using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Azure;
using Azure.Messaging.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

builder.Services.AddAzureClients(clientBuilder =>
{
    // Register clients using a config file section
    clientBuilder.AddSecretClient(
        builder.Configuration.GetSection("KeyVault"));

    clientBuilder.AddBlobServiceClient(
        builder.Configuration.GetSection("Storage"));

    // Register clients using a specific config key-value pair
    clientBuilder.AddServiceBusClientWithNamespace(
        builder.Configuration["ServiceBus:Namespace"]);

    // Register a subclient for each Azure Service Bus Queue
    string[] queueNames = [ "queue1", "queue2" ];
    foreach (string queue in queueNames)
    {
        clientBuilder.AddClient<ServiceBusSender, ServiceBusClientOptions>(
            (_, _, provider) => provider.GetService<ServiceBusClient>()
                    .CreateSender(queue)).WithName(queue);
    }

    clientBuilder.UseCredential(new DefaultAzureCredential());

    // Set up any default settings
    clientBuilder.ConfigureDefaults(
        builder.Configuration.GetSection("AzureDefaults"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapGet("/reports", async (
        BlobServiceClient blobServiceClient,
        IAzureClientFactory<ServiceBusSender> senderFactory) =>
{
    // Create the named client
    ServiceBusSender serviceBusSender = senderFactory.CreateClient("queue1");

    await serviceBusSender.SendMessageAsync(new ServiceBusMessage("Hello world"));

    // Use the blob client
    BlobContainerClient containerClient
        = blobServiceClient.GetBlobContainerClient("reports");

    List<BlobItem> reports = new();
    await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
    {
        reports.Add(blobItem);
    }

    return reports;
})
.WithName("GetReports");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
