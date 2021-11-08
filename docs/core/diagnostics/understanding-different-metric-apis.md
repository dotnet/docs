---
title: Understanding different metric APIs
description: A guide to different metric APIs offered by .NET and 3rd parties
ms.date: 11/04/2021
---

When adding new Metric instrumentation to a .NET app or library there are a variety of different APIs to choose from. This page
will help you understand what is available and some of the tradeoffs involved.

There are two major categories of APIs, vendor-neutral and vendor-specific.
Vendor specific APIs have the advantage that the vendor can iterate their designs quickly, add specialized features and achieve
tight integration between their instrumentation APIs and their backend systems. As an example, if you instrumented your app with
metric APIs provided by  [Application Insights](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview) then
you would expect to find well integrated functionality and all of Application Insight's latest features when working with their
analysis tools. However the library or app would also now be coupled to this vendor and changing to a different one in the future
would require rewriting the instrumentation. For libraries this coupling can be particularly problematic because the library
developer might use one vendor's API and the app developer that references the library wants to work with a different vendor.
To resolve this coupling issue we have vendor-neutral options that aim to provide a standardized API facade and extensibility
points to route data to a variety of vendor backend systems depending on configuration. Vendor neutral APIs however may provide
fewer capabilities and the user will still be constrained to pick a vendor that has integrated with the facade's extensibility
mechanism.

## .NET Runtime provided APIs

Over .NET's 20+ year history we have iterated a few times on the design for metric APIs, all of which are supported and vendor-neutral:

- <xref:System.Diagnostics.PerformanceCounter?displayProperty=nameWithType> - Our oldest APIs, these are only supported on Windows and provide
a managed wrapper for Windows OS [Performance Counter](https://docs.microsoft.com/windows/win32/perfctrs/performance-counters-portal)
technology. They are available in all supported versions of .NET. These APIs are provided primarily for compatibility and the .NET team
considers this a stable area that is unlikely to receive further improvement aside from bug fixes. These APIs are not suggested
for new development projects unless the project is Windows-only and the developers have a desire to use Windows Performance Counter
tools.

- [EventCounters](event-counters.md) - The next API designed after PerformanceCounters, this one was aimed at providing a uniform
cross-platform experience. The APIs are available by targetting .NET Core 3.1+ and a small subset is available on .NET Framework 4.7.1
and above. These APIs are fully supported and are actively used by key .NET libraries, but they
have less functionality than the newer <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> APIs. EventCounters support reporting
rates of change and averages, but do not support histograms and percentiles. There is also no support for multi-dimensional metrics. Custom
tooling is possible via the <xref:System.Diagnostics.Tracing.EventListener> API, though it is not strongly typed, only gives
access to the aggregated values, and has limitations using more than one listener simultaneously. EventCounters are supported directly by
[Visual Studio](https://docs.microsoft.com/en-us/visualstudio/profiling/dotnet-counters-tool?view=vs-2019), 
[Application Insights](https://docs.microsoft.com/azure/azure-monitor/app/eventcounters),
[dotnet-counters](dotnet-counters.md), and [dotnet-monitor](https://devblogs.microsoft.com/dotnet/introducing-dotnet-monitor/). For 3rd
party tool support please check the vendor or project's documentation to see if it is available.
At the time of writing this is the cross-platform .NET runtime API with the broadest stable ecosystem support, however we expect it will be
overtaken in the near future by growing support for [System.Diagnostics.Metrics](metrics-instrumentation.md). The .NET team doesn't expect to
make substantial new investments on this API going forward, but just as with PerformanceCounters the API remains actively supported for all
current and future users.

- [System.Diagnostics.Metrics](metrics-instrumentation.md) - These are the newest cross-platform APIs, designed in close collaboration with the
[OpenTelemetry](https://opentelemetry.io/) project. The OpenTelemetry effort is an industry wide collaboration across telemetry tooling vendors, 
programming languages and application developers to create a broadly compatible standard for telemetry APIs. .NET is taking a big bet by embedding
the metrics API directly into the base class libraries to eliminate any friction normally associated with .NET libraries adding 3rd party
dependencies. It is available either by targetting .NET 6 or older .NET Core and .NET Framework apps can add a reference to the .NET
[System.Diagnostics.DiagnosticsSource](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource) 6.0 NuGet package. In addition to
aiming at broad compatibility this API adds support for many things that were lacking from EventCounters such as histograms
and percentiles, multi-dimensional metrics, strongly typed high performance listener API, multiple simultaneous listeners, and
listener access to unaggregated measurements. Although this API was designed to work well with OpenTelemetry and its growing ecosystem
of pluggable vendor integration libraries, applications also have the option to use the .NET built-in listener APIs directly to create custom
metric tooling without taking any external library dependencies. At the time of writing the System.Diagnostics.Metrics are brand new and support
is limited to [dotnet-counters](dotnet-counters.md) and preview versions of [OpenTelemetry.NET](https://opentelemetry.io/docs/net/). However
we expect support for these APIs will grow quickly given the very active nature of the OpenTelemetry project.


## Metric APIs from other .NET projects and vendors

Most APM vendors such as [AppDynamics](https://www.appdynamics.com/), 
[Application Insights](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview),
[DataDog](https://www.datadoghq.com/), [DynaTrace](https://www.dynatrace.com/),
[NewRelic](https://newrelic.com/), and others include metrics APIs as part of their instrumentation
libraries. There are also popular .NET OSS projects
[Prometheus](https://github.com/prometheus-net/prometheus-net) and [AppMetrics](https://www.app-metrics.io/).
Check the various project websites to learn more about these options.