---
title: Compile-time metric source generation
description: Learn how to use a source generator to create metrics in .NET
ms.date: 04/11/2025
---

# Compile-time metric source generation

.NET's metering infrastructure is designed to deliver a highly usable and high-performance metering solution for modern .NET applications.

To use source-generated metering, create a class that defines the names and dimensions of the metrics your code can produce. Then, create the class with `partial` method signatures.

The code generator automatically generates the code, which exposes strongly typed metering types and methods that you can invoke to record metric values. The generated methods are implemented in a highly efficient form, which reduces computation overhead as compared to traditional metering solutions.

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

## Generic attributes

Generic attributes require C# 11 or later. For C# 10 or earlier, use nongeneric attributes instead.

The following example shows a class that declares two metrics. The methods are marked with an attribute and are declared as `static` and `partial`.
The code generator runs at build time and provides an implementation of these methods, along with accompanying
types.

:::code language="csharp" source="snippets/MetricsGen/MetricConstants.cs" id="snippet_metricConstants":::

:::code language="csharp" source="snippets/MetricsGen/Metris.cs" id="snippet_Metrics" :::

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

The dimensions specified in the attributes have been turned into arguments to the `Add` and `Record` methods. You then use the generated methods to create instances of these types. With the instances created, you can call `Add` and `Record` to register metric values, as shown in the following example:

:::code language="csharp" source="snippets/MetricsGen/MyClass.cs" id ="snippet_metricCreation":::

## Metric methods requirements

Metric methods are constrained to the following:

- They must be `public static partial`.
- The return type must be unique.
- Their names must not start with an underscore.
- Their parameter names must not start with an underscore.
- Their first parameter must be <xref:System.Diagnostics.Metrics.Meter> type.
Metric methods are constrained to the following:

## See also

For more information on the supported metrics, see [Types of instruments](metrics-instrumentation.md#types-of-instruments) to learn how to choose which instrument to use in different situations.
