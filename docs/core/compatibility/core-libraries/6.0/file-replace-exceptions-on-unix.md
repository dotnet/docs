---
title: ".NET 6 breaking change: File.Replace exceptions on Unix"
description: Learn about the .NET 6 breaking change in core .NET libraries where File.Replace throws exceptions in more cases on Unix-based operating systems.
ms.date: 10/13/2021
---
# File.Replace on Unix throws exceptions to match Windows implementation

The behavior of <xref:System.IO.File.Replace%2A?displayProperty=nameWithType> on Unix-based operating systems has changed. The exceptions it throws now match those that are thrown by the Windows implementation.

## Previous Behavior

On Unix, with .NET 5, the <xref:System.IO.File.Replace%2A?displayProperty=nameWithType> method:

- Throws <xref:System.IO.IOException> with the message `Is a directory` when `sourceFileName` is a file and `destinationFileName` is a directory.
- Throws <xref:System.IO.IOException> with the message `Not a directory` when `sourceFileName` is a directory and `destinationFileName` is a file.
- Silently succeeds when both `sourceFileName` and `destinationFileName` point to the same file or directory.

## New behavior

On Unix, with .NET 6, the <xref:System.IO.File.Replace%2A?displayProperty=nameWithType> method:

- Throws <xref:System.UnauthorizedAccessException> with the message `The specified path <path> is not a path`, when either `sourceFileName` or `destinationFileName` exists and is not a file, or when both `sourceFileName` and `destinationFileName` point to the same existing directory.
- Throws <xref:System.IO.IOException> with the message `The source <sourceFileName> and destination <destinationFileName> are the same file` when `sourceFileName` and `destinationFileName` point to the same existing file.

## Version introduced

.NET 6

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

This change was made to ensure that <xref:System.IO.File.Replace%2A?displayProperty=nameWithType> throws the same exceptions for the same reasons across platforms.

## Recommended action

If you invoke <xref:System.IO.File.Replace%2A?displayProperty=nameWithType> on Unix inside a `try catch` block, make sure to now also catch <xref:System.UnauthorizedAccessException>. Also, be aware of the new behaviors that are caught.

## Affected APIs

- <xref:System.IO.File.Replace%2A?displayProperty=fullName>
