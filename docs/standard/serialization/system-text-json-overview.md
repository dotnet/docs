---
title: "Serialize and deserialize JSON using C# - .NET"
description: This overview describes the System.Text.Json namespace functionality for serializing to and deserializing from JSON in .NET.
ms.date: 10/18/2021
no-loc: [System.Text.Json, Newtonsoft.Json]
zone_pivot_groups: dotnet-version
helpviewer_keywords: 
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# JSON serialization and deserialization (marshalling and unmarshalling) in .NET - overview

The `System.Text.Json` namespace provides functionality for serializing to and deserializing from JavaScript Object Notation (JSON).

The library design emphasizes high performance and low memory allocation over an extensive feature set. Built-in UTF-8 support optimizes the process of reading and writing JSON text encoded as UTF-8, which is the most prevalent encoding for data on the web and files on disk.

The library also provides classes for working with an in-memory document object model (DOM). This feature enables random read-only access of the elements in a JSON file or string.

There are some limitations on what parts of the library that you can use from Visual Basic code. For more information, see [Visual Basic support](system-text-json-how-to.md#visual-basic-support).

## Run-time reflection vs. compile-time source generation

By default, `System.Text.Json` uses run-time [reflection](../../csharp/programming-guide/concepts/reflection.md) to gather the metadata it needs to access properties of objects for serialization and deserialization. As an alternative, `System.Text.Json` can use the C# [source generation](../../csharp/roslyn-sdk/source-generators-overview.md) feature to improve performance, reduce private memory usage, and facilitate [assembly trimming](../../core/deploying/trimming/trim-self-contained.md), which reduces app size. For more information, see [How to choose reflection or source generation in System.Text.Json](system-text-json-source-generation-modes.md).
  
## How to get the library

The library is built-in as part of the shared framework for .NET Core 3.0 and later versions. The source generation feature is built-in as part of the shared framework for .NET 6 and later versions. Use of source generation requires .NET 5 SDK or later.

For framework versions earlier than .NET Core 3.0, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package. The package supports:

* .NET Standard 2.0 and later
* .NET Framework 4.7.2 and later
* .NET Core 2.1 and later
* .NET 5 and later

## Security information

For information about security threats that were considered when designing <xref:System.Text.Json.JsonSerializer>, and how they can be mitigated, see [`System.Text.Json` Threat Model](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/docs/ThreatModel.md).

## Thread safety

* The `System.Text.Json` types are thread-safe, including:

:::zone pivot="dotnet-5-0,dotnet-core-3-1"

* <xref:System.Text.Json.JsonSerializer>
* <xref:System.Text.Json.Utf8JsonReader>
* <xref:System.Text.Json.Utf8JsonWriter>
* <xref:System.Text.Json.JsonDocument>
:::zone-end

:::zone pivot="dotnet-6-0"

* <xref:System.Text.Json.JsonSerializer>
* <xref:System.Text.Json.Utf8JsonReader>
* <xref:System.Text.Json.Utf8JsonWriter>
* <xref:System.Text.Json.JsonDocument>
* <xref:System.Text.Json.Nodes.JsonNode>
:::zone-end

## Additional resources

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
* [How to use source generation](system-text-json-source-generation.md)
* [Supported collection types](system-text-json-supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
