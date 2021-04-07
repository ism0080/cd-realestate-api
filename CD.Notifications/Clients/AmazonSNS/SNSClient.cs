using System;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using CD.Notifications.Models;
using CD.Notifications.Configurations;
using Microsoft.Extensions.Options;
using Amazon.Lambda.Core;

namespace CD.Notifications.Clients.AmazonSNS
{
    public class SNSClient : ISNSClient
    {
        private readonly IAmazonSimpleNotificationService _amazonSNSClient;
        private static SNSClientSettings _sNSClientConfig;

        public SNSClient(IOptions<SNSClientSettings> sNSClientConfig, IAmazonSimpleNotificationService amazonSNSClient)
        {
            _amazonSNSClient = amazonSNSClient;
            _sNSClientConfig = sNSClientConfig.Value;
        }

        public async Task<bool> SendMessage(NotificationMessage message)
        {

            var request = new PublishRequest
            {
                Subject = message.Subject,
                Message = message.Message,
                TopicArn = _sNSClientConfig.TopicArn
            };

            try
            {
                var response = await _amazonSNSClient.PublishAsync(request);

                return true;
            }
            catch (Exception ex)
            {
                LambdaLogger.Log($"ERROR: {ex.Message}");

                return false;
            }
        }
    }
}