---
title: How to preserve references in System.Text.Json
description: "Learn how to preserve references and handle or ignore circular references while using System.Text.Json to serialize and deserialize JSON in .NET."
ms.date: 01/12/2021
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
---

# How to preserve references and handle or ignore circular references in System.Text.Json

This article shows how to preserve references and handle or ignore circular references while using System.Text.Json to serialize and deserialize JSON in .NET

## Preserve references and handle circular references

To preserve references and handle circular references, set <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler%2A> to <xref:System.Text.Json.Serialization.ReferenceHandler.Preserve%2A>. This setting causes the following behavior:

* On serialize:

  When writing complex types, the serializer also writes metadata properties (`$id`, `$values`, and `$ref`).

* On deserialize:

  Metadata is expected (although not mandatory), and the deserializer tries to understand it.

The following code illustrates use of the `Preserve` setting.

:::code language="csharp" source="snippets/how-to-contd/csharp/PreserveReferences.cs" highlight="32":::
:::code language="vb" source="snippets/how-to-contd/vb/PreserveReferences.vb" :::

This feature can't be used to preserve value types or immutable types. On deserialization, the instance of an immutable type is created after the entire payload is read. So it would be impossible to deserialize the same instance if a reference to it appears within the JSON payload.

For value types, immutable types, and arrays, no reference metadata is serialized. On deserialization, an exception is thrown if `$ref` or `$id` is found. However, value types ignore `$id` (and `$values` in the case of collections) to make it possible to deserialize payloads that were serialized by using Newtonsoft.Json, which does serialize metadata for such types.

To determine if objects are equal, System.Text.Json uses <xref:System.Collections.Generic.ReferenceEqualityComparer.Instance%2A?displayProperty=nameWithType>, which uses reference equality (<xref:System.Object.ReferenceEquals(System.Object,System.Object)?displayProperty=nameWithType>) instead of value equality (<xref:System.Object.Equals(System.Object)?displayProperty=nameWithType>) when comparing two object instances.

For more information about how references are serialized and deserialized, see <xref:System.Text.Json.Serialization.ReferenceHandler.Preserve%2A?displayProperty=nameWithType>.

The <xref:System.Text.Json.Serialization.ReferenceResolver> class defines the behavior of preserving references on serialization and deserialization. Create a derived class to specify custom behavior. For an example, see [GuidReferenceResolver](https://github.com/dotnet/docs/blob/main/docs/standard/serialization/system-text-json/snippets/how-to-contd/csharp/GuidReferenceResolverExample.cs).

### Persist reference metadata across multiple serialization and deserialization calls

By default, reference data is only cached for each call to <xref:System.Text.Json.JsonSerializer.Serialize%2A> or <xref:System.Text.Json.JsonSerializer.Deserialize%2A>. To persist references from one `Serialize` or `Deserialize` call to another one, root the <xref:System.Text.Json.Serialization.ReferenceResolver> instance in the call site of `Serialize`/`Deserialize`. The following code shows an example for this scenario:

* You have a list of `Employee` objects and you have to serialize each one individually.
* You want to take advantage of the references saved in the resolver for the `ReferenceHandler`.

Here is the `Employee` class:

:::code language="csharp" source="snippets/how-to-contd/csharp/PreserveReferencesMultipleCalls.cs" id="Employee":::

A class that derives from <xref:System.Text.Json.Serialization.ReferenceResolver> stores the references in a dictionary:

:::code language="csharp" source="snippets/how-to-contd/csharp/PreserveReferencesMultipleCalls.cs" id="MyReferenceResolver":::

A class that derives from <xref:System.Text.Json.Serialization.ReferenceHandler> holds an instance of `MyReferenceResolver` and creates a new instance only when needed (in a method named `Reset` in this example):

:::code language="csharp" source="snippets/how-to-contd/csharp/PreserveReferencesMultipleCalls.cs" id="MyReferenceHandler":::

When the sample code calls the serializer, it uses a <xref:System.Text.Json.JsonSerializerOptions> instance in which the <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler> property is set to an instance of `MyReferenceHandler`. When you follow this pattern, be sure to reset the `ReferenceResolver` dictionary when you're finished serializing, to keep it from growing forever.

:::code language="csharp" source="snippets/how-to-contd/csharp/PreserveReferencesMultipleCalls.cs" id="CallSerializer" highlight = "3-4,14":::

## Ignore circular references

Instead of handling circular references, you can ignore them. To ignore circular references, set <xref:System.Text.Json.JsonSerializerOptions.ReferenceHandler%2A> to <xref:System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles%2A>. The serializer sets circular reference properties to `null`, as shown in the following example:

:::code language="csharp" source="snippets/how-to-6-0/csharp/SerializeIgnoreCycles.cs" highlight="32,59":::

In the preceding example, `Manager` under `Adrian King` is serialized as `null` to avoid the circular reference. This behavior has the following advantages over <xref:System.Text.Json.Serialization.ReferenceHandler.Preserve%2A?displayProperty=nameWithType>:

* It decreases payload size.
* It creates JSON that is comprehensible for serializers other than System.Text.Json and Newtonsoft.Json.

This behavior has the following disadvantages:

* Silent loss of data.
* Data can't make a round trip from JSON back to the source object.

## See also

* [System.Text.Json overview](overview.md)
* [How to serialize and deserialize JSON](how-to.md)
