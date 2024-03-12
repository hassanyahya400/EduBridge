using System;
using AutoMapper;
using EduBridge.API.Contracts;
using EduBridge.API.Data;

namespace EduBridge.API.Repository
{
	public class DepartmentsRepository : GenericRepository<Department>, IDepartmentsRepository
	{
		private readonly IMapper _mapper;

		private readonly EduBridgeDbContext _context;

		public DepartmentsRepository (IMapper mapper, EduBridgeDbContext context) : base(mapper, context)
		{
			this._mapper = mapper;
			this._context = context;
		}
	}
}
