namespace Demo.DataLayer.Models;

/// <summary>
/// Товар
/// </summary>
public class ProductEntity : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Стоимость
    /// </summary>
    public decimal Price { get; set; }
}
