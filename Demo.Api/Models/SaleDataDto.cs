using Demo.Application.Models;

namespace Demo.Api.Models;

/// <summary>
/// Купленный товар
/// </summary>
public class SaleDataDto
{
    public SaleDataDto(SaleData saleData) 
    { 
        ProductId = saleData.ProductId;
        ProductQuantity = saleData.ProductQuantity;
        ProductAmount = saleData.ProductAmount;
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
    /// Общая стоимость купленных товаров
    /// </summary>
    public decimal ProductAmount { get; }
}
