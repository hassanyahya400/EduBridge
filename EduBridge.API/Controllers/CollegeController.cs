using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EduBridge.API.Contracts;
using EduBridge.API.Data;
using EduBridge.API.Models;
using EduBridge.API.Models.Department;
using EduBridge.API.Models.GenericResponse;
using EduBridge.API.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EduBridge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CollegeController : ControllerBase
    {
        public readonly IMapper _mapper;

        public readonly ICollegeRepository _collegeRepository;

        public CollegeController (IMapper mapper, ICollegeRepository collegeRepository)
        {
            this._mapper = mapper;
            this._collegeRepository = collegeRepository;
        }

         //GET: api/Colleges
        //[HttpGet]
        //[Route("{id}/departments")]
        //public async Task<ActionResult<IEnumerable<GetDepartmentsDto>>> GetDepartments(int id)
        //{
        //    var departments = await _collegeRepository.GetAllAsync();
        //    var result = _mapper.Map<List<DepartmentDto>>(departments);

        //    return Ok(new SuccessResponse
        //    {
        //        Message = "Departments retrieved successfully",
        //        Data = result
        //    });
        //}
    }
}

