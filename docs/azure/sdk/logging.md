---
title: Logging with the Azure SDK for .NET
description: Learn how to enable logging with the Azure SDK for .NET client libraries
ms.date: 03/20/2020
ms.custom: devx-track-dotnet
ms.author: casoper
author: camsoper
---

# Logging with the Azure SDK for .NET

The [Azure SDK](https://azure.microsoft.com/downloads/) for .NET client libraries includes the ability to log client library operations. This allows you to monitor I/O requests and responses that client libraries are making to Azure services. Typically, the logs are used to debug or diagnose communication issues. This article describes four approaches to enable logging with the Azure SDK for .NET:

- Log to the console window
- Log to .NET diagnostics traces
- Configure custom logging
- ASP.NET Core logging

> [!IMPORTANT]
> This article applies to client libraries that use the most recent versions of the Azure SDK for .NET. To see if a library is supported, refer to the list of [Azure SDK latest releases](https://azure.github.io/azure-sdk/releases/latest/index.html). If your application is using an older version of the Azure SDK client libraries, refer to specific instructions in the applicable service documentation.

## Log information

The SDK logs the following information, sanitizing parameter query and header values to remove personal data.

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

For request and response content:

- Content stream as text or bytes depending on the Content-Type header.
     > [!NOTE]
     > Content logging is disabled by default. To enable it, set `Diagnostics.IsLoggingContentEnabled` to `true` in `ClientOptions`.

Event logs are output usually at one of these three levels:

- Informational for request and response events
- Warning for errors
- Verbose for detailed messages and content logging

## Enable logging with built-in methods

The Azure SDK for .NET client libraries logs events to Event Tracing for Windows (ETW) via the [`EventSource` class](/dotnet/api/system.diagnostics.tracing.eventsource), which is typical for .NET. Event sources allow you to use structured logging in your application code with a minimal performance overhead. To gain access to these event logs, you need to register event listeners.

The SDK includes the `Azure.Core.Diagnostics.AzureEventSourceListener` class (defined in the Azure.Core NuGet package), which contains two static methods that simplify comprehensive logging for your .NET application: `CreateConsoleLogger` and `CreateTraceLogger`. These methods take an optional parameter that specifies a log level.

### Log to the console window

A core tenet of the Azure SDK for .NET client libraries is to simplify the ability to view comprehensive logs in real time. The `CreateConsoleLogger` method allows you to send logs to the console window with a single line of code:

```csharp
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

### Log to diagnostic traces

If you implement trace listeners, you can use the `CreateTraceLogger` method to log to the standard .NET event tracing mechanism ([`System.Diagnostics.Tracing`](/dotnet/api/system.diagnostics.tracing)). For more information on event tracing in .NET, see [Trace Listeners](../../framework/debug-trace-profile/trace-listeners.md). This example specifies a log level of verbose:

```csharp
using AzureEventSourceListener listener = AzureEventSourceListener.CreateTraceLogger(EventLevel.Verbose);
```

## Configure custom logging

As mentioned above, you need to register event listeners to receive log messages from the Azure SDK for .NET. If you don’t want to implement comprehensive logging using one the simplified methods above, you can construct an instance of the `AzureEventSourceListener` class and pass it a callback function that you write. This method will receive log messages that you can process however you need to. In addition, when you construct the instance, you can specify the log levels to include.

The following example creates an event listener that logs to the console with a custom message, and is filtered to Azure core events of the level verbose.

```csharp
using AzureEventSourceListener listener = new AzureEventSourceListener((e, message) =>
    {
        // Only log messages from Azure-Core event source
        if (e.EventSource.Name == "Azure-Core")
        {
            Console.WriteLine($"{DateTime.Now} {message}");
        }
    },
    level: EventLevel.Verbose);
```

## ASP.NET Core logging

Using the `AddAzureClients` extension method registers a `AzureEventSourceLogForwarder` service. The `AzureEventSourceLogForwarder` service enables you to use the standard ASP.NET logging configuration for logging.

The following table depicts how Azure SDK for .NET log levels map to ASP.NET log levels.

| Azure SDK `EventLevel` | ASP.NET `LogLevel` |
|------------------------|--------------------|
| `Critical`             | `Critical`         |
| `Error`                | `Error`            |
| `Informational`        | `Information`      |
| `Verbose`              | `Debug`            |
| `Warning`              | `Warning`          |
| `LogAlways`            | `Information`      |

## Next steps

- [Enable diagnostics logging for apps in Azure App Service](/azure/app-service/troubleshoot-diagnostic-logs)
- Review [Azure security logging and auditing](/azure/security/fundamentals/log-audit) options
- Learn how to work with [Azure platform logs](/azure/azure-monitor/platform/platform-logs-overview)
- Read more about [.NET Core logging and tracing](../../core/diagnostics/logging-tracing.md)
