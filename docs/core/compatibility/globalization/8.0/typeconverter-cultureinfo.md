---
title: "Breaking change: Date and time converters honor culture argument"
description: Learn about the globalization breaking change in .NET 8 where the type converters for date and time types use the argument-specified culture to format the date and time.
ms.date: 05/03/2023
---
# Date and time converters honor culture argument

The `ConvertTo` methods on the following classes now use the culture from the `culture` parameter to format the date and time instead of <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType>:

- <xref:System.ComponentModel.DateOnlyConverter>
- <xref:System.ComponentModel.DateTimeConverter>
- <xref:System.ComponentModel.DateTimeOffsetConverter>
- <xref:System.ComponentModel.TimeOnlyConverter>

## Previous behavior

Previously, the [affected APIs](#affected-apis) used <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> to format the date and time even though the caller specified a culture in the `culture` parameter.

## New behavior

Starting in .NET 8, the [affected APIs](#affected-apis) use the culture specified by the `culture` parameter to format the date and time.

## Version introduced

.NET 8 Preview 4

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change fixes a bug where `ConvertTo` was not consistent with `ConvertFrom`. It used the date format pattern from the input culture and but formatted the date and time with <xref:System.Globalization.CultureInfo.CurrentCulture>.

## Recommended action

If you relied on the previous behavior, pass in <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> or a custom culture for the `culture` parameter.

## Affected APIs

- <xref:System.ComponentModel.DateOnlyConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)?displayProperty=fullName>
- <xref:System.ComponentModel.DateTimeConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)?displayProperty=fullName>
- <xref:System.ComponentModel.DateTimeOffsetConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)?displayProperty=fullName>
- <xref:System.ComponentModel.TimeOnlyConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)?displayProperty=fullName>
