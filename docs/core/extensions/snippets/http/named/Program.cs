using NamedHttp.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        string httpClientName = context.Configuration["JokeHttpClientName"];
        services.AddHttpClient(
            httpClientName,
            client =>
            {
                // Set the base address of the named client.
                client.BaseAddress = new Uri("https://api.icndb.com/");

                // Add a user-agent default request header.
                client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
            });
        services.AddTransient<JokeService>();
    })
    .Build();

JokeService jokeService =
    host.Services.GetRequiredService<JokeService>();

string jokeText = await jokeService.GetRandomJokeAsync();

ILogger logger =
    host.Services.GetRequiredService<ILogger<JokeService>>();

logger.LogInformation("Joke: {Text}", jokeText);

await host.RunAsync();
