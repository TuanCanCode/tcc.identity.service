using System.Diagnostics;

namespace Tcc.Identity.Api.Middleware;

/// <summary>
/// PerformanceMiddleware
/// </summary>
public class PerformanceMiddleware
{
    private readonly ILogger<PerformanceMiddleware> _logger;
    private readonly RequestDelegate _next;
    private const int performanceTimeLog = 300; // miliseconds

    /// <summary>
    /// PerformanceMiddleware
    /// </summary>
    /// <param name="next"></param>
    /// <param name="logger"></param>
    public PerformanceMiddleware(RequestDelegate next, ILogger<PerformanceMiddleware> logger)
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
       
        var sw = new Stopwatch();

        sw.Start();

        await _next(context);

        sw.Stop();

        if (performanceTimeLog < sw.ElapsedMilliseconds)
            _logger.LogWarning("Request {method} {path} it took about {elapsed} ms",
                context.Request?.Method,
                context.Request?.Path.Value,
                sw.ElapsedMilliseconds);
    }
}
