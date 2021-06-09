---
title: How to handle overflow JSON with System.Text.Json
description: "Learn how to handle overflow JSON while serializing to and deserializing from JSON in .NET."
ms.date: 11/30/2020
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

# How to handle overflow JSON with System.Text.Json

This article shows how to handle overflow JSON with the [`System.Text.Json`](xref:System.Text.Json) namespace.

## Handle overflow JSON

While deserializing, you might receive data in the JSON that is not represented by properties of the target type. For example, suppose your target type is this:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WF":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WF":::

And the JSON to be deserialized is this:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "temperatureCelsius": 25,
  "Summary": "Hot",
  "DatesAvailable": [
    "2019-08-01T00:00:00-07:00",
    "2019-08-02T00:00:00-07:00"
  ],
  "SummaryWords": [
    "Cool",
    "Windy",
    "Humid"
  ]
}
```

If you deserialize the JSON shown into the type shown, the `DatesAvailable` and `SummaryWords` properties have nowhere to go and are lost. To capture extra data such as these properties, apply the [[JsonExtensionData]](xref:System.Text.Json.Serialization.JsonExtensionDataAttribute) attribute to a property of type `Dictionary<string,object>` or `Dictionary<string,JsonElement>`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithExtensionData":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithExtensionData":::

The following table shows the result of deserializing the JSON shown earlier into this sample type. The extra data becomes key-value pairs of the `ExtensionData` property:

| Property | Value | Notes |
|--|--|--|
| `Date` | `"8/1/2019 12:00:00 AM -07:00"` |  |
| `TemperatureCelsius` | `0` | Case-sensitive mismatch (`temperatureCelsius` in the JSON), so the property isn't set. |
| `Summary` | `"Hot"` |  |
| `ExtensionData` | `"temperatureCelsius": 25,`<br>`"DatesAvailable": ["2019-08-01T00:00:00-07:00","2019-08-02T00:00:00-07:00"],`<br>`"SummaryWords": ["Cool","Windy","Humid"]`| Since the case didn't match, `temperatureCelsius` is an extra and becomes a key-value pair in the dictionary. <br>Each extra array from the JSON becomes a key-value pair, with an array as the value object.|

When the target object is serialized, the extension data key value pairs become JSON properties just as they were in the incoming JSON:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 0,
  "Summary": "Hot",
  "temperatureCelsius": 25,
  "DatesAvailable": [
    "2019-08-01T00:00:00-07:00",
    "2019-08-02T00:00:00-07:00"
  ],
  "SummaryWords": [
    "Cool",
    "Windy",
    "Humid"
  ]
}
```

Notice that the `ExtensionData` property name doesn't appear in the JSON. This behavior lets the JSON make a round trip without losing any extra data that otherwise wouldn't be deserialized.

The following example shows a round trip from JSON to a deserialized object and back to JSON:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripExtensionData.cs" highlight="13-14":::

## Deserialize into JsonElement

If you just want to be flexible about what JSON to accept for a particular property, an alternative is to deserialize into <xref:System.Text.Json.JsonElement>. Any valid JSON property can be deserialized into `JsonElement`. The following example shows a round trip from JSON and back to JSON for a class that includes properties of type `JsonElement`.

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/RoundtripJsonElement.cs" highlight="11-12":::

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [How to serialize and deserialize JSON](system-text-json-how-to.md)
* [Instantiate JsonSerializerOptions instances](system-text-json-configure-options.md)
* [Enable case-insensitive matching](system-text-json-character-casing.md)
* [Customize property names and values](system-text-json-customize-properties.md)
* [Ignore properties](system-text-json-ignore-properties.md)
* [Allow invalid JSON](system-text-json-invalid-json.md)
* [Preserve references](system-text-json-preserve-references.md)
* [Immutable types and non-public accessors](system-text-json-immutability.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md)
* [Customize character encoding](system-text-json-character-encoding.md)
* [Use the JSON DOM, Utf8JsonReader, and Utf8JsonWriter](system-text-json-use-dom-utf8jsonreader-utf8jsonwriter.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
