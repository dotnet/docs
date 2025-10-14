---
title: "Breaking change: Type.MakeGenericSignatureType argument validation"
description: Learn about the .NET 10 breaking change in core .NET libraries where Type.MakeGenericSignatureType validates that the genericTypeDefinition argument is a generic type definition.
ms.date: 10/13/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/48902
---
# Type.MakeGenericSignatureType argument validation

Starting in .NET 10, the <xref:System.Type.MakeGenericSignatureType(System.Type,System.Type[])?displayProperty=nameWithType> API validates that the `genericTypeDefinition` argument is a generic type definition.

## Version introduced

.NET 10 Preview 3

## Previous behavior

Previously, <xref:System.Type.MakeGenericSignatureType(System.Type,System.Type[])?displayProperty=nameWithType> accepted any type for the `genericTypeDefinition` argument, including non-generic types.

## New behavior

Starting in .NET 10, <xref:System.Type.MakeGenericSignatureType(System.Type,System.Type[])?displayProperty=nameWithType> requires the `genericTypeDefinition` argument to be a generic type definition. If the argument is not a generic type definition, the method throws an <xref:System.ArgumentException>.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The type created by <xref:System.Type.MakeGenericSignatureType(System.Type,System.Type[])?displayProperty=nameWithType> had non-sensical behavior when the `genericTypeDefinition` argument was not a generic type definition.

## Recommended action

Avoid calling <xref:System.Type.MakeGenericSignatureType(System.Type,System.Type[])?displayProperty=nameWithType> for types that are not generic type definitions. For example:

```csharp
// Before
Type instantiatedType = Type.MakeGenericSignatureType(originalType, instantiation);

// After
Type instantiatedType = originalType.IsGenericTypeDefinition ? Type.MakeGenericSignatureType(originalType, instantiation) : originalType;
```

## Affected APIs

- <xref:System.Type.MakeGenericSignatureType(System.Type,System.Type[])?displayProperty=fullName>
