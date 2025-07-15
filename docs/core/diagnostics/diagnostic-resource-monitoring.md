---
title: Diagnostic resource monitoring
description: Learn how to use the diagnostic resource monitoring library in .NET.
ms.date: 07/09/2025
---

# Resource monitoring

Resource monitoring involves the continuous measurement of resource utilization values, such as CPU, memory, and network usage. The [Microsoft.Extensions.Diagnostics.ResourceMonitoring](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.ResourceMonitoring) NuGet package offers a collection of APIs tailored for monitoring the resource utilization of your .NET applications.

The measurements can be consumed in two ways:

- Using [.NET metrics](metrics.md).
- Using the <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface. This interface is deprecated, so use the metrics-based approach instead. If you still need to listen to metric values manually, see [Migrate to metrics-based resource monitoring](#migrate-to-metrics-based-resource-monitoring).

> [!IMPORTANT]
> The <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring?displayProperty=fullName> package assumes that the consumer will register logging providers with the `Microsoft.Extensions.Logging` package. If you don't register logging, the call to `AddResourceMonitoring` will throw an exception. Furthermore, you can enable internal library logging by configuring the [`Debug`](xref:Microsoft.Extensions.Logging.LogLevel.Debug) log level for the `Microsoft.Extensions.Diagnostics.ResourceMonitoring` category as per the [guide](../extensions/logging.md#log-category).

## Use .NET metrics of resource monitoring

To consume .NET metrics produced by the Resource monitoring library:

1. Add the `Microsoft.Extensions.Diagnostics.ResourceMonitoring` package to your project.
1. Add the resource monitoring services to your dependency injection container:

   ```csharp
   services.AddResourceMonitoring();
   ```

1. Configure metrics collection using any OpenTelemetry-compatible metrics collector. For example:

   ```csharp
   services.AddOpenTelemetry()
       .WithMetrics(builder =>
       {
           builder.AddMeter("Microsoft.Extensions.Diagnostics.ResourceMonitoring");
           builder.AddConsoleExporter(); // Or any other metrics exporter
       });
   ```

1. Now you can observe the resource usage metrics through your configured metrics exporter.

For information about available metrics, see [.NET extensions metrics: Microsoft.Extensions.Diagnostics.ResourceMonitoring](built-in-metrics-diagnostics.md#microsoftextensionsdiagnosticsresourcemonitoring).

For information about metrics collection, see [Metrics collection](metrics-collection.md).

## Use the `IResourceMonitor` interface

> [!CAUTION]
> The <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface described in this section is deprecated and might be removed in future versions of .NET. [Migrate to the metrics-based approach](#migrate-to-metrics-based-resource-monitoring).

The <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface furnishes methods for retrieving real-time information concerning process resource utilization. This interface supports the retrieval of data related to CPU and memory usage and is currently compatible with both Windows and Linux platforms.

### Example resource monitoring usage

The following example demonstrates how to use the `IResourceMonitor` interface to retrieve information about the current process's CPU and memory usage.

:::code source="snippets/resource-monitoring/Program.cs" id="setup":::

The preceding code:

- Instantiates a new <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection> instance, chaining calls to the <xref:Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions.AddLogging%2A> and <xref:Microsoft.Extensions.DependencyInjection.ResourceMonitoringServiceCollectionExtensions.AddResourceMonitoring%2A> extension methods.
- Builds a new <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider> instance from the `ServiceCollection` instance.
- Gets an instance of the <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface from the `ServiceProvider` instance.

At this point, with the `IResourceMonitor` implementation you'll ask for resource utilization with the <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor.GetUtilization%2A?displayProperty=nameWithType> method. The `GetUtilization` method returns a <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization> instance that contains the following information:

- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.CpuUsedPercentage?displayProperty=nameWithType>: CPU usage as a percentage.
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.MemoryUsedPercentage?displayProperty=nameWithType>: Memory usage as a percentage.
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.MemoryUsedInBytes?displayProperty=nameWithType>: Memory usage in bytes.
- <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization.SystemResources?displayProperty=nameWithType>: System resources.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.GuaranteedMemoryInBytes?displayProperty=nameWithType>: Guaranteed memory in bytes.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.MaximumMemoryInBytes?displayProperty=nameWithType>: Maximum memory in bytes.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.GuaranteedCpuUnits?displayProperty=nameWithType>: Guaranteed CPU in units.
  - <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.SystemResources.MaximumCpuUnits?displayProperty=nameWithType>: Maximum CPU in units.

### Extend resource monitoring with Spectre.Console

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

### Migrate to metrics-based resource monitoring

Since the <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface is deprecated, migrate to the metrics-based approach. The `Microsoft.Extensions.Diagnostics.ResourceMonitoring` package provides several metrics that you can use instead, for instance:

- `container.cpu.limit.utilization`: The CPU consumption share of the running containerized application relative to resource limit in range `[0, 1]`. Available for containerized apps on Linux and Windows.
- `container.cpu.request.utilization`: The CPU consumption share of the running containerized application relative to resource request in range `[0, 1]`. Available for containerized apps on Linux.
- `container.memory.limit.utilization`: The memory consumption share of the running containerized application relative to resource limit in range `[0, 1]`. Available for containerized apps on Linux and Windows.

For more information about the available metrics, see the [Built-in metrics: Microsoft.Extensions.Diagnostics.ResourceMonitoring](built-in-metrics-diagnostics.md#microsoftextensionsdiagnosticsresourcemonitoring) section.

#### Migration guide

This section provides a migration guide from the deprecated `IResourceMonitor` interface to the metrics-based approach. You only need this guide if you manually listen to resource utilization metrics in your application. In most cases, you don't need to listen to metrics manually because they're automatically collected and exported to back-ends using metrics exporters, as described in [Use .NET metrics of Resource monitoring](#use-net-metrics-of-resource-monitoring).

If you have code similar to the `IResourceMonitor` [example usage](#example-resource-monitoring-usage), update it as follows:

:::code source="snippets/resource-monitoring-with-manual-metrics/Program.cs" id="monitor" :::

The preceding code:

- Creates a cancellation token source and a cancellation token.
- Creates a new `Table` instance, configuring it with a title, caption, and columns.
- Performs a live render of the `Table` instance, passing in a delegate that will be invoked every three seconds.
- Gets the current resource utilization information using a callback set with the `SetMeasurementEventCallback` method and displays it as a new row in the `Table` instance.

The following is an example of the output from the preceding code:

:::image type="content" source="media/resource-monitoring-with-manual-metrics-output.png" lightbox="media/resource-monitoring-with-manual-metrics-output.png" alt-text="Example Resource Monitoring with manual metrics app output.":::

For the complete source code of this example, see the [Resource monitoring with manual metrics sample](https://github.com/dotnet/docs/tree/main/docs/core/diagnostics/snippets/resource-monitoring-with-manual-metrics).

## Kubernetes probes

In addition to resource monitoring, apps that exist within a Kubernetes cluster report their health through diagnostic probes. The [Microsoft.Extensions.Diagnostics.Probes](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Probes) NuGet package provides support for Kubernetes probes. It externalizes various [health checks](diagnostic-health-checks.md) that align with various Kubernetes probes, for example:

- Liveness
- Readiness
- Startup

The library communicates the app's current health to a Kubernetes hosting environment. If a process reports as being unhealthy, Kubernetes doesn't send it any traffic, providing the process time to recover or terminate.

To add support for Kubernetes probes, add a package reference to [Microsoft.Extensions.Diagnostics.Probes](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Probes). On an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> instance, call <xref:Microsoft.Extensions.DependencyInjection.KubernetesProbesExtensions.AddKubernetesProbes%2A>.

## See also

- [.NET extensions metrics](built-in-metrics-diagnostics.md)
- [Observability with OpenTelemetry](observability-with-otel.md)
