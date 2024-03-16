using System.Text.Json;
using System.Text.Json.Serialization;
using Tcc.Identity.Api.Models;
using Tcc.Identity.Application.Exceptions;
using Tcc.Identity.Core.Exceptions;

namespace Tcc.Identity.Api.Middleware;

/// <summary>
/// ExceptionHandlingMiddleware
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    private readonly RequestDelegate _next;

    /// <summary>
    /// ExceptionHandlingMiddleware
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invoke
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private Task HandleException(HttpContext context, Exception ex)
    {
        _logger.LogError(ex.Message);

        var code = StatusCodes.Status500InternalServerError;
        var errors = new List<string> { ex.Message };

        code = ex switch
        {
            NotFoundException => StatusCodes.Status404NotFound,
            ResourceNotFoundException => StatusCodes.Status404NotFound,
            BadRequestException => StatusCodes.Status400BadRequest,
            UnprocessableRequestException => StatusCodes.Status422UnprocessableEntity,
            _ => code
        };

        var result = JsonSerializer.Serialize(ApiResult<string>.Failure(errors));

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;

        return context.Response.WriteAsync(result);
    }
}
