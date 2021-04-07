using System.Threading.Tasks;
using CD.Notifications.Models;

namespace CD.Notifications.Clients.AmazonSNS
{
    public interface ISNSClient
    {
        Task<bool> SendMessage(NotificationMessage message);
    }
}