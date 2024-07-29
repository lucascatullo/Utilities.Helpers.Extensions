using System.Text.RegularExpressions;

namespace Utilities.Helpers.Extensions.Extension;

public static class StringExtension
{
    public static bool GetSubString(this string val, string fromString, string toString, out string result)
    {
        result = "";
        var startIndex = val.IndexOf(fromString) + fromString.Length;
        var endIndex = val.IndexOf(toString);
        var response = true;

        if (startIndex == -1 || endIndex == -1)
            response = false;
        else
            result = val[startIndex..endIndex];

        return response;
    }

    public static bool HasEmailFormat(this string val) => new Regex(@"^[\w-.]+@([\w-]+.)+[\w-]{2,4}$", RegexOptions.None).IsMatch(val);
    public static bool IsValidAsPassword(this string pass) => !(pass.Length < 8 && new Regex("[a-z]").Matches(pass).Count < 1 && new Regex("[1-9]").Matches(pass).Count < 1);
}