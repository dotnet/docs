---
title: Creating Metrics
description: How to add new metrics to a .NET library or application
ms.topic: tutorial
ms.date: 11/04/2021
---

# Creating Metrics

**This article applies to: ✔️** .NET Core 3.1 and later versions **✔️** .NET Framework 4.6.1 and later versions

.NET applications can be instrumented using the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> APIs to track
important metrics. Some metrics are included in standard .NET libraries, but you may want to add new custom metrics that are relevant for
your applications and libraries. In this tutorial, you will add new metrics and understand what types of metrics are available.

> [!NOTE]
> .NET has some older metric APIs, namely [EventCounters](event-counters.md) and <xref:System.Diagnostics.PerformanceCounter?displayProperty=nameWithType>,
> that are not covered here. To learn more about these alternatives, see [Compare metric APIs](compare-metric-apis.md).

## Create a custom metric

**Prerequisites**: [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet) or a later version

Create a new console application that references the [System.Diagnostics.DiagnosticSource NuGet package](https://www.nuget.org/packages/System.Diagnostics.DiagnosticSource/)
version 6 or greater. Applications that target .NET 6+ include this reference by default. Then, update the code in `Program.cs` to match:

```dotnetcli
> dotnet new console
> dotnet add package System.Diagnostics.DiagnosticSource
```

```C#
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

The <xref:System.Diagnostics.Metrics.Meter?displayProperty=nameWithType> type is the entry point for a library to create a named group of instruments. Instruments
record the numeric measurements that are needed to calculate metrics. Here we used <xref:System.Diagnostics.Metrics.Meter.CreateCounter%2A> to create a Counter
instrument named "hats-sold". During each pretend transaction, the code calls <xref:System.Diagnostics.Metrics.Counter`1.Add%2A> to record the measurement of hats
that were sold, 4 in this case. The "hats-sold" instrument implicitly defines some metrics that could be computed from these measurements, such as the total number
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

- Create the Meter once, store it in a static variable or DI container, and use that instance as long as needed. Each library or library subcomponent can
(and often should) create its own <xref:System.Diagnostics.Metrics.Meter>. Consider creating a new Meter rather than reusing an existing one if you anticipate
app developers would appreciate being able to enable and disable the groups of metrics separately.

- The name passed to the <xref:System.Diagnostics.Metrics.Meter> constructor has to be unique to avoid conflicts with any other Meters. Use a dotted hierarichal
name that contains the assembly name and optionally a subcomponent name. If an assembly is adding instrumentation for code in a second, independent assembly, the name
should be based on the assembly that defines the Meter, not the assembly whose code is being instrumented.

- The <xref:System.Diagnostics.Metrics.Meter> constructor version parameter is optional. We recommend that you provide a version in case you release multiple versions
of the library and make changes to the instruments.

- .NET doesn't enforce any naming scheme for metrics, but by convention all the .NET runtime libraries have metric names using '-' if a separator is needed. Other metric
ecosystems have encouraged using '.' or '_' as the separator. Microsoft's suggestion is to use '-' in code and let the metric consumer such as OpenTelemetry or
Prometheus convert to an alternate separator if needed.

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
Tool 'dotnet-counters' (version '5.0.251802') was successfully installed.
```

While the example app is still running, list the running processes in a second shell to determine the process ID:

```dotnetcli
> dotnet-counters ps
     10180 dotnet     C:\Program Files\dotnet\dotnet.exe
     19964 metric-instr E:\temp\metric-instr\bin\Debug\netcoreapp3.1\metric-instr.exe
```

Find the ID for the process name that matches the example app and have dotnet-counters monitor the new counter:

```dotnetcli
> dotnet-counters monitor -p 19964 HatCo.HatStore
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.HatStore]
    hats-sold (Count / 1 sec)                          4
```

As expected, you can see that HatCo store is steadily selling 4 hats each second.

## Types of instruments

In the previous example, we've only demonstrated a <xref:System.Diagnostics.Metrics.Counter`1> instrument, but there are more instrument types available. Instruments differ
in two ways:

- **Default metric computations** - Tools that collect and analyze the instrument measurements will compute different default metrics depending on the instrument.
- **Storage of aggregated data** - Most useful metrics need data to be aggregated from many measurements. One option is the caller provides individual measurements
  at arbitrary times and the collection tool manages the aggregation. Alternatively, the caller can manage the aggregate measurements and provide them on-demand in a callback.

Types of instruments currently available:

