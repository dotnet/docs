---
title: Require properties for deserialization
description: "Learn how to mark properties as required for deserialization to succeed."
ms.date: 09/21/2022
no-loc: [System.Text.Json, Newtonsoft.Json]
---
# Required properties

Starting in .NET 7, you can mark certain properties to signify that they must be present in the JSON payload for deserialization to succeed. If one or more of these required properties is not present, the <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=nameWithType> methods throw a <xref:System.Text.Json.JsonException>.

There are three ways to mark a property or field as required for JSON deserialization:

- By adding the [required modifier](../../../csharp/language-reference/keywords/required.md), which is new in C# 11.
- By annotating it with <xref:System.Text.Json.Serialization.JsonRequiredAttribute>, which is new in .NET 7.
- By modifying the <xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsRequired?displayProperty=nameWithType> property of the contract model, which is new in .NET 7.

From the serializer's perspective, these two demarcations are equivalent and both map to the same piece of metadata, which is <xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsRequired?displayProperty=nameWithType>. In most cases, you'd simply use the built-in C# keyword. However, in the following cases, you should use <xref:System.Text.Json.Serialization.JsonRequiredAttribute> instead:

- If you're using a programming language other than C# or a down-level version of C#.
- If you only want the requirement to apply to JSON deserialization.
- If you're using `System.Text.Json` serialization in [source generation](source-generation-modes.md#metadata-based-mode) mode. In this case, your code won't compile if you use the `required` modifier, as source generation occurs at compile time.

The following code snippet shows an example of a property modified with the `required` keyword. This property must be present in the JSON payload for deserialization to succeed.

```csharp
using System.Text.Json;

// The following line throws a JsonException at run time.
Console.WriteLine(JsonSerializer.Deserialize<Person>("""{"Age": 42}"""));

public class Person
{
    public required string Name { get; set; }
    public int Age { get; set; }
}
```

Alternatively, you can use <xref:System.Text.Json.Serialization.JsonRequiredAttribute>:

```csharp
using System.Text.Json;

// The following line throws a JsonException at run time.
Console.WriteLine(JsonSerializer.Deserialize<Person>("""{"Age": 42}"""));

public class Person
{
    [JsonRequired]
    public string Name { get; set; }
    public int Age { get; set; }
}
```

It's also possible to control whether a property is required via the contract model using the <xref:System.Text.Json.Serialization.Metadata.JsonPropertyInfo.IsRequired?displayProperty=nameWithType> property:

```csharp
var options = new JsonSerializerOptions
{
    TypeInfoResolver = new DefaultJsonTypeInfoResolver
    {
        Modifiers =
        {
            static typeInfo =>
            {
                if (typeInfo.Kind != JsonTypeInfoKind.Object)
                    return;

                foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
                {
                    // Strip IsRequired constraint from every property.
                    propertyInfo.IsRequired = false;
                }
            }
        }
    }
};

// Deserialization now succeeds even though the Name property isn't in the JSON payload.
JsonSerializer.Deserialize<Person>("""{"Age": 42}""", options);
```
