---
title: How to handle overflow JSON or use JsonElement or JsonNode in System.Text.Json
description: "Learn how to handle overflow JSON or use JsonElement or JsonNode while using System.Text.Json to serialize and deserialize JSON in .NET."
ms.date: 07/21/2021
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

# How to handle overflow JSON or use JsonElement or JsonNode in System.Text.Json

This article shows how to handle overflow JSON with the [`System.Text.Json`](xref:System.Text.Json) namespace. It also shows how to deserialize into <xref:System.Text.Json.JsonElement> or <xref:System.Text.Json.Nodes.JsonNode>, as an alternative for other scenarios where the target type might not perfectly match all of the JSON being deserialized.

## Handle overflow JSON

While deserializing, you might receive data in the JSON that is not represented by properties of the target type. For example, suppose your target type is this:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WF":::
:::code language="vb" source="snippets/how-to/vb/WeatherForecast.vb" id="WF":::

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

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithExtensionData":::
:::code language="vb" source="snippets/how-to/vb/WeatherForecast.vb" id="WFWithExtensionData":::

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

:::code language="csharp" source="snippets/how-to/csharp/RoundtripExtensionData.cs" highlight="11-12":::

## Deserialize into JsonElement or JsonNode

If you just want to be flexible about what JSON is acceptable for a particular property, an alternative is to deserialize into <xref:System.Text.Json.JsonElement> or <xref:System.Text.Json.Nodes.JsonNode>. Any valid JSON property can be deserialized into `JsonElement` or `JsonNode`. Choose `JsonElement` to create an immutable object or `JsonNode` to create a mutable object.

The following example shows a round trip from JSON and back to JSON for a class that includes properties of type `JsonElement` and `JsonNode`.

:::code language="csharp" source="snippets/how-to-6-0/csharp/RoundtripJsonElementAndNode.cs" highlight="11-12":::

## See also

* [System.Text.Json overview](overview.md)
* [How to serialize and deserialize JSON](how-to.md)
