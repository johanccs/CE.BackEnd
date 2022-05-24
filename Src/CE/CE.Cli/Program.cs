using CE.Contracts;
using CE.IoC;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace CE.Cli
{
    public class Program
    {
        async static Task Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            
            services.RegisterServices();

            var serviceProvider = services.BuildServiceProvider();

            var rt = new Runtime(serviceProvider.GetService<IOrderService>());

            await rt.Run();
        }
    }
}
