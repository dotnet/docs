---
title: ".NET 8 breaking change: Complex.ToString format changed to `<a; b>`"
description: Learn about the .NET 8 breaking change in core .NET libraries where the Complex.ToString() format changed from `(a, b)` to `<a; b>`.
ms.date: 08/06/2024
---
# Complex.ToString format changed to `<a; b>`

To better support formatting values with culture-specific information, the default string representation of complex numbers was changed to avoid using characters that can be used in formatted numeric values. This change affects <xref:System.Numerics.Complex.ToString%2A?displayProperty=nameWithType>, where the value is now formatted as `<a; b>` instead of `(a, b)`. Both *a* and *b* are formatted using the general format specifier ("G") and the conventions of the culture defined by provider&mdash;this hasn't changed.

## Previous behavior

Previously, the string representation of the complex number returned by <xref:System.Numerics.Complex.ToString%2A?displayProperty=nameWithType> displayed the number using its Cartesian coordinates in the form `(a, b)`, where *a* was the real part of the complex number, and *b* was its imaginary part.

## New behavior

Starting in .NET 8, the string representation of the complex number returned by <xref:System.Numerics.Complex.ToString%2A?displayProperty=nameWithType> displays the number using its Cartesian coordinates in the form `<a; b>`, where *a* is the real part of the complex number, and *b* is its imaginary part.

## Version introduced

.NET 8

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The change to use a semicolon enables support of formatting with culture-specific information. It also enables the corresponding need to be able to parse results back out given that it implements <xref:System.Numerics.INumberBase%601>.

The change from parentheses (`( )`) to angle brackets avoids potential collision with numeric formats where negative numbers are formatted as `(x)`. The new behavior is also consistent with the behavior of the `Vector*` types.

## Recommended action

If you need the previous format, you can use a custom string formatting mechanism such as `$"({complex.Real}, {complex.Imaginary})"` to produce a string in that format.

## Affected APIs

- <xref:System.Numerics.Complex.ToString%2A?displayProperty=fullName>

## See also

- [Format a complex number](../../../../fundamentals/runtime-libraries/system-numerics-complex.md#format-a-complex-number)
