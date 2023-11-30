---
title: Include fields in serialization
description: "Learn how to include fields when you serialize to and deserialize from JSON in .NET."
ms.date: 10/19/2023
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
  - "vb"
ms.topic: conceptual
---

# Include fields

By default, fields aren't serialized. Use the <xref:System.Text.Json.JsonSerializerOptions.IncludeFields?displayProperty=nameWithType> global setting or the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute to include fields when serializing or deserializing, as shown in the following example:

:::code language="csharp" source="snippets/how-to-5-0/csharp/Fields.cs" highlight="15,17,19,31-34":::
:::code language="vb" source="snippets/how-to-5-0/vb/Fields.vb" :::

To ignore read-only fields, use the <xref:System.Text.Json.JsonSerializerOptions.IgnoreReadOnlyFields%2A?displayProperty=nameWithType> global setting.
