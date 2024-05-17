---
title: ".NET 7 breaking change: DateTime addition methods precision change"
description: Learn about the .NET 7 breaking change in core .NET libraries where the precision of the value that's added in DateTime addition methods has increased.
ms.date: 02/01/2023
---
# DateTime addition methods precision change

In .NET 6 and earlier versions, the value parameter of the `DateTime` addition methods was rounded to the nearest millisecond. In .NET 7 and later versions, the full <xref:System.Double> precision of the value parameter is used. However, due to the inherent imprecision of floating-point math, the resulting precision will vary.

## Previous behavior

Previously, the `double` value parameter of the <xref:System.DateTime> `Add*` methods, for example, <xref:System.DateTime.AddDays(System.Double)?displayProperty=nameWithType>, was rounded to the nearest millisecond.

## New behavior

Starting in .NET 7, the full precision of the `double` value parameter is used, improving the precision of the [affected methods](#affected-apis).

## Version introduced

.NET 7

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made in response to a community request to improve the precision in <xref:System.DateTime>.

## Recommended action

No specific action unless you have code that depends on the precision of the `Add*` methods. In that case, review your code and retest it to avoid any surprises with the precision change.

## Affected APIs

- <xref:System.DateTime.AddDays(System.Double)?displayProperty=fullName>
- <xref:System.DateTime.AddHours(System.Double)?displayProperty=fullName>
- <xref:System.DateTime.AddMicroseconds(System.Double)?displayProperty=fullName>
- <xref:System.DateTime.AddMilliseconds(System.Double)?displayProperty=fullName>
- <xref:System.DateTime.AddMinutes(System.Double)?displayProperty=fullName>
- <xref:System.DateTime.AddSeconds(System.Double)?displayProperty=fullName>
