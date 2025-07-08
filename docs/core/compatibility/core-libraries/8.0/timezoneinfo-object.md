---
title: ".NET 8 breaking change: FindSystemTimeZoneById doesn't return new object"
description: Learn about the .NET 8 breaking change in core .NET libraries where TimeZoneInfo.FindSystemTimeZoneById doesn't return a new TimeZoneInfo object.
ms.date: 03/06/2024
---
# FindSystemTimeZoneById doesn't return new object

The <xref:System.TimeZoneInfo> object returned by <xref:System.TimeZoneInfo.FindSystemTimeZoneById(System.String)> is now a cached `TimeZoneInfo` instance instead of a new object.

## Previous behavior

<xref:System.TimeZoneInfo.FindSystemTimeZoneById(System.String)?displayProperty=nameWithType> returned a new `TimeZoneInfo` object.

## New behavior

Starting in .NET 8, <xref:System.TimeZoneInfo.FindSystemTimeZoneById(System.String)?displayProperty=nameWithType> returns a cached `TimeZoneInfo` instance.

## Version introduced

.NET 8

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to improve performance when calling <xref:System.TimeZoneInfo.FindSystemTimeZoneById(System.String)>. For more information, see [dotnet/runtime pull request #85615](https://github.com/dotnet/runtime/pull/85615).

## Recommended action

If your code relied on <xref:System.TimeZoneInfo.FindSystemTimeZoneById(System.String)> to create a new instance of `TimeZoneInfo`, refactor the code to call [one of these methods](xref:System.TimeZoneInfo#remarks) instead.

## Affected APIs

- <xref:System.TimeZoneInfo.FindSystemTimeZoneById(System.String)?displayProperty=fullName>
