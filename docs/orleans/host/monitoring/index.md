---
title: Orleans observability
description: Explore the various runtime monitoring, logging, distributed tracing, and metrics options available in .NET Orleans.
ms.date: 08/31/2023
zone_pivot_groups: orleans-version
---

# Orleans observability

One of the most important aspects of a distributed system is observability. Observability is the ability to understand the state of the system at any given time. There are various ways to achieve this, including logging, metrics, and distributed tracing.

## Logging

Orleans uses [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging) for all silo and client logs. You can use any logging provider that is compatible with `Microsoft.Extensions.Logging`. Your app code would rely on [dependency injection](../../../core/extensions/dependency-injection.md) to get an instance of <xref:Microsoft.Extensions.Logging.ILogger%601> and use it to log messages. For more information, see [Logging in .NET](../../../core/extensions/logging.md).

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-7-0"
<!-- markdownlint-enable MD044 -->

## Metrics

Metrics are numerical measurements reported over time. They're most often used to monitor the health of an application and generate alerts. For more information, see [Metrics in .NET](../../../core/diagnostics/metrics.md). Orleans uses the [System.Diagnostics.Metrics](../../../core/diagnostics/compare-metric-apis.md#systemdiagnosticsmetrics) APIs to collect metrics. The metrics are exposed to the [OpenTelemetry](https://opentelemetry.io) project, which exports the metrics to various monitoring systems.

To monitor your app without making any code changes at all, you can use the `dotnet counters` .NET diagnostic tool. To monitor Orleans <xref:System.Diagnostics.ActivitySource> counters, given your desired `<ProcessName>` to monitor, use the `dotnet counters monitor` command as shown:

```dotnetcli
dotnet counters monitor -n <ProcessName> --counters Microsoft.Orleans
```

