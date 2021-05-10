using System;
using System.Web;

namespace CD.Notifications.Extensions
{
    public static class StringExtenders
    {
        /// <summary>
        /// Trim if is not null
        /// </summary>
        public static string SafeTrim(this string _this)
        {
            return _this.IsEmpty() ? _this : _this.Trim();
        }

        /// <summary>
        /// Is Empty
        /// </summary>
        public static bool IsEmpty(this string _this)
        {
            return string.IsNullOrEmpty(_this);
        }

        /// <summary>
        /// Is Not Empty
        /// </summary>
        public static bool IsNotEmpty(this string _this)
        {
            return !string.IsNullOrEmpty(_this);
        }

        /// <summary>
        /// Case Insensitive equals
        /// </summary>
        public static bool IEquals(this string _this, string value)
        {
            if (_this == null && value != null)
                return false;

            if (value == null && _this != null)
                return false;

            return _this.Equals(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Combines two paths into one, e.g. /path1/ + /path2 = /path1/path2
        /// </summary>
        /// <returns>Combined path</returns>
        public static string UrlPathCombine(this string _this, string path)
        {
            if (_this.IsEmpty())
                return path;

            if (path.IsEmpty())
                return _this;

            return $"{_this.TrimEnd('/')}/{path.TrimStart('/')}";
        }
    }
}