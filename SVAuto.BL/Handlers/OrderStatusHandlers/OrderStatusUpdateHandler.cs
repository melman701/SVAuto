using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderStatusHandlers
{
    public class OrderStatusUpdateHandler
        : BaseUpdateHandler<OrderStatus>
    {
        public OrderStatusUpdateHandler(
            IOrderStatusRepository repository,
            ILogger<OrderStatusUpdateHandler> logger)
            : base(repository, logger)
        {

        }
    }
}
