---
title: ".NET 8 breaking change: FileStream writes when pipe is closed"
description: Learn about the .NET 8 breaking change in core .NET libraries where an exception is thrown if you write to a FileStream whose underlying pipe is closed.
ms.date: 01/27/2023
ms.topic: article
---
# FileStream writes when pipe is closed

<xref:System.IO.FileStream> error handling on Windows has been updated to be consistent with <xref:System.IO.Pipes.NamedPipeServerStream>, <xref:System.IO.Pipes.NamedPipeClientStream>, <xref:System.IO.Pipes.AnonymousPipeServerStream>, and <xref:System.IO.Pipes.AnonymousPipeClientStream>.

## Previous behavior

Previously, when writing to a <xref:System.IO.FileStream> that represented a closed or disconnected pipe, the underlying operating system error was ignored and the write was reported as successful. However, nothing was written to the pipe.

## New behavior

Starting in .NET 8, when writing to a <xref:System.IO.FileStream> whose underlying pipe is closed or disconnected, the write fails and an <xref:System.IO.IOException> is thrown.

## Version introduced

.NET 8 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made to unify the handling of edge cases and avoid silent errors that are difficult to diagnose.

## Recommended action

Close or disconnect the pipe after everything has been written.

## Affected APIs

- <xref:System.IO.FileStream.WriteByte(System.Byte)?displayProperty=fullName>
- <xref:System.IO.FileStream.Write%2A?displayProperty=fullName>
- <xref:System.IO.FileStream.WriteAsync%2A?displayProperty=fullName>
