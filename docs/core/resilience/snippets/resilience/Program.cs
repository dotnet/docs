// <setup>
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.CircuitBreaker;
using Polly.Registry;
using Polly.Retry;
using Polly.Timeout;

var services = new ServiceCollection();

const string key = "Retry-Timeout";

services.AddResiliencePipeline(key, static builder =>
{
    // See: https://www.pollydocs.org/strategies/retry.html
    builder.AddRetry(new RetryStrategyOptions
    {
        ShouldHandle = new PredicateBuilder().Handle<TimeoutRejectedException>()
    });

    // See: https://www.pollydocs.org/strategies/timeout.html
    builder.AddTimeout(TimeSpan.FromSeconds(1.5));
});
// </setup>

// <enricher>
services.AddResilienceEnricher();
// </enricher>

// <pipeline>
using ServiceProvider provider = services.BuildServiceProvider();

ResiliencePipelineProvider<string> pipelineProvider =
    provider.GetRequiredService<ResiliencePipelineProvider<string>>();

ResiliencePipeline pipeline = pipelineProvider.GetPipeline(key);
// </pipeline>

// <execute>
await pipeline.ExecuteAsync(static cancellationToken =>
{
    // Code that could potentially fail.

    return ValueTask.CompletedTask;
});
// </execute>

Console.WriteLine("Done...");
