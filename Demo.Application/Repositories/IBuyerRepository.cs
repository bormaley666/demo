using Demo.Application.Models;

namespace Demo.Application.Repositories;

/// <summary>
/// Хранилище <see cref="Buyer"/>
/// </summary>
public interface IBuyerRepository
{
    /// <summary>
    /// Вернуть покупателя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор покупателя</param>
    /// <returns>Покупатель</returns>
    Task<Buyer> GetByIdAsync(Guid id);

    /// <summary>
    /// Вернуть список покупателей
    /// </summary>
    /// <returns>Список покупателей</returns>
    Task<Buyer[]> GetListAsync();

    /// <summary>
    /// Добавить нового покупателя
    /// </summary>
    /// <param name="buyer">Покупатель</param>
    /// <returns>Идентификатор покупателя</returns>
    Task<Guid> InsertAsync(Buyer buyer);

    /// <summary>
    /// Удалить покупателя
    /// </summary>
    /// <param name="id">Идентификатор покупателя</param>
    Task DeleteAsync(Guid id);
}
