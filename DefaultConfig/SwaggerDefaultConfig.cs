

using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Utilities.Helpers.Extensions.DefaultConfig;

public static class SwaggerDefaultConfig
{
    public static void DefaultConfigFunction(SwaggerGenOptions options, string assemblyName)
    {
        options.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth", Version = "v1" });
        var xmlFile = $"{assemblyName}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please insert JWT with Bearer into field",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
               new OpenApiSecurityScheme
               {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                Array.Empty<string>()
            }
        });
    }
}
