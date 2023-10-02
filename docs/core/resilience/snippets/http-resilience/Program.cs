using System.Net;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;

var services = new ServiceCollection();

var builder = services.AddHttpClient<ExampleClient>(
    configureClient: static client =>
    {
        client.BaseAddress = new("https://jsonplaceholder.typicode.com");
    });

builder.AddStandardResilienceHandler(options =>
{
    options.RetryOptions.BackoffType = DelayBackoffType.Linear;
});

builder.AddResilienceHandler("CustomPipeline", static builder =>
{
    // See: https://www.pollydocs.org/strategies/retry.html
    builder.AddRetry(new HttpRetryStrategyOptions
    {
        BackoffType = DelayBackoffType.Exponential,
        MaxRetryAttempts = 5,
        UseJitter = true
    });

    // See: https://www.pollydocs.org/strategies/circuit-breaker.html
    builder.AddCircuitBreaker(new HttpCircuitBreakerStrategyOptions
    {
        SamplingDuration = TimeSpan.FromSeconds(10),
        FailureRatio = 0.2,
        MinimumThroughput = 3,
        ShouldHandle = static args =>
        {
            return ValueTask.FromResult(args is
            {
                Outcome.Result.StatusCode:
                    HttpStatusCode.RequestTimeout or HttpStatusCode.TooManyRequests
            });
        }
    });

    // See: https://www.pollydocs.org/strategies/timeout.html
    builder.AddTimeout(TimeSpan.FromSeconds(5));
});

builder.AddStandardHedgingHandler();

builder.AddStandardHedgingHandler(static (IRoutingStrategyBuilder builder) =>
{
    // Hedging allows sending multiple concurrent requests
    builder.ConfigureOrderedGroups(static orderedGroup =>
    {
        orderedGroup.Groups.Add(new EndpointGroup()
        {
            Endpoints =
            {
                // Imagine a/b testing
                new WeightedEndpoint() { Uri = new("route/a"), Weight = 1 },
                new WeightedEndpoint() { Uri = new("b"), Weight = 99 }
            }
        });
    });

    builder.ConfigureWeightedGroups(static weightedGroup =>
    {
        weightedGroup.SelectionMode = WeightedGroupSelectionMode.EveryAttempt;

        weightedGroup.Groups.Add(new WeightedEndpointGroup()
        {
            Endpoints =
            {
                // imagine a/b testing
                new WeightedEndpoint() { Uri = new("a"), Weight = 1 },
                new WeightedEndpoint() { Uri = new("b"), Weight = 99 }
            }
        });
    });
});

builder.AddResilienceHandler(
    "AdvancedPipeline",
    static (ResiliencePipelineBuilder<HttpResponseMessage> builder,
        ResilienceHandlerContext context) =>
{
    // Enable the reloads whenever the named options change
    context.EnableReloads<RetryStrategyOptions>("my-retry-options");

    // Retrieve the named options
    var retryOptions =
        context.ServiceProvider
            .GetRequiredService<IOptionsMonitor<RetryStrategyOptions<HttpResponseMessage>>>()
            .Get("my-retry-options");

    // Add retries using the resolved options
    builder.AddRetry(retryOptions);
});

var provider = services.BuildServiceProvider();

var client = provider.GetRequiredService<ExampleClient>();

await foreach (var comment in client.GetCommentsAsync())
{
    Console.WriteLine(comment);
}
