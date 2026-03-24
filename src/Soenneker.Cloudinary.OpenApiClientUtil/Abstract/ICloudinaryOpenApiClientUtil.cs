using Soenneker.Cloudinary.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cloudinary.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ICloudinaryOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<CloudinaryOpenApiClient> Get(CancellationToken cancellationToken = default);
}
