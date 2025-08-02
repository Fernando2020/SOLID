using Domain.Interfaces;
using Infrastructure.DataAccess;
using Infrastructure.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace SOLID.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddMyInfrastructure(this IServiceCollection services)
        {
            AddRepositories(services);
            AddLogger(services);

            return services;
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddSingleton<IProductRepository, InMemoryProductRepository>();
        }

        private static void AddLogger(IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, SerilogLogger>();
        }
    }
}
