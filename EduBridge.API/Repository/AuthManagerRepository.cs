using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using EduBridge.API.Contracts;
using EduBridge.API.Data;
using EduBridge.API.Models.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace EduBridge.API.Repository
{
	public class AuthManagerRepository : IAuthManagerRepository
	{
        private readonly IMapper _mapper;

		private readonly UserManager<EduBridgeUser> _userManager;

		private readonly IConfiguration _configuration;

		private readonly ILogger<AuthManagerRepository> _logger;

        private EduBridgeUser? _user;

        private const string _loginProvider = "EduBridgeApi";

        private const string _refreshToken = "RefreshToken";

        private const string ADMINISTRATOR = "ADMINISTRATOR";

        private const string TEACHER = "TEACHER";

        private const string STUDENT = "STUDENT";


        public AuthManagerRepository (IMapper mapper, UserManager<EduBridgeUser> userManager, IConfiguration configuration, ILogger<AuthManagerRepository> logger)
        { 
            this._mapper = mapper;
            this._userManager = userManager;
			this._configuration = configuration;
			this._logger = logger;
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
            var result = _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);

            return newRefreshToken;
        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            _user = await _userManager.FindByEmailAsync(loginDto.Email);
            bool hasValidCredentials = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

            if (_user is null || hasValidCredentials is false)
            {
                // thro exception here later
                return null;
            }

            var token = await GenerateToken();
            return new AuthResponseDto()
            {
                UserId = _user.Id,
                Email = _user.Email,
                Token = token,
                RefreshToken = await CreateRefreshToken()
            };

        }

        public async Task<IEnumerable<IdentityError>> Register(EduBridgeUserDto userDto, string userRole)
        {
            switch (userRole)
            {
                case ADMINISTRATOR:
                    _user = _mapper.Map<Teacher>(userDto);
                    break;

                case TEACHER:
                    _user = _mapper.Map<Teacher>(userDto);
                    break;

                case STUDENT:
                    _user = _mapper.Map<Student>(userDto);
                    break;

                default:
                    break;
            }

            _user.UserName = _user.Email;

            var result = await _userManager.CreateAsync(_user, userDto.Password);

            if (result.Succeeded is true)
            {
                switch (userRole)
                {
                    case ADMINISTRATOR:
                        await _userManager.AddToRoleAsync(_user, ADMINISTRATOR);
                        break;

                    case TEACHER:
                        await _userManager.AddToRoleAsync(_user, TEACHER);
                        break;

                    case STUDENT:
                        await _userManager.AddToRoleAsync(_user, STUDENT);
                        break;

                    default:
                        break;
                }
            }

            return result.Errors;
        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
            _user = await _userManager.FindByEmailAsync(username);

            if (_user is null)
            {
                // throw exception later
                return null;
            }

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);

            if (isValidRefreshToken)
            {
                var token = await GenerateToken();

                return new AuthResponseDto()
                {
                    UserId = _user.Id,
                    Email = _user.Email,
                    Token = token,
                    RefreshToken = await CreateRefreshToken()
                };
            }

            await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }

        public async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roles = await _userManager.GetRolesAsync(_user);
            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, _user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, _user.Email),
                new Claim("uid", _user.Id)
            }
            .Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
