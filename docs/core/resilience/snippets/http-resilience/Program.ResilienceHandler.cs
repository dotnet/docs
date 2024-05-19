using Microsoft.Extensions.DependencyInjection;
using Polly;

internal partial class Program
{
    private static void WithStandardHandler(IHttpClientBuilder httpClientBuilder)
    {
        // <standard>
        httpClientBuilder.AddStandardResilienceHandler();
        // </standard>
    }

    private static void WithConfiguredStandardHandler(IHttpClientBuilder httpClientBuilder)
    {
        // <configure>
        httpClientBuilder.AddStandardResilienceHandler(static options =>
        {
            options.Retry.BackoffType = DelayBackoffType.Linear;
        });
        // </configure>
    }
}
