---
title: .NET extensions metrics
description: Review the metrics available for diagnostic .NET extensions libraries.
ms.topic: reference
ms.date: 11/02/2023
---

# .NET extensions metrics

This article describes the metrics built-in for diagnostic .NET extensions libraries produced using the
<xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. For a listing of metrics based on the older [EventCounters](event-counters.md) API, see [here](available-counters.md).

- [Meter: `Microsoft.Extensions.Diagnostics.HealthChecks`](#meter-microsoftextensionsdiagnosticshealthchecks)
  - [Instrument: `dotnet.health_check.reports`](#instrument-dotnethealth_checkreports)
  - [Instrument: `dotnet.health_check.unhealthy_checks`](#instrument-dotnethealth_checkunhealthy_checks)
- [Meter: `Microsoft.Extensions.Diagnostics.ResourceMonitoring`](#meter-microsoftextensionsdiagnosticsresourcemonitoring)
  - [Instrument: `process.cpu.utilization`](#instrument-processcpuutilization)
  - [Instrument: `dotnet.process.memory.virtual.utilization`](#instrument-dotnetprocessmemoryvirtualutilization)
  - [Instrument: `system.network.connections`](#instrument-systemnetworkconnections)

## Meter: `Microsoft.Extensions.Diagnostics.HealthChecks`

### Instrument: `dotnet.health_check.reports`

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

Available starting in: .NET extensions 8.0.

### Instrument: `dotnet.health_check.unhealthy_checks`

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

Available starting in: .NET extensions 8.0.

## Meter: `Microsoft.Extensions.Diagnostics.ResourceMonitoring`

> [!NOTE]
> Metrics emitted by the `Microsoft.Extensions.Diagnostics.ResourceMonitoring` meter are in experimental stage. This means that there could be breaking changes to them.

### Instrument: `process.cpu.utilization`

The instrument is available only on Linux.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `process.cpu.utilization` | ObservableGauge | `1` | The CPU consumption of the running application in range `[0, 1]`. |

Available starting in: .NET extensions 8.0.

### Instrument: `dotnet.process.memory.virtual.utilization`

The instrument is available only on Linux.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `dotnet.process.memory.virtual.utilization` | ObservableGauge | `1` | The memory consumption of the running application in range `[0, 1]`. |

Available starting in: .NET extensions 8.0.

### Instrument: `system.network.connections`

The instrument is available only on Windows.

| Name | Instrument Type | Unit (UCUM) | Description |
| ---- | --------------- | ----------- | ----------- |
| `system.network.connections` | ObservableUpDownCounter | `{connection}` | Number of network connections by state. |

| Attribute | Type | Description | Examples | Presence |
|---|---|---|---|---|
| `network.type` | string | OSI network layer or non-OSI equivalent. | `ipv4`; `ipv6` | Always |
| `system.network.state` | string | The state of a network connection. | `close`; `listen` | Always |

`network.type` is one of the following:

| Value  | Description |
|---|---|
| `ipv4` | IPv4 |
| `ipv6` | IPv6 |

`system.network.state` is one of the following:

| Value  | Description |
|---|---|
| `close` | A connection is closed. |
| `close_wait` | A connection is in the close wait state. |
| `closing` | A connection is closing. |
| `delete` | A connection is in the delete TCB state. |
| `established` | A connection is established. |
| `fin_wait_1` | A connection is waiting for a FIN packet 1. |
| `fin_wait_2` | A connection is waiting for a FIN packet 2. |
| `last_ack` | A connection is in the last ACK state. |
| `listen` | A connection is in the listen state. |
| `syn_recv` | A connection has received a SYN packet. |
| `syn_sent` | A connection has sent a SYN packet. |
| `time_wait` | A connection is in the time wait state. |

Available starting in: .NET extensions 8.0.
