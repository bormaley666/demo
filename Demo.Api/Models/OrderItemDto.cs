namespace Demo.Api.Models;

/// <summary>
/// Товар на продажу
/// </summary>
public class OrderItemDto
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Запрашиваемое кол-во товаров
    /// </summary>
    public int Quantity { get; set; }
}
