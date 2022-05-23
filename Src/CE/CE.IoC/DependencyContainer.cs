using CE.Contracts;
using CE.Services.Mocks;
using Microsoft.Extensions.DependencyInjection;

namespace CE.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, MockOrderService>();
        }
    }
}
