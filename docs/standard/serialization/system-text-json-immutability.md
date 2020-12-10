---
title: How to use immutable types and non-public accessors with System.Text.Json
description: "Learn how to use immutable types and non-public accessors while serializing to and deserializing from JSON in .NET."
ms.date: 11/30/2020
no-loc: [System.Text.Json, Newtonsoft.Json]
zone_pivot_groups: dotnet-version
helpviewer_keywords:
  - "JSON serialization"
  - "serializing objects"
  - "serialization"
  - "objects, serializing"
---

# How to use immutable types and non-public accessors with System.Text.Json

In this article, you will learn how to use immutable types, such as Records, with the `System.Text.Json` namespace.

## Immutable types and Records

::: zone pivot="dotnet-5-0"
`System.Text.Json` can use a parameterized constructor, which makes it possible to deserialize an immutable class or struct. For a class, if the only constructor is a parameterized one, that constructor will be used. For a struct, or a class with multiple constructors, specify the one to use by applying the [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute.%23ctor%2A) attribute. When the attribute is not used, a public parameterless constructor is always used if present. The attribute can only be used with public constructors. The following example uses the `[JsonConstructor]` attribute:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/ImmutableTypes.cs" highlight="13":::

Records in C# 9 are also supported, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/Records.cs":::

For types that are immutable because all their property setters are non-public, see the following section about [non-public property accessors](#non-public-property-accessors).
::: zone-end

::: zone pivot="dotnet-core-3-1"
`JsonConstructorAttribute` and C# 9 Record support aren't available in .NET Core 3.1.
::: zone-end

## Non-public property accessors

::: zone pivot="dotnet-5-0"
To enable use of a non-public property accessor, use the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute, as shown in the following example:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/NonPublicAccessors.cs" highlight="12,15":::
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
* [Handle overflow JSON](system-text-json-handle-overflow.md)
* [Preserve references](system-text-json-preserve-references.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md)
* [Customize character encoding](system-text-json-character-encoding.md)
* [Write custom serializers and deserializers](write-custom-serializer-deserializer.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
