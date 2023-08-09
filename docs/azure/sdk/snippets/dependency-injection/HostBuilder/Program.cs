#region snippet_HostBuilder
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Azure;

var queueNames = await GetQueueNames();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddAzureClients(clientBuilder =>
        {
            // Register clients for each service
            clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
            clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
            clientBuilder.AddServiceBusClientWithNamespace("<your-namespace>.servicebus.windows.net");
            clientBuilder.UseCredential(new DefaultAzureCredential());

            // Register a subclient for each Service Bus Queue
            foreach (var queue in queueNames)
            {
                clientBuilder.AddClient<ServiceBusSender, ServiceBusClientOptions>((_, _, provider) =>
                    provider.GetService<ServiceBusClient>()!.CreateSender(queue)
                ).WithName(queue);
            }
        });
    }).Build();

await host.RunAsync();

async Task<List<string>> GetQueueNames()
{
    // Query the available queues for the Service Bus namespace.
    var adminClient = new ServiceBusAdministrationClient
        ("<your-namespace>.servicebus.windows.net", new DefaultAzureCredential());
    var queueNames = new List<string>();

    // Because the result is async, they need to be captured to a standard list to avoid async
    // calls when registering. Failure to do so results in an error with the services collection.
    await foreach (var queue in adminClient.GetQueuesAsync())
    {
        queueNames.Add(queue.Name);
    }

    return queueNames;
}
#endregion snippet_HostBuilder
