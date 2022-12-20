namespace Demo.DataLayer.Models;

/// <summary>
/// Наличие товаров
/// </summary>
public class ProvidedProductEntity : BaseEntity
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Количество
    /// </summary>
    public int ProductQuantity { get; set; }

    /// <summary>
    /// Идентификатор точки продажи
    /// </summary>
    public Guid SalePointEntityId { get; set; }
}
