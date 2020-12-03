---
title: How to enable case-insensitive property name matching with System.Text.Json
description: "Learn how to enable case-insensitive property name matching while serializing to and deserializing from JSON in .NET."
ms.date: 11/30/2020
no-loc: [System.Text.Json, Newtonsoft.Json]
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# How to enable case-insensitive property name matching with System.Text.Json

In this article, you will learn how to enable case-insensitive property name matching with the `System.Text.Json` namespace.

## Case-insensitive property matching

By default, deserialization looks for case-sensitive property name matches between JSON and the target object properties. To change that behavior, set <xref:System.Text.Json.JsonSerializerOptions.PropertyNameCaseInsensitive?displayProperty=nameWithType> to `true`:

> [!NOTE]
> The [web defaults](system-text-json-configure-options.md#web-defaults-for-jsonserializeroptions) is case-insensitive.

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
* [Instantiate JsonSerializerOptions](system-text-json-configure-options.md)
* [Customize property names and values](system-text-json-customize-properties.md)
* [Ignore properties](system-text-json-ignore-properties.md)
* [Allow invalid JSON](system-text-json-invalid-json.md)
* [Handle overflow JSON](system-text-json-handle-overflow.md)
* [Preserve circular references](system-text-json-preserve-references.md)
* [Immutable types and non-public accessors](system-text-json-immutability.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [System.Text.Json API reference](xref:System.Text.Json)
