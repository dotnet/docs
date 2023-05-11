using Shared;
using TypedHttp.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient<TodoService>(
            client =>
            {
                // Set the base address of the typed client.
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                // Add a user-agent default request header.
                client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
            });
    })
    .Build();

TodoService todoService =
    host.Services.GetRequiredService<TodoService>();

Todo[] todos = await todoService.GetUserTodosAsync(4);

ILogger logger =
    host.Services.GetRequiredService<ILogger<TodoService>>();

foreach (Todo? todo in todos)
{
    logger.LogInformation("Todo: {Details}", $"""
        Id: {todo?.Id} (Is completed: {todo?.Completed})
        Title: {todo?.Title}
        """);
}

await host.RunAsync();
