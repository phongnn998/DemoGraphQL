using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphQL.EntityFramework
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
        Task<TEntity> GetByIdAsync(TPrimaryKey Id);

        Task<TEntity> InsertAsync(TEntity entity);
        Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entities);

        Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TPrimaryKey id);
    }
}
