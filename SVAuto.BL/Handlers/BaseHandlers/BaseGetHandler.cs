using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.Interfaces;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using System;

namespace SVAuto.BL.Handlers.BaseHandlers
{
    public class BaseGetHandler<TEntity>
        : SVAutoBaseHandler<TEntity>
        ,IGetHandler<TEntity>
        where TEntity: class
    {
        public BaseGetHandler(ISVAutoBaseRepository<TEntity> repository, ILogger logger)
            : base(repository, logger)
        {
            
        }

        public virtual HandlerResult<TEntity> Execute(int id)
        {
            try
            {
                logger.LogDebug($"Get {typeof(TEntity).Name} {id}");
                var result = repository.Get(id);
                return HandlerResultFactory.GetSuccessResult(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"{typeof(TEntity).Name}");
                return HandlerResultFactory.GetFailResult<TEntity>(ex);
            }
        }
    }
}
