using Demo.Application.Models;

namespace Demo.Application.Repositories;

/// <summary>
/// Хранилище <see cref="Product"/>
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Вернуть товар по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    /// <returns>Товар</returns>
    Task<Product> GetByIdAsync(Guid id);

    /// <summary>
    /// Вернуть список товаров
    /// </summary>
    /// <returns>Список товаров</returns>
    Task<Product[]> GetListAsync();

    /// <summary>
    /// Добавить новый товар
    /// </summary>
    /// <param name="product">Товар</param>
    /// <returns>Идентификатор товара</returns>
    Task<Guid> InsertAsync(Product product);

    /// <summary>
    /// Удалить товар
    /// </summary>
    /// <param name="id">Идентификатор товара</param>
    Task DeleteAsync(Guid id);
}