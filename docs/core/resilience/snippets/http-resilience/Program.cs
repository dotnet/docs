using Microsoft.Extensions.DependencyInjection;
using Polly;

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

builder.AddResilienceHandler("CustomPipeline", builder =>
{
    builder.

    options.AddCircuitBreaker(new());
});

// services.ConfigureOptions<RetryStrategyOptions<HttpResponseMessage>>(/**/);

var provider = services.BuildServiceProvider();

var client = provider.GetRequiredService<ExampleClient>();

await foreach (var comment in client.GetCommentsAsync())
{
    Console.WriteLine(comment);
}
