using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderHandlers
{
    public class OrderAddHandler
        : BaseAddHandler<Order>
    {
        public OrderAddHandler(IOrderRepository orderRepository,
            ILogger<OrderAddHandler> logger)
            : base(orderRepository, logger)
        {

        }
    }
}
