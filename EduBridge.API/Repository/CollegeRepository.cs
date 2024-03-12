using System;
using AutoMapper;
using EduBridge.API.Contracts;
using EduBridge.API.Data;

namespace EduBridge.API.Repository
{
	public class CollegeRepository : GenericRepository<College>, ICollegeRepository
	{
        private readonly IMapper _mapper;

        private readonly EduBridgeDbContext _context;

        public CollegeRepository (IMapper mapper, EduBridgeDbContext context) : base(mapper, context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public Task<List<Department>> GetDepartmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetTeachersAsync()
        {
            throw new NotImplementedException();
        }
    }
}

