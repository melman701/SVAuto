using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using SVAuto.DAL;
using SVAuto.EF.Model;
using SVAuto.Web.Extensions;
using SVAuto.Web.Utils;

namespace SVAuto.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("Initialize SVAuto application");
                CreateWebHostBuilder(args)
                    .Build()
                    .MigrateDbContext<SVAutoDbContext>()
                    .SeedModel<SVAutoDbContext, OrderStatus>((env) =>
                    {
                        return CsvReader<OrderStatus>.GetModelFromFile(
                            Path.Combine(env.ContentRootPath, "Setup", "SVAutoDatabase", "OrderStatuses.csv"),
                            new string[] { "Name", "Description" },
                            (columns, headers) =>
                            {
                                int iName = Array.IndexOf(headers, "Name");
                                int iDesc = Array.IndexOf(headers, "Description");
                                return new OrderStatus
                                {
                                    Name = columns[iName],
                                    Description = columns[iDesc]
                                };
                            });
                    })
                    .Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Application stopped because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Trace);
                })
                .UseNLog();
    }
}
