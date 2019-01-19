using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SVAuto.DAL;
using SVAuto.Global;

namespace SVAuto.Web
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SVAutoDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString(SVAutoConfiguration.SVAutoConnectionString));
            });

            return services;
        }
    }
}
