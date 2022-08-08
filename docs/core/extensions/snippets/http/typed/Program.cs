﻿using TypedHttp.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient<JokeService>(
            client =>
            {
                // Set the base address of the named client.
                client.BaseAddress = new Uri("https://api.icndb.com/");

                // Add a user-agent default request header.
                client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
            });
    })
    .Build();

JokeService jokeService =
    host.Services.GetRequiredService<JokeService>();

string jokeText = await jokeService.GetRandomJokeAsync();

ILogger logger =
    host.Services.GetRequiredService<ILogger<JokeService>>();

logger.LogInformation("Joke: {Text}", jokeText);

await host.RunAsync();
