using CD.Notifications.Models;

namespace CD.Notifications.Extensions
{
    public static class StringBuilder
    {
        public static string NotificationMessage(Customer customer)
        {
            return $"Name: {customer.FirstName} {customer.LastName} \n Phone: {customer.PhoneNumber} \n Email: {customer.Email} \n Address: {customer.Address.Street}, {customer.Address.City} {customer.Address.PostCode} \n Message: {customer.AdditionalMessage}";
        }
    }
}