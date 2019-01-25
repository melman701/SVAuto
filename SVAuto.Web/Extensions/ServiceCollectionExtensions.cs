using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SVAuto.BL.Handlers.OrderHandlers;
using SVAuto.DAL;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.Global;

namespace SVAuto.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomDbContext(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<SVAutoDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString(
                    SVAutoConfiguration.SVAutoConnectionString);
                options.UseSqlite(connectionString);
            });

            return services;
        }

        public static IServiceCollection AddCustomDependencyInjection(
            this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<OrderGetAllHandler>();

            return services;
        }
    }
}
