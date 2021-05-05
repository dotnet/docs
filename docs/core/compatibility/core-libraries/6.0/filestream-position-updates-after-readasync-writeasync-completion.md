---
title: ".NET 6 breaking change: FileStream.Position updated after ReadAsync or WriteAsync completion"
description: Learn about the .NET 6 breaking change in core .NET libraries FileStream.Position is updated after ReadAsync or WriteAsync completion.
ms.date: 05/05/2021
---
# FileStream.Position updates after ReadAsync or WriteAsync completes

<xref:System.IO.FileStream.Position?displayProperty=nameWithType> is now updated after <xref:System.IO.FileStream.ReadAsync%2A> or <xref:System.IO.FileStream.WriteAsync%2A> complete.

## Change description

In previous .NET versions on Windows, <xref:System.IO.FileStream.Position?displayProperty=nameWithType> is updated after the asynchronous read or write operation starts. Starting in .NET 6, <xref:System.IO.FileStream.Position?displayProperty=nameWithType> is updated after those operations complete.

## Version introduced

6.0 Preview 4

## Reason for change

<xref:System.IO.FileStream> has never been thread-safe, but until .NET 6, .NET has tried to support multiple concurrent calls to its async methods (<xref:System.IO.FileStream.ReadAsync%2A> and <xref:System.IO.FileStream.WriteAsync%2A>) on Windows.

This change was introduced to allow for 100% asynchronous file I/O with <xref:System.IO.FileStream> and to fix the following issues:

- [FileStream.FlushAsync ends up doing synchronous writes](https://github.com/dotnet/runtime/issue/27643)
- [Win32 FileStream turns async reads into sync reads](https://github.com/dotnet/runtime/issue/16341)

Now when buffering is enabled (that is, the `bufferSize` argument that's passed to <xref:System.IO.FileStream.%23ctor%2A> is greater than 1), every <xref:System.IO.FileStream.ReadAsync%2A> and <xref:System.IO.FileStream.WriteAsync%2A> operation is serialized.

## Recommended action



## Affected APIs

- <xref:System.IO.FileStream.Position?displayProperty=fullName>

<!--

### Category

- Core .NET libraries

### Affected APIs

- `P:System.IO.FileStream.Position`

-->
