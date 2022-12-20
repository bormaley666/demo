using Demo.Application.Models;
using Demo.Application.Repositories;
using Demo.Common.Exceptions;
using Demo.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.DataLayer.Repositories;

/// <inheritdoc/>
public class ProductRepository : IProductRepository
{
    private readonly DataDbContext _db;

    public ProductRepository(DataDbContext db)
    {
        _db = db;
    }

    /// <inheritdoc/>
    public async Task<Product> GetByIdAsync(Guid id)
    {
        var entity = await _db.Set<ProductEntity>()
            .Where(x => !x.IsDeleted && x.Id == id)
            .SingleOrDefaultAsync();

        return entity != null ? new Product(entity.Id, entity.Name, entity.Price)
            : throw new EntityNotFoundException($"Не найден товар '{id}'");
    }

    /// <inheritdoc/>
    public async Task<Product[]> GetListAsync()
    {
        var entities = await _db.Set<ProductEntity>()
            .Where(x => !x.IsDeleted)
            .ToArrayAsync();

        return entities
            .Select(entity => new Product(entity.Id, entity.Name, entity.Price))
            .ToArray();
    }

    /// <inheritdoc/>
    public async Task<Guid> InsertAsync(Product product)
    {
        var entity = new ProductEntity()
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };

        await _db.AddAsync(entity);

        return entity.Id;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id)
    {
        var entity = await _db.Set<ProductEntity>()
            .Where(x => x.Id == id && !x.IsDeleted)
            .SingleOrDefaultAsync();

        if (entity != null)
        {
            entity.IsDeleted = true;
        }
    }
}
