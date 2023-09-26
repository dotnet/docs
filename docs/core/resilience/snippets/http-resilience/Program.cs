using System.Threading.RateLimiting;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.CircuitBreaker;
using Polly.Registry;

var services = new ServiceCollection();

const string key = "default-pipeline";

services.AddResiliencePipeline(key, builder =>
{
    builder.AddCircuitBreaker(new CircuitBreakerStrategyOptions()
    {
        ManualControl = new CircuitBreakerManualControl(isIsolated: true)
    });

    builder.AddConcurrencyLimiter(new ConcurrencyLimiterOptions()
    {
        QueueProcessingOrder = QueueProcessingOrder.OldestFirst
    });
});

services.AddResilienceEnrichment();

using ServiceProvider provider = services.BuildServiceProvider();

ResiliencePipelineProvider<string> pipelineProvider =
    provider.GetRequiredService<ResiliencePipelineProvider<string>>();

ResiliencePipeline pipeline = pipelineProvider.GetPipeline(key);

await pipeline.ExecuteAsync(static async cancellationToken =>
{
    await ValueTask.CompletedTask;
});
