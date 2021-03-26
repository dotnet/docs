---
title: "Breaking change: Non-public, parameterless constructors not used for deserialization"
description: Learn about the breaking change in .NET 5 where non-public, parameterless constructors are no longer used for deserialization with JsonSerializer.
ms.date: 10/18/2020
---
# Non-public, parameterless constructors not used for deserialization

For consistency across all supported target framework monikers (TFMs), non-public, parameterless constructors are no longer used for deserialization with <xref:System.Text.Json.JsonSerializer>, by default.

## Change description

The standalone [System.Text.Json NuGet packages](https://www.nuget.org/packages/System.Text.Json/) that support .NET Standard 2.0 and higher, that is, versions 4.6.0-4.7.2, behave inconsistently with the built-in behavior on .NET Core 3.0 and 3.1. On .NET Core 3.x, internal and private constructors can be used for deserialization. In the standalone packages, non-public constructors are not allowed, and a <xref:System.MissingMethodException> is thrown if no public, parameterless constructor is defined.

Starting with .NET 5 and System.Text.Json NuGet package 5.0.0, the behavior is consistent between the NuGet package and the built-in APIs. Non-public constructors, including parameterless constructors, are ignored by the serializer by default. The serializer uses one of the following constructors for deserialization:

- Public constructor annotated with <xref:System.Text.Json.Serialization.JsonConstructorAttribute>.
- Public parameterless constructor.
- Public parameterized constructor (if it's the only public constructor present).

If none of these constructors are available, a <xref:System.NotSupportedException> is thrown if you attempt to deserialize the type.

## Version introduced

5.0

## Reason for change

- To enforce consistent behavior between all target framework monikers (TFMs) that <xref:System.Text.Json?displayProperty=fullName> builds for (.NET Core 3.0 and later versions and .NET Standard 2.0)
- Because <xref:System.Text.Json.JsonSerializer> shouldn't call the non-public surface area of a type, whether that's a constructor, a property, or a field.

## Recommended action

- If you own the type and it's feasible, make the parameterless constructor public.
- Otherwise, implement a <xref:System.Text.Json.Serialization.JsonConverter%601> for the type and control the deserialization behavior. You can call a non-public constructor from a <xref:System.Text.Json.Serialization.JsonConverter%601> implementation if C# accessibility rules for that scenario allow it.

## Affected APIs

- <xref:System.Text.Json.JsonSerializer.Deserialize%2A?displayProperty=fullName>
- <xref:System.Text.Json.JsonSerializer.DeserializeAsync%2A?displayProperty=fullName>

<!--

### Affected APIs

- `Overload:System.Text.Json.JsonSerializer.Deserialize`
- `Overload:System.Text.Json.JsonSerializer.DeserializeAsync`

### Category

Serialization

-->
