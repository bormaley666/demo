namespace Demo.DataLayer.Models;

/// <summary>
/// Точка продажи товаров
/// </summary>
public class SalePointEntity : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Список товаров доступных к продаже
    /// </summary>
    public ICollection<ProvidedProductEntity> ProvidedProducts { get; set; } = null!;
}
