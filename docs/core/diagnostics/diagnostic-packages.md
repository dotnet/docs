---
title: Diagnostic packages overview
description: An overview of the available diagnostic packages in .NET.
ms.date: 10/12/2023
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

The <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.IExceptionSummarizer> interface offers methods for extracting crucial details from recognized exception types, thereby furnishing a singular `string` that serves as the foundation for crafting top-quality diagnostic messages.

The <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.IExceptionSummarizer.Summarize%2A?displayProperty=nameWithType> method systematically traverses the roster of registered summarizers until it identifies a summarizer capable of handling the specific exception type. In the event that no summarizer is capable of recognizing the exception type, a meaningful default exception summary is provided instead.

### Example exception summarization usage

The following example demonstrates how to use the `IExceptionSummarizer` interface to retrieve a summary of an exception.

:::code source="snippets/exception-summary/Program.cs":::

The preceding code:

- Instantiates a new <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection> instance, chaining a call to the <xref:Microsoft.Extensions.Diagnostics.ExceptionSummarization.ExceptionSummarizationExtensions.AddExceptionSummarizer%2A> extension method.
  - The `AddExceptionSummarizer` extension method accepts a delegate that is used to configure the `ExceptionSummarizerBuilder` instance.
  - The `builder` is used to add the HTTP provider, which handles exceptions of type:
    - <xref:System.OperationCanceledException>
    - <xref:System.Threading.Tasks.TaskCanceledException>
    - <xref:System.Net.Sockets.SocketException>
    - <xref:System.Net.WebException>
- Builds a new `ServiceProvider` instance from the `ServiceCollection` instance.
- Gets an instance of the `IExceptionSummarizer` interface from the `ServiceProvider` instance.
- Iterates over a collection of exceptions, calling the `Summarize` method on each exception and displaying the result.

> [!WARNING]
> The primary focus in the design of all exception summarization implementations is to provide diagnostic convenience to trusted users, rather than prioritizing the protection of personally identifiable information (PII).

## Resource monitoring

Resource monitoring involves the continuous measurement of resource utilization over a specified period. The [Microsoft.Extensions.Diagnostics.ResourceMonitoring](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.ResourceMonitoring) NuGet package offers a collection of APIs tailored for monitoring the resource utilization of your .NET applications.

The <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface furnishes methods for retrieving real-time information concerning process resource utilization. This interface supports the retrieval of data related to CPU and memory usage and is currently compatible with both Windows and Linux platforms.

### Example resource monitoring usage

The following example demonstrates how to use the `IResourceMonitor` interface to retrieve information about the current process's CPU and memory usage.

:::code source="snippets/resource-monitoring/Program.cs" id="setup":::

The preceding code:

- Instantiates a new `ServiceCollection` instance, chaining calls to the <xref:Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions.AddLogging%2A> and <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceMonitoringExtensions.AddResourceMonitoring%2A> extension methods.
- Builds a new `ServiceProvider` instance from the `ServiceCollection` instance.
- Gets an instance of the `IResourceMonitor` interface from the `ServiceProvider` instance.

> [!IMPORTANT]
> The <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring?displayProperty=fullName> package assumes that the consumer will register logging providers with the `Microsoft.Extensions.Logging` package. If you don't register logging, the call to `AddResourceMonitoring` will throw an exception.

At this point, with the `IResourceMonitor` implementation you'll ask for resource utilization with the <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor.GetUtilization%2A?displayProperty=nameWithType> method. The `GetUtilization` method returns a <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization> instance that contains the following information:

- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.CpuUsedPercentage>: CPU usage as a percentage.
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.MemoryUsedPercentage>: Memory usage as a percentage.
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.MemoryUsedInBytes>: Memory usage in bytes.
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.SystemResources?displayProperty=nameWithType>: System resources.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.GuaranteedMemoryInBytes?displayProperty=nameWithType>: Guaranteed memory in bytes.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.MaximumMemoryInBytes?displayProperty=nameWithType>: Maximum memory in bytes.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.GuaranteedCpuUnits?displayProperty=nameWithType>: Guaranteed CPU in units.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.MaximumCpuUnits?displayProperty=nameWithType>: Maximum CPU in units.

Extending this example, you can leverage [Spectre.Console](https://www.nuget.org/packages/Spectre.Console), a well-regarded .NET library designed to simplify the development of visually appealing, cross-platform console applications. With Spectre, you'll be able to present resource utilization data in a tabular format. The following code illustrates the usage of the `IResourceMonitor` interface to access details regarding the CPU and memory usage of the current process, then presenting this data in a table:

:::code source="snippets/resource-monitoring/Program.cs" id="monitor":::

The preceding code:

- Creates a cancellation token source and a cancellation token.
- Creates a new `Table` instance, configuring it with a title, caption, and columns.
- Performs a live render of the `Table` instance, passing in a delegate that will be invoked every three seconds.
- Gets the current resource utilization information from the `IResourceMonitor` instance and displays it as a new row in the `Table` instance.

The following is an example of the output from the preceding code:

:::code source="snippets/resource-monitoring/Program.cs" id="output":::

## Health checks

<https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.Common>

<https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.ResourceUtilization>

## Kubernetes probes

<https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Probes>
