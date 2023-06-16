---
title: How to allow some kinds of invalid JSON with System.Text.Json
description: "Learn how to allow comments, trailing commas, and quoted numbers while serializing to and deserializing from JSON in .NET."
ms.date: 12/03/2020
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

# How to allow some kinds of invalid JSON with System.Text.Json

In this article, you will learn how to allow comments, trailing commas, and quoted numbers in JSON, and how to write numbers as strings.

## Allow comments and trailing commas

By default, comments and trailing commas are not allowed in JSON. To allow comments in the JSON, set the <xref:System.Text.Json.JsonSerializerOptions.ReadCommentHandling?displayProperty=nameWithType> property to `JsonCommentHandling.Skip`.
And to allow trailing commas, set the <xref:System.Text.Json.JsonSerializerOptions.AllowTrailingCommas?displayProperty=nameWithType> property to `true`. The following example shows how to allow both:

:::code language="csharp" source="snippets/how-to/csharp/DeserializeCommasComments.cs" id="Deserialize":::
:::code language="vb" source="snippets/how-to/vb/DeserializeCommasComments.vb" id="Deserialize":::

Here's example JSON with comments and a trailing comma:

```json
{
  "Date": "2019-08-01T00:00:00-07:00",
  "TemperatureCelsius": 25, // Fahrenheit 77
  "Summary": "Hot", /* Zharko */
  // Comments on
  /* separate lines */
}
```

## Allow or write numbers in quotes

Some serializers encode numbers as JSON strings (surrounded by quotes).

For example:

```json
{
    "DegreesCelsius": "23"
}
```

Instead of:

```json
{
    "DegreesCelsius": 23
}
```

To serialize numbers in quotes or accept numbers in quotes across the entire input object graph, set <xref:System.Text.Json.JsonSerializerOptions.NumberHandling%2A?displayProperty=nameWithType> as shown in the following example:

:::code language="csharp" source="snippets/how-to-5-0/csharp/QuotedNumbers.cs" highlight="26-28":::
:::code language="vb" source="snippets/how-to-5-0/vb/QuotedNumbers.vb" :::

When you use `System.Text.Json` indirectly through ASP.NET Core, quoted numbers are allowed when deserializing because ASP.NET Core specifies [web default options](xref:System.Text.Json.JsonSerializerDefaults.Web).

To allow or write quoted numbers for specific properties, fields, or types, use the [[JsonNumberHandling]](xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute) attribute.

## See also

* [System.Text.Json overview](overview.md)
* [How to serialize and deserialize JSON](how-to.md)
