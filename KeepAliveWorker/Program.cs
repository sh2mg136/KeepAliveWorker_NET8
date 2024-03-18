using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;

namespace KeepAliveWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            // var logger = NLog.LogManager.LoadConfiguration("nlog.config").GetCurrentClassLogger();
            var logger = LogManager.GetCurrentClassLogger();

            try
            {
                logger.Info("Starting...");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                logger.Fatal(ex);
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .UseWindowsService()
            .ConfigureServices((hostContext, services) =>
            {
                var env = hostContext.HostingEnvironment;

                services.AddHostedService<Worker>();

                // var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
                var logger = LogManager.GetCurrentClassLogger();

                logger.Info(Environment.NewLine);
                logger.Info($"HostingEnvironment: {env.EnvironmentName}");
                logger.Info("Worker added");

                try
                {
                    IConfiguration configuration = hostContext.Configuration;

                    ServiceConfig cfg = configuration.GetSection("ServiceConfig").Get<ServiceConfig>();

                    services.AddSingleton(cfg);

                    logger.Info("Configuration accepted");
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }

                /*
                services.AddHostedService<Worker>();
                var provider = services.BuildServiceProvider();
                var factory = provider.GetService<ILoggerFactory>();
                LogManager.LoadConfiguration("nlog.config");
                var logger = provider.GetService<ILogger<Program>>();
                logger.LogInformation("Service started");
                services.AddLogging();
                */
            })
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            })
            .UseNLog();
    }
}