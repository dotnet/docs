---
title: "Breaking change: Math.Round and MathF.Round return correctly rounded results"
description: "Learn about the breaking change in .NET 11 where Math.Round and MathF.Round with a digits argument return the correctly rounded result and accept any non-negative digit count."
ms.date: 08/04/2026
ai-usage: ai-assisted
---

# Math.Round and MathF.Round return correctly rounded results

<xref:System.Math.Round(System.Double,System.Int32)?displayProperty=nameWithType> and <xref:System.MathF.Round(System.Single,System.Int32)?displayProperty=nameWithType>, and their <xref:System.MidpointRounding> overloads, now return the value that's correctly rounded to the requested number of fractional digits based on the *exact* value of the input. Some inputs now round to a different (and correct) result than in previous releases. In addition, the `digits` argument no longer has an upper limit.

## Version introduced

.NET 11 Preview 7

## Previous behavior

Previously, `Math.Round(value, digits, mode)` computed `Round(value * 10^digits, mode) / 10^digits`. Because `value * 10^digits` generally isn't exactly representable, values slightly below (or above) a decimal midpoint could scale into an exact midpoint or across a rounding boundary, which produced an incorrectly rounded result. Values with large magnitudes could also lose their fractional bits entirely during the scaling step.

The `digits` argument was also limited to 0-15 for `double` and 0-6 for `float`; values outside that range threw <xref:System.ArgumentOutOfRangeException>.

```csharp
Math.Round(655.925, 2, MidpointRounding.AwayFromZero);            // 655.93              (incorrect)
Math.Round(1111111111111111.5, 1, MidpointRounding.AwayFromZero); // 1111111111111111.6  (incorrect)
Math.Round(1.5, 16, MidpointRounding.ToEven);                     // throws ArgumentOutOfRangeException
```

For example, `655.925` is stored as `655.924999999999954525…`, which is below the `655.925` midpoint, so the correct result is `655.92`.

## New behavior

Starting in .NET 11, the result is computed from the exact value of the input using arbitrary-precision arithmetic, and the returned value is the nearest representable value to the correctly rounded decimal result.

Also, any non-negative `digits` value is accepted; only negative values throw <xref:System.ArgumentOutOfRangeException>. Digit counts at or beyond the precision needed to round-trip the type (17 for `double`, 9 for `float`) leave the value unchanged, which is the correct result.

```csharp
Math.Round(655.925, 2, MidpointRounding.AwayFromZero);            // 655.92              (correct)
Math.Round(1111111111111111.5, 1, MidpointRounding.AwayFromZero); // 1111111111111111.5  (correct)
Math.Round(1.5, 16, MidpointRounding.ToEven);                     // 1.5                 (no longer throws)
```

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The previous results were incorrect for a large fraction of inputs&mdash;roughly 5% of random values across the supported `digits` range differed from the correctly rounded result. The previous behavior also rejected or mishandled large finite inputs. The new implementation is IEEE-consistent: it rounds the exact value of the input and returns the nearest representable result, which matches the value that `value.ToString("F{digits}")` already produced.

The 0-15 and 0-6 `digits` caps were an artificial limitation tied to the old scale-by-`10^digits` approach. Because the exact implementation is correct for any digit count, the cap was lifted at the same time to avoid a second behavioral break later.

For more information, see [dotnet/runtime#130574](https://github.com/dotnet/runtime/pull/130574).

## Recommended action

Most code needs no change and benefits from the corrected results.

If you depend on the exact prior (incorrect) output, round using the previous approach explicitly, for example, `Math.Round(value * pow10, mode) / pow10`. Alternatively, perform the rounding using `decimal` when the values represent base-10 quantities such as currency.

`double` and `float` are binary floating-point types and can't exactly represent most decimal fractions. For exact decimal rounding of decimal quantities, prefer <xref:System.Decimal>. <System.Numerics.Decimal32>, <System.Numerics.Decimal64>, and <System.Numerics.Decimal128> are IEEE 754 decimal-based types with expanded ranges and functionality, and are also suitable for this type of work.

## Affected APIs

- <xref:System.Math.Round(System.Double,System.Int32)?displayProperty=fullName>
- <xref:System.Math.Round(System.Double,System.Int32,System.MidpointRounding)?displayProperty=fullName>
- <xref:System.MathF.Round(System.Single,System.Int32)?displayProperty=fullName>
- <xref:System.MathF.Round(System.Single,System.Int32,System.MidpointRounding)?displayProperty=fullName>

The same corrected behavior and lifted `digits` range flow through the numeric interface entry points that delegate to these methods, for example, `double.Round`, `float.Round`, `Half.Round`, and `NFloat.Round`. <xref:System.Math.Round(System.Decimal,System.Int32)?displayProperty=nameWithType> and the single-argument <xref:System.Math.Round(System.Double)?displayProperty=nameWithType> and <xref:System.MathF.Round(System.Single)?displayProperty=nameWithType> overloads are unaffected.
