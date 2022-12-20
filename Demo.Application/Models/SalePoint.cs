using Demo.Common.Exceptions;

namespace Demo.Application.Models;

/// <summary>
/// Точка продажи товаров
/// </summary>
public class SalePoint
{
    private readonly List<ProvidedProduct> _providedProducts = new();

    public SalePoint(string name)
    {
        Name = name;
    }

    public SalePoint(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Установить запас товара указанным кол-вом
    /// </summary>
    /// <param name="productId">Идентификатор товара</param>
    /// <param name="productQuantity">Кол-во доступных товаров</param>
    public void StockProductQuantity(Guid productId, int productQuantity)
    {
        var providedProduct = FindProvidedProduct(productId);

        if (providedProduct == null)
        {
            providedProduct = new ProvidedProduct(productId, productQuantity);
            _providedProducts.Add(providedProduct);
        }

        providedProduct.ProductQuantity = productQuantity;
    }

    /// <summary>
    /// Израсходовать запрашиваемое кол-во товаров
    /// </summary>
    /// <param name="productId">Идентификатор товара</param>
    /// <param name="wantedProductQuantity">Кол-во запрашиваемых товаров</param>
    public void ConsumeProductQuantity(Guid productId, int wantedProductQuantity)
    {
        var providedProduct = FindProvidedProduct(productId, true);

        var availableProductQuantity = providedProduct!.ProductQuantity;

        if (wantedProductQuantity > availableProductQuantity)
        {
            throw new SalePointException($"Недостаточно товара '{productId}'");
        }

        providedProduct.ProductQuantity = availableProductQuantity - wantedProductQuantity;
    }

    /// <summary>
    /// Вернуть доступное кол-во товаров
    /// </summary>
    /// <param name="productId">Идентификатор товара</param>
    /// <returns>Доступное кол-во товаров</returns>
    public int GetAvailableProductQuantity(Guid productId)
    {
        var providedProduct = FindProvidedProduct(productId, true);

        return providedProduct!.ProductQuantity;
    }

    /// <summary>
    /// Список товаров доступных к продаже
    /// </summary>
    public IEnumerable<ProvidedProduct> ProvidedProducts => _providedProducts;

    private ProvidedProduct? FindProvidedProduct(Guid productId, bool throwIfNotFound = false)
    {
        var providedProduct = ProvidedProducts
            .Where(x => x.ProductId == productId)
            .SingleOrDefault();

        if (throwIfNotFound && providedProduct == null)
        {
            throw new SalePointException($"Запрашиваемый товар '{productId}' отсутствует в точке продаж '{Id}'");
        }

        return providedProduct;
    }
}
