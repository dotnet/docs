---
title: How to choose reflection or source generation in System.Text.Json
description: "Learn how to choose reflection or source generation in System.Text.Json."
ms.date: 10/30/2023
no-loc: [System.Text.Json]
zone_pivot_groups: dotnet-preview-version
---

# Reflection versus source generation in System.Text.Json

This article explains the differences between reflection and source generation as it relates to `System.Text.Json` serialization. It also provides guidance on how to choose the best approach for your scenario.

## Metadata collection

To serialize or deserialize a type, <xref:System.Text.Json.JsonSerializer> needs information about how to access the members of the type. `JsonSerializer` needs the following information:

* How to access property getters and fields for serialization.
* How to access a constructor, property setters, and fields for deserialization.
* Information about which attributes have been used to customize serialization or deserialization.
* Run-time configuration from <xref:System.Text.Json.JsonSerializerOptions>.

This information is referred to as *metadata*.

## Reflection

By default, `JsonSerializer` collects metadata at run time by using [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/). Whenever `JsonSerializer` has to serialize or deserialize a type for the first time, it collects and caches this metadata. The metadata collection process takes time and uses memory.

## Source generation

As an alternative, `System.Text.Json` can use the C# [source generation](../../../csharp/roslyn-sdk/source-generators-overview.md) feature to improve performance, reduce private memory usage, and facilitate [assembly trimming](../../../core/deploying/trimming/trim-self-contained.md), which reduces app size. In addition, reflection can't be used in [Native AOT applications](../../../core/deploying/native-aot/index.md), so you must use source generation for those apps.

Source generation can be used in two modes:

* **Metadata collection mode**

  During compilation, System.Text.Json collects the metadata needed for serialization and generates source code files. The generated source code files are automatically compiled as an integral part of the application.

* **Serialization optimization (fast track) mode**

  <xref:System.Text.Json.JsonSerializer> features that customize the output of serialization, such as naming policies and reference preservation, carry a performance overhead. In serialization optimization mode, System.Text.Json generates optimized code that uses [`Utf8JsonWriter`](use-utf8jsonwriter.md) directly. This optimized or *fast path* code increases serialization throughput.

Source generation for `System.Text.Json` requires C# 9.0 or a later version.

## Feature comparison

Choose reflection or source-generation modes based on the following benefits that each one offers:

:::zone pivot="dotnet-8-0"

| Benefit                                              | Reflection | Source generation<br/>(Metadata collection mode) | Source generation<br/>(Serialization optimization mode) |
|------------------------------------------------------|------------|---------------------|----------------------------|
| Simpler to code and debug.                           | ✔️        | ❌                  | ❌                        |
| Supports non-public accessors.                       | ✔️        | ❌                  | ❌                        |
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
