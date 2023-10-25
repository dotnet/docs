---
title: Use immutable types and properties
description: "Learn how to deserialize JSON to immutable types and properties in .NET."
ms.date: 10/20/2023
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# Use immutable types and properties

An immutable *type* is one that prevents you from changing any property or field values of an object after it's instantiated. The type might be a record, have no public properties or fields, have read-only properties, or have properties with private or init-only setters. <xref:System.String?displayProperty=nameWithType> is an example of an immutable type. <xref:System.Text.Json> provides different ways that you can deserialize JSON to immutable types.

## Parameterized constructors

By default, `System.Text.Json` uses the default public parameterless constructor. However, you can tell it to use a parameterized constructor, which makes it possible to deserialize an immutable class or struct.

- For a class, if the only constructor is a parameterized one, that constructor will be used.
- For a struct, or a class with multiple constructors, specify the one to use by applying the [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute) attribute. When the attribute is not used, a public parameterless constructor is always used if present.

  The following example uses the `[JsonConstructor]` attribute:

  :::code language="csharp" source="snippets/how-to-5-0/csharp/ImmutableTypes.cs" highlight="12":::
  :::code language="vb" source="snippets/how-to-5-0/vb/ImmutableTypes.vb" :::

  In .NET 7 and earlier versions, the `[JsonConstructor]` attribute can only be used with public constructors.

The parameter names of a parameterized constructor must match the property names and types. Matching is case-insensitive, and the constructor parameter must match the actual property name even if you use [[JsonPropertyName]](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) to rename a property. In the following example, the name for the `TemperatureC` property is changed to `celsius` in the JSON, but the constructor parameter is still named `temperatureC`:

:::code language="csharp" source="snippets/how-to-5-0/csharp/ImmutableTypesCtorParms.cs" highlight="9,13-15":::

Besides `[JsonPropertyName]`, the following attributes support deserialization with parameterized constructors:

- [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute)
- [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute)
- [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute)
- [[JsonNumberHandling]](xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute)

## Records

Records are also supported for both serialization and deserialization, as shown in the following example:

:::code language="csharp" source="snippets/how-to-5-0/csharp/Records.cs":::

You can apply any of the attributes to the property names, using the `property:` target on the attribute. For more information on positional records, see the article on [records](../../../csharp/language-reference/builtin-types/record.md#positional-syntax-for-property-definition) in the C# language reference.

## Non-public members and property accessors

You can enable use of a non-public *accessor* on a property by using the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute, as shown in the following example:

:::code language="csharp" source="snippets/how-to-5-0/csharp/NonPublicAccessors.cs" highlight="10,13":::
:::code language="vb" source="snippets/how-to-5-0/vb/NonPublicAccessors.vb" :::

By including a property with a private setter, you can still deserialize that property.

In .NET 8 and later versions, you can also use the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute to opt non-public *members* into the serialization contract for a given type.

> [!NOTE]
> In source-generation mode, you can't serialize `private` members or use `private` accessors by annotating them with the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute. And you can only serialize `internal` members or use `internal` accessors if they're in the same assembly as the generated <xref:System.Text.Json.Serialization.JsonSerializerContext>.

## Read-only properties

In .NET 8 and later versions, read-only properties, or those that have no setter either private or public, can also be deserialized. While you can't change the instance that the property references, if the type of the property is mutable, you can modify it. For example, you can add an element to a list. To deserialize a read-only property, you need to set its object creation handling behavior to *populate* instead of *replace*. For example, you can annotate the property with the <xref:System.Text.Json.Serialization.JsonObjectCreationHandlingAttribute> attribute.

  ```csharp
  class A
  {
      [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
      public List<int> Numbers1 { get; } = new List<int>() { 1, 2, 3 };
  }
  ```

For more information, see [Populate initialized properties](populate-properties.md).

## See also

- [System.Text.Json overview](overview.md)
- [How to serialize and deserialize JSON](how-to.md)
