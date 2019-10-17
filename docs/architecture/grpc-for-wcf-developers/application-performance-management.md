---
title: Application Performance Management - gRPC for WCF Developers
description: Logging, metrics and tracing for ASP.NET Core gRPC applications.
author: markrendle
ms.date: 09/02/2019
---

# Application Performance Management

[!INCLUDE [book-preview](../../../includes/book-preview.md)]

In modern production environments like Kubernetes, it's very important to be able to monitor applications to ensure they're running optimally. Concerns like logging and metrics have never been more important. ASP.NET Core, including gRPC, has first-class support for producing and managing log messages and metrics data, as well as *tracing* data. This section will explore these areas in more details.

## Logging vs Metrics

Before looking at the implementation details, it's necessary to understand the difference between logging and metrics.

Logging is concerned with text messages that record detailed information about things that have happened in the system. Log messages may include exception data like stack traces, or structured data that provides context about the message. Logging output is commonly written to a searchable text store.

Metrics refers to numeric data that is designed to be aggregated and presented using charts and graphs in a dashboard that provides a view of the overall health and performance of an application. Metrics data can also be used to trigger automated alerts when a threshold is exceeded. The following list shows some examples of metrics data:

- Time taken to process requests.
- The number of requests per second being handled by an instance of a service.
- The number of failed requests on an instance.

## Logging in ASP.NET Core gRPC

