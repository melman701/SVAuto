using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderHandlers
{
    public class OrderRemoveHandler
        : BaseRemoveHandler<Order>
    {
        public OrderRemoveHandler(IOrderRepository repository,
            ILogger<OrderRemoveHandler> logger)
            : base(repository, logger)
        {

        }
    }
}
