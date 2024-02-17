using System;
using EduBridge.API.Contracts;
using EduBridge.API.Data;
using EduBridge.API.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;

namespace EduBridge.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly EduBridgeDbContext _context;

        public GenericRepository(EduBridgeDbContext context)
        {
            this._context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetOneAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetOneAsync(id);

            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
             return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetOneAsync(int? id)
        {
            if (id is null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var record = GetOneAsync(id);

            if (record is null)
            {
                throw new NotFoundException("Entity", id);
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();
            return;
        }
    }
}

