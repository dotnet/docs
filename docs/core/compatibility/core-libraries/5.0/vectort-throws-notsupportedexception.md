---
title: "Breaking change: Vector<T> throws NotSupportedException"
description: Learn about the .NET 5 breaking change in core .NET libraries where Vector<T> always throws an exception for unsupported type parameters.
ms.date: 11/01/2020
---
# Vector\<T> always throws NotSupportedException for unsupported types

<xref:System.Numerics.Vector%601?displayProperty=nameWithType> now always throws a <xref:System.NotSupportedException> for unsupported type parameters.

## Change description

Previously, members of <xref:System.Numerics.Vector%601> would not always throw a <xref:System.NotSupportedException> when `T` was an [unsupported type](#unsupported-types). The exception wasn't always thrown because of code paths that supported hardware acceleration. For example, `Vector<bool> + Vector<bool>` returned `default` instead of throwing an exception on platforms that have no hardware acceleration, such as ARM32. For unsupported types, <xref:System.Numerics.Vector%601> members exhibited inconsistent behavior across different platforms and hardware configurations.

Starting in .NET 5, <xref:System.Numerics.Vector%601> members always throw a <xref:System.NotSupportedException> on all hardware configurations when `T` is not a supported type.

### Unsupported types

The supported types for the type parameter of <xref:System.Numerics.Vector%601> are:

- `byte`
- `sbyte`
- `short`
- `ushort`
- `int`
- `uint`
- `long`
- `ulong`
- `float`
- `double`

The supported types have not changed, however, they may change in the future.

## Version introduced

5.0

## Recommended action

Don't use an unsupported type for the type parameter of <xref:System.Numerics.Vector%601>.

## Affected APIs

- <xref:System.Numerics.Vector%601?displayProperty=fullName> and all its members

<!--

#### Category

Core .NET libraries

### Affected APIs

- ``T:System.Numerics.Vector`1``

-->
