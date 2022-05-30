using CE.Contracts;
using CE.Domain.Helpers;
using CE.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CE.Cli
{
    public class Program
    {
        public static IConfiguration Config { get; set; }

        async static Task Main(string[] args)
        {
            try
            {
                IServiceCollection services = new ServiceCollection();

                var settings = new Settings(
                    "https://api-dev.channelengine.net/api/v2/products", 
                    "541b989ef78ccb1bad630ea5b85c6ebff9ca3322");


                LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

                services.RegisterServices(settings);

                var serviceProvider = services.BuildServiceProvider();

                var rt = new Runtime(
                    serviceProvider.GetService<IOrderService>(), 
                    serviceProvider.GetService<ILoggerService>());

                await rt.Run();
            }
            catch (Exception)
            {
                Environment.Exit(-1);
            }
        }
    }
}
