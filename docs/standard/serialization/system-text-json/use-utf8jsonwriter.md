---
title: How to use Utf8JsonWriter in System.Text.Json
description: "Learn how to use Utf8JsonWriter."
ms.date: 03/29/2022
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to use Utf8JsonWriter in System.Text.Json

This article shows how to use the <xref:System.Text.Json.Utf8JsonWriter> type for building custom serializers.

<xref:System.Text.Json.Utf8JsonWriter> is a high-performance way to write UTF-8 encoded JSON text from common .NET types like `String`, `Int32`, and `DateTime`. The writer is a low-level type that can be used to build custom serializers. The <xref:System.Text.Json.JsonSerializer.Serialize%2A?displayProperty=nameWithType> method uses `Utf8JsonWriter` under the covers.

The following example shows how to use the <xref:System.Text.Json.Utf8JsonWriter> class:

:::code language="csharp" source="snippets/how-to/csharp/Utf8WriterToStream.cs" id="Serialize":::
:::code language="vb" source="snippets/how-to/vb/Utf8WriterToStream.vb" id="Serialize":::

## Write with UTF-8 text

To achieve the best possible performance while using the `Utf8JsonWriter`, write JSON payloads already encoded as UTF-8 text rather than as UTF-16 strings. Use <xref:System.Text.Json.JsonEncodedText> to cache and pre-encode known string property names and values as statics, and pass those to the writer, rather than using UTF-16 string literals. This is faster than caching and using UTF-8 byte arrays.

This approach also works if you need to do custom escaping. `System.Text.Json` doesn't let you disable escaping while writing a string. However, you could pass in your own custom <xref:System.Text.Encodings.Web.JavaScriptEncoder> as an option to the writer, or create your own `JsonEncodedText` that uses your `JavascriptEncoder` to do the escaping, and then write the `JsonEncodedText` instead of the string. For more information, see [Customize character encoding](character-encoding.md).

## Write raw JSON

In some scenarios, you might want to write "raw" JSON to a JSON payload that you're creating with `Utf8JsonWriter`. You can use <xref:System.Text.Json.Utf8JsonWriter.WriteRawValue%2A?displayProperty=nameWithType> to do that. Here are typical scenarios:

* You have an existing JSON payload that you want to enclose in new JSON.
* You want to format values differently from the default `Utf8JsonWriter` formatting.

  For example, you might want to customize number formatting. By default, System.Text.Json omits the decimal point for whole numbers, writing `1` rather than `1.0`, for example. The rationale is that writing fewer bytes is good for performance. But suppose the consumer of your JSON treats numbers with decimals as doubles, and numbers without decimals as integers. You might want to ensure that the numbers in an array are all recognized as doubles, by writing a decimal point and zero for whole numbers. The following example shows how to do that:

  :::code language="csharp" source="snippets/use-dom-utf8jsonreader-utf8jsonwriter/csharp/WriteRawJson.cs":::

## Customize character escaping

The [StringEscapeHandling](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_StringEscapeHandling.htm) setting of `JsonTextWriter` offers options to escape all non-ASCII characters **or** HTML characters. By default, `Utf8JsonWriter` escapes all non-ASCII **and** HTML characters. This escaping is done for defense-in-depth security reasons. To specify a different escaping policy, create a <xref:System.Text.Encodings.Web.JavaScriptEncoder> and set <xref:System.Text.Json.JsonWriterOptions.Encoder?displayProperty=nameWithType>. For more information, see [Customize character encoding](character-encoding.md).

## Write null values

To write null values by using `Utf8JsonWriter`, call:

* <xref:System.Text.Json.Utf8JsonWriter.WriteNull%2A> to write a key-value pair with null as the value.
* <xref:System.Text.Json.Utf8JsonWriter.WriteNullValue%2A> to write null as an element of a JSON array.

For a string property, if the string is null, <xref:System.Text.Json.Utf8JsonWriter.WriteString%2A> and <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue%2A> are equivalent to `WriteNull` and `WriteNullValue`.

## Write Timespan, Uri, or char values

To write `Timespan`, `Uri`, or `char` values, format them as strings (by calling `ToString()`, for example) and call <xref:System.Text.Json.Utf8JsonWriter.WriteStringValue%2A>.

## See also

* [How to use Utf8JsonReader in System.Text.Json](use-utf8jsonreader.md)
