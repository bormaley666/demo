namespace Demo.Api.Models;

/// <summary>
/// Модель ошибки
/// </summary>
public class ErrorDto
{
    public ErrorDto(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    public string Message { get; }
}
