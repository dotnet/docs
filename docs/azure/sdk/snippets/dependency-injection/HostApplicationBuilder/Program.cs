using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
    clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
    clientBuilder.UseCredential(new DefaultAzureCredential());
});

using IHost host = builder.Build();
await host.RunAsync();
