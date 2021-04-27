---
title: "How to copy, delete, and move files and folders - C# Programming Guide"
description: Learn how to copy, delete, and move files and folders using the File, Directory, FileInfo, and DirectoryInfo classes.
ms.date: 07/20/2015
ms.topic: how-to
helpviewer_keywords: 
  - "I/O [C#]"
ms.assetid: 62e52cd7-9597-4e4a-acf9-1315f5cdbf05
---
# How to copy, delete, and move files and folders (C# Programming Guide)

The following examples show how to copy, move, and delete files and folders in a synchronous manner by using the <xref:System.IO.File?displayProperty=nameWithType>, <xref:System.IO.Directory?displayProperty=nameWithType>, <xref:System.IO.FileInfo?displayProperty=nameWithType>, and <xref:System.IO.DirectoryInfo?displayProperty=nameWithType> classes from the <xref:System.IO?displayProperty=nameWithType> namespace. These examples do not provide a progress bar or any other user interface. If you want to provide a standard progress dialog box, see [How to provide a progress dialog box for file operations](how-to-provide-a-progress-dialog-box-for-file-operations.md).  
  
 Use <xref:System.IO.FileSystemWatcher?displayProperty=nameWithType> to provide events that will enable you to calculate the progress when operating on multiple files. Another approach is to use platform invoke to call the relevant file-related methods in the Windows Shell. For information about how to perform these file operations asynchronously, see [Asynchronous File I/O](../../../standard/io/asynchronous-file-i-o.md).  
  
## Examples  

 The following example shows how to copy files and directories.  
  
 [!code-csharp[csFilesandFolders#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#7)]  
  
 The following example shows how to move files and directories.  
  
 [!code-csharp[csFilesandFolders#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#8)]  

 The following example shows how to delete files and directories.  
  
 [!code-csharp[csFilesandFolders#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#9)]  
  
## See also

- <xref:System.IO?displayProperty=nameWithType>
- [C# Programming Guide](../index.md)
- [File System and the Registry (C# Programming Guide)](index.md)
- [How to provide a progress dialog box for file operations](how-to-provide-a-progress-dialog-box-for-file-operations.md)
- [File and Stream I/O](../../../standard/io/index.md)
- [Common I/O Tasks](../../../standard/io/common-i-o-tasks.md)
