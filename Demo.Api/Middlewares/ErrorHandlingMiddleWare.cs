using Demo.Api.Models;
using Demo.Common.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace Demo.Api.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            context.Response.ContentType = MediaTypeNames.Application.Json;
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = new ErrorDto(exception.Message);

            if (exception is EntityNotFoundException or SalePointException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            await context.Response.WriteAsync(JsonSerializer.Serialize(result,
                new JsonSerializerOptions(JsonSerializerDefaults.Web)));
        }
    }
}