- **Counter** (<xref:System.Diagnostics.Metrics.Meter.CreateCounter%2A>) - This instrument conceptually tracks a value that increases over time and the caller reports the
  increments using <xref:System.Diagnostics.Metrics.Counter%601.Add%2A>. Most tools will calculate the total and the rate of change in the total. For tools that only show
  one thing, the rate of change is recommended. For example, assume that the caller invokes `Add()` once each second with successive values 1, 2, 4, 5, 4, 3. If the collection
  tool updates every three seconds, then the total after three seconds is 1+2+4=7 and the total after six seconds is 1+2+4+5+4+3=19. The rate of change is the
  (current_total - previous_total), so at three seconds the tool reports 7-0=7, and after six seconds, it reports 19-7=12.

- **ObservableCounter** (<xref:System.Diagnostics.Metrics.Meter.CreateObservableCounter%2A>) - This instrument is similar to Counter except that the caller is now responsible
  for maintaining the aggregated total. The caller provides a callback delegate when the ObservableCounter is created and the callback is invoked whenever tools need to observe
  the current total. For example, if a collection tool updates every three seconds, then the callback will also be invoked every three seconds. Most tools will have both the total and
  rate of change in the total available. If only one can be shown, rate of change is recommended. If the callback returns 0, 7, and 19 at 0, 3, and 6 seconds respectively, then the
  tool will report those values as the totals. For rate of change, the tool will show 7-0=7 after three seconds and 19-7=12 after six seconds.

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

- Other common cases, such as business metrics, physical sensors, cache hit rates, or sizes of caches, queues, and files are usually well suited for `ObservableGauge`.

> [!NOTE]
> OpenTelemetry also defines an UpDownCounter not currently present in the .NET API. ObservableGauge can usually be substituted by defining a variable to store the running
> total and reporting the value of that variable in the ObservableGauge callback.

### Example of different instrument types

Stop the example process started previously, and replace the example code in `Program.cs` with:

```C#
using System;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.HatStore", "1.0.0");
    static Counter<int> s_hatsSold = s_meter.CreateCounter<int>("hats-sold");
    static Histogram<int> s_orderProcessingTimeMs = s_meter.CreateHistogram<int>("order-processing-time");
    static int s_coatsSold;
    static int s_ordersPending;

    static Random s_rand = new Random();

    static void Main(string[] args)
    {
        s_meter.CreateObservableCounter<int>("coats-sold", () => s_coatsSold);
        s_meter.CreateObservableGauge<int>("orders-pending", () => s_ordersPending);

        Console.WriteLine("Press any key to exit");
        while(!Console.KeyAvailable)
        {
            // Pretend our store has one transaction each 100ms that each sell 4 hats
            Thread.Sleep(100);
            s_hatsSold.Add(4);

            // Pretend we also sold 3 coats. For an ObservableCounter we track the value in our variable and report it
            // on demand in the callback
            s_coatsSold += 3;

            // Pretend we have some queue of orders that varies over time. The callback for the "orders-pending" gauge will report
            // this value on-demand.
            s_ordersPending = s_rand.Next(0, 20);

            // Last we pretend that we measured how long it took to do the transaction (for example we could time it with Stopwatch)
            s_orderProcessingTimeMs.Record(s_rand.Next(5, 15));
        }
    }
}
```

Run the new process and use dotnet-counters as before in a second shell to view the metrics:

```dotnetcli
> dotnet-counters ps
      2992 dotnet     C:\Program Files\dotnet\dotnet.exe
     20508 metric-instr E:\temp\metric-instr\bin\Debug\netcoreapp3.1\metric-instr.exe
> dotnet-counters monitor -p 20508 HatCo.HatStore
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.HatStore]
    coats-sold (Count / 1 sec)                        30
    hats-sold (Count / 1 sec)                         40
    order-processing-time
        Percentile=50                                125
        Percentile=95                                146
        Percentile=99                                146
    orders-pending                                     3
```

This example uses some randomly generated numbers so your values will vary a bit. You can see that `hats-sold` (the Counter) and
`coats-sold` (the ObservableCounter) both show up as a rate. The ObservableGauge, `orders-pending`, appears
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

```C#
using System;
using System.Diagnostics.Metrics;

class Program
{
    // BEWARE! Static initializers only run when code in a running method refers to a static variable.
    // These statics will never be initialized because none of them were referenced in Main().
    //
    static Meter s_meter = new Meter("HatCo.HatStore", "1.0.0");
    static ObservableCounter<int> s_coatsSold = s_meter.CreateObservableCounter<int>("coats-sold", () => s_rand.Next(1,10));
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

```C#
using System;
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

