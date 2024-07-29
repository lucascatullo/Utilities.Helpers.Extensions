using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Utilities.Helpers.Extensions.Attribute;

/// <summary>
/// Gives you an error if the file extension is not contained in the allowExtension param.
/// </summary>
/// <param name="allowedExtensions">All allowed extensions separated by coma</param>
public class AllowedExtensionsAttribute(string allowedExtensions) : ValidationAttribute
{
    private readonly string _allowedExtensions = allowedExtensions;

    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        var formFile = value as IFormFile;
        if (formFile != null)
        {
            var extension = Path.GetExtension(formFile.FileName);
            if (!_allowedExtensions.ToLower().Contains(extension.ToLower()))
                return new ValidationResult($"File extension is no allowed ({extension}).");
        }
        return ValidationResult.Success!;
    }

}