using Demo.Application.Models;
using Demo.Application.Repositories;
using Demo.Common.Exceptions;
using Demo.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataLayer.Repositories;

/// <inheritdoc/>
public class BuyerRepository : IBuyerRepository
{
    private readonly DataDbContext _db;

    public BuyerRepository(DataDbContext db)
    {
        _db = db;
    }

    /// <inheritdoc/>
    public async Task<Buyer> GetByIdAsync(Guid id)
    {
        var entity = await _db.Set<BuyerEntity>()
            .Include(x => x.Sales)
            .Where(x => !x.IsDeleted && x.Id == id)
            .SingleOrDefaultAsync();

        return entity != null ? ToModel(entity) 
            : throw new EntityNotFoundException($"Не найден покупатель '{id}'");
    }

    /// <inheritdoc/>
    public async Task<Buyer[]> GetListAsync()
    {
        var entities = await _db.Set<BuyerEntity>()
            .Include(x => x.Sales)
            .Where(x => !x.IsDeleted)
            .ToArrayAsync();

        return entities
            .Select(entity => ToModel(entity))
            .ToArray();
    }

    /// <inheritdoc/>
    public async Task<Guid> InsertAsync(Buyer buyer)
    {
        var entity = new BuyerEntity()
        {
            Id = buyer.Id,
            Name = buyer.Name
        };

        await _db.AddAsync(entity);

        return entity.Id;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _db.Set<BuyerEntity>()
            .Where(x => x.Id == id && !x.IsDeleted)
            .SingleOrDefaultAsync();

        if (entity != null)
        {
            entity.IsDeleted = true;
        }
    }

    /// <inheritdoc/>
    private Buyer ToModel(BuyerEntity buyerEntity)
    {
        var buyer = new Buyer(buyerEntity.Id, buyerEntity.Name);

        foreach (var saleEntity in buyerEntity.Sales)
        {
            buyer.SaleIds.Add(saleEntity.Id);
        }

        return buyer;
    }
}
