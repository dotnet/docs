---
title: "How to: Copy directories"
ms.date: "12/27/2018"
ms.technology: dotnet-standard
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "directory copying"
  - "I/O [.NET Framework], copying directories"
  - "subdirectory copying"
  - "copying directories"
  - "directories [.NET Framework], copying"
ms.assetid: 5a969765-e5f8-4b4e-977e-90e2b0a1fe3c
---
# How to: Copy directories
This topic demonstrates how to use I/O classes to synchronously copy the contents of a directory to another location. 

For an example of asynchronous file copy, see [Asynchronous file I/O](../../../docs/standard/io/asynchronous-file-i-o.md). 

This example copies subdirectories by setting the `copySubDirs` of the `DirectoryCopy` method to `true`. The `DirectoryCopy` method recursively copies subdirectories by calling itself on each subdirectory until there are no more to copy.  
  
## Example  
 [!code-csharp[System.IO.Directory_Copy#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.IO.Directory_Copy/cs/program.cs#1)]
 [!code-vb[System.IO.Directory_Copy#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.IO.Directory_Copy/vb/Program.vb#1)]  
  
## See also

- <xref:System.IO.FileInfo>
- <xref:System.IO.DirectoryInfo>
- <xref:System.IO.FileStream>
- [File and stream I/O](../../../docs/standard/io/index.md)
- [Common I/O tasks](../../../docs/standard/io/common-i-o-tasks.md)
- [Asynchronous file I/O](../../../docs/standard/io/asynchronous-file-i-o.md)
