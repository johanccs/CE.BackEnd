using CE.Contracts;
using CE.Services;
using CE.Services.Mocks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CE.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, MockOrderService>();
        }

        public static void RegisterMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(MediatREntryPoint).Assembly);
        }
    }
}

