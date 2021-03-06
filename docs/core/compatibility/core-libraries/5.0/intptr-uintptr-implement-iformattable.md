---
title: "Breaking change: IntPtr and UIntPtr implement IFormattable"
description: Learn about the .NET 5 breaking change in core .NET libraries where IntPtr and UIntPtr now implement IFormattable.
ms.date: 11/01/2020
---
# IntPtr and UIntPtr implement IFormattable

<xref:System.IntPtr> and <xref:System.UIntPtr> now implement <xref:System.IFormattable>. Functions that check for <xref:System.IFormattable> support may now return different results for these types, because they may pass in a format specifier and a culture.

## Change description

In previous versions of .NET, <xref:System.IntPtr> and <xref:System.UIntPtr> do not implement <xref:System.IFormattable>. Functions that check for <xref:System.IFormattable> may fall back to just calling <xref:System.IntPtr.ToString%2A?displayProperty=nameWithType> or <xref:System.UIntPtr.ToString%2A?displayProperty=nameWithType>, which means that format specifiers and cultures are not respected.

In .NET 5 and later versions, <xref:System.IntPtr> and <xref:System.UIntPtr> implement <xref:System.IFormattable>. Functions that check for <xref:System.IFormattable> support may now return different results for these types, because they may pass in a format specifier and a culture.

This change impacts scenarios like interpolated strings and <xref:System.Console.WriteLine%2A?displayProperty=nameWithType>, among others.

## Reason for change

<xref:System.IntPtr> and <xref:System.UIntPtr> now have language support in C# through the `nint` and `nuint` keywords. The backing types were updated to provide near parity (where possible) with functionality exposed by other primitive types, such as <xref:System.Int32?displayProperty=nameWithType>.

## Version introduced

5.0

## Recommended action

If you don't want a format specifier or custom culture to be used when displaying values of these types, you can call the <xref:System.IntPtr.ToString?displayProperty=nameWithType> and <xref:System.UIntPtr.ToString?displayProperty=nameWithType> overloads of `ToString()`.

## Affected APIs

Not detectable via API analysis.

<!--

### Category

Core .NET libraries

### Affected APIs

Not detectable via API analysis.

-->
