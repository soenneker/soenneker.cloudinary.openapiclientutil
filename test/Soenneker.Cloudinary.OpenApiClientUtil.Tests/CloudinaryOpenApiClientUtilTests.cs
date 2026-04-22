using Soenneker.Cloudinary.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Cloudinary.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CloudinaryOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ICloudinaryOpenApiClientUtil _openapiclientutil;

    public CloudinaryOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ICloudinaryOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
