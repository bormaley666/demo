using Demo.Application.Models;
using Demo.Application.Repositories;
using Demo.Common.Exceptions;
using Demo.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataLayer.Repositories;

/// <inheritdoc/>
public class SalePointRepository : ISalePointRepository
{
    protected readonly DataDbContext _db;

    public SalePointRepository(DataDbContext db)
    {
        _db = db;
    }

    /// <inheritdoc/>
    public async Task<SalePoint> GetByIdAsync(Guid id)
    {
        var entity = await _db.Set<SalePointEntity>()
            .Include(x => x.ProvidedProducts)
            .Where(x => !x.IsDeleted && x.Id == id)
            .SingleOrDefaultAsync();

        return entity != null ? ToModel(entity) 
            : throw new EntityNotFoundException($"Не найдена точка продажи '{id}'");
    }

    /// <inheritdoc/>
    public async Task<SalePoint[]> GetListAsync()
    {
        var entities = await _db.Set<SalePointEntity>()
            .Include(x => x.ProvidedProducts)
            .Where(x => !x.IsDeleted)
            .ToArrayAsync();

        return entities
            .Select(x => ToModel(x))
            .ToArray();
    }

    /// <inheritdoc/>
    public async Task<Guid> InsertAsync(SalePoint salePoint)
    {
        var salePointEntity = new SalePointEntity()
        {
            Id = salePoint.Id,
            Name = salePoint.Name,
            ProvidedProducts = new List<ProvidedProductEntity>()
        };

        foreach (var providedProduct in salePoint.ProvidedProducts)
        {
            var providedProductEntity = new ProvidedProductEntity()
            {
                ProductId = providedProduct.ProductId,
                ProductQuantity = providedProduct.ProductQuantity
            };

            salePointEntity.ProvidedProducts.Add(providedProductEntity);
        }

        await _db.AddAsync(salePointEntity);

        return salePointEntity.Id;
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(SalePoint salePoint)
    {
        var salePointEntity = await _db.Set<SalePointEntity>()
            .Include(x => x.ProvidedProducts)
            .Where(x => x.Id == salePoint.Id && !x.IsDeleted)
            .SingleOrDefaultAsync() ?? throw new EntityNotFoundException($"Не найдена точка продажи '{salePoint.Id}'");

        salePointEntity.Name = salePoint.Name;

        foreach (var providedProduct in salePoint.ProvidedProducts)
        {
            AddOrUpdateProductQuantity(salePointEntity, providedProduct.ProductId, providedProduct.ProductQuantity);
        }
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _db.Set<SalePointEntity>()
            .Where(x => x.Id == id && !x.IsDeleted)
            .SingleOrDefaultAsync();

        if (entity != null)
        {
            entity.IsDeleted = true;
        }
    }

    private SalePoint ToModel(SalePointEntity salePointEntity)
    {
        var salePoint = new SalePoint(salePointEntity.Id, salePointEntity.Name);

        foreach (var providedProductEntity in salePointEntity.ProvidedProducts)
        {
            salePoint.StockProductQuantity(providedProductEntity.ProductId, providedProductEntity.ProductQuantity);
        }

        return salePoint;
    }

    private void AddOrUpdateProductQuantity(SalePointEntity salePointEntity, Guid productId, int productQuantity)
    {
        var storedProvidedProductEntity = salePointEntity.ProvidedProducts
            .Where(x => x.ProductId == productId)
            .SingleOrDefault();

        if (storedProvidedProductEntity != null)
        {
            storedProvidedProductEntity.ProductQuantity = productQuantity;
        }
        else
        {
            var providedProductEntity = new ProvidedProductEntity()
            {
                ProductId = productId,
                ProductQuantity = productQuantity
            };

            salePointEntity.ProvidedProducts.Add(providedProductEntity);
        }
    }
}