---
title: How to choose Reflection or source generation in System.Text.Json
description: "Learn how to choose Reflection or source generation in System.Text.Json."
ms.date: 10/18/2021
no-loc: [System.Text.Json]
zone_pivot_groups: dotnet-version
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: how-to
---

# How to choose Reflection or source generation in System.Text.Json

:::zone pivot="dotnet-6-0"
> [!IMPORTANT]
> Some information relates to prerelease product that may be substantially modified before it's released. Microsoft makes no warranties, express or implied, with respect to the information provided here.

By default, `System.Text.Json` uses run-time Reflection to gather the metadata it needs to access properties of objects for serialization and deserialization. As an alternative, `System.Text.Json` can use the C# [source generation](../../csharp/roslyn-sdk/source-generators-overview.md) feature to improve performance, reduce private memory usage, and facilitate [assembly trimming](../../core/deploying/trimming/trim-self-contained.md), which reduces app size.

You can use version 6.0 of System.Text.Json in projects that target earlier frameworks. For more information, see [How to get the library](system-text-json-overview.md#how-to-get-the-library).

[The .NET 6.0 version of this article](system-text-json-source-generation-modes.md?pivots=dotnet-6-0) explains the options and gives guidance on how to choose the best approach for your scenario.
:::zone-end

:::zone pivot="dotnet-5-0,dotnet-core-3-1"
[System.Text.Json](system-text-json-overview.md) version 6.0 and later can use the C# [source generation](../../csharp/roslyn-sdk/source-generators-overview.md) feature to improve performance, reduce private memory usage, and improve [assembly trimming](../../core/deploying/trimming/trim-self-contained.md) accuracy. You can use version 6.0 of System.Text.Json in projects that target earlier frameworks. For more information, see:

* [The .NET 6.0 version of this article](system-text-json-source-generation-modes.md?pivots=dotnet-6-0).
* [How to get the library](system-text-json-overview.md#how-to-get-the-library)

:::zone-end

:::zone pivot="dotnet-6-0"

## Introduction to System.Text.Json metadata

To serialize or deserialize a type, <xref:System.Text.Json.JsonSerializer> needs information about how to access the members of the type. `JsonSerializer` needs the following information:

* How to access property getters and fields for serialization.
* How to access a constructor, property setters, and fields for deserialization.
* Attributes that have been used to customize serialization or deserialization.
* Run-time configuration from <xref:System.Text.Json.JsonSerializerOptions>.

This information is referred to as *metadata*.

## Metadata collection using source generation

By default, `JsonSerializer` collects metadata at run time by using [Reflection](../../csharp/programming-guide/concepts/reflection.md). Whenever `JsonSerializer` has to serialize or deserialize a type for the first time, it collects and caches this metadata. The metadata collection process takes time and uses memory.

You can use source generation to move the metadata collection process from run time to compile time. During compilation, the metadata is collected and source code files are generated. The generated source code files are automatically compiled as an integral part of the application. This compile-time metadata collection eliminates run-time metadata collection, which improves performance of both serialization and deserialization.

### Limitations of source generation metadata

The following `JsonSerializer` features are not supported in metadata collection mode using source generation:

| Feature
|------------------------------------------------------------------------|
| [Init-only properties](xref:System.Text.Json.Serialization.JsonIncludeAttribute) |
| [Private members](xref:System.Text.Json.Serialization.JsonIncludeAttribute) |

The following table shows which attributes are supported by the optimized serialization code:

| Attribute                                                         | Supported by optimized code |
|-------------------------------------------------------------------|-----------------------------|
| <xref:System.Text.Json.Serialization.JsonConverterAttribute>      | ❌                         |
| <xref:System.Text.Json.Serialization.JsonExtensionDataAttribute>  | ❌                         |
| <xref:System.Text.Json.Serialization.JsonIgnoreAttribute>         | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonIncludeAttribute>        | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> | ❌                         |
| <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute>   | ✔️                         |

## Serialization optimization mode

`JsonSerializer` has many features that customize the output of serialization, such as [camel-casing property names](system-text-json-customize-properties.md#use-camel-case-for-all-json-property-names) and [preserving references](system-text-json-preserve-references.md#preserve-references-and-handle-circular-references). Support for all those features causes some performance overhead. Source generation can improve serialization performance by generating optimized code that uses [`Utf8JsonWriter`](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md#use-utf8jsonwriter) directly.

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
| <xref:System.Text.Json.JsonSerializerOptions.WriteIndented>            | ✔️                         |

The following table shows which attributes are supported by the optimized serialization code:

| Attribute                                                         | Supported by optimized code |
|-------------------------------------------------------------------|-----------------------------|
| <xref:System.Text.Json.Serialization.JsonConverterAttribute>      | ❌                         |
| <xref:System.Text.Json.Serialization.JsonExtensionDataAttribute>  | ❌                         |
| <xref:System.Text.Json.Serialization.JsonIgnoreAttribute>         | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonIncludeAttribute>        | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> | ❌                         |
| <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute>   | ✔️                         |

If a non-supported option or attribute is specified for a type, the serializer falls back to the default `JsonSerializer` code. In that case the optimized code isn't used when serializing that type but may be used for other types.

## Choose Reflection or a source generation mode

Choose Reflection or source generation modes based on the following benefits that each one offers:

| Benefit                                   | Reflection | Metadata collection | Serialization optimization |
|-------------------------------------------|------------|---------------------|----------------------------|
| Simpler to code and debug.                | ✔️         | ❌                  | ❌                        |
| Supports all available options.           | ✔️         | ❌                  | ❌                        |
| Reduces start-up time.                    | ❌         | ✔️                  | ❌                        |
| Reduces private memory usage.             | ❌         | ✔️                  | ✔️                        |
| Eliminates run-time reflection.           | ❌         | ✔️                  | ✔️                        |
| Facilitates trim-safe app size reduction. | ❌         | ✔️                  | ✔️                        |
| Increases serialization throughput.       | ❌         | ❌                  | ✔️ \*                     |

The performance improvements provided by source generation can be substantial. For example, [test results](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/#how-source-generation-provides-benefits) have shown up to 40% or more startup time reduction, private memory reduction, throughput speed increase, and app size reduction.

\* As explained in the [preceding section](#serialization-optimization-mode), the optimized code doesn't support some features. Do performance testing with your options and workloads to determine how much benefit you can actually get from serialization optimization mode. Also, the ability to fall back to `JsonSerializer` code requires metadata collection mode. If you select only serialization optimization mode, serialization might fail for types or options that need to fall back to `JsonSerializer` code.

## Get the source generation functionality

The source generation functionality of System.Text.Json 6.0 and later can be used in any .NET C# project, including class libraries and console, web, and Blazor applications. You can use version 6.0 of System.Text.Json in projects that target earlier frameworks. For more information, see [How to get the library](system-text-json-overview.md#how-to-get-the-library).

For information about how to use source generation modes in code that uses System.Text.Json, see [How to use source generation in System.Text.Json](system-text-json-source-generation.md).
:::zone-end

## See also

* [Try the new System.Text.Json source generator](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/)
* [JSON serialization and deserialization in .NET - overview](system-text-json-overview.md)
* [How to use the library](system-text-json-how-to.md)
* [Instantiate JsonSerializerOptions instances](system-text-json-configure-options.md)
* [Enable case-insensitive matching](system-text-json-character-casing.md)
* [Customize property names and values](system-text-json-customize-properties.md)
* [Ignore properties](system-text-json-ignore-properties.md)
* [Allow invalid JSON](system-text-json-invalid-json.md)
* [Handle overflow JSON or use JsonElement or JsonNode](system-text-json-handle-overflow.md)
* [Preserve references and handle circular references](system-text-json-preserve-references.md)
* [Deserialize to immutable types and non-public accessors](system-text-json-immutability.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md)
* [Customize character encoding](system-text-json-character-encoding.md)
* [Use DOM, Utf8JsonReader, and Utf8JsonWriter](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [Supported collection types in System.Text.Json](system-text-json-supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
