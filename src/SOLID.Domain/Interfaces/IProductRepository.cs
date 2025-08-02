using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    void Add(Product product);
    IEnumerable<Product> GetAll();
}
