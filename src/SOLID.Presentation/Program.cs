using Application.DTOs;
using Microsoft.Extensions.DependencyInjection;
using SOLID.Application;
using SOLID.Application.UseCases;
using SOLID.Infrastructure;

var services = new ServiceCollection();

services.AddMyApplication();
services.AddMyInfrastructure();

var provider = services.BuildServiceProvider();
var useCase = provider.GetRequiredService<ICreateProductUseCase>();

var productDto = new CreateProductDto
{
    Name = "Notebook Dell",
    Price = 4599.99m
};

useCase.Execute(productDto);
