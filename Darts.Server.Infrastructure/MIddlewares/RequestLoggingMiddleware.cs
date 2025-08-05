using Microsoft.AspNetCore.Http;
using NLog;
using NLog.Web;

namespace Darts.Server.Infrastructure.MIddlewares;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Logger _logger;

    // Correct constructor - only takes RequestDelegate
    public RequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;

        LogManager.Setup().LoadConfigurationFromAppSettings();
        _logger = LogManager.GetLogger("RequestLogger");
    }

    public async Task Invoke(HttpContext context) // Note: Correct method name is "Invoke" (not "Invoke")
    {
        await _next(context);;
        _logger.Info($"Request {context.Request.Method} {context.Request.Path} => {context.Response.StatusCode} ");
    }
}