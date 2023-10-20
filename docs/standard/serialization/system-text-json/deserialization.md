---
title: "How to deserialize JSON in C#"
description: "Learn how to use the System.Text.Json namespace to deserialize from JSON in .NET. Includes sample code."
ms.date: 10/19/2023
no-loc: [System.Text.Json, Newtonsoft.Json]
zone_pivot_groups: dotnet-preview-version
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "JSON deserialization"
  - "deserializing objects"
  - "deserialization"
ms.topic: how-to
---

# How to read JSON as .NET objects (deserialize)

This article shows how to use the <xref:System.Text.Json?displayProperty=fullName> namespace to serialize to and deserialize from JavaScript Object Notation (JSON). If you're porting existing code from `Newtonsoft.Json`, see [How to migrate to `System.Text.Json`](migrate-from-newtonsoft.md).

A common way to deserialize JSON is to have (or create) a .NET class with properties and fields that represent one or more of the JSON properties. Then, to deserialize from a string or a file, call the <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> method. For the generic overloads, the generic type parameter is the .NET class. For the non-generic overloads, you pass the type of the class as a method parameter. You can deserialize either synchronously or asynchronously.

Any JSON properties that aren't represented in your class are ignored [by default](missing-members.md). Also, if any properties on the type are [required](required-properties.md) but not present in the JSON payload, deserialization will fail.

The following example shows how to deserialize a JSON string:

:::code language="csharp" source="snippets/how-to/csharp/DeserializeExtra.cs" highlight="53-54":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToString.vb" id="Deserialize":::

To deserialize from a file by using synchronous code, read the file into a string, as shown in the following example:

:::code language="csharp" source="snippets/how-to/csharp/DeserializeFromFile.cs" highlight="16-18":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToFile.vb" id="Deserialize":::

To deserialize from a file by using asynchronous code, call the <xref:System.Text.Json.JsonSerializer.DeserializeAsync%2A> method:

:::code language="csharp" source="snippets/how-to/csharp/DeserializeFromFileAsync.cs" highlight="17-20":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToFileAsync.vb" id="Deserialize":::

## Deserialization behavior

The following behaviors apply when deserializing JSON:

* By default, property name matching is case-sensitive. You can [specify case-insensitivity](character-casing.md).
* Non-public constructors are ignored by the serializer.
* Deserialization to immutable objects or properties that don't have public `set` accessors is supported but not enabled by default. See [Immutable types and records](immutability.md).
* By default, enums are supported as numbers. You can [deserialize string enum fields](customize-properties.md#enums-as-strings).
* By default, fields are ignored. You can [include fields](#include-fields).
* By default, comments or trailing commas in the JSON throw exceptions. You can [allow comments and trailing commas](invalid-json.md).
* The [default maximum depth](xref:System.Text.Json.JsonReaderOptions.MaxDepth) is 64.

When you use System.Text.Json indirectly in an ASP.NET Core app, some default behaviors are different. For more information, see [Web defaults for JsonSerializerOptions](configure-options.md#web-defaults-for-jsonserializeroptions).

You can [implement custom converters](converters-how-to.md) to provide functionality that isn't supported by the built-in converters.

## Deserialize without a .NET class

If you have JSON that you want to deserialize, and you don't have the class to deserialize it into, you have options other than manually creating the class that you need:

* Use the [Utf8JsonReader](use-utf8jsonreader.md) directly.

* Deserialize into a [JSON DOM (document object model)](use-dom.md) and extract what you need from the DOM.

  The DOM lets you navigate to a subsection of a JSON payload and deserialize a single value, a custom type, or an array. For information about the <xref:System.Text.Json.Nodes.JsonNode> DOM, see [Deserialize subsections of a JSON payload](use-dom.md#deserialize-subsections-of-a-json-payload). For information about the <xref:System.Text.Json.JsonDocument> DOM, see [How to search a JsonDocument and JsonElement for sub-elements](migrate-from-newtonsoft.md#how-to-search-a-jsondocument-and-jsonelement-for-sub-elements).

* Use Visual Studio 2022 to automatically generate the class you need:

  * Copy the JSON that you need to deserialize.
  * Create a class file and delete the template code.
  * Choose **Edit** > **Paste Special** > **Paste JSON as Classes**.

  The result is a class that you can use for your deserialization target.

## Deserialize from UTF-8

To deserialize from UTF-8, call a <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> overload that takes a `ReadOnlySpan<byte>` or a `Utf8JsonReader`, as shown in the following examples. The examples assume the JSON is in a byte array named jsonUtf8Bytes.

:::code language="csharp" source="snippets/how-to/csharp/RoundtripToUtf8.cs" id="Deserialize1":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToUtf8.vb" id="Deserialize1":::

:::code language="csharp" source="snippets/how-to/csharp/RoundtripToUtf8.cs" id="Deserialize2":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToUtf8.vb" id="Deserialize2":::
