using Demo.Application.Models;

namespace Demo.Api.Models;

/// <summary>
/// Товар
/// </summary>
public class ProductDto
{
    public ProductDto(Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Price = product.Price;
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
