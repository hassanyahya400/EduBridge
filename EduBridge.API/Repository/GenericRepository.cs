using System;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using EduBridge.API.Contracts;
using EduBridge.API.Data;
using EduBridge.API.Exceptions;
using EduBridge.API.Models;
using EduBridge.API.Models.GenericResponse;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;

namespace EduBridge.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IMapper _mapper;

        private readonly EduBridgeDbContext _context;

        public GenericRepository (IMapper mapper, EduBridgeDbContext context)
        {
            this._mapper = mapper;
            this._context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(string id)
        {
            var record = await GetOneAsync(id);

            if (record is null)
            {
                throw new NotFoundException("Entity", id);
            }

            _context.Set<T>().Remove(record);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(string id)
        {
            var entity = await GetOneAsync(id);

            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
             return await _context.Set<T>().ToListAsync();
        }

        public async Task<PagedResponse<TResult>> GetAllAsync<TResult>(QueryParameters queryParameters)
        {
            int totalCount = await _context.Set<T>().CountAsync();
            var result = await _context.Set<T>()
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<TResult>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new PagedResponse<TResult>
            {
                TotalCount = totalCount,
                PageSize = queryParameters.PageSize,
                Data = result
            };
        }

        public async Task<List<TEntity>> GetAllByDepartmentAsync<TEntity>(int departmentId) where TEntity : class
        {
            var departmentProperty = typeof(TEntity).GetProperty("DepartmentId");

            if(departmentProperty is null)
            {
                throw new NotFoundException("property", "DepartmentId");
            }

            var entities = await _context.Set<TEntity>()
                .Where(e => EF.Property<int>(e, "DepartmentId") == departmentId)
                .ToListAsync();

            return entities;
        }

        public async Task<T?> GetOneAsync(string id)
        {
            if (Int32.TryParse(id, out int intId))
            {
                return await _context.Set<T>().FindAsync(intId);
            }
            else
            {
                return await _context.Set<T>().FindAsync(id);
            }
        }

        public async Task UpdateAsync(string id, T entity)
        {
            if (await Exists(id) is false)
            {
                throw new NotFoundException("Entity", id);
            }

            _context.Update(entity);
            await _context.SaveChangesAsync();
            return;
        }
    }
}

