using Microsoft.Extensions.AI;
using OllamaSharp;
using OpenTelemetry.Trace;

// Configure OpenTelemetry exporter.
string sourceName = Guid.NewGuid().ToString();
TracerProvider tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    .AddSource(sourceName)
    .AddConsoleExporter()
    .Build();

IChatClient ollamaClient = new OllamaApiClient(
    new Uri("http://localhost:11434/"), "phi3:mini");

IChatClient client = new ChatClientBuilder(ollamaClient)
    .UseOpenTelemetry(
        sourceName: sourceName,
        configure: c => c.EnableSensitiveData = true)
    .Build();

Console.WriteLine((await client.GetResponseAsync("What is AI?")).Text);
