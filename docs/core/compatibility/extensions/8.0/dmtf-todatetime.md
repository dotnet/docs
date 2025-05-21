---
title: "Breaking change: ManagementDateTimeConverter.ToDateTime returns a local time"
description: Learn about the .NET 8 breaking change in .NET extensions where the DateTime returned by ManagementDateTimeConverter.ToDateTime is based on local time.
ms.date: 10/05/2023
ms.topic: concept-article
---
# ManagementDateTimeConverter.ToDateTime returns a local time

The <xref:System.DateTime> value returned by <xref:System.Management.ManagementDateTimeConverter.ToDateTime(System.String)?displayProperty=nameWithType> is now based on the local time zone.

## Version introduced

.NET 8 RC 1

## Previous behavior

Previously, <xref:System.Management.ManagementDateTimeConverter.ToDateTime(System.String)?displayProperty=nameWithType> returned a value whose <xref:System.DateTime.Kind?displayProperty=nameWithType> value was <xref:System.DateTimeKind.Unspecified?displayProperty=nameWithType>.

## New behavior

Starting in .NET 8, <xref:System.Management.ManagementDateTimeConverter.ToDateTime(System.String)?displayProperty=nameWithType> returns a value whose <xref:System.DateTime.Kind?displayProperty=nameWithType> value was <xref:System.DateTimeKind.Local?displayProperty=nameWithType>.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made so that the code matched what the documentation said it did.

## Recommended action

If your code expected the returned value to be based on an unspecified time zone, update it to expect a value that's based on the local time zone.

## Affected APIs

- <xref:System.Management.ManagementDateTimeConverter.ToDateTime(System.String)?displayProperty=fullName>
