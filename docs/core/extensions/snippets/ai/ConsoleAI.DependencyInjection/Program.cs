using Microsoft.Extensions.AI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// App setup
HostApplicationBuilder builder = Host.CreateApplicationBuilder();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddChatClient(new SampleChatClient(
        new Uri("http://coolsite.ai"), "target-ai-model"))
    .UseDistributedCache();

using IHost app = builder.Build();

// Elsewhere in the app
IChatClient chatClient = app.Services.GetRequiredService<IChatClient>();

Console.WriteLine(await chatClient.GetResponseAsync("What is AI?"));

app.Run();
