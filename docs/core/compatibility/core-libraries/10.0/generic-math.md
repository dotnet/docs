---
title: "Breaking change: Consistent shift behavior in generic math"
description: Learn about the .NET 10 breaking change in core .NET libraries where shift operations in generic math now have consistent behavior.
ms.date: 01/30/2025
ai-usage: ai-assisted
ms.topic: concept-article
---
# Consistent shift behavior in generic math

Shift operations in generic math now have consistent behavior across all built-in integer types.

## Previous behavior

The behavior when utilizing generic math to perform a shift on a `T` could differ based on the type. In some cases, it appropriately masked the shift amount by `sizeof(T) - 1`. And in other cases, there was no masking. This meant that "overshifting" (such as shifting a `byte` by 8) could result in different answers than expected.

## New behavior

The implementations were updated to mask the shift amount, as appropriate, to ensure consistent behavior across all built-in integer types and with the behavior documented by the <xref:System.Numerics.IShiftOperators`3?displayProperty=nameWithType> interface.

## Version introduced

.NET 10 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The behavior differed from the designed behavior due to a difference in how masking works for small integer types in C#.

## Recommended action

Update any code that relies on the previous inconsistent behavior to ensure it works with the new consistent behavior.

## Affected APIs

- `operator <<`
- `operator >>`
- `operator >>>` for `byte`, `char`, `sbyte`, `short`, and `ushort` when used via generic math, which requires a `T` constrained to `where T : IShiftOperators<T, int, T>` or a similar interface.
