//#define SECOND
#if FIRST
// <snippet_1>
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
        byte[] bytes = await client.GetByteArrayAsync(uri, ct);
        await Console.Out.WriteLineAsync($"{uri} - received {bytes.Length} bytes.");
    });
}
// </snippet_1>
#elif SECOND
// <snippet_2>
using OpenTelemetry.Metrics;
using OpenTelemetry;
using System.Net;

using MeterProvider meterProvider = Sdk.CreateMeterProviderBuilder()
    .AddMeter("System.Net.Http", "System.Net.NameResolution")
    .AddPrometheusHttpListener(options => options.UriPrefixes = new string[] { "http://localhost:9184/" })
    .Build();

string[] uris = ["http://example.com", "http://httpbin.org/get", "https://example.com", "https://httpbin.org/get"];
using HttpClient client = new()
{
    DefaultRequestVersion = HttpVersion.Version20
};

while (!Console.KeyAvailable)
{
    await Parallel.ForAsync(0, Random.Shared.Next(20), async (_, ct) =>
    {
        string uri = uris[Random.Shared.Next(uris.Length)];
        byte[] bytes = await client.GetByteArrayAsync(uri, ct);
        await Console.Out.WriteLineAsync($"{uri} - received {bytes.Length} bytes.");
    });
}
// </snippet_2>
#else
// <snippet_3>
using System.Net.Http.Metrics;
using HttpClient client = new();

using HttpRequestMessage request1 = new(HttpMethod.Get, "https://httpbin.org/response-headers?Enrichment-Value=A");
HttpMetricsEnrichmentContext.AddCallback(request1, EnrichmentCallback);
using HttpResponseMessage response1 = await client.SendAsync(request1);

using HttpRequestMessage request2 = new(HttpMethod.Get, "https://httpbin.org/response-headers?Enrichment-Value=B");
HttpMetricsEnrichmentContext.AddCallback(request2, EnrichmentCallback);
using HttpResponseMessage response2 = await client.SendAsync(request2);

static void EnrichmentCallback(HttpMetricsEnrichmentContext context)
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
}
// </snippet_3>
#endif
