---
title: "Floating point-to-integer conversions are saturating"
description: Learn about the breaking change in .NET 9 where floating point-to-integer conversions have saturating behavior.
ms.date: 09/03/2024
---
# Floating point-to-integer conversions are saturating

Floating point-to-integer conversions now have *saturating* behavior on x86 and x64 machines. Saturating behavior means that if the converted value is too small or large for target type, the value is set to the minimum or maximum value, respectively, for that type.

Additionally, the `ConvertToIntegerNative<TInteger>` methods on [Single](xref:System.Single.ConvertToIntegerNative``1(System.Single)), [Double](xref:System.Double.ConvertToIntegerNative``1(System.Double)), and [Half](xref:System.Half.ConvertToIntegerNative``1(System.Half)) now have *platform-specific* behavior. This behavior is not guaranteed to match the previous behavior (which was already non-deterministic), but rather does whatever is most efficient for the native platform. In most cases, however, the behavior matches the previous behavior.

## Previous behavior

The following table shows the previous behavior when converting a `float` or `double` value.

| Convert to ...            | Value of `x`                           | (Previous) result         |
|---------------------------|----------------------------------------|---------------------------|
| `int` scalar and packed   | `int.MinValue <= x <= int.MaxValue`    | `(int)x`                  |
|                           | `< int.MinValue` or `> int.MaxValue`   | `int.MinValue`            |
| `long` scalar and packed  | `long.MinValue <= x <= long.MaxValue`  | `(long)x`                 |
|                           | `< long.MinValue` or `> long.MaxValue` | `long.MinValue`           |
| `uint` scalar and packed  | Any value                              | `(((long)x << 32) >> 32)` |
| `ulong` scalar and packed | `<= 2^63`                              | `(long)x`                 |
|                           | `> 2^63`                               | `(long)(x - 2^63) + 2^63` |

## New behavior

The following table shows the new behavior when converting a `float` or `double` value.

| Convert to ...            | Value of `x`                          | .NET 9+ result   |
|---------------------------|---------------------------------------|------------------|
| `int` scalar and packed   | `int.MinValue <= x <= int.MaxValue`   | `(int)x`         |
|                           | `< int.MinValue`                      | `int.MinValue`   |
|                           | `> int.MaxValue`                      | `int.MaxValue`   |
|                           | `NaN`                                 | 0                |
| `long` scalar and packed  | `long.MinValue <= x <= long.MaxValue` | `(long)x`        |
|                           | `< long.MinValue`                     | `long.MinValue`  |
|                           | `> long.MaxValue`                     | `long.MaxValue`  |
|                           | `NaN`                                 | 0                |
| `uint` scalar and packed  | `0 <= x <= uint.MaxValue`             | `(uint)x`        |
|                           | `x > uint.MaxValue`                   | `uint.MaxValue`  |
|                           | `x < 0`                               | 0                |
| `ulong` scalar and packed | `0 <= x <= ulong.MaxValue`            | `(ulong)x`       |
|                           | `x > ulong.MaxValue`                  | `ulong.MaxValue` |
|                           | `x < 0`                               | 0                |

## Version introduced

.NET 9 Preview 4

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to standardize all floating point-to-integer conversions to have saturating behavior.

## Recommended action

If you relied on the values shown in the [Previous behavior](#previous-behavior) section to be returned from the conversion, even if they were incorrect, update your code to expect the values shown in the [New behavior](#new-behavior) section.

## Affected APIs

- <xref:System.Half.ConvertToIntegerNative``1(System.Half)>
- <xref:System.Single.ConvertToIntegerNative``1(System.Single)>
- <xref:System.Double.ConvertToIntegerNative``1(System.Double)>
- All explicit and implicit casts from floating point to integer:

  - `(int)val` where `val` is a `float` or `double`
  - `Vector.ConvertToInt32(Vector<float> val)`
  - `(long)val` where `val` is a `float` or `double`
  - `Vector.ConvertToInt64(Vector<double> val)`
  - `(uint)val` where `val` is a `float` or `double`
  - `Vector.ConvertToUInt32(Vector<float> val)`
  - `(ulong)val` where `val` is a `float` or `double`
  - `Vector.ConvertToUInt64(Vector<double> val)`
