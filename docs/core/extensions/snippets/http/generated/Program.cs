using GeneratedHttp.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;
using Shared;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddRefitClient<IJokeService>()
            .ConfigureHttpClient(client =>
            {
                // Set the base address of the named client.
                client.BaseAddress = new Uri("https://api.icndb.com/");

                // Add a user-agent default request header.
                client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
            });
    })
    .Build();

IJokeService jokeService =
    host.Services.GetRequiredService<IJokeService>();

ChuckNorrisJoke joke = await jokeService.GetRandomJokeAsync();

ILogger logger =
    host.Services.GetRequiredService<ILogger<IJokeService>>();

logger.LogInformation("Joke: {Text}", joke?.Value?.Joke);

await host.RunAsync();
