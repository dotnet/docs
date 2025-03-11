using Example.Two;

// <program>
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddChatClient(services =>
    new SampleChatClient(new Uri("http://localhost"), "test")
        .AsBuilder()
        .UseDistributedCache()
        .UseRateLimiting()
        .UseOpenTelemetry()
        .Build(services));

using var app = builder.Build();

// Elsewhere in the app
var chatClient = app.Services.GetRequiredService<IChatClient>();

Console.WriteLine(await chatClient.GetResponseAsync("What is AI?"));

app.Run();
// </program>
