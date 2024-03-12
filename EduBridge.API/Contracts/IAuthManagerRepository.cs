using System;
using EduBridge.API.Data;
using EduBridge.API.Models.Authentication;
using Microsoft.AspNetCore.Identity;
namespace EduBridge.API.Contracts
{
	public interface IAuthManagerRepository
    {
        Task<string> GenerateToken();

        Task<AuthResponseDto> Login(LoginDto loginDto);

        Task<IEnumerable<IdentityError>> Register(EduBridgeUserDto userDto, string userRole);

        Task<string> CreateRefreshToken();

        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
    }
}

