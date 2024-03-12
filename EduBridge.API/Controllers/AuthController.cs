using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EduBridge.API.Contracts;
using EduBridge.API.Data;
using EduBridge.API.Models.Authentication;
using EduBridge.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduBridge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IAuthManagerRepository _authManagerRepository;

        public AuthController (IMapper mapper, IAuthManagerRepository authManagerRepository)
        {
            this._mapper = mapper;
            this._authManagerRepository = authManagerRepository;
        }

        [HttpPost]
        [Route("register/admin")]
        public async Task<IActionResult> RegisterAdministrator([FromBody] EduBridgeUserDto teacherDto)
        {
            try
            {
                var errors = await _authManagerRepository.Register(teacherDto, "ADMINISTRATOR");

                if (errors.Any())
                {
                    foreach(var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(errors);
                }

                return Ok();
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"An error occured while trying to create user {teacherDto.Email}", Ex.Message);
                return Problem();
            }
        }

        [HttpPost]
        [Route("register/teacher")]
        public async Task<IActionResult> RegisterTeacher([FromBody] EduBridgeUserDto teacherDto)
        {
            try
            {
                var errors = await _authManagerRepository.Register(teacherDto, "TEACHER");

                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(errors);
                }

                return Ok();
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"An error occured while trying to create user {teacherDto.Email}", Ex.Message);
                return Problem();
            }
        }

        [HttpPost]
        [Route("register/student")]
        public async Task<IActionResult> RegisterStudent([FromBody] EduBridgeUserDto studentDto)
        {
            try
            {
                var errors = await _authManagerRepository.Register(studentDto, "STUDENT");

                if (errors.Any())
                {
                    foreach (var error in errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }

                    return BadRequest(errors);
                }

                return Ok();
            }
            catch (Exception Ex)
            {
                Console.WriteLine($"An error occured while trying to create user {studentDto.Email}", Ex.Message);
                return Problem();
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto loginDto)
        {
            AuthResponseDto response = await _authManagerRepository.Login(loginDto);

            if (response is null)
            {
                return Problem("An error occured! cannot login");
            }

            return Ok(response);
            
        }
    }
}

