using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using CoinXplorer_API.Services;
using UAParser; // For TelegramService
namespace CoinXplorer_API.ErrorsFilter
{
    public class ExceptionErrorsFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionErrorsFilter> _logger;
        // private readonly TelegramService _telegramService;

        public ExceptionErrorsFilter(ILogger<ExceptionErrorsFilter> logger)
        {
            _logger = logger;
            // _telegramService = telegramService;
        }

        public void OnException(ExceptionContext context)
        {
            var httpContext = context.HttpContext;
            var request = httpContext.Request;
            var exception = context.Exception;

            var statusCode = exception is HttpException httpEx
                ? (int)httpEx.StatusCode
                : (int)HttpStatusCode.InternalServerError;

            var message = exception.Message ?? "Internal Server Error";

            // Get Client IP Address
            var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1";
            if (ip.StartsWith("::ffff:"))
                ip = ip.Replace("::ffff:", "");
            if (ip == "::1")
                ip = "127.0.0.1";

            // Parse User-Agent
            var userAgent = httpContext.Request.Headers["User-Agent"].ToString();
            var uaParser = Parser.GetDefault();
            var clientInfo = uaParser.Parse(userAgent);
            var platform = request.Headers.ContainsKey("x-flutter") && request.Headers["x-flutter"] == "true"
                ? "Mobile"
                : clientInfo.Device.Family ?? "Web";

            // Log and send to Telegram
            var route = request.Path;
            var method = request.Method;
            var timestamp = FormatDate(DateTime.Now);

            // _telegramService.SendErrorMessageLogs(
            //     route,
            //     method,
            //     statusCode.ToString(),
            //     message,
            //     ip,
            //     platform
            // ).Wait();

            var result = new JsonResult(new
            {
                status_code = statusCode,
                message = message,
                error = exception.GetType().Name,
                timestamp,
                path = request.Path,
                ip,
                device = platform
            });

            result.StatusCode = statusCode;
            context.Result = result;
            context.ExceptionHandled = true;
        }

        private static string FormatDate(DateTime date)
        {
            return $"{date:dd-MM-yyyy HH:mm:ss tt}";
        }
    }

    // Optional custom HttpException class if you want to throw specific codes
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        public HttpException(HttpStatusCode statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
