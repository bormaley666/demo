using Demo.Application.Models;

namespace Demo.Application.Services;

public interface IBuyerService
{
    Task<Guid> RegisterAsync(string buyerName);

    Task UnregisterAsync(Guid id);

    Task<Buyer> FindByIdAsync(Guid id);

    Task<Buyer[]> GetListAsync();
}
