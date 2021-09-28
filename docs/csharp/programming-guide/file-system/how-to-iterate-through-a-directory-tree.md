---
title: "How to iterate through a directory tree - C# Programming Guide"
description: Learn how to iterate through a directory tree. Access each file in each nested subdirectory under a specified root folder.
ms.date: 07/20/2015
ms.topic: how-to
helpviewer_keywords: 
  - "iterating through folders [C#]"
  - "file iteration [C#]"
ms.assetid: c4be4a75-6b1b-46a7-9d38-bab353091ed7
---
# How to iterate through a directory tree (C# Programming Guide)

The phrase "iterate a directory tree" means to access each file in each nested subdirectory under a specified root folder, to any depth. You do not necessarily have to open each file. You can just retrieve the name of the file or subdirectory as a `string`, or you can retrieve additional information in the form of a <xref:System.IO.FileInfo?displayProperty=nameWithType> or <xref:System.IO.DirectoryInfo?displayProperty=nameWithType> object.  
  
> [!NOTE]
> In Windows, the terms "directory" and "folder" are used interchangeably. Most documentation and user interface text uses the term "folder," but .NET class libraries use the term "directory."  
  
 In the simplest case, in which you know for certain that you have access permissions for all directories under a specified root, you can use the `System.IO.SearchOption.AllDirectories` flag. This flag returns all the nested subdirectories that match the specified pattern. The following example shows how to use this flag.  
  
```csharp  
root.GetDirectories("*.*", System.IO.SearchOption.AllDirectories);  
```  
  
 The weakness in this approach is that if any one of the subdirectories under the specified root causes a <xref:System.IO.DirectoryNotFoundException> or <xref:System.UnauthorizedAccessException>, the whole method fails and returns no directories. The same is true when you use the <xref:System.IO.DirectoryInfo.GetFiles%2A> method. If you have to handle these exceptions on specific subfolders, you must manually walk the directory tree, as shown in the following examples.  
  
 When you manually walk a directory tree, you can handle the files first (*pre-order traversal*), or the subdirectories first (*post-order traversal*). If you perform a pre-order traversal, you visit files directly under that folder itself, and then walk the whole tree under the current folder. Post-order traversal is the other way around, walking the whole tree beneath before getting to the current folder's files. The examples later in this document perform pre-order traversal, but you can easily modify them to perform post-order traversal.  
  
 Another option is whether to use recursion or a stack-based traversal. The examples later in this document show both approaches.  
  
 If you have to perform a variety of operations on files and folders, you can modularize these examples by refactoring the operation into separate functions that you can invoke by using a single delegate.  
  
> [!NOTE]
> NTFS file systems can contain *reparse points* in the form of *junction points*, *symbolic links*, and *hard links*. .NET methods such as <xref:System.IO.DirectoryInfo.GetFiles%2A> and <xref:System.IO.DirectoryInfo.GetDirectories%2A> will not return any subdirectories under a reparse point. This behavior guards against the risk of entering into an infinite loop when two reparse points refer to each other. In general, you should use extreme caution when you deal with reparse points to ensure that you do not unintentionally modify or delete files. If you require precise control over reparse points, use platform invoke or native code to call the appropriate Win32 file system methods directly.  
  
## Examples  

 The following example shows how to walk a directory tree by using recursion. The recursive approach is elegant but has the potential to cause a stack overflow exception if the directory tree is large and deeply nested.  
  
 The particular exceptions that are handled, and the particular actions that are performed on each file or folder, are provided as examples only. You should modify this code to meet your specific requirements. See the comments in the code for more information.  
  
 [!code-csharp[csFilesandFolders#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#1)]  
  
 The following example shows how to iterate through files and folders in a directory tree without using recursion. This technique uses the generic <xref:System.Collections.Generic.Stack%601> collection type, which is a last in first out (LIFO) stack.  
  
 The particular exceptions that are handled, and the particular actions that are performed on each file or folder, are provided as examples only. You should modify this code to meet your specific requirements. See the comments in the code for more information.  
  
 [!code-csharp[csFilesandFolders#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csFilesAndFolders/CS/FileIteration.cs#2)]  
  
 It is generally too time-consuming to test every folder to determine whether your application has permission to open it. Therefore, the code example just encloses that part of the operation in a `try/catch` block. You can modify the `catch` block so that when you are denied access to a folder, you try to elevate your permissions and then access it again. As a rule, only catch those exceptions that you can handle without leaving your application in an unknown state.  
  
 If you must store the contents of a directory tree, either in memory or on disk, the best option is to store only the <xref:System.IO.FileSystemInfo.FullName%2A> property (of type `string`) for each file. You can then use this string to create a new <xref:System.IO.FileInfo> or <xref:System.IO.DirectoryInfo> object as necessary, or open any file that requires additional processing.  
  
## Robust Programming  

 Robust file iteration code must take into account many complexities of the file system. For more information on the Windows file system, see [NTFS overview](/windows-server/storage/file-server/ntfs-overview).  
  
## See also

- <xref:System.IO>
- [LINQ and File Directories](../concepts/linq/linq-and-file-directories.md)
- [File System and the Registry (C# Programming Guide)](./index.md)
