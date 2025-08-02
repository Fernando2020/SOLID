using Application.DTOs;

namespace SOLID.Application.UseCases
{
    public interface ICreateProductUseCase
    {
        void Execute(CreateProductDto dto);
    }
}
