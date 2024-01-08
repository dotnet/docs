---
title: System.MidpointRounding enum
description: Learn about the System.MidpointRounding enum.
ms.date: 12/31/2023
---
# System.MidpointRounding enum

[!INCLUDE [context](includes/context.md)]

Use the <xref:System.MidpointRounding> enumeration with appropriate overloads of <xref:System.Math.Round%2A?displayProperty=nameWithType>, <xref:System.MathF.Round%2A?displayProperty=nameWithType>, and <xref:System.Decimal.Round%2A?displayProperty=nameWithType> to provide more control of the rounding process.

There are two overall rounding strategies&mdash;*round to nearest* and *directed rounding*&mdash;and each enumeration field participates in exactly one of these strategies.

## Round to nearest

Fields:

- <xref:System.MidpointRounding.AwayFromZero>
- <xref:System.MidpointRounding.ToEven>

A round-to-nearest operation takes an original number with an implicit or specified precision; examines the next digit, which is at that precision plus one; and returns the nearest number with the same precision as the original number. For positive numbers, if the next digit is from 0 through 4, the nearest number is toward negative infinity. If the next digit is from 6 through 9, the nearest number is toward positive infinity. For negative numbers, if the next digit is from 0 through 4, the nearest number is toward positive infinity. If the next digit is from 6 through 9, the nearest number is toward negative infinity.

If the next digit is from 0 through 4 or 6 through 9, the `MidpointRounding.AwayFromZero` and `MidpointRounding.ToEven` do not affect the result of the rounding operation. However, if the next digit is 5, which is the midpoint between two possible results, and all remaining digits are zero or there are no remaining digits, the nearest number is ambiguous. In this case, the round-to-nearest modes in `MidpointRounding` enable you to specify whether the rounding operation returns the nearest number away from zero or the nearest even number.

The following table demonstrates the results of rounding some negative and positive numbers in conjunction with round-to-nearest modes. The precision used to round the numbers is zero, which means the number after the decimal point affects the rounding operation. For example, for the number -2.5, the digit after the decimal point is 5. Because that digit is the midpoint, you can use a `MidpointRounding` value to determine the result of rounding. If `AwayFromZero` is specified, -3 is returned because it is the nearest number away from zero with a precision of zero. If `ToEven` is specified, -2 is returned because it is the nearest even number with a precision of zero.

| Original number | AwayFromZero | ToEven |
|-----------------|--------------|--------|
| 3.5             | 4            | 4      |
| 2.8             | 3            | 3      |
| 2.5             | 3            | 2      |
| 2.1             | 2            | 2      |
| -2.1            | -2           | -2     |
| -2.5            | -3           | -2     |
| -2.8            | -3           | -3     |
| -3.5            | -4           | -4     |

## Directed rounding

Fields:

- <xref:System.MidpointRounding.ToNegativeInfinity>
- <xref:System.MidpointRounding.ToPositiveInfinity>
- <xref:System.MidpointRounding.ToZero>

A directed-rounding operation takes an original number with an implicit or specified precision and returns the next closest number in a specific direction with the same precision as the original number. Directed modes on `MidpointRounding` control toward which predefined number the rounding is performed.

The following table demonstrates the results of rounding some negative and positive numbers in conjunction with directed-rounding modes. The precision used to round the numbers is zero, which means the number before the decimal point is affected by the rounding operation.

| Original number | ToNegativeInfinity | ToPositiveInfinity | ToZero |
|-----------------|--------------------|--------------------|--------|
| 3.5             | 3                  | 4                  | 3      |
| 2.8             | 2                  | 3                  | 2      |
| 2.5             | 2                  | 3                  | 2      |
| 2.1             | 2                  | 3                  | 2      |
| -2.1            | -3                 | -2                 | -2     |
| -2.5            | -3                 | -2                 | -2     |
| -2.8            | -3                 | -2                 | -2     |
| -3.5            | -4                 | -3                 | -3     |
