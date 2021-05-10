using Xunit;
using Shouldly;
using System;
using CD.Notifications.Models;
using CD.Notifications.Extensions;

namespace CD.Notifications.Tests.Extensions
{
    public class StringBuilderTests
    {
        private Customer GetCustomer(string message = null, bool update = true)
        {
            return new Customer
            {
                FirstName = "John",
                LastName = "Smith",
                Email = "john.smith@email.com",
                PhoneNumber = "0210315555",
                AdditionalMessage = message,
                MarketUpdate = update,
                Address = new Address
                {
                    Street = "11 Test St",
                    City = "Bulldog",
                    PostCode = "12345"
                }
            };
        }

        [Fact(DisplayName = "NotificationMessage_ShouldReturnCorrectString_WithMessageAndMarketUpdateTrue")]
        public void NotificationMessage_ShouldReturnCorrectString_WithMessageAndMarketUpdateTrue()
        {
            // Arrange
            var customer = GetCustomer("This is a test message");
            var expected = "Name: John Smith \nPhone: 0210315555 \nEmail: john.smith@email.com \nAddress: 11 Test St, Bulldog 12345 \nMessage: This is a test message \nReceive Market Update: Yes";

            // Act
            var message = StringBuilder.NotificationMessage(customer);

            // Assert
            Assert.Equal(expected, message);
        }

        [Fact(DisplayName = "NotificationMessage_ShouldReturnCorrectString_WithMessageNullAndMarketUpdateFalse")]
        public void NotificationMessage_ShouldReturnCorrectString_WithMessageNullAndMarketUpdateFalse()
        {
            // Arrange
            var customer = GetCustomer(update: false);
            var expected = "Name: John Smith \nPhone: 0210315555 \nEmail: john.smith@email.com \nAddress: 11 Test St, Bulldog 12345 \nMessage:  \nReceive Market Update: No";

            // Act
            var message = StringBuilder.NotificationMessage(customer);

            // Assert
            Assert.Equal(expected, message);
        }
    }
}