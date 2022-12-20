namespace Demo.DataLayer.Models;

/// <summary>
/// Покупатель
/// </summary>
public class BuyerEntity : BaseEntity
{
    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Список покупок
    /// </summary>
    public ICollection<SaleEntity> Sales { get; set; } = null!;
}
