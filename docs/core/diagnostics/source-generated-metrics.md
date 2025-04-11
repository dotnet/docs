---
title: Source-generated metrics
description: Learn how to use a source generator to create metrics in .NET
ms.date: 04/11/2025
---

# Source generated metering

.NET's metering infrastructure is designed to deliver a highly-usable and high-performance metering solution
for modern .NET applications.

To use source generated metering, you first create a class that defines the names and dimensions of the metrics your code can produce.
Then you need to create the class with partial methods signatures.

Then, the .NET's code generator automatically generates the code, which exposes strongly-typed metering types and
methods that you can invoke to record metric values. The generated methods are implemented in a highly efficient
form, which reduces computation overhead as compared to traditional metering solutions.

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

## Generic attributes

Generic attributes are only supported in C# 11 or later, so if you are using generic attributes then please enable C# 11 or later.
Please use non generic attributes if you are using C# 10 or earlier.

## Usage

The following example shows a class that declares two metrics. The methods are marked with an attribute and are declared as `static` and `partial`.
The code generator runs at build time and provides an implementation of these methods, along with accompanying
types.

```csharp
using System.Diagnostics.Metrics;
using Microsoft.Extensions.Diagnostics.Metrics;

internal class MetricConstants
{
    public const string EnvironmentName = "env";
    public const string Region = "region";
    public const string RequestName = "requestName";
    public const string RequestStatus = "requestStatus";
}

internal static partial class Metric
{
    // an explicit metric name is given
    [Histogram<long>("requestName", "duration", Name = "MyCustomMetricName")]
    public static partial Latency CreateLatency(Meter meter);

    // no explicit metric name given, it is auto-generated from the method name
    [Counter<int>(MetricConstants.EnvironmentName, MetricConstants.Region, MetricConstants.RequestName, MetricConstants.RequestStatus)]
    public static partial TotalCount CreateTotalCount(Meter meter);

    [Counter<int>]
    public static partial TotalFailures CreateTotalFailures(Meter meter);
}
```

The previous declaration automatically returns the following:

- `Latency` class with a `Record` method
- `TotalCount` class with an `Add` method
- `TotalFailures` class with a `Add` method.

The attributes indicate the set of dimensions that each metric uses. The signature for the generated types looks like this:

```csharp
internal class TotalCount
{
    public void Add(int value, object? env, object? region, object? requestName, object? requestStatus)
}

internal TotalFailures
{
    public void Add(int value)
}

internal class Latency
{
    public void Record(long value, object? requestName, object? duration);
}
```

The dimensions specified in the attributes have been turned into arguments to the `Add` and `Record` methods.
You then use the generated methods to create instances of these types. With the instances created,
you can call `Add` and `Record` to register metric values, like this:

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

    public void ReportSampleRequestCount()
    {
        // method logic ...

        // Invoke Add on the counter and pass the dimension values.
        _totalCountMetric.Add(1, envName, regionName, requestName, status);
    }

    public void ReportSampleLatency()
    {
        // method logic ...

        // Invoke Record on the histogram and pass the dimension values.
        _latencyMetric.Record(1, requestName, duration);
    }

    public void ReportSampleFailuresCount()
    {
        // method logic ...

        // Invoke Add on the counter and pass the dimension values.
        _totalFailuresMetric.Add(1);
    }
}
```

## Metric methods requirements

Metric methods have some constraints that you must follow:

- They must be static, partial, and public.
- The return type must be unique.
- Their names must not start with an underscore.
- Their parameter names must not start with an underscore.
- Their first parameter must be `Meter`.
- They can't be generic or accept any generic parameters.

## Supported metrics

Please refer to the .NET [`Types of instruments`](https://learn.microsoft.com/dotnet/core/diagnostics/metrics-instrumentation#types-of-instruments) to learn about all the supported instruments and description on how to choose which instrument to use in different situations.
