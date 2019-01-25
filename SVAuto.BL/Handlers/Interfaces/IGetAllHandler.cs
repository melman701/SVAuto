using System.Collections.Generic;

namespace SVAuto.BL.Handlers.Interfaces
{
    public interface IGetAllHandler<TEntity>
    {
        HandlerResult<List<TEntity>> Execute();
    }
}
