using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderStatusHandlers
{
    public class OrderStatusGetAllHandler : BaseGetAllHandler<OrderStatus>
    {
        public OrderStatusGetAllHandler(
            IOrderStatusRepository repository,
            ILogger<OrderStatusGetAllHandler> logger)
            : base(repository, logger)
        {

        }
    }
}
