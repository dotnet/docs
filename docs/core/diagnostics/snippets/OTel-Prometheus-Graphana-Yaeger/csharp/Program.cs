// <WholeProgram>
using System.Diagnostics;
using System.Diagnostics.Metrics;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using Azure.Monitor.OpenTelemetry.AspNetCore;
using Azure;

var builder = WebApplication.CreateBuilder(args);


// <Snippet_CustomMetrics>
// Custom metrics for the application
var GreeterMeter = new Meter("GOtPrGrYa.Sample", "1.0.0");
var CountGreetings = GreeterMeter.CreateCounter<int>("greetings.count", description: "Counts the number of greetings");

// Custom ActivitySource for the application
var GreeterActivitySource = new ActivitySource("OtPrGrYa.Sample");
// </Snippet_CustomMetrics>
// <Snippet_HttpClientFactory>
builder.Services.AddHttpClient();
// </Snippet_HttpClientFactory>


#if !AZURE_MONITOR
// <Snippet_OTEL>
var TracingOtlpEndpoint = builder.Configuration["OTLP_ENDPOINT_URL"];
var otel = builder.Services.AddOpenTelemetry();

// Configure OpenTelemetry Resources with the application name
otel.ConfigureResource(resource => resource
    .AddService(serviceName: builder.Environment.ApplicationName));

// Add Metrics for ASP.NET Core and our custom metrics and export to Prometheus
otel.WithMetrics(metrics => metrics
    // Metrics provider from OpenTelemetry
    .AddAspNetCoreInstrumentation()
    .AddMeter(GreeterMeter.Name)
    // Metrics provides by ASP.NET in .NET 8
    .AddMeter("Microsoft.AspNetCore.Hosting")
    .AddMeter("Microsoft.AspNetCore.Http.Connections")
    .AddMeter("Microsoft.AspNetCore.Server.Kestrel")
    .AddPrometheusExporter());

// Add Tracing for ASP.NET Core and our custom ActivitySource and export to Jaeger
otel.WithTracing(tracing =>
{
    tracing.AddAspNetCoreInstrumentation();
    tracing.AddHttpClientInstrumentation();
    tracing.AddSource(GreeterActivitySource.Name);
    if (TracingOtlpEndpoint != null)
    {
        tracing.AddOtlpExporter(otlpOptions =>
         {
             otlpOptions.Endpoint = new Uri(TracingOtlpEndpoint);
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
       .AddMeter(GreeterMeter.Name)
       .AddMeter("Microsoft.AspNetCore.Hosting")
       .AddMeter("Microsoft.AspNetCore.Http.Connections")
       .AddMeter("Microsoft.AspNetCore.Server.Kestrel"));
otel.WithTracing(tracing =>
{
    tracing.AddSource(GreeterActivitySource.Name);
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


#if !AZURE_MONITOR
//<Snippet_Prometheus>
// Configure the Prometheus scraping endpoint
app.UseOpenTelemetryPrometheusScrapingEndpoint();
//</Snippet_Prometheus>
#endif

app.Run();

//<Snippet_SendGreeting>
async Task<String> SendGreeting(ILogger<Program> logger)
{
    // Create a new Activity scoped to the method
    using var activity = GreeterActivitySource.StartActivity("GreeterActivity");

    // Log a message
    logger.LogInformation("Sending greeting");

    // Increment the custom counter
    CountGreetings.Add(1);

    // Add a tag to the Activity
    activity?.SetTag("greeting", "Hello World!");

    return "Hello World!";
}
//</Snippet_SendGreeting>

//<Snippet_SendNestedGreeting>
async Task SendNestedGreeting(int nestlevel, ILogger<Program> logger, HttpContext context, IHttpClientFactory clientFactory)
{
    // Create a new Activity scoped to the method
    using var activity = GreeterActivitySource.StartActivity("GreeterActivity");

    if (nestlevel <= 5)
    {
        // Log a message
        logger.LogInformation("Sending greeting, level {nestlevel}", nestlevel);

        // Increment the custom counter
        CountGreetings.Add(1);

        // Add a tag to the Activity
        activity?.SetTag("nest-level", nestlevel);

        var url = new Uri($"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}?nestlevel={nestlevel - 1}");
        await context.Response.WriteAsync($"Nested Greeting, level: {nestlevel}\r\n");
        if (nestlevel > 0) await context.Response.WriteAsync(await clientFactory.CreateClient().GetStringAsync(url));
    }
    else
    {
        // Log a message
        logger.LogInformation("Greeting nest level {nestlevel} too high ", nestlevel);
        await context.Response.WriteAsync("Nest level too high, max is 5");
    }
}
//</Snippet_SendNestedGreeting>
