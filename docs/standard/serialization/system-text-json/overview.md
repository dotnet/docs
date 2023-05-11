---
title: "Serialize and deserialize JSON using C# - .NET"
description: This overview describes the System.Text.Json namespace functionality for serializing to and deserializing from JSON in .NET.
ms.date: 10/18/2021
no-loc: [System.Text.Json, Newtonsoft.Json]
helpviewer_keywords: 
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# JSON serialization and deserialization (marshalling and unmarshalling) in .NET - overview

The `System.Text.Json` namespace provides functionality for serializing to and deserializing from JavaScript Object Notation (JSON). *Serialization* is the process of converting the state of an object, that is, the values of its properties, into a form that can be stored or transmitted. The serialized form doesn't include any information about an object's associated methods. *Deserialization* reconstructs an object from the serialized form.

The `System.Text.Json` library design emphasizes high performance and low memory allocation over an extensive feature set. Built-in UTF-8 support optimizes the process of reading and writing JSON text encoded as UTF-8, which is the most prevalent encoding for data on the web and files on disk.

The library also provides classes for working with an in-memory [document object model (DOM)](use-dom-utf8jsonreader-utf8jsonwriter.md#json-dom-choices). This feature enables random access to the elements in a JSON file or string.

There are some limitations on what parts of the library you can use from Visual Basic code. For more information, see [Visual Basic support](visual-basic-support.md).
  
## How to get the library

The library is built-in as part of the shared framework for .NET Core 3.0 and later versions. The [source generation feature](source-generation-modes.md#source-generation---metadata-collection-mode) is built-in as part of the shared framework for .NET 6 and later versions. Use of source generation requires .NET 5 SDK or later.

For framework versions earlier than .NET Core 3.0, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package. The package supports:

* .NET Standard 2.0 and later
* .NET Framework 4.6.2 and later
* .NET Core 2.1 and later
* .NET 5 and later

## Run-time reflection vs. compile-time source generation

By default, `System.Text.Json` uses [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/) to gather the metadata it needs to access properties of objects for serialization and deserialization *at run time*. As an alternative, `System.Text.Json` can use the C# [source generation](../../../csharp/roslyn-sdk/source-generators-overview.md) feature to improve performance, reduce private memory usage, and facilitate [assembly trimming](../../../core/deploying/trimming/trim-self-contained.md), which reduces app size. For more information, see [How to choose reflection or source generation in System.Text.Json](source-generation-modes.md).

## Security information

For information about security threats that were considered when designing <xref:System.Text.Json.JsonSerializer>, and how they can be mitigated, see [`System.Text.Json` Threat Model](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/docs/ThreatModel.md).

## Thread safety

The `System.Text.Json` serializer was designed with thread safety in mind. Practically, this means that once locked, <xref:System.Text.Json.JsonSerializerOptions> instances can be safely shared across multiple threads.

<xref:System.Text.Json.JsonDocument> was designed to provide an immutable and thus thread-safe DOM representation for JSON values. However, due to a [concurrency bug](https://github.com/dotnet/runtime/issues/76440), `JsonDocument` is not currently thread safe.

## Additional resources

* [How to use the library](how-to.md)
* [Instantiate JsonSerializerOptions instances](configure-options.md)
* [Enable case-insensitive matching](character-casing.md)
* [Customize property names and values](customize-properties.md)
* [Ignore properties](ignore-properties.md)
* [Require properties](required-properties.md)
* [Allow invalid JSON](invalid-json.md)
* [Handle overflow JSON or use JsonElement or JsonNode](handle-overflow.md)
* [Preserve references and handle circular references](preserve-references.md)
* [Deserialize to immutable types and non-public accessors](immutability.md)
* [Polymorphic serialization](polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](migrate-from-newtonsoft.md)
* [Customize character encoding](character-encoding.md)
* [Use DOM, Utf8JsonReader, and Utf8JsonWriter](use-dom-utf8jsonreader-utf8jsonwriter.md)
* [Write custom converters for JSON serialization](converters-how-to.md)
* [DateTime and DateTimeOffset support](../../datetime/system-text-json-support.md)
* [How to use source generation](source-generation.md)
* [Supported collection types](supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
