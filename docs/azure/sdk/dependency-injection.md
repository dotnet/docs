---
title: Dependency injection with the Azure SDK for .NET
description: Learn how to use dependency injection with the Azure SDK for .NET client libraries.
ms.topic: how-to
ms.custom: devx-track-dotnet, engagement-fy23
ms.date: 07/21/2023
---

# Dependency injection with the Azure SDK for .NET

This article demonstrates how to register Azure service clients from the [latest Azure client libraries for .NET](https://azure.github.io/azure-sdk/releases/latest/index.html#net) for [dependency injection in a .NET app](/dotnet/core/extensions/dependency-injection). Every modern .NET app starts up by using the instructions provided in a *Program.cs* file.

## Install packages

To register and configure service clients from an [`Azure.`-prefixed package](/dotnet/azure/sdk/packages#libraries-using-azurecore):

1. Install the [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) package in your project:

    ```dotnetcli
    dotnet add package Microsoft.Extensions.Azure
    ```

1. Install the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) package to configure a `TokenCredential` type to use for authenticating all registered clients that accept such a type:

    ```dotnetcli
    dotnet add package Azure.Identity
    ```

For demonstration purposes, the sample code in this article uses the Key Vault Secrets and Blob Storage libraries. Install the following packages to follow along:

```dotnetcli
dotnet add package Azure.Security.KeyVault.Secrets
dotnet add package Azure.Storage.Blobs
```

## Register clients

In the *Program.cs* file, invoke the <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClients%2A> extension method to register a client for each service. The following code samples provide guidance on application builders from the `Microsoft.AspNetCore.Builder` and `Microsoft.Extensions.Hosting` namespaces.

### [WebApplicationBuilder](#tab/web-app-builder)

:::code language="csharp" source="snippets/dependency-injection/WebApplicationBuilder/Program.cs" id="snippet_WebApplicationBuilder" highlight="6-11":::

### [HostApplicationBuilder](#tab/host-app-builder)

:::code language="csharp" source="snippets/dependency-injection/HostApplicationBuilder/Program.cs" highlight="7-12":::

### [HostBuilder](#tab/host-builder)

:::code language="csharp" source="snippets/dependency-injection/HostBuilder/Program.cs" id="snippet_HostBuilder" highlight="8-13":::

---

In the preceding code:

* Key Vault Secrets and Blob Storage clients are registered using <xref:Microsoft.Extensions.Azure.SecretClientBuilderExtensions.AddSecretClient%2A> and <xref:Microsoft.Extensions.Azure.BlobClientBuilderExtensions.AddBlobServiceClient%2A>, respectively. The `Uri`-typed arguments are passed. To avoid specifying these URLs explicitly, see the [Store configuration separately from code](#store-configuration-separately-from-code) section.
* <xref:Azure.Identity.DefaultAzureCredential> is used to satisfy the `TokenCredential` argument requirement for each registered client. When one of the clients is created, `DefaultAzureCredential` is used to authenticate.

## Use the registered clients

With the clients registered, as described in the [Register clients](#register-clients) section, you can now use them. In the following example, [constructor injection](/dotnet/core/extensions/dependency-injection#constructor-injection-behavior) is used to obtain the Blob Storage client in an ASP.NET Core API controller:

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
  
    [HttpGet]
    public async Task<IEnumerable<string>> Get()
    {
        BlobContainerClient containerClient = 
            _blobServiceClient.GetBlobContainerClient("demo");
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

In the [Register clients](#register-clients) section, you explicitly passed the `Uri`-typed variables to the client constructors. This approach could cause problems when you run code against different environments during development and production. The .NET team suggests [storing such configurations in environment-dependent JSON files](../../core/extensions/configuration-providers.md#json-configuration-provider). For example, you can have an *appsettings.Development.json* file containing development environment settings. Another *appsettings.Production.json* file would contain production environment settings, and so on. The file format is:

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

You can add any properties from the <xref:Azure.Core.ClientOptions> class into the JSON file. In the preceding JSON sample:

* The `AzureDefaults` section name is used; however, that name is arbitrary.
* The `AzureDefaults.Retry` object literal:
  * Represents the retry policy configuration settings.
  * Corresponds to the <xref:Azure.Core.ClientOptions.Retry> property. Within that object literal, you find the `MaxRetries` key, which corresponds to the <xref:Azure.Core.RetryOptions.MaxRetries> property.

For more information, see [Configure a new retry policy](#configure-a-new-retry-policy).

The settings in the JSON configuration file can be retrieved using <xref:Microsoft.Extensions.Configuration.IConfiguration>.

### [WebApplicationBuilder](#tab/web-app-builder)

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(
        builder.Configuration.GetSection("KeyVault"));

    clientBuilder.AddBlobServiceClient(
        builder.Configuration.GetSection("Storage"));

    clientBuilder.UseCredential(new DefaultAzureCredential());

    // Set up any default settings
    clientBuilder.ConfigureDefaults(
        builder.Configuration.GetSection("AzureDefaults"));
});
```

### [HostApplicationBuilder](#tab/host-app-builder)

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(
        builder.Configuration.GetSection("KeyVault"));

    clientBuilder.AddBlobServiceClient(
        builder.Configuration.GetSection("Storage"));

    clientBuilder.UseCredential(new DefaultAzureCredential());

    // Set up any default settings
    clientBuilder.ConfigureDefaults(
        builder.Configuration.GetSection("AzureDefaults"));
});
```

### [HostBuilder](#tab/host-builder)

```csharp
IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        services.AddAzureClients(clientBuilder =>
        {
            clientBuilder.AddSecretClient(
                hostContext.Configuration.GetSection("KeyVault"));

            clientBuilder.AddBlobServiceClient(
                hostContext.Configuration.GetSection("Storage"));

            clientBuilder.UseCredential(new DefaultAzureCredential());

            // Set up any default settings
            clientBuilder.ConfigureDefaults(
                hostContext.Configuration.GetSection("AzureDefaults"));
        });
    })
    .Build();
```

---

## Configure multiple service clients with different names

Imagine you have two storage accounts: one for private information and another for public information. Your app transfers data from the public to the private storage account after some operation. You need to have two storage service clients. To differentiate those two clients, use the <xref:Microsoft.Extensions.Azure.AzureClientBuilderExtensions.WithName%2A> extension method:

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(
        builder.Configuration.GetSection("PublicStorage"));

    clientBuilder.AddBlobServiceClient(
            builder.Configuration.GetSection("PrivateStorage"))
        .WithName("PrivateStorage");
});
```

Using an ASP.NET Core controller as an example, access the named service client using the <xref:Microsoft.Extensions.Azure.IAzureClientFactory%601> interface:

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

At some point, you may want to change the default settings for a service client. For example, you may want different retry settings or to use a different service API version. You can set the retry settings globally or on a per-service basis. Assume you have the following *appsettings.json* file in your ASP.NET Core project:

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

You can change the retry policy to suit your needs like so:
  
```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    // Establish the global defaults
    clientBuilder.ConfigureDefaults(
        builder.Configuration.GetSection("AzureDefaults"));
    clientBuilder.UseCredential(new DefaultAzureCredential());

    // A Key Vault Secrets client using the global defaults
    clientBuilder.AddSecretClient(
        builder.Configuration.GetSection("KeyVault"));

    // A Blob Storage client with a custom retry policy
    clientBuilder.AddBlobServiceClient(
            builder.Configuration.GetSection("Storage"))
        .ConfigureOptions(options => options.Retry.MaxRetries = 10);

    // A named storage client with a different custom retry policy
    clientBuilder.AddBlobServiceClient(
            builder.Configuration.GetSection("CustomStorage"))
        .WithName("CustomStorage")
        .ConfigureOptions(options =>
        {
            options.Retry.Mode = Azure.Core.RetryMode.Exponential;
            options.Retry.MaxRetries = 5;
            options.Retry.MaxDelay = TimeSpan.FromSeconds(120);
        });
});
```

You can also place retry policy overrides in the *appsettings.json* file:

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

* [Dependency injection in ASP.NET Core](/aspnet/core/fundamentals/dependency-injection)
* [Configuration in .NET](/dotnet/core/extensions/configuration)
* [Configuration in ASP.NET Core](/aspnet/core/fundamentals/configuration)
