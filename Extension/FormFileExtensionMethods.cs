using Microsoft.AspNetCore.Http;

namespace Utilities.Helpers.Extensions.Extension;

public static class FormFileExtensionMethods
{
    public static byte[] GetBytes(this IFormFile file)
    {
        using (var ms = new MemoryStream())
        {
            file.CopyTo(ms);
            return ms.ToArray();
        }
    }
}