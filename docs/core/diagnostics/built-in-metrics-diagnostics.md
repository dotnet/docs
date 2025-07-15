---
title: .NET extensions metrics
description: Review the metrics available for diagnostic .NET extensions libraries.
ms.topic: reference
ms.date: 11/02/2023
---

# .NET extensions metrics

This article describes the built-in metrics for diagnostic .NET extensions libraries that are produced using the
<xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. For a listing of metrics based on the older [EventCounters](event-counters.md) API, see [Available counters](available-counters.md).

> [!TIP]
> For more information about how to collect and report these metrics, see [Collecting Metrics](metrics-collection.md).

## `Microsoft.Extensions.Diagnostics.HealthChecks`

The `Microsoft.Extensions.Diagnostics.HealthChecks` metrics report health check information from [.NET health checks](diagnostic-health-checks.md):

- [`dotnet.health_check.reports`](#metric-dotnethealth_checkreports)
- [`dotnet.health_check.unhealthy_checks`](#metric-dotnethealth_checkunhealthy_checks)

You can enable these metrics by calling the <xref:Microsoft.Extensions.DependencyInjection.CommonHealthChecksExtensions.AddTelemetryHealthCheckPublisher%2A> extension method. These metrics can only be enabled for push-based metrics and aren't available for pull-based metrics.

##### Metric: `dotnet.health_check.reports`

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `dotnet.health_check.reports` | Counter | `{report}` | Number of times a health report reported the health status of an application. |

| Attribute | Type | Description | Examples | Presence |
|---|---|---|---|---|
| `dotnet.health_check.status` | string | The health status of an application. | `Healthy`; `Unhealthy` | Always |

`dotnet.health_check.status` is one of the following:

| Value | Description |
|---|---|
| `Degraded` | An application was in degraded state. |
| `Healthy` | An application was healthy. |
| `Unhealthy` | An application was unhealthy. |

Available starting in: .NET 8.0.

##### Metric: `dotnet.health_check.unhealthy_checks`

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `dotnet.health_check.unhealthy_checks` | Counter | `{unhealthy_check}` | Number of times a health check reported the health status of an application as `Degraded` or `Unhealthy`. |

| Attribute | Type | Description | Examples | Presence |
|---|---|---|---|---|
| `dotnet.health_check.name` | string | The name of the health check. | `ApplicationLifecycle` | Always |
| `dotnet.health_check.status` | string | The health status of an application. | `Healthy`; `Unhealthy` | Always |

`dotnet.health_check.status` is one of the following:

| Value | Description |
|---|---|
| `Degraded` | An application was in degraded state. |
| `Healthy` | An application was healthy. |
| `Unhealthy` | An application was unhealthy. |

Available starting in: .NET 8.0.

## `Microsoft.Extensions.Diagnostics.ResourceMonitoring`

The `Microsoft.Extensions.Diagnostics.ResourceMonitoring` metrics report resource information from [resource monitoring](diagnostic-resource-monitoring.md):

- [`container.cpu.limit.utilization`](#metric-containercpulimitutilization)
- [`container.cpu.request.utilization`](#metric-containercpurequestutilization)
- [`container.cpu.time`](#metric-containercputime)
- [`container.memory.limit.utilization`](#metric-containermemorylimitutilization)
- [`process.cpu.utilization`](#metric-processcpuutilization)
- [`dotnet.process.memory.virtual.utilization`](#metric-dotnetprocessmemoryvirtualutilization)
- [`system.network.connections`](#metric-systemnetworkconnections)

> [!NOTE]
> Metrics emitted by the `Microsoft.Extensions.Diagnostics.ResourceMonitoring` meter are in experimental stage. This means that there could be breaking changes to them.

##### Metric: `container.cpu.limit.utilization`

The instrument is only available on a system running on containers both on Windows and Linux.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `container.cpu.limit.utilization` | ObservableGauge | `1` | The CPU consumption of the running containerized application relative to resource limit in range `[0, 1]`. |

Available starting in: .NET 8.8.0.

##### Metric: `container.cpu.request.utilization`

The instrument is only available on a system running on containers on Linux.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `container.cpu.request.utilization` | ObservableGauge | `1` | The CPU consumption of the running containerized application relative to resource request in range `[0, 1]`. |

Available starting in: .NET 8.8.0.

##### Metric: `container.cpu.time`

The instrument is only available on a system running on a container either on Windows or Linux.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `container.cpu.time` | ObservableCounter | `s` | CPU time used by the container. |

Available starting in: .NET 9.8.0.

##### Metric: `container.memory.limit.utilization`

The instrument is only available on a system running on containers both on Windows and Linux.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `container.memory.limit.utilization` | ObservableGauge | `1` | The memory consumption of the running containerized application relative to resource limit in range `[0, 1]`. |

Available starting in: .NET 8.8.0.

##### Metric: `process.cpu.utilization`

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `process.cpu.utilization` | ObservableGauge | `1` | The CPU consumption of the running application in range `[0, 1]`. |

Available starting in: .NET 8.0.

##### Metric: `dotnet.process.memory.virtual.utilization`

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `dotnet.process.memory.virtual.utilization` | ObservableGauge | `1` | The memory consumption of the running application in range `[0, 1]`. |

Available starting in: .NET 8.0.

##### Metric: `system.network.connections`

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `system.network.connections` | ObservableUpDownCounter | `{connection}` | Number of network connections by state. |

| Attribute | Type | Description | Examples | Presence |
|---|---|---|---|---|
| `network.type` | string | OSI network layer or non-OSI equivalent. | `ipv4`; `ipv6` | Always |
| `system.network.state` | string | The state of a network connection. | `close`; `listen` | Always |

Available starting in: .NET 8.0.
