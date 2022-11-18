using GeneratedHttp.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Refit;
using Shared;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddRefitClient<ITodoService>()
            .ConfigureHttpClient(client =>
            {
                // Set the base address of the named client.
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                // Add a user-agent default request header.
                client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
            });
    })
    .Build();

ITodoService todoService =
    host.Services.GetRequiredService<ITodoService>();

Todo[] todos = await todoService.GetUserTodosAsync(2);

ILogger logger =
    host.Services.GetRequiredService<ILogger<ITodoService>>();

foreach (Todo? todo in todos)
{
    logger.LogInformation("Todo: {Details}", $"""
        Id: {todo?.Id} (Is completed: {todo?.Completed})
        Title: {todo?.Title}
        """);
}

await host.RunAsync();
