namespace Demo.Application.Models;

/// <summary>
/// Покупатель
/// </summary>
public class Buyer
{
    public Buyer(string name)
    {
        Name = name;
    }

    public Buyer(Guid id, string name) 
    {
        Id = id;
        Name = name;
    }

    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Список покупок
    /// </summary>
    public List<Guid> SaleIds { get; } = new();
}
