namespace Demo.Application.Models;

/// <summary>
/// Наличие товаров
/// </summary>
public class ProvidedProduct
{
    public ProvidedProduct(Guid productId, int productQuantity)
    {
        ProductId = productId;
        ProductQuantity = productQuantity;
    }

    /// <summary>
    /// Идентификатор товара
    /// </summary>
    public Guid ProductId { get; }

    /// <summary>
    /// Количество
    /// </summary>
    public int ProductQuantity { get; set; }
}
