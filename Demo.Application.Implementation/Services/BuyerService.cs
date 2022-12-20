using Demo.Application.Models;
using Demo.Application.Repositories;
using Demo.Application.Services;

namespace Demo.Application.Implementation.Services;

public class BuyerService : IBuyerService
{
    private readonly IBuyerRepository _buyerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public BuyerService(IBuyerRepository buyerRepository, IUnitOfWork unitOfWork)
    {
        _buyerRepository = buyerRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<Buyer> FindByIdAsync(Guid id)
    {
        return _buyerRepository.GetByIdAsync(id);
    }

    public Task<Buyer[]> GetListAsync()
    {
        return _buyerRepository.GetListAsync();
    }

    public async Task<Guid> RegisterAsync(string buyerName)
    {
        var id = await _buyerRepository.InsertAsync(new Buyer(buyerName));
        await _unitOfWork.SaveChangesAsync();

        return id;
    }

    public async Task UnregisterAsync(Guid id)
    {
        await _buyerRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
