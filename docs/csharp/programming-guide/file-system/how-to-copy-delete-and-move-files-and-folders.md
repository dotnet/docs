---
title: "How to: Copy, Delete, and Move Files and Folders (C# Programming Guide) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "I/O [C#]"
ms.assetid: 62e52cd7-9597-4e4a-acf9-1315f5cdbf05
caps.latest.revision: 13
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# How to: Copy, Delete, and Move Files and Folders (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

The following examples show how to copy, move, and delete files and folders in a synchronous manner by using the <xref:System.IO.File?displayProperty=fullName>, <xref:System.IO.Directory?displayProperty=fullName>, <xref:System.IO.FileInfo?displayProperty=fullName>, and <xref:System.IO.DirectoryInfo?displayProperty=fullName> classes from the <xref:System.IO?displayProperty=fullName> namespace. These examples do not provide a progress bar or any other user interface. If you want to provide a standard progress dialog box, see [How to: Provide a Progress Dialog Box for File Operations](../../../csharp/programming-guide/file-system/how-to-provide-a-progress-dialog-box-for-file-operations.md).  
  
 Use <xref:System.IO.FileSystemWatcher?displayProperty=fullName> to provide events that will enable you to calculate the progress when operating on multiple files. Another approach is to use platform invoke to call the relevant file-related methods in the Windows Shell. For information about how to perform these file operations asynchronously, see [Asynchronous File I/O](../Topic/Asynchronous%20File%20I-O.md).  
  
## Example  
 The following example shows how to copy files and directories.  
  
 [!code-csharp[csFilesandFolders#7](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#7)]  
  
## Example  
 The following example shows how to move files and directories.  
  
 [!code-csharp[csFilesandFolders#8](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#8)]  
  
## Example  
 The following example shows how to delete files and directories.  
  
 [!code-csharp[csFilesandFolders#9](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#9)]  
  
## See Also  
 <xref:System.IO?displayProperty=fullName>   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [File System and the Registry (C# Programming Guide)](../../../csharp/programming-guide/file-system/file-system-and-the-registry.md)   
 [How to: Provide a Progress Dialog Box for File Operations](../../../csharp/programming-guide/file-system/how-to-provide-a-progress-dialog-box-for-file-operations.md)   
 [File and Stream I-O](../Topic/File%20and%20Stream%20I-O.md)   
 [Common I/O Tasks](../Topic/Common%20I-O%20Tasks.md)