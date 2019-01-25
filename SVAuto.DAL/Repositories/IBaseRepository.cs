using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace SVAuto.DAL.Repositories
{
    public interface IBaseRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class
    {
        TContext DbContext { get; }

        DbSet<TEntity> DefaultSet { get; }

        IEnumerable<TEntity> GetAll();

        TEntity Get(int id);
        void Remove(int id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        void SaveChanges();
    }
}
