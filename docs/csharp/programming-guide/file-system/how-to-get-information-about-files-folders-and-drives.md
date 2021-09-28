---
title: "How to get information about files, folders, and drives  - C# Programming Guide"
description: Learn how to get information about files, folders, and drives. See a code example and additional available resources.
ms.date: 07/20/2015
ms.topic: how-to
helpviewer_keywords: 
  - "files [C#], getting information about"
ms.assetid: 22fc2da6-5494-405b-995e-c0b99142a93e
---
# How to get information about files, folders, and drives  (C# Programming Guide)

In .NET, you can access file system information by using the following classes:  
  
- <xref:System.IO.FileInfo?displayProperty=nameWithType>  
  
- <xref:System.IO.DirectoryInfo?displayProperty=nameWithType>  
  
- <xref:System.IO.DriveInfo?displayProperty=nameWithType>  
  
- <xref:System.IO.Directory?displayProperty=nameWithType>  
  
- <xref:System.IO.File?displayProperty=nameWithType>  
  
 The <xref:System.IO.FileInfo> and <xref:System.IO.DirectoryInfo> classes represent a file or directory and contain properties that expose many of the file attributes that are supported by the NTFS file system. They also contain methods for opening, closing, moving, and deleting files and folders. You can create instances of these classes by passing a string that represents the name of the file, folder, or drive in to the constructor:  
  
```csharp  
System.IO.DriveInfo di = new System.IO.DriveInfo(@"C:\");  
```  
  
 You can also obtain the names of files, folders, or drives by using calls to <xref:System.IO.DirectoryInfo.GetDirectories%2A?displayProperty=nameWithType>, <xref:System.IO.DirectoryInfo.GetFiles%2A?displayProperty=nameWithType>, and <xref:System.IO.DriveInfo.RootDirectory%2A?displayProperty=nameWithType>.  
  
 The <xref:System.IO.Directory?displayProperty=nameWithType> and <xref:System.IO.File?displayProperty=nameWithType> classes provide static methods for retrieving information about directories and files.  
  
## Example  

 The following example shows various ways to access information about files and folders.  
  
 [!code-csharp[csFilesandFolders#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#6)]  
  
## Robust Programming  

 When you process user-specified path strings, you should also handle exceptions for the following conditions:  
  
- The file name is malformed. For example, it contains invalid characters or only white space.  
  
- The file name is null.  
  
- The file name is longer than the system-defined maximum length.  
  
- The file name contains a colon (:).  
  
 If the application does not have sufficient permissions to read the specified file, the `Exists` method returns `false` regardless of whether a path exists; the method does not throw an exception.  
  
## See also

- <xref:System.IO?displayProperty=nameWithType>
- [C# Programming Guide](../index.md)
- [File System and the Registry (C# Programming Guide)](./index.md)
