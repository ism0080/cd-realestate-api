using Xunit;
using Shouldly;
using System;
using CD.Notifications.Extensions;

namespace CD.Notifications.Tests.Extensions
{
    public class BooleanExtensionTests
    {
        [Fact(DisplayName = "ToYesNoString_ShouldReturnYes_WhenValueTrue")]
        public void ToYesNoString_ShouldReturnYes_WhenValueTrue()
        {
            bool result = true;

            Assert.Equal("Yes", result.ToYesNoString());
        }

        [Fact(DisplayName = "ToYesNoString_ShouldReturnNo_WhenValueFalse")]
        public void ToYesNoString_ShouldReturnNo_WhenValueFalse()
        {
            bool result = false;

            Assert.Equal("No", result.ToYesNoString());
        }
    }
}