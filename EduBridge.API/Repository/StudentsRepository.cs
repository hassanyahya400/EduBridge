using System;
using AutoMapper;
using EduBridge.API.Contracts;
using EduBridge.API.Data;

namespace EduBridge.API.Repository
{
	public class StudentsRepository : GenericRepository<Student>, IStudentsRepository
	{
        private readonly IMapper _mapper;

        private readonly EduBridgeDbContext _context;

        public StudentsRepository(IMapper mapper, EduBridgeDbContext context) : base(mapper, context)
		{
			this._mapper = mapper;
			this._context = context;
		}
	}
}

