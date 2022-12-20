namespace Demo.Application.Models;

public class OrderItem
{
    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Запрашиваемое кол-во товаров
    /// </summary>
    public int WantedProductQuantity { get; set; }
}
