using Demo.Application.Models;

namespace Demo.Api.Models;

/// <summary>
/// Точка продажи товаров
/// </summary>
public class SalePointDto
{
    public SalePointDto(SalePoint salePoint)
    {
        Id = salePoint.Id;
        Name = salePoint.Name;
        ProvidedProducts = new List<ProvidedProductDto>();

        foreach (var providedProduct in salePoint.ProvidedProducts)
        {
            ProvidedProducts.Add(new ProvidedProductDto(providedProduct.ProductId, providedProduct.ProductQuantity));
        }
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get;}

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Список товаров доступных к продаже
    /// </summary>
    public List<ProvidedProductDto> ProvidedProducts { get; }
}
