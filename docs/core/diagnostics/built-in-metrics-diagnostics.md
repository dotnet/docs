---
title: .NET extensions metrics
description: Review the metrics available for diagnostic .NET extensions libraries.
ms.topic: reference
ms.date: 11/02/2023
---

# .NET extensions metrics

This article describes the built-in metrics for diagnostic .NET extensions libraries that are produced using the
<xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. For a listing of metrics based on the older [EventCounters](event-counters.md) API, see [Available counters](available-counters.md).

## `Microsoft.Extensions.Diagnostics.HealthChecks`

The `Microsoft.Extensions.Diagnostics.HealthChecks` metrics report health check information from [.NET health checks](diagnostic-health-checks.md):

- [`dotnet.health_check.reports`](#metric-dotnethealth_checkreports)
- [`dotnet.health_check.unhealthy_checks`](#metric-dotnethealth_checkunhealthy_checks)

### Metric: `dotnet.health_check.reports`

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

### Metric: `dotnet.health_check.unhealthy_checks`

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

- [`process.cpu.utilization`](#metric-processcpuutilization)
- [`dotnet.process.memory.virtual.utilization`](#metric-dotnetprocessmemoryvirtualutilization)
- [`system.network.connections`](#metric-systemnetworkconnections)

> [!NOTE]
> Metrics emitted by the `Microsoft.Extensions.Diagnostics.ResourceMonitoring` meter are in experimental stage. This means that there could be breaking changes to them.

### Metric: `process.cpu.utilization`

The instrument is available only on Linux.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `process.cpu.utilization` | ObservableGauge | `1` | The CPU consumption of the running application in range `[0, 1]`. |

Available starting in: .NET 8.0.

### Metric: `dotnet.process.memory.virtual.utilization`

The instrument is available only on Linux.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `dotnet.process.memory.virtual.utilization` | ObservableGauge | `1` | The memory consumption of the running application in range `[0, 1]`. |

Available starting in: .NET 8.0.

### Metric: `system.network.connections`

The instrument is available only on Windows.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `system.network.connections` | ObservableUpDownCounter | `{connection}` | Number of network connections by state. |

| Attribute | Type | Description | Examples | Presence |
|---|---|---|---|---|
| `network.type` | string | OSI network layer or non-OSI equivalent. | `ipv4`; `ipv6` | Always |
| `system.network.state` | string | The state of a network connection. | `close`; `listen` | Always |

Available starting in: .NET 8.0.
