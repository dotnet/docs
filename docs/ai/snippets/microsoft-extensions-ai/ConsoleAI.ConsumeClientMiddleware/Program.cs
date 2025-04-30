using Example.Two;

// <program>
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// <SnippetUse>
var client = new OllamaChatClient(new Uri("http://localhost:11434"), "llama3.1")
    .AsBuilder()
    .UseDistributedCache()
    .UseRateLimiting()
    .UseOpenTelemetry()
    .Build(services);
// </SnippetUse>

// Elsewhere in the app
var chatClient = app.Services.GetRequiredService<IChatClient>();

Console.WriteLine(await chatClient.GetResponseAsync("What is AI?"));

app.Run();
// </program>
