using Application.DTOs;
using FluentValidation;

namespace SOLID.Application.UseCases
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price cannot be negative.");
        }
    }
}
