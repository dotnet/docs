using Shared;
using BasicHttp.Example;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHttpClient();
        services.AddTransient<TodoService>();
    })
    .Build();

TodoService todoService =
    host.Services.GetRequiredService<TodoService>();

Todo[] todos = await todoService.GetUserTodosAsync(1);

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
