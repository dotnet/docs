---
title: "How to serialize and deserialize JSON using C# - .NET"
description: "Learn how to use the System.Text.Json namespace to serialize to and deserialize from JSON in .NET. Includes sample code."
ms.date: 08/04/2021
ms.custom: contperf-fy21q2
no-loc: [System.Text.Json, Newtonsoft.Json]
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

# How to serialize and deserialize (marshal and unmarshal) JSON in .NET

This article shows how to use the <xref:System.Text.Json?displayProperty=fullName> namespace to serialize to and deserialize from JavaScript Object Notation (JSON). If you're porting existing code from `Newtonsoft.Json`, see [How to migrate to `System.Text.Json`](system-text-json-migrate-from-newtonsoft-how-to.md).

## Code samples

The code samples in this article:

* Use the library directly, not through a framework such as [ASP.NET Core](/aspnet/core/).

* Use the <xref:System.Text.Json.JsonSerializer> class with custom types to serialize from and deserialize into.

  For information about how to read and write JSON data without using `JsonSerializer`, see [How to use the JSON DOM, Utf8JsonReader, and Utf8JsonWriter](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md).

* Use the <xref:System.Text.Json.JsonSerializerOptions.WriteIndented> option to format the JSON for human readability when that is helpful.

  For production use, you would typically accept the default value of `false` for this setting, since adding unnecessary whitespace may incur a negative impact on performance and bandwidth usage.

* Refer to the following class and variants of it:

  :::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WF":::
  :::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WF":::

## Visual Basic support

