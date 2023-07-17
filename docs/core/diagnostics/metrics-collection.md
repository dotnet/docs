---
title: Collect metrics - .NET
description: Tutorial to collect metrics in .NET applications
ms.topic: tutorial
ms.date: 10/27/2021
---

# Collect metrics

**This article applies to: ✔️** .NET Core 3.1 and later **✔️** .NET Framework 4.6.1 and later

Instrumented code can record numeric measurements, but the measurements usually need to be aggregated, transmitted, and stored to create useful metrics for monitoring. The process of aggregating, transmitting, and storing data is called collection. This tutorial shows several examples of collecting metrics:

- Populating metrics in [Grafana](https://grafana.com/) with [OpenTelemetry](https://opentelemetry.io/) and [Prometheus](https://prometheus.io/).
- Viewing metrics in real time with [`dotnet-counters`](dotnet-counters.md)
- Creating a custom collection tool using the underlying .NET <xref:System.Diagnostics.Metrics.MeterListener> API.

For more information on custom metric instrumentation and options, see [Compare metric APIs](compare-metric-apis.md).

## Prerequisites

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet) or a later

## Create an example app

Before metrics can be collected, measurements must be produced. This tutorial creates an app that has basic metric instrumentation. The .NET runtime also has [various metrics built-in](available-counters.md). For more information about creating new metrics using the <xref:System.Diagnostics.Metrics.Meter?displayProperty=nameWithType> API, see [the instrumentation tutorial](metrics-instrumentation.md).

```dotnetcli
dotnet new console -o metric-instr
cd metric-instr
dotnet add package System.Diagnostics.DiagnosticSource
```

Replace the contents of `Program.cs` with the following code:

:::code language="csharp" source="snippets/Metrics/Program.cs" id="snippet":::

The preceding code simulates selling hats at random intervals and random times.

## View metrics with dotnet-counters

[dotnet-counters](dotnet-counters.md) is a command-line tool that can view live metrics for .NET Core apps on demand. It doesn't require setup, making it useful for ad-hoc investigations or verifying that metric instrumentation is working. It works with both <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> based APIs and [EventCounters](event-counters.md).

If the [dotnet-counters](dotnet-counters.md) tool isn't installed, run the following command:

```dotnetcli
dotnet tool update -g dotnet-counters
```

While the example app is running, launch [dotnet-counters](dotnet-counters.md). The following command shows an example of `dotnet-counters` monitoring all metrics from the `HatCo.HatStore` meter. The meter name is case-sensitive. Our sample app was metric-instr.exe, substitute this with the name of your sample app.

```dotnetcli
dotnet-counters monitor -n metric-instr HatCo.HatStore
```

Output similar to the following is displayed:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.HatStore]
    hats-sold (Count / 1 sec)                          4
```

`dotnet-counters` can be run with a different set of metrics to see some of the built-in instrumentation from the .NET runtime:

```dotnetcli
dotnet-counters monitor -n metric-instr
```

Output similar to the following is displayed:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[System.Runtime]
    % Time in GC since last GC (%)                                 0
    Allocation Rate (B / 1 sec)                                8,168
    CPU Usage (%)                                                  0
    Exception Count (Count / 1 sec)                                0
    GC Heap Size (MB)                                              2
    Gen 0 GC Count (Count / 1 sec)                                 0
    Gen 0 Size (B)                                         2,216,256
    Gen 1 GC Count (Count / 1 sec)                                 0
    Gen 1 Size (B)                                           423,392
    Gen 2 GC Count (Count / 1 sec)                                 0
    Gen 2 Size (B)                                           203,248
    LOH Size (B)                                             933,216
    Monitor Lock Contention Count (Count / 1 sec)                  0
    Number of Active Timers                                        1
    Number of Assemblies Loaded                                   39
    ThreadPool Completed Work Item Count (Count / 1 sec)           0
    ThreadPool Queue Length                                        0
    ThreadPool Thread Count                                        3
    Working Set (MB)                                              30
```

For more information, see [dotnet-counters](dotnet-counters.md). To learn more about metrics in .NET, see [built-in metrics](available-counters.md).

## View metrics in Grafana with OpenTelemetry and Prometheus

### Overview

