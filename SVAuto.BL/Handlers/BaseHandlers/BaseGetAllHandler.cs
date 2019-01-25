using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.Interfaces;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SVAuto.BL.Handlers.BaseHandlers
{
    public class BaseGetAllHandler<TEntity>
        : SVAutoBaseHandler<TEntity>
        , IGetAllHandler<TEntity>
        where TEntity: class
    {
        public BaseGetAllHandler(ISVAutoBaseRepository<TEntity> repository, ILogger logger)
            : base(repository, logger)
        {

        }

        public virtual HandlerResult<List<TEntity>> Execute()
        {
            try
            {
                logger.LogDebug($"Get all {typeof(TEntity).Name}");
                var result = repository.GetAll().ToList();
                return HandlerResultFactory.GetSuccessResult(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"{typeof(TEntity).Name}");
                return HandlerResultFactory.GetFailResult<List<TEntity>>(ex);
            }
        }
    }
}
