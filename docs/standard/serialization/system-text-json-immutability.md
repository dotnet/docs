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

::: zone pivot="dotnet-5-0,dotnet-6-0"
`System.Text.Json` can use a public parameterized constructor, which makes it possible to deserialize an immutable class or struct. For a class, if the only constructor is a parameterized one, that constructor will be used. For a struct, or a class with multiple constructors, specify the one to use by applying the [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute) attribute. When the attribute is not used, a public parameterless constructor is always used if present. The attribute can only be used with public constructors. The following example uses the `[JsonConstructor]` attribute:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/ImmutableTypes.cs" highlight="13":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/ImmutableTypes.vb" :::

The parameter names of a parameterized constructor must match the property names. Matching is case-insensitive, and the constructor parameter must match the actual property name even if you use [[JsonPropertyName]](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) to rename a property. In the following example, the name for the `TemperatureC` property is changed to `celsius` in the JSON, but the constructor parameter is still named `temperatureC`:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/ImmutableTypesCtorParms.cs" highlight="10,14-16":::

Besides `[JsonPropertyName]` the following attributes support deserialization with parameterized constructors:

* [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute)
* [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute)
* [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute)
* [[JsonNumberHandling]](xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute)

Records in C# 9 are also supported, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/Records.cs":::

You can apply any of the attributes to the property names, using the `property:` target on the attribute. For more information on positional records, see the article on [records](../../csharp/language-reference/builtin-types/record.md#positional-syntax-for-property-definition) in the C# language reference.

For types that are immutable because all their property setters are non-public, see the following section.
::: zone-end

::: zone pivot="dotnet-core-3-1"
`JsonConstructorAttribute` and C# 9 Record support aren't available in .NET Core 3.1.
::: zone-end

## Non-public property accessors

::: zone pivot="dotnet-5-0,dotnet-6-0"
To enable use of a non-public property accessor, use the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/NonPublicAccessors.cs" highlight="12,15":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/NonPublicAccessors.vb" :::
::: zone-end

::: zone pivot="dotnet-core-3-1"
Non-public property accessors are not supported in .NET Core 3.1. For more information, see [the Migrate from Newtonsoft.Json article](system-text-json-migrate-from-newtonsoft-how-to.md#non-public-property-setters-and-getters).
::: zone-end

## See also

* [System.Text.Json overview](system-text-json-overview.md)
* [How to serialize and deserialize JSON](system-text-json-how-to.md)
* [Instantiate JsonSerializerOptions instances](system-text-json-configure-options.md)
* [Enable case-insensitive matching](system-text-json-character-casing.md)
* [Customize property names and values](system-text-json-customize-properties.md)
* [Ignore properties](system-text-json-ignore-properties.md)
* [Allow invalid JSON](system-text-json-invalid-json.md)
* [Handle overflow JSON or use JsonElement or JsonNode](system-text-json-handle-overflow.md)
* [Preserve references and handle circular references](system-text-json-preserve-references.md)
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
