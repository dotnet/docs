using Shared;
using NamedHttp.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        string? httpClientName = context.Configuration["TodoHttpClientName"];
        services.AddHttpClient(
            httpClientName ?? "",
            client =>
            {
                // Set the base address of the named client.
                client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

                // Add a user-agent default request header.
                client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
            });
        services.AddTransient<TodoService>();
    })
    .Build();

TodoService todoService =
    host.Services.GetRequiredService<TodoService>();

Todo[] todos = await todoService.GetUserTodosAsync(3);

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
