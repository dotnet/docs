---
title: "How to: Copy Directories"
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
  - "directory copying"
  - "I/O [.NET Framework], copying directories"
  - "subdirectory copying"
  - "copying directories"
  - "directories [.NET Framework], copying"
ms.assetid: 5a969765-e5f8-4b4e-977e-90e2b0a1fe3c
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Copy Directories
This example demonstrates how to use I/O classes to synchronously copy the contents of a directory to another location. In this example, the user can specify whether to also copy the subdirectories. If the subdirectories are copied, the method in this example recursively copies them by calling itself on each subsequent subdirectory until there are no more to copy.  
  
 For an example of copying files asynchronously, see [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md).  
  
## Example  
 [!code-csharp[System.IO.Directory_Copy#1](../../../samples/snippets/csharp/VS_Snippets_CLR_System/system.IO.Directory_Copy/cs/program.cs#1)]
 [!code-vb[System.IO.Directory_Copy#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR_System/system.IO.Directory_Copy/vb/Program.vb#1)]  
  
## See Also  
 <xref:System.IO.FileInfo>  
 <xref:System.IO.DirectoryInfo>  
 <xref:System.IO.FileStream>  
 [File and Stream I/O](../../../docs/standard/io/index.md)  
 [Common I/O Tasks](../../../docs/standard/io/common-i-o-tasks.md)  
 [Asynchronous File I/O](../../../docs/standard/io/asynchronous-file-i-o.md)
