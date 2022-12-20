using Demo.Application.Models;
using Demo.Application.Repositories;
using Demo.Application.Services;

namespace Demo.Application.Implementation.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<Product> FindByIdAsync(Guid id)
    {
        return _productRepository.GetByIdAsync(id);
    }

    public Task<Product[]> GetListAsync()
    {
        return _productRepository.GetListAsync();
    }

    public async Task<Guid> RegisterAsync(string productName, decimal productPrice)
    {
        var id = await _productRepository.InsertAsync(new Product(productName, productPrice));
        await _unitOfWork.SaveChangesAsync();

        return id;
    }

    public async Task UnregisterAsync(Guid id)
    {
        await _productRepository.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
    }
}
