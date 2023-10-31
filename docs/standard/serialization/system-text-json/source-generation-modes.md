---
title: Source-generation modes in System.Text.Json
description: Learn about the two different source-generation modes in System.Text.Json.
ms.date: 10/30/2023
no-loc: [System.Text.Json]
zone_pivot_groups: dotnet-preview-version
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Source-generation modes in System.Text.Json

Source generation can be used in two modes: metadata collection and serialization optimization. This article describes the different modes.

For information about how to use source generation modes, see [How to use source generation in System.Text.Json](source-generation.md).

## Metadata collection mode

You can use source generation to move the metadata collection process from run time to compile time. During compilation, the metadata is collected and source code files are generated. The generated source code files are automatically compiled as an integral part of the application. This technique eliminates run-time metadata collection, which improves performance of both serialization and deserialization.

The performance improvements provided by source generation can be substantial. For example, [test results](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/#how-source-generation-provides-benefits) have shown up to 40% or more startup time reduction, private memory reduction, throughput speed increase (in serialization optimization mode), and app size reduction.

### Known issues

:::zone pivot="dotnet-7-0,dotnet-6-0"

Only `public` properties and fields are supported by default in either serialization mode. However, reflection mode supports the use of `private` *accessors*, while source-generation mode doesn't. For example, you can apply the [JsonInclude attribute](xref:System.Text.Json.Serialization.JsonIncludeAttribute) to a property that has a `private` setter or getter and it will be serialized in reflection mode. Source-generation mode supports only `public` or `internal` accessors of `public` properties. If you set `[JsonInclude]` on non-public accessors and choose source-generation mode, a `NotSupportedException` will be thrown at run time.

:::zone-end

:::zone pivot="dotnet-8-0"

Only `public` properties and fields are supported by default in either serialization mode. However, reflection mode supports the use of `private` members and `private` *accessors*, while source-generation mode doesn't. For example, if you apply the [JsonInclude attribute](xref:System.Text.Json.Serialization.JsonIncludeAttribute) to a `private` property or a property that has a `private` setter or getter, it will be serialized in reflection mode. Source-generation mode supports only `public` or `internal` members and `public` or `internal` accessors of `public` properties. If you set `[JsonInclude]` on `private` members or accessors and choose source-generation mode, a `NotSupportedException` will be thrown at run time.

:::zone-end

For information about other known issues with source generation, see the [GitHub issues that are labeled "source-generator"](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json+label%3Asource-generator) in the *dotnet/runtime* repository.

## Serialization optimization mode

`JsonSerializer` has many features that customize the output of serialization, such as [naming policies](customize-properties.md#use-a-built-in-naming-policy) and [preserving references](preserve-references.md#preserve-references-and-handle-circular-references). Support for all those features causes some performance overhead. Source generation can improve serialization performance by generating optimized code that uses [`Utf8JsonWriter`](use-utf8jsonwriter.md) directly.

The optimized code doesn't support all of the serialization features that `JsonSerializer` supports. The serializer detects whether the optimized code can be used and falls back to default serialization code if unsupported options are specified. For example, <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString?displayProperty=nameWithType> isn't applicable to writing, so specifying this option doesn't cause a fallback to default code.

The following table shows which options in `JsonSerializerOptions` are supported by the optimized serialization code:

| Serialization option                                                   | Supported by optimized code |
|------------------------------------------------------------------------|-----------------------------|
| <xref:System.Text.Json.JsonSerializerOptions.AllowTrailingCommas>      | ✔️                          |
| <xref:System.Text.Json.JsonSerializerOptions.Converters>               | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.DefaultBufferSize>        | ✔️                          |
| <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition>   | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.DictionaryKeyPolicy>      | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.Encoder>                  | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues>         | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields>     | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyProperties> | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.IncludeFields>            | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.MaxDepth>                 | ✔️                          |
| <xref:System.Text.Json.JsonSerializerOptions.NumberHandling>           | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive> | ❌                       |
| <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy>     | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.ReadCommentHandling>      | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler>         | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver>         | ✔️                         |
| <xref:System.Text.Json.JsonSerializerOptions.UnknownTypeHandling>      | ❌                          |
| <xref:System.Text.Json.JsonSerializerOptions.WriteIndented>            | ✔️                         |

The following table shows which attributes are supported by the optimized serialization code:

| Attribute                                                         | Supported by optimized code |
|-------------------------------------------------------------------|-----------------------------|
| <xref:System.Text.Json.Serialization.JsonConstructorAttribute>    | ❌                         |
| <xref:System.Text.Json.Serialization.JsonConverterAttribute>      | ❌                         |
| <xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute>    | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonExtensionDataAttribute>  | ❌                         |
| <xref:System.Text.Json.Serialization.JsonIgnoreAttribute>         | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonIncludeAttribute>        | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> | ❌                         |
| <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute>    | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute>   | ✔️                         |
| <xref:System.Text.Json.Serialization.JsonPropertyOrderAttribute>  | ❌                         |
| <xref:System.Text.Json.Serialization.JsonRequiredAttribute>       | ✔️                         |

If a non-supported option or attribute is specified for a type, the serializer falls back to metadata mode, assuming that the source generator has been configured to generate metadata. In that case, the optimized code isn't used when serializing that type but may be used for other types. Therefore it's important to do performance testing with your options and workloads to determine how much benefit you can actually get from serialization-optimization mode. Also, the ability to fall back to `JsonSerializer` code requires metadata-collection mode. If you select only serialization-optimization mode, serialization might fail for types or options that need to fall back to `JsonSerializer` code.

## See also

* [JSON serialization and deserialization in .NET - overview](overview.md)
* [How to use the library](how-to.md)
