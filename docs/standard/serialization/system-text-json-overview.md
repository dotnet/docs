---
title: "Serialize and deserialize JSON using C# - .NET"
description: This overview describes the System.Text.Json namespace functionality for serializing to and deserializing from JSON in .NET.
ms.date: "01/10/2020"
no-loc: [System.Text.Json, Newtonsoft.Json]
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

## How to get the library

* The library is built-in as part of the shared framework for .NET Core 3.0 and later versions.
* For earlier framework versions, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package. The package supports:

  * .NET Standard 2.0 and later versions
  * .NET Framework 4.7.2 and later versions
  * .NET Core 2.0, 2.1, and 2.2

## Security information

For information about security threats that were considered when designing <xref:System.Text.Json.JsonSerializer>, and how they can be mitigated, see [`System.Text.Json` Threat Model](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/docs/ThreatModel.md).

## Additional resources

* [How to use the library](system-text-json-how-to.md)
* [Instantiate JsonSerializerOptions instances](system-text-json-configure-options.md)
* [Enable case-insensitive matching](system-text-json-character-casing.md)
* [Customize property names and values](system-text-json-customize-properties.md)
* [Ignore properties](system-text-json-ignore-properties.md)
* [Allow invalid JSON](system-text-json-invalid-json.md)
* [Handle overflow JSON](system-text-json-handle-overflow.md)
* [Preserve references](system-text-json-preserve-references.md)
* [Immutable types and non-public accessors](system-text-json-immutability.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md)
* [Customize character encoding](system-text-json-character-encoding.md)
* [Write custom serializers and deserializers](write-custom-serializer-deserializer.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [Supported collection types in System.Text.Json](system-text-json-supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
