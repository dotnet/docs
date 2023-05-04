---
title: "Breaking change: Date and time converters honor culture argument"
description: Learn about the globalization breaking change in .NET 8 where the type converters for date and time types use the argument-specified culture to format the date and time.
ms.date: 05/03/2023
---
# Date and time converters honor culture argument

The `ConvertTo` methods on the following classes now use the culture from the `culture` parameter as the format provider for the date and time instead of <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType>:

- <xref:System.ComponentModel.DateOnlyConverter>
- <xref:System.ComponentModel.DateTimeConverter>
- <xref:System.ComponentModel.DateTimeOffsetConverter>
- <xref:System.ComponentModel.TimeOnlyConverter>

## Previous behavior

Previously, the [affected APIs](#affected-apis) used <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType> as the format provider for the date and time even though the caller specified a culture in the `culture` parameter.

Consider the following code snippet that sets the current culture to Spanish (Spain) but passes a customized French culture to <xref:System.ComponentModel.DateTimeConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)?displayProperty=nameWithType>.

```csharp
CultureInfo.CurrentCulture = new CultureInfo("es-ES");
Console.WriteLine($"Current culture: {CultureInfo.CurrentCulture}");

var dt1 = new DateTime(2022, 8, 1);

var frCulture = new CultureInfo("fr-FR");
frCulture.DateTimeFormat = new DateTimeFormatInfo() { ShortDatePattern = "dd MMMM yyyy" };

Console.WriteLine(TypeDescriptor.GetConverter(dt1).ConvertTo(null, frCulture, dt1, typeof(string)));
```

In .NET 7 and earlier versions, this code prints the date in the correct format but with the name of the month in Spanish instead of French:

```output
Current culture: es-ES
01 agosto 2022
```

## New behavior

Starting in .NET 8, the [affected APIs](#affected-apis) use the culture specified by the `culture` parameter as the format provider.

The code snippet shown in the [Previous behavior](#previous-behavior) correctly prints the name of the month in French:

```output
Current culture: es-ES
01 août 2022
```

## Version introduced

.NET 8 Preview 4

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change fixes a bug where `ConvertTo` was not consistent with `ConvertFrom`. It used the date and time format strings from the input culture but formatted the date and time with <xref:System.Globalization.CultureInfo.CurrentCulture>.

## Recommended action

If you relied on the previous behavior, pass in <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=nameWithType>, `null`, or a custom culture for the `culture` parameter.

## Affected APIs

- <xref:System.ComponentModel.DateOnlyConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)?displayProperty=fullName>
- <xref:System.ComponentModel.DateTimeConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)?displayProperty=fullName>
- <xref:System.ComponentModel.DateTimeOffsetConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)?displayProperty=fullName>
- <xref:System.ComponentModel.TimeOnlyConverter.ConvertTo(System.ComponentModel.ITypeDescriptorContext,System.Globalization.CultureInfo,System.Object,System.Type)?displayProperty=fullName>
