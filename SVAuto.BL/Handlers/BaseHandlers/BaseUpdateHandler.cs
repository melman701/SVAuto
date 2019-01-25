using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.Interfaces;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using System;

namespace SVAuto.BL.Handlers.BaseHandlers
{
    public class BaseUpdateHandler<TEntity>
        : SVAutoBaseHandler<TEntity>
        , IUpdateHandler<TEntity>
        where TEntity: class
    {
        public BaseUpdateHandler(ISVAutoBaseRepository<TEntity> repository, ILogger logger)
            : base(repository, logger)
        {

        }

        public virtual HandlerResult Execute(TEntity entity)
        {
            try
            {
                logger.LogDebug($"Update {typeof(TEntity).Name}: {entity}");
                repository.Update(entity);
                repository.SaveChanges();
                return HandlerResultFactory.GetSuccessResult();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"{typeof(TEntity).Name}");
                return HandlerResultFactory.GetFailResult(ex.Message);
            }
        }
    }
}
