using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Cloudinary.HttpClients.Registrars;
using Soenneker.Cloudinary.OpenApiClientUtil.Abstract;

namespace Soenneker.Cloudinary.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class CloudinaryOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="CloudinaryOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCloudinaryOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddCloudinaryOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ICloudinaryOpenApiClientUtil, CloudinaryOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="CloudinaryOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCloudinaryOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddCloudinaryOpenApiHttpClientAsSingleton()
                .TryAddScoped<ICloudinaryOpenApiClientUtil, CloudinaryOpenApiClientUtil>();

        return services;
    }
}
