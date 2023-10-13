using System.Net;

namespace UsersNotebook.Api.Security
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            var apiKeyHeader = context.Request.Headers["X-API-Key"];
            var expectedApiKey = _configuration["AppSettings:ApiKey"];

            if (apiKeyHeader == expectedApiKey)
            {
                // API key is valid
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
        }
    }
}
