using CD.Notifications.Models;

namespace CD.Notifications.Extensions
{
    public static class StringBuilder
    {
        public static string NotificationMessage(Customer customer)
        {
            return $"Name: {customer.FirstName} {customer.LastName} \n Phone: {customer.PhoneNumber} \n Email: {customer.Email} \n Address: {customer.Address.StreetNumber} {customer.Address.StreetName}, {customer.Address.Suburb}, {customer.Address.City} {customer.Address.PostCode}";
        }
    }
}