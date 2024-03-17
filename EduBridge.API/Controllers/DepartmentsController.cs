using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EduBridge.API.Contracts;
using EduBridge.API.Data;
using EduBridge.API.Exceptions;
using EduBridge.API.Models;
using EduBridge.API.Models.Department;
using EduBridge.API.Models.GenericResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduBridge.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMapper _mapper;

        private readonly IDepartmentsRepository _departmentsRepository;

        public DepartmentsController (IMapper mapper, IDepartmentsRepository departmentRepository)
        {
            this._mapper = mapper;
            this._departmentsRepository = departmentRepository;
        }

        // GET: api/Departments
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll()
        {
            var departments = await _departmentsRepository.GetAllAsync();
            var result = _mapper.Map<List<DepartmentDto>>(departments);

            return Ok(new SuccessResponse
            {
                Message = "Departments retrieved successfully",
                Data = result
            });
        }

        // GET: api/Departments?StartIndex=1
        [HttpGet]
        public async Task<ActionResult<PagedResponse<DepartmentDto>>> GetAll([FromQuery] QueryParameters queryParameters)
        {
            var result = await _departmentsRepository.GetAllAsync<DepartmentDto>(queryParameters);

            return Ok(result);
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<DepartmentDto>> GetOne(string id)
        {
            var department = await _departmentsRepository.GetOneAsync(id);

            if (department is null)
            {
                throw new NotFoundException("Department", id);
            }

            return Ok(new SuccessResponse
            {
                Message = "Department retrieved successfully",
                Data = department
            });
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            var newDepartment = _mapper.Map<Department>(createDepartmentDto);

            await _departmentsRepository.AddAsync(newDepartment);

            return Created("",new SuccessResponse
            {
                Message = "Department created successfully"
            });
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, [FromBody] CreateDepartmentDto updateDepartmentDto)
        {
            var department = await _departmentsRepository.GetOneAsync(id) ?? throw new NotFoundException("Department", id);

            _mapper.Map(updateDepartmentDto, department);

            await _departmentsRepository.UpdateAsync(id, department);

            return Ok(new SuccessResponse
            {
                Message = $"Department id({id}) updated successfully"
            });
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _departmentsRepository.DeleteAsync(id);

            return Ok(new SuccessResponse
            {
                Message = $"Department id: {id} deleted successfully"
            });
        }
    }
}
