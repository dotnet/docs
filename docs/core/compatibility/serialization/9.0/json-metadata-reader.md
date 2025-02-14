---
title: "The System.Text.Json metadata reader now unescapes metadata property names."
description: System.Text.Json now unescapes metadata property names, affecting reference preservation and metadata property validation.
ms.date: 2/13/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/44748
---

# The System.Text.Json metadata reader now unescapes metadata property names.

In .NET 9, the `System.Text.Json` library has been updated to unescape metadata property names. This change affects how JSON documents are interpreted in the context of reference preservation and metadata property validation.

## Version introduced

.NET Aspire 9.0 GA

## Previous behavior

Previously, `System.Text.Json` did not unescape metadata property names. For example, the following code would succeed in the first call but throw an exception in the second call:

```csharp
JsonSerializerOptions options = new() { ReferenceHandler = ReferenceHandler.Preserve };
JsonSerializer.Deserialize<MyPoco>("""{"\u0024invalid" : 42 }""", options);
JsonSerializer.Deserialize<MyPoco>("""{"$invalid" : 42 }""", options);

record MyPoco;
```

## New behavior

With the new behavior, both deserialization calls will fail with the following error:

```
Unhandled exception. System.Text.Json.JsonException: Properties that start with '$' are not allowed in types that support metadata.
```

## Type of breaking change

This change is a [behavioral change](../categories.md#behavioral-change).

## Reason for change

The change improves correctness and reliability by ensuring that metadata property names are properly unescaped, preventing the bypass of metadata property validation. For more details, see the [reported issue](https://github.com/dotnet/runtime/issues/112288).

## Recommended action

Users should avoid using escaping to bypass metadata property validation and should instead pick property names that do not conflict with metadata properties.

## Affected APIs

None.
