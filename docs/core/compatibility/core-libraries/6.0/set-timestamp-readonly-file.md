---
title: "Breaking change: Set timestamp on read-only file on Windows"
description: Learn about the .NET 6 servicing release breaking change where you can now set the timestamp on a read-only file on Windows.
ms.date: 01/11/2022
---
# Set timestamp on read-only file on Windows

Setting the timestamp on a file with the read-only attribute now succeeds on Windows and no longer throws an exception.

## Old behavior

Prior to .NET 6 servicing releases, setting the timestamp on a read-only file on Windows resulted in an <xref:System.UnauthorizedAccessException>.

## New behavior

Starting in .NET 6.0.2, setting the timestamp on a read-only file on Windows succeeds.

## Version introduced

.NET 6.0.2 (servicing release)

## Type of breaking change

This change can affect [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

Customers gave feedback that they expected setting the timestamp on a read-only file to succeed. This change also makes the Windows behavior consistent with Linux. Finally, the behavior was unintentional, caused by a bug.

## Recommended action

It is unlikely that existing code expects setting the timestamp on a read-only file to fail. However, if your code expects it to fail, add a check for the read-only attribute using <xref:System.IO.File.GetAttributes(System.String)?displayProperty=nameWithType> before attempting to set the timestamp.

## Affected APIs

- <xref:System.IO.File.SetCreationTime(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetCreationTimeUtc(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetLastAccessTime(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetLastAccessTimeUtc(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetLastWriteTime(System.String,System.DateTime)?displayProperty=fullName>
- <xref:System.IO.File.SetLastWriteTimeUtc(System.String,System.DateTime)?displayProperty=fullName>
