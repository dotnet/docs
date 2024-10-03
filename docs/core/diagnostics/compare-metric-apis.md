---
title: Understanding different metric APIs
description: A guide to the different metric APIs offered by .NET and third parties.
ms.date: 11/04/2021
---

# Metric APIs comparison

When adding new metric instrumentation to a .NET app or library, there are various different APIs to choose from. This article
will help you understand the options.

## .NET APIs

### System.Diagnostics.Metrics

[System.Diagnostics.Metrics](metrics-instrumentation.md) APIs are the newest cross-platform APIs, and were designed in close collaboration with the
[OpenTelemetry](https://opentelemetry.io/) project. If you don't have a specific reason to use one of the older APIs covered below, [System.Diagnostics.Metrics](metrics-instrumentation.md) is
a good default choice for new work. It's available by targeting .NET 6+, or in older .NET Core and .NET Framework apps by adding a reference to the .NET
[System.Diagnostics.DiagnosticsSource](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource) 6.0+ NuGet package. In addition to
aiming at broad compatibility, this API adds support for many things that were lacking from earlier APIs, such as:

- Histograms and percentiles
- Multi-dimensional metrics
- Strongly typed high-performance listener API
- Multiple simultaneous listeners
- Listener access to unaggregated measurements

Although this API was designed to work well with OpenTelemetry and its growing ecosystem of pluggable vendor integration libraries, applications also have the option to use the .NET built-in listener APIs directly. With this option, you can create custom metric tooling without taking any external library dependencies.

### PerformanceCounter

<xref:System.Diagnostics.PerformanceCounter?displayProperty=nameWithType> APIs are the oldest .NET metric APIs. They're only supported on Windows and provide
a managed wrapper for Windows OS [Performance Counter](/windows/win32/perfctrs/performance-counters-portal)
technology. They are available in all supported versions of .NET.

These APIs are provided primarily for compatibility; the .NET team
considers this a stable area that's unlikely to receive further improvement aside from bug fixes. These APIs are not suggested
for new development projects unless the project is Windows-only and you have a desire to use Windows Performance Counter tools.

For more information, see [Performance counters in .NET Framework](../../framework/debug-trace-profile/performance-counters.md).

### EventCounters

The [EventCounters](event-counters.md) were the first .NET APIs to support a cross-platform metrics experience. The APIs are available by targeting .NET Core 3.1+, and a small subset is available on .NET Framework 4.7.1
and later. These APIs are fully supported and still used by key .NET libraries, but they
have less functionality than the newer <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> APIs. EventCounters are able to report
rates of change and averages, but do not support histograms and percentiles. There is also no support for multi-dimensional metrics. Custom
tooling is possible via the <xref:System.Diagnostics.Tracing.EventListener> API, though it is not strongly typed, only gives
access to the aggregated values, and has limitations when using more than one listener simultaneously. EventCounters are supported directly by
[Visual Studio](/visualstudio/profiling/dotnet-counters-tool), [Application Insights](/azure/azure-monitor/app/eventcounters),
[dotnet-counters](dotnet-counters.md), and [dotnet-monitor](https://devblogs.microsoft.com/dotnet/introducing-dotnet-monitor/). For third-party
tool support, check the vendor or project documentation to see if it's available.

The .NET team doesn't expect to make new investments on this API going forward, but as with `PerformanceCounters`, the API remains supported for all current and future users.

## Third-party APIs

Most application performance monitoring (APM) vendors such as [AppDynamics](https://www.appdynamics.com/),
[Application Insights](/azure/azure-monitor/app/app-insights-overview),
[DataDog](https://www.datadoghq.com/), [DynaTrace](https://www.dynatrace.com/), and
[NewRelic](https://newrelic.com/) include metrics APIs as part of their instrumentation libraries.
[Prometheus](https://github.com/prometheus-net/prometheus-net) and [AppMetrics](https://www.app-metrics.io/) are also popular .NET OSS projects.
To learn more about these projects, check the various project websites.
