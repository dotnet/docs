---
title: Source-generation modes in System.Text.Json
description: Learn about the two different source-generation modes in System.Text.Json.
ms.date: 08/18/2026
ai-usage: ai-assisted
no-loc: [System.Text.Json]
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# Source-generation modes in System.Text.Json

`System.Text.Json` source generation provides two modes: *metadata-based* and *serialization optimization*. This article describes both modes.

To use source-generation modes, see [How to use source generation in System.Text.Json](source-generation.md).

## Metadata-based mode

Use source generation to move metadata collection from run time to compile time. During compilation, `System.Text.Json` collects metadata and generates source files. The compiler includes the generated files in your app. Compile-time metadata collection improves serialization and deserialization performance.

The performance improvements from source generation can be substantial. For example, [test results](https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/#how-source-generation-provides-benefits) show up to 40% or more startup time reduction, private memory reduction, throughput increase in serialization-optimization mode, and app size reduction.

### Non-public members and constructors

By default, both reflection mode and source-generation mode include only `public` properties and fields in the serialization contract.

Starting in .NET 11, source generation supports members that you explicitly mark with the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute. The member can be `private`, `internal`, or `protected`. It also supports `private`, `internal`, and `protected` accessors on properties that you mark with `[JsonInclude]`. Source generation also supports inaccessible constructors marked with [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute).

On .NET 11, the generated accessors use <xref:System.Runtime.CompilerServices.UnsafeAccessorAttribute>.

A source-generated setter for an `init`-only property runs only when the JSON payload contains that property. An `init`-only property that the payload omits keeps the value from its property initializer.

In .NET 10 and earlier versions, source generation has the following limitations:

* Source generation doesn't support `private` or `protected` members or accessors. If you mark such a member with `[JsonInclude]`, the serializer throws a <xref:System.NotSupportedException> at runtime.
* Source generation supports `internal` members and accessors only when they're accessible to the generated <xref:System.Text.Json.Serialization.JsonSerializerContext> in the same assembly.
* Source generation doesn't support constructors that are inaccessible to the generated context, even when you mark them with `[JsonConstructor]`.

### Known issues

For other known issues, see [`source-generator` issues](https://github.com/dotnet/runtime/issues?q=is%3Aopen+is%3Aissue+label%3Aarea-System.Text.Json+label%3Asource-generator) in the *dotnet/runtime* repository.

## Serialization-optimization (fast path) mode

`JsonSerializer` has many features that customize the output of serialization, such as [naming policies](customize-properties.md#use-a-built-in-naming-policy) and [preserving references](preserve-references.md#preserve-references-and-handle-circular-references). Support for all those features causes some performance overhead. Source generation can improve serialization performance by generating optimized code that uses [`Utf8JsonWriter`](use-utf8jsonwriter.md) directly.

Serialization-optimization mode emits fast-path serialization methods but not serialization metadata. Fast-path serialization supports fewer scenarios and doesn't support asynchronous serialization or deserialization.

The optimized code doesn't support every `JsonSerializer` feature. The serializer uses optimized code when the configuration supports it and falls back to default code for unsupported options. For example, <xref:System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString?displayProperty=nameWithType> doesn't apply to writing, so the option doesn't cause a fallback.

The following table lists the `JsonSerializerOptions` options that fast-path serialization supports:

| Serialization option                                                   | Supported for fast-path |
|------------------------------------------------------------------------|-------------------------|
| <xref:System.Text.Json.JsonSerializerOptions.AllowTrailingCommas>      | ✔️                      |
| <xref:System.Text.Json.JsonSerializerOptions.Converters>               | ❌                      |
| <xref:System.Text.Json.JsonSerializerOptions.DefaultBufferSize>        | ✔️                      |
| <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition>   | ✔️                      |
| <xref:System.Text.Json.JsonSerializerOptions.DictionaryKeyPolicy>      | ❌                      |
| <xref:System.Text.Json.JsonSerializerOptions.Encoder>                  | ❌                      |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues>         | ❌                      |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields>     | ✔️                      |
| <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyProperties> | ✔️                      |
| <xref:System.Text.Json.JsonSerializerOptions.IncludeFields>            | ✔️                      |
| <xref:System.Text.Json.JsonSerializerOptions.MaxDepth>                 | ✔️                      |
| <xref:System.Text.Json.JsonSerializerOptions.NumberHandling>           | ❌                      |
| <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy>     | ✔️                      |
| <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler>         | ❌                      |
| <xref:System.Text.Json.JsonSerializerOptions.TypeInfoResolver>         | ✔️                      |
| <xref:System.Text.Json.JsonSerializerOptions.WriteIndented>            | ✔️                      |

Fast-path serialization doesn't support the following options because they apply only to *de*serialization: <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive>, <xref:System.Text.Json.JsonSerializerOptions.ReadCommentHandling>, and <xref:System.Text.Json.JsonSerializerOptions.UnknownTypeHandling>.

The following table lists the attributes that fast-path serialization supports:

| Attribute                                                         | Supported for fast-path |
|-------------------------------------------------------------------|-------------------------|
| <xref:System.Text.Json.Serialization.JsonConstructorAttribute>    | ❌                      |
| <xref:System.Text.Json.Serialization.JsonConverterAttribute>      | ❌                      |
| <xref:System.Text.Json.Serialization.JsonDerivedTypeAttribute>    | ✔️                      |
| <xref:System.Text.Json.Serialization.JsonExtensionDataAttribute>  | ❌                      |
| <xref:System.Text.Json.Serialization.JsonIgnoreAttribute>         | ✔️                      |
| <xref:System.Text.Json.Serialization.JsonIncludeAttribute>        | ✔️                      |
| <xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute> | ❌                      |
| <xref:System.Text.Json.Serialization.JsonPolymorphicAttribute>    | ✔️                      |
| <xref:System.Text.Json.Serialization.JsonPropertyNameAttribute>   | ✔️                      |
| <xref:System.Text.Json.Serialization.JsonPropertyOrderAttribute>  | ✔️                      |
| <xref:System.Text.Json.Serialization.JsonRequiredAttribute>       | ✔️                      |

If you specify an unsupported option or attribute for a type, the serializer falls back to [metadata mode](#metadata-based-mode) when the source generator includes metadata. The serializer skips optimized code for that type but might use it for other types. Test your options and workloads to measure the benefit of serialization-optimization mode. Fallback to `JsonSerializer` code requires [metadata mode](#metadata-based-mode). If you select only serialization-optimization mode, serialization might fail for types or options that require fallback.

## See also

* [JSON serialization and deserialization in .NET - overview](overview.md)
* [How to use the library](how-to.md)
