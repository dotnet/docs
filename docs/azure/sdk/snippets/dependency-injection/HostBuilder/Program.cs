using HostBuilder;
#region snippet_HostBuilder
using Azure.Identity;
using Microsoft.Extensions.Azure;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
            clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
            clientBuilder.UseCredential(new DefaultAzureCredential());
        });
    })
    .Build();

await host.RunAsync();
#endregion snippet_HostBuilder
