using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Cloudinary.HttpClients.Abstract;
using Soenneker.Cloudinary.OpenApiClientUtil.Abstract;
using Soenneker.Cloudinary.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Cloudinary.OpenApiClientUtil;

///<inheritdoc cref="ICloudinaryOpenApiClientUtil"/>
public sealed class CloudinaryOpenApiClientUtil : ICloudinaryOpenApiClientUtil
{
    private readonly AsyncSingleton<CloudinaryOpenApiClient> _client;

    public CloudinaryOpenApiClientUtil(ICloudinaryOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<CloudinaryOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Cloudinary:ApiKey");
            string authHeaderValueTemplate = configuration["Cloudinary:AuthHeaderValueTemplate"] ?? "Bearer {token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new CloudinaryOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<CloudinaryOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
