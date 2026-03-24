using Soenneker.Cloudinary.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Cloudinary.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class CloudinaryOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly ICloudinaryOpenApiClientUtil _openapiclientutil;

    public CloudinaryOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<ICloudinaryOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
