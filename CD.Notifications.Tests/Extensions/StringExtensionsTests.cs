using CD.Notifications.Extensions;
using Shouldly;
using Xunit;

namespace CD.Notifications.Tests.Extensions
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("lol     ", "lol")]
        [InlineData("      lol     ", "lol")]
        [InlineData("lol", "lol")]
        [InlineData("l o l", "l o l")]
        [InlineData("    l o l    ", "l o l")]
        public void SafeTrimTests(string input, string expected)
        {
            input.SafeTrim().ShouldBe(expected);
        }

        [Theory]
        [InlineData("", true)]
        [InlineData(null, true)]
        [InlineData("lol     ", false)]
        [InlineData("      lol     ", false)]
        [InlineData("lol", false)]
        [InlineData("    ", false)]
        [InlineData(" ", false)]
        public void IsEmptyTests(string input, bool expected)
        {
            input.IsEmpty().ShouldBe(expected);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData(null, false)]
        [InlineData("lol     ", true)]
        [InlineData("      lol     ", true)]
        [InlineData("lol", true)]
        [InlineData("    ", true)]
        [InlineData(" ", true)]
        public void IsNotEmptyTests(string input, bool expected)
        {
            input.IsNotEmpty().ShouldBe(expected);
        }

        [Theory]
        [InlineData("", "")]
        [InlineData("asd", "ASD")]
        [InlineData("lol", "LoL")]
        [InlineData("      lol     ", "      lOl     ")]
        [InlineData("1111lol1111", "1111lOl1111")]
        public void IEquals_ShouldBeEqualNoMatterTheCase(string str1, string str2)
        {
            str1.IEquals(str2).ShouldBe(true);
        }

        [Theory]
        [InlineData("", null)]
        [InlineData(null, "")]
        [InlineData("asd", " ASD")]
        [InlineData("lol", "LoL ")]
        [InlineData("1111lol1111", "1111l0l1111")]
        public void IEquals_ShouldNotBeEqual(string str1, string str2)
        {
            str1.IEquals(str2).ShouldBe(false);
        }

        [Theory]
        [InlineData("/path1/", "path2", "/path1/path2")]
        [InlineData("/path1/", "/path2", "/path1/path2")]
        [InlineData("/path1/", "/path2/", "/path1/path2/")]
        [InlineData("/path1", "/path2", "/path1/path2")]
        [InlineData("/path1", "path2", "/path1/path2")]
        [InlineData("path1", "path2", "path1/path2")]
        [InlineData("", "path2", "path2")]
        [InlineData("path1", "", "path1")]
        [InlineData("path1", null, "path1")]
        [InlineData(null, "path2", "path2")]
        public void UrlPathCombineTests(string path1, string path2, string expected)
        {
            path1.UrlPathCombine(path2).ShouldBe(expected);
        }
    }
}