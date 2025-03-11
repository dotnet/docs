#define snippet_Testing
#if snippet_ExampleApp
// <snippet_ExampleApp>
using System.Net;

string[] uris = ["http://example.com", "http://httpbin.org/get", "https://example.com", "https://httpbin.org/get"];
using HttpClient client = new()
{
    DefaultRequestVersion = HttpVersion.Version20
};

Console.WriteLine("Press any key to start.");
Console.ReadKey();

while (!Console.KeyAvailable)
{
    await Parallel.ForAsync(0, Random.Shared.Next(20), async (_, ct) =>
    {
        string uri = uris[Random.Shared.Next(uris.Length)];
        try
        {
            byte[] bytes = await client.GetByteArrayAsync(uri, ct);
            await Console.Out.WriteLineAsync($"{uri} - received {bytes.Length} bytes.");
        }
        catch { await Console.Out.WriteLineAsync($"{uri} - failed."); }
    });
}
// </snippet_ExampleApp>
#elif snippet_Enrichment
// <snippet_Enrichment>
using System.Net.Http.Metrics;

using HttpClient client = new(new EnrichmentHandler() { InnerHandler = new HttpClientHandler() });

await client.GetStringAsync("https://httpbin.org/response-headers?Enrichment-Value=A");
await client.GetStringAsync("https://httpbin.org/response-headers?Enrichment-Value=B");

sealed class EnrichmentHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpMetricsEnrichmentContext.AddCallback(request, static context =>
        {
            if (context.Response is not null) // Response is null when an exception occurs.
            {
                // Use any information available on the request or the response to emit custom tags.
                string? value = context.Response.Headers.GetValues("Enrichment-Value").FirstOrDefault();
                if (value != null)
                {
                    context.AddCustomTag("enrichment_value", value);
                }
            }
        });
        return base.SendAsync(request, cancellationToken);
    }
}
// </snippet_Enrichment>
#elif snippet_EnrichmentWithFactory
// <snippet_EnrichmentWithFactory>
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Metrics;

ServiceCollection services = new();
services.AddHttpClient(Options.DefaultName).AddHttpMessageHandler(() => new EnrichmentHandler());

ServiceProvider serviceProvider = services.BuildServiceProvider();
HttpClient client = serviceProvider.GetRequiredService<HttpClient>();

await client.GetStringAsync("https://httpbin.org/response-headers?Enrichment-Value=A");
await client.GetStringAsync("https://httpbin.org/response-headers?Enrichment-Value=B");

// </snippet_EnrichmentWithFactory>

sealed class EnrichmentHandler : DelegatingHandler
{
    public EnrichmentHandler() { }
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpMetricsEnrichmentContext.AddCallback(request, static context =>
        {
            if (context.Response is not null) // Response is null when an exception occurs.
            {
                // Use any information available on the request or the response to emit custom tags.
                string? value = context.Response.Headers.GetValues("Enrichment-Value").FirstOrDefault();
                if (value != null)
                {
                    context.AddCustomTag("enrichment_value", value);
                }
            }
        });
        return base.SendAsync(request, cancellationToken);
    }
}
#elif snippet_Testing
using System.Diagnostics.Metrics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.Metrics.Testing;
using Xunit;

await new MetricsTests().RequestDurationTest();

public class MetricsTests
{
    // <snippet_Testing>
    [Fact]
    public async Task RequestDurationTest()
    {
        // Arrange
        ServiceCollection services = new();
        services.AddHttpClient();
        ServiceProvider serviceProvider = services.BuildServiceProvider();
        var meterFactory = serviceProvider.GetService<IMeterFactory>();
        var collector = new MetricCollector<double>(meterFactory,
            "System.Net.Http", "http.client.request.duration");
        var client = serviceProvider.GetRequiredService<HttpClient>();

        // Act
        await client.GetStringAsync("http://example.com");

        // Assert
        await collector.WaitForMeasurementsAsync(minCount: 1).WaitAsync(TimeSpan.FromSeconds(5));
        Assert.Collection(collector.GetMeasurementSnapshot(),
            measurement =>
            {
                Assert.Equal("http", measurement.Tags["url.scheme"]);
                Assert.Equal("GET", measurement.Tags["http.request.method"]);
            });
    }
    // </snippet_Testing>
}

#endif
