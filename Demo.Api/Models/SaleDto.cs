using Demo.Application.Models;

namespace Demo.Api.Models;

/// <summary>
/// Акт продажи
/// </summary>
public class SaleDto
{
    public SaleDto(Sale sale)
    {
        Id = sale.Id;
        SalePointId = sale.SalesPointId;
        BuyerId = sale.BuyerId;
        DateTime = sale.DateTime;
        TotalAmount = sale.TotalAmount;
        SaleData = new List<SaleDataDto>();

        foreach (var saleData in sale.SaleData)
        {
            SaleData.Add(new SaleDataDto(saleData));
        }
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Идентификатор точки продажи
    /// </summary>
    public Guid SalePointId { get; }

    /// <summary>
    /// Идентификатор покупателя
    /// </summary>
    public Guid? BuyerId { get; }

    /// <summary>
    /// Дата и время осуществления покупки
    /// </summary>
    public DateTime DateTime { get; }

    /// <summary>
    /// Список купленных товаров
    /// </summary>
    public List<SaleDataDto> SaleData { get; }

    /// <summary>
    /// Общая сумма покупки
    /// </summary>
    public decimal TotalAmount { get; }
}
