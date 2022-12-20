using Demo.Application.Models;

namespace Demo.Application.Services;

public interface ISalePointService
{
    Task<Guid> RegisterAsync(string salePointName);

    Task UnregisterAsync(Guid id);

    Task<SalePoint> FindByIdAsync(Guid id);

    Task<SalePoint[]> GetListAsync();

    Task StockProductAsync(Guid salePointId, Guid productId, int productQuantity);
}
