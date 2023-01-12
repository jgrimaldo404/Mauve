using System;

namespace Mauve.Extensibility
{
    /// <summary>
    /// Represents a collection of extension methods for <see cref="DateTime"/> instances.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Translates the specified <see cref="DateTime"/> instance to a string using a specified <see cref="DateFormat"/>.
        /// </summary>
        /// <param name="input">The <see cref="DateTime"/> instance to translate.</param>
        /// <param name="format">The <see cref="DateFormat"/> to translate to.</param>
        /// <returns>Returns the specified <see cref="DateTime"/> instance translated to a <see cref="string"/> using the specified <see cref="DateFormat"/>.</returns>
        public static string ToString(this DateTime input, DateFormat format)
        {
            switch (format)
            {
                case DateFormat.UnixMilliseconds:
                    long milliseconds = new DateTimeOffset(input).ToUnixTimeMilliseconds();
                    return milliseconds.ToString();
                default: return input.ToString(GetFormatSpecifier(format));
            }
        }
        /// <summary>
        /// Translates the specified <see cref="DateTime"/> instance to a string using a specified <see cref="DateFormat"/>.
        /// </summary>
        /// <param name="input">The <see cref="DateTime"/> instance to translate.</param>
        /// <param name="format">The <see cref="DateFormat"/> to translate to.</param>
        /// <param name="universal">Specifies whether or not <see cref="DateTime.ToUniversalTime()"/> is invoked prior to formatting.</param>
        /// <returns>Returns the specified <see cref="DateTime"/> instance translated to a <see cref="string"/> using the specified <see cref="DateFormat"/>.</returns>
        public static string ToString(this DateTime input, DateFormat format, bool universal) =>
            universal
                ? input.ToUniversalTime().ToString(format)
                : input.ToString(format);
        /// <summary>
        /// Gets the format specifier for a specified <see cref="DateFormat"/>.
        /// </summary>
        /// <param name="format">The <see cref="DateFormat"/> to get the format specifier for.</param>
        /// <returns>Returns the format specifier for a specified <see cref="DateFormat"/>.</returns>
        private static string GetFormatSpecifier(DateFormat format)
        {
            return format switch
            {
                DateFormat.Iso8601 => "yyyy-MM-ddTHH:mm:ss.ffK",
                DateFormat.Rfc3339 => "yyyy-MM-dd'T'HH:mm:ss.fffK",
                DateFormat.MsSql => "yyyy-MM-dd HH:mm:ss.fff",
                _ => string.Empty,
            };
        }
    }
}
