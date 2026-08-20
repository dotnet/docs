// <Snippet_Usings>
using System.Diagnostics;
using System.Diagnostics.Metrics;
using OpenTelemetry.Exporter;
using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
// </Snippet_Usings>

// <Snippet_CustomMetrics>
// Custom metrics for the application
var greeterMeter = new Meter("OTel.Example", "1.0.0");
var countGreetings = greeterMeter.CreateCounter<int>("greetings.count", description: "Counts the number of greetings");

// Custom ActivitySource for the application
var greeterActivitySource = new ActivitySource("OTel.Example");
// </Snippet_CustomMetrics>

var builder = WebApplication.CreateBuilder(args);

// <Snippet_OTEL>
// Configure the shared OTLP connection used by logs, metrics, and traces.
var otlpEndpoint = new Uri(builder.Configuration["OTEL_EXPORTER_OTLP_ENDPOINT"]!);
Action<OtlpExporterOptions> configureOtlp = options =>
{
    options.Endpoint = otlpEndpoint;
    options.Protocol = OtlpExportProtocol.Grpc;
    options.Headers = builder.Configuration["OTEL_EXPORTER_OTLP_HEADERS"]; // To secure endpoint (not in this example)
};

// Setup logging to be exported via OpenTelemetry
builder.Logging.AddOpenTelemetry(logging =>
{
    logging.IncludeFormattedMessage = true;
    logging.IncludeScopes = true;
    logging.AddOtlpExporter(configureOtlp);
});

var otel = builder.Services.AddOpenTelemetry();

// Identify this application as a single service in the Aspire dashboard.
otel.ConfigureResource(resource => resource.AddService(builder.Configuration["OTEL_SERVICE_NAME"]!));

// Add Metrics for ASP.NET Core and our custom metrics and export via OTLP
otel.WithMetrics(metrics =>
{
    // Metrics provider from OpenTelemetry
    metrics.AddAspNetCoreInstrumentation();
    //Our custom metrics
    metrics.AddMeter(greeterMeter.Name);
    // Metrics provides by ASP.NET Core in .NET
    metrics.AddMeter("Microsoft.AspNetCore.Hosting");
    metrics.AddMeter("Microsoft.AspNetCore.Server.Kestrel");
    metrics.AddOtlpExporter(configureOtlp);
});

// Add Tracing for ASP.NET Core and our custom ActivitySource and export via OTLP
otel.WithTracing(tracing =>
{
    tracing.AddAspNetCoreInstrumentation();
    tracing.AddHttpClientInstrumentation();
    tracing.AddSource(greeterActivitySource.Name);
    tracing.AddOtlpExporter(configureOtlp);
});
// </Snippet_OTEL>

var app = builder.Build();

// <Snippet_MapGet>
app.MapGet("/", SendGreeting);
// </Snippet_MapGet>

app.Run();

// <Snippet_SendGreeting>
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
// </Snippet_SendGreeting>
