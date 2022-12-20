namespace Demo.Api.Models;

/// <summary>
/// Наличие товаров
/// </summary>
public class ProvidedProductDto
{
    public ProvidedProductDto(Guid productId, int productQuantity) 
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
    public int ProductQuantity { get; }
}