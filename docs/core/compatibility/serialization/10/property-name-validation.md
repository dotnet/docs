---
title: "Breaking change: System.Text.Json checks for property name conflicts"
description: "Learn about the breaking change in .NET 10 where System.Text.Json validates that user-defined property names don't conflict with reserved metadata property names."
ms.date: 11/13/2025
ai-usage: ai-assisted
---
# System.Text.Json checks for property name conflicts

Under certain contexts, such as polymorphism and reference preservation, <xref:System.Text.Json> reserves specific property names (for example, `$type`, `$id`, and `$ref`) for emitting metadata. Previously, the serializer didn't perform validation on whether these property names conflicted with user-defined contracts, which could result in duplicate properties and produce JSON that was ambiguous or failed to round-trip. Starting with .NET 10, System.Text.Json enables validation to prevent such configurations and provides early warning to users.

## Version introduced

.NET 10

## Previous behavior

Previously, the following code produced an invalid JSON object with duplicate `Type` properties and failed to deserialize with a <xref:System.Text.Json.JsonException>:

```csharp
using System.Text.Json;
using System.Text.Json.Serialization;

string json = JsonSerializer.Serialize<Animal>(new Dog());
Console.WriteLine(json); // {"Type":"dog","Type":"Dog"}
JsonSerializer.Deserialize<Animal>(json); // JsonException: Deserialized object contains a duplicate 'Type' metadata property.

[JsonPolymorphic(TypeDiscriminatorPropertyName = "Type")]
[JsonDerivedType(typeof(Dog), "dog")]
public abstract class Animal
{
    public abstract string Type { get; }
}

public class Dog : Animal
{
    public override string Type => "Dog";
}
```

## New behavior

Starting in .NET 10, any attempt to serialize that same type results in an early validation error:

> InvalidOperationException: The type 'Dog' contains property 'Type' that conflicts with an existing metadata property name. Consider either renaming it or ignoring it with JsonIgnoreAttribute.

This validation error occurs when the serializer is first created or when serialization is first attempted, providing early detection of invalid serialization contracts.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change provides early prevention of invalid serialization contracts. By validating property names upfront, the serializer prevents scenarios where duplicate properties would be emitted, resulting in invalid JSON that cannot round-trip correctly. This helps developers identify and fix configuration issues during development rather than discovering them at run time during deserialization.

For more information, see:

- [[STJ] Disallow property names that conflict with metadata property names (dotnet/runtime#106390)](https://github.com/dotnet/runtime/issues/106390)
- [Disallow types with property names conflicting with metadata (dotnet/runtime#106460)](https://github.com/dotnet/runtime/pull/106460)

## Recommended action

Avoid using property names that conflict with System.Text.Json-specific metadata properties (such as `$type`, `$id`, and `$ref`). If it's absolutely necessary to keep such a property in the class, apply a <xref:System.Text.Json.Serialization.JsonIgnoreAttribute> annotation on the conflicting property.

## Affected APIs

- <xref:>
- <xref:System.Text.Json.JsonSerializer.Deserialize*?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.DeserializeAsync*?displayProperty=fullName>
