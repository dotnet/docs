using Example.Two;

using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// <SnippetUse>
HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddChatClient(services =>
    new SampleChatClient(new Uri("http://localhost"), "test")
        .AsBuilder()
        .UseDistributedCache()
        .UseRateLimiting()
        .UseOpenTelemetry()
        .Build(services));
// </SnippetUse>

// Elsewhere in the app
using IHost app = builder.Build();
IChatClient chatClient = app.Services.GetRequiredService<IChatClient>();

Console.WriteLine(await chatClient.GetResponseAsync("What is AI?"));

app.Run();
