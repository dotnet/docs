---
title: Best practices for using the Azure SDK with ASP.NET Core
description: Provides guidance and an overview of best practices for using the Azure SDK with ASP.NET Core
ms.topic: conceptual
ms.custom: devx-track-dotnet
ms.date: 10/08/2024
---

# Azure SDK for .NET overview

The Azure SDK for .NET enables ASP.NET Core apps to integrate with many different Azure services. In this article, you'll learn best practices and the steps to properly implement the Azure SDK for .NET in your ASP.NET Core apps. You'll learn how to:

- Register services for dependency injection.
- Implement centralized, standardized configuration.
- Authenticate to Azure without using passwords or secrets.
- Configure common web app concerns such as logging and retries.
- Get started with additional topics such unit testing.

## Register service clients

The Azure SDK for .NET provides many service clients to connect your app to services such as Azure Blob Storage and Azure Key Vault. Register these services with the dependency container in the `Program.cs` file of your app to make them available to your app using Dependency Injection. The [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) library provides helper methods to properly register your services and handles various concerns for you, such as setting up logging, handling service lifetimes, and assisting with authentication credential management.

To register the services you need, complete the following steps.

1. Install the [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) package.

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
        // Register clients for each service
        clientBuilder.AddSecretClient(new Uri("<key_vault_url>"));
        clientBuilder.AddBlobServiceClient(new Uri("<storage_url>"));
        clientBuilder.AddServiceBusClientWithNamespace(
            "<your_namespace>.servicebus.windows.net");
        clientBuilder.UseCredential(new DefaultAzureCredential());
    
        // Register a subclient for each Service Bus Queue
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
    
    @foreach(var report in reports)
    {
        <p>@report.Name</p>
    }
    
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

## Set up service configurations

Azure service clients support configurations to change their default behaviors. You can define service client configurations directly in your code when you register a service. For example, in the [Register clients and subclients](#register-service-clients-and-subclients) section, you explicitly passed the Uri-typed variables to the client constructors. However, the recommended approach is to [store configurations in environment-dependent JSON files](/dotnet/core/extensions/configuration-providers#json-configuration-provider). For example, use an `appsettings.Development.json` file to store development environment settings and an `appsettings.Production.json` file to contain production environment settings. You can add any properties from the [`ClientOptions`](/dotnet/api/azure.core.clientoptions) class into the JSON file.

1. Update the `appsettings.<environment>.json` file in your app to match the following structure:

    ```json
    {
      "AzureDefaults": {
        "Diagnostics": {
          "IsTelemetryDisabled": false,
          "IsLoggingContentEnabled": true
        }
      },
      "KeyVault": {
        "VaultUri": "https://<your-key-vault-name>.vault.azure.net"
      },
      "ServiceBus": {
        "Namespace": "<your_service-bus_namespace>.servicebus.windows.net"
      },
      "Storage": {
        "ServiceUri": "https://<your-storage-account-name>.storage.windows.net"
      }
    }
    ```

    In the preceding JSON sample:

    - The top-level key names, `AzureDefaults`, `KeyVault`, `ServiceBus`, and `Storage`, are arbitrary. All other key names hold significance, and JSON serialization is performed in a case-insensitive manner.
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
    
        // Set up any default settings
        clientBuilder.ConfigureDefaults(
            builder.Configuration.GetSection("AzureDefaults"));
    });
    ```

### Configure retries and service defaults

At some point, you may want to change default Azure client configurations globally or for a specific service client. For example, you may want different retry settings or to use a different service API version. You can set the retry settings globally or on a per-service basis.

Update your configuration file to set a new default retry policy, as well as a specific retry policy for Azure Key Vault:

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

## Authenticate using Microsoft Entra ID

Microsoft Entra ID is the recommended approach to authorize requests to Azure services. Use the [Azure Identity client library]() to implement secretless connections to Azure services in your code. The Azure Identity client library provides tools such as `DefaultAzureCredential` to simplify configuring secure connections. `DefaultAzureCredential` supports multiple authentication methods and determines which method should be used at runtime. This approach enables your app to use different authentication methods in different environments (local vs. production) without implementing environment-specific code.

Some Azure services also allow you to authorize requests using secrets keys. However, this approach should be used with caution. Developers must be diligent to never expose the access key in an unsecure location. Anyone who has the access key is able to authorize requests against the service and data.

Consider the following service client registrations:

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

## Configure logging

The Azure SDK for .NET client libraries include the ability to log client library operations. This logging allows you to monitor requests and responses between services clients and Azure services. When you register the Azure SDK library's client via a call to the <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClients%2A> extension method, some logging configurations are handled for you.

```csharp
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

In the preceding sample, the `AddAzureClients` method:

- Registers the following objects with the dependency injection (DI) container:
  - Log forwarder service
  - Azure Service Bus client
- Sets the default token credential to be used for all registered clients.

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

## Unit testing considerations

Unit testing is an important part of a sustainable development process that can improve code quality and prevent regressions or bugs in your apps. This section provides a basic introduction to Unit Testing with the Azure SDK for .NET. Visit the [Unit testing and mocking with the Azure SDK for .NET](/dotnet/azure/sdk/unit-testing-mocking) article for a detailed exploration of these unit testing concepts.

Unit testing presents challenges when the code you're testing performs network calls, such as those made to Azure resources by Azure service clients. Tests that run against live services can experience issues, such as latency that slows down test execution, dependencies on code outside of the isolated test, and issues with managing service state and costs every time the test is run. Instead of testing against live Azure services, replace the service clients with mocked or in-memory implementations to avoid these issues.

Each of the Azure SDK clients follows [mocking guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-mocking) that allow their behavior to be overridden:

* Each client offers at least one protected constructor to allow inheritance for testing.
* All public client members are virtual to allow overriding.

To create a test service client, you can either use a mocking library or standard C# features such as inheritance. Mocking frameworks allow you to simplify the code that you must write to override member behavior. (These frameworks also have other useful features that are beyond the scope of this article.)

```csharp
KeyVaultSecret keyVaultSecret = SecretModelFactory.KeyVaultSecret(
    new SecretProperties("secret"), "secretValue");

Mock<SecretClient> clientMock = new Mock<SecretClient>();
clientMock.Setup(c => c.GetSecret(
        It.IsAny<string>(),
        It.IsAny<string>(),
        It.IsAny<CancellationToken>())
    )
    .Returns(Response.FromValue(keyVaultSecret, Mock.Of<Response>()));

clientMock.Setup(c => c.GetSecretAsync(
        It.IsAny<string>(),
        It.IsAny<string>(),
        It.IsAny<CancellationToken>())
    )
    .ReturnsAsync(Response.FromValue(keyVaultSecret, Mock.Of<Response>()));

SecretClient secretClient = clientMock.Object;
```
