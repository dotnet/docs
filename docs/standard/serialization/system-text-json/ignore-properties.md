---
title: How to ignore properties with System.Text.Json
description: "Learn how to ignore properties when serializing with System.Text.Json in .NET."
ms.date: 07/22/2022
ms.custom: devdivchpfy22
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

# How to ignore properties with System.Text.Json

When serializing C# objects to JavaScript Object Notation (JSON), by default, all public properties are serialized. If you don't want some of them to appear in the resulting JSON, you have several options. In this article, you learn how to ignore properties based on various criteria:

::: zone pivot="dotnet-5-0,dotnet-7-0,dotnet-6-0"

* [Individual properties](#ignore-individual-properties)
* [All read-only properties](#ignore-all-read-only-properties)
* [All null-value properties](#ignore-all-null-value-properties)
* [All default-value properties](#ignore-all-default-value-properties)
::: zone-end

::: zone pivot="dotnet-core-3-1"

* [Individual properties](#ignore-individual-properties)
* [All read-only properties](#ignore-all-read-only-properties)
* [All null-value properties](#ignore-all-null-value-properties)
::: zone-end

## Ignore individual properties

To ignore individual properties, use the [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute) attribute.

The following example shows a type to serialize. It also shows the JSON output:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithIgnoreAttribute":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithIgnoreAttribute":::

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
}
```

::: zone pivot="dotnet-5-0,dotnet-7-0,dotnet-6-0"
You can specify conditional exclusion by setting the [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute) attribute's `Condition` property. The <xref:System.Text.Json.Serialization.JsonIgnoreCondition> enum provides the following options:

* `Always` - The property is always ignored. If no `Condition` is specified, this option is assumed.
* `Never` - The property is always serialized and deserialized, regardless of the `DefaultIgnoreCondition`, `IgnoreReadOnlyProperties`, and `IgnoreReadOnlyFields` global settings.
* `WhenWritingDefault` - The property is ignored on serialization if it's a reference type `null`, a nullable value type `null`, or a value type `default`.
* `WhenWritingNull` - The property is ignored on serialization if it's a reference type `null`, or a nullable value type `null`.

The following example illustrates the use of the [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute) attribute's `Condition` property:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/JsonIgnoreAttributeExample.cs" highlight="8,11,14":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/JsonIgnoreAttributeExample.vb" :::
::: zone-end

## Ignore all read-only properties

A property is read-only if it contains a public getter but not a public setter. To ignore all read-only properties when serializing, set the <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyProperties?displayProperty=nameWithType> to `true`, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeExcludeReadOnlyProperties.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializeExcludeReadOnlyProperties.vb" id="Serialize":::

The following example shows a type to serialize. It also shows the JSON output:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/WeatherForecast.cs" id="WFWithROProperty":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/WeatherForecast.vb" id="WFWithROProperty":::

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
}
```

::: zone pivot="dotnet-core-3-1"
This option applies only to serialization. During deserialization, read-only properties are ignored by default.
::: zone-end

::: zone pivot="dotnet-5-0,dotnet-7-0,dotnet-6-0"
This option applies only to properties. To ignore read-only fields when [serializing fields](how-to.md#include-fields), use the <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields%2A?displayProperty=nameWithType> global setting.
::: zone-end

## Ignore all null-value properties

::: zone pivot="dotnet-5-0,dotnet-7-0,dotnet-6-0"
To ignore all null-value properties, set the <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition> property to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull>, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/IgnoreNullOnSerialize.cs" highlight="26":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/IgnoreNullOnSerialize.vb" :::

::: zone-end

::: zone pivot="dotnet-core-3-1"
To ignore all null-value properties when serializing or deserializing, set the <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues> property to `true`. The following example shows this option used for serialization:

:::code language="csharp" source="snippets/system-text-json-how-to/csharp/SerializeExcludeNullValueProperties.cs" id="Serialize":::
:::code language="vb" source="snippets/system-text-json-how-to/vb/SerializeExcludeNullValueProperties.vb" id="Serialize":::

The following example shows a type to serialize. It also shows the JSON output:

| Property             | Value                         |
|----------------------|-------------------------------|
| `Date`               | `8/1/2019 12:00:00 AM -07:00` |
| `TemperatureCelsius` | `25`                          |
| `Summary`            | `null`                        |

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25
}
```

> [!NOTE]
> The <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues> property is deprecated in .NET 5 and later versions. For the current way to ignore null values, see [how to ignore all null-value properties in .NET 5 and later](ignore-properties.md?pivots=dotnet-5-0#ignore-all-null-value-properties).

::: zone-end

## Ignore all default-value properties

::: zone pivot="dotnet-5-0,dotnet-7-0,dotnet-6-0"
To prevent serialization of default values in value type properties, set the <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition> property to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault>, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/IgnoreValueDefaultOnSerialize.cs" highlight="26":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/IgnoreValueDefaultOnSerialize.vb" :::
::: zone-end

The <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault> setting also prevents serialization of null-value reference type and nullable value type properties.

::: zone pivot="dotnet-core-3-1"
There's no built-in way to prevent serialization of properties with value type defaults in `System.Text.Json` in .NET Core 3.1.
::: zone-end

## See also

* [System.Text.Json overview](overview.md)
* [How to serialize and deserialize JSON](how-to.md)
* [Instantiate JsonSerializerOptions instances](configure-options.md)
* [Enable case-insensitive matching](character-casing.md)
* [Customize property names and values](customize-properties.md)
* [Allow invalid JSON](invalid-json.md)
* [Handle overflow JSON or use JsonElement or JsonNode](handle-overflow.md)
* [Preserve references and handle circular references](preserve-references.md)
* [Deserialize to immutable types and non-public accessors](immutability.md)
* [Polymorphic serialization](polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](migrate-from-newtonsoft.md)
* [Customize character encoding](character-encoding.md)
* [Use DOM, Utf8JsonReader, and Utf8JsonWriter](use-dom-utf8jsonreader-utf8jsonwriter.md)
* [Write custom converters for JSON serialization](converters-how-to.md)
* [DateTime and DateTimeOffset support](../../datetime/system-text-json-support.md)
* [How to use source generation](source-generation.md)
* [Supported collection types](supported-collection-types.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
