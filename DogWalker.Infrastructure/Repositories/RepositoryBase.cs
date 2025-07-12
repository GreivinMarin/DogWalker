using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using DogWalker.Core.Interfaces;
using DogWalker.Infrastructure.Data;
using DogWalker.Core;

namespace DogWalker.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly IDatabaseContext _context;

        public RepositoryBase(IDatabaseContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            string sql = GetSelectAllQuery();
            return await _context.Connection.QueryAsync<T>(sql);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            string sql = GetSelectByIdQuery();
            var parameters = new { Id = id };
            return await _context.Connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            string sql = GetInsertQuery();
            return await _context.Connection.ExecuteScalarAsync<int>(sql, entity);
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            string sql = GetUpdateQuery();
            int rowsAffected = await _context.Connection.ExecuteAsync(sql, entity);
            return rowsAffected > 0;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            string sql = GetDeleteQuery();
            var parameters = new { Id = id };
            int rowsAffected = await _context.Connection.ExecuteAsync(sql, parameters);
            return rowsAffected > 0;
        }

        // Métodos abstractos para que las clases hijas implementen sus queries SQL
        protected abstract string GetSelectAllQuery();
        protected abstract string GetSelectByIdQuery();
        protected abstract string GetInsertQuery();
        protected abstract string GetUpdateQuery();
        protected abstract string GetDeleteQuery();
    }
}
