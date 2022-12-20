using Demo.Application.Models;
using Demo.Application.Repositories;
using Demo.Application.Services;

namespace Demo.Application.Implementation.Services;

public class SalePointService : ISalePointService
{
    private readonly ISalePointRepository _salePointRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SalePointService(ISalePointRepository salePointRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _salePointRepository = salePointRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> RegisterAsync(string salePointName)
    {
        var id = await _salePointRepository.InsertAsync(new SalePoint(salePointName));
        await _unitOfWork.SaveChangesAsync();

        return id;
    }

    public async Task UnregisterAsync(Guid id)
    {
        await _salePointRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }

    public Task<SalePoint> FindByIdAsync(Guid id)
    {
        return _salePointRepository.GetByIdAsync(id);
    }

    public Task<SalePoint[]> GetListAsync()
    {
        return _salePointRepository.GetListAsync();
    }

    public async Task StockProductAsync(Guid salePointId, Guid productId, int productQuantity)
    {
        _ = await _productRepository.GetByIdAsync(productId);

        var salePoint = await _salePointRepository.GetByIdAsync(salePointId);
        salePoint.StockProductQuantity(productId, productQuantity);
        await _salePointRepository.UpdateAsync(salePoint);

        await _unitOfWork.SaveChangesAsync();
    }
}
