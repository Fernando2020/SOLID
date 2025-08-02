using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.DataAccess;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public void Add(Product product) => _products.Add(product);

    public IEnumerable<Product> GetAll() => _products;
}
