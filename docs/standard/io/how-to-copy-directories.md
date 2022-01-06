---
title: "How to: Copy directories"
description: See how to copy directories by using I/O classes that synchronously copy the contents of a directory to another location.
ms.date: 01/06/2022
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "directory copying"
  - "I/O [.NET], copying directories"
  - "subdirectory copying"
  - "copying directories"
  - "directories [.NET], copying"
ms.assetid: 5a969765-e5f8-4b4e-977e-90e2b0a1fe3c
---
# How to: Copy directories

This article demonstrates how to use I/O classes to synchronously copy the contents of a directory to another location.

For an example of asynchronous file copy, see [Asynchronous file I/O](asynchronous-file-i-o.md).

This example copies subdirectories by setting the `recursive` parameter of the `CopyDirectory` method to `true`. The `CopyDirectory` method recursively copies subdirectories by calling itself on each subdirectory until there are no more to copy.

## Example

:::code language="csharp" source="./snippets/how-to-copy-directories/csharp/Program.cs":::
:::code language="vb" source="./snippets/how-to-copy-directories/vb/Program.vb":::

[!INCLUDE [localized code comments](../../../includes/code-comments-loc.md)]

## See also

- <xref:System.IO.FileInfo>
- <xref:System.IO.DirectoryInfo>
- <xref:System.IO.FileStream>
- [File and stream I/O](index.md)
- [Common I/O tasks](common-i-o-tasks.md)
- [Asynchronous file I/O](asynchronous-file-i-o.md)
