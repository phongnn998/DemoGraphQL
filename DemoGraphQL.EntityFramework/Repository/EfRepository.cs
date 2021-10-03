using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoGraphQL.EntityFramework.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;

namespace DemoGraphQL.EntityFramework
{
    public class EfRepository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : Entity<TPrimaryKey>
    {
        private readonly IDbContext _dbContext;
        private DbSet<TEntity> _entities;

        protected virtual DbSet<TEntity> Entities => _entities ??= _dbContext.Set<TEntity>();

        public IQueryable<TEntity> Table => Entities;
        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public EfRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> DeleteAsync(TPrimaryKey id)
        {
            var entity = await Entities.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.RemoveRange(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> GetByIdAsync(TPrimaryKey Id)
        {
            return await Entities.FindAsync(Id);
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> InsertAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            await Entities.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

            return entities;
        }

        public async Task<IEnumerable<TEntity>> UpdateAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            Entities.UpdateRange(entities);

            await _dbContext.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Entities.Update(entity);

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
