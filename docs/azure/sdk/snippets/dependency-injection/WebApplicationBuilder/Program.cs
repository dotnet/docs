#region snippet_WebApplicationBuilder
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

#region snippet_WebApplicationBuilder
builder.Services.AddAzureClients(async clientBuilder =>
{
    // Register clients for each service
    var credential = new DefaultAzureCredential();

    clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
    clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
    clientBuilder.AddServiceBusClient("<NAMESPACE-NAME>.servicebus.windows.net");
    clientBuilder.UseCredential(new DefaultAzureCredential());

    // Register a subclient for each Service Bus Queue
    var admin = new ServiceBusAdministrationClient(
    "<NAMESPACE-NAME>.servicebus.windows.net", credential);

    await foreach (var queue in admin.GetQueuesAsync())
    {
        clientBuilder.AddClient<ServiceBusSender, ServiceBusClientOptions>((_, _, provider) =>
            provider.GetService<ServiceBusClient>()!
                    .CreateSender(queue.Name)
        ).WithName(queue.Name);
    }
});

WebApplication app = builder.Build();
#endregion snippet_WebApplicationBuilder

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
