using HostBuilder;
#region snippet_HostBuilder
using Azure.Identity;
using Microsoft.Extensions.Azure;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddAzureClients(async clientBuilder =>
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
    })
    .Build();

await host.RunAsync();
#endregion snippet_HostBuilder
