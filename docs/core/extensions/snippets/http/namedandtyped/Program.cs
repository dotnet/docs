using Shared;
using TypedHttp.Example;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHttpClient<TodoService>("primary"
    client =>
    {
        // Configure the primary typed client
        client.BaseAddress = new Uri("https://primary-host-address.com/");
        client.Timeout = TimeSpan.FromSeconds(3);
    });

// Register the same typed client but with different settings
builder.Services.AddHttpClient<TodoService>("secondary"
    client =>
    {
        // Configure the secondary typed client
        client.BaseAddress = new Uri("https://secondary-host-address.com/");
        client.Timeout = TimeSpan.FromSeconds(10);
    });

using IHost host = builder.Build();

// Fetch an IHttpClientFactory instance to create a named client
IHttpClientFactory namedClientFactory =
    host.Services.GetRequiredService<IHttpClientFactory>();

// Fetch an ITypedHttpClientFactory<TodoService> instance to create a named and typed client
ITypedHttpClientFactory<TodoService> typedClientFactory  =
    host.Services.GetRequiredService<ITypedHttpClientFactory<TodoService>>();

// Create a TodoService instance against the primary host
var primaryClient = namedClientFactory.CreateClient("primary");
var todoService = typedClientFactory.CreateClient(primaryClient);

try
{
    Todo[] todos = await todoService.GetUserTodosAsync(4);
}
catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
{
    // The request timed out against the primary host

    // Create a TodoService instance against the secondary host
    var fallbackClient = namedClientFactory.CreateClient("secondary");
    var todoFallbackService = typedClientFactory.CreateClient(fallbackClient);

    // Issue request against the secondary host
    Todo[] todos = await todoFallbackService.GetUserTodosAsync(4);
}

await host.RunAsync();
