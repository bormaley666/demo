namespace Demo.Application.Models;

/// <summary>
/// Модель товара
/// </summary>
public class Product
{
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public Product(Guid id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Стоимость
    /// </summary>
    public decimal Price { get; }
}