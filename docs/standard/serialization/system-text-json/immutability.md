---
title: Use immutable types and properties
description: "Learn how to deserialize JSON to immutable types and properties in .NET."
ms.date: 08/18/2026
ai-usage: ai-assisted
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# Use immutable types and properties

An immutable *type* prevents changes to property or field values after construction. Examples include records, types with no public properties or fields, read-only properties, and properties with private or init-only setters. <xref:System.String?displayProperty=nameWithType> is an immutable type. <xref:System.Text.Json> provides several ways to deserialize JSON to immutable types.

## Parameterized constructors

By default, `System.Text.Json` uses the public parameterless constructor. To deserialize an immutable class or struct, configure the serializer to use a parameterized constructor.

- For a class whose only constructor is parameterized, `System.Text.Json` uses that constructor.
- For a struct or a class with multiple constructors, apply the [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute) attribute to the constructor to use. Without the attribute, the serializer uses a public parameterless constructor when one exists.

  The following example uses the `[JsonConstructor]` attribute:

  :::code language="csharp" source="snippets/how-to-contd/csharp/ImmutableTypes.cs" highlight="12":::
  :::code language="vb" source="snippets/how-to-contd/vb/ImmutableTypes.vb" :::

  In .NET 7 and earlier versions, apply the `[JsonConstructor]` attribute only to public constructors.

In .NET 8 and later versions, reflection mode supports non-public constructors marked with `[JsonConstructor]`. Starting in .NET 11, source-generation mode supports them too.

The parameter names of a parameterized constructor must match the property names and types. Matching is case-insensitive. A constructor parameter must match the actual property name even when [[JsonPropertyName]](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) renames the property. In the following example, `[JsonPropertyName]` changes `TemperatureC` to `celsius` in the JSON, but the constructor parameter remains `temperatureC`:

:::code language="csharp" source="snippets/how-to-contd/csharp/ImmutableTypesCtorParms.cs" highlight="9,13-15":::

Besides `[JsonPropertyName]`, the following attributes support deserialization with parameterized constructors:

- [[JsonConverter]](xref:System.Text.Json.Serialization.JsonConverterAttribute)
- [[JsonIgnore]](xref:System.Text.Json.Serialization.JsonIgnoreAttribute)
- [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute)
- [[JsonNumberHandling]](xref:System.Text.Json.Serialization.JsonNumberHandlingAttribute)

## By-reference constructor parameters

Starting in .NET 11, both reflection mode and source-generation mode deserialize types whose constructor parameters use the `in`, `ref`, `out`, and `ref readonly` modifiers.

| Parameter modifier | Deserialization behavior |
|--------------------|--------------------------|
| `in`, `ref`, and `ref readonly` | The serializer binds each parameter by name and uses its underlying element type for type matching. |
| `out` | The serializer doesn't bind the parameter to JSON. It discards the value that the constructor assigns. |

In the following constructor, the serializer binds `temperatureC` from JSON. It doesn't bind `isValid`:

```csharp
public Forecast(in int temperatureC, out bool isValid)
{
    TemperatureC = temperatureC;
    isValid = true;
}
```

In Visual Basic, a `ByRef` constructor parameter follows the `ref` behavior shown in the table:

```vb
Public Sub New(ByRef temperatureC As Integer)
    TemperatureC = temperatureC
End Sub
```

## Records

`System.Text.Json` supports records for both serialization and deserialization, as shown in the following example:

:::code language="csharp" source="snippets/how-to-contd/csharp/Records.cs":::

Apply any of the attributes to property names by using the `property:` target. For more information about positional records, see [records](../../../csharp/language-reference/builtin-types/record.md#positional-syntax-for-property-and-field-definition) in the C# language reference.

## Non-public members and property accessors

Apply the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute to use a non-public property *accessor*, as shown in the following example:

:::code language="csharp" source="snippets/how-to-contd/csharp/NonPublicAccessors.cs" highlight="10,13":::
:::code language="vb" source="snippets/how-to-contd/vb/NonPublicAccessors.vb" :::

To deserialize a property with a private setter, mark the property with `[JsonInclude]`.

In .NET 8 and later versions, apply `[JsonInclude]` to add non-public *members* to a type's serialization contract.

Starting in .NET 11, source generation supports `private`, `internal`, and `protected` members that you mark with `[JsonInclude]`. It also supports `private`, `internal`, and `protected` accessors on properties that you mark with `[JsonInclude]`. Source generation also supports inaccessible constructors marked with [[JsonConstructor]](xref:System.Text.Json.Serialization.JsonConstructorAttribute).

> [!NOTE]
> In .NET 10 and earlier versions, source generation doesn't support `private` or `protected` members or accessors. Applying the [[JsonInclude]](xref:System.Text.Json.Serialization.JsonIncludeAttribute) attribute to the member or property doesn't remove this limitation. Source generation supports `internal` members and accessors only when they're in the same assembly as the generated <xref:System.Text.Json.Serialization.JsonSerializerContext>. It doesn't support inaccessible constructors, even when you mark them with `[JsonConstructor]`.

## Init-only properties

`System.Text.Json` deserializes `init`-only properties like any other settable property. Starting in .NET 11, a source-generated setter runs only when the JSON payload contains the property. An omitted property retains its initializer value.

## Read-only properties

In .NET 8 and later versions, `System.Text.Json` can deserialize read-only properties that have no public or private setter. You can't replace the instance that the property references, but you can modify a mutable instance. For example, add an element to a list. To deserialize a read-only property, set its object creation handling behavior to *populate* instead of *replace*. For example, apply the <xref:System.Text.Json.Serialization.JsonObjectCreationHandlingAttribute> attribute.

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
