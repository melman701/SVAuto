using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderHandlers
{
    public class OrderUpdateHandler
        : BaseUpdateHandler<Order>
    {
        public OrderUpdateHandler(IOrderRepository repository,
            ILogger<OrderUpdateHandler> logger)
            : base(repository, logger)
        {

        }
    }
}
