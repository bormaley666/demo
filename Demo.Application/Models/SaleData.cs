namespace Demo.Application.Models;

/// <summary>
/// Купленный товар
/// </summary>
public class SaleData
{
    public SaleData(Guid productId, int productQuantity, decimal productPrice)
    {
        ProductId = productId;
        ProductQuantity = productQuantity;
        ProductPrice = productPrice;
    }

    /// <summary>
    /// Идентификатор купленного товара
    /// </summary>
    public Guid ProductId { get; }

    /// <summary>
    /// Количество купленных товаров
    /// </summary>
    public int ProductQuantity { get; }

    /// <summary>
    /// Стоимость товара
    /// </summary>
    public decimal ProductPrice { get; }

    /// <summary>
    /// Общая стоимость купленных товаров
    /// </summary>
    public decimal ProductAmount => ProductQuantity * ProductPrice;
}
