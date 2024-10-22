---
title: Best practices for using the Azure SDK with ASP.NET Core
description: Learn best practices and the steps to properly implement the Azure SDK for .NET in your ASP.NET Core apps.
ms.topic: conceptual
ms.custom: devx-track-dotnet
ms.date: 10/22/2024
---

# Implement the Azure SDK for .NET in ASP.NET Core apps

The Azure SDK for .NET enables ASP.NET Core apps to integrate with many different Azure services. In this article, you'll learn best practices and the steps to implement the Azure SDK for .NET in your ASP.NET Core apps. You'll learn how to:

- Register services for dependency injection.
- Implement centralized, standardized configuration.
- Authenticate to Azure without using passwords or secrets.
- Configure common web app concerns such as logging and retries.

## Register service clients

The Azure SDK for .NET provides service clients to connect your app to Azure services such as Azure Blob Storage and Azure Key Vault. Register these services with the dependency container in the `Program.cs` file of your app to make them available to your app using Dependency Injection. The [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) library provides helper methods to properly register your services and handles various concerns for you, such as setting up logging, handling service lifetimes, and authentication credential management.

Complete the following steps to register the services you need:

1. Install the [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) package:

    ```dotnetcli
    dotnet add package Microsoft.Extensions.Azure
    ```

2. Install the `Azure.*` service packages you need for your app:

    ```dotnetcli
    dotnet add package Azure.Security.KeyVault.Secrets
    dotnet add package Azure.Storage.Blobs
    dotnet add package Azure.Messaging.ServiceBus
    ```

3. In the `Program.cs` file, invoke the `AddAzureClients` extension method from the `Microsoft.Extensions.Azure` library to register a client for each service. Some services use additional subclients, which you can also register for dependency injection.

    ```csharp
    builder.Services.AddAzureClients(clientBuilder =>
    {
        // Register clients for each Azure service
        clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
        clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
        clientBuilder.AddServiceBusClientWithNamespace(
            "<your_namespace>.servicebus.windows.net");

        // Register a shared credential for Microsoft Entra ID authentication
        clientBuilder.UseCredential(new DefaultAzureCredential());
    
        // Register a subclient for each Azure Service Bus Queue
        foreach (string queue in queueNames)
        {
            clientBuilder.AddClient<ServiceBusSender, ServiceBusClientOptions>(
                (_, _, provider) => provider.GetService<ServiceBusClient>()
                        .CreateSender(queue)).WithName(queue);
        }
    });
    ```

4. Inject the registered services into your ASP.NET Core app components, services, or API endpoint methods:

    ## [Minimal API](#tab/api)

    ```csharp
    app.MapPost("/reports", async (BlobServiceClient blobServiceClient) =>
    {
        // Use the blob client
        BlobContainerClient containerClient 
            = await blobServiceClient.CreateBlobContainerAsync("reports");
    });
    ```

    ## [Blazor](#tab/blazor)

    ```csharp
    @page "/reports"
    @inject BlobServiceClient blobservice
    
    <h1>Reports</h1>
    
    <ul>
    @foreach(var report in reports)
    {
        <li>@report.Name</li>
    }
    </ul>
    
    @code {
        List<BlobItem> reports = new();
    
        protected override async Task OnInitializedAsync()
        {
            BlobContainerClient containerClient = blobservice.GetBlobContainerClient("reports");
    
            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                reports.Add(blobItem);
            }
        }
    }
    ```

    ---

## Authenticate using Microsoft Entra ID

Microsoft Entra ID is the recommended approach to authorize requests to Azure services. Use the [Azure Identity client library]() to implement secretless connections to Azure services in your code. The Azure Identity client library provides tools such as `DefaultAzureCredential` to simplify configuring secure connections. `DefaultAzureCredential` supports multiple authentication methods and determines which method should be used at runtime. This approach enables your app to use different authentication methods in different environments (local vs. production) without implementing environment-specific code.

Some Azure services also allow you to authorize requests using secrets keys. However, this approach should be used with caution. Developers must be diligent to never expose the access key in an unsecure location. Anyone who has the access key is able to authorize requests against the service and data.

