using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SVAuto.EF.Model;
using System.Collections.Generic;
using System.Linq;

namespace SVAuto.DAL.Repositories
{
    public class BaseRepository<TContext, TEntity>
        : IBaseRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class, IBaseEntity
    {
        private readonly ILogger logger;

        public BaseRepository(TContext context, ILogger logger)
        {
            DbContext = context;
            this.logger = logger;
        }

        public TContext DbContext { get; }

        public virtual DbSet<TEntity> DefaultSet => DbContext.Set<TEntity>();

        public virtual void Add(TEntity entity)
        {
            logger.LogDebug($"Add enity: {entity}");
            DefaultSet.Add(entity);
        }

        public virtual TEntity Get(int id)
        {
            if (id <= 0)
            {
                logger.LogWarning($"Try to get entity with invalid id {id}");
                return null;
            }

            logger.LogDebug($"Get {typeof(TEntity).Name} with id {id}");
            return DefaultSet.SingleOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            logger.LogDebug($"Get all {typeof(TEntity).Name}");
            return DefaultSet.ToList();
        }

        public virtual void Remove(int id)
        {
            logger.LogDebug($"Remove {typeof(TEntity).Name} with id {id}");
            var entity = Get(id);
            Remove(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            logger.LogDebug($"Remove entity: {entity}");
            DefaultSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            logger.LogDebug($"Update entity: {entity}");
            DefaultSet.Update(entity);
        }

        public virtual void SaveChanges()
        {
            logger.LogDebug($"Save changes into database");
            DbContext.SaveChanges();
        }
    }
}
