using Demo.Api.Models;
using Demo.Application.Models;
using Demo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

[Route("api/sales")]
public class SaleController : ControllerBase
{
    private readonly ISaleService _saleService;

    public SaleController(ISaleService saleService)
    {
        _saleService = saleService;
    }

    /// <summary>
    /// Получить акт продажи по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор акта продажи</param>
    /// <returns>Акт продажи</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaleDto))]
    public async Task<SaleDto> GetByIdAsync(Guid id)
    {
        var sale = await _saleService.FindByIdAsync(id);

        return new SaleDto(sale);
    }

    /// <summary>
    /// Получить список актов продажи
    /// </summary>
    /// <returns>Список актов продажи</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SaleDto))]
    public async Task<SaleDto[]> GetListAsync()
    {
        var sales = await _saleService.GetListAsync();

        return sales
            .Select(sale => new SaleDto(sale))
            .ToArray();
    }

    /// <summary>
    /// Совершить продажу
    /// </summary>
    /// <param name="request">Параметры запроса</param>
    /// <returns>Идентификатор акта продажи</returns>
    [HttpPost("order")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    public async Task<Guid> OrderAsync([FromBody] OrderRequest request)
    {
        var orderItems = request.Items
            .Select(x => new OrderItem() { ProductId = x.ProductId, WantedProductQuantity = x.Quantity })
            .ToArray();

        var sale = await _saleService.OrderAsync(orderItems, request.SalePointId, request.BuyerId);

        return sale.Id;
    }

    /// <summary>
    /// Удалить акт продажи
    /// </summary>
    /// <param name="id">Идентификатор акта продажи</param>
    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        await _saleService.DeleteAsync(id);
    }
}
