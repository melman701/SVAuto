using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderStatusHandlers
{
    public class OrderStatusGetHandler
        : BaseGetHandler<OrderStatus>
    {
        public OrderStatusGetHandler(
            IOrderStatusRepository repository,
            ILogger<OrderStatusGetHandler> logger)
            : base(repository, logger)
        {

        }
    }
}
