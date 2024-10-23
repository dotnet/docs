using BlazorSample.Components;
using Azure.Identity;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

builder.Services.AddAzureClients(clientBuilder =>
{
    // Register a client for each Azure service using inline configuration
    clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
    clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
    clientBuilder.AddServiceBusClientWithNamespace(
        "<your_namespace>.servicebus.windows.net");

    // Register a subclient for each Azure Service Bus Queue
    var queueNames = new string[] { "queue1", "queue2" };
    foreach (string queue in queueNames)
    {
        clientBuilder.AddClient<ServiceBusSender, ServiceBusClientOptions>(
            (_, _, provider) => provider.GetService<ServiceBusClient>()
                    .CreateSender(queue)).WithName(queue);
    }

    // Register a shared credential for Microsoft Entra ID authentication
    clientBuilder.UseCredential(new DefaultAzureCredential());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
