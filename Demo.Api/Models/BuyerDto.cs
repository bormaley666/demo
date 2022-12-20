using Demo.Application.Models;

namespace Demo.Api.Models;

/// <summary>
/// Покупатель
/// </summary>
public class BuyerDto
{
    public BuyerDto(Buyer buyer)
    {
        Id = buyer.Id;
        Name = buyer.Name;
        SalesIds = new List<Guid>();

        foreach (var saleId in buyer.SaleIds)
        {
            SalesIds.Add(saleId);
        }
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
    /// Идентификатор покупок
    /// </summary>
    public List<Guid> SalesIds { get; }
}
