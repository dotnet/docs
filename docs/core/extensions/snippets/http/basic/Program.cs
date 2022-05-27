using BasicHttp.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
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
