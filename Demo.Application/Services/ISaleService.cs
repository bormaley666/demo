using Demo.Application.Models;

namespace Demo.Application.Services;

public interface ISaleService
{
    Task<Sale> FindByIdAsync(Guid id);

    Task<Sale[]> GetListAsync();

    Task<Sale> OrderAsync(OrderItem[] orderItems, Guid salePointId, Guid? buyerId);

    Task DeleteAsync(Guid id);
}
