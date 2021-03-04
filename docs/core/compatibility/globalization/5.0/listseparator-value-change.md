---
title: "Breaking change: TextInfo.ListSeparator value change"
description: Learn about the .NET 5 breaking change where the default value of TextInfo.ListSeparator was changed between versions 5.0 and 5.0.1.
ms.date: 12/10/2020
---
# TextInfo.ListSeparator values changed

The default <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values for different cultures have changed on all operating systems.

## Change description

In .NET 5.0.0, as part of the [switch from NLS to ICU libraries](icu-globalization-api.md), the default <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values for different cultures changed on Windows. Decimal separator values, obtained from International Components for Unicode (ICU), were used as the <xref:System.Globalization.TextInfo.ListSeparator> values. On Linux and macOS, there was no change in <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values; that is, they continued to use decimal separator values.

For all operating systems in .NET 5.0.1 and later versions, the values for <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> are equivalent to the values that would be obtained from NLS. For Windows, this means the values are equivalent to what they were in .NET Framework and .NET Core 1.0 - 3.1. For Linux and macOS, the <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values now match the <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values for Windows.

The following table summarizes the changes for <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values.

| | .NET Framework<br/>.NET Core 1.0 - 3.1 | .NET 5 | .NET 5.0.1 |
-|-|-|-
| **Windows** | Obtain from NLS | Decimal separator from ICU.<br/>Can switch back to NLS. | Equivalent to NLS |
| **Linux and macOS** | Decimal separator from ICU | Decimal separator from ICU | Equivalent to NLS |

## Version introduced

5.0.1

## Reason for change

Developers reported that they use the <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> property when parsing comma-separated value (CSV) files, and the new <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values broke that parsing.

## Recommended action

If your code relies on the previous decimal separator values, you can hardcode the desired <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=nameWithType> values.

## Affected APIs

- <xref:System.Globalization.TextInfo.ListSeparator?displayProperty=fullName>

<!--

#### Category

- Globalization

### Affected APIs

- `P:System.Globalization.TextInfo.ListSeparator`

-->
