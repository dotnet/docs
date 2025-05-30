---
title: Best practices for using the Azure SDK with ASP.NET Core
description: Learn best practices and the steps to properly implement the Azure SDK for .NET in your ASP.NET Core apps.
ms.topic: concept-article
ms.custom: devx-track-dotnet
ms.date: 10/22/2024
---

# Use the Azure SDK for .NET in ASP.NET Core apps

The Azure SDK for .NET enables ASP.NET Core apps to integrate with many different Azure services. In this article, you'll learn best practices and the steps to adopt the Azure SDK for .NET in your ASP.NET Core apps. You'll learn how to:

- Register services for dependency injection.
- Authenticate to Azure without using passwords or secrets.
- Implement centralized, standardized configuration.
- Configure common web app concerns such as logging and retries.

## Explore common Azure SDK client libraries

ASP.NET Core apps that connect to Azure services generally depend on the following Azure SDK client libraries:

- [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) provides helper methods to register clients with the dependency injection service collection and handles various concerns for you, such as setting up logging, handling DI service lifetimes, and authentication credential management.
- [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) enables Microsoft Entra ID authentication support across the Azure SDK. It provides a set of [TokenCredential](/dotnet/api/azure.core.tokencredential?view=azure-dotnet) implementations to construct Azure SDK clients that support Microsoft Entra authentication.
- `Azure.<service-namespace>` libraries, such as [Azure.Storage.Blobs](https://www.nuget.org/packages/Azure.Storage.Blobs) and [Azure.Messaging.ServiceBus](https://www.nuget.org/packages/Azure.Messaging.ServiceBus), provide service clients and other types to help you connect to and consume specific Azure services. For a complete inventory of these libraries, see [Libraries using Azure.Core](packages.md#libraries-using-azurecore).

In the sections ahead, you'll explore how to implement an ASP.NET Core application that uses these libraries.

## Register Azure SDK clients with the DI service collection

The Azure SDK for .NET client libraries provide service clients to connect your app to Azure services such as Azure Blob Storage and Azure Key Vault. Register these services with the dependency container in the `Program.cs` file of your app to make them available via [dependency injection](/aspnet/core/fundamentals/dependency-injection).

Complete the following steps to register the services you need:

1. Add the [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) package:

    ```dotnetcli
    dotnet add package Microsoft.Extensions.Azure
    ```

2. Add the relevant `Azure.*` service client packages:

    ```dotnetcli
    dotnet add package Azure.Security.KeyVault.Secrets
    dotnet add package Azure.Storage.Blobs
    dotnet add package Azure.Messaging.ServiceBus
    ```

3. In the `Program.cs` file of your app, invoke the <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClients%2A> extension method from the `Microsoft.Extensions.Azure` library to register a client to communicate with each Azure service. Some client libraries provide additional [subclients](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-subclients) for specific subgroups of Azure service functionality. You can register such subclients for dependency injection via the <xref:Microsoft.Extensions.Azure.AzureClientFactoryBuilder.AddClient%2A> extension method.

    :::code language="csharp" source="snippets/aspnetcore-guidance/BlazorSample/Program.cs" range="11-30" highlight="4-7,13-15":::

4. Inject the registered clients into your ASP.NET Core app components, services, or API endpoint:

    <!-- markdownlint-disable MD023 -->
    ## [Minimal API](#tab/api)

    :::code language="csharp" source="snippets/aspnetcore-guidance/MinApiSample/Program.cs" range="52-73" highlight="1-3,6,8,11-12":::

    <!-- markdownlint-disable MD023 -->
    ## [Blazor](#tab/blazor)

    :::code language="razor" source="snippets/aspnetcore-guidance/BlazorSample/Components/Pages/Home.razor" range="1-28" highlight="19-28":::

    ---

For more information, see [Dependency injection with the Azure SDK for .NET](dependency-injection.md).

## Authenticate using Microsoft Entra ID

Token-based authentication with [Microsoft Entra ID](/entra/fundamentals/whatis) is the recommended approach to authenticate requests to Azure services. To authorize those requests, [Azure role-based access control (RBAC)](/azure/role-based-access-control/overview) manages access to Azure resources based on a user's Microsoft Entra identity and assigned roles.

Use the [Azure Identity](/dotnet/api/overview/azure/identity-readme) library for the aforementioned token-based authentication support. The library provides classes such as [`DefaultAzureCredential`](/dotnet/api/azure.identity.defaultazurecredential) to simplify configuring secure connections. `DefaultAzureCredential` supports multiple authentication methods and determines which method should be used at runtime. This approach enables your app to use different authentication methods in different environments (local vs. production) without implementing environment-specific code. Visit the [Authentication](/dotnet/azure/sdk/authentication) section of the Azure SDK for .NET docs for more details on these topics.

> [!NOTE]
> Many Azure services also allow you to authorize requests using keys. However, this approach should be used with caution. Developers must be diligent to never expose the access key in an unsecure location. Anyone who has the access key can authorize requests against the associated Azure resource.

1. Add the [Azure.Identity](https://www.nuget.org/packages/Azure.Identity) package:

    ```dotnetcli
    dotnet add package Azure.Identity
    ```

1. In the `Program.cs` file of your app, invoke the <xref:Microsoft.Extensions.Azure.AzureClientFactoryBuilder.UseCredential%2A> extension method from the `Microsoft.Extensions.Azure` library to set a shared `DefaultAzureCredential` instance for all registered Azure service clients:

    :::code language="csharp" source="snippets/aspnetcore-guidance/BlazorSample/Program.cs" range="11-30" highlight="19":::

    `DefaultAzureCredential` discovers available credentials in the current environment and uses them to authenticate to Azure services. For the order and locations in which `DefaultAzureCredential` scans for credentials, see [DefaultAzureCredential overview](/dotnet/azure/sdk/authentication/credential-chains?tabs=dac#defaultazurecredential-overview). Using a shared `DefaultAzureCredential` instance ensures the underlying token cache is used, which improves application resilience and performance due to fewer requests for a new token.

## Apply configurations

Azure SDK service clients support configurations to change their default behaviors. There are two ways to configure service clients:

- [JSON configuration files](../../core/extensions/configuration-providers.md#json-configuration-provider) are generally the recommended approach because they simplify managing differences in app deployments between environments.
- Inline code configurations can be applied when you register the service client. For example, in the [Register clients and subclients](#register-azure-sdk-clients-with-the-di-service-collection) section, you explicitly passed the URI variables to the client constructors.

`IConfiguration` precedence rules are respected by the `Microsoft.Extensions.Azure` extension methods, which are detailed in the [Configuration Providers](../../core/extensions/configuration.md#configuration-providers) documentation.

Complete the steps in the following sections to update your app to use JSON file configuration for the appropriate environments. Use the `appsettings.Development.json` file for development settings and the `appsettings.Production.json` file for production environment settings. You can add configuration settings whose names are public properties on the <xref:Azure.Core.ClientOptions> class to the JSON file.

### Configure registered services

1. Update the `appsettings.<environment>.json` file in your app with the highlighted service configurations:

    :::code language="json" source="snippets/aspnetcore-guidance/MinApiSample/appsettings.Development.json" highlight="19-27":::

    In the preceding JSON sample:

    - The top-level key names, `KeyVault`, `ServiceBus`, and `Storage`, are arbitrary names used to reference the config sections from your code.  You will pass these names to `AddClient` extension methods to configure a given client. All other key names map to specific client options, and JSON serialization is performed in a case-insensitive manner.
    - The `KeyVault:VaultUri`, `ServiceBus:Namespace`, and `Storage:ServiceUri` key values map to the arguments of the <xref:Azure.Security.KeyVault.Secrets.SecretClient.%23ctor(System.Uri,Azure.Core.TokenCredential,Azure.Security.KeyVault.Secrets.SecretClientOptions)?displayProperty=name>, <xref:Azure.Messaging.ServiceBus.ServiceBusClient.%23ctor(System.String)?displayProperty=name>, and <xref:Azure.Storage.Blobs.BlobServiceClient.%23ctor(System.Uri,Azure.Core.TokenCredential,Azure.Storage.Blobs.BlobClientOptions)?displayProperty=name> constructor overloads, respectively. The `TokenCredential` variants of the constructors are used because a default `TokenCredential` is set via the <xref:Microsoft.Extensions.Azure.AzureClientFactoryBuilder.UseCredential(Azure.Core.TokenCredential)?displayProperty=name> method call.

1. Update the the `Program.cs` file to retrieve the JSON file configurations using `IConfiguration` and pass them into your service registrations:

    :::code language="csharp" source="snippets/aspnetcore-guidance/MinApiSample/Program.cs" range="14-25" highlight="4-5,7-8,11-12":::

### Configure Azure defaults and retries

You may want to change default Azure client configurations globally or for a specific service client. For example, you may want different retry settings or to use a different service API version. You can set the retry settings globally or on a per-service basis.

1. Update your configuration file to set default Azure settings, such as a new default retry policy that all registered Azure clients will use:

    :::code language="json" source="snippets/aspnetcore-guidance/MinApiSample/appsettings.Development.json" highlight="9-18":::

2. In the `Program.cs` file, call the `ConfigureDefaults` extension method to retrieve the default settings and apply them to your service clients:

    :::code language="csharp" source="snippets/aspnetcore-guidance/MinApiSample/Program.cs" range="14-41" highlight="26-27":::

## Configure logging

The Azure SDK for .NET client libraries can log client library operations to monitor requests and responses to Azure services. Client libraries can also log a variety of other events, including retries, token retrieval, and service-specific events from various clients. When you register an Azure SDK client using the <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClients%2A> extension method, the <xref:Microsoft.Extensions.Azure.AzureEventSourceLogForwarder> is registered with the dependency injection container. The `AzureEventSourceLogForwarder` forwards log messages from Azure SDK event sources to <xref:Microsoft.Extensions.Logging.ILoggerFactory> to enables you to use the standard ASP.NET Core logging configuration for logging.

The following table depicts how the Azure SDK for .NET `EventLevel` maps to the ASP.NET Core `LogLevel`. For more information on these topics and other scenarios, see [Logging with the Azure SDK for .NET](logging.md) and [Dependency injection with the Azure SDK for .NET](dependency-injection.md).

| Azure SDK `EventLevel` | ASP.NET Core `LogLevel` |
|------------------------|-------------------------|
| `Critical`             | `Critical`              |
| `Error`                | `Error`                 |
| `Informational`        | `Information`           |
| `Warning`              | `Warning`               |
| `Verbose`              | `Debug`                 |
| `LogAlways`            | `Information`           |

You can change default log levels and other settings using the same JSON configurations outlined in the [configure authentication](#authenticate-using-microsoft-entra-id) section. For example, toggle the `ServiceBusClient` log level to `Debug` by setting the `Logging:LogLevel:Azure.Messaging.ServiceBus` key as follows:

:::code language="json" source="snippets/aspnetcore-guidance/MinApiSample/appsettings.Development.json" highlight="6":::
