using Demo.Application.Models;
using Demo.Application.Repositories;
using Demo.Common.Exceptions;
using Demo.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataLayer.Repositories;

/// <inheritdoc/>
public class SaleRepository : ISaleRepository
{
    protected readonly DataDbContext _db;

    public SaleRepository(DataDbContext db)
    {
        _db = db;
    }

    /// <inheritdoc/>
    public async Task<Sale> GetByIdAsync(Guid id)
    {
        var entity = await GetQuery()
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();

        return entity != null ? ToModel(entity) 
            : throw new EntityNotFoundException($"Не найден акт продажи '{id}'");
    }

    /// <inheritdoc/>
    public async Task<Sale[]> GetListAsync()
    {
        var entities = await GetQuery()
            .ToArrayAsync();

        return entities
            .Select(x => ToModel(x))
            .ToArray();
    }

    /// <inheritdoc/>
    public async Task<Guid> InsertAsync(Sale sale)
    {
        var saleEntity = new SaleEntity()
        {
            Id = sale.Id,
            DateTime = sale.DateTime,
            SalesPointId = sale.SalesPointId,
            BuyerId = sale.BuyerId,
            SaleData = new List<SaleDataEntity>()
        };

        foreach (var saleData in sale.SaleData)
        {
            var saleDataEntity = new SaleDataEntity()
            {
                ProductId = saleData.ProductId,
                ProductQuantity = saleData.ProductQuantity,
                ProductPrice = saleData.ProductPrice
            };

            saleEntity.SaleData.Add(saleDataEntity);
        }

        await _db.AddAsync(saleEntity);

        return saleEntity.Id;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _db.Set<SaleEntity>()
            .Where(x => x.Id == id && !x.IsDeleted)
            .SingleOrDefaultAsync();

        if (entity != null)
        {
            entity.IsDeleted = true;
        }
    }

    private Sale ToModel(SaleEntity saleEntity)
    {
        var sale = new Sale(saleEntity.Id, saleEntity.DateTime, saleEntity.SalesPoint.Id, saleEntity.Buyer?.Id);

        foreach (var saleDataEntity in saleEntity.SaleData)
        {
            sale.AddProduct(saleDataEntity.Product.Id, saleDataEntity.ProductQuantity, saleDataEntity.ProductPrice);
        }

        return sale;
    }

    private IQueryable<SaleEntity> GetQuery() =>
        _db.Set<SaleEntity>()
        .Include(x => x.SalesPoint)
        .Include(x => x.Buyer)
        .Include(x => x.SaleData)
        .ThenInclude(x => x.Product)
        .Where(x => !x.IsDeleted);
}
