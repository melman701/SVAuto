using Microsoft.Extensions.Logging;
using SVAuto.EF.Model;

namespace SVAuto.DAL.Repositories.SVAutoRepositories
{
    public interface IOrderStatusRepository : ISVAutoBaseRepository<OrderStatus>
    {

    }


    public class OrderStatusRepository : SVAutoBaseRepository<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(SVAutoDbContext dbContext,
            ILogger<OrderStatusRepository> logger)
            : base(dbContext, logger)
        {

        }
    }
}
