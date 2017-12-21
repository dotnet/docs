---
title: "How to: Create Files and Directories in Isolated Storage"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "directories [.NET Framework], isolated storage"
  - "files [.NET Framework], isolated storage"
  - "isolated storage, creating files and directories"
  - "data stores, creating files and directories"
  - "data storage using isolated storage, creating files and directories"
  - "stores, creating files and directories"
  - "storing data using isolated storage, creating files and directories"
ms.assetid: 2ca4d2a4-809b-4f00-bc08-bf4a64d3a5c3
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Create Files and Directories in Isolated Storage
After you have obtained an isolated store, you can create directories and files for storing data. Within a store, file and directory names are specified with respect to the root of the virtual file system.  
  
 To create a directory, use the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.CreateDirectory%2A?displayProperty=nameWithType> instance method. If you specify a subdirectory of an directory that doesn't exist, both directories are created. If you specify a directory that already exists, the method returns without creating a directory, and no exception is thrown. However, if you specify a directory name that contains invalid characters, an <xref:System.IO.IsolatedStorage.IsolatedStorageException> exception is thrown.  
  
 To create a file, use  the <xref:System.IO.IsolatedStorage.IsolatedStorageFile.CreateFile%2A?displayProperty=nameWithType> method.  
  
 In the Windows operating system, isolated storage file and directory names are case-insensitive. That is, if you create a file named `ThisFile.txt`, and then create another file named `THISFILE.TXT`, only one file is created. The file name keeps its original casing for display purposes.  
  
## Example  
 The following code example illustrates how to create files and directories in an isolated store.  
  
 [!code-csharp[Conceptual.IsolatedStorage#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.isolatedstorage/cs/source.cs#1)]
 [!code-vb[Conceptual.IsolatedStorage#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.isolatedstorage/vb/source.vb#1)]  
  
## See Also  
 <xref:System.IO.IsolatedStorage.IsolatedStorageFile>  
 <xref:System.IO.IsolatedStorage.IsolatedStorageFileStream>  
 [Isolated Storage](../../../docs/standard/io/isolated-storage.md)
