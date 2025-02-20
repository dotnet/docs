---
title: "Breaking change: System.Text.Json metadata reader now unescapes metadata property names"
description: System.Text.Json now unescapes metadata property names, affecting reference preservation and metadata property validation.
ms.date: 2/13/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/44748
---

# System.Text.Json metadata reader now unescapes metadata property names

The <xref:System.Text.Json?displayProperty=fullName> library has been updated to unescape metadata property names. This change affects how JSON documents are interpreted in the context of reference preservation, polymorphism, and metadata property validation.

## Version introduced

.NET 9

## Previous behavior

Previously, <xref:System.Text.Json?displayProperty=fullName> didn't unescape metadata property names. This would lead to invalid property names being accepted, which could bypass metadata property validation.

For example, the following code would succeed in the first call but throw an exception in the second call:

```csharp
JsonSerializerOptions options = new() { ReferenceHandler = ReferenceHandler.Preserve };
JsonSerializer.Deserialize<MyPoco>("""{"\u0024invalid" : 42 }""", options);
JsonSerializer.Deserialize<MyPoco>("""{"$invalid" : 42 }""", options);

record MyPoco;
```

This behavior could cause polymorphism issues when roundtripping metadata properties whose names require escaping, as seen here:

```csharp
string json = JsonSerializer.Serialize<Base>(new Derived());
Console.WriteLine(json); // {"categor\u00EDa":"derived"}
Console.WriteLine(JsonSerializer.Deserialize<Base>(json) is Derived); // False

[JsonPolymorphic(TypeDiscriminatorPropertyName = "categoría")]
[JsonDerivedType(typeof(Derived), "derived")]
public record Base;
public record Derived : Base;
```

## New behavior

<xref:System.Text.Json?displayProperty=fullName> now unescapes metadata property names. This means that invalid property names will correctly fail to deserialize with the following exception:

```output
Unhandled exception. System.Text.Json.JsonException: Properties that start with '$' are not allowed in types that support metadata.
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change improves correctness and reliability by ensuring that metadata property names are properly unescaped, preventing the bypass of metadata property validation. For more details, see the [reported issue](https://github.com/dotnet/runtime/issues/112288).

## Recommended action

Avoid using escaping to bypass metadata property validation. Instead, pick property names that don't conflict with metadata properties.

## Affected APIs

* <xref:System.Text.Json?displayProperty=fullName>
* <xref:System.Text.Json.JsonSerializer.Deserialize*?displayProperty=fullName>