Imagine that you're running the [Orleans GPS Tracker sample app](/samples/dotnet/samples/orleans-gps-device-tracker-sample), and in a separate terminal, you're monitoring it with the `dotnet counters monitor` command. The following output is typical:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running
[Microsoft.Orleans]
    orleans-app-requests-latency-bucket (Count / 1 sec)                    0
        duration=10000ms                                                   0
        duration=1000ms                                                    0
        duration=100ms                                                     0
        duration=10ms                                                      0
        duration=15000ms                                                   0
        duration=1500ms                                                    0
        duration=1ms                                                   2,530
        duration=2000ms                                                    0
        duration=200ms                                                     0
        duration=2ms                                                       0
        duration=400ms                                                     0
        duration=4ms                                                       0
        duration=5000ms                                                    0
        duration=50ms                                                      0
        duration=6ms                                                       0
        duration=800ms                                                     0
        duration=8ms                                                       0
        duration=9223372036854775807ms                                     0
    orleans-app-requests-latency-count (Count / 1 sec)                 2,530
    orleans-app-requests-latency-sum (Count / 1 sec)                       0
    orleans-catalog-activation-working-set                                36
    orleans-catalog-activations                                           38
    orleans-consistent-ring-range-percentage-average                     100
    orleans-consistent-ring-range-percentage-local                       100
    orleans-consistent-ring-size                                           1
    orleans-directory-cache-size                                          27
    orleans-directory-partition-size                                      26
    orleans-directory-ring-local-portion-average-percentage              100
    orleans-directory-ring-local-portion-distance                          0
    orleans-directory-ring-local-portion-percentage                        0
    orleans-directory-ring-size                                        1,295
    orleans-gateway-received (Count / 1 sec)                           1,291
    orleans-gateway-sent (Count / 1 sec)                               2,582
    orleans-messaging-processing-activation-data                           0
    orleans-messaging-processing-dispatcher-forwarded (Count / 1           0
    orleans-messaging-processing-dispatcher-processed (Count / 1       2,543
        Direction=Request,Status=Ok                                    2,582
    orleans-messaging-processing-dispatcher-received (Count / 1        1,271
        Context=Grain,Direction=Request                                1,291
        Context=None,Direction=Request                                 1,291
    orleans-messaging-processing-ima-enqueued (Count / 1 sec)          5,113
```

For more information, see [Investigate performance counters (dotnet-counters)](../../../core/diagnostics/dotnet-counters.md).

### Prometheus

There are various third-party metrics providers that you can use with Orleans. One popular example is [Prometheus](https://prometheus.io), which can be used to collect metrics from your app with OpenTelemetry.

To use OpenTelemetry and Prometheus with Orleans, call the following `IServiceCollection` extension method:

```csharp
builder.Services.AddOpenTelemetry()
    .WithMetrics(metrics =>
    {
        metrics
            .AddPrometheusExporter()
            .AddMeter("Microsoft.Orleans");
    });
```

> [!IMPORTANT]
> Both the [OpenTelemetry.Exporter.Prometheus](https://www.nuget.org/packages/OpenTelemetry.Exporter.Prometheus) and [OpenTelemetry.Exporter.Prometheus.AspNetCore](https://www.nuget.org/packages/OpenTelemetry.Exporter.Prometheus.AspNetCore) NuGet packages are currently in preview as release candidates. They're not recommended for production use.

The `AddPrometheusExporter` method ensures that the `PrometheusExporter` is added to the `builder`. Orleans makes use of a <xref:System.Diagnostics.Metrics.Meter> named `"Microsoft.Orleans"` to create <xref:System.Diagnostics.Metrics.Counter%601> instances for many Orleans-specific metrics. The `AddMeter` method is used to specify the name of the meter to subscribe to, in this case `"Microsoft.Orleans"`.

After the exporter has been configured, and your app has been built, you must call `MapPrometheusScrapingEndpoint` on the `IEndpointRouteBuilder` (the `app` instance) to expose the metrics to Prometheus. For example:

```csharp
WebApplication app = builder.Build();

app.MapPrometheusScrapingEndpoint();
app.Run();
```

## Distributed tracing

Distributed tracing is a set of tools and practices to monitor and troubleshoot distributed applications. Distributed tracing is a key component of observability, and it's a critical tool for developers to understand the behavior of their apps. Orleans also supports distributed tracing with [OpenTelemetry](https://opentelemetry.io).

Regardless of the distributed tracing exporter you choose, you call:

- <xref:Orleans.Hosting.CoreHostingExtensions.AddActivityPropagation(Orleans.Hosting.ISiloBuilder)>: which enables distributed tracing for the silo.
- <xref:Orleans.Hosting.ClientBuilderExtensions.AddActivityPropagation(Orleans.Hosting.IClientBuilder)>: which enables distributed tracing for the client.

Referring back to the [Orleans GPS Tracker sample app](/samples/dotnet/samples/orleans-gps-device-tracker-sample), you can use the [Zipkin](https://zipkin.io) distributed tracing system to monitor the app by updating the _Program.cs_. To use OpenTelemetry and Zipkin with Orleans, call the following `IServiceCollection` extension method:

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing =>
    {
        // Set a service name
        tracing.SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName: "GPSTracker", serviceVersion: "1.0"));

        tracing.AddSource("Microsoft.Orleans.Runtime");
        tracing.AddSource("Microsoft.Orleans.Application");

        tracing.AddZipkinExporter(zipkin =>
        {
            zipkin.Endpoint = new Uri("http://localhost:9411/api/v2/spans");
        });
    });
```

> [!IMPORTANT]
> The [OpenTelemetry.Exporter.Zipkin](https://www.nuget.org/packages/OpenTelemetry.Exporter.Zipkin) NuGet package is currently in preview as a release candidate. It is not recommended for production use.

The Zipkin trace is shown in the Jaeger UI (which is an alternative to Zipkin but uses the same data format):

:::image type="content" source="../media/jaeger-ui.png" lightbox="../media/jaeger-ui.png" alt-text="Orleans GPS Tracker sample app: Jaeger UI trace.":::

For more information, see [Distributed tracing](../../../core/diagnostics/distributed-tracing.md).

:::zone-end

<!-- markdownlint-disable MD044 -->
:::zone target="docs" pivot="orleans-3-x"
<!-- markdownlint-enable MD044 -->

Orleans outputs its runtime statistics and metrics through the <xref:Orleans.Runtime.ITelemetryConsumer> interface. The application can register one or more telemetry consumers for their silos and clients, to receive statistics and metrics that the Orleans runtime periodically publishes. These can be consumers for popular telemetry analytics solutions or custom ones for any other destination and purpose. Three telemetry consumers are currently included in the Orleans codebase.

They're released as separate NuGet packages:

- `Microsoft.Orleans.OrleansTelemetryConsumers.AI` for publishing to [Azure Application Insights](/azure/azure-monitor/app/app-insights-overview).

- `Microsoft.Orleans.OrleansTelemetryConsumers.Counters` for publishing to Windows performance counters. The Orleans runtime continually updates many them. The _CounterControl.exe_ tool, included in the [`Microsoft.Orleans.CounterControl`](https://www.nuget.org/packages/Microsoft.Orleans.CounterControl/) NuGet package, helps register necessary performance counter categories. It has to run with elevated privileges. The performance counters can be monitored using any of the standard monitoring tools.

- `Microsoft.Orleans.OrleansTelemetryConsumers.NewRelic`, for publishing to [New Relic](https://newrelic.com/).

To configure your silo and client to use telemetry consumers, silo configuration code looks like this:

```csharp
var siloHostBuilder = new HostBuilder()
    .UseOrleans(c =>
    {
        c.AddApplicationInsightsTelemetryConsumer("INSTRUMENTATION_KEY");
    });

```

Client configuration code look like this:

```csharp
var clientBuilder = new ClientBuilder();
clientBuilder.AddApplicationInsightsTelemetryConsumer("INSTRUMENTATION_KEY");
```

To use a custom defined <xref:Orleans.Runtime.Configuration.TelemetryConfiguration> (which may have <xref:Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.TelemetryProcessors>, <xref:Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration.TelemetrySinks>, and so on), silo configuration code looks like this:

```csharp
var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
var siloHostBuilder = new HostBuilder()
    .UseOrleans(c =>
    {
        c.AddApplicationInsightsTelemetryConsumer(telemetryConfiguration);
    });
```

Client configuration code look like this:

```csharp
var clientBuilder = new ClientBuilder();
var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
clientBuilder.AddApplicationInsightsTelemetryConsumer(telemetryConfiguration);
```

:::zone-end

## See also

- [Logging in .NET](../../../core/extensions/logging.md)
- [.NET metrics](../../../core/diagnostics/metrics.md)
- [Investigate performance counters (dotnet-counters)](../../../core/diagnostics/dotnet-counters.md)
- [.NET distributed tracing](../../../core/diagnostics/distributed-tracing.md)
