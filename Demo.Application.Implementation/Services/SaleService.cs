using Demo.Application.Models;
using Demo.Application.Repositories;
using Demo.Application.Services;

namespace Demo.Application.Implementation.Services;

public class SaleService : ISaleService
{
    private readonly ISalePointRepository _salePointRepository;
    private readonly IBuyerRepository _buyerRepository;
    private readonly ISaleRepository _saleRepository;
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SaleService(ISalePointRepository salePointRepository, IBuyerRepository buyerRepository, 
        ISaleRepository saleRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _salePointRepository = salePointRepository;
        _buyerRepository = buyerRepository;
        _saleRepository = saleRepository;
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<Sale> FindByIdAsync(Guid id)
    {
        return _saleRepository.GetByIdAsync(id);
    }

    public Task<Sale[]> GetListAsync()
    {
        return _saleRepository.GetListAsync();
    }

    public async Task<Sale> OrderAsync(OrderItem[] orderItems, Guid salePointId, Guid? buyerId)
    {
        var salePoint = await _salePointRepository.GetByIdAsync(salePointId);

        if (buyerId != null)
        {
            _ = await _buyerRepository.GetByIdAsync(buyerId.Value);
        }

        var sale = new Sale(DateTime.UtcNow, salePointId, buyerId);

        foreach (var orderItem in orderItems)
        {
            salePoint.ConsumeProductQuantity(orderItem.ProductId, orderItem.WantedProductQuantity);

            var product = await _productRepository.GetByIdAsync(orderItem.ProductId);

            sale.AddProduct(orderItem.ProductId, orderItem.WantedProductQuantity, product.Price);
        }

        await _saleRepository.InsertAsync(sale);
        await _salePointRepository.UpdateAsync(salePoint);

        await _unitOfWork.SaveChangesAsync();

        return sale;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _saleRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
