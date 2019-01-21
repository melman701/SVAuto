using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SVAuto.DAL.Repositories
{
    public class BaseRepository<TContext, TEntity>
        : IBaseRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        private readonly ILogger logger;

        public BaseRepository(TContext context, ILogger logger)
        {
            DbContext = context;
            this.logger = logger;
        }

        public TContext DbContext { get; }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetAll()
        {
            logger.LogDebug($"Get all {typeof(TEntity).Name} data");
            return DbContext.Set<TEntity>().ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
