using Demo.Application.Models;

namespace Demo.Application.Repositories;

/// <summary>
/// Хранилище <see cref="Sale"/>
/// </summary>
public interface ISaleRepository
{
    /// <summary>
    /// Вернуть акт продажи по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор акта продажи</param>
    /// <returns>Акт продажи</returns>
    Task<Sale> GetByIdAsync(Guid id);

    /// <summary>
    /// Вернуть список актов продаж
    /// </summary>
    /// <returns>Список актов продаж</returns>
    Task<Sale[]> GetListAsync();

    /// <summary>
    /// Добавить новый акт продажи
    /// </summary>
    /// <param name="sale">Акт продажи</param>
    /// <returns>Идентификатор акта продажи</returns>
    Task<Guid> InsertAsync(Sale sale);

    /// <summary>
    /// Удалить акт продажи
    /// </summary>
    /// <param name="id">Идентификатор акта продажи</param>
    Task DeleteAsync(Guid id);
}
