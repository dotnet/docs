---
title: "How to serialize JSON in C#"
description: "Learn how to use the System.Text.Json namespace to serialize to JSON in .NET. Includes sample code."
ms.date: 9/04/2024
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
ms.topic: how-to
ms.collection: ce-skilling-ai-copilot
ms.custom: vs-copilot-horizontal
adobe-target: true
---

# How to write .NET objects as JSON (serialize)

This article shows how to use the <xref:System.Text.Json?displayProperty=fullName> namespace to serialize to JavaScript Object Notation (JSON). If you're porting existing code from `Newtonsoft.Json`, see [How to migrate to `System.Text.Json`](migrate-from-newtonsoft.md).

> [!TIP]
> You can use AI assistance to [serialize to JSON with GitHub Copilot](#use-github-copilot-to-serialize-to-json).

To write JSON to a string or to a file, call the <xref:System.Text.Json.JsonSerializer.Serialize%2A?displayProperty=nameWithType> method.

## Serialization examples

The following example creates JSON as a string:

:::code language="csharp" source="snippets/how-to/csharp/SerializeBasic.cs" id="all" highlight="23":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToString.vb" id="Serialize":::

The JSON output is *minified* (whitespace, indentation, and new-line characters are removed) by default.

The following example uses synchronous code to create a JSON file:

:::code language="csharp" source="snippets/how-to/csharp/SerializeToFile.cs" highlight="23-25":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToFile.vb" id="Serialize":::

The following example uses asynchronous code to create a JSON file:

:::code language="csharp" source="snippets/how-to/csharp/SerializeToFileAsync.cs" highlight="23-26":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToFileAsync.vb" id="Serialize":::

The preceding examples use type inference for the type being serialized. An overload of `Serialize()` takes a generic type parameter:

:::code language="csharp" source="snippets/how-to/csharp/SerializeWithGenericParameter.cs" highlight="23":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToString.vb" id="SerializeWithGenericParameter":::

You can also use GitHub Copilot to generate serialization code for you. For instructions, see the [Use GitHub Copilot](#use-github-copilot-to-serialize-to-json) section in this article.

## Serialization behavior

* By default, all public properties are serialized. You can [specify properties to ignore](ignore-properties.md). You can also include [private members](immutability.md#non-public-members-and-property-accessors).
* The [default encoder](xref:System.Text.Encodings.Web.JavaScriptEncoder.Default) escapes non-ASCII characters, HTML-sensitive characters within the ASCII-range, and characters that must be escaped according to [the RFC 8259 JSON spec](https://tools.ietf.org/html/rfc8259#section-7).
* By default, JSON is minified. You can [pretty-print the JSON](#serialize-to-formatted-json).
* By default, casing of JSON names matches the .NET names. You can [customize JSON name casing](customize-properties.md).
* By default, circular references are detected and exceptions thrown. You can [preserve references and handle circular references](preserve-references.md).
* By default, [fields](../../../csharp/programming-guide/classes-and-structs/fields.md) are ignored. You can [include fields](fields.md).

When you use System.Text.Json indirectly in an ASP.NET Core app, some default behaviors are different. For more information, see [Web defaults for JsonSerializerOptions](configure-options.md#web-defaults-for-jsonserializeroptions).

Supported types include:

* .NET primitives that map to JavaScript primitives, such as numeric types, strings, and Boolean.
* User-defined [plain old CLR objects (POCOs)](../../glossary.md#poco).
* One-dimensional and jagged arrays (`T[][]`).
* Collections and dictionaries from the following namespaces:

  * <xref:System.Collections>
  * <xref:System.Collections.Generic>
  * <xref:System.Collections.Immutable>
  * <xref:System.Collections.Concurrent>
  * <xref:System.Collections.Specialized>
  * <xref:System.Collections.ObjectModel>

  For more information, see [Supported types in System.Text.Json](supported-types.md).

You can [implement custom converters](converters-how-to.md) to handle additional types or to provide functionality that isn't supported by the built-in converters.

Here's an example showing how a class that contains collection properties and a user-defined type is serialized:

:::code language="csharp" source="snippets/how-to/csharp/SerializeExtra.cs" highlight="42-43":::
:::code language="vb" source="snippets/how-to/vb/WeatherForecast.vb" id="WFWithPOCOs":::

## Serialize to UTF-8

It's 5-10% faster to serialize to a UTF-8 byte array than to use the string-based methods. That's because the bytes (as UTF-8) don't need to be converted to strings (UTF-16).

To serialize to a UTF-8 byte array, call the <xref:System.Text.Json.JsonSerializer.SerializeToUtf8Bytes%2A?displayProperty=nameWithType> method:

:::code language="csharp" source="snippets/how-to/csharp/RoundtripToUtf8.cs" id="Serialize":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToUtf8.vb" id="Serialize":::

A <xref:System.Text.Json.JsonSerializer.Serialize%2A> overload that takes a <xref:System.Text.Json.Utf8JsonWriter> is also available.

## Serialize to formatted JSON

To pretty-print the JSON output, set <xref:System.Text.Json.JsonSerializerOptions.WriteIndented?displayProperty=nameWithType> to `true`:

:::code language="csharp" source="snippets/how-to/csharp/SerializeWriteIndented.cs" highlight="24":::
:::code language="vb" source="snippets/how-to/vb/RoundtripToString.vb" id="SerializePrettyPrint":::

Starting in .NET 9, you can also customize the indent character and size using <xref:System.Text.Json.JsonSerializerOptions.IndentCharacter> and <xref:System.Text.Json.JsonSerializerOptions.IndentSize>.

> [!TIP]
> If you use `JsonSerializerOptions` repeatedly with the same options, don't create a new `JsonSerializerOptions` instance each time you use it. Reuse the same instance for every call. For more information, see [Reuse JsonSerializerOptions instances](configure-options.md#reuse-jsonserializeroptions-instances).

## Use GitHub Copilot to serialize to JSON

You can use GitHub Copilot in your IDE to generate code that uses `System.Text.Json` to serialize to JSON. You can customize the prompt to use object fields that suit your requirements.

The following text shows an example prompt for Copilot Chat:

```copilot-prompt
Generate code to use System.Text.Json to serialize an object to a JSON string.
The object contains the following fields: FirstName (string), Lastname (string), Age (int).
Provide example output.
```

GitHub Copilot is powered by AI, so surprises and mistakes are possible. For more information, see [Copilot FAQs](https://aka.ms/copilot-general-use-faqs).

Learn more about [GitHub Copilot in Visual Studio](/visualstudio/ide/visual-studio-github-copilot-install-and-states) and [GitHub Copilot in VS Code](https://code.visualstudio.com/docs/copilot/overview).
