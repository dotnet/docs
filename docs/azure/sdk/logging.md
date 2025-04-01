---
title: Logging with the Azure SDK for .NET
description: Learn how to enable logging with the Azure SDK for .NET client libraries
ms.date: 04/05/2024
ms.custom: devx-track-dotnet, engagement-fy23
ms.topic: how-to
---

# Logging with the Azure SDK for .NET

The Azure SDK for .NET's client libraries include the ability to log client library operations. This logging allows you to monitor I/O requests and responses that client libraries are making to Azure services. Typically, the logs are used to debug or diagnose communication issues. This article describes the following approaches to enable logging with the Azure SDK for .NET:

- [Enable logging with built-in methods](#enable-logging-with-built-in-methods)
- [Configure custom logging](#configure-custom-logging)
- [Map to ASP.NET Core logging](#map-to-aspnet-core-logging)

> [!IMPORTANT]
> This article applies to client libraries that use the most recent versions of the Azure SDK for .NET. To see if a library is supported, see the list of [Azure SDK latest releases](https://azure.github.io/azure-sdk/releases/latest/index.html#net). If your app is using an older version of an Azure SDK client library, refer to specific instructions in the applicable service documentation.

## Log information

The SDK logs each HTTP request and response, sanitizing parameter query and header values to remove personal data.

HTTP request log entry:

- Unique ID
- HTTP method
- URI
- Outgoing request headers

HTTP response log entry:

- Duration of I/O operation (time elapsed)
- Request ID
- HTTP status code
- HTTP reason phrase
- Response headers
- Error information, when applicable

HTTP request and response content:

- Content stream as text or bytes depending on the `Content-Type` header.

  > [!NOTE]
  > Content logging is disabled by default. To enable it, see [Log HTTP request and response bodies](#log-http-request-and-response-bodies). This capability applies only to libraries using HTTP to communicate with an Azure service. Libraries based on alternative protocols, such as AMQP, don't support content logging. Unsupported examples include libraries for Azure services such as Event Hubs, Service Bus, and Web PubSub.

Event logs are output usually at one of these three levels:

- Informational for request and response events
- Warning for errors
- Verbose for detailed messages and content logging

## Enable logging with built-in methods

The Azure SDK for .NET's client libraries log events to Event Tracing for Windows (ETW) via the <xref:System.Diagnostics.Tracing.EventSource?displayProperty=nameWithType> class, which is typical for .NET. Event sources allow you to use structured logging in your app with minimal performance overhead. To gain access to the event logs, you need to register event listeners.

The SDK includes the <xref:Azure.Core.Diagnostics.AzureEventSourceListener?displayProperty=nameWithType> class, which contains two static methods that simplify comprehensive logging for your .NET app: `CreateConsoleLogger` and `CreateTraceLogger`. Each of these methods accepts an optional parameter that specifies a log level. If the parameter isn't provided, the default log level of `Informational` is used.

### Log to the console window

A core tenet of the Azure SDK for .NET client libraries is to simplify the ability to view comprehensive logs in real time. The `CreateConsoleLogger` method allows you to send logs to the console window with a single line of code:

```csharp
using AzureEventSourceListener listener =
    AzureEventSourceListener.CreateConsoleLogger();
```

### Log to diagnostic traces

If you implement trace listeners, you can use the `CreateTraceLogger` method to log to the standard .NET event tracing mechanism (<xref:System.Diagnostics.Tracing?displayProperty=nameWithType>). For more information on event tracing in .NET, see [Trace Listeners](../../framework/debug-trace-profile/trace-listeners.md).

This example specifies a log level of verbose:

```csharp
using AzureEventSourceListener listener =
    AzureEventSourceListener.CreateTraceLogger(EventLevel.Verbose);
```

## Configure custom logging

As mentioned above, you need to register event listeners to receive log messages from the Azure SDK for .NET. If you don't want to implement comprehensive logging using one of the simplified methods above, you can construct an instance of the `AzureEventSourceListener` class. Pass that instance a callback method that you write. This method will receive log messages that you can process however you need to. In addition, when you construct the instance, you can specify the log levels to include.

The following example creates an event listener that logs to the console with a custom message. The logs are filtered to those events emitted from the Azure Core client library with a level of verbose. The Azure Core library uses an event source name of `Azure-Core`.

```csharp
using Azure.Core.Diagnostics;
using System.Diagnostics.Tracing;

// code omitted for brevity

using var listener = new AzureEventSourceListener((e, message) =>
    {
        // Only log messages from "Azure-Core" event source
        if (e.EventSource.Name == "Azure-Core")
        {
            Console.WriteLine($"{DateTime.Now} {message}");
        }
    },
    level: EventLevel.Verbose);
```

## Map to ASP.NET Core logging

The <xref:Microsoft.Extensions.Azure.AzureEventSourceLogForwarder> service enables you to use the standard ASP.NET Core logging configuration for logging. The service forwards log messages from Azure SDK event sources to <xref:Microsoft.Extensions.Logging.ILoggerFactory>.

The following table depicts how the Azure SDK for .NET `EventLevel` maps to the ASP.NET Core `LogLevel`.

| Azure SDK `EventLevel` | ASP.NET Core `LogLevel` |
|------------------------|-------------------------|
| `Critical`             | `Critical`              |
| `Error`                | `Error`                 |
| `Informational`        | `Information`           |
| `Warning`              | `Warning`               |
| `Verbose`              | `Debug`                 |
| `LogAlways`            | `Information`           |

### Logging with client registration

Using the Azure Service Bus library as an example, complete the following steps:

1. Install the [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) NuGet package:

    ```dotnetcli
    dotnet package add Microsoft.Extensions.Azure
    ```

1. In *Program.cs*, register the Azure SDK library's client via a call to the <xref:Microsoft.Extensions.Azure.AzureClientServiceCollectionExtensions.AddAzureClients%2A> extension method:

    ```csharp
    using Azure.Identity;
    using Microsoft.Extensions.Azure;

    // code omitted for brevity

    builder.Services.AddAzureClients(azureBuilder =>
    {
        azureBuilder.AddServiceBusClient(
            builder.Configuration.GetConnectionString("ServiceBus"));
        azureBuilder.UseCredential(new DefaultAzureCredential());
    });
    ```

    In the preceding sample, the `AddAzureClients` method:

    - Registers the following objects with the dependency injection (DI) container:
      - Log forwarder service
      - Azure Service Bus client
    - Sets the default token credential to be used for all registered clients.

1. In *appsettings.json*, change the Service Bus library's default log level. For example, toggle it to `Debug` by setting the `Logging:LogLevel:Azure.Messaging.ServiceBus` key as follows:

    :::code language="json" source="snippets/logging/appsettings.Development.json" highlight="9":::

    Since the `Logging:LogLevel:Azure.Messaging.ServiceBus` key is set to `Debug`, Service Bus client events up to `EventLevel.Verbose` will be logged.

### Logging without client registration

There are scenarios in which [registering an Azure SDK library's client with the DI container](dependency-injection.md#register-clients-and-subclients) is either impossible or unnecessary:

- The Azure SDK library doesn't include an `IServiceCollection` extension method to register a client in the DI container.
- Your app uses Azure extension libraries that depend on other Azure SDK libraries. Examples of such Azure extension libraries include:
  - [Azure Key Vault key encryptor for DataProtection](/dotnet/api/overview/azure/Extensions.AspNetCore.DataProtection.Keys-readme)
  - [Azure Key Vault secrets configuration provider](/dotnet/api/overview/azure/Extensions.AspNetCore.Configuration.Secrets-readme)
  - [Azure Blob Storage key store for DataProtection](/dotnet/api/overview/azure/Extensions.AspNetCore.DataProtection.Blobs-readme)

In these scenarios, complete the following steps:

1. Install the [Microsoft.Extensions.Azure](https://www.nuget.org/packages/Microsoft.Extensions.Azure) NuGet package:

    ```dotnetcli
    dotnet package add Microsoft.Extensions.Azure
    ```

1. In *Program.cs*, register the log forwarder service as a singleton in the DI container:

    :::code language="csharp" source="snippets/logging/Program.cs" id="RegisterServiceWithDI" highlight="8":::

1. Fetch the log forwarder service from the DI container and invoke its <xref:Microsoft.Extensions.Azure.AzureEventSourceLogForwarder.Start%2A> method. For example, using constructor injection in an ASP.NET Core Razor Pages page model class:

    :::code language="csharp" source="snippets/logging/Pages/Index.cshtml.cs" id="FetchServiceAndStart" highlight="6-7":::

1. In *appsettings.json*, change the Azure Core library's default log level. For example, toggle it to `Debug` by setting the `Logging:LogLevel:Azure.Core` key as follows:

    :::code language="json" source="snippets/logging/appsettings.json" highlight="6":::

    Since the `Logging:LogLevel:Azure.Core` key is set to `Debug`, Azure Core library events up to `EventLevel.Verbose` will be logged.

For more information, see [Logging in .NET Core and ASP.NET Core](/aspnet/core/fundamentals/logging/).

## Logging using Azure.Monitor.OpenTelemetry.AspNetCore

The [Azure Monitor OpenTelemetry distro](https://www.nuget.org/packages/Azure.Monitor.OpenTelemetry.AspNetCore), starting with version `1.2.0`, supports capturing logs coming from Azure client libraries. You can control logging using any of the configuration options discussed in [Logging in .NET Core and ASP.NET Core](/aspnet/core/fundamentals/logging/).

Using the Azure Service Bus library as an example, complete the following steps:

1. Install the [Azure.Monitor.OpenTelemetry.AspNetCore](https://www.nuget.org/packages/Azure.Monitor.OpenTelemetry.AspNetCore) NuGet package:

    ```dotnetcli
    dotnet package add Azure.Monitor.OpenTelemetry.AspNetCore
    ```

1. Create or register the library's client. The distro supports both cases.

   ```csharp
   await using var client = new ServiceBusClient("<connection_string>");
   ```

1. In *appsettings.json*, change the Service Bus library's default log level. For example, toggle it to `Debug` by setting the `Logging:LogLevel:Azure.Messaging.ServiceBus` key as follows:

    :::code language="json" source="snippets/logging/appsettings.Development.json" highlight="9":::

    Since the `Logging:LogLevel:Azure.Messaging.ServiceBus` key is set to `Debug`, Service Bus client events up to `EventLevel.Verbose` will be logged.

## Log HTTP request and response bodies

> [!NOTE]
> This capability applies only to libraries using HTTP to communicate with an Azure service. Libraries based on alternative protocols, such as AMQP, don't support content logging. Unsupported examples include libraries for Azure services such as Event Hubs, Service Bus, and Web PubSub.

When troubleshooting unexpected behavior with a client library, it's helpful to inspect the following items:

- The HTTP request body sent to the underlying Azure service's REST API.
- The HTTP response body received from the Azure service's REST API.

By default, logging of the aforementioned content is disabled. To enable logging of the HTTP request and response bodies, complete the following steps:

1. Set the client options object's <xref:Azure.Core.DiagnosticsOptions.IsLoggingContentEnabled%2A> property to `true`, and pass the options object to the client's constructor. For example, to log HTTP requests and responses for the Azure Key Vault Secrets library:

    ```csharp
    var clientOptions = new SecretClientOptions
    {
        Diagnostics =
        {
            IsLoggingContentEnabled = true,
        }
    };
    var client = new SecretClient(
        new Uri("https://<keyvaultname>.vault.azure.net/"),
        new DefaultAzureCredential(),
        clientOptions);
    ```

1. Use your preferred logging approach with an event/log level of verbose/debug or higher. Find your approach in the following table for specific instructions.

    |Approach |Instructions |
    |---------|-------------|
    |[Enable logging with built-in methods](#enable-logging-with-built-in-methods) |Pass `EventLevel.Verbose` or `EventLevel.LogAlways` to `AzureEventSourceListener.CreateConsoleLogger` or `AzureEventSourceListener.CreateTraceLogger` |
    |[Configure custom logging](#configure-custom-logging) |Set the `AzureEventSourceListener` class' `level` constructor parameter to `EventLevel.Verbose` or `EventLevel.LogAlways` |
    |[Map to ASP.NET Core logging](#map-to-aspnet-core-logging) |Add `"Azure.Core": "Debug"` to *appsettings.json* |

## Next steps

- [Enable diagnostics logging for apps in Azure App Service](/azure/app-service/troubleshoot-diagnostic-logs)
- Review [Azure security logging and auditing](/azure/security/fundamentals/log-audit) options
- Learn how to work with [Azure platform logs](/azure/azure-monitor/platform/platform-logs-overview)
- Read more about [.NET logging and tracing](../../core/diagnostics/logging-tracing.md)
