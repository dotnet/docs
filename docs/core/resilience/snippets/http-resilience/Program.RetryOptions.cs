using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Http.Resilience;

internal partial class Program
{
    private static void ConfigureRetryOptions(HostApplicationBuilder builder)
    {
        // <options>
        var section = builder.Configuration.GetSection("RetryOptions");

        builder.Services.Configure<HttpStandardResilienceOptions>(section);
        // </options>
    }

    private static void DisableRetriesFor(IHttpClientBuilder httpClientBuilder)
    {
        // <disable_for>
        httpClientBuilder.AddStandardResilienceHandler(options =>
        {
            options.Retry.DisableFor(HttpMethod.Post, HttpMethod.Delete);
        });
        // </disable_for>
    }

    private static void DisableRetriesForUnsafeHttpMethods(IHttpClientBuilder httpClientBuilder)
    {
        // <disable_for_unsafe_http_methods>
        httpClientBuilder.AddStandardResilienceHandler(options =>
        {
            options.Retry.DisableForUnsafeHttpMethods();
        });
        // </disable_for_unsafe_http_methods>
    }
}
