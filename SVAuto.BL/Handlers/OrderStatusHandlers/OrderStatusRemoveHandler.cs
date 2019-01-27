using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderStatusHandlers
{
    public class OrderStatusRemoveHandler
        : BaseRemoveHandler<OrderStatus>
    {
        public OrderStatusRemoveHandler(
            IOrderStatusRepository repository,
            ILogger<OrderStatusRemoveHandler> logger)
            : base(repository, logger)
        {

        }
    }
}