Consider the following service client registrations:

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    // Register clients for each Azure service
    clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
    clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
    clientBuilder.AddServiceBusClientWithNamespace(
        "<your_namespace>.servicebus.windows.net");

    // Register a shared credential for Microsoft Entra ID authentication
    clientBuilder.UseCredential(new DefaultAzureCredential());

    // Register a subclient for each Azure Service Bus Queue
    foreach (string queue in queueNames)
    {
        clientBuilder.AddClient<ServiceBusSender, ServiceBusClientOptions>(
            (_, _, provider) => provider.GetService<ServiceBusClient>()
                    .CreateSender(queue)).WithName(queue);
    }
});
```

In the preceding code, the `clientBuilder.UseCredential()` method accepts an instance of `DefaultAzureCredential` that will be reused across your registered services. `DefaultAzureCredential` discovers available credentials in the current environment and use them to connect to Azure services. The full order and locations in which `DefaultAzureCredential` looks for credentials can be found in the [`Azure Identity library overview`](/dotnet/api/overview/azure/Identity-readme#defaultazurecredential).

For example, when you run the app locally, `DefaultAzureCredential` discovers and uses credentials from the following developer tools:

- Environment variables
- Visual Studio
- Azure CLI
- Azure PowerShell
- Azure Developer CLI

`DefaultAzureCredential` also discovers credentials after you deploy your app from the following:

- Environment variables
- Workload identity
- Managed identity

## Set up service configurations

Azure service clients support configurations to change their default behaviors. There are two ways to configure service clients:

- You can [store configurations in environment-dependent JSON files](/dotnet/core/extensions/configuration-providers#json-configuration-provider). Configuration files are generally the recommended approach because they simplify app deployments between environments and help eliminate hard coded values.
- You can also configurations directly in your code when you register the service client. For example, in the [Register clients and subclients](#register-service-clients-and-subclients) section, you explicitly passed the Uri-typed variables to the client constructors.

The following example uses an `appsettings.Development.json` file to store development environment settings and an `appsettings.Production.json` file to contain production environment settings. You can add any properties from the [`ClientOptions`](/dotnet/api/azure.core.clientoptions) class into the JSON file.

1. Update the `appsettings.<environment>.json` file in your app to match the following structure:

    ```json
    {
      "KeyVault": {
        "VaultUri": "https://<your-key-vault-name>.vault.azure.net"
      },
      "Storage": {
        "ServiceUri": "https://<your-storage-account-name>.storage.windows.net"
      },
      "ServiceBus": {
        "Namespace": "<your_service-bus_namespace>.servicebus.windows.net"
      }
    }
    ```

    In the preceding JSON sample:

    - The top-level key names, `KeyVault`, `ServiceBus`, and `Storage`, are arbitrary names used to reference the config sections from your code. All other key names hold significance, and JSON serialization is performed in a case-insensitive manner.
    - The `KeyVault:VaultUri`, `ServiceBus:Namespace`, and `Storage:ServiceUri` key values map to the `Uri`- and `string`-typed arguments of the <xref:Azure.Security.KeyVault.Secrets.SecretClient.%23ctor(System.Uri,Azure.Core.TokenCredential,Azure.Security.KeyVault.Secrets.SecretClientOptions)?displayProperty=fullName>, <xref:Azure.Messaging.ServiceBus.ServiceBusClient.%23ctor(System.String)?displayProperty=fullName>, and <xref:Azure.Storage.Blobs.BlobServiceClient.%23ctor(System.Uri,Azure.Core.TokenCredential,Azure.Storage.Blobs.BlobClientOptions)?displayProperty=fullName> constructor overloads, respectively. The `TokenCredential` variants of the constructors are used because a default `TokenCredential` is set via the <xref:Microsoft.Extensions.Azure.AzureClientFactoryBuilder.UseCredential(Azure.Core.TokenCredential)?displayProperty=fullName> method call.

1. Retrieve the settings in the JSON configuration file using `IConfiguration` and pass them into your service registrations:

    ```csharp
    builder.Services.AddAzureClients(clientBuilder =>
    {
        clientBuilder.AddSecretClient(
            builder.Configuration.GetSection("KeyVault"));
    
        clientBuilder.AddBlobServiceClient(
            builder.Configuration.GetSection("Storage"));
    
        clientBuilder.AddServiceBusClientWithNamespace(
            builder.Configuration["ServiceBus:Namespace"]);
    
        clientBuilder.UseCredential(new DefaultAzureCredential());
    });
    ```

### Configure retries and Azure defaults

At some point, you may want to change default Azure client configurations globally or for a specific service client. For example, you may want different retry settings or to use a different service API version. You can set the retry settings globally or on a per-service basis.

1. Update your configuration file to set default Azure settings, such as a new default retry policy and a specific retry policy for Azure Key Vault:

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
    "VaultUri": "https://mykeyvault.vault.azure.net",
    "Retry": {
      "maxRetries": 10
    }
  }
}
```

2. Add a call to the `ConfigureDefaults` extension method in your `AddAzureClients` setup:

```csharp
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddSecretClient(
        builder.Configuration.GetSection("KeyVault"));

    clientBuilder.AddBlobServiceClient(
        builder.Configuration.GetSection("Storage"));

    clientBuilder.AddServiceBusClientWithNamespace(
        builder.Configuration["ServiceBus:Namespace"]);

    clientBuilder.UseCredential(new DefaultAzureCredential());

    // Set up any default settings
    clientBuilder.ConfigureDefaults(
        builder.Configuration.GetSection("AzureDefaults"));
});
```

## Configure logging

The Azure SDK for .NET client libraries can log client library operations to monitor requests and responses to Azure services. When you register an Azure SDK client using the <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClients%2A> extension method, the <xref:Microsoft.Extensions.Azure.AzureEventSourceLogForwarder> is registered with the dependency injection container. This service forwards log messages from Azure SDK event sources to <xref:Microsoft.Extensions.Logging.ILoggerFactory> to enables you to use the standard ASP.NET Core logging configuration for logging.

The following table depicts how the Azure SDK for .NET `EventLevel` maps to the ASP.NET Core `LogLevel`.

| Azure SDK `EventLevel` | ASP.NET Core `LogLevel` |
|------------------------|-------------------------|
| `Critical`             | `Critical`              |
| `Error`                | `Error`                 |
| `Informational`        | `Information`           |
| `Warning`              | `Warning`               |
| `Verbose`              | `Debug`                 |
| `LogAlways`            | `Information`           |

You can change default log levels and other settings using the same JSON configurations outlined in the [configure authentication](#configure-authentication) section. For example, toggle a the `ServiceBusClient` log level to `Debug` by setting the `Logging:LogLevel:Azure.Messaging.ServiceBus` key as follows:

```json
{
"Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning",
            "Azure.Messaging.ServiceBus": "Debug"
        }
    }
}
```
