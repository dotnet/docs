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
> The <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring?displayProperty=fullName> package assumes that the consumer will register logging providers with the `Microsoft.Extensions.Logging` package. If you don't register logging, the call to `AddResourceMonitoring` will throw an exception. Furthermore, you can enable internal library logging by configuring the [`Debug`](xref:Microsoft.Extensions.Logging.LogLevel.Debug) log level for the `Microsoft.Extensions.Diagnostics.ResourceMonitoring` category as per the [guide](../extensions/logging/overview.md#log-category).

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

- Instantiates a new <xref:Microsoft.Extensions.DependencyInjection.ServiceCollection> instance, chaining calls to the <xref:Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions.AddLogging*> and <xref:Microsoft.Extensions.DependencyInjection.ResourceMonitoringServiceCollectionExtensions.AddResourceMonitoring*> extension methods.
- Builds a new <xref:Microsoft.Extensions.DependencyInjection.ServiceProvider> instance from the `ServiceCollection` instance.
- Gets an instance of the <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor> interface from the `ServiceProvider` instance.

At this point, with the `IResourceMonitor` implementation you'll ask for resource utilization with the <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.IResourceMonitor.GetUtilization*?displayProperty=nameWithType> method. The `GetUtilization` method returns a <xref:Microsoft.Extensions.Diagnostics.ResourceMonitoring.ResourceUtilization> instance that contains the following information:

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
- `container.cpu.request.utilization`: The CPU consumption share of the running containerized application relative to resource request in range `[0, 1]`. Available for containerized apps on Linux and Windows.
- `container.memory.limit.utilization`: The memory consumption share of the running containerized application relative to resource limit in range `[0, 1]`. Available for containerized apps on Linux and Windows.
- `container.memory.request.utilization`: The memory consumption share of the running containerized application relative to resource request in range `[0, 1]`. Available for containerized apps on Linux and Windows.

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

## Kubernetes resource monitoring

