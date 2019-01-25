using Microsoft.Extensions.Logging;
using SVAuto.EF.Model;

namespace SVAuto.DAL.Repositories.SVAutoRepositories
{
    public interface IOrderRepository : ISVAutoBaseRepository<Order>
    {

    }


    public class OrderRepository : BaseRepository<SVAutoDbContext, Order>, IOrderRepository
    {
        public OrderRepository(SVAutoDbContext dbContext, ILogger<OrderRepository> logger)
            : base(dbContext, logger)
        {

        }
    }
}
