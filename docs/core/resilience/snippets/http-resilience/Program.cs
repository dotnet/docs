using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;

var services = new ServiceCollection();

var builder = services.AddHttpClient<ExampleClient>(
    configureClient: static client =>
    {
        client.BaseAddress = new("https://jsonplaceholder.typicode.com");
    });

builder.AddStandardResilienceHandler(options =>
{
    options.RetryOptions.BackoffType = DelayBackoffType.Exponential;
});

builder.AddResilienceHandler("CustomPipeline", static builder =>
{
    builder.AddRetry(new RetryStrategyOptions<HttpResponseMessage>
    {
        // Custom options
        BackoffType = DelayBackoffType.Exponential,
    });

    builder.AddCircuitBreaker(new CircuitBreakerStrategyOptions<HttpResponseMessage>());

    builder.AddTimeout(TimeSpan.FromSeconds(5));
});

builder.AddStandardHedgingHandler();

// services.ConfigureOptions<RetryStrategyOptions<HttpResponseMessage>>(/**/);

var provider = services.BuildServiceProvider();

var client = provider.GetRequiredService<ExampleClient>();

await foreach (var comment in client.GetCommentsAsync())
{
    Console.WriteLine(comment);
}
