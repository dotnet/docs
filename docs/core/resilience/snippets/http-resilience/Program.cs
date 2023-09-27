using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.CircuitBreaker;
using Polly.Registry;

var services = new ServiceCollection();

const string key = "Retry-CircuitBreaker-Timeout";

services.AddResiliencePipeline(key, builder =>
{
    // See: https://www.pollydocs.org/strategies/retry.html
    builder.AddRetry(new());

    // See: https://www.pollydocs.org/strategies/circuit-breaker.html
    builder.AddCircuitBreaker(new CircuitBreakerStrategyOptions());

    builder.AddTimeout(TimeSpan.FromSeconds(5));

    // Add other strategies here...
});

using ServiceProvider provider = services.BuildServiceProvider();

ResiliencePipelineProvider<string> pipelineProvider =
    provider.GetRequiredService<ResiliencePipelineProvider<string>>();

ResiliencePipeline pipeline = pipelineProvider.GetPipeline(key);

int failures = 0;

await pipeline.ExecuteAsync(async cancellationToken =>
{
    await Task.Delay(5_050, cancellationToken);

    throw new Exception($"I failed {++ failures} times...");
});
