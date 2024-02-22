---
title: Diagnostic resource monitoring
description: Learn how to use the diagnostic resource monitoring library in .NET.
ms.date: 11/29/2023
---

# Resource monitoring

Resource monitoring involves the continuous measurement of resource utilization over a specified period. The [Microsoft.Extensions.Diagnostics.ResourceMonitoring](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.ResourceMonitoring) NuGet package offers a collection of APIs tailored for monitoring the resource utilization of your .NET applications.

The <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface furnishes methods for retrieving real-time information concerning process resource utilization. This interface supports the retrieval of data related to CPU and memory usage and is currently compatible with both Windows and Linux platforms. All resource monitoring diagnostic information is published to OpenTelemetry by default, so there's no need to manually publish this yourself.

In addition, the resource monitoring library reports various diagnostic metrics. For more information, see [Diagnostic Metrics: `Microsoft.Extensions.Diagnostics.ResourceMonitoring`](built-in-metrics-diagnostics.md#microsoftextensionsdiagnosticsresourcemonitoring).

## Example resource monitoring usage

The following example demonstrates how to use the `IResourceMonitor` interface to retrieve information about the current process's CPU and memory usage.

:::code source="snippets/resource-monitoring/Program.cs" id="setup":::

The preceding code:

- Instantiates a new <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection> instance, chaining calls to the <xref:Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions.AddLogging%2A> and <xref:Microsoft.Extensions.DependencyInjection.ResourceMonitoringServiceCollectionExtensions.AddResourceMonitoring%2A> extension methods.
- Builds a new <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider> instance from the `ServiceCollection` instance.
- Gets an instance of the <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface from the `ServiceProvider` instance.

> [!IMPORTANT]
> The <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring?displayProperty=fullName> package assumes that the consumer will register logging providers with the `Microsoft.Extensions.Logging` package. If you don't register logging, the call to `AddResourceMonitoring` will throw an exception.

At this point, with the `IResourceMonitor` implementation you'll ask for resource utilization with the <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor.GetUtilization%2A?displayProperty=nameWithType> method. The `GetUtilization` method returns a <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization> instance that contains the following information:

- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.CpuUsedPercentage?displayProperty=nameWithType>: CPU usage as a percentage.
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.MemoryUsedPercentage?displayProperty=nameWithType>: Memory usage as a percentage.
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.MemoryUsedInBytes?displayProperty=nameWithType>: Memory usage in bytes.
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.SystemResources?displayProperty=nameWithType>: System resources.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.GuaranteedMemoryInBytes?displayProperty=nameWithType>: Guaranteed memory in bytes.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.MaximumMemoryInBytes?displayProperty=nameWithType>: Maximum memory in bytes.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.GuaranteedCpuUnits?displayProperty=nameWithType>: Guaranteed CPU in units.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.MaximumCpuUnits?displayProperty=nameWithType>: Maximum CPU in units.

## Extend resource monitoring with Spectre.Console

Extending this example, you can leverage [Spectre.Console](https://www.nuget.org/packages/Spectre.Console), a well-regarded .NET library designed to simplify the development of visually appealing, cross-platform console applications. With Spectre, you'll be able to present resource utilization data in a tabular format. The following code illustrates the usage of the `IResourceMonitor` interface to access details regarding the CPU and memory usage of the current process, then presenting this data in a table:

:::code source="snippets/resource-monitoring/Program.cs" id="monitor" highlight="27-28,33-37":::

The preceding code:

- Creates a cancellation token source and a cancellation token.
- Creates a new `Table` instance, configuring it with a title, caption, and columns.
- Performs a live render of the `Table` instance, passing in a delegate that will be invoked every three seconds.
- Gets the current resource utilization information from the `IResourceMonitor` instance and displays it as a new row in the `Table` instance.

The following is an example of the output from the preceding code:

:::image type="content" source="media/resource-monitoring-output.png" lightbox="media/resource-monitoring-output.png" alt-text="Example Resource Monitoring app output.":::

For the source code of this example, see the [Resource monitoring sample](https://github.com/dotnet/docs/tree/main/docs/core/diagnostics/snippets/resource-monitoring).

## Kubernetes probes

In addition to resource monitoring, apps that exist within a Kubernetes cluster report their health through diagnostic probes. The [Microsoft.Extensions.Diagnostics.Probes](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Probes) NuGet package provides support for Kubernetes probes. It externalizes various [health checks](diagnostic-health-checks.md) that align with various Kubernetes probes, for example:

- Liveness
- Readiness
- Startup

The library communicates the apps current health to a Kubernetes hosting environment. If a process reports as being unhealthy, Kubernetes doesn't send it any traffic, providing the process time to recover or terminate.

To add support for Kubernetes probes, add a package reference to [Microsoft.Extensions.Diagnostics.Probes](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Probes). On an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> instance, call <xref:Microsoft.Extensions.DependencyInjection.KubernetesProbesExtensions.AddKubernetesProbes%2A>.

## See also

- [.NET extensions metrics](built-in-metrics-diagnostics.md)
