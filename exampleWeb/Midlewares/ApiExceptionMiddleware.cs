using System.Diagnostics.CodeAnalysis;
using System.Net.Mime;
using System.Security.Authentication;
using System.Text.Json.Serialization;
using System.Text.Json;
using ExampleWeb.Application.Exceptions;

namespace ExampleWeb.Midlewares
{
    internal class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionMiddleware> _logger;

        public ApiExceptionMiddleware(RequestDelegate next, ILogger<ApiExceptionMiddleware> logger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                HandleApiExceptionAsync(context, ex);
            }
        }

        private void HandleApiExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = exception switch
            {
                TimeoutException _ => StatusCodes.Status504GatewayTimeout,
                InvalidOperationException _ => StatusCodes.Status400BadRequest,
                AuthenticationException _ => StatusCodes.Status401Unauthorized,
                NotFoundExceptions _ => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.ContentType = MediaTypeNames.Application.Json;
        }
    }
}
