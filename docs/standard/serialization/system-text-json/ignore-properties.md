---
title: How to ignore properties with System.Text.Json
description: "Learn how to ignore properties when serializing with System.Text.Json in .NET."
ms.date: 08/18/2026
ms.custom: devdivchpfy22
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
ai-usage: ai-assisted
---

# How to ignore properties with System.Text.Json

When serializing C# objects to JavaScript Object Notation (JSON), by default, all public properties are serialized. If you don't want some of them to appear in the resulting JSON, you have several options. In this article, you learn how to ignore properties based on various criteria:

* [Individual properties](#ignore-individual-properties)
* [Properties based on a type-level condition](#ignore-properties-based-on-a-type-level-condition)
* [All read-only properties](#ignore-all-read-only-properties)
* [All null-value properties](#ignore-all-null-value-properties)
* [All default-value properties](#ignore-all-default-value-properties)

## Ignore individual properties

To ignore individual properties, use the [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute) attribute.

The following example shows a type to serialize. It also shows the JSON output:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithIgnoreAttribute":::
:::code language="vb" source="snippets/how-to/vb/WeatherForecast.vb" id="WFWithIgnoreAttribute":::

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
}
```

You can specify conditional exclusion by setting the [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute) attribute's `Condition` property. The <xref:System.Text.Json.Serialization.JsonIgnoreCondition> enum provides the following options:

* `Always` - The property is always ignored. If no `Condition` is specified, this option is assumed.
* `Never` - The property is always serialized and deserialized, regardless of the `DefaultIgnoreCondition`, `IgnoreReadOnlyProperties`, and `IgnoreReadOnlyFields` global settings.
* `WhenWritingDefault` - The property is ignored on serialization if it's a reference type `null`, a nullable value type `null`, or a value type `default`.
* `WhenWritingNull` - The property is ignored on serialization if it's a reference type `null`, or a nullable value type `null`.

The following example illustrates the use of the [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute) attribute's `Condition` property:

:::code language="csharp" source="snippets/how-to-contd/csharp/JsonIgnoreAttributeExample.cs" highlight="8,11,14":::
:::code language="vb" source="snippets/how-to-contd/vb/JsonIgnoreAttributeExample.vb" :::

## Ignore properties based on a type-level condition

Starting in .NET 11, apply `[JsonIgnore(Condition = ...)]` to a class, struct, or interface to set the default ignore condition for its properties and fields:

```csharp
[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
public class Forecast
{
    public string? Summary { get; set; }
}
```

```vb
<JsonIgnore(Condition:=JsonIgnoreCondition.WhenWritingNull)>
Public Class Forecast
    Public Property Summary As String
End Class
```

The serializer applies ignore settings in this order, from highest to lowest precedence:

* A member-level <xref:System.Text.Json.Serialization.JsonIgnoreAttribute>.
* A type-level <xref:System.Text.Json.Serialization.JsonIgnoreAttribute>.
* <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition?displayProperty=nameWithType>.

At the type level, <xref:System.Text.Json.Serialization.JsonIgnoreCondition.Always> is invalid. Reflection-based serialization throws an <xref:System.InvalidOperationException>, and source generation reports `SYSLIB1226`. Because `Always` is the default condition, specify `Condition` when you apply `[JsonIgnore]` to a type.

A type-level <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull> condition doesn't ignore non-nullable value-type members. The type-level condition still overrides the global `DefaultIgnoreCondition`, so those members remain in the JSON even when the global condition is `WhenWritingDefault`.

## Ignore all read-only properties

A property is read-only if it contains a public getter but not a public setter. To ignore all read-only properties when serializing, set the <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyProperties?displayProperty=nameWithType> to `true`, as shown in the following example:

:::code language="csharp" source="snippets/how-to/csharp/SerializeExcludeReadOnlyProperties.cs" id="Serialize":::
:::code language="vb" source="snippets/how-to/vb/SerializeExcludeReadOnlyProperties.vb" id="Serialize":::

The following example shows a type to serialize. It also shows the JSON output:

:::code language="csharp" source="snippets/how-to/csharp/WeatherForecast.cs" id="WFWithROProperty":::
:::code language="vb" source="snippets/how-to/vb/WeatherForecast.vb" id="WFWithROProperty":::

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25,
  "Summary": "Hot",
}
```

This option applies only to properties. To ignore read-only fields when [serializing fields](fields.md), use the <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields*?displayProperty=nameWithType> global setting.

> [!NOTE]
> Read-only collection-type properties are still serialized even if <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyProperties?displayProperty=nameWithType> is set to `true`.

## Ignore all null-value properties

To ignore all null-value properties, set the <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition> property to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull>, as shown in the following example:

:::code language="csharp" source="snippets/how-to-contd/csharp/IgnoreNullOnSerialize.cs" highlight="26":::
:::code language="vb" source="snippets/how-to-contd/vb/IgnoreNullOnSerialize.vb" :::

## Ignore all default-value properties

To prevent serialization of default values in value type properties, set the <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition> property to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault>, as shown in the following example:

:::code language="csharp" source="snippets/how-to-contd/csharp/IgnoreValueDefaultOnSerialize.cs" highlight="26":::
:::code language="vb" source="snippets/how-to-contd/vb/IgnoreValueDefaultOnSerialize.vb":::

The <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault> setting also prevents serialization of null-value reference type and nullable value type properties.

## See also

* [System.Text.Json overview](overview.md)
* [How to serialize and deserialize JSON](how-to.md)
