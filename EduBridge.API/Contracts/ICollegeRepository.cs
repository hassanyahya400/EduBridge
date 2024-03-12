using System;
using EduBridge.API.Data;

namespace EduBridge.API.Contracts
{
	public interface ICollegeRepository : IGenericRepository<College>
	{
        Task<List<Department>> GetDepartmentsAsync();

        Task<List<Teacher>> GetTeachersAsync();

        Task<List<Student>> GetStudentsAsync();
    }
}