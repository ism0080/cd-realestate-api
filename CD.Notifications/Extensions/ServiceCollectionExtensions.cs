using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CD.Notifications.Configurations;

namespace CD.Notifications.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SNSClientSettings>(configuration.GetSection(nameof(SNSClientSettings)));
            services.Configure<SecurityConfig>(configuration.GetSection(nameof(SecurityConfig)));
        }
    }
}