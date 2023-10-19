// <setup>
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.CircuitBreaker;
using Polly.Registry;
using Polly.Retry;

var services = new ServiceCollection();

const string key = "Retry-CircuitBreaker-Timeout";

services.AddResiliencePipeline(key, static builder =>
{
    // See: https://www.pollydocs.org/strategies/retry.html
    builder.AddRetry(new RetryStrategyOptions());

    // See: https://www.pollydocs.org/strategies/circuit-breaker.html
    builder.AddCircuitBreaker(new CircuitBreakerStrategyOptions());

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
await pipeline.ExecuteAsync(static async cancellationToken =>
{
    // Code that could potentially fail.

    await ValueTask.CompletedTask;
});
// </execute>

Console.WriteLine("Done...");
