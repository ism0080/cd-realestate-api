using CD.Notifications.Models;

namespace CD.Notifications.Extensions
{
    public static class StringBuilder
    {
        public static string NotificationMessage(Customer customer)
        {
            return $"Name: {customer.FirstName} {customer.LastName} \nPhone: {customer.PhoneNumber} \nEmail: {customer.Email} \nAddress: {customer.Address.Street}, {customer.Address.City} {customer.Address.PostCode} \nMessage: {customer.AdditionalMessage} \nReceive Market Update: {customer.MarketUpdate.ToYesNoString()}";
        }
    }
}