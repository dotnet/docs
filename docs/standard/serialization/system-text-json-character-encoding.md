---
title: How to customize character encoding with System.Text.Json
description: "Learn how to customize character encoding while serializing to and deserializing from JSON in .NET."
ms.date: 01/22/2021
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
---

# How to customize character encoding with System.Text.Json

By default, the serializer escapes all non-ASCII characters. That is, it replaces them with `\uxxxx` where `xxxx` is the Unicode code of the character. For example, if the `Summary` property in the following JSON is set to Cyrillic `жарко`, the `WeatherForecast` object is serialized as shown in this example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "\u0436\u0430\u0440\u043A\u043E"
}
```

## Serialize language character sets

To serialize the character set(s) of one or more languages without escaping, specify [Unicode range(s)](xref:System.Text.Unicode.UnicodeRanges) when creating an instance of <xref:System.Text.Encodings.Web.JavaScriptEncoder?displayProperty=fullName>, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeCustomEncoding.cs" id="Usings":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializeCustomEncoding.vb" id="Usings":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeCustomEncoding.cs" id="LanguageSets":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializeCustomEncoding.vb" id="LanguageSets":::

This code doesn't escape Cyrillic or Greek characters. If the `Summary` property is set to Cyrillic `жарко`, the `WeatherForecast` object is serialized as shown in this example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "жарко"
}
```

By default, the encoder is initialized with the <xref:System.Text.Unicode.UnicodeRanges.BasicLatin> range.

To serialize all language sets without escaping, use <xref:System.Text.Unicode.UnicodeRanges.All?displayProperty=nameWithType>.

## Serialize specific characters

An alternative is to specify individual characters that you want to allow through without being escaped. The following example serializes only the first two characters of `жарко`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeCustomEncoding.cs" id="Usings":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializeCustomEncoding.vb" id="Usings":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeCustomEncoding.cs" id="SelectedCharacters":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializeCustomEncoding.vb" id="SelectedCharacters":::

Here's an example of JSON produced by the preceding code:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "жа\u0440\u043A\u043E"
}
```

## Block lists

The preceding sections show how to specify allow lists of code points or ranges that you don't want to be escaped. However, there are global and encoder-specific block lists that can override certain code points in your allow list. Code points in a block list are always escaped, even if they're included in your allow list.

### Global block list

The global block list includes things like private-use characters, control characters, undefined code points, and certain Unicode categories, such as the [Space_Separator category](https://util.unicode.org/UnicodeJsps/list-unicodeset.jsp?a=%5B:General_Category=Space_Separator:%5D), excluding `U+0020 SPACE`. For example, `U+3000 IDEOGRAPHIC SPACE` is escaped even if you specify Unicode range [CJK Symbols and Punctuation (U+3000-U+303F)](xref:System.Text.Unicode.UnicodeRanges.CjkSymbolsandPunctuation) as your allow list.

The global block list is an implementation detail that has changed in every release of .NET Core and in .NET 5. Don't take a dependency on a character being a member of (or not being a member of) the global block list.

### Encoder-specific block lists

Examples of encoder-specific blocked code points include `'<'` and `'&'` for the [HTML encoder](xref:System.Text.Encodings.Web.HtmlEncoder), `'\'` for the [JSON encoder](xref:System.Text.Encodings.Web.JavaScriptEncoder), and `'%'` for the [URL encoder](xref:System.Text.Encodings.Web.UrlEncoder). For example, the HTML encoder always escapes ampersands (`'&'`), even though the ampersand is in the `BasicLatin` range and all the encoders are initialized with `BasicLatin` by default.

## Serialize all characters

To minimize escaping you can use <xref:System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping?displayProperty=nameWithType>, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeCustomEncoding.cs" id="Usings":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializeCustomEncoding.vb" id="Usings":::

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeCustomEncoding.cs" id="UnsafeRelaxed":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializeCustomEncoding.vb" id="UnsafeRelaxed":::

> [!CAUTION]
> Compared to the default encoder, the `UnsafeRelaxedJsonEscaping` encoder is more permissive about allowing characters to pass through unescaped:
>
> * It doesn't escape HTML-sensitive characters such as `<`, `>`, `&`, and `'`.
> * It doesn't offer any additional defense-in-depth protections against XSS or information disclosure attacks, such as those which might result from the client and server disagreeing on the *charset*.
>
> Use the unsafe encoder only when it's known that the client will be interpreting the resulting payload as UTF-8 encoded JSON. For example, you can use it if the server is sending the response header `Content-Type: application/json; charset=utf-8`. Never allow the raw `UnsafeRelaxedJsonEscaping` output to be emitted into an HTML page or a `<script>` element.

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [How to serialize and deserialize JSON](system-text-json-how-to.md)
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
* [Use DOM, Utf8JsonReader, and Utf8JsonWriter](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [How to use source generation](system-text-json-source-generation.md)
* [Supported collection types](system-text-json-supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