When your application runs inside a Kubernetes cluster, you typically configure resource limits and requests in your pod specification. The [Microsoft.Extensions.Diagnostics.ResourceMonitoring.Kubernetes](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.ResourceMonitoring.Kubernetes) NuGet package extends the base resource monitoring library to read these values from environment variables exposed by the [Kubernetes Downward API](https://kubernetes.io/docs/concepts/workloads/pods/downward-api/).

This package automatically detects your container's CPU and memory boundaries and emits accurate utilization metrics relative to those values.

> [!TIP]
> If your cluster runs Kubernetes v1.32 or later with cgroup v2, always prefer `AddKubernetesResourceMonitoring()` over `AddResourceMonitoring()` for accurate request-based utilization metrics. The Kubernetes package reads CPU and memory requests directly from environment variables, bypassing the cgroup weight inversion that can produce inaccurate values. See [Known limitations](#known-limitations-on-cgroup-v2) for details.

### How it works

The Kubernetes Downward API can expose pod resource limits and requests as environment variables. The `Microsoft.Extensions.Diagnostics.ResourceMonitoring.Kubernetes` package reads these environment variables at startup and uses them to calculate utilization metrics.

You choose a prefix for your environment variables (for example, `MY_APP_`). The library then looks for the following variables:

| Environment variable | Description |
| --- | --- |
| `<PREFIX>LIMITS_CPU` | CPU limit in millicores (for example, `2000` for 2 cores) |
| `<PREFIX>LIMITS_MEMORY` | Memory limit in bytes |
| `<PREFIX>REQUESTS_CPU` | CPU request in millicores (optional, defaults to limit value) |
| `<PREFIX>REQUESTS_MEMORY` | Memory request in bytes (optional, defaults to limit value) |

At minimum, you must set `<PREFIX>LIMITS_CPU` and `<PREFIX>LIMITS_MEMORY` to non-zero values. If you omit the request variables or set them to zero, the library defaults them to the corresponding limit values.

### Configure the Downward API

To expose resource limits as environment variables, add `resourceFieldRef` entries to your Kubernetes deployment manifest:

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: my-app
spec:
  template:
    spec:
      containers:
        - name: my-app
          resources:
            requests:
              cpu: "500m"
              memory: "256Mi"
            limits:
              cpu: "1000m"
              memory: "512Mi"
          env:
            - name: MY_APP_LIMITS_CPU
              valueFrom:
                resourceFieldRef:
                  resource: limits.cpu
                  divisor: "1m"
            - name: MY_APP_LIMITS_MEMORY
              valueFrom:
                resourceFieldRef:
                  resource: limits.memory
                  divisor: "1"
            - name: MY_APP_REQUESTS_CPU
              valueFrom:
                resourceFieldRef:
                  resource: requests.cpu
                  divisor: "1m"
            - name: MY_APP_REQUESTS_MEMORY
              valueFrom:
                resourceFieldRef:
                  resource: requests.memory
                  divisor: "1"
```

The `divisor: "1m"` for CPU fields ensures Kubernetes expresses the value in millicores (for example, a `500m` limit becomes `500`). The `divisor: "1"` for memory fields returns the value in bytes.

### Register Kubernetes resource monitoring

In your application code, call <xref:Microsoft.Extensions.DependencyInjection.KubernetesResourceQuotaServiceCollectionExtensions.AddKubernetesResourceMonitoring*> with the environment variable prefix that matches your Kubernetes manifest:

:::code source="snippets/resource-monitoring-kubernetes/Program.cs" id="setup":::

The `"MY_APP_"` prefix tells the library to look for environment variables named `MY_APP_LIMITS_CPU`, `MY_APP_LIMITS_MEMORY`, `MY_APP_REQUESTS_CPU`, and `MY_APP_REQUESTS_MEMORY`.

> [!IMPORTANT]
> Don't call `AddResourceMonitoring()` in addition to `AddKubernetesResourceMonitoring()`. The Kubernetes method already registers all necessary base resource monitoring components. Calling both methods can result in conflicting service registrations.

### Emitted metrics

Once registered, the library emits the following metrics under the `Microsoft.Extensions.Diagnostics.ResourceMonitoring` meter. It uses the Kubernetes resource boundaries you configured for its calculations:

| Metric name | Type | Description |
| --- | --- | --- |
| `container.cpu.limit.utilization` | ObservableGauge | CPU usage relative to the configured limit, in the range [0, 1] |
| `container.cpu.request.utilization` | ObservableGauge | CPU usage relative to the configured request, in the range [0, 1] |
| `container.cpu.time` | ObservableCounter | Total CPU time consumed in seconds, with a `cpu.mode` dimension (user/system) |
| `container.memory.limit.utilization` | ObservableGauge | Memory usage relative to the configured limit, in the range [0, 1] |
| `container.memory.request.utilization` | ObservableGauge | Memory usage relative to the configured request, in the range [0, 1] |
| `container.memory.usage` | ObservableUpDownCounter | Memory usage in bytes |
| `process.cpu.utilization` | ObservableGauge | Process CPU usage relative to the CPU limit, in the range [0, 1] |
| `dotnet.process.memory.virtual.utilization` | ObservableGauge | Process memory usage relative to the memory limit, in the range [0, 1] |

For the full list of metrics emitted by the base resource monitoring library, see [.NET extensions metrics: Microsoft.Extensions.Diagnostics.ResourceMonitoring](built-in-metrics-diagnostics.md#microsoftextensionsdiagnosticsresourcemonitoring).

### Example output

When you run your application inside a Kubernetes pod with the environment variables configured, the metrics produce values such as:

```
Instrument: container.cpu.limit.utilization
  Value: 0.23

Instrument: container.cpu.request.utilization
  Value: 0.46

Instrument: container.memory.limit.utilization
  Value: 0.61

Instrument: container.memory.request.utilization
  Value: 0.78

Instrument: container.memory.usage
  Value: 312475648 (By)

Instrument: container.cpu.time
  Value: 142.35 (s), cpu.mode=user
  Value: 28.91 (s), cpu.mode=system
```

In this example, the pod uses 23% of its CPU limit and 61% of its memory limit. Because the CPU request is lower than the CPU limit, `container.cpu.request.utilization` shows a higher value (46%) for the same absolute CPU usage.

### Collect metrics with OpenTelemetry

To export these metrics to your observability backend, register the meter with OpenTelemetry:

```csharp
services.AddOpenTelemetry()
    .WithMetrics(builder =>
    {
        builder.AddMeter("Microsoft.Extensions.Diagnostics.ResourceMonitoring");
        builder.AddOtlpExporter(); // Or any other metrics exporter
    });
```

### Known limitations on cgroup v2

Starting with Kubernetes v1.32 (using runc 1.3.2+ or crun 1.23+), the OCI runtime uses a new quadratic formula to convert cgroup v1 CPU shares to cgroup v2 CPU weight. This change affects the accuracy of the base `AddResourceMonitoring()` method when it attempts to derive CPU request values from cgroup parameters on Linux.

The core issue is that the base resource monitoring library reads `cpu.weight` from the cgroup v2 filesystem and reverse-converts it to estimate the original CPU request in millicores. However, the new conversion formula is **many-to-one**: multiple milliCPU values map to the same `cpu.weight`. For example, milliCPU values from 90 through 109 all produce `cpu.weight = 17`. Reversing this mapping cannot recover the exact original value, which means `container.cpu.request.utilization` may report inaccurate values.

The following metrics are affected:

| Metric | Affected? | Reason |
| --- | --- | --- |
| `container.cpu.request.utilization` | Yes | Relies on inferred CPU request from `cpu.weight` |
| `container.memory.request.utilization` | Yes | Relies on inferred memory request from cgroup parameters |
| `container.cpu.limit.utilization` | No | Uses `cpu.max`, not `cpu.weight` |
| `container.memory.limit.utilization` | No | Uses memory limit directly from cgroup |

**How the Kubernetes package solves this:** `AddKubernetesResourceMonitoring()` reads the actual CPU and memory request values directly from environment variables you configure through the Downward API. It never reverse-converts cgroup parameters, so utilization metrics are always accurate regardless of which OCI runtime conversion formula your cluster uses.

For more information, see:

- [New cgroup v1 to v2 CPU conversion formula (Kubernetes blog)](https://kubernetes.io/blog/2026/01/30/new-cgroup-v1-to-v2-cpu-conversion-formula/)
- [dotnet/extensions issue #7202](https://github.com/dotnet/extensions/issues/7202)

### Best practices

When deploying .NET applications to Kubernetes, consider the following recommendations:

1. **Use the Kubernetes package in Kubernetes environments.** Always prefer `AddKubernetesResourceMonitoring()` over `AddResourceMonitoring()` when running in a Kubernetes cluster. It provides accurate resource utilization metrics by reading values directly from the pod specification through environment variables.

1. **Expose resource metadata through the Downward API.** Configure your deployment manifests to expose CPU and memory limits and requests as environment variables. This ensures the library has access to the exact values you specified in your pod spec.

1. **Test metric accuracy after cluster upgrades.** When upgrading your Kubernetes cluster or OCI runtime (runc, crun), verify that your resource utilization metrics still report expected values, especially if you use the base `AddResourceMonitoring()` method.

## Kubernetes probes

In addition to resource monitoring, apps that exist within a Kubernetes cluster report their health through diagnostic probes. The [Microsoft.Extensions.Diagnostics.Probes](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Probes) NuGet package provides support for Kubernetes probes. It externalizes various [health checks](diagnostic-health-checks.md) that align with various Kubernetes probes, for example:

- Liveness
- Readiness
- Startup

The library communicates the app's current health to a Kubernetes hosting environment. If a process reports as being unhealthy, Kubernetes doesn't send it any traffic, providing the process time to recover or terminate.

To add support for Kubernetes probes, add a package reference to [Microsoft.Extensions.Diagnostics.Probes](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Probes). On an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> instance, call <xref:Microsoft.Extensions.DependencyInjection.KubernetesProbesExtensions.AddKubernetesProbes*>.

## See also

- [.NET extensions metrics](built-in-metrics-diagnostics.md)
- [Observability with OpenTelemetry](observability-with-otel.md)
