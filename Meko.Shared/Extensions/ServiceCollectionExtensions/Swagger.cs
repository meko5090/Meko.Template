using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Meko.Shared.Extensions.ServiceCollectionExtensions;

/// <summary>
/// IServiceCollection extension methods for common configurations
/// </summary>
public static partial class IServiceCollectionExtension
{
    /// <summary>
    /// Adds Swagger to the project's services
    /// </summary>
    /// <param name="services">The Microsoft.Extensions.DependencyInjection.IServiceCollection
    /// to add Swagger to</param>
    /// <param name="apiBase">The base URL of the caller microservice</param>
    /// <param name="assemblyName">The assembly name of the caller microservice</param>
    /// <param name="setupAction">Action to extend configuration by the caller microservice</param>
    public static void ConfigureSwagger(
        this IServiceCollection services,
        string apiBase,
        string assemblyName,
        Action<SwaggerGenOptions>? setupAction = null
    )
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            var xmlFilename = $"{assemblyName}.xml";
            options.IncludeXmlComments(
                Path.Combine(AppContext.BaseDirectory, xmlFilename)
            );

            var JwtScheme = new OpenApiSecurityScheme()
            {
                Scheme = "bearer",
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Reference = new OpenApiReference()
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            options.AddSecurityDefinition(JwtScheme.Reference.Id, JwtScheme);
            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement()
                {
                    { JwtScheme, Array.Empty<string>() }
                }
            );
            options.AddServer(new OpenApiServer { Url = apiBase });

            if (setupAction is not null)
            {
                setupAction(options);
            }
        });
    }
}
