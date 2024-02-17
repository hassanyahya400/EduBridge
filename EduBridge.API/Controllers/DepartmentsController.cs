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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduBridge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private EduBridgeDbContext _eduBridgeDbContext;
        private readonly IMapper _mapper;
        private readonly IDepartmentsRepository _departmentsRepository;

        public DepartmentsController(EduBridgeDbContext eduBridgeDbContext, IMapper mapper, IDepartmentsRepository departmentRepository)
        {
            this._eduBridgeDbContext = eduBridgeDbContext;
            this._mapper = mapper;
            this._departmentsRepository = departmentRepository;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDepartmentsDto>>> GetAll()
        {
            var departments = await _departmentsRepository.GetAllAsync();

            return Ok(_mapper.Map<List<DepartmentDto>>(departments));
        }

        // GET: api/Departments/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<DepartmentDto>> Get(int id)
        {
            var department = await _departmentsRepository.GetOneAsync(id);

            if (department is null) throw new NotFoundException("Department", id);

            return Ok(department);
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateDepartmentDto createDepartmentDto)
        {
            var newDepartment = _mapper.Map<Department>(createDepartmentDto);

            await _departmentsRepository.AddAsync(newDepartment);

            return NoContent();
        }

        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CreateDepartmentDto updateDepartmentDto)
        {
            var department = await _departmentsRepository.GetOneAsync(id) ?? throw new NotFoundException("Department", id);

            _mapper.Map(updateDepartmentDto, department);

            await _departmentsRepository.UpdateAsync(id, department);

            return NoContent();
        }

        // DELETE: api/Department/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _departmentsRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
