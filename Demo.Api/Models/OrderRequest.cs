namespace Demo.Api.Models;

/// <summary>
/// Запрос на продажу
/// </summary>
public class OrderRequest
{
    /// <summary>
    /// Идентификатор точки продажи
    /// </summary>
    public Guid SalePointId { get; set; }

    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    public Guid? BuyerId { get; set; }

    /// <summary>
    /// Список товаров на продажу
    /// </summary>
    public OrderItemDto[] Items { get; set; } = null!;
}
