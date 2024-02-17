using System;
using EduBridge.API.Contracts;
using EduBridge.API.Data;

namespace EduBridge.API.Repository
{
	public class DepartmentsRepository : GenericRepository<Department>, IDepartmentsRepository
	{
		private readonly EduBridgeDbContext _context;

		public DepartmentsRepository(EduBridgeDbContext context) : base(context)
		{
			this._context = context;
		}
	}
}