Parts of System.Text.Json use [ref structs](../../csharp/language-reference/builtin-types/struct.md#ref-struct), which are not supported by Visual Basic. If you try to use System.Text.Json ref struct APIs with Visual Basic you get BC40000 compiler errors. The error message indicates that the problem is an obsolete API, but the actual issue is lack of ref struct support in the compiler. The following parts of System.Text.Json aren't usable from Visual Basic:

* The <xref:System.Text.Json.Utf8JsonReader> class. Since the <xref:System.Text.Json.Serialization.JsonConverter%601.Read%2A?displayProperty=nameWithType> method takes a `Utf8JsonReader` parameter, this limitation means you can't use Visual Basic to write custom converters. A workaround for this is to implement custom converters in a C# library assembly, and reference that assembly from your VB project. This assumes that all you do in Visual Basic is register the converters into the serializer. You can't call the `Read` methods of the converters from Visual Basic code.
* Overloads of other APIs that include a <xref:System.ReadOnlySpan%601> type. Most methods include overloads that use `String` instead of `ReadOnlySpan`.

These restrictions are in place because ref structs cannot be used safely without language support, even when just "passing data through." Subverting this error will result in Visual Basic code that can corrupt memory and should not be done.

## Namespaces

The <xref:System.Text.Json> namespace contains all the entry points and the main types. The <xref:System.Text.Json.Serialization> namespace contains attributes and APIs for advanced scenarios and customization specific to serialization and deserialization. The code examples shown in this article require `using` directives for one or both of these namespaces:

```csharp
using System.Text.Json;
using System.Text.Json.Serialization;
```

```vb
Imports System.Text.Json
Imports System.Text.Json.Serialization
```

> [!IMPORTANT]
> Attributes from the <xref:System.Runtime.Serialization> namespace aren't supported in `System.Text.Json`.

## How to write .NET objects as JSON (serialize)

To write JSON to a string or to a file, call the <xref:System.Text.Json.JsonSerializer.Serialize%2A?displayProperty=nameWithType> method.

The following example creates JSON as a string:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeBasic.cs" highlight="24":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToString.vb" id="Serialize":::

The JSON output is minified (whitespace, indentation, and new-line characters are removed) by default.

The following example uses synchronous code to create a JSON file:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeToFile.cs" highlight="25-27":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToFile.vb" id="Serialize":::

The following example uses asynchronous code to create a JSON file:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeToFileAsync.cs" highlight="26-29":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToFileAsync.vb" id="Serialize":::

The preceding examples use type inference for the type being serialized. An overload of `Serialize()` takes a generic type parameter:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeWithGenericParameter.cs" highlight="24":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToString.vb" id="SerializeWithGenericParameter":::

### Serialization example

Here's an example showing how a class that contains collection properties and a user-defined type is serialized:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeExtra.cs" highlight="44-45":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithPOCOs":::

## Serialize to UTF-8

Serializing to a UTF-8 byte array is about 5-10% faster than using the string-based methods. The difference is because the bytes (as UTF-8) don't need to be converted to strings (UTF-16).

To serialize to a UTF-8 byte array, call the <xref:System.Text.Json.JsonSerializer.SerializeToUtf8Bytes%2A?displayProperty=nameWithType> method:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripToUtf8.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToUtf8.vb" id="Serialize":::

A <xref:System.Text.Json.JsonSerializer.Serialize%2A> overload that takes a <xref:System.Text.Json.Utf8JsonWriter> is also available.

## Serialization behavior

::: zone pivot="dotnet-5-0,dotnet-6-0"

* By default, all public properties are serialized. You can [specify properties to ignore](system-text-json-ignore-properties.md).
* The [default encoder](xref:System.Text.Encodings.Web.JavaScriptEncoder.Default) escapes non-ASCII characters, HTML-sensitive characters within the ASCII-range, and characters that must be escaped according to [the RFC 8259 JSON spec](https://tools.ietf.org/html/rfc8259#section-7).
* By default, JSON is minified. You can [pretty-print the JSON](#serialize-to-formatted-json).
* By default, casing of JSON names matches the .NET names. You can [customize JSON name casing](system-text-json-customize-properties.md).
* By default, circular references are detected and exceptions thrown. You can [preserve references and handle circular references](system-text-json-preserve-references.md).
* By default, [fields](../../csharp/programming-guide/classes-and-structs/fields.md) are ignored. You can [include fields](#include-fields).

When you use System.Text.Json indirectly in an ASP.NET Core app, some default behaviors are different. For more information, see [Web defaults for JsonSerializerOptions](system-text-json-configure-options.md#web-defaults-for-jsonserializeroptions).
::: zone-end

::: zone pivot="dotnet-core-3-1"

* By default, all public properties are serialized. You can [specify properties to ignore](system-text-json-ignore-properties.md).
* The [default encoder](xref:System.Text.Encodings.Web.JavaScriptEncoder.Default) escapes non-ASCII characters, HTML-sensitive characters within the ASCII-range, and characters that must be escaped according to [the RFC 8259 JSON spec](https://tools.ietf.org/html/rfc8259#section-7).
* By default, JSON is minified. You can [pretty-print the JSON](#serialize-to-formatted-json).
* By default, casing of JSON names matches the .NET names. You can [customize JSON name casing](system-text-json-customize-properties.md).
* Circular references are detected and exceptions thrown.
* [Fields](../../csharp/programming-guide/classes-and-structs/fields.md) are ignored.
::: zone-end

Supported types include:
::: zone pivot="dotnet-5-0,dotnet-6-0"

* .NET primitives that map to JavaScript primitives, such as numeric types, strings, and Boolean.
* User-defined [plain old CLR objects (POCOs)](https://en.wikipedia.org/wiki/Plain_old_CLR_object).
* One-dimensional and jagged arrays (`T[][]`).
* Collections and dictionaries from the following namespaces.
  * <xref:System.Collections>
  * <xref:System.Collections.Generic>
  * <xref:System.Collections.Immutable>
  * <xref:System.Collections.Concurrent>
  * <xref:System.Collections.Specialized>
  * <xref:System.Collections.ObjectModel>
::: zone-end

::: zone pivot="dotnet-core-3-1"

* .NET primitives that map to JavaScript primitives, such as numeric types, strings, and Boolean.
* User-defined [plain old CLR objects (POCOs)](https://en.wikipedia.org/wiki/Plain_old_CLR_object).
* One-dimensional and jagged arrays (`ArrayName[][]`).
* `Dictionary<string,TValue>` where `TValue` is `object`, `JsonElement`, or a POCO.
* Collections from the following namespaces.
  * <xref:System.Collections>
  * <xref:System.Collections.Generic>
  * <xref:System.Collections.Immutable>
  * <xref:System.Collections.Concurrent>
  * <xref:System.Collections.Specialized>
  * <xref:System.Collections.ObjectModel>
::: zone-end

For more information, see [Supported collection types in System.Text.Json](system-text-json-supported-collection-types.md).

You can [implement custom converters](system-text-json-converters-how-to.md) to handle additional types or to provide functionality that isn't supported by the built-in converters.

## How to read JSON as .NET objects (deserialize)

A common way to deserialize JSON is to first create a class with properties and fields that represent one or more of the JSON properties. Then, to deserialize from a string or a file, call the <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> method. For the generic overloads, you pass the type of the class you created as the generic type parameter. For the non-generic overloads, you pass the type of the class you created as a method parameter. You can deserialize either synchronously or asynchronously. Any JSON properties that aren't represented in your class are ignored.

The following example shows how to deserialize a JSON string:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/DeserializeExtra.cs" highlight="55-56":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToString.vb" id="Deserialize":::

To deserialize from a file by using synchronous code, read the file into a string, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/DeserializeFromFile.cs" highlight="18-20":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToFile.vb" id="Deserialize":::

To deserialize from a file by using asynchronous code, call the <xref:System.Text.Json.JsonSerializer.DeserializeAsync%2A> method:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/DeserializeFromFileAsync.cs" highlight="19-22":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToFileAsync.vb" id="Deserialize":::

> [!TIP]
> If you have JSON that you want to deserialize, and you don't have the class to deserialize it into, you have options other than manually creating the class that you need:
>
> * Deserialize into a [JSON DOM (document object model)](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md) and extract what you need from the DOM.
>
>   The DOM lets you navigate to a subsection of a JSON payload and deserialize a single value, a custom type, or an array. For information about the <xref:System.Text.Json.Nodes.JsonNode> DOM in .NET 6, see [Deserialize subsections of a JSON payload](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md?pivots=dotnet-6-0#deserialize-subsections-of-a-json-payload). For information about the <xref:System.Text.Json.JsonDocument> DOM, see [How to search a JsonDocument and JsonElement for sub-elements](system-text-json-migrate-from-newtonsoft-how-to.md#how-to-search-a-jsondocument-and-jsonelement-for-sub-elements).
>
> * Use the [Utf8JsonReader](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md#use-utf8jsonreader) directly.
> * Use Visual Studio 2019 to automatically generate the class you need:
>   * Copy the JSON that you need to deserialize.
>   * Create a class file and delete the template code.
>   * Choose **Edit** > **Paste Special** > **Paste JSON as Classes**.
>   The result is a class that you can use for your deserialization target.

## Deserialize from UTF-8

To deserialize from UTF-8, call a <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> overload that takes a `ReadOnlySpan<byte>` or a `Utf8JsonReader`, as shown in the following examples. The examples assume the JSON is in a byte array named jsonUtf8Bytes.

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripToUtf8.cs" id="Deserialize1":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToUtf8.vb" id="Deserialize1":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripToUtf8.cs" id="Deserialize2":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToUtf8.vb" id="Deserialize2":::

## Deserialization behavior

The following behaviors apply when deserializing JSON:

::: zone pivot="dotnet-5-0,dotnet-6-0"

* By default, property name matching is case-sensitive. You can [specify case-insensitivity](system-text-json-character-casing.md).
* If the JSON contains a value for a read-only property, the value is ignored and no exception is thrown.
* Non-public constructors are ignored by the serializer.
* Deserialization to immutable objects or properties that don't have public `set` accessors is supported. See [Immutable types and Records](system-text-json-immutability.md).
* By default, enums are supported as numbers. You can [serialize enum names as strings](system-text-json-customize-properties.md#enums-as-strings).
* By default, fields are ignored. You can [include fields](#include-fields).
* By default, comments or trailing commas in the JSON throw exceptions. You can [allow comments and trailing commas](system-text-json-invalid-json.md).
* The [default maximum depth](xref:System.Text.Json.JsonReaderOptions.MaxDepth) is 64.

When you use System.Text.Json indirectly in an ASP.NET Core app, some default behaviors are different. For more information, see [Web defaults for JsonSerializerOptions](system-text-json-configure-options.md#web-defaults-for-jsonserializeroptions).
::: zone-end

::: zone pivot="dotnet-core-3-1"

* By default, property name matching is case-sensitive. You can [specify case-insensitivity](system-text-json-character-casing.md). ASP.NET Core apps [specify case-insensitivity by default](system-text-json-configure-options.md#web-defaults-for-jsonserializeroptions).
* If the JSON contains a value for a read-only property, the value is ignored and no exception is thrown.
* A parameterless constructor, which can be public, internal, or private, is used for deserialization.
* Deserialization to immutable objects or properties that don't have public `set` accessors isn't supported.
* By default, enums are supported as numbers. You can [serialize enum names as strings](system-text-json-customize-properties.md#enums-as-strings).
* Fields aren't supported.
* By default, comments or trailing commas in the JSON throw exceptions. You can [allow comments and trailing commas](system-text-json-invalid-json.md).
* The [default maximum depth](xref:System.Text.Json.JsonReaderOptions.MaxDepth) is 64.

When you use System.Text.Json indirectly in an ASP.NET Core app, some default behaviors are different. For more information, see [Web defaults for JsonSerializerOptions](system-text-json-configure-options.md#web-defaults-for-jsonserializeroptions).
::: zone-end

You can [implement custom converters](system-text-json-converters-how-to.md) to provide functionality that isn't supported by the built-in converters.

## Serialize to formatted JSON

To pretty-print the JSON output, set <xref:System.Text.Json.JsonSerializerOptions.WriteIndented?displayProperty=nameWithType> to `true`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeWriteIndented.cs" highlight="24-25":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripToString.vb" id="SerializePrettyPrint":::

If you use `JsonSerializerOptions` repeatedly with the same options, don't create a new `JsonSerializerOptions` instance each time you use it. Reuse the same instance for every call. For more information, see [Reuse JsonSerializerOptions instances](system-text-json-configure-options.md#reuse-jsonserializeroptions-instances).

## Include fields

::: zone pivot="dotnet-5-0,dotnet-6-0"
Use the <xref:System.Text.Json.JsonSerializerOptions.IncludeFields?displayProperty=nameWithType> global setting or the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute to include fields when serializing or deserializing, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/Fields.cs" highlight="16,18,20,32-35":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/Fields.vb" :::

To ignore read-only fields, use the <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields%2A?displayProperty=nameWithType> global setting.
::: zone-end

::: zone pivot="dotnet-core-3-1"
Fields are not supported in System.Text.Json in .NET Core 3.1. [Custom converters](system-text-json-converters-how-to.md) can provide this functionality.
::: zone-end

## HttpClient and HttpContent extension methods

::: zone pivot="dotnet-5-0,dotnet-6-0"

Serializing and deserializing JSON payloads from the network are common operations. Extension methods on [HttpClient](xref:System.Net.Http.Json.HttpClientJsonExtensions) and [HttpContent](xref:System.Net.Http.Json.HttpContentJsonExtensions) let you do these operations in a single line of code. These extension methods use [web defaults for JsonSerializerOptions](system-text-json-configure-options.md#web-defaults-for-jsonserializeroptions).

The following example illustrates use of <xref:System.Net.Http.Json.HttpClientJsonExtensions.GetFromJsonAsync%2A?displayProperty=nameWithType> and <xref:System.Net.Http.Json.HttpClientJsonExtensions.PostAsJsonAsync%2A?displayProperty=nameWithType>:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/HttpClientExtensionMethods.cs" highlight="26,33":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/HttpClientExtensionMethods.vb" :::

There are also extension methods for System.Text.Json on [HttpContent](xref:System.Net.Http.Json.HttpContentJsonExtensions).
::: zone-end

::: zone pivot="dotnet-core-3-1"
Extension methods on `HttpClient` and `HttpContent` are not available in System.Text.Json in .NET Core 3.1.
::: zone-end

## See also

* [System.Text.Json overview](system-text-json-overview.md)
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
