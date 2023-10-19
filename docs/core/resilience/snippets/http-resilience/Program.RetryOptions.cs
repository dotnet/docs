using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Resilience;

internal partial class Program
{
    private static void ConfigureRetryOptions(HostApplicationBuilder builder)
    {
        // <options>
        var section =
            builder.Configuration.GetSection("RetryOptions");

        builder.Services.Configure<HttpRetryStrategyOptions>(section);
        // </options>
    }
}
