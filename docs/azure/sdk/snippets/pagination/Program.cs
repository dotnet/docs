using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

// Relies on the following env vars:
//     AZURE_TENANT_ID - The Azure Active Directory tenant (directory) ID.
//     AZURE_CLIENT_ID - The client (application) ID of an App Registration in the tenant.
//     AZURE_CLIENT_SECRET - A client secret that was generated for the App Registration.
//     AZURE_KEY_VAULT_URI - The URI for the Azure Key Vault resource.

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddAzureClients(builder =>
        {
            Uri vaultUri = new(Environment.GetEnvironmentVariable("AZURE_KEY_VAULT_URI")!);

            builder.AddSecretClient(vaultUri);
            builder.UseCredential(new DefaultAzureCredential());
        });
    })
    .Build();

SecretClient client = host.Services.GetRequiredService<SecretClient>();

await IterateSecretsWithAwaitForeachAsync();
await IterateSecretsWithWhileLoopAsync();
await IterateSecretsAsPagesAsync();
await ToListAsync();
await TakeAsync();

IterateWithPageable();

using IDisposable subscription = UseTheToObservableMethod();

await host.RunAsync();

async Task IterateSecretsWithAwaitForeachAsync()
{
    AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

    await foreach (SecretProperties secret in allSecrets)
    {
        Console.WriteLine($"IterateSecretsWithAwaitForeachAsync: {secret.Name}");
    }
}

async Task IterateSecretsWithWhileLoopAsync()
{
    AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

    IAsyncEnumerator<SecretProperties> enumerator = allSecrets.GetAsyncEnumerator();
    try
    {
        while (await enumerator.MoveNextAsync())
        {
            SecretProperties secret = enumerator.Current;
            Console.WriteLine($"IterateSecretsWithWhileLoopAsync: {secret.Name}");
        }
    }
    finally
    {
        await enumerator.DisposeAsync();
    }
}

async Task IterateSecretsAsPagesAsync()
{
    AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

    await foreach (Page<SecretProperties> page in allSecrets.AsPages())
    {
        foreach (SecretProperties secret in page.Values)
        {
            Console.WriteLine($"IterateSecretsAsPagesAsync: {secret.Name}");
        }

        // The continuation token that can be used in AsPages call to resume enumeration
        Console.WriteLine(page.ContinuationToken);
    }
}

async Task ToListAsync()
{
    AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

    List<SecretProperties> secretList = await allSecrets.ToListAsync();
    secretList.ForEach(secret => Console.WriteLine($"ToListAsync: {secret.Name}"));
}

async Task TakeAsync(int count = 30)
{
    AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

    await foreach (SecretProperties secret in allSecrets.Take(count))
    {
        Console.WriteLine($"TakeAsync: {secret.Name}");
    }
}

void IterateWithPageable()
{
    Pageable<SecretProperties> allSecrets = client.GetPropertiesOfSecrets();

    foreach (SecretProperties secret in allSecrets)
    {
        Console.WriteLine($"IterateWithPageable: {secret.Name}");
    }
}

IDisposable UseTheToObservableMethod()
{
    AsyncPageable<SecretProperties> allSecrets = client.GetPropertiesOfSecretsAsync();

    IObservable<SecretProperties> observable = allSecrets.ToObservable();

    return observable.Subscribe(new SecretPropertyObserver());
}

sealed class SecretPropertyObserver : IObserver<SecretProperties>
{
    public void OnCompleted() => Console.WriteLine("Done observing secrets");
    public void OnError(Exception error) => Console.WriteLine($"Error observing secrets: {error}");
    public void OnNext(SecretProperties secret) => Console.WriteLine($"Observable: {secret.Name}");
}
