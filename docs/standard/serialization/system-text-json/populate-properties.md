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

The System.Text.Json deserializer always creates a new instance of the target type. However, even though a new instance is created, some properties and fields might already be initialized as part of the object's construction. Consider the following type:

```csharp
class A
{
    public List<int> Numbers1 { get; } = new List<int>() { 1, 2, 3 };
    public List<int> Numbers2 { get; set; } = new List<int>() { 1, 2, 3 };
}
```

When you create an instance of this class, the `Numbers1` (and `Numbers2`) property's value is a list with three elements (1, 2, and 3). If you deserialize JSON to this type, the default behavior is that property values are replaced:

- For `Numbers1`, since it's read-only (no setter), it will still have the values 1, 2, and 3 in its list.
- For `Numbers2`, which is read-write, the contents of the list will be replaced with the values from the JSON.

For example, if you execute the following deserialization code, `Numbers1` contains the values 1, 2, and 3 and `Numbers2` contains the values 4, 5, and 6.

```csharp
A? a = JsonSerializer.Deserialize<A>("""{"Numbers1": [4,5,6], "Numbers2": [4,5,6]}""");
```

Starting in .NET 8, you can change the deserialization behavior to modify (*populate*) initialized properties and fields instead of replacing them. And since the value that the property references isn't *replaced* (that is, doesn't require a setter), if the type of the property is mutable, deserialization can also populate *read-only* properties. The <xref:System.Text.Json.Serialization.JsonObjectCreationHandling> enum fields provide the object creation handling choices:

- <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Replace?displayProperty=nameWithType> (matches the default behavior)
- <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate?displayProperty=nameWithType>

There are multiple ways to specify a preference for *replace* or *populate*:

- Use the <xref:System.Text.Json.Serialization.JsonObjectCreationHandlingAttribute> attribute to annotate at the type or property level. If you set the attribute at the type level and set its <xref:System.Text.Json.Serialization.JsonObjectCreationHandlingAttribute.Handling> property to <xref:System.Text.Json.Serialization.JsonObjectCreationHandling.Populate>, the populate behavior will only apply to those properties where it's possible (for example, value types must have a setter).

  ```csharp
  [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]  // Type-level
  class A
  {
      [JsonObjectCreationHandling(JsonObjectCreationHandling.Populate)]  // Property-level
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
