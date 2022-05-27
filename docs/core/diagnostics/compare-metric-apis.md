---
title: Understanding different metric APIs
description: A guide to the different metric APIs offered by .NET and third parties.
ms.date: 11/04/2021
---

# Metric APIs comparison

When adding new metric instrumentation to a .NET app or library, there are various different APIs to choose from. This article
will help you understand what is available and some of the tradeoffs involved.

There are two major categories of APIs, vendor-neutral and vendor-specific.
Vendor-specific APIs have the advantage that the vendor can iterate their designs quickly, add specialized features, and achieve
tight integration between their instrumentation APIs and their backend systems. As an example, if you instrumented your app with
metric APIs provided by  [Application Insights](/azure/azure-monitor/app/app-insights-overview), then
you would expect to find well-integrated functionality and all of Application Insight's latest features when working with their
analysis tools. However the library or app would also now be coupled to this vendor and changing to a different one in the future
would require rewriting the instrumentation. For libraries, this coupling can be particularly problematic because the library
developer might use one vendor's API and the app developer that references the library wants to work with a different vendor.
To resolve this coupling issue, vendor-neutral options provide a standardized API façade and extensibility
points to route data to various vendor backend systems depending on configuration. However, vendor-neutral APIs may provide
fewer capabilities, and you're still constrained to pick a vendor that has integrated with the façade's extensibility
mechanism.

## .NET APIs

Over .NET's 20+ year history, we've iterated a few times on the design for metric APIs, all of which are supported and vendor-neutral:

### PerformanceCounter

<xref:System.Diagnostics.PerformanceCounter?displayProperty=nameWithType> APIs are the oldest metric APIs. They're only supported on Windows and provide
a managed wrapper for Windows OS [Performance Counter](/windows/win32/perfctrs/performance-counters-portal)
technology. They are available in all supported versions of .NET.

These APIs are provided primarily for compatibility; the .NET team
considers this a stable area that's unlikely to receive further improvement aside from bug fixes. These APIs are not suggested
for new development projects unless the project is Windows-only and you have a desire to use Windows Performance Counter tools.

For more information, see [Performance counters in .NET Framework](../../framework/debug-trace-profile/performance-counters.md).

### EventCounters

The [EventCounters](event-counters.md) API came next after `PerformanceCounters`. This API aimed to provide a uniform
cross-platform experience. The APIs are available by targeting .NET Core 3.1+, and a small subset is available on .NET Framework 4.7.1
and above. These APIs are fully supported and are actively used by key .NET libraries, but they
have less functionality than the newer <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> APIs. EventCounters are able to report
rates of change and averages, but do not support histograms and percentiles. There is also no support for multi-dimensional metrics. Custom
tooling is possible via the <xref:System.Diagnostics.Tracing.EventListener> API, though it is not strongly typed, only gives
access to the aggregated values, and has limitations when using more than one listener simultaneously. EventCounters are supported directly by
[Visual Studio](/visualstudio/profiling/dotnet-counters-tool), [Application Insights](/azure/azure-monitor/app/eventcounters),
[dotnet-counters](dotnet-counters.md), and [dotnet-monitor](https://devblogs.microsoft.com/dotnet/introducing-dotnet-monitor/). For third-party
tool support, check the vendor or project documentation to see if it's available.

At the time of writing, this is the cross-platform .NET runtime API that has the broadest and most stable ecosystem support. However, it will likely be
overtaken soon by growing support for [System.Diagnostics.Metrics](metrics-instrumentation.md). The .NET team doesn't expect to
make substantial new investments on this API going forward, but as with `PerformanceCounters`, the API remains actively supported for all
current and future users.

### System.Diagnostics.Metrics

[System.Diagnostics.Metrics](metrics-instrumentation.md) APIs are the newest cross-platform APIs, and were designed in close collaboration with the
[OpenTelemetry](https://opentelemetry.io/) project. The OpenTelemetry effort is an industry-wide collaboration across telemetry tooling vendors,
programming languages, and application developers to create a broadly compatible standard for telemetry APIs. To eliminate any friction associated with adding third-party dependencies, .NET embeds the metrics API directly into the base class libraries.
It's available by targeting .NET 6, or in older .NET Core and .NET Framework apps by adding a reference to the .NET
[System.Diagnostics.DiagnosticsSource](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource) 6.0 NuGet package. In addition to
aiming at broad compatibility, this API adds support for many things that were lacking from EventCounters, such as:

- Histograms and percentiles
- Multi-dimensional metrics
- Strongly typed high-performance listener API
- Multiple simultaneous listeners
- Listener access to unaggregated measurements

Although this API was designed to work well with OpenTelemetry and its growing ecosystem of pluggable vendor integration libraries, applications also have the option to use the .NET built-in listener APIs directly. With this option, you can create custom metric tooling without taking any external library dependencies. At the time of writing, the System.Diagnostics.Metrics APIs are brand new and support is limited to [dotnet-counters](dotnet-counters.md) and preview versions of [OpenTelemetry.NET](https://opentelemetry.io/docs/net/). However, we expect support for these APIs will grow quickly given the active nature of the OpenTelemetry project.

## Third-party APIs

Most application performance monitoring (APM) vendors such as [AppDynamics](https://www.appdynamics.com/),
[Application Insights](/azure/azure-monitor/app/app-insights-overview),
[DataDog](https://www.datadoghq.com/), [DynaTrace](https://www.dynatrace.com/), and
[NewRelic](https://newrelic.com/) include metrics APIs as part of their instrumentation libraries.
[Prometheus](https://github.com/prometheus-net/prometheus-net) and [AppMetrics](https://www.app-metrics.io/) are also popular .NET OSS projects.
To learn more about these projects, check the various project websites.
