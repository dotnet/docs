---
title: How to choose reflection or source generation in System.Text.Json
description: "Learn how to choose reflection or source generation in System.Text.Json."
ms.date: 08/18/2026
ai-usage: ai-assisted
no-loc: [System.Text.Json]
---

# Reflection versus source generation in System.Text.Json

This article explains the differences between reflection and source generation as it relates to `System.Text.Json` serialization. It also provides guidance on how to choose the best approach for your scenario.

## Metadata collection

To serialize or deserialize a type, <xref:System.Text.Json.JsonSerializer> needs information about how to access the members of the type. `JsonSerializer` needs the following information:

* How to access property getters and fields for serialization.
* How to access a constructor, property setters, and fields for deserialization.
* Which attributes customize serialization or deserialization.
* Runtime configuration from <xref:System.Text.Json.JsonSerializerOptions>.

The term *metadata* refers to this information.

## Reflection

By default, <xref:System.Text.Json.JsonSerializer> collects metadata at run time by using [reflection](../../../csharp/advanced-topics/reflection-and-attributes/index.md). The first time `JsonSerializer` serializes or deserializes a type, it collects and caches this metadata. Metadata collection takes time and uses memory.

## Source generation

As an alternative, `System.Text.Json` can use the C# [source generation](../../../csharp/roslyn-sdk/index.md#source-generators) feature. Source generation improves performance, reduces private memory usage, and facilitates [assembly trimming](../../../core/deploying/trimming/trim-self-contained.md) to reduce app size. [Native AOT applications](../../../core/deploying/native-aot/index.md) don't support certain reflection APIs, so use source generation for those apps.

Source generation provides two modes:

* **Metadata-based mode**

  During compilation, `System.Text.Json` collects the information needed for serialization and generates source code files that populate JSON contract metadata for the requested types.

* **Serialization-optimization (fast path) mode**

  <xref:System.Text.Json.JsonSerializer> features that customize the output of serialization, such as naming policies and reference preservation, carry a performance overhead. In serialization-optimization mode, System.Text.Json generates optimized serialization code that uses [`Utf8JsonWriter`](use-utf8jsonwriter.md) directly. This optimized or *fast path* code increases serialization throughput.

  `System.Text.Json` doesn't currently provide fast-path *deserialization*. For more information, see [dotnet/runtime issue 55043](https://github.com/dotnet/runtime/issues/55043).

Source generation for `System.Text.Json` requires C# 9.0 or a later version.

> [!NOTE]
> F# discriminated union support works only in reflection mode. It requires dynamic code and untrimmed reflection metadata. You can't use it with source generation or Native AOT. For more information, see [F# discriminated unions](supported-types.md#f-discriminated-unions).

## Feature comparison

Choose reflection or source-generation modes based on the following benefits that each one offers:

| Benefit                                              | Reflection | Source generation<br/>(Metadata-based mode) | Source generation<br/>(Serialization-optimization mode) |
|------------------------------------------------------|------------|---------------------|----------------------------|
| Simpler to code.                                     | ✔️        | ❌                  | ❌                        |
| Simpler to debug.                                    | ❌        | ✔️                  | ✔️                        |
| Supports `[JsonInclude]` on non-public members.      | ✔️        | ✔️<sup>*</sup>      | ✔️<sup>*</sup>            |
| Supports all available serialization customizations. | ✔️        | ❌<sup>†</sup>      | ❌<sup>†</sup>            |
| Reduces start-up time.                               | ❌        | ✔️                  | ✔️                        |
| Reduces private memory usage.                        | ❌        | ✔️                  | ✔️                        |
| Eliminates runtime reflection.                      | ❌        | ✔️                  | ✔️                        |
| Facilitates trim-safe app size reduction.            | ❌        | ✔️                  | ✔️                        |
| Increases serialization throughput.                  | ❌        | ❌                  | ✔️                        |

\* Starting in .NET 11, source generation supports `private`, `internal`, and `protected` members that you explicitly mark with [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute). It also supports `private`, `internal`, and `protected` accessors on properties that you mark with `[JsonInclude]`. Metadata-based source generation supports inaccessible constructors that you mark with [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute). Generated setters run only for `init`-only properties that appear in the JSON, so omitted properties keep their initializer values. In .NET 10 and earlier versions, source generation doesn't support `private` or `protected` members or accessors, or inaccessible constructors. The generated context can access `internal` members and accessors only when they share an assembly. For more information, see [Non-public members and constructors](source-generation-modes.md#non-public-members-and-constructors).
† Use the contract customization API to modify source-generated contracts.
