using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SVAuto.EF.Model;
using SVAuto.EF.EntityConfigurations;

namespace SVAuto.DAL
{
    public class SVAutoDbContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrdersStatuses { get; set; }

        public SVAutoDbContext(DbContextOptions<SVAutoDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderStatusEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
        }
    }
}
