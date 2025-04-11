---
title: Source-generated metrics with strongly-typed tags
description: Learn how to use a source generator to create strongly-typed metric tags in .NET, reducing boilerplate and ensuring consistent.
ms.date: 03/07/2025
---

# Source-generated metrics with strongly-typed tags

Modern .NET applications can capture metrics using the <xref:System.Diagnostics.Metrics> API. These metrics often include additional context in the form of key-value pairs called *tags* (sometimes referred to as *dimensions* in telemetry systems). This article shows how to use a compile-time source generator to define **strongly-typed metric tags** (TagNames) and metric recording types and methods. By using strongly-typed tags, you eliminate repetitive boilerplate code and ensure that related metrics share the same set of tag names with compile-time safety. The primary benefit of this approach is improved developer productivity and type safety.

> [!NOTE]
> In the context of metrics, a tag is sometimes also called a "dimension." This article uses "tag" for clarity and consistency with .NET metrics terminology.

## Install the package

To get started, install the [📦 Microsoft.Extensions.Telemetry.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.Telemetry.Abstractions) NuGet package:

### [.NET CLI](#tab/dotnet-cli)

```dotnetcli
dotnet add package Microsoft.Extensions.Telemetry.Abstractions
```

### [PackageReference](#tab/package-reference)

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Telemetry.Abstractions"
                    Version="*" />
</ItemGroup>
```

---

## Tag name defaults and customization

By default, the source generator derives metric tag names from the field and property names of your tag class. In other words, each public field or property in the strongly-typed tag object becomes a tag name by default. You can override this by using the <xref:Microsoft.Extensions.Diagnostics.Metrics.TagNameAttribute> on a field or property to specify a custom tag name. In the examples below, you’ll see both approaches in action.

## Example 1: Basic metric with a single tag

The following example demonstrates a simple counter metric with one tag. In this scenario, we want to count the number of processed requests and categorize them by a `Region` tag:

```csharp
public struct RequestTags
{
    public string Region { get; set; }
}

public static partial class MyMetrics
{
    [Counter<int>(typeof(RequestTags))]
    public static partial RequestCount CreateRequestCount(Meter meter);
}
```

In the code above, `RequestTags` is a strongly-typed tag struct with a single property `Region`. The `CreateRequestCount` method is marked with <xref:Microsoft.Extensions.Diagnostics.Metrics.CounterAttribute`1> where `T` is an `int`, indicating it generates a **Counter** instrument that tracks `int` values. The attribute references `typeof(RequestTags)`, meaning the counter will use the tags defined in `RequestTags` when recording metrics. The source generator will produce a strongly-typed instrument class (named `RequestCount`) with an `Add` method that accepts integer value and `RequestTags` object.

To use the generated metric, create a <xref:System.Diagnostics.Metrics.Meter> and record measurements as shown below:

```csharp
Meter meter = new Meter("MyCompany.MyApp", "1.0");
RequestCount requestCountMetric = MyMetrics.CreateRequestCount(meter);

// Create a tag object with the relevant tag value
var tags = new RequestTags { Region = "NorthAmerica" };

// Record a metric value with the associated tag
requestCountMetric.Add(1, tags);
```

In this usage example, calling `MyMetrics.CreateRequestCount(meter)` creates a counter instrument (via the `Meter`) and returns a `RequestCount` metric object. When you call `requestCountMetric.Add(1, tags)`, the metric system records a count of 1 associated with the tag `Region="NorthAmerica"`. You can reuse the `RequestTags` object or create new ones to record counts for different regions, and the tag name `Region` will consistently be applied to every measurement.

## Example 2: Metric with nested tag objects

For more complex scenarios, you can define tag classes that include multiple tags, nested objects, or even inherited properties. This allows a group of related metrics to share a common set of tags easily. In the next example, we define a set of tag classes and use them for three different metrics:

```csharp
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Diagnostics.Metrics;

public class MetricTags : MetricParentTags
{
    [TagName("Dim1DimensionName")]
    public string? Dim1;                      // custom tag name via attribute

    public Operations Operation { get; set; } // tag name defaults to "Operation"

    public MetricChildTags? ChildTagsObject { get; set; }
}

public enum Operations
{
    Unknown = 0,
    Operation1 = 1,
}

public class MetricParentTags
{
    [TagName("DimensionNameOfParentOperation")]
    public string? ParentOperationName { get; set; }  // custom tag name via attribute

    public MetricTagsStruct ChildTagsStruct { get; set; }
}

public class MetricChildTags
{
    public string? Dim2 { get; set; }  // tag name defaults to "Dim2"
}

public struct MetricTagsStruct
{
    public string Dim3 { get; set; }   // tag name defaults to "Dim3"
}

public static partial class Metric
{
    [Histogram<long>(typeof(MetricTags))]
    public static partial Latency CreateLatency(Meter meter);

    [Counter<long>(typeof(MetricTags))]
    public static partial TotalCount CreateTotalCount(Meter meter);

    [Counter<int>(typeof(MetricTags))]
    public static partial TotalFailures CreateTotalFailures(Meter meter);
}
```

