---
title: Networking Telemetry
description: Overview of networking telemetry tools in .NET.
author: MihaZupan
ms.author: mizupan
ms.date: 10/18/2022
---

# Networking telemetry in .NET

The .NET networking stack is instrumented at various layers. .NET gives you the option to collect accurate timings throughout the lifetime of an HTTP request using metrics, distributed tracing, event counters, and events.

- **[Networking metrics](metrics.md)**: Starting with .NET 8, the HTTP and the name resolution (DNS) components are instrumented using the modern [System.Diagnostics.Metrics API](../../../core/diagnostics/metrics.md). These metrics were designed in cooperation with [OpenTelemetry](https://opentelemetry.io/) and can be exported to various monitoring tools.
- **[Distributed tracing](tracing.md)**: `HttpClient` is instrumented to emit [distributed tracing](../../../core/diagnostics/distributed-tracing.md) activities (also known as spans).
- **[Networking events](events.md)**: Events provide debug and trace information with accurate timestamps.
- **[Networking event counters](event-counters.md)**: All networking components are instrumented to publish real-time performance metrics using the EventCounters API.
