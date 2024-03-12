using System;
using EduBridge.API.Models;
using EduBridge.API.Models.GenericResponse;

namespace EduBridge.API.Contracts
{
	public interface IGenericRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync();

        Task<List<TEntity>> GetAllByDepartmentAsync<TEntity>(int departmentId) where TEntity : class;

		Task<PagedResponse<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters);

		Task<T?> GetOneAsync(string id);

		Task<T> AddAsync(T entity);

		Task UpdateAsync(string id, T entity);

		Task DeleteAsync(string id);

		Task<bool> Exists(string id);
	}
}