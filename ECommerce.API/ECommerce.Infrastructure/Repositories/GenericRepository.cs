
using ECommerce.Domain.Abstractions;
using ECommerce.Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ECommerceReadContext _readContext;
        private readonly ECommerceWriteContext _writeContext;
        private DbSet<T> _readEntity;
        private DbSet<T> _writeEntity;

        public GenericRepository(ECommerceReadContext readContext, ECommerceWriteContext writeContext)
        {
            _readContext = readContext;
            _writeContext = writeContext;
            _readEntity = readContext.Set<T>();
            _writeEntity = writeContext.Set<T>();
        }

        public async Task<List<T>> GetAllAsync() => await _readEntity.ToListAsync();
        public async Task<T?> GetByIdAsync(int id) => await _readEntity.FindAsync(id);
        public async Task<T?> GetByGuid(Guid id) => await _readEntity.FindAsync(id);
        public async Task<T> GetByExpression(Func<T, bool> predicate) => _readEntity.Where(predicate).FirstOrDefault();
        public async Task<IEnumerable<T>> GetAllByExpression(Func<T, bool> predicate) => _readEntity.Where(predicate);


        public async Task AddAsync(T entity) => await _writeEntity.AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<T> entities) => await _writeEntity.AddRangeAsync(entities);
       

        public void Update(T entity) => _writeEntity.Entry(entity).State = EntityState.Modified;
        public void Update(string Query)
        {
            _writeContext.Database.ExecuteSqlRaw(Query);
        }
        

        public async Task DeleteAsync(T entity) => _writeContext.Entry(entity).State = EntityState.Deleted;
        public async Task<bool> IsExist(Expression<Func<T, bool>> filter) => await _writeEntity.AnyAsync(filter);
        public async Task<bool> Save() => await _writeContext.SaveChangesAsync() > 0;
        public async Task SaveAsync() => await _writeContext.SaveChangesAsync();

        public async Task<object> SqlRaw(string Query)
        {
            return await _writeEntity.FromSqlRaw(Query).ToListAsync();
        }

    }
}
