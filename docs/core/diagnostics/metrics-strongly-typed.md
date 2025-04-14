---
title: Source-generated metrics with strongly-typed tags
description: Learn how to use a source generator to create strongly-typed metric tags in .NET, reducing boilerplate and ensuring consistent.
ms.date: 03/07/2025
---

# Source-generated metrics with strongly-typed tags

Modern .NET applications can capture metrics using the <xref:System.Diagnostics.Metrics> API. These metrics often include additional context in the form of key-value pairs called *tags* (sometimes referred to as *dimensions* in telemetry systems). This article shows how to use a compile-time source generator to define **strongly-typed metric tags** (TagNames) and metric recording types and methods. By using strongly-typed tags, you eliminate repetitive boilerplate code and ensure that related metrics share the same set of tag names with compile-time safety. The primary benefit of this approach is improved developer productivity and type safety.

> [!NOTE]
> In the context of metrics, a tag is sometimes also called a "dimension." This article uses "tag" for clarity and consistency with .NET metrics terminology.

## Get started

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

For more information, see [dotnet add package](../tools/dotnet-package-add.md) or [Manage package dependencies in .NET applications](../tools/dependencies.md).

## Tag name defaults and customization

By default, the source generator derives metric tag names from the field and property names of your tag class. In other words, each public field or property in the strongly-typed tag object becomes a tag name by default. You can override this by using the <xref:Microsoft.Extensions.Diagnostics.Metrics.TagNameAttribute> on a field or property to specify a custom tag name. In the examples below, you’ll see both approaches in action.

## Example 1: Basic metric with a single tag

The following example demonstrates a simple counter metric with one tag. In this scenario, we want to count the number of processed requests and categorize them by a `Region` tag:

:::code language="csharp" source="snippets/MetricsGen/MyMetrics.cs id= "snippet_SimpleMetricTag":::

In the code above, `RequestTags` is a strongly-typed tag struct with a single property `Region`. The `CreateRequestCount` method is marked with <xref:Microsoft.Extensions.Diagnostics.Metrics.CounterAttribute`1> where `T` is an `int`, indicating it generates a **Counter** instrument that tracks `int` values. The attribute references `typeof(RequestTags)`, meaning the counter will use the tags defined in `RequestTags` when recording metrics. The source generator will produce a strongly-typed instrument class (named `RequestCount`) with an `Add` method that accepts integer value and `RequestTags` object.

To use the generated metric, create a <xref:System.Diagnostics.Metrics.Meter> and record measurements as shown below:

:::code language="csharp" source="snippets/MetricsGen/MyClass.cs id ="snippet_SimpleMetricTagUsage":::

In this usage example, calling `MyMetrics.CreateRequestCount(meter)` creates a counter instrument (via the `Meter`) and returns a `RequestCount` metric object. When you call `requestCountMetric.Add(1, tags)`, the metric system records a count of 1 associated with the tag `Region="NorthAmerica"`. You can reuse the `RequestTags` object or create new ones to record counts for different regions, and the tag name `Region` will consistently be applied to every measurement.

## Example 2: Metric with nested tag objects

For more complex scenarios, you can define tag classes that include multiple tags, nested objects, or even inherited properties. This allows a group of related metrics to share a common set of tags easily. In the next example, we define a set of tag classes and use them for three different metrics:

:::code language="csharp" source="snippets/MetricsGen/MetricTags.cs :::
:::code language="csharp" source="snippets/MetricsGen/Metris.cs id="snippet_MetricTags" :::

In this example, `MetricTags` is a tag class that inherits from `MetricParentTags` and also contains a nested tag object (`MetricChildTags`) and a nested struct (`MetricTagsStruct`). The tag properties demonstrate both default and customized tag names:

- The `Dim1` field in `MetricTags` has a `[TagName("Dim1DimensionName")]` attribute, so its tag name will be `"Dim1DimensionName"`.
- The `Operation` property has no attribute, so its tag name defaults to `"Operation"`.
- In `MetricParentTags`, the `ParentOperationName` property is overridden with a custom tag name `"DimensionNameOfParentOperation"`.
- The nested `MetricChildTags` class defines a `Dim2` property (no attribute, tag name `"Dim2"`).
- The `MetricTagsStruct` struct defines a `Dim3` field (tag name `"Dim3"`).

All three metric definitions `CreateLatency`, `CreateTotalCount`, and `CreateTotalFailures` use `MetricTags` as their tag object type. This means the generated metric types (`Latency`, `TotalCount`, and `TotalFailures`) will all expect a `MetricTags` instance when recording data. **Each of these metrics will have the same set of tag names:** `Dim1DimensionName`, `Operation`, `Dim2`, `Dim3`, and `DimensionNameOfParentOperation`.

The following code shows how to create and use these metrics in a class:

:::code language="csharp" source="snippets/MetricsGen/MyClass.cs id ="snippet_strongMetricCreation":::

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

- [Source generated metrics in .NET](metrics-generator.md)
- [Creating metrics in .NET (Instrumentation tutorial)](metrics-instrumentation.md)
- [Collecting metrics in .NET (Using MeterListener and exporters)](metrics-collection.md)
- [Logging source generation in .NET](../extensions/logger-message-generator.md) (for a similar source-generation approach applied to logging)
