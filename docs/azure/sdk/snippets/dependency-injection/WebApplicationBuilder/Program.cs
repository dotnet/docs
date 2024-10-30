#region snippet_WebApplicationBuilder
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Azure;
using Azure.AI.OpenAI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAzureClients(async clientBuilder =>
{
    // Register clients for each service
    clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
    clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
    clientBuilder.AddServiceBusClientWithNamespace(
        "<your_namespace>.servicebus.windows.net");

    // Set a credential for all clients to use by default
    DefaultAzureCredential credential = new();
    clientBuilder.UseCredential(credential);

    // Register a subclient for each Service Bus Queue
    List<string> queueNames = await GetQueueNames(credential);
    foreach (string queue in queueNames)
    {
        clientBuilder.AddClient<ServiceBusSender, ServiceBusClientOptions>(
            (_, _, provider) => provider.GetService<ServiceBusClient>()
                .CreateSender(queue)).WithName(queue);
    }

    // Register a custom client factory
    clientBuilder.AddClient<AzureOpenAIClient, AzureOpenAIClientOptions>(
        (options, _, _) => new AzureOpenAIClient(
            new Uri("<url_here>"), credential, options)); 
});

WebApplication app = builder.Build();

async Task<List<string>> GetQueueNames(DefaultAzureCredential credential)
{
    // Query the available queues for the Service Bus namespace.
    var adminClient = new ServiceBusAdministrationClient
        ("<your_namespace>.servicebus.windows.net", credential);
    var queueNames = new List<string>();

    // Because the result is async, the queue names need to be captured
    // to a standard list to avoid async calls when registering. Failure to
    // do so results in an error with the services collection.
    await foreach (QueueProperties queue in adminClient.GetQueuesAsync())
    {
        queueNames.Add(queue.Name);
    }

    return queueNames;
}
#endregion

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

string[] summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    WeatherForecast[] forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

await app.RunAsync();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
