namespace Demo.DataLayer.Models;

public abstract class BaseEntity
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Признак деактивации записи
    /// </summary>
    public bool IsDeleted { get; set; }
}
