---
title: "Serialize and deserialize JSON using C# - .NET"
description: This overview describes the System.Text.Json namespace functionality for serializing to and deserializing from JSON in .NET.
ms.date: 10/18/2021
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - CSharp
  - VB
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# JSON serialization and deserialization (marshalling and unmarshalling) in .NET - overview

The <xref:System.Text.Json> namespace provides functionality for serializing to and deserializing from JavaScript Object Notation (JSON). *Serialization* is the process of converting the state of an object, that is, the values of its properties, into a form that can be stored or transmitted. The serialized form doesn't include any information about an object's associated methods. *Deserialization* reconstructs an object from the serialized form.

The `System.Text.Json` library design emphasizes high performance and low memory allocation over an extensive feature set. Built-in UTF-8 support optimizes the process of reading and writing JSON text encoded as UTF-8, which is the most prevalent encoding for data on the web and files on disk.

The library also provides classes for working with an in-memory [document object model (DOM)](use-dom.md#json-dom-choices). This feature enables random access to the elements in a JSON file or string.

For Visual Basic, there are some limitations on what parts of the library you can use. For more information, see [Visual Basic support](visual-basic-support.md).

## How to get the library

The library is built-in as part of the shared framework for .NET Core 3.0 and later versions. The [source generation feature](source-generation-modes.md#metadata-based-mode) is built-in as part of the shared framework for .NET 6 and later versions.

For framework versions earlier than .NET Core 3.0, install the [System.Text.Json](https://www.nuget.org/packages/System.Text.Json) NuGet package. The package supports:

* .NET Standard 2.0 and later
* .NET Framework 4.6.2 and later
* .NET Core 2.1 and later
* .NET 5 and later

## Namespaces and APIs

- The <xref:System.Text.Json> namespace contains all the entry points and the main types.
- The <xref:System.Text.Json.Serialization> namespace contains attributes and APIs for advanced scenarios and customization specific to serialization and deserialization.

The code examples shown in this article require `using` directives for one or both of these namespaces.

> [!IMPORTANT]
>
> `System.Text.Json` doesn't support the following serialization APIs that you might have used previously:
>
> * Attributes from the <xref:System.Runtime.Serialization> namespace.
> * The <xref:System.SerializableAttribute?displayProperty=fullName> attribute and the <xref:System.Runtime.Serialization.ISerializable> interface. These types are used only for [Binary and XML serialization](/previous-versions/dotnet/fundamentals/serialization/binary/binary-serialization).

### HttpClient and HttpContent extension methods

Serializing and deserializing JSON payloads from the network are common operations. Extension methods on [HttpClient](xref:System.Net.Http.Json.HttpClientJsonExtensions) and [HttpContent](xref:System.Net.Http.Json.HttpContentJsonExtensions) let you do these operations in a single line of code. These extension methods use [web defaults for JsonSerializerOptions](configure-options.md#web-defaults-for-jsonserializeroptions).

The following example illustrates use of <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A?displayProperty=nameWithType> and <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/how-to-5-0/csharp/HttpClientExtensionMethods.cs" highlight="23,30":::
:::code language="vb" source="snippets/how-to-5-0/vb/HttpClientExtensionMethods.vb" :::

There are also extension methods for System.Text.Json on [HttpContent](xref:System.Net.Http.Json.HttpContentJsonExtensions).

## Reflection vs. source generation

By default, `System.Text.Json` gathers the metadata it needs to access properties of objects for serialization and deserialization *at run time* using [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/). As an alternative, `System.Text.Json` can use the C# [source generation](../../../csharp/roslyn-sdk/source-generators-overview.md) feature to improve performance, reduce private memory usage, and facilitate [assembly trimming](../../../core/deploying/trimming/trim-self-contained.md), which reduces app size.

For more information, see [Reflection versus source generation](reflection-vs-source-generation.md).

## Security information

For information about security threats that were considered when designing <xref:System.Text.Json.JsonSerializer>, and how they can be mitigated, see [`System.Text.Json` Threat Model](https://github.com/dotnet/runtime/blob/main/src/libraries/System.Text.Json/docs/ThreatModel.md).

## Thread safety

The `System.Text.Json` serializer was designed with thread safety in mind. Practically, this means that once locked, <xref:System.Text.Json.JsonSerializerOptions> instances can be safely shared across multiple threads. <xref:System.Text.Json.JsonDocument> provides an immutable, and in .NET 8 and later versions, thread-safe, DOM representation for JSON values.

## Additional resources

* [How to use the library](how-to.md)
