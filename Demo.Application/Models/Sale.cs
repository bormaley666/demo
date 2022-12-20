namespace Demo.Application.Models;

/// <summary>
/// Акт продажи
/// </summary>
public class Sale
{
    private readonly List<SaleData> _saleData = new();

    public Sale(DateTime dateTime, Guid salesPointId, Guid? buyerId = null)
    {
        DateTime = dateTime;
        SalesPointId = salesPointId;
        BuyerId = buyerId;
    }

    public Sale(Guid id, DateTime dateTime, Guid salesPointId, Guid? buyerId = null) 
    {
        Id = id;
        DateTime = dateTime;
        SalesPointId = salesPointId;
        BuyerId = buyerId;
    }

    /// <summary>
    /// Добавить купленный товар
    /// </summary>
    /// <param name="productId">Идентификатор товара</param>
    /// <param name="productQuantity">Кол-во купленного товара</param>
    /// <param name="productPrice">Стоимость товара</param>
    public void AddProduct(Guid productId, int productQuantity, decimal productPrice)
    {
        _saleData.Add(new SaleData(productId, productQuantity, productPrice));
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Дата и время осуществления покупки
    /// </summary>
    public DateTime DateTime { get; }

    /// <summary>
    /// Идентификатор точки продажи
    /// </summary>
    public Guid SalesPointId { get; }

    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    public Guid? BuyerId { get; }

    /// <summary>
    /// Список купленных товаров
    /// </summary>
    public IEnumerable<SaleData> SaleData => _saleData;

    /// <summary>
    /// Общая сумма покупки
    /// </summary>
    public decimal TotalAmount => _saleData.Sum(x => x.ProductAmount);
}
