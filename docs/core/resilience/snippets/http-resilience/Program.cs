// <setup>
using Http.Resilience.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

IHttpClientBuilder httpClientBuilder = builder.Services.AddHttpClient<ExampleClient>(
    configureClient: static client =>
    {
        client.BaseAddress = new("https://jsonplaceholder.typicode.com");
    });
// </setup>

WithStandardHandler(httpClientBuilder);

// WithStandardHedgingHandler(httpClientBuilder);

// WithCustomHandler(httpClientBuilder);

ConfigureRetryOptions(builder);
WithAdvancedCustomHandler(httpClientBuilder);

// <example-usage>
IHost host = builder.Build();

ExampleClient client = host.Services.GetRequiredService<ExampleClient>();

await foreach (Comment? comment in client.GetCommentsAsync())
{
    Console.WriteLine(comment);
}
// </example-usage>
