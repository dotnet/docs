---
title: Metrics Overview
description: An overview of the metrics APIs available to monitor and diagnose .NET Core applications.
ms.date: 07/22/2021
---

# .NET Metrics

Metrics are numerical measurements reported over time, most often used to monitor the health of an application
and generate alerts. For example a web service might track how many requests it receives each second, how
many milliseconds it took to respond, and how many of the responses sent an error back to the user. These
metrics can be reported to a monitoring system at frequent regular intervals. If the example web service is
intended to respond within 400ms and then one day the response time slows to 600ms the monitoring system
can notify engineers that the application is not operating as expected.

Engineers can get metrics in two ways:

1. Some .NET libraries are already instrumented with metrics by the library's authors. Check the library's
documentation to learn what may be available.
  - [Built-in Metrics](https://docs.microsoft.com/en-us/dotnet/framework/debug-trace-profile/performance-counters) in .NET Framework 4.8 and lower
  - [Built-in Metrics](.\available-counters.md) in .NET Core 3.1, .NET 5 and .NET 6
2. Software developers can create new metrics by instrumenting code with Metric APIs discussed below.

## .NET Runtime APIs

Over the years .NET has accumulated a few different metrics APIs:

- <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> namespace - These are newest APIs, available either by targetting .NET 6
or older .NET apps can reference the [System.Diagnostics.DiagnosticsSource](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource) 6.0 NuGet package. They are
a good default choice for anyone starting a new .NET project or adding metrics to an application that
isn't already committed to an alternative API. The APIs work on all platforms supported by .NET and
were designed to integrate well with [OpenTelemetry's](https://opentelemetry.io/) growing ecosystem of tools. They also integrate
with dotnet SDK tools like [dotnet-counters](./dotnet-counters.md), and have a 1st class listener API available for developers
that want to create custom tooling or adapters to other systems.

- [EventCounters](./event-counters.md) - This was .NET's first set of cross platform metrics APIs. They are available by
targetting .NET Core 3.1 and a small subset is available on .NET Framework 4.7.1 and above. These
APIs remain fully supported and are actively used by a number of important .NET libraries, but they
have less functionality than the newer <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> APIs. EventCounters support reporting
rates of change and averages, but do not support histograms and percentiles. There is also
no support for multi-dimensional metrics. Custom tooling and adapters are possible via the
<xref:System.Diagnostics.Tracing.EventListener> API, though it is not strongly typed and only gives access to the aggregated values.

- <xref:System.Diagnostics.PerformanceCounter?displayProperty=nameWithType> - These APIs are only supported on Windows and provide
a managed API wrapper for Windows OS [Performance Counter](https://docs.microsoft.com/windows/win32/perfctrs/performance-counters-portal) technology. They are available in all
versions of .NET. These APIs are provided primarily for compatibility and are not commonly used
for new development projects.

## Metric APIs from other .NET projects and vendors

Most APM vendors such as [AppDynamics](https://www.appdynamics.com/), 
[Application Insights](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview),
[DataDog](https://www.datadoghq.com/), [DynaTrace](https://www.dynatrace.com/),
[NewRelic](https://newrelic.com/), and others include metrics APIs as part of their instrumentation
libraries. There are also popular .NET OSS projects
[Prometheus](https://github.com/prometheus-net/prometheus-net) and [AppMetrics](https://www.app-metrics.io/).
