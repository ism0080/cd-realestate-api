using Microsoft.AspNetCore.Builder;
using CD.Notifications.Middleware;

namespace CD.Notifications.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApiKeyMiddleWare(this IApplicationBuilder builder, bool isDevelopmentEnvironment)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>(isDevelopmentEnvironment);
        }
    }
}