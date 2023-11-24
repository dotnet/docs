---
title: Networking Telemetry in .NET
description: Overview of networking telemetry tools in .NET.
author: MihaZupan
ms.author: mizupan
ms.date: 10/18/2022
---

# Networking telemetry in .NET

The .NET networking stack is instrumented at various layers. .NET gives you the option to collect accurate timings throughout the lifetime of an HTTP request using Metrics, Event Counters and Events.

- **[Networking Metrics](metrics.md)**: Starting with .NET 8.0, the HTTP and the name resolution (DNS) components are instrumented using the modern, OpenTelemetry-compatible [Metrics](../../../core/diagnostics/metrics.md) API.
- **[Networking Event Counters](event-counters.md)**: All Networking components are instrumented to publish real-time performance metrics using the EventCounters API.
- **[Networking Events](events.md)**: Debug/trace information with accurate timestamps.

> [!TIP]
> If you're looking for information on tracking HTTP operations across different services, see the [distributed tracing documentation](../../../core/diagnostics/distributed-tracing.md).

## Need more telemetry?

If you have suggestions for other useful information that could be exposed via events or metrics, create a [dotnet/runtime issue](https://github.com/dotnet/runtime/issues/new).

If you're using the [`Yarp.Telemetry.Consumption`](https://www.nuget.org/packages/Yarp.Telemetry.Consumption) library and have any suggestions, create a [microsoft/reverse-proxy issue](https://github.com/microsoft/reverse-proxy/issues/new).
