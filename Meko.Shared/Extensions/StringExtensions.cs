using System.Globalization;

namespace Meko.Extensions;

/// <summary>
/// String extension methods
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Helper method that calls string.Format(format, args) with the invariant
    /// Culture info
    /// </summary>
    /// <param name="args">Arguments to be substituted in the format string</param>
    /// <returns>The formatted string</returns>
    public static string FormatInvariant(this string str, params object[] args)
    {
        return string.Format(CultureInfo.InvariantCulture, str, args);
    }
}
