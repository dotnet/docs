using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Resilience;

internal partial class Program
{
    private static void ConfigureRetryOptions(HostApplicationBuilder builder)
    {
        // <retry-options>
        var section =
            builder.Configuration.GetSection("RetryOptions");

        builder.Services.Configure<HttpRetryStrategyOptions>(section);

        //// Bind the options to a strongly-typed object
        //HttpRetryStrategyOptions options = new();

        //// Get the retry options from the configuration
        //builder.Configuration
        //    .GetSection("RetryOptions")
        //    .Bind(options);
        // </retry-options>
    }
}
