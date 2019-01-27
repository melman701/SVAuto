using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderStatusHandlers
{
    public class OrderStatusAddHandler
        : BaseAddHandler<OrderStatus>
    {
        public OrderStatusAddHandler(
            IOrderStatusRepository repository,
            ILogger<OrderStatusAddHandler> logger)
            : base(repository, logger)
        {

        }
    }
}
