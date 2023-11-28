---
title: Networking Telemetry in .NET
description: Overview of networking telemetry tools in .NET.
author: MihaZupan
ms.author: mizupan
ms.date: 10/18/2022
---

# Networking telemetry in .NET

The .NET networking stack is instrumented at various layers. .NET gives you the option to collect accurate timings throughout the lifetime of an HTTP request using Metrics, Event Counters and Events.

- **[Networking Metrics](metrics.md)**: Starting with .NET 8.0, the HTTP and the name resolution (DNS) components are instrumented using the modern [Metrics API](../../../core/diagnostics/metrics.md). These metrics were designed in cooperation with [OpenTelemetry](https://opentelemetry.io/).
- **[Networking Events](events.md)**: Debug/trace information with accurate timestamps.
- **[Networking Event Counters](event-counters.md)**: All Networking components are instrumented to publish real-time performance metrics using the EventCounters API.

> [!TIP]
> If you're looking for information on tracking HTTP operations across different services, see the [distributed tracing documentation](../../../core/diagnostics/distributed-tracing.md).
