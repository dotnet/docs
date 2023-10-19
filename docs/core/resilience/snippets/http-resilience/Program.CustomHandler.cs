using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Polly;

internal partial class Program
{
    private static void WithCustomHandler(IHttpClientBuilder httpClientBuilder)
    {
        // <custom-handler>
        httpClientBuilder.AddResilienceHandler(
            "CustomPipeline",
            static builder =>
        {
            // See: https://www.pollydocs.org/strategies/retry.html
            builder.AddRetry(new HttpRetryStrategyOptions
            {
                // Customize and configure the retry logic.
                BackoffType = DelayBackoffType.Exponential,
                MaxRetryAttempts = 5,
                UseJitter = true
            });

            // See: https://www.pollydocs.org/strategies/circuit-breaker.html
            builder.AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions
            {
                // Customize and configure the circuit breaker logic.
                SamplingDuration = TimeSpan.FromSeconds(10),
                FailureRatio = 0.2,
                MinimumThroughput = 3,
                ShouldHandle = static args =>
                {
                    return ValueTask.FromResult(args is
                    {
                        Outcome.Result.StatusCode:
                            HttpStatusCode.RequestTimeout or
                                HttpStatusCode.TooManyRequests
                    });
                }
            });

            // See: https://www.pollydocs.org/strategies/timeout.html
            builder.AddTimeout(TimeSpan.FromSeconds(5));
        });
        // </custom-handler>
    }

    private static void WithAdvancedCustomHandler(IHttpClientBuilder httpClientBuilder)
    {
        // <advanced-handler>
        httpClientBuilder.AddResilienceHandler(
            "AdvancedPipeline",
            static (ResiliencePipelineBuilder<HttpResponseMessage> builder,
                ResilienceHandlerContext context) =>
            {
                // Enable the reloads whenever the named options change
                context.EnableReloads<HttpRetryStrategyOptions>("RetryOptions");

                // Retrieve the named options
                var retryOptions =
                    context.GetOptions<HttpRetryStrategyOptions>("RetryOptions");

                // Add retries using the resolved options
                builder.AddRetry(retryOptions);
            });
        // </advanced-handler>
    }
}
