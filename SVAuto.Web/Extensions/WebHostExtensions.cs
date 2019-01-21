using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SVAuto.Web.Extensions
{
    public static class IWebHostExtensions
    {
        public static IWebHost MigrateDbContext<TContext>(
            this IWebHost webHost)
            where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation($"Migrating database assiciated with context {typeof(TContext).Name}");
                    var retry = Policy.Handle<SqlException>()
                        .WaitAndRetry(new TimeSpan[]
                        {
                            TimeSpan.FromSeconds(3),
                            TimeSpan.FromSeconds(5),
                            TimeSpan.FromSeconds(8)
                        });

                    retry.Execute(() =>
                    {
                        context.Database.Migrate();
                    });
                    
                    logger.LogInformation($"Migrated database assiciated with context {typeof(TContext).Name}");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occurred while migrating the database used on context {typeof(TContext).Name}");
                }
            }

            return webHost;
        }

        public static IWebHost SeedModel<TContext, TModel>(
            this IWebHost webHost, Func<IHostingEnvironment ,IEnumerable<TModel>> values)
            where TContext : DbContext where TModel : class
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();
                var env = services.GetService<IHostingEnvironment>();

                logger.LogInformation($"Seeding model {typeof(TModel).Name} default data with context {typeof(TContext).Name}");

                Task.Run(async () =>
                {
                    int retries = 3;
                    var policy = Policy.Handle<SqlException>().
                    WaitAndRetryAsync(
                        retryCount: retries,
                        sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                        onRetry: (exception, timeSpan, retry, ctx) =>
                        {
                            logger.LogTrace($"Exception {exception.GetType().Name} with message ${exception.Message} detected on attempt {retry} of {retries}");
                        }
                    );

                    await policy.ExecuteAsync(async () =>
                    {
                        if (!context.Set<TModel>().Any())
                        {
                            await context.Set<TModel>().AddRangeAsync(values(env));
                            await context.SaveChangesAsync();
                        }
                    });
                }).Wait();
                logger.LogInformation($"Finished seeding model {typeof(TModel).Name} data with context {typeof(TContext).Name}");
            }

            return webHost;
        }
    }
}