ASP.NET Core provides built-in support for logging, in the form of the [Microsoft.Extensions.Logging](https://www.nuget.org/packages/Microsoft.Extensions.Logging) NuGet package. The core parts of this library are included with the Web SDK, so there's no need to install it manually. By default, log messages are written to the standard output (the "console") and to any attached debugger. To write logs to persistent external data stores, you may need to import [optional logging sink packages](https://docs.microsoft.com/aspnet/core/fundamentals/logging/?view=aspnetcore-3.0#third-party-logging-providers).

The ASP.NET Core gRPC framework writes detailed diagnostic logging messages to this logging framework so they can be processed/stored along with your application's own messages.

### Produce log messages

The logging extension is automatically registered with ASP.NET Core's dependency injection system, so you can specify loggers as a constructor parameter on gRPC service types.

```csharp
public class StockData : Stocks.StocksBase
{
    private readonly ILogger<StockData> _logger;

    public StockData(ILogger<StockData> logger)
    {
        _logger = logger;
    }
}
```

Many log messages around requests, exceptions, and so on, are provided by the ASP.NET Core and gRPC framework components. Add your own log messages to provide detail and context about application logic rather than lower-level concerns.

For more information about writing log messages and available logging sinks and targets, see the [Logging in .NET Core and ASP.NET Core](https://docs.microsoft.com/aspnet/core/fundamentals/logging/?view=aspnetcore-3.0) article.

## Metrics in ASP.NET Core gRPC

The .NET Core runtime provides a set of components for emitting and observing metrics that includes APIs such as the <xref:System.Diagnostics.Tracing.EventSource> and <xref:System.Diagnostics.Tracing.EventCounter> classes. These APIs can be used to emit basic numeric data that can be consumed by external processes like the [dotnet-counters global tool](https://github.com/dotnet/diagnostics/blob/master/documentation/dotnet-counters-instructions.md), or Event Tracing for Windows. For more information about using `EventCounter` in your own code, see the [EventCounter Introduction](https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.Tracing/documentation/EventCounterTutorial.md) tutorial.

For more advanced metrics and for writing metric data to a wider range of data stores, there's an excellent open-source project called [App Metrics](https://www.app-metrics.io). This suite of libraries provides an extensive set of types to instrument your code. It also offers packages to write metrics to different kinds of targets that include time-series databases, such as Prometheus and InfluxDB, [Azure Application Insights](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview), and more. The [App.Metrics.AspNetCore.Mvc](https://www.nuget.org/packages/App.Metrics.AspNetCore.Mvc/) NuGet package even adds a comprehensive set of basic metrics that are automatically generated via integration with the ASP.NET Core framework, and the web site provides [templates](https://www.app-metrics.io/samples/grafana/) for displaying those metrics with the [Grafana](https://grafana.com/) visualization platform.

For more information and documentation about App Metrics, see the [app-metrics.io](https://app-metrics.io) website.

### Produce metrics

Most metrics platforms support five basic types of metric, outlined in the following table:

| Metric type | Description |
| ----------- | ----------- |
| Counter     | Tracks how often something happens, such as requests, errors, and so on. |
| Gauge       | Records a single value that changes over time, such as active connections. |
| Histogram   | Measures a distribution of values across arbitrary limits. For example, a histogram could track data set size, counting how many contained <10 records, how many 11-100 and 101-1000, and >1000 records. |
| Meter       | Measures the rate at which an event occurs in various time spans. |
| Timer       | Tracks the duration of events and the rate at which it occurs, stored as a histogram. |

Using *App Metrics*, an `IMetrics` interface can be obtained via dependency injection and used to record any of these metrics for a gRPC service. The following example shows how to count the number of `Get` requests made over time:

```csharp
public class StockData : Stocks.StocksBase
{
    private static readonly CounterOptions GetRequestCounter = new CounterOptions
    {
        Name = "StockData_Get_Requests",
        MeasurementUnit = Unit.Calls
    };

    private readonly IStockRepository _repository;
    private readonly IMetrics _metrics;

    public StockData(IStockRepository repository, IMetrics metrics)
    {
        _repository = repository;
        _metrics = metrics;
    }

    public override async Task<GetResponse> Get(GetRequest request, ServerCallContext context)
    {
        _metrics.Measure.Counter.Increment(GetRequestCounter);

        // Serve request...
    }
}
```

### Store and visualize metrics data

The best way to store metrics data is in a *time-series database*, a specialized data store designed to record numerical data series marked with timestamps. The most popular of these databases are [Prometheus](https://prometheus.io/) and [InfluxDB](https://www.influxdata.com/products/influxdb-overview/). Microsoft Azure also provides dedicated metrics storage through the [Azure Monitor](https://docs.microsoft.com/azure/azure-monitor/overview) service.

The current go-to solution for visualizing metrics data is [Grafana](https://grafana.com), which works with a wide range of storage providers including Azure Monitor, InfluxDB and Prometheus. The following image shows an example Grafana dashboard that displays metrics from the Linkerd service mesh running the StockData sample:

![Grafana dashboard](media/application-performance-management/grafana-screenshot.png)

### Metrics-based alerting

The numerical nature of metrics data means that it's ideally suited to drive alerting systems, notifying developers or support engineers when a value falls outside of some defined tolerance. The platforms already mentioned all provide support for alerting via a range of options, including emails, text messages, or in-dashboard visualizations.

## Distributed tracing

*Distributed tracing* is a relatively recent development in monitoring, which has arisen from the increasing use of microservices and distributed architectures. A single request from a client browser, application, or device may be broken down into many steps and sub-requests, and involve the use of many services across a network. This makes it difficult to correlate log messages and metrics with the specific request that triggered them. Distributed tracing applies identifiers to requests that allow logs and metrics to be correlated with a particular operation. This is similar to [WCF's end-to-end tracing](https://docs.microsoft.com/dotnet/framework/wcf/diagnostics/tracing/end-to-end-tracing), but applied across multiple platforms.

Although it's still a nascent technology area, distributed tracing has grown quickly in popularity and is now going through a standardization process. The Cloud Native Computing Foundation created the [the Open Tracing standard](https://opentracing.io), attempting to provide vendor-neutral libraries for working with backends like [Jaeger](https://www.jaegertracing.io/) and [Elastic APM](https://www.elastic.co/products/apm). At the same time, Google created the [OpenCensus project](https://opencensus.io/) to address the same set of problems. These two projects are now being merged into a new project, [OpenTelemetry](https://opentelemetry.io), which aims to be the future industry standard.

### How distributed tracing works

Distributed tracing is based on the concept of *Spans*: named, timed operations that are part of a single *Trace*, which may involve processing on multiple nodes of a system. When a new operation is initiated, a trace is created with a unique identifier. For each sub-operation, a span is created with its own identifier and trace identifier. As the request passes around the system, various components can create *child* spans that include the identifier of their *parent*. A span has a *context*, which contains the trace and span identifiers, as well as useful data in the form of key/value pairs (called *baggage*).

### Distributed tracing with DiagnosticSource

.NET Core has an internal module that maps well to distributed traces and spans: [DiagnosticSource](https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.DiagnosticSource/src/DiagnosticSourceUsersGuide.md#diagnosticsource-users-guide). As well as providing a simple way to produce and consume diagnostics within a process, the `DiagnosticSource` module has the concept of an *Activity*, which is effectively an implementation of a distributed trace, or a span within a trace. The internals of the module take care of parent/child activities, including allocating identifiers. For more information about using the `Activity` type, see the [Activity User Guide on GitHub](https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.DiagnosticSource/src/ActivityUserGuide.md#activity-user-guide)

Because DiagnosticSource is a part of the core framework, it's supported by several core components, including <xref:System.Net.Http.HttpClient>, Entity Framework Core and ASP.NET Core, including explicit support in the gRPC framework. When ASP.NET Core receives a request, it  checks for a pair of HTTP headers matching the [W3C Trace Context](https://www.w3.org/TR/trace-context) standard. If the headers are found, an Activity is started using the identity values and context from the headers. If no headers are found, an Activity is started with generated identity values that match the standard format. Any diagnostics generated by the framework or by application code during the lifetime of this Activity can be tagged with the trace and span identifiers. The `HttpClient` support extends this further by checking for a current Activity on every request and automatically adding the trace headers to the outgoing request.

The ASP.NET Core gRPC client and server libraries include explicit support for DiagnosticSource and Activity, and will create activities and apply and use header information automatically.

> [!NOTE]
> All of this only happens if a *listener* is consuming the diagnostic information. If there's no listener, no diagnostics are written and no activities are created.

### Add your own DiagnosticSources and Activities

Although a good quantity of data is automatically generated by ASP.NET Core, including gRPC, as well as Entity Framework Core and `HttpClient`, you may wish to add your own diagnostics or create explicit spans within your application code. Refer to the [DiagnosticSource User Guide](https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.DiagnosticSource/src/DiagnosticSourceUsersGuide.md#instrumenting-with-diagnosticsourcediagnosticlistener) and [Activity User Guide](https://github.com/dotnet/corefx/blob/master/src/System.Diagnostics.DiagnosticSource/src/ActivityUserGuide.md#activity-usage) for details on how to implement your own diagnostics.

### Store distributed trace data

At the time of writing the OpenTelemetry project is still in the early stages, and only alpha-quality packages are available for .NET applications. The OpenTracing project offers more mature libraries, but these will be superseded by the OpenTelemetry libraries in the future.

The OpenTracing API is described below. If you would prefer to use the newer OpenTelemetry API in your application, refer to the [OpenTelemetry .NET SDK repository on GitHub](https://github.com/open-telemetry/opentelemetry-dotnet).

#### Use the OpenTracing package to store distributed trace data

The [an OpenTracing NuGet package](https://www.nuget.org/packages/OpenTracing/) that supports all OpenTracing-compliant back-ends (which can be used independently of `DiagnosticSource`). There's an additional package from the OpenTracing API Contributions project, [OpenTracing.Contrib.NetCore](https://www.nuget.org/packages/OpenTracing.Contrib.NetCore/), which adds a `DiagnosticSource` listener and writes events and activities to a back-end automatically. Enabling this package is as simple as installing it from NuGet and adding it as a service in your `Startup` class.

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOpenTracing();
    }
}
```

The OpenTracing package is an abstraction layer and as such it requires a back-end-specific implementation. OpenTracing API implementations are available for the following open source back-ends.

| Name | Package | Web site |
| ---- | ------- | -------- |
| Jaeger | [Jaeger](https://www.nuget.org/packages/Jaeger/) | [jaegertracing.io](https://jaegertracing.io) |
| Elastic APM | [Elastic.Apm.NetCoreAll](https://www.nuget.org/packages/Elastic.Apm.NetCoreAll/) | [elastic.co/products/apm](https://www.elastic.co/products/apm) |

For more information on the OpenTracing API for .NET, see the [OpenTracing for C#](https://github.com/opentracing/opentracing-csharp) and the [OpenTracing Contrib C#/.NET Core](https://github.com/opentracing-contrib/csharp-netcore) repositories on GitHub.

>[!div class="step-by-step"]
>[Previous](load-balancing.md)
>[Next](appendix.md)