[OpenTelemetry](https://opentelemetry.io/):

- Is a vendor-neutral open-source project supported by the [Cloud Native Computing Foundation](https://www.cncf.io/).
- Standardizes generating and collecting telemetry for cloud-native software.
- Works with .NET using the .NET metric APIs.
- Is endorsed by [Azure Monitor](/azure/azure-monitor/app/opentelemetry-overview) and many APM vendors.

This tutorial shows one of the integrations available for OpenTelemetry metrics using the OSS [Prometheus](https://prometheus.io/) and [Grafana](https://grafana.com/) projects. The metrics data flow:

1. The .NET metric APIs record measurements from the example app.
1. The OpenTelemetry library running in the app aggregates the measurements.
1. The Prometheus exporter library makes the aggregated data available via an HTTP metrics endpoint. 'Exporter' is what OpenTelemetry calls the libraries that transmit telemetry to vendor-specific backends.
1. A Prometheus server:

   - Polls the metrics endpoint
   - Reads the data
   - Stores the data in a database for long-term persistence. Prometheus refers to reading and storing data as *scraping* an endpoint.
   - Can run on a different machine

1. The Grafana server:

   - Queries the data stored in Prometheus and displays it on a web-based monitoring dashboard.
   - Can run on a different machine.

### Configure the example app to use OpenTelemetry's Prometheus exporter

Add a reference to the OpenTelemetry Prometheus exporter to the example app:

```dotnetcli
dotnet add package OpenTelemetry.Exporter.Prometheus.AspNetCore --prerelease
```

> [!NOTE]
> This tutorial uses a pre-release build of OpenTelemetry's Prometheus support available at the time of writing.

Update `Program.cs` with OpenTelemetry configuration:

:::code language="csharp" source="snippets/Metrics/Program.cs" id="snippet_1":::

In the preceding code:

- `AddMeter("HatCo.HatStore")` configures OpenTelemetry to transmit all the metrics collected by the Meter defined in the app.
- `AddPrometheusExporter` configures OpenTelemetry to:
  - Expose Prometheus' metrics endpoint on port `9184`
  - Use the HttpListener.

See the [OpenTelemetry documentation](https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/metrics/getting-started-prometheus-grafana#collect-metrics-using-prometheus) for more information about OpenTelemetry configuration options. The OpenTelemetry documentation shows hosting options for ASP.NET apps.

Run the app and leave it running so measurements can be collected:

```dotnetcli
dotnet run
```

### Set up and configure Prometheus

Follow the [Prometheus first steps](https://prometheus.io/docs/introduction/first_steps/) to set up a Prometheus server and confirm it is working.

Modify the *prometheus.yml* configuration file so that Prometheus scrapes the metrics endpoint that the example app is exposing. Add the following highlighted text in the `scrape_configs` section:

:::code language="yaml" source="snippets/Metrics/prometheus.yml" highlight="31-99":::

#### Start Prometheus

1. Reload the configuration or restart the Prometheus server.
1. Confirm that OpenTelemetryTest is in the UP state in the **Status** > **Targets** page of the Prometheus web portal.
![Prometheus status](~/docs/core/diagnostics/media/prometheus-status.png)

1. On the Graph page of the Prometheus web portal, enter `hats` in the expression text box and select `hats_sold_Hats`
![hat](~/docs/core/diagnostics/media/prometheus-search.png)
  In the graph tab, Prometheus shows the increasing value of the "hats-sold" Counter that is being emitted by the example app.
  ![Prometheus hats sold graph](~/docs/core/diagnostics/media/prometheus-hat-sold-metric2.png)

In the preceding image, the graph time is set to **5m**, which is 5 minutes.

If the Prometheus server hasn't been scraping the example app for long, you may need to wait for data to accumulate.

### Show metrics on a Grafana dashboard

1. Follow the [standard instructions](https://prometheus.io/docs/visualization/grafana/#creating-a-prometheus-graph) to install Grafana and connect it to a Prometheus data source.

2. Create a Grafana dashboard by clicking the **+** icon on the left toolbar in the Grafana web portal, then select **Dashboard**. In the dashboard editor that appears, enter **Hats Sold/Sec** in the **Title** input box and **rate(hats_sold[5m])**  in the PromQL expression field:

   ![Hats sold Grafana dashboard editor](~/docs/core/diagnostics/media/grafana-hats-sold-dashboard-editor.png)

3. Click **Apply** to save and view the new dashboard.

   ![Hats sold Grafana dashboard](~/docs/core/diagnostics/media/grafana-hats-sold-dashboard.png)]

## Create a custom collection tool using the .NET <xref:System.Diagnostics.Metrics.MeterListener> API

The .NET <xref:System.Diagnostics.Metrics.MeterListener> API allows creating custom in-process logic to observe the measurements being recorded by <xref:System.Diagnostics.Metrics.Meter?displayProperty=nameWithType>. For guidance creating custom logic compatible with the older EventCounters instrumentation, see [EventCounters](event-counters.md).

Modify the code of `Program.cs` to use <xref:System.Diagnostics.Metrics.MeterListener>:

:::code language="csharp" source="snippets/Metrics/Program.cs" id="snippet_ml":::

The following output shows the output of the app with custom callback on each measurement:

```dotnetcli
> dotnet run
Press any key to exit
hats-sold recorded measurement 978
hats-sold recorded measurement 775
hats-sold recorded measurement 666
hats-sold recorded measurement 66
hats-sold recorded measurement 914
hats-sold recorded measurement 912
...
```

### Explaining the sample code

The code snippets in this section come from the preceding sample.

In the following highlighted code, an instance of the <xref:System.Diagnostics.Metrics.MeterListener> is created to receive measurements. The `using` keyword causes `Dispose` to be called when the `meterListener` goes out of scope.

:::code language="csharp" source="snippets/Metrics/Program.cs" id="snippet_uml" highlight="1":::

The following highlighted code configures which instruments the listener receives measurements from. <xref:System.Diagnostics.Metrics.MeterListener.InstrumentPublished> is a delegate that is invoked when a new instrument is created within the app.

:::code language="csharp" source="snippets/Metrics/Program.cs" id="snippet_uml" highlight="2-99":::

The delegate can examine the instrument to decide whether to subscribe. For example, the delegate can check the name, the Meter, or any other public property. <xref:System.Diagnostics.Metrics.MeterListener.EnableMeasurementEvents%2A> enables receiving measurements from the specified instrument. Code that obtains a reference to an instrument by another approach:

- Is not typically done.
- Can invoke `EnableMeasurementEvents()` at any time with the reference.

The delegate that is invoked when measurements are received from an instrument is configured by calling <xref:System.Diagnostics.Metrics.MeterListener.SetMeasurementEventCallback%2A>:

:::code language="csharp" source="snippets/Metrics/Program.cs" id="snippet_sme" highlight="1,15-99":::

The generic parameter controls which data type of measurement is received by the callback. For example, a `Counter<int>` generates `int` measurements, `Counter<double>` generates `double` measurements. Instruments can be created with `byte`, `short`, `int`, `long`, `float`, `double`, and `decimal` types. We recommend registering a callback for every data type unless you have scenario-specific knowledge that not all data types are needed. Making repeated calls to `SetMeasurementEventCallback` with different generic arguments may appear a little unusual. The API was designed this way to allow a `MeterListener` to receive measurements with low performance overhead, typically just a few nanoseconds.

When `MeterListener.EnableMeasurementEvents` is called, a `state` object can be provided as
one of the parameters. The `state` object is arbitrary. If you provide a state object in that call, then it is stored with that instrument and returned to you as the `state` parameter in the callback. This is intended both as a convenience and as a performance optimization. Often listeners need to:

- Create an object for each instrument that is storing measurements in memory.
- Have code to do calculations on those measurements.

Alternatively, create a `Dictionary` that maps from the instrument to the storage object and look it up on every measurement. Using a `Dictionary` is much slower than accessing it from `state`.

```csharp
meterListener.Start();
```

The preceding code starts the `MeterListener` which enables callbacks. The `InstrumentPublished` delegate is invoked for every pre-existing Instrument in the process. Newly created Instrument objects also trigger `InstrumentPublished` to be invoked.

```csharp
using MeterListener meterListener = new MeterListener();
```

When the app is done listening, disposing the listener stops the flow of callbacks and releases any internal references to the listener object. The `using` keyword used when declaring `meterListener` causes `Dispose` to be called when the variable goes out of scope. Note that `Dispose` is only promising that it won't initiate new callbacks. Because callbacks
occur on different threads, there may still be callbacks in progress after the call to `Dispose` returns.

To guarantee that a certain region of code in the callback isn't currently executing and won't execute in the future, thread synchronization must be added. `Dispose` doesn't include synchronization by default because:

- Synchronization adds performance overhead in every measurement callback.
- `MeterListener` is designed as a highly performance conscious API.
