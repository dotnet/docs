---
title: ".NET 6 breaking change: FileStream.Position updated after ReadAsync or WriteAsync completion"
description: Learn about the .NET 6 breaking change in core .NET libraries where FileStream.Position is updated after ReadAsync or WriteAsync completion.
ms.date: 10/04/2022
ms.topic: article
---
# FileStream.Position updates after ReadAsync or WriteAsync completes

<xref:System.IO.FileStream.Position?displayProperty=nameWithType> is now updated after <xref:System.IO.FileStream.ReadAsync%2A> or <xref:System.IO.FileStream.WriteAsync%2A> completes.

## Change description

In previous .NET versions on Windows, <xref:System.IO.FileStream.Position?displayProperty=nameWithType> was updated after the asynchronous read or write operation started. Starting in .NET 6, <xref:System.IO.FileStream.Position?displayProperty=nameWithType> is updated optimistically:

- After <xref:System.IO.FileStream.WriteAsync%2A> starts, but if the operation fails or is canceled, the position is corrected.
- When <xref:System.IO.FileStream.ReadAsync%2A> starts, but if the entire buffer isn't read, the position is corrected after the operation completes.

## Version introduced

.NET 6

## Reason for change

<xref:System.IO.FileStream> has never been thread-safe, but until .NET 6, .NET has tried to support multiple concurrent calls to its asynchronous methods (<xref:System.IO.FileStream.ReadAsync%2A> and <xref:System.IO.FileStream.WriteAsync%2A>) on Windows.

This change was introduced to allow for 100% asynchronous file I/O with <xref:System.IO.FileStream> and to fix the following issues:

- [FileStream.FlushAsync ends up doing synchronous writes](https://github.com/dotnet/runtime/issues/27643)
- [Win32 FileStream turns async reads into sync reads](https://github.com/dotnet/runtime/issues/16341)

## Recommended action

- If you rely on <xref:System.IO.FileStream.Position?displayProperty=nameWithType> being set before the read or write starts because your code performs *parallel* reads or writes, you should switch to use the <xref:System.IO.RandomAccess?displayProperty=fullName> API instead. The <xref:System.IO.RandomAccess> API is designed for parallel file operations.

- To enable the .NET 5 behavior in .NET 6, specify an `AppContext` switch or an environment variable. By setting the switch to `true`, you opt out of all performance improvements made to `FileStream` in .NET 6.

  ```json
  {
      "configProperties": {
          "System.IO.UseNet5CompatFileStream": true
      }
  }
  ```

  ```cmd
  set DOTNET_SYSTEM_IO_USENET5COMPATFILESTREAM=1
  ```

  > [!IMPORTANT]
  > This switch is only available in .NET 6. It was [removed in .NET 7](../7.0/filestream-compat-switch.md).

## Affected APIs

- <xref:System.IO.FileStream.Position?displayProperty=fullName>
