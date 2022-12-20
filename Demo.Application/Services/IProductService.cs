using Demo.Application.Models;

namespace Demo.Application.Services;

public interface IProductService
{
    Task<Guid> RegisterAsync(string productName, decimal productPrice);

    Task UnregisterAsync(Guid id);

    Task<Product> FindByIdAsync(Guid id);

    Task<Product[]> GetListAsync();
}
