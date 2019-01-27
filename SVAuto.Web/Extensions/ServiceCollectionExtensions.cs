using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SVAuto.BL.Handlers.OrderHandlers;
using SVAuto.BL.Handlers.OrderStatusHandlers;
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
                options
                    .UseLazyLoadingProxies()
                    .UseSqlite(connectionString);
            });

            return services;
        }

        public static IServiceCollection AddCustomDependencyInjection(
            this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<OrderGetAllHandler>();
            services.AddScoped<OrderGetHandler>();
            services.AddScoped<OrderAddHandler>();
            services.AddScoped<OrderRemoveHandler>();
            services.AddScoped<OrderUpdateHandler>();

            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<OrderStatusGetAllHandler>();
            services.AddScoped<OrderStatusGetHandler>();
            services.AddScoped<OrderStatusAddHandler>();
            services.AddScoped<OrderStatusRemoveHandler>();
            services.AddScoped<OrderStatusUpdateHandler>();

            return services;
        }
    }
}
