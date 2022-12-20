using Demo.Application.Models;

namespace Demo.Application.Repositories;

/// <summary>
/// Хранилище <see cref="SalePoint"/>
/// </summary>
public interface ISalePointRepository
{
    /// <summary>
    /// Вернуть точку продажи по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор точки продажи</param>
    /// <returns>Точка продажи</returns>
    Task<SalePoint> GetByIdAsync(Guid id);

    /// <summary>
    /// Вернуть список точек продаж
    /// </summary>
    /// <returns>Список точек продаж</returns>
    Task<SalePoint[]> GetListAsync();

    /// <summary>
    /// Добавить новую точку продажи
    /// </summary>
    /// <param name="salePoint">Точка продажи</param>
    /// <returns>Идентификатор точки продажи</returns>
    Task<Guid> InsertAsync(SalePoint salePoint);

    Task UpdateAsync(SalePoint salePoint);

    /// <summary>
    /// Удалить точку продажи
    /// </summary>
    /// <param name="id">Идентификатор точки продажи</param>
    Task DeleteAsync(Guid id);
}
