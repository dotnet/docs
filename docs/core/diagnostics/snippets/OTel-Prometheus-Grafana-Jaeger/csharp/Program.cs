// <WholeProgram>
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Azure;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;

var builder = WebApplication.CreateBuilder(args);

// <Snippet_CustomMetrics>
// Custom metrics for the application
var greeterMeter = new Meter("OtPrGrYa.Example", "1.0.0");
var countGreetings = greeterMeter.CreateCounter<int>("greetings.count", description: "Counts the number of greetings");

// Custom ActivitySource for the application
var greeterActivitySource = new ActivitySource("OtPrGrJa.Example");
// </Snippet_CustomMetrics>
// <Snippet_HttpClientFactory>
builder.Services.AddHttpClient();
// </Snippet_HttpClientFactory>


#if !AZURE_MONITOR
// <Snippet_OTEL>
var tracingOtlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"];
var otel = builder.Services.AddOpenTelemetry();

// Configure OpenTelemetry Resources with the application name
otel.ConfigureResource(resource => resource
    .AddService(serviceName: builder.Environment.ApplicationName));

// Add Metrics for ASP.NET Core and our custom metrics and export to Prometheus
otel.WithMetrics(metrics => metrics
    // Metrics provider from OpenTelemetry
    .AddAspNetCoreInstrumentation()
    .AddMeter(greeterMeter.Name)
    // Metrics provides by ASP.NET Core in .NET 8
    .AddMeter("Microsoft.AspNetCore.Hosting")
    .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
    // Metrics provided by System.Net libraries
    .AddMeter("System.Net.Http")
    .AddMeter("System.Net.NameResolution")
    .AddPrometheusExporter());

// Add Tracing for ASP.NET Core and our custom ActivitySource and export to Jaeger
otel.WithTracing(tracing =>
{
    tracing.AddAspNetCoreInstrumentation();
    tracing.AddHttpClientInstrumentation();
    tracing.AddSource(greeterActivitySource.Name);
    if (tracingOtlpEndpoint != null)
    {
        tracing.AddOtlpExporter(otlpOptions =>
         {
             otlpOptions.Endpoint = new Uri(tracingOtlpEndpoint);
         });
    }
    else
    {
        tracing.AddConsoleExporter();
    }
});
//</Snippet_OTEL>

#else
//<Snippet_AzureMonitor>
var otel = builder.Services.AddOpenTelemetry();
otel.UseAzureMonitor();
otel.WithMetrics(metrics => metrics
    .AddMeter(greeterMeter.Name)
    .AddMeter("Microsoft.AspNetCore.Hosting")
    .AddMeter("Microsoft.AspNetCore.Server.Kestrel"));
otel.WithTracing(tracing =>
{
    tracing.AddSource(greeterActivitySource.Name);
});
//</Snippet_AzureMonitor>
#endif

var app = builder.Build();

//<Snippet_MapGet>
app.MapGet("/", SendGreeting);
//</Snippet_MapGet>

//<Snippet_MapNested>
app.MapGet("/NestedGreeting", SendNestedGreeting);
//</Snippet_MapNested>

//<Snippet_ClientStress>
app.MapGet("/ClientStress", async Task<string> (ILogger<Program> logger, HttpClient client) =>
{
    string[] uris = ["http://example.com", "http://httpbin.org/get", "https://example.com", "https://httpbin.org/get"];
    await Parallel.ForAsync(0, 50, async (_, ct) =>
    {
        string uri = uris[Random.Shared.Next(uris.Length)];

        try
        {
            await client.GetAsync(uri, ct);
            logger.LogInformation($"{uri} - done.");
        }
        catch { logger.LogInformation($"{uri} - failed."); }
    });
    return "Sent 50 requests to example.com and httpbin.org.";
});
//</Snippet_ClientStress>

#if !AZURE_MONITOR
//<Snippet_Prometheus>
// Configure the Prometheus scraping endpoint
app.MapPrometheusScrapingEndpoint();
//</Snippet_Prometheus>
#endif

app.Run();

//<Snippet_SendGreeting>
async Task<string> SendGreeting(ILogger<Program> logger)
{
    // Create a new Activity scoped to the method
    using var activity = greeterActivitySource.StartActivity("GreeterActivity");

    // Log a message
    logger.LogInformation("Sending greeting");

    // Increment the custom counter
    countGreetings.Add(1);

    // Add a tag to the Activity
    activity?.SetTag("greeting", "Hello World!");

    return "Hello World!";
}
//</Snippet_SendGreeting>

//<Snippet_SendNestedGreeting>
async Task SendNestedGreeting(int nestlevel, ILogger<Program> logger, HttpContext context, IHttpClientFactory clientFactory)
{
    // Create a new Activity scoped to the method
    using var activity = greeterActivitySource.StartActivity("GreeterActivity");

    if (nestlevel <= 5)
    {
        // Log a message
        logger.LogInformation("Sending greeting, level {nestlevel}", nestlevel);

        // Increment the custom counter
        countGreetings.Add(1);

        // Add a tag to the Activity
        activity?.SetTag("nest-level", nestlevel);

        await context.Response.WriteAsync($"Nested Greeting, level: {nestlevel}\r\n");

        if (nestlevel > 0)
        {
            var request = context.Request;
            var url = new Uri($"{request.Scheme}://{request.Host}{request.Path}?nestlevel={nestlevel - 1}");

            // Makes an http call passing the activity information as http headers
            var nestedResult = await clientFactory.CreateClient().GetStringAsync(url);
            await context.Response.WriteAsync(nestedResult);
        }
    }
    else
    {
        // Log a message
        logger.LogError("Greeting nest level {nestlevel} too high", nestlevel);
        await context.Response.WriteAsync("Nest level too high, max is 5");
    }
}
//</Snippet_SendNestedGreeting>
