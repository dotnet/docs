using Microsoft.Extensions.AI;
using OpenTelemetry.Trace;

// Configure OpenTelemetry exporter
var sourceName = Guid.NewGuid().ToString();
var tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    .AddSource(sourceName)
    .AddConsoleExporter()
    .Build();

var sampleChatClient = new SampleChatClient(
    new Uri("http://coolsite.ai"), "target-ai-model");

IChatClient client = new ChatClientBuilder(sampleChatClient)
    .UseOpenTelemetry(
        sourceName: sourceName,
        configure: static c => c.EnableSensitiveData = true)
    .Build();

Console.WriteLine((await client.GetResponseAsync("What is AI?")).Message);
