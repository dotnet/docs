---
title: Creating Metrics
description: How to add new metrics to a .NET library or application
ms.topic: tutorial
ms.date: 10/11/2023
---

# Creating metrics

**This article applies to: ✔️** .NET Core 6 and later versions **✔️** .NET Framework 4.6.1 and later versions

.NET applications can be instrumented using the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> APIs to track
important metrics. Some metrics are included in standard .NET libraries, but you may want to add new custom metrics that are relevant for
your applications and libraries. In this tutorial, you will add new metrics and understand what types of metrics are available.

> [!NOTE]
> .NET has some older metric APIs, namely [EventCounters](event-counters.md) and <xref:System.Diagnostics.PerformanceCounter?displayProperty=nameWithType>,
> that are not covered here. To learn more about these alternatives, see [Compare metric APIs](compare-metric-apis.md).

## Create a custom metric

**Prerequisites**: [.NET Core 6 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version

Create a new console application that references the [System.Diagnostics.DiagnosticSource NuGet package](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource/)
version 8 or greater. Applications that target .NET 8+ include this reference by default. Then, update the code in `Program.cs` to match:

```dotnetcli
> dotnet new console
> dotnet add package System.Diagnostics.DiagnosticSource
```

```csharp
using System;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.Store");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>("hatco.store.hats_sold");

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

The <xref:System.Diagnostics.Metrics.Meter?displayProperty=nameWithType> type is the entry point for a library to create a named group of instruments. Instruments
record the numeric measurements that are needed to calculate metrics. Here we used <xref:System.Diagnostics.Metrics.Meter.CreateCounter%2A> to create a Counter
instrument named "hatco.store.hats_sold". During each pretend transaction, the code calls <xref:System.Diagnostics.Metrics.Counter`1.Add%2A> to record the measurement of hats
that were sold, 4 in this case. The "hatco.store.hats_sold" instrument implicitly defines some metrics that could be computed from these measurements, such as the total number
of hats sold or hats sold/sec. Ultimately it is up to metric collection tools to determine which metrics to compute and how to perform those computations, but each
instrument has some default conventions that convey the developer's intent. For Counter instruments, the convention is that collection tools show the total count and/or
the rate at which the count is increasing.

The generic parameter `int` on `Counter<int>` and `CreateCounter<int>(...)` defines that this counter must be able to store values up to <xref:System.Int32.MaxValue?displayProperty=nameWithType>. You can use
any of `byte`, `short`, `int`, `long`, `float`, `double`, or `decimal` depending on the size of data you need to store and whether fractional values are needed.

Run the app and leave it running for now. We will view the metrics next.

```dotnetcli
> dotnet run
Press any key to exit
```

### Best practices

- For code that is not designed for use in a Dependency Injection (DI) container, create the Meter once and store it in a static variable. For usage in DI-aware libraries static variables are
considered an anti-pattern and the [DI example](#get-a-meter-via-dependency-injection) below shows a more idiomatic approach. Each library or library subcomponent can
(and often should) create its own <xref:System.Diagnostics.Metrics.Meter>. Consider creating a new Meter rather than reusing an existing one if you anticipate
app developers would appreciate being able to easily enable and disable the groups of metrics separately.

- The name passed to the <xref:System.Diagnostics.Metrics.Meter> constructor should be unique to distinguish it from other Meters. We recommend
[OpenTelemetry naming guidelines](https://github.com/open-telemetry/semantic-conventions/blob/main/docs/general/metrics.md#general-guidelines),
which use dotted hierarchical names. Assembly names or namespace names for code being instrumented are usually a good choice. If an assembly adds instrumentation
for code in a second, independent assembly, the name should be based on the assembly that defines the Meter, not the assembly whose code is being instrumented.

- .NET doesn't enforce any naming scheme for Instruments, but we recommend following
[OpenTelemetry naming guidelines](https://github.com/open-telemetry/semantic-conventions/blob/main/docs/general/metrics.md#general-guidelines), which use lowercase dotted hierarchical names
and an underscore ('_') as the separator between multiple words in the same element. Not all metric tools preserve the Meter name as part of the final metric name, so it's beneficial
to make the instrument name globally unique on its own.

  Example instrument names:

  - `contoso.ticket_queue.duration`
  - `contoso.reserved_tickets`
  - `contoso.purchased_tickets`

- The APIs to create instruments and record measurements are thread-safe. In .NET libraries, most instance methods require synchronization when
invoked on the same object from multiple threads, but that's not needed in this case.

- The Instrument APIs to record measurements (<xref:System.Diagnostics.Metrics.Counter%601.Add%2A> in this example) typically run in <10 ns when no data is being
collected, or tens to hundreds of nanoseconds when measurements are being collected by a high-performance collection library or tool. This allows these APIs to be used liberally
in most cases, but take care for code that is extremely performance sensitive.

### View the new metric

There are many options to store and view metrics. This tutorial uses the [dotnet-counters](dotnet-counters.md) tool, which is useful for ad-hoc analysis. You can also see
the [metrics collection tutorial](metrics-collection.md) for other alternatives. If the [dotnet-counters](dotnet-counters.md) tool is not already installed, use the SDK
to install it:

```dotnetcli
> dotnet tool update -g dotnet-counters
You can invoke the tool using the following command: dotnet-counters
Tool 'dotnet-counters' (version '7.0.430602') was successfully installed.
```

While the example app is still running, use dotnet-counters to monitor the new counter:

```dotnetcli
> dotnet-counters monitor -n metric-demo.exe --counters HatCo.Store
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.Store]
    hatco.store.hats_sold (Count / 1 sec)                          4
```

As expected, you can see that HatCo store is steadily selling 4 hats each second.

## Get a Meter via dependency injection

In the previous example, the Meter was obtained by constructing it with `new` and assigning it to a static field. Using statics this way is not a good approach when using dependency
injection (DI). In code that uses DI, such as ASP.NET Core or apps with [Generic Host](../extensions/generic-host.md), create the Meter object using
<xref:System.Diagnostics.Metrics.IMeterFactory>. Starting in .NET 8, hosts will automatically register <xref:System.Diagnostics.Metrics.IMeterFactory> in the service container
or you can manually register the type in any <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> by calling <xref:Microsoft.Extensions.DependencyInjection.MetricsServiceExtensions.AddMetrics%2A>.
The meter factory integrates metrics with DI, keeping Meters in different service collections isolated from each other even if they use an identical name. This is
especially useful for testing so that multiple tests running in parallel only observe measurements produced from within the same test case.

To obtain a Meter in a type designed for DI, add an <xref:System.Diagnostics.Metrics.IMeterFactory> parameter to the constructor, then call
<xref:System.Diagnostics.Metrics.MeterFactoryExtensions.Create%2A>. This example shows using IMeterFactory in an ASP.NET Core app.

Define a type to hold the instruments:

```cs
public class HatCoMetrics
{
    private readonly Counter<int> _hatsSold;

    public HatCoMetrics(IMeterFactory meterFactory)
    {
        var meter = meterFactory.Create("HatCo.Store");
        _hatsSold = meter.CreateCounter<int>("hatco.store.hats_sold");
    }

    public void HatsSold(int quantity)
    {
        _hatsSold.Add(quantity);
    }
}
```

Register the type with DI container in `Program.cs`.

```cs
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<HatCoMetrics>();
```

Inject the metrics type and record values where needed. Because the metrics type is registered in DI, it can be used with MVC controllers, minimal APIs, or any other type that is created by DI:

```cs
app.MapPost("/complete-sale", ([FromBody] SaleModel model, HatCoMetrics metrics) =>
{
    // ... business logic such as saving the sale to a database ...

    metrics.HatsSold(model.QuantitySold);
});
```

## Types of instruments

So far we've only demonstrated a <xref:System.Diagnostics.Metrics.Counter`1> instrument, but there are more instrument types available. Instruments differ
in two ways:

- **Default metric computations** - Tools that collect and analyze the instrument measurements will compute different default metrics depending on the instrument.
- **Storage of aggregated data** - Most useful metrics need data to be aggregated from many measurements. One option is the caller provides individual measurements
  at arbitrary times and the collection tool manages the aggregation. Alternatively, the caller can manage the aggregate measurements and provide them on-demand in a callback.

Types of instruments currently available:

- **Counter** (<xref:System.Diagnostics.Metrics.Meter.CreateCounter%2A>) - This instrument tracks a value that increases over time and the caller reports the
  increments using <xref:System.Diagnostics.Metrics.Counter%601.Add%2A>. Most tools will calculate the total and the rate of change in the total. For tools that only show
  one thing, the rate of change is recommended. For example, assume that the caller invokes `Add()` once each second with successive values 1, 2, 4, 5, 4, 3. If the collection
  tool updates every three seconds, then the total after three seconds is 1+2+4=7 and the total after six seconds is 1+2+4+5+4+3=19. The rate of change is the
  (current_total - previous_total), so at three seconds the tool reports 7-0=7, and after six seconds, it reports 19-7=12.

- **UpDownCounter** (<xref:System.Diagnostics.Metrics.Meter.CreateUpDownCounter%2A>) - This instrument tracks a value that may increase or decrease over time. The caller reports the
  increments and decrements using <xref:System.Diagnostics.Metrics.UpDownCounter%601.Add%2A>. For example, assume that the caller invokes `Add()` once each second with successive
  values 1, 5, -2, 3, -1, -3. If the collection tool updates every three seconds, then the total after three seconds is 1+5-2=4 and the total after six seconds is 1+5-2+3-1-3=3.

- **ObservableCounter** (<xref:System.Diagnostics.Metrics.Meter.CreateObservableCounter%2A>) - This instrument is similar to Counter except that the caller is now responsible
  for maintaining the aggregated total. The caller provides a callback delegate when the ObservableCounter is created and the callback is invoked whenever tools need to observe
  the current total. For example, if a collection tool updates every three seconds, then the callback function will also be invoked every three seconds. Most tools will have both
  the total and rate of change in the total available. If only one can be shown, rate of change is recommended. If the callback returns 0 on the initial call, 7 when it is called
  again after three seconds, and 19 when called after six seconds, then the tool will report those values unchanged as the totals. For rate of change, the tool will show 7-0=7
  after three seconds and 19-7=12 after six seconds.

- **ObservableUpDownCounter** (<xref:System.Diagnostics.Metrics.Meter.CreateObservableUpDownCounter%2A>) - This instrument is similar to UpDownCounter except that the caller is now responsible
  for maintaining the aggregated total. The caller provides a callback delegate when the ObservableUpDownCounter is created and the callback is invoked whenever tools need to observe
  the current total. For example, if a collection tool updates every three seconds, then the callback function will also be invoked every three seconds. Whatever value is returned by
  the callback will be shown in the collection tool unchanged as the total.

- **ObservableGauge** (<xref:System.Diagnostics.Metrics.Meter.CreateObservableGauge%2A>) - This instrument allows the caller to provide a callback where the measured value
  is passed through directly as the metric. Each time the collection tool updates, the callback is invoked, and whatever value is returned by the callback is displayed in
  the tool.

- **Histogram** (<xref:System.Diagnostics.Metrics.Meter.CreateHistogram%2A>) - This instrument tracks the distribution of measurements. There isn't a single canonical way to
  describe a set of measurements, but tools are recommended to use histograms or computed percentiles. For example, assume the caller invoked
  <xref:System.Diagnostics.Metrics.Histogram%601.Record%2A> to record these measurements during the collection tool's update interval: 1,5,2,3,10,9,7,4,6,8. A collection tool
  might report that the 50th, 90th, and 95th percentiles of these measurements are 5, 9, and 9 respectively.

### Best practices when selecting an instrument type

- For counting things, or any other value that solely increases over time, use Counter or ObservableCounter. Choose between Counter and ObservableCounter depending on which
  is easier to add to the existing code: either an API call for each increment operation, or a callback that will read the current total from a variable the code maintains. In
  extremely hot code paths where performance is important and using <xref:System.Diagnostics.Metrics.Counter%601.Add%2A> would create more than one million calls per second per thread, using
  ObservableCounter may offer more opportunity for optimization.

- For timing things, Histogram is usually preferred. Often it's useful to understand the tail of these distributions (90th, 95th, 99th percentile) rather than averages or
  totals.

- Other common cases, such as cache hit rates or sizes of caches, queues, and files are usually well suited for `UpDownCounter` or `ObservableUpDownCounter`.
  Choose between them depending on which is easier to add to the existing code: either an API call for each increment and decrement operation or a callback that will read the current value from
  a variable the code maintains.

> [!NOTE]
> If you're using an older version of .NET or a DiagnosticSource NuGet package that doesn't support `UpDownCounter` and `ObservableUpDownCounter` (before version 7), `ObservableGauge` is
> often a good substitute.

### Example of different instrument types

Stop the example process started previously, and replace the example code in `Program.cs` with:

```csharp
using System;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.Store");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>("hatco.store.hats_sold");
    static Histogram<double> s_orderProcessingTime = s_meter.CreateHistogram<double>("hatco.store.order_processing_time");
    static int s_coatsSold;
    static int s_ordersPending;

    static Random s_rand = new Random();

    static void Main(string[] args)
    {
        s_meter.CreateObservableCounter<int>("hatco.store.coats_sold", () => s_coatsSold);
        s_meter.CreateObservableGauge<int>("hatco.store.orders_pending", () => s_ordersPending);

        Console.WriteLine("Press any key to exit");
        while(!Console.KeyAvailable)
        {
            // Pretend our store has one transaction each 100ms that each sell 4 hats
            Thread.Sleep(100);
            s_hatsSold.Add(4);

            // Pretend we also sold 3 coats. For an ObservableCounter we track the value in our variable and report it
            // on demand in the callback
            s_coatsSold += 3;

            // Pretend we have some queue of orders that varies over time. The callback for the orders_pending gauge will report
            // this value on-demand.
            s_ordersPending = s_rand.Next(0, 20);

            // Last we pretend that we measured how long it took to do the transaction (for example we could time it with Stopwatch)
            s_orderProcessingTime.Record(s_rand.Next(0.005, 0.015));
        }
    }
}
```

Run the new process and use dotnet-counters as before in a second shell to view the metrics:

```dotnetcli
> dotnet-counters monitor -n metric-demo.exe --counters HatCo.Store
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.Store]
    hatco.store.coats_sold (Count / 1 sec)                                27
    hatco.store.hats_sold (Count / 1 sec)                                 36
    hatco.store.order_processing_time
        Percentile=50                                                      0.012
        Percentile=95                                                      0.014
        Percentile=99                                                      0.014
    hatco.store.orders_pending                                             5
```

This example uses some randomly generated numbers so your values will vary a bit. You can see that `hatco.store.hats_sold` (the Counter) and
`hatco.store.coats_sold` (the ObservableCounter) both show up as a rate. The ObservableGauge, `hatco.store.orders_pending`, appears
as an absolute value. Dotnet-counters renders Histogram instruments as three percentile statistics (50th, 95th, and 99th) but other tools may
summarize the distribution differently or offer more configuration options.

### Best practices

- Histograms tend to store a lot more data in memory than other metric types, however, the exact memory usage is determined by the collection tool being used.
  If you're defining a large number (>100) of Histogram metrics, you may need to give users guidance not to enable them all at the same time, or to configure their tools to save
  memory by reducing precision. Some collection tools may have hard limits on the number of concurrent Histograms they will monitor to prevent excessive memory use.

- Callbacks for all observable instruments are invoked in sequence, so any callback that takes a long time can delay or prevent all metrics from being collected. Favor
  quickly reading a cached value, returning no measurements, or throwing an exception over performing any potentially long-running or blocking operation.

- The <xref:System.Diagnostics.Metrics.Meter.CreateObservableGauge%2A> and <xref:System.Diagnostics.Metrics.Meter.CreateObservableCounter%2A> functions do return an
  instrument object, but in most cases you don't need to save it in a variable because no further interaction with the object is needed. Assigning it to a static variable
  as we did for the other instruments is legal but error prone, because C# static initialization is lazy and the variable is usually never referenced. Here is an example
  of the problem:

```csharp
using System;
using System.Diagnostics.Metrics;

class Program
{
    // BEWARE! Static initializers only run when code in a running method refers to a static variable.
    // These statics will never be initialized because none of them were referenced in Main().
    //
    static Meter s_meter = new Meter("HatCo.Store");
    static ObservableCounter<int> s_coatsSold = s_meter.CreateObservableCounter<int>("hatco.store.coats_sold", () => s_rand.Next(1,10));
    static Random s_rand = new Random();

    static void Main(string[] args)
    {
        Console.ReadLine();
    }
}
```

## Descriptions and units

Instruments can specify optional descriptions and units. These values are opaque to all metric calculations but can be shown in collection tool UI
to help engineers understand how to interpret the data. Stop the example process you started previously, and replace the example code in `Program.cs` with:

```csharp
using System;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.Store");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>(name: "hatco.store.hats_sold",
                                                                unit: "{hats}",
                                                                description: "The number of hats sold in our store");

    static void Main(string[] args)
    {
        Console.WriteLine("Press any key to exit");
        while(!Console.KeyAvailable)
        {
            // Pretend our store has a transaction each 100ms that sells 4 hats
            Thread.Sleep(100);
            s_hatsSold.Add(4);
        }
    }
}
```

Run the new process and use dotnet-counters as before in a second shell to view the metrics:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.Store]
    hatco.store.hats_sold ({hats} / 1 sec)                                40
```

dotnet-counters doesn't currently use the description text in the UI, but it does show the unit when it is provided. In this case, you see "{hats}"
has replaced the generic term "Count" that is visible in previous descriptions.

### Best practices

- .NET APIs allow any string to be used as the unit, but we recommend using [UCUM](https://ucum.org/), an international standard for unit names. The curly
braces around "{hats}" is part of the UCUM standard, indicating that it is a descriptive annotation rather than a unit name with a standardized meaning like seconds or bytes.

- The unit specified in the constructor should describe the units appropriate for an individual measurement. This will sometimes differ from the units on the final metric. In this example, each measurement is a number of hats, so "{hats}" is the appropriate unit to pass in the constructor. The collection tool calculated a rate and derived on its own that the appropriate unit for the calculated metric is {hats}/sec.

- When recording measurements of time, prefer units of seconds recorded as a floating point or double value.

## Multi-dimensional metrics

Measurements can also be associated with key-value pairs called tags that allow data to be categorized for analysis. For example, HatCo might want to record not
only the number of hats that were sold, but also which size and color they were. When analyzing the data later, HatCo engineers can break out the totals by
size, color, or any combination of both.

Counter and Histogram tags can be specified in overloads of the <xref:System.Diagnostics.Metrics.Counter%601.Add%2A> and
<xref:System.Diagnostics.Metrics.Histogram%601.Record%2A> that take one or more `KeyValuePair` arguments. For example:

```csharp
s_hatsSold.Add(2,
               new KeyValuePair<string, object>("product.color", "red"),
               new KeyValuePair<string, object>("product.size", 12));

```

Replace the code of `Program.cs` and rerun the app and dotnet-counters as before:

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.Store");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>("hatco.store.hats_sold");

    static void Main(string[] args)
    {
        Console.WriteLine("Press any key to exit");
        while(!Console.KeyAvailable)
        {
            // Pretend our store has a transaction, every 100ms, that sells two size 12 red hats, and one size 19 blue hat.
            Thread.Sleep(100);
            s_hatsSold.Add(2,
                           new KeyValuePair<string,object>("product.color", "red"),
                           new KeyValuePair<string,object>("product.size", 12));
            s_hatsSold.Add(1,
                           new KeyValuePair<string,object>("product.color", "blue"),
                           new KeyValuePair<string,object>("product.size", 19));
        }
    }
}
```

Dotnet-counters now shows a basic categorization:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.Store]
    hatco.store.hats_sold (Count / 1 sec)
        product.color=blue,product.size=19                                 9
        product.color=red,product.size=12                                 18

```

For ObservableCounter and ObservableGauge, tagged measurements can be provided in the callback passed to the constructor:

```csharp
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.Store");

    static void Main(string[] args)
    {
        s_meter.CreateObservableGauge<int>("hatco.store.orders_pending", GetOrdersPending);
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }

    static IEnumerable<Measurement<int>> GetOrdersPending()
    {
        return new Measurement<int>[]
        {
            // pretend these measurements were read from a real queue somewhere
            new Measurement<int>(6, new KeyValuePair<string,object>("customer.country", "Italy")),
            new Measurement<int>(3, new KeyValuePair<string,object>("customer.country", "Spain")),
            new Measurement<int>(1, new KeyValuePair<string,object>("customer.country", "Mexico")),
        };
    }
}
```

When run with dotnet-counters as before, the result is:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.Store]
    hatco.store.orders_pending
        customer.country=Italy                                             6
        customer.country=Mexico                                            1
        customer.country=Spain                                             3
```

### Best practices

- Although the API allows any object to be used as the tag value, numeric types and strings are anticipated by collection tools. Other types may or may not be
  supported by a given collection tool.

- We recommend tag names follow the [OpenTelemetry naming guidelines](https://github.com/open-telemetry/semantic-conventions/blob/main/docs/general/metrics.md#general-guidelines),
  which use lowercase dotted hierarchal names with '_' characters to separate multiple words in the same element. If tag names are reused in different metrics or other telemetry
  records, then they should have the same meaning and set of legal values everywhere they are used.

  Example tag names:

  - `customer.country`
  - `store.payment_method`
  - `store.purchase_result`

- Beware of having very large or unbounded combinations of tag values being recorded in practice. Although the .NET API implementation can handle it, collection tools will
  likely allocate storage for metric data associated with each tag combination and this could become very large. For example, it's fine if HatCo has 10 different
  hat colors and 25 hat sizes for up to 10*25=250 sales totals to track. However, if HatCo added a third tag that's a CustomerID for the sale and they sell to 100
  million customers worldwide, now there are now likely to be billions of different tag combinations being recorded. Most metric collection tools will either drop data
  to stay within technical limits or there can be large monetary costs to cover the data storage and processing. The implementation of each collection tool will determine
  its limits, but likely less than 1000 combinations for one instrument is safe. Anything above 1000 combinations will require the collection tool to apply filtering or be engineered to operate at a high scale.
  Histogram implementations tend to use far more memory than other metrics, so safe limits could be 10-100 times lower. If you anticipate a large number of unique tag combinations,
  then logs, transactional databases, or big data processing systems may be more appropriate solutions to operate at the needed scale.

- For instruments that will have very large numbers of tag combinations, prefer using a smaller storage type to help reduce memory overhead. For example, storing the `short` for
  a `Counter<short>` only occupies 2 bytes per tag combination, whereas a `double` for `Counter<double>` occupies 8 bytes per tag combination.

- Collection tools are encouraged to optimize for code that specifies the same set of tag names in the same order for each call to record measurements on the
  same instrument. For high-performance code that needs to call <xref:System.Diagnostics.Metrics.Counter%601.Add%2A> and <xref:System.Diagnostics.Metrics.Histogram%601.Record%2A>
  frequently, prefer using the same sequence of tag names for each call.

- The .NET API is optimized to be allocation-free for <xref:System.Diagnostics.Metrics.Counter%601.Add%2A> and <xref:System.Diagnostics.Metrics.Histogram%601.Record%2A> calls
  with three or fewer tags specified individually. To avoid allocations with larger numbers of tags, use <xref:System.Diagnostics.TagList>. In general,
  the performance overhead of these calls increases as more tags are used.

> [!NOTE]
> OpenTelemetry refers to tags as 'attributes'. These are two different names for the same functionality.

## Test custom metrics

Its possible to test any custom metrics you add using <xref:Microsoft.Extensions.Diagnostics.Metrics.Testing.MetricCollector%601>. This type makes it easy to record the measurements from specific instruments and assert the values were correct.

### Test with dependency injection

The following code shows an example test case for code components that use dependency injection and IMeterFactory.

```csharp
public class MetricTests
{
    [Fact]
    public void SaleIncrementsHatsSoldCounter()
    {
        // Arrange
        var services = CreateServiceProvider();
        var metrics = services.GetRequiredService<HatCoMetrics>();
        var meterFactory = services.GetRequiredService<IMeterFactory>();
        var collector = new MetricCollector<int>(meterFactory, "HatCo.Store", "hatco.store.hats_sold");

        // Act
        metrics.HatsSold(15);

        // Assert
        var measurements = collector.GetMeasurementSnapshot();
        Assert.Equal(1, measurements.Count);
        Assert.Equal(15, measurements[0].Value);
    }

    // Setup a new service provider. This example creates the collection explicitly but you might leverage
    // a host or some other application setup code to do this as well.
    private static IServiceProvider CreateServiceProvider()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMetrics();
        serviceCollection.AddSingleton<HatCoMetrics>();
        return serviceCollection.BuildServiceProvider();
    }
}
```

Each MetricCollector object records all measurements for one Instrument. If you need to verify measurements from multiple instruments, create one MetricCollector for each one.

### Test without dependency injection

It is also possible to test code that uses a shared global Meter object in a static field, but make sure such tests are configured not to run in parallel. Because the
Meter object is being shared, MetricCollector in one test will observe the measurements created from any other tests running in parallel.

```csharp
class HatCoMetricsWithGlobalMeter
{
    static Meter s_meter = new Meter("HatCo.Store");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>("hatco.store.hats_sold");

    public void HatsSold(int quantity)
    {
        s_hatsSold.Add(quantity);
    }
}

public class MetricTests
{
    [Fact]
    public void SaleIncrementsHatsSoldCounter()
    {
        // Arrange
        var metrics = new HatCoMetricsWithGlobalMeter();
        // Be careful specifying scope=null. This binds the collector to a global Meter and tests
        // that use global state should not be configured to run in parallel.
        var collector = new MetricCollector<int>(null, "HatCo.Store", "hatco.store.hats_sold");

        // Act
        metrics.HatsSold(15);

        // Assert
        var measurements = collector.GetMeasurementSnapshot();
        Assert.Equal(1, measurements.Count);
        Assert.Equal(15, measurements[0].Value);
    }
}
```
