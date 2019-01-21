using Microsoft.Extensions.Logging;
using SVAuto.EF.Model;

namespace SVAuto.DAL.Repositories
{
    public interface IOrderRepository : IBaseRepository<SVAutoDbContext, Order>
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
