using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderHandlers
{
    public class OrderGetHandler
        : BaseGetHandler<Order>
    {
        public OrderGetHandler(IOrderRepository repository,
            ILogger<OrderGetHandler> logger)
            : base(repository, logger)
        {

        }
    }
}
