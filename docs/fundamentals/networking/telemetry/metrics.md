---
title: Networking metrics
description: Learn how to consume .NET networking Metrics.
author: antonfirsov
ms.author: anfirszo
ms.date: 11/14/2023
---

# Networking metrics in .NET

[Metrics](../../../core/diagnostics/metrics.md) are numerical measurements reported over time. They are typically used to monitor the health of an app and generate alerts.

Starting with .NET 8, the `System.Net.Http` and the `System.Net.NameResolution` components are instrumented to publish metrics using .NET's new [System.Diagnostics.Metrics API](../../../core/diagnostics/metrics.md).
These metrics were designed in cooperation with [OpenTelemetry](https://opentelemetry.io/) to make sure they're consistent with the standard and work well with popular tools like [Prometheus](https://prometheus.io/) and [Grafana](https://grafana.com/).
They are also [multi-dimensional](../../../core/diagnostics/metrics-instrumentation.md#multi-dimensional-metrics), meaning that measurements are associated with key-value pairs called tags (a.k.a. attributes or labels) that allow data to be categorized for analysis.

> [!TIP]
> For a comprehensive list of all built-in instruments together with their attributes, see [System.Net metrics](../../../core/diagnostics/built-in-metrics-system-net.md).

## Collect System.Net metrics

There are two parts to using metrics in a .NET app:

* **Instrumentation:** Code in .NET libraries takes measurements and associates these measurements with a metric name. .NET and ASP.NET Core include many built-in metrics.
* **Collection:** A .NET app configures named metrics to be transmitted from the app for external storage and analysis. Some tools might perform configuration outside the app using configuration files or a UI tool.

This section demonstrates various methods to collect and view System.Net metrics.

### Example app

For the sake of this tutorial, create a simple app that sends HTTP requests to various endpoints in parallel.

```dotnetcli
dotnet new console -o HelloBuiltinMetrics
cd ..\HelloBuiltinMetrics
```

Replace the contents of `Program.cs` with the following sample code:

:::code language="csharp" source="snippets/metrics/Program.cs" id="snippet_ExampleApp":::

### View metrics with dotnet-counters

[`dotnet-counters`](../../../core/diagnostics/dotnet-counters.md) is a cross-platform performance monitoring tool for ad-hoc health monitoring and first-level performance investigation.

```dotnetcli
dotnet tool install --global dotnet-counters
```

When running against a .NET 8+ process, `dotnet-counters` enables the instruments defined by the `--counters` argument and displays the measurements. It continuously refreshes the console with the latest numbers:

```console
dotnet-counters monitor --counters System.Net.Http,System.Net.NameResolution -n HelloBuiltinMetrics
```

### View metrics in Grafana with OpenTelemetry and Prometheus

#### Overview

[OpenTelemetry](https://opentelemetry.io/):

- Is a vendor-neutral, open-source project supported by the [Cloud Native Computing Foundation](https://www.cncf.io/).
- Standardizes generating and collecting telemetry for cloud-native software.
- Works with .NET using the .NET metric APIs.
- Is endorsed by [Azure Monitor](/azure/azure-monitor/app/opentelemetry-overview) and many APM vendors.

This tutorial shows one of the integrations available for OpenTelemetry metrics using the OSS [Prometheus](https://prometheus.io/) and [Grafana](https://grafana.com/) projects. The metrics data flow consists of the following steps:

1. The .NET metric APIs record measurements from the example app.
1. The OpenTelemetry library running in the app aggregates the measurements.
1. The Prometheus exporter library makes the aggregated data available via an HTTP metrics endpoint. 'Exporter' is what OpenTelemetry calls the libraries that transmit telemetry to vendor-specific backends.
1. A Prometheus server:

   - Polls the metrics endpoint.
   - Reads the data.
   - Stores the data in a database for long-term persistence. Prometheus refers to reading and storing data as *scraping* an endpoint.
   - Can run on a different machine.

1. The Grafana server:

   - Queries the data stored in Prometheus and displays it on a web-based monitoring dashboard.
   - Can run on a different machine.

#### Configure the example app to use OpenTelemetry's Prometheus exporter

Add a reference to the OpenTelemetry Prometheus exporter to the example app:

```dotnetcli
dotnet add package OpenTelemetry.Exporter.Prometheus.HttpListener --prerelease
```

> [!NOTE]
> This tutorial uses a pre-release build of OpenTelemetry's Prometheus support available at the time of writing.

Update `Program.cs` with OpenTelemetry configuration:

:::code language="csharp" source="snippets/metrics/Program.cs" id="snippet_PrometheusExporter" highlight="5-8":::

In the preceding code:

- `AddMeter("System.Net.Http", "System.Net.NameResolution")` configures OpenTelemetry to transmit all the metrics collected by the built-in `System.Net.Http` and `System.Net.NameResolution` meters.
- `AddPrometheusHttpListener` configures OpenTelemetry to expose Prometheus' metrics HTTP endpoint on port `9184`.

> [!NOTE]
> This configuration differs for ASP.NET Core apps, where metrics are exported with `OpenTelemetry.Exporter.Prometheus.AspNetCore` instead of `HttpListener`. See the [related ASP.NET Core example](/aspnet/core/log-mon/metrics/metrics#create-the-starter-app).

Run the app and leave it running so measurements can be collected:

```dotnetcli
dotnet run
```

#### Set up and configure Prometheus

Follow the [Prometheus first steps](https://prometheus.io/docs/introduction/first_steps/) to set up a Prometheus server and confirm it is working.

Modify the *prometheus.yml* configuration file so that Prometheus scrapes the metrics endpoint that the example app is exposing. Add the following highlighted text in the `scrape_configs` section:

:::code language="yaml" source="snippets/metrics/prometheus.yml" highlight="31-99":::

#### Start prometheus

1. Reload the configuration or restart the Prometheus server.
1. Confirm that OpenTelemetryTest is in the UP state in the **Status** > **Targets** page of the Prometheus web portal.
![Prometheus status](~/docs/core/diagnostics/media/prometheus-status.png)

1. On the Graph page of the Prometheus web portal, enter `http` in the expression text box and select `http_client_active_requests`.
![http_client_active_requests](~/docs/fundamentals/networking/telemetry/media/prometheus-search.png)
  In the graph tab, Prometheus shows the value of the `http.client.active_requests` counter that's emitted by the example app.
  ![Prometheus active requests graph](~/docs/fundamentals/networking/telemetry/media/prometheus-active-requests.png)

#### Show metrics on a Grafana dashboard

1. Follow the [standard instructions](https://prometheus.io/docs/visualization/grafana/#installing) to install Grafana and connect it to a Prometheus data source.

1. Create a Grafana dashboard by selecting the **+** icon on the top toolbar then selecting **Dashboard**. In the dashboard editor that appears, enter **Open HTTP/1.1 Connections** in the **Title** box and the following query in the PromQL expression field:

```
sum by(http_connection_state) (http_client_open_connections{network_protocol_version="1.1"})
```

![Grafana HTTP/1.1 Connections](~/docs/fundamentals/networking/telemetry/media/grafana-connections.png)

1. Select **Apply** to save and view the new dashboard. It displays the number of active vs idle HTTP/1.1 connections in the pool.

## Enrichment

*Enrichment* is the addition of custom tags (a.k.a. attributes or labels) to a metric. This is useful if an app wants to add a custom categorization to dashboards or alerts built with metrics.
The [`http.client.request.duration`](../../../core/diagnostics/built-in-metrics-system-net.md#metric-httpclientrequestduration) instrument supports enrichment by registering callbacks with the <xref:System.Net.Http.Metrics.HttpMetricsEnrichmentContext>.
Note that this is a low-level API and a separate callback registration is needed for each `HttpRequestMessage`.

A simple way to do the callback registration at a single place is to implement a custom <xref:System.Net.Http.DelegatingHandler>.
This will allow you to intercept and modify the requests before they are forwarded to the inner handler and sent to the server:

:::code language="csharp" source="snippets/metrics/Program.cs" id="snippet_Enrichment":::

If you're working with [`IHttpClientFactory`](../../../core/extensions/httpclient-factory.md), you can use <xref:Microsoft.Extensions.DependencyInjection.HttpClientBuilderExtensions.AddHttpMessageHandler%2A> to register the `EnrichmentHandler`:

:::code language="csharp" source="snippets/metrics/Program.cs" id="snippet_EnrichmentWithFactory":::

> [!NOTE]
> For performance reasons, the enrichment callback is only invoked when the `http.client.request.duration` instrument is enabled, meaning that something should be collecting the metrics.
> This can be `dotnet-monitor`, Prometheus exporter, a [`MeterListener`](../../../core/diagnostics/metrics-collection.md#create-a-custom-collection-tool-using-the-net-meterlistener-api), or a `MetricCollector<T>`.

## `IMeterFactory` and `IHttpClientFactory` integration

HTTP metrics were designed with isolation and testability in mind. These aspects are supported by the use of <xref:System.Diagnostics.Metrics.IMeterFactory>, which enables publishing metrics by a custom <xref:System.Diagnostics.Metrics.Meter> instance in order to keep Meters isolated from each other.
By default, all metrics are emitted by a global <xref:System.Diagnostics.Metrics.Meter> internal to the `System.Net.Http` library. This behavior can be overriden by assigning a custom <xref:System.Diagnostics.Metrics.IMeterFactory> instance to <xref:System.Net.Http.SocketsHttpHandler.MeterFactory?displayProperty=nameWithType> or <xref:System.Net.Http.HttpClientHandler.MeterFactory?displayProperty=nameWithType>.

> [!NOTE]
> The <xref:System.Diagnostics.Metrics.Meter.Name?displayProperty=nameWithType> is `System.Net.Http` for all metrics emitted by `HttpClientHandler` and `SocketsHttpHandler`.

When working with [`Microsoft.Extensions.Http`](https://www.nuget.org/packages/microsoft.extensions.http) and [`IHttpClientFactory`](../../../core/extensions/httpclient-factory.md) on .NET 8+, the default `IHttpClientFactory` implementation automatically picks the `IMeterFactory` instance registered in the <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> and assigns it to the primary handler it creates internally.

> [!NOTE]
> Starting with .NET 8, the <xref:Microsoft.Extensions.DependencyInjection.HttpClientFactoryServiceCollectionExtensions.AddHttpClient%2A> method automatically calls <xref:Microsoft.Extensions.DependencyInjection.MetricsServiceExtensions.AddMetrics%2A> to initialize the metrics services and register the default <xref:System.Diagnostics.Metrics.IMeterFactory> implementation with <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>. The default <xref:System.Diagnostics.Metrics.IMeterFactory> caches <xref:System.Diagnostics.Metrics.Meter> instances by name, meaning that there will be one <xref:System.Diagnostics.Metrics.Meter> with the name `System.Net.Http` per <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection>.

### Test metrics

The following example demonstrates how to validate built-in metrics in unit tests using xUnit, `IHttpClientFactory`, and `MetricCollector<T>` from the [`Microsoft.Extensions.Diagnostics.Testing`](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.Testing) NuGet package:

:::code language="csharp" source="snippets/metrics/Program.cs" id="snippet_Testing":::

## Metrics vs. EventCounters

Metrics are [more feature-rich](../../../core/diagnostics/compare-metric-apis.md#systemdiagnosticsmetrics) than EventCounters, most notably because of their multi-dimensional nature. This multi-dimensionality lets you create sophisticated queries in tools like Prometheus and get insights on a level that's not possible with EventCounters.

Nevertheless, as of .NET 8, only the `System.Net.Http` and the `System.Net.NameResolutions` components are instrumented using Metrics, meaning that if you need counters from the lower levels of the stack such as `System.Net.Sockets` or `System.Net.Security`, you must use EventCounters.

Moreover, there are some semantical differences between Metrics and their matching EventCounters.
For example, when using `HttpCompletionOption.ResponseContentRead`, the [`current-requests` EventCounter](../../../core/diagnostics/available-counters.md) considers a request to be active until the moment when the last byte of the request body has been read.
Its metrics counterpart [`http.client.active_requests`](../../../core/diagnostics/built-in-metrics-system-net.md#metric-httpclientactive_requests) doesn't include the time spent reading the response body when counting the active requests.

## Need more metrics?

If you have suggestions for other useful information that could be exposed via metrics, create a [dotnet/runtime issue](https://github.com/dotnet/runtime/issues/new).
