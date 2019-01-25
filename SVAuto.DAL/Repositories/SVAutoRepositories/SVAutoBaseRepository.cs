using Microsoft.Extensions.Logging;
using SVAuto.EF.Model;

namespace SVAuto.DAL.Repositories.SVAutoRepositories
{
    public class SVAutoBaseRepository<TEntity>
        : BaseRepository<SVAutoDbContext, TEntity>,
        ISVAutoBaseRepository<TEntity>
        where TEntity: class, IBaseEntity
    {
        public SVAutoBaseRepository(SVAutoDbContext context, ILogger<SVAutoBaseRepository<TEntity>> logger)
            : base (context, logger)
        {

        }
    }
}
