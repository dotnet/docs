#region snippet_HostBuilder
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Azure;
using OpenAI;
using OpenAI.Responses;
using System.ClientModel.Primitives;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddAzureClients(async clientBuilder =>
        {
            // Register clients for each service
            clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
            clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
            clientBuilder.AddServiceBusClientWithNamespace("<your_namespace>.servicebus.windows.net");
            
            // AddAzureClients implicitly creates a DefaultAzureCredential instance
            // Create a credential manually to override the type or access it explicitly for DI registrations
            // This example shows credential reuse for GetQueueNames and AddClient calls downstream
            DefaultAzureCredential credential = new();
            clientBuilder.UseCredential(credential);
            
            // Register a subclient for each Service Bus Queue
            List<string> queueNames = await GetQueueNames(credential);
            foreach (string queueName in queueNames)
            {
                clientBuilder.AddClient<ServiceBusSender, ServiceBusClientOptions>((_, _, provider) =>
                    provider.GetService(typeof(ServiceBusClient)) switch
                    {
                        ServiceBusClient client => client.CreateSender(queueName),
                        _ => throw new InvalidOperationException("Unable to create ServiceBusClient")
                    }).WithName(queueName);
            }

            var endpoint = Environment.GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT")
            ?? throw new InvalidOperationException("AZURE_OPENAI_ENDPOINT is required.");

            // Register a custom client factory
            #pragma warning disable OPENAI001 // Type is for evaluation purposes and is subject to change in future updates.
            clientBuilder.AddClient<OpenAIResponseClient, OpenAIClientOptions>(
                (options, credential, _) => new OpenAIResponseClient(
                    "gpt-5-mini",
                    new BearerTokenPolicy(new DefaultAzureCredential(), "https://cognitiveservices.azure.com/.default"),
                    new OpenAIClientOptions { Endpoint = new Uri($"{endpoint}/openai/v1/") }
                ));

        });
    }).Build();

await host.RunAsync();

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
#endregion snippet_HostBuilder
