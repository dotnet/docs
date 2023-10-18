---
title: How to choose reflection or source generation in System.Text.Json
description: "Learn how to choose reflection or source generation in System.Text.Json."
ms.date: 09/25/2023
no-loc: [System.Text.Json]
zone_pivot_groups: dotnet-preview-version
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: how-to
---

# How to choose reflection or source generation in System.Text.Json

By default, `System.Text.Json` uses run-time reflection to gather the metadata it needs to access properties of objects for serialization and deserialization. As an alternative, `System.Text.Json` 6.0 and later can use the C# [source generation](../../../csharp/roslyn-sdk/source-generators-overview.md) feature to improve performance, reduce private memory usage, and facilitate [assembly trimming](../../../core/deploying/trimming/trim-self-contained.md), which reduces app size.

You can use version 6.0+ of `System.Text.Json` in projects that target earlier frameworks. For more information, see [How to get the library](overview.md#how-to-get-the-library).

This article explains the options and provides guidance on how to choose the best approach for your scenario.

## Overview

Choose reflection or source generation modes based on the following benefits that each one offers:

:::zone pivot="dotnet-8-0"

| Benefit                                              | Reflection | Source generation:<br/>Metadata collection | Source generation:<br/>Serialization optimization |
|------------------------------------------------------|------------|---------------------|----------------------------|
| Simpler to code and debug.                           | ✔️        | ❌                  | ❌                        |
| Supports non-public accessors.                       | ✔️        | ❌                  | ❌                        |
| Supports required properties.                        | ✔️        | ✔️                  | ✔️                        |
| Supports init-only properties.                       | ✔️        | ✔️                  | ✔️                        |
| Supports all available serialization customizations. | ✔️        | ❌                  | ❌                        |
| Reduces start-up time.                               | ❌        | ✔️                  | ❌                        |
| Reduces private memory usage.                        | ❌        | ✔️                  | ✔️                        |
| Eliminates run-time reflection.                      | ❌        | ✔️                  | ✔️                        |
| Facilitates trim-safe app size reduction.            | ❌        | ✔️                  | ✔️                        |
| Increases serialization throughput.                  | ❌        | ❌                  | ✔️                        |

:::zone-end

:::zone pivot="dotnet-7-0,dotnet-6-0"

| Benefit                                              | Reflection | Source generation:<br/>Metadata collection | Source generation:<br/>Serialization optimization |
|------------------------------------------------------|------------|---------------------|----------------------------|
| Simpler to code and debug.                           | ✔️        | ❌                  | ❌                        |
| Supports non-public accessors.                       | ✔️        | ❌                  | ❌                        |
| Supports required properties.                        | ✔️        | ❌                  | ❌                        |
| Supports init-only properties.                       | ✔️        | ❌                  | ❌                        |
| Supports all available serialization customizations. | ✔️        | ❌                  | ❌                        |
| Reduces start-up time.                               | ❌        | ✔️                  | ❌                        |
| Reduces private memory usage.                        | ❌        | ✔️                  | ✔️                        |
| Eliminates run-time reflection.                      | ❌        | ✔️                  | ✔️                        |
| Facilitates trim-safe app size reduction.            | ❌        | ✔️                  | ✔️                        |
| Increases serialization throughput.                  | ❌        | ❌                  | ✔️                        |

:::zone-end

The following sections explain these options and their relative benefits.

## System.Text.Json metadata

To serialize or deserialize a type, <xref:System.Text.Json.JsonSerializer> needs information about how to access the members of the type. `JsonSerializer` needs the following information:

* How to access property getters and fields for serialization.
* How to access a constructor, property setters, and fields for deserialization.
* Information about which attributes have been used to customize serialization or deserialization.
* Run-time configuration from <xref:System.Text.Json.JsonSerializerOptions>.

This information is referred to as *metadata*.

By default, `JsonSerializer` collects metadata at run time by using [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/). Whenever `JsonSerializer` has to serialize or deserialize a type for the first time, it collects and caches this metadata. The metadata collection process takes time and uses memory.

## Source generation - metadata collection mode

You can use source generation to move the metadata collection process from run time to compile time. During compilation, the metadata is collected and source code files are generated. The generated source code files are automatically compiled as an integral part of the application. This technique eliminates run-time metadata collection, which improves performance of both serialization and deserialization.

The performance improvements provided by source generation can be substantial. For example, [test results](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/#how-source-generation-provides-benefits) have shown up to 40% or more startup time reduction, private memory reduction, throughput speed increase (in serialization optimization mode), and app size reduction.

### Known issues

:::zone pivot="dotnet-7-0,dotnet-6-0"

Only `public` properties and fields are supported by default<sup>\*</sup> in either serialization mode. However, reflection mode supports the use of `private` *accessors*, while source-generation mode doesn't. For example, you can apply the [JsonInclude attribute](xref:System.Text.Json.Serialization.JsonIncludeAttribute) to a property that has a `private` setter or getter and it will be serialized in reflection mode. Source-generation mode supports only `public` or `internal` accessors of `public` properties. If you set `[JsonInclude]` on non-public accessors and choose source-generation mode, a `NotSupportedException` will be thrown at run time.

:::zone-end

:::zone pivot="dotnet-8-0"

Only `public` properties and fields are supported by default<sup>\*</sup> in either serialization mode. However, reflection mode supports the use of `private` members and `private` *accessors*, while source-generation mode doesn't. For example, if you apply the [JsonInclude attribute](xref:System.Text.Json.Serialization.JsonIncludeAttribute) to a `private` property or a property that has a `private` setter or getter, it will be serialized in reflection mode. Source-generation mode supports only `public` or `internal` members and `public` or `internal` accessors of `public` properties. If you set `[JsonInclude]` on `private` members or accessors and choose source-generation mode, a `NotSupportedException` will be thrown at run time.

:::zone-end

For information about other known issues with source generation, see the [GitHub issues that are labeled "source-generator"](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json+label%3Asource-generator) in the *dotnet/runtime* repository.

## Serialization optimization mode

`JsonSerializer` has many features that customize the output of serialization, such as [naming policies](customize-properties.md#use-a-built-in-naming-policy) and [preserving references](preserve-references.md#preserve-references-and-handle-circular-references). Support for all those features causes some performance overhead. Source generation can improve serialization performance by generating optimized code that uses [`Utf8JsonWriter`](use-utf8jsonwriter.md) directly.

The optimized code doesn't support all of the serialization features that `JsonSerializer` supports. The serializer detects whether the optimized code can be used and falls back to default serialization code if unsupported options are specified. For example, <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString?displayProperty=nameWithType> is not applicable to writing, so specifying this option doesn't cause a fall-back to default code.

The following table shows which options in `JsonSerializerOptions` are supported by the optimized serialization code:

| Serialization option                                                   | Supported by optimized code |
|------------------------------------------------------------------------|-----------------------------|
| <xref:System.Text.Json.JsonSerializerOptions.Converters>               | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition>   | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.DictionaryKeyPolicy>      | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.Encoder>                  | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues>         | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields>     | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyProperties> | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.IncludeFields>            | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.NumberHandling>           | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy>     | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler>         | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver>         | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.WriteIndented>            | ✔️                         |

The following table shows which attributes are supported by the optimized serialization code:

| Attribute                                                         | Supported by optimized code |
|-------------------------------------------------------------------|-----------------------------|
| <xref:System.Text.Json.Serialization.JsonConverterAttribute>      | ❌                         |
| <xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute>    | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonExtensionDataAttribute>  | ❌                         |
| <xref:System.Text.Json.Serialization.JsonIgnoreAttribute>         | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonIncludeAttribute>        | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> | ❌                         |
| <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute>    | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute>   | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonRequiredAttribute>       | ✔️                         |

If a non-supported option or attribute is specified for a type, the serializer falls back to the default `JsonSerializer` code. In that case, the optimized code isn't used when serializing that type but may be used for other types. Therefore it's important to do performance testing with your options and workloads to determine how much benefit you can actually get from serialization optimization mode. Also, the ability to fall back to `JsonSerializer` code requires metadata collection mode. If you select only serialization optimization mode, serialization might fail for types or options that need to fall back to `JsonSerializer` code.

## How to use source generation modes

Most of the System.Text.Json documentation shows how to write code that uses reflection mode. For information about how to use source generation modes, see [How to use source generation in System.Text.Json](source-generation.md).

:::zone pivot="dotnet-8-0"

## Serialize enum fields as strings

### `JsonStringEnumConverter<T>` converter

By default, enums are serialized as numbers. To serialize enum names as strings using source generation, use the <xref:System.Text.Json.Serialization.JsonStringEnumConverter%601> converter. (The non-generic <xref:System.Text.Json.Serialization.JsonStringEnumConverter> type is not supported by the Native AOT runtime.)

Suppose you need to serialize the following class that has an enum property:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithConverterEnum":::

Create a <xref:System.Text.Json.Serialization.JsonSerializerContext> class and annotate it with the <xref:System.Text.Json.Serialization.JsonSerializableAttribute> attribute:

:::code language="csharp" source="snippets/how-to/csharp/RoundtripEnumSourceGeneration.cs" id="Context1":::

The following code serializes the enum names instead of the numeric values:

:::code language="csharp" source="snippets/how-to/csharp/RoundtripEnumSourceGeneration.cs" id="Serialize":::

The resulting JSON looks like the following example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Precipitation": "Sleet"
}
```

### Blanket policy

Instead of using the <xref:System.Text.Json.Serialization.JsonStringEnumConverter%601> type, you can apply a blanket policy to serialize enums as strings by using the <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute>. Create a <xref:System.Text.Json.Serialization.JsonSerializerContext> class and annotate it with the <xref:System.Text.Json.Serialization.JsonSerializableAttribute> *and <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute>* attributes:

:::code language="csharp" source="snippets/how-to/csharp/RoundtripEnumSourceGeneration.cs" id="Context2":::

Notice that the enum doesn't have the <xref:System.Text.Json.Serialization.JsonConverterAttribute>:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithPrecipEnumNoConverter":::

:::zone-end

## See also

* [Try the new System.Text.Json source generator](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/)
* [JSON serialization and deserialization in .NET - overview](overview.md)
* [How to use the library](how-to.md)
