using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.Interfaces;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using System;

namespace SVAuto.BL.Handlers.BaseHandlers
{
    public class BaseRemoveHandler<TEntity>
        : SVAutoBaseHandler<TEntity>
        ,IRemoveHandler
        where TEntity: class
    {
        public BaseRemoveHandler(ISVAutoBaseRepository<TEntity> repository, ILogger logger)
            : base(repository, logger)
        {

        }

        public virtual HandlerResult Execute(int id)
        {
            try
            {
                logger.LogDebug($"Remove {typeof(TEntity).Name} {id}");
                repository.Remove(id);
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
