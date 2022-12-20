using Microsoft.EntityFrameworkCore;
using Demo.DataLayer.Models;

namespace Demo.DataLayer;

public class DataDbContext : DbContext
{
    /// <summary>
    /// Покупатели
    /// </summary>
    public DbSet<BuyerEntity> Buyers => Set<BuyerEntity>();

    /// <summary>
    /// Товары
    /// </summary>
    public DbSet<ProductEntity> Products => Set<ProductEntity>();

    /// <summary>
    /// Акты продаж
    /// </summary>
    public DbSet<SaleEntity> Sales => Set<SaleEntity>();

    /// <summary>
    /// Точки продаж
    /// </summary>
    public DbSet<SalePointEntity> SalePoints => Set<SalePointEntity>();

    public DataDbContext(DbContextOptions options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder builder)
    {
        var productEntities = new[]
        {
            new ProductEntity()
            {
                Id = new Guid("35355c1f-cb64-490c-80b0-4fc12ae14488"),
                Name = "Хлеб",
                Price = 4
            },
            new ProductEntity()
            {
                Id = new Guid("f5d57407-fd30-4345-aa28-ea39817df41a"),
                Name = "Масло",
                Price = 9
            }
        };

        var providedProductEntities = new List<ProvidedProductEntity>()
        {
            new ProvidedProductEntity()
            {
                Id = new Guid("35e83dbb-d15e-4ecf-9ce9-abd328c5d5fd"),
                SalePointEntityId = new Guid("c827b322-9370-436e-b474-aeadebf86cbf"),
                ProductId = new Guid("35355c1f-cb64-490c-80b0-4fc12ae14488"),
                ProductQuantity = 10
            },
            new ProvidedProductEntity()
            {
                Id = new Guid("327494f4-13d2-4f00-a485-f4cdc476c8f8"),
                SalePointEntityId = new Guid("c827b322-9370-436e-b474-aeadebf86cbf"),
                ProductId = new Guid("f5d57407-fd30-4345-aa28-ea39817df41a"),
                ProductQuantity = 20
            }
        };

        var salePointEntities = new[]
        { 
            new SalePointEntity()
            {
                Id = new Guid("c827b322-9370-436e-b474-aeadebf86cbf"),
                Name = "Точка-продажи-1"
            }
        };

        var buyer = new BuyerEntity()
        {
            Id = new Guid("3686bba6-9524-4ad1-941e-db9df7253276"),
            Name = "Покупатель-1"
        };

        var saleEntities = new List<SaleEntity>()
        {
            new SaleEntity()
            {
                Id = new Guid("fed64749-044e-45d3-bd94-1eb3674a95fc"),
                BuyerId = buyer.Id,
                DateTime = DateTime.UtcNow,
                SalesPointId = salePointEntities[0].Id
            }
        };

        var salesDataEntities = new List<SaleDataEntity>()
        {
            new SaleDataEntity ()
            {
                Id = new Guid("c056d04e-b710-414a-89d4-4e3fe8080cea"),
                ProductId = productEntities[0].Id,
                SaleEntityId = saleEntities[0].Id,
                ProductPrice = productEntities[0].Price,
                ProductQuantity = 1
            }
        };

        builder.Entity<BuyerEntity>().HasData(buyer);
        builder.Entity<ProductEntity>().HasData(productEntities);
        builder.Entity<ProvidedProductEntity>().HasData(providedProductEntities);
        builder.Entity<SalePointEntity>().HasData(salePointEntities);
        builder.Entity<SaleEntity>().HasData(saleEntities);
        builder.Entity<SaleDataEntity>().HasData(salesDataEntities);
    }
}
