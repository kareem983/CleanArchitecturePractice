using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Abstractions
{
    public interface IGenericRepository <T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByGuid(Guid id);
        Task<T> GetByExpression(Func<T, bool> predicate);
        Task<IEnumerable<T>> GetAllByExpression(Func<T, bool> predicate);


        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);


        void Update(T entity);
        void Update(string Query);
       
        Task DeleteAsync(T entity);
        Task<bool> IsExist(Expression<Func<T, bool>> filter);
        Task<bool> Save();
        Task SaveAsync();
        Task<object> SqlRaw(string Query);

    }
}
