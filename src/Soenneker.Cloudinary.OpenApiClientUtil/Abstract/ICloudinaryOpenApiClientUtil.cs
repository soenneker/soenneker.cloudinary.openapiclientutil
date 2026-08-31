using Soenneker.Cloudinary.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cloudinary.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached, configured Cloudinary OpenAPI client.
/// </summary>
public interface ICloudinaryOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the client owned by this utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<CloudinaryOpenApiClient> Get(CancellationToken cancellationToken = default);
}
