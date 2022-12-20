using Demo.Api.Models;
using Demo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

[Route("api/sale-points")]
public class SalePointController : ControllerBase
{
    private readonly ISalePointService _salePointService;

    public SalePointController(ISalePointService salePointService)
    {
        _salePointService = salePointService;
    }

    /// <summary>
    /// Получить точку продажи по идентификатору
    /// </summary>
    /// <param name="salePointId">Идентификатор точки продажи</param>
    /// <returns>Точка продажи</returns>
    [HttpGet("{salePointId:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SalePointDto))]
    public async Task<SalePointDto> GetByIdAsync(Guid salePointId)
    {
        var salePoint = await _salePointService.FindByIdAsync(salePointId);

        return new SalePointDto(salePoint);
    }

    /// <summary>
    /// Получить список точек продажи
    /// </summary>
    /// <returns>Список точек продажи</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SalePointDto))]
    public async Task<SalePointDto[]> GetListAsync()
    {
        var salePoints = await _salePointService.GetListAsync();

        return salePoints
            .Select(salePoint => new SalePointDto(salePoint))
            .ToArray();
    }

    /// <summary>
    /// Создать новую точку продажи
    /// </summary>
    /// <param name="salePointName">Наименование точки продажи</param>
    /// <returns>Идентификатор точки продажи</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    public async Task<Guid> RegisterAsync([FromQuery] string salePointName)
    {
        return await _salePointService.RegisterAsync(salePointName);
    }

    /// <summary>
    /// Удалить точку продажи
    /// </summary>
    /// <param name="salePointId">Идентификатор точки продажи</param>
    [HttpDelete("{salePointId:guid}")]
    public async Task UnregisterAsync(Guid salePointId)
    {
        await _salePointService.UnregisterAsync(salePointId);
    }

    /// <summary>
    /// Установить запас товаров
    /// </summary>
    /// <param name="salePointId">Идентификатор точки продажи</param>
    /// <param name="productId">Идентификатор товара</param>
    /// <param name="productQuantity">Количество товаров</param>
    /// <returns></returns>
    [HttpPost("{salePointId:guid}/stock-product")]
    public async Task StockProductAsync(Guid salePointId, [FromQuery] Guid productId, [FromQuery] int productQuantity)
    {
        await _salePointService.StockProductAsync(salePointId, productId, productQuantity);
    }
}
