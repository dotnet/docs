---
title: How to preserve references with System.Text.Json
description: "Learn how to preserve references and handle circular references while serializing to and deserializing from JSON in .NET."
ms.date: 01/12/2021
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
---

# How to preserve references and handle circular references with System.Text.Json

::: zone pivot="dotnet-5-0"

To preserve references and handle circular references, set <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler%2A> to <xref:System.Text.Json.Serialization.ReferenceHandler.Preserve%2A>. This setting causes the following behavior:

* On serialize:

  When writing complex types, the serializer also writes metadata properties (`$id`, `$values`, and `$ref`).

* On deserialize:

  Metadata is expected (although not mandatory), and the deserializer tries to understand it.

The following code illustrates use of the `Preserve` setting.

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/PreserveReferences.cs" highlight="34":::
:::code language="vb" source="snippets/system-text-json-how-to-5-0/vb/PreserveReferences.vb" :::

This feature can't be used to preserve value types or immutable types. On deserialization, the instance of an immutable type is created after the entire payload is read. So it would be impossible to deserialize the same instance if a reference to it appears within the JSON payload.

For value types, immutable types, and arrays, no reference metadata is serialized. On deserialization, an exception is thrown if `$ref` or `$id` is found. However, value types ignore `$id` (and `$values` in the case of collections) to make it possible to deserialize payloads that were serialized by using Newtonsoft.Json.  Newtonsoft.Json does serialize metadata for such types.

To determine if objects are equal, System.Text.Json uses <xref:System.Collections.Generic.ReferenceEqualityComparer.Instance%2A?displayProperty=nameWithType>, which uses reference equality (<xref:System.Object.ReferenceEquals(System.Object,System.Object)?displayProperty=nameWithType>) instead of value equality (<xref:System.Object.Equals(System.Object)?displayProperty=nameWithType> when comparing two object instances.

For more information about how references are serialized and deserialized, see <xref:System.Text.Json.Serialization.ReferenceHandler.Preserve%2A?displayProperty=nameWithType>.

The <xref:System.Text.Json.Serialization.ReferenceResolver> class defines the behavior of preserving references on serialization and deserialization. Create a derived class to specify custom behavior. For an example, see [GuidReferenceResolver](https://github.com/dotnet/docs/blob/9d5e88edbd7f12be463775ffebbf07ac8415fe18/docs/standard/serialization/snippets/system-text-json-how-to-5-0/csharp/GuidReferenceResolverExample.cs).

## Persist reference metadata across multiple serialization and deserialization calls

By default, reference data is only cached for each call to <xref:System.Text.Json.JsonSerializer.Serialize%2A> or <xref:System.Text.Json.JsonSerializer.Deserialize%2A>. To persist references from one `Serialize`/`Deserialize` call to another one, root the <xref:System.Text.Json.Serialization.ReferenceResolver> instance in the call site of `Serialize`/`Deserialize`. The following code shows an example for this scenario:

* You have a list of `Employee`s and you have to serialize each one individually.
* you want to take advantage of the references saved in the `ReferenceHandler`'s resolver.

Here is the `Employee` class:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/PreserveReferencesMultipleCalls.cs" id="Employee":::

A class that derives from <xref:System.Text.Json.Serialization.ReferenceResolver> stores the references in a dictionary:

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/PreserveReferencesMultipleCalls.cs" id="MyReferenceResolver":::

A class that derives from <xref:System.Text.Json.Serialization.ReferenceHandler> holds an instance of `MyReferenceResolver` and creates a new instance only when needed (in a method named `Reset` in this example):

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/PreserveReferencesMultipleCalls.cs" id="MyReferenceHandler":::

When the sample code calls the serializer, it uses a <xref:System.Text.Json.JsonSerializerOptions> instance in which the <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler> property is set to an instance of `MyReferenceHandler`. When you follow this pattern, be sure to reset the `ReferenceResolver` dictionary when you're finished serializing, to keep it from growing forever.

:::code language="csharp" source="snippets/system-text-json-how-to-5-0/csharp/PreserveReferencesMultipleCalls.cs" id="CallSerializer" highlight = "3-4,14":::

::: zone-end

::: zone pivot="dotnet-core-3-1"
System.Text.Json in .NET Core 3.1 only supports serialization by value and throws an exception for circular references.
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
* [Immutable types and non-public accessors](system-text-json-immutability.md)
* [Polymorphic serialization](system-text-json-polymorphism.md)
* [Migrate from Newtonsoft.Json to System.Text.Json](system-text-json-migrate-from-newtonsoft-how-to.md)
* [Customize character encoding](system-text-json-character-encoding.md)
* [Write custom serializers and deserializers](write-custom-serializer-deserializer.md)
* [Write custom converters for JSON serialization](system-text-json-converters-how-to.md)
* [DateTime and DateTimeOffset support](../datetime/system-text-json-support.md)
* [System.Text.Json API reference](xref:System.Text.Json)
* [System.Text.Json.Serialization API reference](xref:System.Text.Json.Serialization)
