namespace Demo.DataLayer.Models;

/// <summary>
/// Купленный товар
/// </summary>
public class SaleDataEntity : BaseEntity
{
    /// <summary>
    /// Идентификатор купленного товар
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Идентификатор точки продажи
    /// </summary>
    public Guid SaleEntityId { get; set; }

    /// <summary>
    /// Количество купленных товаров
    /// </summary>
    public int ProductQuantity { get; set; }

    /// <summary>
    /// Стоимость купленного товара
    /// </summary>
    public decimal ProductPrice { get; set; }

    #region Navigation
    /// <summary>
    /// Купленный товар
    /// </summary>
    public ProductEntity Product { get; set; } = null!; 
    #endregion
}