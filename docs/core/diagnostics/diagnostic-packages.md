---
title: Diagnostic packages overview
description: An overview of the available diagnostic packages in .NET.
ms.date: 10/11/2023
ms.topic: overview
---

# Diagnostic packages overview

Available as a set of .NET Extensions, various diagnostic packages provide a set of APIs and tools that enable you to collect and analyze diagnostic information about your .NET applications. From summarizing exceptions, to determining resource utilization and monitoring, to exposing health checks, and providing probes for Kubernetes, the diagnostic packages provide a rich set of functionality that can be used to instrument your apps.

The following NuGet packages are available:

| NuGet package | Description |
|--|--|
| [📦 Microsoft.Extensions.Diagnostics.ExceptionSummarization](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.ExceptionSummarization) | Retrieves exception summary information. |
| [📦 Microsoft.Extensions.Diagnostics.ResourceMonitoring](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.ResourceMonitoring) | Measures processor and memory usage. |
| [📦 Microsoft.Extensions.Diagnostics.HealthChecks.Common](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.Common) | Health check implementations. |
| [📦 Microsoft.Extensions.Diagnostics.HealthChecks.ResourceUtilization](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.ResourceUtilization) | Resource utilization health checks. |
| [📦 Microsoft.Extensions.Diagnostics.Probes](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Probes) | Provides support for environmental probes. |

## Exception summarization

When you're trying to generate meaningful diagnostic messages for exceptions, maintaining the inclusion of pertinent information can pose a challenge. The standard exception message often lacks critical details that accompany the exception, while invoking the <xref:System.Exception.ToString%2A?displayProperty=nameWithType> method yields an excess of state information.

The `IExceptionSummarizer` class offers methods for extracting crucial details from recognized exception types, thereby furnishing a singular `string` that serves as the foundation for crafting top-quality diagnostic messages.

The `IExceptionSummarizer.Summarize` method systematically traverses the roster of registered summarizers until it identifies a summarizer capable of handling the specific exception type. In the event that no summarizer is capable of recognizing the exception type, a meaningful default exception summary is provided instead.

### Example exception summarization usage

The following example demonstrates how to use the `IExceptionSummarizer` interface to retrieve a summary of an exception.

<!-- :::code source="snippets/exception-summary/Program.cs"::: -->

```csharp
using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.ExceptionSummarization;

// Add exception summarization services.
var services = new ServiceCollection()
    .AddExceptionSummarizer(static builder => builder.AddHttpProvider());

var provider = services.BuildServiceProvider();

// Get the exception summarizer.
var summarizer = provider.GetRequiredService<IExceptionSummarizer>();

foreach (var exception in new Exception[]
    {
        new OperationCanceledException("Operation cancelled..."),
        new TaskCanceledException("Task cancelled..."),
        new SocketException(10_024, "Too many sockets open..."),
        new WebException("Keep alive failure...",
            WebExceptionStatus.KeepAliveFailure)
    })
{
    // Summarize the exception.
    var summary = summarizer.Summarize(exception);

    Console.WriteLine(summary);
}

Console.ReadLine();

// Sample output:
//   OperationCanceledException:TaskTimeout:Unknown
//   TaskCanceledException:TaskTimeout:Unknown
//   SocketException:TooManyOpenSockets:Unknown
//   WebException:KeepAliveFailure:Unknown
```

The preceding code:

- Instantiates a new `ServiceCollection` instance, chaining a call to the `AddExceptionSummarizer` extension method.
  - The `AddExceptionSummarizer` extension method accepts a delegate that is used to configure the `ExceptionSummarizerBuilder` instance.
  - The `builder` is used to add the HTTP provider, which handles exceptions of type:
    - <xref:System.OperationCanceledException>
    - <xref:System.Threading.Tasks.TaskCanceledException>
    - <xref:System.Net.Sockets.SocketException>
    - <xref:System.Net.WebException>
- Builds a new `ServiceProvider` instance from the `ServiceCollection` instance.
- Gets an instance of the `IExceptionSummarizer` interface from the `ServiceProvider` instance.
- Iterates over a collection of exceptions, calling the `Summarize` method on each exception and displaying the result.

## Resource monitoring

Resource monitoring involves the continuous measurement of resource utilization over a specified period. The [Microsoft.Extensions.Diagnostics.ResourceMonitoring](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.ResourceMonitoring) NuGet package offers a collection of APIs tailored for monitoring the resource utilization of your .NET applications.

The `IResourceMonitor` interface furnishes methods for retrieving real-time information concerning process resource utilization. This interface supports the retrieval of data related to CPU and memory usage and is currently compatible with both Windows and Linux platforms.

### Example resource monitoring usage

The following example demonstrates how to use the `IResourceMonitor` interface to retrieve information about the current process's CPU and memory usage.

:::code source="snippets/resource-monitoring/Program.cs":::

The preceding code:

- Instantiates a new `ServiceCollection` instance, chaining calls to the `AddLogging` and `AddResourceMonitoring` extension methods.
- Builds a new `ServiceProvider` instance from the `ServiceCollection` instance.
- Gets an instance of the `IResourceMonitor` interface from the `ServiceProvider` instance.
- Creates a cancellation token source and a cancellation token.
- Creates a new `Table` instance, configuring it with a title, caption, and columns.
- Performs a live render of the `Table` instance, passing in a delegate that will be invoked every three seconds.
- Gets the current resource utilization information from the `IResourceMonitor` instance and displays it as a new row in the `Table` instance.

> [!IMPORTANT]
> The `Microsoft.Extensions.Diagnostics.ResourceMonitoring` package assumes that the consumer will register logging providers with the `Microsoft.Extensions.Logging` package. If you don't register logging, the call to `AddResourceMonitoring` will throw an exception.

## Health checks

<https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.Common>

<https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.ResourceUtilization>

## Kubernetes probes

<https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Probes>
