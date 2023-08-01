namespace BingSamples.Web.Core;

public static class StringExtensions
{
    public static string Truncate(this string original, int numberOfChars = 10, string endChar = "...")
    {
        if (original.Length > numberOfChars)
            original = original[..numberOfChars];
        original += endChar;
        return original;
    }
}