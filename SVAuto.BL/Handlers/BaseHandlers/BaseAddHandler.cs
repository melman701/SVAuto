using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.Interfaces;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using System;

namespace SVAuto.BL.Handlers.BaseHandlers
{
    public class BaseAddHandler<TEntity>
        : SVAutoBaseHandler<TEntity>
        ,IAddHandler<TEntity>
        where TEntity: class
    {
        public BaseAddHandler(ISVAutoBaseRepository<TEntity> repository, ILogger logger)
            : base(repository, logger)
        {

        }

        public virtual HandlerResult Execute(TEntity entity)
        {
            try
            {
                logger.LogDebug($"Add {typeof(TEntity).Name}: {entity}");
                repository.Add(entity);
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
