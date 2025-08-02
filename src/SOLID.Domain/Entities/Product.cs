namespace Domain.Entities;

public class Product
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Name { get; }
    public decimal Price { get; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
