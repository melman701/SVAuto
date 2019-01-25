namespace SVAuto.DAL.Repositories.SVAutoRepositories
{
    public interface ISVAutoBaseRepository<TEntity>
        : IBaseRepository<SVAutoDbContext, TEntity>
        where TEntity: class
    {
    }
}
