---
title: How to customize property names and values with System.Text.Json
description: "Learn how to customize property names and values when serializing with System.Text.Json in .NET."
ms.date: 08/25/2021
zone_pivot_groups: dotnet-version
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

# How to customize property names and values with System.Text.Json

:::zone pivot="dotnet-6-0,dotnet-5-0,dotnet-core-3-1"
By default, property names and dictionary keys are unchanged in the JSON output, including case. Enum values are represented as numbers. In this article, you'll learn how to:
::: zone-end

* [Customize individual property names](#customize-individual-property-names)
* [Convert all property names to camel case](#use-camel-case-for-all-json-property-names)
* [Implement a custom property naming policy](#use-a-custom-json-property-naming-policy)
* [Convert dictionary keys to camel case](#camel-case-dictionary-keys)
* [Convert enums to strings and camel case](#enums-as-strings)

:::zone pivot="dotnet-6-0"

* [Configure the order of serialized properties](#configure-the-order-of-serialized-properties)
::: zone-end

> [!NOTE]
> The [web default](system-text-json-configure-options.md#web-defaults-for-jsonserializeroptions) is camel case.

For other scenarios that require special handling of JSON property names and values, you can [implement custom converters](system-text-json-converters-how-to.md).

## Customize individual property names

To set the name of individual properties, use the [[JsonPropertyName]](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) attribute.

Here's an example type to serialize and resulting JSON:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithPropertyNameAttribute":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithPropertyNameAttribute":::

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
  "Wind": 35
}
```

The property name set by this attribute:

* Applies in both directions, for serialization and deserialization.
* Takes precedence over property naming policies.
* [Doesn't affect parameter name matching for parameterized constructors](system-text-json-immutability.md#immutable-types-and-records).

## Use camel case for all JSON property names

To use camel case for all JSON property names, set <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy?displayProperty=nameWithType> to `JsonNamingPolicy.CamelCase`, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundTripCamelCasePropertyNames.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundTripCamelCasePropertyNames.vb" id="Serialize":::

Here's an example class to serialize and JSON output:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithPropertyNameAttribute":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithPropertyNameAttribute":::

```json
{
  "date": "2019-08-01T00:00:00-07:00",
  "temperatureCelsius": 25,
  "summary": "Hot",
  "Wind": 35
}
```

The camel case property naming policy:

* Applies to serialization and deserialization.
* Is overridden by `[JsonPropertyName]` attributes. This is why the JSON property name `Wind` in the example is not camel case.

## Use a custom JSON property naming policy

To use a custom JSON property naming policy, create a class that derives from <xref:System.Text.Json.JsonNamingPolicy> and override the <xref:System.Text.Json.JsonNamingPolicy.ConvertName%2A> method, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/UpperCaseNamingPolicy.cs":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/UpperCaseNamingPolicy.vb":::

Then set the <xref:System.Text.Json.JsonSerializerOptions.PropertyNamingPolicy?displayProperty=nameWithType> property to an instance of your naming policy class:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripPropertyNamingPolicy.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripPropertyNamingPolicy.vb" id="Serialize":::

Here's an example class to serialize and JSON output:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithPropertyNameAttribute":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithPropertyNameAttribute":::

```json
{
  "DATE": "2019-08-01T00:00:00-07:00",
  "TEMPERATURECELSIUS": 25,
  "SUMMARY": "Hot",
  "Wind": 35
}
```

The JSON property naming policy:

* Applies to serialization and deserialization.
* Is overridden by `[JsonPropertyName]` attributes. This is why the JSON property name `Wind` in the example is not upper case.

## Camel case dictionary keys

If a property of an object to be serialized is of type `Dictionary<string,TValue>`, the `string` keys can be converted to camel case. To do that, set <xref:System.Text.Json.JsonSerializerOptions.DictionaryKeyPolicy> to `JsonNamingPolicy.CamelCase`, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeCamelCaseDictionaryKeys.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializeCamelCaseDictionaryKeys.vb" id="Serialize":::

Serializing an object with a dictionary named `TemperatureRanges` that has key-value pairs `"ColdMinTemp", 20` and `"HotMinTemp", 40` would result in JSON output like the following example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
  "TemperatureRanges": {
    "coldMinTemp": 20,
    "hotMinTemp": 40
  }
}
```

The camel case naming policy for dictionary keys applies to serialization only. If you deserialize a dictionary, the keys will match the JSON file even if you specify `JsonNamingPolicy.CamelCase` for the `DictionaryKeyPolicy`.

## Enums as strings

By default, enums are serialized as numbers. To serialize enum names as strings, use the <xref:System.Text.Json.Serialization.JsonStringEnumConverter>.

For example, suppose you need to serialize the following class that has an enum:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithEnum":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithEnum":::

If the Summary is `Hot`, by default the serialized JSON has the numeric value 3:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": 3
}
```

The following sample code serializes the enum names instead of the numeric values, and converts the names to camel case:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripEnumAsString.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripEnumAsString.vb" id="Serialize":::

The resulting JSON looks like the following example:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "hot"
}
```

The built-in <xref:System.Text.Json.Serialization.JsonStringEnumConverter> can deserialize string values as well. It works without a specified naming policy or with the <xref:System.Text.Json.JsonNamingPolicy.CamelCase> naming policy. It doesn't support other naming policies, such as snake case. The following example shows deserialization using `CamelCase`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripEnumAsString.cs" id="Deserialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/RoundtripEnumAsString.vb" id="Deserialize":::

For information about custom converter code that supports deserialization while using a snake case naming policy, see [Support enum string value deserialization](system-text-json-converters-how-to.md#support-enum-string-value-deserialization).

:::zone pivot="dotnet-6-0"

## Configure the order of serialized properties

The [`[JsonPropertyOrder]`](xref:System.Text.Json.Serialization.JsonPropertyOrderAttribute) attribute lets you specify the order of properties in the JSON output from serialization. The default value of the `Order` property is zero. Set `Order` to a positive number to position a property after those that have the default value. A negative `Order` positions a property before those that have the default value. Properties are written in order from the lowest `Order` value to the highest. Here's an example:

:::code language="csharp" source="snippets/system-text-json-how-to-6-0/csharp/PropertyOrder.cs":::
::: zone-end

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [How to serialize and deserialize JSON](system-text-json-how-to.md)
* [Instantiate JsonSerializerOptions instances](system-text-json-configure-options.md)
* [Enable case-insensitive matching](system-text-json-character-casing.md)
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
