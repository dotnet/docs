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

### Orleans meters

Orleans uses the [System.Diagnostics.Metrics](../../../core/diagnostics/compare-metric-apis.md#systemdiagnosticsmetrics) APIs to collect metrics. Orleans categorizes each meter into domain-centric concerns, such as networking, messaging, gateway, and so on. The following subsections describe the meters that Orleans uses.

#### Networking

A collection of networking meters that are used to monitor the networking layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-networking-sockets-closed` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of sockets that have closed. |
| `orleans-networking-sockets-opened` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of sockets that have opened. |

#### Messaging

A collection of messaging meters that are used to monitor the messaging layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-messaging-sent-messages-size` | <xref:System.Diagnostics.Metrics.Histogram%601> | A histogram representing the size of messages in bytes that have been sent. |
| `orleans-messaging-received-messages-size` | <xref:System.Diagnostics.Metrics.Histogram%601> | A histogram representing the size of messages in bytes that have been received. |
| `orleans-messaging-sent-header-size` | <xref:System.Diagnostics.Metrics.ObservableCounter%601> | An observable counter representing the number of header bytes sent. |
| `orleans-messaging-received-header-size` | <xref:System.Diagnostics.Metrics.ObservableCounter%601> | An observable counter representing the number of header bytes received. |
| `orleans-messaging-sent-failed` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of failed sent messages. |
| `orleans-messaging-sent-dropped` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of dropped sent messages. |
| `orleans-messaging-processing-dispatcher-received` | <xref:System.Diagnostics.Metrics.ObservableCounter%601> | An observable counter representing the number dispatcher received messages. |
| `orleans-messaging-processing-dispatcher-processed` | <xref:System.Diagnostics.Metrics.ObservableCounter%601> | An observable counter representing the number dispatcher processed messages. |
| `orleans-messaging-processing-dispatcher-forwarded` | <xref:System.Diagnostics.Metrics.ObservableCounter%601> | An observable counter representing the number dispatcher forwarded messages. |
| `orleans-messaging-processing-ima-received` | <xref:System.Diagnostics.Metrics.ObservableCounter%601> | An observable counter representing the number of incoming messages received. |
| `orleans-messaging-processing-ima-enqueued` | <xref:System.Diagnostics.Metrics.ObservableCounter%601> | An observable counter representing the number of incoming messages enqueued. |
| `orleans-messaging-processing-activation-data` | <xref:System.Diagnostics.Metrics.ObservableGauge%601> | An observable gauge representing all of the processing activation data. |
| `orleans-messaging-pings-sent` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of pings sent. |
| `orleans-messaging-pings-received` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of pings received. |
| `orleans-messaging-pings-reply-received` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of ping replies received. |
| `orleans-messaging-pings-reply-missed` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of ping replies missed. |
| `orleans-messaging-expired"` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of messages that have expired. |
| `orleans-messaging-rejected` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of messages that have been rejected. |
| `orleans-messaging-rerouted` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of messages that have been rerouted. |
| `orleans-messaging-sent-local` | <xref:System.Diagnostics.Metrics.ObservableCounter%601> | An observable counter representing the number of local messages sent. |

#### Gateway

A collection of gateway meters that are used to monitor the gateway layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-gateway-connected-clients` | <xref:System.Diagnostics.Metrics.UpDownCounter%601> | An up/down counter representing the number of connected clients. |
| `orleans-gateway-sent` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of gateway messages sent. |
| `orleans-gateway-received` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of gateway messages received. |
| `orleans-gateway-load-shedding` | <xref:System.Diagnostics.Metrics.Counter%601> | A count of the number of gateway load shedding. |

#### Runtime

A collection of runtime meters that are used to monitor the runtime layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-scheduler-long-running-turns` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-runtime-total-physical-memory` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-runtime-available-memory` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Catalog

A collection of catalog meters that are used to monitor the catalog layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-catalog-activations` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-catalog-activation-working-set` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-catalog-activation-created` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-catalog-activation-destroyed` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-catalog-activation-failed-to-activate` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-catalog-activation-collections` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-catalog-activation-shutdown` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-catalog-activation-non-existent` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-catalog-activation-concurrent-registration-attempts` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Directory

A collection of directory meters that are used to monitor the directory layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-directory-lookups-local-issued` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-lookups-local-successes` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-lookups-full-issued` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-lookups-remote-sent` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-lookups-remote-received` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-lookups-local-directory-issued` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-lookups-local-directory-successes` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-lookups-cache-issued` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-lookups-cache-successes` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-validations-cache-sent` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-validations-cache-received` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-partition-size` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-cache-size` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-ring-size` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-ring-local-portion-distance` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-ring-local-portion-percentage` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-ring-local-portion-average-percentage` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-registrations-single-act-issued` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-registrations-single-act-local` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-registrations-single-act-remote-sent` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-registrations-single-act-remote-received` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-unregistrations-issued` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-unregistrations-local` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-unregistrations-remote-sent` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-unregistrations-remote-received` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-unregistrations-many-issued` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-unregistrations-many-remote-sent` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-directory-unregistrations-many-remote-received` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Consistent ring

A collection of consistent ring meters that are used to monitor the consistent ring layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-consistent-ring-size` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-consistent-ring-range-percentage-local` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-consistent-ring-range-percentage-average` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Watchdog

A collection of watchdog meters that are used to monitor the watchdog layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-watchdog-health-checks` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-watchdog-health-checks-failed` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Client

A collection of client meters that are used to monitor the client layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-client-connected-gateways` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Miscellaneous

A collection of miscellaneous meters that are used to monitor various layers.

| Meter name | Type | Description |
|--|--|--|
| `orleans-grains` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-system-targets` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### App requests

A collection of app request meters that are used to monitor the app request layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-app-requests-latency` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-app-requests-timedout` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Reminders

A collection of reminder meters that are used to monitor the reminder layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-reminders-tardiness` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-reminders-active` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-reminders-ticks-delivered` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Storage

A collection of storage meters that are used to monitor the storage layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-storage-read-errors` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-storage-write-errors` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-storage-clear-errors` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-storage-read-latency` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-storage-write-latency` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-storage-clear-latency` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Streams

A collection of stream meters that are used to monitor the stream layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-streams-pubsub-producers-added` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-pubsub-producers-removed` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-pubsub-producers` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-pubsub-consumers-added` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-pubsub-consumers-removed` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-pubsub-consumers` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-persistent-stream-pulling-agents` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-persistent-stream-messages-read` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-persistent-stream-messages-sent` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-persistent-stream-pubsub-cache-size` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-initialization-failures` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-initialization-duration` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-initialization-exceptions` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-read-failures` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-read-duration` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-read-exceptions` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-shutdown-failures` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-shutdown-duration` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-shutdown-exceptions` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-messages-received` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-oldest-message-enqueue-age` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-newest-message-enqueue-age` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-block-pool-total-memory` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-block-pool-available-memory` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-block-pool-claimed-memory` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-block-pool-released-memory` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-block-pool-allocated-memory` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-size` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-length` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-messages-added` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-messages-purged` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-memory-allocated` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-memory-released` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-oldest-to-newest-duration` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-oldest-age` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-pressure` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-under-pressure` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-streams-queue-cache-pressure-contribution-count` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

#### Transactions

A collection of transaction meters that are used to monitor the transaction layer.

| Meter name | Type | Description |
|--|--|--|
| `orleans-transactions-started` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-transactions-successful` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-transactions-failed` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |
| `orleans-transactions-throttled` | <xref:System.Diagnostics.Metrics.Counter%601> | ... |

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
