using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CoinXplorer_API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var method = context.Request.Method;
            var path = context.Request.Path;
            var ip = context.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            var userAgent = context.Request.Headers["User-Agent"].ToString();
            var device = userAgent.Contains("Flutter") ? "Mobile" : "Web";

            _logger.LogInformation($"[REQUEST] {method} {path} from {ip} on {device}");
            Console.WriteLine($"[REQUEST] {method} {path} from {ip} on {device}");

            // Proceed to the next middleware
            await _next(context);
        }
    }
}
