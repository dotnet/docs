using Shared;
using NamedHttp.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

string? httpClientName = builder.Configuration["TodoHttpClientName"];
ArgumentException.ThrowIfNullOrEmpty(httpClientName);

builder.Services.AddHttpClient(
    httpClientName,
    client =>
    {
        // Set the base address of the named client.
        client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");

        // Add a user-agent default request header.
        client.DefaultRequestHeaders.UserAgent.ParseAdd("dotnet-docs");
    });
builder.Services.AddTransient<TodoService>();

using IHost host = builder.Build();

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
