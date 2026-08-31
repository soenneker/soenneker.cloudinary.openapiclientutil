[![](https://img.shields.io/nuget/v/soenneker.cloudinary.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudinary.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudinary.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cloudinary.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cloudinary.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cloudinary.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cloudinary.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cloudinary.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Cloudinary.OpenApiClientUtil

Provides a cached, authenticated `CloudinaryOpenApiClient` with configurable base URL and authorization formatting.

## Installation

```bash
dotnet add package Soenneker.Cloudinary.OpenApiClientUtil
```

## Configuration

```json
{
  "Cloudinary": {
    "ApiKey": "your-api-token",
    "ClientBaseUrl": "https://api.cloudinary.com",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

`ApiKey` is required. The other values show their defaults. Use the header name, value template, and base URL required by the Cloudinary API you call, and store credentials outside source control.

## Registration

```csharp
using Soenneker.Cloudinary.OpenApiClientUtil.Registrars;

services.AddCloudinaryOpenApiClientUtilAsScoped();
```

Singleton registration is available with `AddCloudinaryOpenApiClientUtilAsSingleton()`.

The scoped utility borrows a singleton `ICloudinaryOpenApiHttpClient`. Disposing a scope clears that utility's generated-client cache but deliberately leaves the shared HTTP provider and its client alive; the container disposes the provider at the end of its own lifetime.

## Usage

```csharp
using Soenneker.Cloudinary.OpenApiClientUtil.Abstract;

CloudinaryOpenApiClient client = await clientUtil.Get(cancellationToken);

// Continue through the generated V1_1 or V2 request builders.
var v1 = client.V1_1;
```

`Get` is thread-safe and returns one generated client for the utility's lifetime. The generated client exposes Cloudinary request builders and models directly; API errors and nullable response bodies follow Kiota's generated behavior.

Do not dispose the borrowed `HttpClient` or mutate the shared request adapter. Dispose the utility through dependency injection according to the selected registration lifetime.
