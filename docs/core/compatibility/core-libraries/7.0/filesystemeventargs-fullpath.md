---
title: ".NET 7 breaking change: FullPath and OldFullPath return fully qualified path"
description: Learn about the .NET 7 breaking change in core .NET libraries where the FileSystemEventArgs.FullPath and RenamedEventArgs.OldFullPath properties return fully qualified paths.
ms.date: 02/08/2022
---
# FullPath and OldFullPath return fully qualified path

<xref:System.IO.FileSystemEventArgs.FullPath?displayProperty=nameWithType> and <xref:System.IO.RenamedEventArgs.OldFullPath?displayProperty=nameWithType> return a fully qualified path, even when <xref:System.IO.FileSystemWatcher> is initialized with a relative path. This matches the true intent of these properties.

## Previous behavior

In .NET 6 and previous versions, <xref:System.IO.FileSystemEventArgs.FullPath?displayProperty=nameWithType> and <xref:System.IO.RenamedEventArgs.OldFullPath?displayProperty=nameWithType> mirror what was passed into <xref:System.IO.FileSystemWatcher> initially, which can include a relative path.

## New behavior

Starting in .NET 7, <xref:System.IO.FileSystemEventArgs.FullPath?displayProperty=nameWithType> and <xref:System.IO.RenamedEventArgs.OldFullPath?displayProperty=nameWithType> return a fully qualified path, even when <xref:System.IO.FileSystemWatcher> is initialized with a relative path.

## Version introduced

.NET 7 Preview 1

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was introduced to align the actual result with the intent and name of the `FullPath` and `OldFullPath` properties from the event arguments.

## Recommended action

Check your usage of <xref:System.IO.FileSystemEventArgs.FullPath?displayProperty=nameWithType> and <xref:System.IO.RenamedEventArgs.OldFullPath?displayProperty=nameWithType> and make sure to account for the path change if necessary.

## Affected APIs

- <xref:System.IO.FileSystemEventArgs.FullPath?displayProperty=fullName>
- <xref:System.IO.RenamedEventArgs.OldFullPath?displayProperty=fullName>
