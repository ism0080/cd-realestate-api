using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CD.Notifications.Models;
using CD.Notifications.Clients.AmazonSNS;
using CD.Notifications.Extensions;
using Amazon.Lambda.Core;

namespace CD.Notification.Controllers
{
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISNSClient _snsClient;
        public SubscriptionController(ISNSClient snsClient)
        {
            _snsClient = snsClient;
        }

        [HttpPost("database")]
        public async Task<IActionResult> AddToDatabase([FromBody] Customer request)
        {
            try
            {
                var message = StringBuilder.NotificationMessage(request);
                var snsMessage = new NotificationMessage
                {
                    Message = message,
                    Subject = "Add to Database"
                };

                var result = await _snsClient.SendMessage(snsMessage);

                return Ok($"Notification Sent {result}");
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("appraisal")]
        public IActionResult RequestAppraisal([FromBody] Customer request)
        {
            return Ok("Notification Sent");
        }
    }
}
