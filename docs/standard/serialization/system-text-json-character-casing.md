---
title: How to control character casing with System.Text.Json
description: "Learn how to control character casing while serializing to and deserializing from JSON in .NET."
ms.date: 11/19/2020
no-loc: [System.Text.Json, Newtonsoft.Json]
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# How to control character casing with System.Text.Json

In this article, you will learn how to control character casing with the `System.Text.Json` namespace.

## Case-insensitive property matching

By default, deserialization looks for case-sensitive property name matches between JSON and the target object properties. To change that behavior, set <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive?displayProperty=nameWithType> to `true`:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/DeserializeCaseInsensitive.cs" id="Deserialize":::

Here's example JSON with camel case property names. It can be deserialized into the following type that has Pascal case property names.

```json
{
  "date": "2019-08-01T00:00:00-07:00",
  "temperatureCelsius": 25,
  "summary": "Hot",
}
```

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WF":::

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [How to configure serialization options](system-text-json-configure-options.md)
* [How to ignore properties](system-text-json-ignore-properties.md)
* [How to customize property names](system-text-json-customize-properties.md)
* [System.Text.Json API reference](xref:System.Text.Json)
