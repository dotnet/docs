using Microsoft.Extensions.AI;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using OllamaSharp;
using OpenTelemetry.Trace;

// Configure OpenTelemetry exporter.
var sourceName = Guid.NewGuid().ToString();
var tracerProvider = OpenTelemetry.Sdk.CreateTracerProviderBuilder()
    .AddSource(sourceName)
    .AddConsoleExporter()
    .Build();

// <Snippet1>
// Explore changing the order of the intermediate "Use" calls.
IChatClient client = new ChatClientBuilder(new OllamaApiClient(new Uri("http://localhost:11434"), "llama3.1"))
    .UseDistributedCache(new MemoryDistributedCache(Options.Create(new MemoryDistributedCacheOptions())))
    .UseFunctionInvocation()
    .UseOpenTelemetry(sourceName: sourceName, configure: c => c.EnableSensitiveData = true)
    .Build();
// </Snippet1>

ChatOptions options = new()
{
    Tools = [AIFunctionFactory.Create(
        () => Random.Shared.NextDouble() > 0.5 ? "It's sunny" : "It's raining",
        name: "GetCurrentWeather",
        description: "Gets the current weather")]
};

for (int i = 0; i < 3; i++)
{
    List<ChatMessage> history =
    [
        new ChatMessage(ChatRole.System, "You are a helpful AI assistant"),
        new ChatMessage(ChatRole.User, "Do I need an umbrella?")
    ];

    Console.WriteLine(await client.GetResponseAsync(history, options));
}
