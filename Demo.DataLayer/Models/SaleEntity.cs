namespace Demo.DataLayer.Models;

/// <summary>
/// Акт продажи
/// </summary>
public class SaleEntity : BaseEntity
{
    /// <summary>
    /// Дата и время осуществления покупки
    /// </summary>
    public DateTime DateTime { get; set; }

    /// <summary>
    /// Идентификатор точки продажи
    /// </summary>
    public Guid SalesPointId { get; set; }

    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    public Guid? BuyerId { get; set; }

    /// <summary>
    /// Список кпуленных товаров
    /// </summary>
    public ICollection<SaleDataEntity> SaleData { get; set; } = null!;

    #region Navigation
    /// <summary>
    /// Точка продажи
    /// </summary>
    public SalePointEntity SalesPoint { get; set; } = null!;

    /// <summary>
    /// Покупатель
    /// </summary>
    public BuyerEntity? Buyer { get; set; } 
    #endregion
}