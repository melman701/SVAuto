using Microsoft.Extensions.Logging;
using SVAuto.DAL.Repositories.SVAutoRepositories;

namespace SVAuto.BL.Handlers
{
    public class SVAutoBaseHandler<TEntity>
        : BaseHandler
        where TEntity: class
    {
        protected readonly ISVAutoBaseRepository<TEntity> repository;

        public SVAutoBaseHandler(ISVAutoBaseRepository<TEntity> repository, ILogger logger)
            : base(logger)
        {
            this.repository = repository;
        }
    }
}
