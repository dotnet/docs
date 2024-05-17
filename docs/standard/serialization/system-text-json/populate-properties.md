---
title: Populate initialized properties
description: "Learn how to modify properties and fields that are already initialized when deserializing from JSON in .NET."
ms.date: 10/20/2023
no-loc: [System.Text.Json, Newtonsoft.Json]
dev_langs:
  - "csharp"
ms.topic: how-to
---

# Populate initialized properties

Starting in .NET 8, you can specify a preference to either [replace](#default-replace-behavior) or [populate](#populate-behavior) .NET properties when JSON is deserialized. The <xref:System.Text.Json.Serialization.JsonObjectCreationHandling> enum provides the object creation handling choices:

- <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Replace?displayProperty=nameWithType>
- <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate?displayProperty=nameWithType>

## Default (replace) behavior

The System.Text.Json deserializer always creates a new instance of the target type. However, even though a new instance is created, some properties and fields might already be initialized as part of the object's construction. Consider the following type:

:::code language="csharp" source="snippets/populate-properties/ClassA2.cs" id="ClassA":::

When you create an instance of this class, the `Numbers1` (and `Numbers2`) property's value is a list with three elements (1, 2, and 3). If you deserialize JSON to this type, the *default* behavior is that property values are *replaced*:

- For `Numbers1`, since it's read-only (no setter), it still has the values 1, 2, and 3 in its list.
- For `Numbers2`, which is read-write, a new list is allocated and the values from the JSON are added.

For example, if you execute the following deserialization code, `Numbers1` contains the values 1, 2, and 3 and `Numbers2` contains the values 4, 5, and 6.

```csharp
A? a = JsonSerializer.Deserialize<A>("""{"Numbers1": [4,5,6], "Numbers2": [4,5,6]}""");
```

## Populate behavior

Starting in .NET 8, you can change the deserialization behavior to modify (*populate*) properties and fields instead of replace them:

- For a collection type property, the object is reused without clearing. If the collection is prepopulated with elements, they'll show in the final deserialized result along with the values from the JSON. For an example, see [Collection property example](#collection-property-example).
- For a property that's an object with properties, its mutable properties are updated to the JSON values but the object reference itself doesn't change.
- For a struct type property, the effective behavior is that for its mutable properties, any existing values are kept and new values from the JSON are added. However, unlike a reference property, the object itself isn't reused since it's a value type. Instead, a copy of the struct is modified and then reassigned to the property. For an example, see [Struct property example](#struct-property-example).

  A struct property must have a setter; otherwise, an <xref:System.InvalidOperationException> is thrown at run time.

> [!NOTE]
> The populate behavior currently doesn't work for types that have a parameterized constructor. For more information, see [dotnet/runtime issue 92877](https://github.com/dotnet/runtime/issues/92877).

### Read-only properties

For populating reference properties that are mutable, since the instance that the property references isn't *replaced*, the property doesn't need to have a setter. This behavior means that deserialization can also populate *read-only* properties.

> [!NOTE]
> Struct properties still require setters because the instance is replaced with a modified copy.

### Collection property example

Consider the same class `A` from the [replace behavior](#default-replace-behavior) example, but this time annotated with a preference for *populating* properties instead of replacing them:

:::code language="csharp" source="snippets/populate-properties/ClassA.cs" id="ClassA":::

If you execute the following deserialization code, both `Numbers1` and `Numbers2` contain the values 1, 2, 3, 4, 5, and 6:

```csharp
A? a = JsonSerializer.Deserialize<A>("""{"Numbers1": [4,5,6], "Numbers2": [4,5,6]}""");
```

### Struct property example

The following class contains a struct property, `S1`, whose deserialization behavior is set to <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate>. After executing this code, `c.S1.Value1` has a value of 10 (from the constructor) and `c.S1.Value2` has a value of 5 (from the JSON).

:::code language="csharp" source="snippets/populate-properties/StructProperty.cs" id="StructProperty":::

If the default <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Replace> behavior was used instead, `c.S1.Value1` would have its default value of 0 after deserialization. That's because the constructor `C()` would be called, setting `c.S1.Value1` to 10, but then the value of S1 would be replaced with a new instance. (`c.S1.Value2` would still be 5, since the JSON replaces the default value.)

## How to specify

There are multiple ways to specify a preference for *replace* or *populate*:

- Use the <xref:System.Text.Json.Serialization.JsonObjectCreationHandlingAttribute> attribute to annotate at the type or property level. If you set the attribute at the type level and set its <xref:System.Text.Json.Serialization.JsonObjectCreationHandlingAttribute.Handling> property to <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate>, the behavior will only apply to those properties where population is possible (for example, value types must have a setter).

  If you want the type-wide preference to be <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate>, but want to exclude one or more properties from that behavior, you can add the attribute at the type level and again at the property level to override the inherited behavior. That pattern is shown in the following code.

  :::code language="csharp" source="snippets/populate-properties/TypeVsProperty.cs" id="AttributeLevel":::

- Set <xref:System.Text.Json.JsonSerializerOptions.PreferredObjectCreationHandling?displayProperty=nameWithType> (or, for source generation, <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute.PreferredObjectCreationHandling?displayProperty=nameWithType>) to specify a global preference.

  ```csharp
  var options = new JsonSerializerOptions
  {
      PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate
  };
  ```
