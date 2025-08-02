using Application.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
using SOLID.Application.UseCases;

namespace Application.UseCases;

public class CreateProductUseCase : ICreateProductUseCase
{
    private readonly IProductRepository _repository;
    private readonly ILoggerService _logger;
    private readonly IValidator<CreateProductDto> _validator;

    public CreateProductUseCase(
        IProductRepository repository,
        ILoggerService logger,
         IValidator<CreateProductDto> validator)
    {
        _repository = repository;
        _logger = logger;
        _validator = validator;
    }

    public void Execute(CreateProductDto dto)
    {
        var validate = _validator.Validate(dto);
        if (!validate.IsValid)
        {
            var errors = validate.Errors;
            _logger.Error(string.Join(";", errors.Select(x => x.ErrorMessage)));
            return;
        }

        var product = new Product(dto.Name, dto.Price);

        _repository.Add(product);
        _logger.Info($"Product '{product.Name}' added successfully.");
    }
}
