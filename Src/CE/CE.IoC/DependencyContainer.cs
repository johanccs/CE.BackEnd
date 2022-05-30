using CE.Contracts;
using CE.Domain.Helpers;
using CE.Infrastructure.Logging;
using CE.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CE.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services, Settings settings)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProdService>(c=> new ProductService(settings.Url, settings.Api_Key));
            services.AddScoped<ILoggerService, LoggerService>();
        }

        public static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatREntryPoint).Assembly);
        }
    }
}

