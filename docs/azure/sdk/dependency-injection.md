---
title: Dependency injection with the Azure SDK for .NET
description: Learn how to use dependency injection with the Azure SDK for .NET client libraries.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 2/28/2023
---

# Dependency injection with the Azure SDK for .NET

This article demonstrates how to register Azure service clients from the [latest Azure SDKs for .NET](https://azure.github.io/azure-sdk/releases/latest/index.html#net) for [dependency injection in an ASP.NET Core app](/aspnet/core/fundamentals/dependency-injection). Every ASP.NET Core app starts up by using the instructions provided in the _Program.cs_ file.

To configure the service clients, first add the following NuGet packages to your project:

- [Microsoft.Extensions.Azure](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/extensions/Microsoft.Extensions.Azure/README.md)
- [Azure.Identity](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/identity/Azure.Identity/README.md)
- The `Azure.*` package you'd like to use.

The sample code in this article uses Key Vault secrets and Blob Storage for demonstration purposes.

```dotnetcli
dotnet add package Microsoft.Extensions.Azure
dotnet add package Azure.Identity
dotnet add package Azure.Security.KeyVault.Secrets
dotnet add package Azure.Storage.Blobs
dotnet add package Azure.Storage.ServiceBus
```

<<<<<<< Updated upstream
## Register client

In the _Program.cs_ file, register a client for each service:
=======
## Register clients and subclients

A service client is the entry point to the API for an Azure service – from it, library users can invoke all operations the service provides and can easily implement the most common scenarios. In the *Program.cs* file, invoke the <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClients%2A> extension method to register a client for each service.
Where it will simplify an API's design, groups of service calls can be organized around smaller subclient types. The following code samples provide guidance on application builders from the `Microsoft.AspNetCore.Builder` and `Microsoft.Extensions.Hosting` namespaces.
>>>>>>> Stashed changes

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    // Add a KeyVault client
    clientBuilder.AddSecretClient(keyVaultUrl);

    // Add a Storage account client
    clientBuilder.AddBlobServiceClient(storageUrl);

    // Use DefaultAzureCredential by default
    clientBuilder.UseCredential(new DefaultAzureCredential());
});

builder.Services.AddControllers();
```

In the preceding code:

<<<<<<< Updated upstream
* You specify the `Uri`-typed `keyVaultUrl` and `storageUrl` variables. The [Store configuration separately from code](#store-configuration-separately-from-code) section shows how you can avoid specifying the URLs explicitly.
* <xref:Azure.Identity.DefaultAzureCredential> is used for authentication. `DefaultAzureCredential` chooses the best authentication mechanism based on your environment, allowing you to move your app seamlessly from development to production with no code changes.
=======
* Key Vault Secrets and Blob Storage clients are registered using <xref:Microsoft.Extensions.Azure.SecretClientBuilderExtensions.AddSecretClient%2A> and <xref:Microsoft.Extensions.Azure.BlobClientBuilderExtensions.AddBlobServiceClient%2A>, respectively. The `Uri`-typed arguments are passed. To avoid specifying these URLs explicitly, see the [Store configuration separately from code](#store-configuration-separately-from-code) section.
* <xref:Azure.Identity.DefaultAzureCredential> is used to satisfy the `TokenCredential` argument requirement for each registered client. When one of the clients is created, `DefaultAzureCredential` is used to authenticate.
* Service Bus subclients are registered for each queue on the service using the subclient type and a corresponding options type.
>>>>>>> Stashed changes

## Use the registered clients

With the clients registered in the `AddAzureClients`, you can now use them:

```csharp
[ApiController]
[Route("[controller]")]
public class MyApiController : ControllerBase
{
    private readonly BlobServiceClient _blobServiceClient;
  
    public MyApiController(BlobServiceClient blobServiceClient)
    {
        _blobServiceClient = blobServiceClient;
    }
  
