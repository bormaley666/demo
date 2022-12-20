using Demo.Api.Models;
using Demo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers;

[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Получить товар по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    /// <returns>Товар</returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
    public async Task<ProductDto> GetByIdAsync(Guid id)
    {
        var product = await _productService.FindByIdAsync(id);

        return new ProductDto(product);
    }

    /// <summary>
    /// Получить список товаров
    /// </summary>
    /// <returns>Список товаров</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
    public async Task<ProductDto[]> GetListAsync()
    {
        var products = await _productService.GetListAsync();

        return products
            .Select(product => new ProductDto(product))
            .ToArray();
    }

    /// <summary>
    /// Создать новый товар
    /// </summary>
    /// <param name="productName">Наименование товара</param>
    /// <param name="productPrice">Стоимость товара</param>
    /// <returns>Идентификатор товара</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    public async Task<Guid> RegisterAsync([FromQuery] string productName, [FromQuery] decimal productPrice)
    {
        return await _productService.RegisterAsync(productName, productPrice);
    }

    /// <summary>
    /// Удалить товар
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    [HttpDelete("{id:guid}")]
    public Task UnregisterAsync(Guid id)
    {
        return _productService.UnregisterAsync(id);
    }
}
