---
title: Application Performance Management - gRPC for WCF Developers
description: Logging, metrics and tracing for ASP.NET Core gRPC applications
author: markrendle
ms.date: 09/02/2019
---

# Application Performance Management

In modern production environments like Kubernetes, it is very important to be able to monitor applications to ensure they are running optimally. Concerns like logging and metrics have never been more important. ASP.NET Core, including gRPC, has first-class support for producing and managing log messages and metrics data, as well as *tracing* data. This section will explore these areas in more details.

## Logging vs Metrics

Before looking at the implementation details, it is necessary to understand the difference between logging and metrics.

Logging is concerned with text messages that record detailed information about things that have happened in the system. Log messages may include exception data like stack traces, or structured data that provides context about the message. Logging output is commonly written to a searchable text store.

Metrics refers to numeric data that is designed to be aggregated and presented using charts and graphs in a dashboard that provides a view of the overall health and performance of an application. Metrics data can also be used to trigger automated alerts when a threshold is exceeded. Examples of metrics data include the time taken to process requests, the number of requests per second being handled by an instance of a service, or the number of failed requests on an instance.

## Logging in ASP.NET Core gRPC

ASP.NET Core provides support for logging out-of-the-box, in the form of the [Microsoft.Extensions.Logging package](https://www.nuget.org/packages/Microsoft.Extensions.Logging). This is included with the Web SDK so there is no need to install it manually.

### Producing log messages

The Logging extension is automatically registered with ASP.NET Core's dependency injection system, so loggers can be specified as a constructor parameter on gRPC service types.

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

The `ILogger<T>` interface is generic so that it can use the fully-qualified name of the class that generated the message as the *Log Category*. There is a non-generic `ILogger` interface that can be created with a custom *Log Category* string, but using the generic version means that categories are consistently applied throughout an application.

Log messages are assigned *levels* indicating their importance, which allows the components writing the log output to various destinations whether to include messages or not. These levels allow developers to generate more log messages while debugging or testing code, and fewer messages in production systems to avoid overwhelming the storage providers.

ASP.NET Core provides six log levels, numbered from `0` to `5` and in ascending order of importance.

| Name | Value | Description |
| ---- | ----- | ----------- |
| Trace | 0 | Messages that are only useful for debugging and may include data that should not be recorded in production environments. Disabled by default. |
| Debug | 1 | Messages that are useful for debugging but do not include sensitive data. |
| Information | 2 | Messages about the general operation of the application. |
| Warning | 3 | Messages indicating abnormal or unexpected events that do not cause errors but may require investigation. |
| Error | 4 | Messages about errors that cause an operation to fail. Usually include `Exception` data. |
| Critical | 5 | Messages indicating problems that require immediate attention, such as loss of database connectivity. |

The level can be specified using the `LogLevel` enum with the `ILogger<T>.Log` method.

```csharp
_logger.Log(LogLevel.Information, "GetStock request received.");
```

There are also extension methods for each of the log levels.

```csharp
_logger.LogTrace("Getting user information for ID '{userId}'", id);
_logger.LogDebug("Connecting to database");
_logger.LogInformation("Running query");
_logger.LogWarning("No records found");
_logger.LogError(exception, "Error reading data");
_logger.LogCritical(exception, "Database not available");
```

### Structured logging

Log files have traditionally been stored as unstructured text data, making them difficult to search in a consistent fashion. *Structured logging* aims to solve this problem by attaching key/value pairs to log entries that can be searched more precisely. ASP.NET Core logging supports structured logging by default; to take advantage of it, you simply need to use a convention when writing log messages.

When using [string interpolation in C#](https://docs.microsoft.com/dotnet/csharp/language-reference/tokens/interpolated) to format log messages, you might write code like the following.

```csharp
_logger.LogError(exception, $"Error opening file '{filePath}'.");
```

This will include the value of the `filePath` variable in the log message, but searching against it as part of the text will be inaccurate, involving regular expressions or wildcards.

To enable structured logging, you can just remove the `$` string interpolation operation from the start of the string literal, and supply the `filePath` variable as an additional parameter to the `LogError` call.

```csharp
_logger.LogError(exception, "Error opening file '{file}'.", filePath);
```

Using this syntax, the logger will format the message the same, but the `filePath` variable will be added as a named value `file` on a structured object passed along with the logs. Logging back-ends that support structured logging, such as [Serilog](https://serilog.net/) or [NLog](https://nlog-project.org/) (as of version 4.5) will write this structured object along with the message, as long as the storage target supports it.

Despite having names, the tokens in the message format string are treated as positional parameters, just like in `string.Format`. The first token is treated as `{0}`, the second as `{1}` and so on. If a token is used more than once, the index of the first occurrence is used.

### Storing log data

Log entries are handled by *Providers*, which write the log messages out to various targets. ASP.NET Core logging provides some simple providers via NuGet packages, all prefixed with `Microsoft.Extensions.Logging`.

| Provider | Description |
| -------- | ----------- |
| Console  | Writes simple messages to standard output |
| Debug    | Writes simple messages to a debugger (e.g. Visual Studio) if any is attached |
| TraceSource | Makes messages available to .NET TraceListener |
| EventSource | Makes messages available to .NET EventListener |
| EventLog | Writes messages to the Windows Event Log |
| AzureAppServices | Writes messages and structured data to Azure "Diagnostic logs" and "Log stream" features |

Writing to other storage systems, like SQL databases, text files, or specialized databases like [Elasticsearch](https://elastic.co), is not natively supported by the core libraries. Support for other platforms can be added using one of the various open source logging libraries available for .NET Core, such as Serilog, NLog or log4net, which have extensions supporting a wide range of logging targets. Refer to the documentation for your preferred library for information on how to configure it to work with ASP.NET Core logging.

## Metrics in ASP.NET Core gRPC

Unlike logging, there is no in-the-box support for producing metrics data in ASP.NET Core. There is an excellent open source library called [App Metrics](https://www.app-metrics.io), which provides an extensive set of types to instrument your code, and additional packages to write metrics to a variety of targets including time-series databases (e.g. Prometheus and InfluxDB), [Azure AppInsights](https://docs.microsoft.com/azure/azure-monitor/app/app-insights-overview) and more. The [App.Metrics.AspNetCore.Mvc](https://www.nuget.org/packages/App.Metrics.AspNetCore.Mvc/) package even adds a comprehensive set of basic metrics automatically generated via integration with the ASP.NET Core framework, and the web site provides templates for displaying those the [Grafana](https://grafana.com/) visualization platform.

More information and full documentation on AppMetrics is available through their web site at [app-metrics.io](https://app-metrics.io).

### Producing metrics

Most metrics platforms support five basic types of metric, outlined in this table.

| Metric type | Description |
| ----------- | ----------- |
| Counter     | Track how often something happens, such as requests, errors, etc. |
| Gauge       | Record a single value that changes over time, such as active connections |
| Histogram   | Measure a distribution of values across arbitrary limits. For example, a histogram could track data set size, counting how many contained <10 records, how many 11-100 and 101-1000, and >1000 records. |
| Meter       | Measure the rate at which an event occurs in various time spans |
| Timer       | Track the duration of events as well as the rate at which it occurs, stored as a histogram |

Using *App Metrics*, an `IMetrics` interface can be obtained via dependency injection and used to record any of these metrics for a gRPC service. For example, the following code would simply count the number of `Get` requests made over time.

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

### Storing and visualizing metrics data

The best way to store metrics data is in a *time-series database*, a specialized data store designed to record numerical data series marked with timestamps. The most popular of these are [Prometheus](https://prometheus.io/) and [InfluxDB](https://www.influxdata.com/products/influxdb-overview/). Microsoft Azure also provides dedicated metrics storage through the [Azure Monitor](https://docs.microsoft.com/azure/azure-monitor/overview) service.

The current go-to solution for visualizing metrics data is [Grafana](https://grafana.com), which works with a wide range of storage providers including Azure Monitor, InfluxDB and Prometheus. Here is an example Grafana dashboard showing metrics from the Linkerd service mesh running the StockData sample.

![Grafana dashboard](images/grafana-screenshot.png)

### Metrics-based alerting

The numerical nature of metrics data means that it is ideally suited to drive alerting systems, notifying developers or support engineers when a value falls outside of some defined tolerance. The platforms already mentioned all provide support for alerting via a range of options, including emails, text messages or in-dashboard visualizations.

## Distributed tracing

*Distributed tracing* is a relatively recent development in monitoring, which has arisen from the increasing use of microservices and distributed architectures. A single request from a client browser, application or device may be broken down into many steps and sub-requests and involve the use of many services across a network. This makes it difficult to correlate log messages and metrics with the specific request that triggered them.

Although it is still a nascent technology area, distributed tracing has grown quickly in popularity and is now supported by the Cloud Native Computing Foundation, with [the Open Tracing standard](https://opentracing.io) effort attempting to provide vendor-neutral libraries for working with backends like [Jaeger](https://www.jaegertracing.io/) and [Elastic APM](https://www.elastic.co/products/apm).

>[!div class="step-by-step"]
<!-->[Next](appendix.md)-->
