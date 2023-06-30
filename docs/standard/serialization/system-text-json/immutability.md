---
title: How to use immutable types and non-public accessors with System.Text.Json
description: "Learn how to use immutable types and non-public accessors while serializing to and deserializing from JSON in .NET."
ms.date: 02/08/2021
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

# How to use immutable types and non-public accessors with System.Text.Json

This article shows how to use immutable types, public parameterized constructors, and non-public accessors with the `System.Text.Json` namespace.

## Immutable types and Records

`System.Text.Json` can use a public parameterized constructor, which makes it possible to deserialize an immutable class or struct. For a class, if the only constructor is a parameterized one, that constructor will be used. For a struct, or a class with multiple constructors, specify the one to use by applying the [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute) attribute. When the attribute is not used, a public parameterless constructor is always used if present. The attribute can only be used with public constructors. The following example uses the `[JsonConstructor]` attribute:

:::code language="csharp" source="snippets/how-to-5-0/csharp/ImmutableTypes.cs" highlight="12":::
:::code language="vb" source="snippets/how-to-5-0/vb/ImmutableTypes.vb" :::

The parameter names of a parameterized constructor must match the property names and types. Matching is case-insensitive, and the constructor parameter must match the actual property name even if you use [[JsonPropertyName]](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) to rename a property. In the following example, the name for the `TemperatureC` property is changed to `celsius` in the JSON, but the constructor parameter is still named `temperatureC`:

:::code language="csharp" source="snippets/how-to-5-0/csharp/ImmutableTypesCtorParms.cs" highlight="9,13-15":::

Besides `[JsonPropertyName]` the following attributes support deserialization with parameterized constructors:

* [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute)
* [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute)
* [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute)
* [[JsonNumberHandling]](xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute)

Records in C# 9 are also supported, as shown in the following example:

:::code language="csharp" source="snippets/how-to-5-0/csharp/Records.cs":::

You can apply any of the attributes to the property names, using the `property:` target on the attribute. For more information on positional records, see the article on [records](../../../csharp/language-reference/builtin-types/record.md#positional-syntax-for-property-definition) in the C# language reference.

For types that are immutable because all their property setters are non-public, see the following section.

## Non-public property accessors

`System.Text.Json` doesn't support serialization of non-public properties. However, you can enable use of a non-public property *accessor* by using the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute, as shown in the following example:

:::code language="csharp" source="snippets/how-to-5-0/csharp/NonPublicAccessors.cs" highlight="10,13":::
:::code language="vb" source="snippets/how-to-5-0/vb/NonPublicAccessors.vb" :::

## See also

* [System.Text.Json overview](overview.md)
* [How to serialize and deserialize JSON](how-to.md)
