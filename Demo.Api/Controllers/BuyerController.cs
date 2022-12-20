using Demo.Api.Models;
using Demo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

[Route("api/buyers")]
public class BuyerController : ControllerBase
{
    private readonly IBuyerService _buyerService;

    public BuyerController(IBuyerService buyerService)
    {
        _buyerService = buyerService;
    }

    /// <summary>
    /// Получить покупателя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор покупателя</param>
    /// <returns>Покупатель</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuyerDto))]
    public async Task<BuyerDto> GetByIdAsync(Guid id)
    {
        var buyer = await _buyerService.FindByIdAsync(id);

        return new BuyerDto(buyer);
    }

    /// <summary>
    /// Получить список покупателей
    /// </summary>
    /// <returns>Список покупателей</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BuyerDto))]
    public async Task<BuyerDto[]> GetListAsync()
    {
        var buyers = await _buyerService.GetListAsync();

        return buyers
            .Select(buyer => new BuyerDto(buyer))
            .ToArray();
    }

    /// <summary>
    /// Создать нового покупателя
    /// </summary>
    /// <param name="buyerName">Имя покупателя</param>
    /// <returns>Идентификатор покупателя</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    public async Task<Guid> RegisterAsync(string buyerName)
    {
        return await _buyerService.RegisterAsync(buyerName);
    }

    /// <summary>
    /// Удалить покупателя
    /// </summary>
    /// <param name="id">Идентификатор покупателя</param>
    [HttpDelete("{id:guid}")]
    public Task UnregisterAsync(Guid id)
    {
        return _buyerService.UnregisterAsync(id);
    }
}
