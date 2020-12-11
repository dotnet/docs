---
title: "Breaking change: TextInfo.ListSeparator value change"
description: Learn about the .NET 5.0 breaking change in where the default value of TextInfo.ListSeparator was changed between versions 5.0 and 5.0.1.
ms.date: 12/10/2020
---
# TextInfo.ListSeparator values changed

The default <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values for different cultures have been reverted to their pre-.NET 5.0 values on Windows.

## Change description

In .NET 5.0.0, as part of the [switch from NLS to ICU libraries](icu-globalization-api.md), the default <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values for different cultures changed on Windows. The decimal separator for a given culture was used as the <xref:System.Globalization.TextInfo.ListSeparator> value. Decimal separator values are obtained from International Components for Unicode (ICU). On Linux and macOS, there was no change in <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values.

Starting in .NET 5.0.1, the values for <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> are identical to the values in .NET Framework and .NET Core 1.0 - 3.1 on Windows. That is, the <xref:System.Globalization.TextInfo.ListSeparator> values are obtained from National Language Support (NLS) instead of ICU (via the decimal separator value).

## Version introduced

5.0.1

## Reason for change

Developers reported that they use the <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> property when parsing comma-separated value (CSV) files, and the new <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values broke that parsing.

## Recommended action

Unless you updated your parsing code to handle the list separator value changes in .NET 5.0.0, no action is necessary on your part. If you implemented new CSV-parsing functionality in .NET 5.0.0 using <xref:System.Globalization.TextInfo.ListSeparator>, update your code to account for the <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> changes in .NET 5.0.1.

## Affected APIs

- <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=fullName>

<!--

#### Category

- Globalization

### Affected APIs

- `P:System.Globalization.TextInfo.ListSeparator`

-->
