using System.Text;

namespace Utilities.Helpers.Extensions.Helper;

public static class StreamHelper
{
    public static async Task<string> ToString(Stream steam)
    {
        string documentContents;
        using (Stream receiveStream = steam)
        {
            using StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            documentContents = await readStream.ReadToEndAsync();
        }
        return documentContents;
    }
}