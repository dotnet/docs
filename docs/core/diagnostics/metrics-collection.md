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
- Viewing metrics in real time with [`dotnet-counters`](/dotnet/core/diagnostics/dotnet-counters)
- Creating a custom collection tool using the underlying .NET <xref:System.Diagnostics.Metrics.MeterListener> API.

For more information on custom metric instrumentation and options, see [Compare metric APIs](compare-metric-apis.md).

## Create an example app

**Prerequisites**: [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet) or later

Before metrics can be collected, measurements must be produced. This tutorial creates an app that has some basic metric instrumentation. The .NET runtime also has [various metrics built-in](available-counters.md). For more information about creating new metrics using the
<xref:System.Diagnostics.Metrics.Meter?displayProperty=nameWithType> API, see [the instrumentation tutorial](metrics-instrumentation.md).

```dotnetcli
dotnet new console
dotnet add package System.Diagnostics.DiagnosticSource
```

Replace the contents of `Program.cs` with the following code:

```csharp
using System;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.HatStore", "1.0.0");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>("hats-sold");

    static void Main(string[] args)
    {
        Console.WriteLine("Press any key to exit");
        while(!Console.KeyAvailable)
        {
            // Pretend our store has a transaction each second that sells 4 hats
            Thread.Sleep(1000);
            s_hatsSold.Add(4);
        }
    }
}
```

## View metrics with dotnet-counters

[dotnet-counters](dotnet-counters.md) is a command-line tool that can view live metrics for .NET Core apps on demand. It doesn't require setup, making it useful for ad-hoc investigations or verifying that metric instrumentation is working. It works with both <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> based APIs and [EventCounters](event-counters.md).

If the [dotnet-counters](dotnet-counters.md) tool isn't installed, run the following command:

```dotnetcli
dotnet tool update -g dotnet-counters
```

While the example app is running, list the running processes in a second shell to determine the process ID:

```dotnetcli
dotnet-counters ps
```

Output similar to the following is displayed:

```dotnetcli
     10180 dotnet     C:\Program Files\dotnet\dotnet.exe
     19964 metric-instr E:\temp\metric-instr\bin\Debug\netcoreapp3.1\metric-instr.exe
```

Find the ID for the process name that matches the example app and have `dotnet-counters` monitor all metrics from the "HatCo.HatStore" meter. The meter name is case-sensitive.

```dotnetcli
dotnet-counters monitor -p 19964 HatCo.HatStore
```

Output similar to the following is displayed:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.HatStore]
    hats-sold (Count / 1 sec)                          4
```

`dotnet-counters` can be run specifying a different set of metrics to see some of the built-in instrumentation from the .NET runtime:

```dotnetcli
dotnet-counters monitor -p 19964 System.Runtime
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

For more information, see the [dotnet-counters](dotnet-counters.md). To learn more about metrics in .NET, see [built-in metrics](available-counters.md).

## View metrics in Grafana with OpenTelemetry and Prometheus

### Prerequisites

- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet) or a later

### Overview

