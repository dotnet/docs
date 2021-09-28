---
title: "How to: Copy directories"
description: See how to copy directories by using I/O classes that synchronously copy the contents of a directory to another location.
ms.date: "12/27/2018"
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

This example copies subdirectories by setting the `copySubDirs` of the `DirectoryCopy` method to `true`. The `DirectoryCopy` method recursively copies subdirectories by calling itself on each subdirectory until there are no more to copy.  
  
## Example  

 [!code-csharp[System.IO.Directory_Copy#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.IO.Directory_Copy/cs/program.cs#1)]
 [!code-vb[System.IO.Directory_Copy#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.IO.Directory_Copy/vb/Program.vb#1)]  
  
[!INCLUDE [localized code comments](../../../includes/code-comments-loc.md)]

## See also

- <xref:System.IO.FileInfo>
- <xref:System.IO.DirectoryInfo>
- <xref:System.IO.FileStream>
- [File and stream I/O](index.md)
- [Common I/O tasks](common-i-o-tasks.md)
- [Asynchronous file I/O](asynchronous-file-i-o.md)
