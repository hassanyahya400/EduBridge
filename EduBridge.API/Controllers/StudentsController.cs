using System;
using AutoMapper;
using EduBridge.API.Contracts;
using EduBridge.API.Data;
using EduBridge.API.Models;
using EduBridge.API.Models.Authentication;
using EduBridge.API.Models.GenericResponse;
using EduBridge.API.Models.User;
using EduBridge.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;

namespace EduBridge.API.Controllers
{
	[ApiController]
	[Route("api")]
	//[Authorize]
	public class StudentsController : ControllerBase
	{
		private readonly IMapper _mapper;

		private readonly IStudentsRepository _studentsRepository;

		public StudentsController(IMapper mapper, IStudentsRepository studentsRepository)
		{
			this._mapper = mapper;
			this._studentsRepository = studentsRepository;
		}

        // GET: api/departmentId/students
        [HttpGet("departments/{departmentId}/students")]
        public async Task<ActionResult<IList<BaseUserDto>>> GetAll(int departmentId)
        {
            var students = await _studentsRepository.GetAllByDepartmentAsync<Student>(departmentId);
            var result = _mapper.Map<List<GetStudentsDto>>(students);

            return Ok(new SuccessResponse
            {
                Message = "Students retrieved successfully",
                Data = result
            });
        }

        [HttpGet("students/{id}")]
        public async Task<ActionResult<GetStudentDetails>> GetOne(string id)
        {
            var student = await _studentsRepository.GetOneAsync(id);
            _mapper.Map<GetStudentDetails>(student);

            return Ok(new SuccessResponse
            {
                Message = "Students retrieved successfully",
                Data = student
            });
        }
    }
}