[OpenTelemetry](https://opentelemetry.io/) is a vendor-neutral open-source project supported by the [Cloud Native Computing Foundation](https://www.cncf.io/) that aims to standardize generating and collecting telemetry for cloud-native software. The .NET metric APIs are compatible with OpenTelemetry and make integration straightforward. [Azure Monitor](/azure/azure-monitor/app/opentelemetry-overview) and many major APM vendors have endorsed OpenTelemetry.

This example shows one of the integrations available now for OpenTelemetry metrics using the popular OSS [Prometheus](https://prometheus.io/) and [Grafana](https://grafana.com/) projects. The metrics data flow:

1. The .NET metric APIs collect measurements from the example app.
1. The OpenTelemetry library running in the app aggregates the measurements.
1. The Prometheus exporter library makes the aggregated data available via an HTTP
metrics endpoint. 'Exporter' is what OpenTelemetry calls the libraries that transmit
telemetry to vendor-specific backends.
1. A Prometheus server, potentially running on a different machine:
  * Polls the metrics endpoint
  * Reads the data
  * Stores the data in a database for long-term persistence.
  Prometheus refers to this as 'scraping' an endpoint.
1. The Grafana server, potentially running on a different machine, queries the data stored in Prometheus and displays it on a web-based monitoring dashboard.

### Configure the example app to use OpenTelemetry's Prometheus exporter

Add a reference to the OpenTelemetry Prometheus exporter to the example app:

<!-- This package is deprecated, use the AspNetCore package .>
```dotnetcli
dotnet add package OpenTelemetry.Exporter.Prometheus --version 1.5.0-alpha.2
```
-->

```dotnetcli
dotnet add package OpenTelemetry.Exporter.Prometheus.AspNetCore --prerelease
```
<!-- --prerelease will add the latest prerelease and tutorial won't need to be updated every month. However, maybe add a note to remove prerelease when it's released -->

<!-- It didn't add two libs for me.
> [!NOTE]
> The Prometheus exporter library includes a reference to OpenTelemetry's shared library so this command implicitly adds both libraries to the app.
-->

> [!NOTE]
> This tutorial uses a pre-release build of OpenTelemetry's Prometheus support available at the time of writing.<!-- this is all noise and not needed: The OpenTelemetry project maintainers might make changes prior to the official release. -->

Modify the code of `Program.cs` so that it contains the code to configure OpenTelemetry:

```csharp
using System;
using System.Diagnostics.Metrics;
using System.Threading;
using OpenTelemetry;
using OpenTelemetry.Metrics;

class Program
{
    static Meter s_meter = new Meter("HatCo.HatStore", "1.0.0");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>(name: "hats-sold",
                                                                unit: "Hats",
                                                                description: "The number of hats sold in our store");

    static void Main(string[] args)
    {
        using MeterProvider meterProvider = Sdk.CreateMeterProviderBuilder()
                .AddMeter("HatCo.HatStore")
                .AddPrometheusExporter(opt =>
                {
                    opt.StartHttpListener = true;
                    opt.HttpListenerPrefixes = new string[] { $"http://localhost:9184/" };
                })
                .Build();

        Console.WriteLine("Press any key to exit");
        while(!Console.KeyAvailable)
        {
            // Pretend our store has a transaction each second that sells 4 hats
            Thread.Sleep(1000);
            s_hatsSold.Add(4);
        }
    }
}
```

In the preceding code:

* `AddMeter("HatCo.HatStore")` configures OpenTelemetry to transmit all the metrics collected by the Meter our app defined.
* `AddPrometheusExporter(...)` configures OpenTelemetry to expose Prometheus' metrics endpoint on port 9184 and to use the HttpListener. See the [OpenTelemetry documentation](https://github.com/open-telemetry/opentelemetry-dotnet/tree/main/docs/metrics/getting-started-prometheus-grafana#collect-metrics-using-prometheus)
for more information about OpenTelemetry configuration options. The OpenTelemetry documentation shows hosting options for ASP.NET apps.

> [!NOTE]
> At the time of writing, OpenTelemetry only supports metrics emitted using the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> APIs. However, support for [EventCounters](event-counters.md) is planned.

<!-- EventCounters support? -->
Run the example app and leave it running:

```dotnetcli
dotnet run
```

### Set up and configure Prometheus

Follow the [Prometheus first steps](https://prometheus.io/docs/introduction/first_steps/) to set up your Prometheus server and confirm it is working.

Modify the *prometheus.yml* configuration file so that Prometheus scrapes the metrics endpoint that the example app is exposing. Add this text in the `scrape_configs` section:

```yaml
  - job_name: 'OpenTelemetryTest'
    scrape_interval: 1s # poll very quickly for a more responsive demo
    static_configs:
      - targets: ['localhost:9184']
```

If you are starting from the default configuration, `scrape_configs` is similar to the followling YAML. Replace the ports in the following with your ports:

```yaml
scrape_configs:
  # The job name is added as a label `job=<job_name>` to any timeseries scraped from this config.
  - job_name: "prometheus"

    # metrics_path defaults to '/metrics'
    # scheme defaults to 'http'.

    static_configs:
      - targets: ["localhost:9090"]

  - job_name: 'OpenTelemetryTest'
    scrape_interval: 1s # poll very quickly for a more responsive demo
    static_configs:
      - targets: ['localhost:9184']
```

Reload the configuration or restart the Prometheus server, then confirm that OpenTelemetryTest is in the UP state in the **Status** > **Targets** page of the Prometheus web portal.

On the Graph page of the Prometheus web portal, enter `hats_sold` in the expression text box. In the graph tab, Prometheus should show the steadily increasing value of the "hats-sold" Counter that is being emitted by our example application.

[![Prometheus hats sold graph](media/prometheus-hat-sold-metric.png)](media/prometheus-hat-sold-metric.png)

If the Prometheus server hasn't been scraping the example app for long, you may need to wait a short while for data to accumulate. You can adjust the time range control in the upper left to "1m" (1 minute) to get a better view of very recent data.

### Show metrics on a Grafana dashboard

1. Follow [the standard instructions](https://prometheus.io/docs/visualization/grafana/#creating-a-prometheus-graph) to install Grafana and connect it to a Prometheus data source.

2. Create a Grafana dashboard by clicking the **+** icon on the left toolbar in the Grafana web portal, then select **Dashboard**. In the dashboard
editor that appears, enter 'Hats Sold/Sec' as the Title and 'rate(hats_sold[5m])' in the PromQL expression field. It should look like this:

   [![Hats sold Grafana dashboard editor](media/grafana-hats-sold-dashboard-editor.png)](media/grafana-hats-sold-dashboard-editor.png)

3. Click **Apply** to save and view the new dashboard.

   [![Hats sold Grafana dashboard](media/grafana-hats-sold-dashboard.png)](media/grafana-hats-sold-dashboard.png)

## Create a custom collection tool using the .NET <xref:System.Diagnostics.Metrics.MeterListener> API

The .NET <xref:System.Diagnostics.Metrics.MeterListener> API allows creating custom in-process logic to observe the measurements being recorded by <xref:System.Diagnostics.Metrics.Meter?displayProperty=nameWithType>. For guidance creating custom logic compatible with the older EventCounters instrumentation, see [EventCounters](event-counters.md).

Modify the code of `Program.cs` to use <xref:System.Diagnostics.Metrics.MeterListener>:

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.HatStore", "1.0.0");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>(name: "hats-sold",
                                                                unit: "Hats",
                                                                description: "The number of hats sold in our store");

    static void Main(string[] args)
    {
        using MeterListener meterListener = new MeterListener();
        meterListener.InstrumentPublished = (instrument, listener) =>
        {
            if(instrument.Meter.Name == "HatCo.HatStore")
            {
                listener.EnableMeasurementEvents(instrument);
            }
        };
        meterListener.SetMeasurementEventCallback<int>(OnMeasurementRecorded);
        meterListener.Start();

        Console.WriteLine("Press any key to exit");
        while(!Console.KeyAvailable)
        {
            // Pretend our store has a transaction each second that sells 4 hats
            Thread.Sleep(1000);
            s_hatsSold.Add(4);
        }
    }

    static void OnMeasurementRecorded<T>(Instrument instrument, T measurement, ReadOnlySpan<KeyValuePair<string,object>> tags, object state)
    {
        Console.WriteLine($"{instrument.Name} recorded measurement {measurement}");
    }
}
```

When run, the app now runs the custom callback on each measurement:

```dotnetcli
> dotnet run
Press any key to exit
hats-sold recorded measurement 4
hats-sold recorded measurement 4
hats-sold recorded measurement 4
hats-sold recorded measurement 4
...
```

In the preceding code, consider the following line:

```csharp
using MeterListener meterListener = new MeterListener();
```

An instance of the <xref:System.Diagnostics.Metrics.MeterListener> is created to receive measurements.

```csharp
meterListener.InstrumentPublished = (instrument, listener) =>
{
    if(instrument.Meter.Name == "HatCo.HatStore")
    {
        listener.EnableMeasurementEvents(instrument);
    }
};
```

The preceding code configured which instruments the listener receives measurements from.<xref:System.Diagnostics.Metrics.MeterListener.InstrumentPublished> is a delegate that is invoked when a new instrument is created within the app.  The delegate can examine the instrument to decide whether to subscribe. For example, the delegate can checking the name, the Meter, or any other public property. <!-- The previous version was way too long to MT. Is this better? --> If we do want to receive measurements from this instrument, then we invoke
<xref:System.Diagnostics.Metrics.MeterListener.EnableMeasurementEvents%2A> to indicate that. Code that obtains a reference to an instrument with another approach:

* Is not typically done.
* Can invoke `EnableMeasurementEvents()` at any time with the reference.

```csharp
meterListener.SetMeasurementEventCallback<int>(OnMeasurementRecorded);
...
static void OnMeasurementRecorded<T>(Instrument instrument, T measurement, ReadOnlySpan<KeyValuePair<string,object>> tags, object state)
{
    Console.WriteLine($"{instrument.Name} recorded measurement {measurement}");
}
```

The delegate that is invoked when measurements are received from an instrument is configured by calling <xref:System.Diagnostics.Metrics.MeterListener.SetMeasurementEventCallback%2A>. The generic parameter controls which data type of measurement is received by the callback. For example, a `Counter<int>` generates `int` measurements, `Counter<double>` generates `double` measurements. Instruments can be created with `byte`, `short`, `int`, `long`, `float`, `double`, and `decimal` types. We recommend registering a callback for every data type unless you have scenario-specific knowledge that not all data types are needed. Making repeated calls to `SetMeasurementEventCallback` with different generic arguments may appear a little unusual. The API was designed this way to allow `MeterListeners` to receive measurements with  low performance overhead, typically just a few nanoseconds.

When `MeterListener.EnableMeasurementEvents` is called, a `state` object can be provided as
one of the parameters. That object is arbitrary. If you provide a state object in that call, then it is stored with that instrument and returned to as the `state` parameter in the callback. This is intended both as a convenience and as a performance optimization. Often listeners need to:

* Create an object for each instrument that is storing measurements in memory.
* Have code to do calculations on those measurements.

<!--Why are we explaining low perf options? Metrics should be ultra low cost. Can we remove this? Folks that need this approach are smart enough to figure it out. -->
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

To guarantee that a certain region of code in your callback isn't currently executing and won't execute in the future, athread synchronization must be added. `Dispose` doesn't include the synchronization by default because it adds performance overhead in every measurement callback&mdash;and `MeterListener` is designed as a highly performance conscious API.