    // Get a list of all the blobs in the demo container
    [HttpGet]
    public async Task<IEnumerable<string>> Get()
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient("demo");
        var results = new List<string>();
        await foreach (BlobItem blob in containerClient.GetBlobsAsync())
        {
            results.Add(blob.Name);
        }
        return results.ToArray();
    }
}
```

## Store configuration separately from code

In the [Register client](#register-client) section, you explicitly specify the `keyVaultUrl` and `storageUrl` variables. This approach could cause problems when you run code against different environments during development and production. The .NET team suggests [storing such configurations in environment-dependent JSON files](../../core/extensions/configuration-providers.md#json-configuration-provider). For example, you can have an _appsettings.Development.json_ file containing development environment settings. Another _appsettings.Production.json_ file would contain production environment settings, and so on. The file format is:

```json
{
  "AzureDefaults": {
    "Diagnostics": {
      "IsTelemetryDisabled": false,
      "IsLoggingContentEnabled": true
    },
    "Retry": {
      "MaxRetries": 3,
      "Mode": "Exponential"
    }
  },
  "KeyVault": {
    "VaultUri": "https://mykeyvault.vault.azure.net"
  },
  "Storage": {
    "ServiceUri": "https://mydemoaccount.storage.windows.net"
  }
}
```

You can add any options from <xref:Azure.Core.ClientOptions> into the JSON file's `AzureDefaults` section. One of the options is the retry policy. For more information, see [Configure a new retry policy](#configure-a-new-retry-policy).

Since the `Configuration` object is a member of the `builder` instance, you can configure secrets:

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    // Add a KeyVault client
    clientBuilder.AddSecretClient(builder.Configuration.GetSection("KeyVault"));

    // Add a storage account client
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("Storage"));

    // Use DefaultAzureCredential by default
    clientBuilder.UseCredential(new DefaultAzureCredential());

    // Set up any default settings
    clientBuilder.ConfigureDefaults(builder.Configuration.GetSection("AzureDefaults"));
});

builder.Services.AddControllers();
```

## Configure multiple service clients with different names

Assume you have two storage accounts: one for private information and one for public information. Your app transfers data from the public to private storage account after some operation. You need to have two storage service clients. To set up these clients in the _Program.cs_ file:

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("PublicStorage"));
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("PrivateStorage"))
        .WithName("PrivateStorage");
});
```

In your controller, you can access the named service clients using <xref:Microsoft.Extensions.Azure.IAzureClientFactory%601?displayProperty=nameWithType>:

```csharp
public class HomeController : Controller
{
    private readonly BlobServiceClient _publicStorage;
    private readonly BlobServiceClient _privateStorage;

    public HomeController(
        BlobServiceClient defaultClient,
        IAzureClientFactory<BlobServiceClient> clientFactory)
    {
        _publicStorage = defaultClient;
        _privateStorage = clientFactory.CreateClient("PrivateStorage");
    }
}
```

The unnamed service client is still available in the same way as before. Named clients are additive.

## Configure a new retry policy

At some point, you might want to change the default settings for a service client. You may want different retry settings or to use a different service API version, for example. You can set the retry settings globally or on a per-service basis. Assume you have the following _appsettings.json_ file:

```json
{
  "AzureDefaults": {
    "Retry": {
      "maxRetries": 3
    }
  },
  "KeyVault": {
    "VaultUri": "https://mykeyvault.vault.azure.net"
  },
  "Storage": {
    "ServiceUri": "https://store1.storage.windows.net"
  },
  "CustomStorage": {
    "ServiceUri": "https://store2.storage.windows.net"
  }
}
```

You could change the retry policy depending on your needs like so:
  
```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    // Establish the global defaults
    clientBuilder.ConfigureDefaults(builder.Configuration.GetSection("AzureDefaults"));
    clientBuilder.UseCredential(new DefaultAzureCredential());

    // A Key Vault Secrets client using the global defaults
    clientBuilder.AddSecretClient(builder.Configuration.GetSection("KeyVault"));

    // A Storage client with a custom retry policy
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("Storage"))
        .ConfigureOptions(options => options.Retry.MaxRetries = 10);

    // A named storage client with a different custom retry policy
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("CustomStorage"))
        .WithName("CustomStorage")
        .ConfigureOptions(options =>
        {
            options.Retry.Mode = Azure.Core.RetryMode.Exponential;
            options.Retry.MaxRetries = 5;
            options.Retry.MaxDelay = TimeSpan.FromSeconds(120);
        });
});
```

You can also place policy overrides in the _appsettings.json_ file:

```json
{
  "KeyVault": {
    "VaultUri": "https://mykeyvault.vault.azure.net",
    "Retry": {
      "maxRetries": 10
    }
  }
}
```

## See also

- [Dependency injection in .NET](../../core/extensions/dependency-injection.md)
- [Configuration in .NET](../../core/extensions/configuration.md)
- [Configuration in ASP.NET Core](/aspnet/core/fundamentals/configuration)