In this example, `MetricTags` is a tag class that inherits from `MetricParentTags` and also contains a nested tag object (`MetricChildTags`) and a nested struct (`MetricTagsStruct`). The tag properties demonstrate both default and customized tag names:

- The `Dim1` field in `MetricTags` has a `[TagName("Dim1DimensionName")]` attribute, so its tag name will be `"Dim1DimensionName"`.
- The `Operation` property has no attribute, so its tag name defaults to `"Operation"`.
- In `MetricParentTags`, the `ParentOperationName` property is overridden with a custom tag name `"DimensionNameOfParentOperation"`.
- The nested `MetricChildTags` class defines a `Dim2` property (no attribute, tag name `"Dim2"`).
- The `MetricTagsStruct` struct defines a `Dim3` field (tag name `"Dim3"`).

All three metric definitions `CreateLatency`, `CreateTotalCount`, and `CreateTotalFailures` use `MetricTags` as their tag object type. This means the generated metric types (`Latency`, `TotalCount`, and `TotalFailures`) will all expect a `MetricTags` instance when recording data. **Each of these metrics will have the same set of tag names:** `Dim1DimensionName`, `Operation`, `Dim2`, `Dim3`, and `DimensionNameOfParentOperation`.

The following code shows how to create and use these metrics in a class:

```csharp
internal class MyClass
{
    private readonly Latency _latencyMetric;
    private readonly TotalCount _totalCountMetric;
    private readonly TotalFailures _totalFailuresMetric;

    public MyClass(Meter meter)
    {
        // Create metric instances using the source-generated factory methods
        _latencyMetric = Metric.CreateLatency(meter);
        _totalCountMetric = Metric.CreateTotalCount(meter);
        _totalFailuresMetric = Metric.CreateTotalFailures(meter);
    }

    public void DoWork()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        bool requestSuccessful = true;
        // ... perform some operation ...
        stopwatch.Stop();

        // Create a tag object with values for all tags
        var tags = new MetricTags
        {
            Dim1 = "Dim1Value",
            Operation = Operations.Operation1,
            ParentOperationName = "ParentOpValue",
            ChildTagsObject = new MetricChildTags
            {
                Dim2 = "Dim2Value",
            },
            ChildTagsStruct = new MetricTagsStruct
            {
                Dim3 = "Dim3Value"
            }
        };

        // Record the metric values with the associated tags
        _latencyMetric.Record(stopwatch.ElapsedMilliseconds, tags);
        _totalCountMetric.Add(1, tags);
        if (!requestSuccessful)
        {
            _totalFailuresMetric.Add(1, tags);
        }
    }
}
```

In the preceding `MyClass.DoWork` method, a `MetricTags` object is populated with values for each tag. This single `tags` object is then passed to all three instruments when recording data. The `Latency` metric (a histogram) records the elapsed time, and both counters (`TotalCount` and `TotalFailures`) record occurrence counts. Because all metrics share the same tag object type, the tags (`Dim1DimensionName`, `Operation`, `Dim2`, `Dim3`, `DimensionNameOfParentOperation`) are present on every measurement.

## Performance considerations

Using strongly-typed tags via source generation adds no overhead compared to using metrics directly. If you need to further minimize allocations for very high-frequency metrics, consider defining your tag object as a `struct` (value type) instead of a `class`. Using a `struct` for the tag object can avoid heap allocations when recording metrics, since the tags would be passed by value.

## Generated metric method requirements

When defining metric factory methods (the partial methods decorated with `[Counter]`, `[Histogram]`, etc.), the source generator imposes a few requirements:

- Each method must be `public static partial` (for the source generator to provide the implementation).
- The return type of each partial method must be unique (so that the generator can create a uniquely named type for the metric).
- The method name should not start with an underscore (`_`), and parameter names should not start with an underscore.
- The first parameter must be a <xref:System.Diagnostics.Metrics.Meter> (this is the meter instance used to create the underlying instrument).
- The methods cannot be generic and cannot have generic parameters.
- The tag properties in the tag class can only be of type `string` or `enum`. For other types (for example, `bool` or numeric types), convert the value to a string before assigning it to the tag object.

Adhering to these requirements ensures that the source generator can successfully produce the metric types and methods.

## See also

- [Source generated metrics in .NET](source-generated-metrics.md)
- [Creating metrics in .NET (Instrumentation tutorial)](metrics-instrumentation.md)
- [Collecting metrics in .NET (Using MeterListener and exporters)](metrics-collection.md)
- [Logging source generation in .NET](../extensions/logger-message-generator.md) (for a similar source-generation approach applied to logging)
