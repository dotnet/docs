using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

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

using IHost host = builder.Build();
await host.RunAsync();
