using System;

namespace EduBridge.API.Contracts
{
	public interface IGenericRepository<T> where T : class
	{
		Task<List<T>> GetAllAsync();

		Task<T?> GetOneAsync(int? id);

		Task<T> AddAsync(T entity);

		Task UpdateAsync(int id, T entity);

		Task DeleteAsync(int id);

		Task<bool> Exists(int id);
		
	}
}