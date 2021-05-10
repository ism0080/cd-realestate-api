using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using CD.Notifications.Configurations;
using CD.Notifications.Extensions;

namespace CD.Notifications.Middleware
{
    public class ApiKeyMiddleware
    {
        public static string ApiKeyHeaderKey => "X-API-KEY";
        private readonly RequestDelegate _nextRequestDelegate;
        private readonly bool _isDevelopmentEnvironment;
        private readonly string _apiKey;
        private readonly string _safeToDisplayApiKey;

        public ApiKeyMiddleware(RequestDelegate nextRequestDelegate, IOptions<SecurityConfig> securityConfigOptions, bool isDevelopmentEnvironment)
        {
            _nextRequestDelegate = nextRequestDelegate;
            _isDevelopmentEnvironment = isDevelopmentEnvironment;
            _apiKey = securityConfigOptions.Value?.ApiKey?.Trim() ?? throw new ArgumentException("ApiKey must be provided, but couldn't get from settings");
            _safeToDisplayApiKey = GetSafeKeyValue(_apiKey);
        }

        public async Task Invoke(HttpContext context)
        {

            var validationMessage = $"'{ApiKeyHeaderKey}' header is not present in request";
            var validApiKey = false;
            if (IsDevelopmentMode(_isDevelopmentEnvironment))
            {
                validApiKey = true;
            }
            else if (context.Request.Headers.ContainsKey(ApiKeyHeaderKey))
            {
                var key = context.Request.Headers[ApiKeyHeaderKey].ToString().Trim();
                if (key.Equals(_apiKey))
                {
                    validApiKey = true;
                }
                else
                {
                    validationMessage = $"Validation key provided '{GetSafeKeyValue(key)}' is different from the expected Api Key '{_safeToDisplayApiKey}'";
                }
            }

            if (!validApiKey)
            {
                var errorMessage = $"Failed to validate api key. {validationMessage}";
                // LambdaLogger.Log($"ERROR: {errorMessage}"); 
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            else
            {
                await _nextRequestDelegate.Invoke(context);
            }
        }

        private bool IsDevelopmentMode(bool isDevelopmentEnvironment) => isDevelopmentEnvironment && _apiKey.Equals(string.Empty);

        private static string GetSafeKeyValue(string key)
        {
            return key.IsEmpty()
                ? ""
                : $"{key.Substring(0, Math.Min(key.Length, 3))}***{key.Substring(Math.Max(0, key.Length - 3))}";
        }

    }
}