[HatCo.HatStore]
    hats-sold (Hats / 1 sec)                           40
```

dotnet-counters doesn't currently use the description text in the UI, but it does show the unit when it is provided. In this case, you see "Hats"
has replaced the generic term "Count" that is visible in previous descriptions.

### Best practices

The unit specified in the constructor should describe the units appropriate for an individual measurement. This will sometimes differ from the units on the final metric. In this example, each measurement is a number of hats, so "Hats" is the appropriate unit to pass in the constructor. The collection tool calculated a rate and derived on its own that the appropriate unit for the calculated metric is Hats/sec.

## Multi-dimensional metrics

Measurements can also be associated with key-value pairs called tags that allow data to be categorized for analysis. For example, HatCo might want to record not
only the number of hats that were sold, but also which size and color they were. When analyzing the data later, HatCo engineers can break out the totals by
size, color, or any combination of both.

Counter and Histogram tags can be specified in overloads of the <xref:System.Diagnostics.Metrics.Counter%601.Add%2A> and
<xref:System.Diagnostics.Metrics.Histogram%601.Record%2A> that take one or more `KeyValuePair` arguments. For example:

```C#
s_hatsSold.Add(2,
               new KeyValuePair<string, object>("Color", "Red"),
               new KeyValuePair<string, object>("Size", 12));

```

Replace the code of `Program.cs` and rerun the app and dotnet-counters as before:

```C#
using System;
using System.Collections.Generic;
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
            // Pretend our store has a transaction each 100ms that sells 2 red size 12 hats and 1 blue size 19 hat.
            Thread.Sleep(100);
            s_hatsSold.Add(2,
                           new KeyValuePair<string,object>("Color", "Red"),
                           new KeyValuePair<string,object>("Size", 12));
            s_hatsSold.Add(1,
                           new KeyValuePair<string,object>("Color", "Blue"),
                           new KeyValuePair<string,object>("Size", 19));
        }
    }
}
```

Dotnet-counters now shows a basic categorization:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.HatStore]
    hats-sold (Count / 1 sec)
        Color=Blue,Size=19                             9
        Color=Red,Size=12                             18

```

For ObservableCounter and ObservableGauge, tagged measurements can be provided in the callback passed to the constructor:

```C#
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading;

class Program
{
    static Meter s_meter = new Meter("HatCo.HatStore", "1.0.0");

    static void Main(string[] args)
    {
        s_meter.CreateObservableGauge<int>("orders-pending", GetOrdersPending);
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }

    static IEnumerable<Measurement<int>> GetOrdersPending()
    {
        return new Measurement<int>[]
        {
            // pretend these measurements were read from a real queue somewhere
            new Measurement<int>(6, new KeyValuePair<string,object>("Country", "Italy")),
            new Measurement<int>(3, new KeyValuePair<string,object>("Country", "Spain")),
            new Measurement<int>(1, new KeyValuePair<string,object>("Country", "Mexico")),
        };
    }
}
```

When run with dotnet-counters as before, the result is:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[HatCo.HatStore]
    orders-pending
        Country=Italy                                  6
        Country=Mexico                                 1
        Country=Spain                                  3
```

### Best practices

- Although the API allows any object to be used as the tag value, numeric types and strings are anticipated by collection tools. Other types may or may not be
  supported by a given collection tool.

- Beware of having very large or unbounded combinations of tag values being recorded in practice. Although the .NET API implementation can handle it, collection tools will
  likely allocate storage for metric data associated with each tag combination and this could become very large. For example, it's fine if HatCo has 10 different
  hat colors and 25 hat sizes for up to 10*25=250 sales totals to track. However, if HatCo added a third tag that's a CustomerID for the sale and they sell to 100
  million customers worldwide, now there are now likely to be billions of different tag combinations being recorded. Most metric collection tools will either drop data
  to stay within technical limits or there can be large monetary costs to cover the data storage and processing. The implementation of each collection tool will determine
  its limits, but likely less than 1000 combinations for one instrument is safe. Anything above 1000 combinations will require the collection tool to apply filtering or be engineered to operate at high scale.
  Histogram implementations tend to use far more memory than other metrics, so safe limits could be 10-100 times lower. If you anticipate large number of unique tag combinations,
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
> OpenTelemetry refers to tags as 'attributes'. Despite the name, the functionality is the same.
