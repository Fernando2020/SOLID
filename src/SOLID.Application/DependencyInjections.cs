using Application.DTOs;
using Application.UseCases;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SOLID.Application.UseCases;

namespace SOLID.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddMyApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddValidators(services);

            return services;
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddTransient<ICreateProductUseCase, CreateProductUseCase>();
        }

        private static void AddValidators(IServiceCollection services)
        {
            services.AddSingleton<IValidator<CreateProductDto>, CreateProductDtoValidator>();
        }
    }
}
