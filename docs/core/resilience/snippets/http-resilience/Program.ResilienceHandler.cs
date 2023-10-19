using Microsoft.Extensions.DependencyInjection;
using Polly;

internal partial class Program
{
    private static void WithStandardHandler(IHttpClientBuilder httpClientBuilder)
    {
        // <standard-handler>
        httpClientBuilder.AddStandardResilienceHandler();
        // </standard-handler>
    }

    private static void WithConfiguredStandardHandler(IHttpClientBuilder httpClientBuilder)
    {
        // <configure-standard-handler>
        httpClientBuilder.AddStandardResilienceHandler(static options =>
        {
            options.Retry.BackoffType = DelayBackoffType.Linear;
        });
        // </configure-standard-handler>
    }
}
