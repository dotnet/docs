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

Starting in .NET 8, you can specify a preference to either [replace](#default-replace-behavior) or [populate](#populate-behavior) .NET properties when JSON is deserialized. The <xref:System.Text.Json.Serialization.JsonObjectCreationHandling> enum fields provide the object creation handling choices:

- <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Replace?displayProperty=nameWithType> (matches the default behavior)
- <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate?displayProperty=nameWithType>

## Default (replace) behavior

The System.Text.Json deserializer always creates a new instance of the target type. However, even though a new instance is created, some properties and fields might already be initialized as part of the object's construction. Consider the following type:

```csharp
class A
{
    public List<int> Numbers1 { get; } = new List<int>() { 1, 2, 3 };
    public List<int> Numbers2 { get; set; } = new List<int>() { 1, 2, 3 };
}
```

When you create an instance of this class, the `Numbers1` (and `Numbers2`) property's value is a list with three elements (1, 2, and 3). If you deserialize JSON to this type, the *default* behavior is that property values are *replaced*:

- For `Numbers1`, since it's read-only (no setter), it still has the values 1, 2, and 3 in its list.
- For `Numbers2`, which is read-write, the contents of the list are effectively replaced with the values from the JSON.

For example, if you execute the following deserialization code, `Numbers1` contains the values 1, 2, and 3 and `Numbers2` contains the values 4, 5, and 6.

```csharp
A? a = JsonSerializer.Deserialize<A>("""{"Numbers1": [4,5,6], "Numbers2": [4,5,6]}""");
```

## Populate behavior

Starting in .NET 8, you can change the deserialization behavior to modify (*populate*) initialized properties and fields instead of replacing them:

- For a collection type property, any existing values are kept, and new values from the JSON are added to the collection.
- For a non-collection reference type property, its mutable properties are updated to the JSON value but the reference itself doesn't change.
- For a struct type property, the effective behavior is that for its mutable properties, the existing values are kept, and new values from the JSON are added. However, unlike a reference property, the object itself isn't reused since it's a value type. Instead, a copy of the struct is modified and then reassigned to the property. For example, after executing the following code, `a.S1.Numbers3` contains the values 1, 2, 3, 4, 5, and 6.

  ```csharp
  A? a = JsonSerializer.Deserialize<A>("""{"S1": {"Numbers3": [4,5,6]}}""");

  class A
  {
    public S S1 { get; set; } = new S();
  }

  struct S
  {
      public S() { }
      [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
      public List<int> Numbers3 { get; } = new List<int>() { 1, 2, 3 };
  }
  ```

For reference type properties, since the value that the property references isn't *replaced* (that is, doesn't require a setter), if the type of the property is mutable, deserialization can also populate *read-only* properties. This doesn't apply to struct type properties since the instance must be replaced with a modified copy.

Consider the same example class `A` from the previous exception, but this time annotated with a preference for *populating* properties instead of replacing them:

```csharp
[JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
class A
{
    public List<int> Numbers1 { get; } = new List<int>() { 1, 2, 3 };
    public List<int> Numbers2 { get; set; } = new List<int>() { 1, 2, 3 };
}
```

If you execute the same deserialization code as in the previous section, both `Numbers1` and `Numbers2` contain the values 1, 2, 3, 4, 5, and 6:

```csharp
A? a = JsonSerializer.Deserialize<A>("""{"Numbers1": [4,5,6], "Numbers2": [4,5,6]}""");
```

## How to specify

There are multiple ways to specify a preference for *replace* or *populate*:

- Use the <xref:System.Text.Json.Serialization.JsonObjectCreationHandlingAttribute> attribute to annotate at the type or property level. If you set the attribute at the type level and set its <xref:System.Text.Json.Serialization.JsonObjectCreationHandlingAttribute.Handling> property to <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate>, the behavior will only apply to those properties where population is possible (for example, value types must have a setter).

  If you want to set the type-wide behavior preference to <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate>, but want to exclude one or more properties from that, you can add the attribute at the type level and again at the property level to override the behavior preference for that property. That pattern is shown in the following code.

  ```csharp
  // Type-level preference is Populate.
  [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]
  class A
  {
      // For this property only, use Replace behavior.
      [JsonObjectCreationHandling(JsonObjectCreationHandling.Replace)]
      public List<int> Numbers1 { get; } = new List<int>() { 1, 2, 3 };
      public List<int> Numbers2 { get; set; } = new List<int>() { 1, 2, 3 };
  }
  ```

- Set <xref:System.Text.Json.JsonSerializerOptions.PreferredObjectCreationHandling?displayProperty=nameWithType> (or, for source generation, <xref:System.Text.Json.Serialization.JsonSourceGenerationOptionsAttribute.PreferredObjectCreationHandling?displayProperty=nameWithType>) to specify a global preference.

  ```csharp
  var options = new JsonSerializerOptions
  {
      PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate
  };
  ```
