---
description: "Learn more about: How to: Find Files with a Specific Pattern in Visual Basic"
title: "How to: Find Files with a Specific Pattern"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "files [Visual Basic], finding"
  - "pattern matching"
  - "patterns, matching"
ms.assetid: 25e3b71d-b844-4293-9e4e-f06c5836b5cc
---
# How to: Find Files with a Specific Pattern in Visual Basic

The <xref:Microsoft.VisualBasic.MyServices.FileSystemProxy.GetFiles%2A> method returns a read-only collection of strings representing the path names for the files. You can use the `wildCards` parameter to specify a specific pattern. If you would like to include subdirectories in the search, set the `searchType` parameter to `SearchOption.SearchAllSubDirectories`.  
  
 An empty collection is returned if no files matching the specified pattern are found.  
  
> [!NOTE]
> For information about returning a file list by using the `DirectoryInfo` class of the `System.IO` namespace, see <xref:System.IO.DirectoryInfo.GetFiles%2A>.  
  
### To find files with a specified pattern  
  
- Use the `GetFiles` method, supplying the name and path of the directory you want to search and specifying the pattern. The following example returns all files with the extension `.dll` in the directory and adds them to `ListBox1`.  
  
     [!code-vb[VbFileIOMisc#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIOMisc/VB/Class1.vb#4)]  
  
## .NET Framework Security  

 The following conditions may cause an exception:  
  
- The path is not valid for one of the following reasons: it is a zero-length string, it contains only white space, it contains invalid characters, or it is a device path (starts with \\\\.\\) (<xref:System.ArgumentException>).  
  
- The path is not valid because it is `Nothing` (<xref:System.ArgumentNullException>).  
  
- `directory` does not exist (<xref:System.IO.DirectoryNotFoundException>).  
  
- `directory` points to an existing file (<xref:System.IO.IOException>).  
  
- The path exceeds the system-defined maximum length (<xref:System.IO.PathTooLongException>).  
  
- A file or folder name in the path contains a colon (:) or is in an invalid format (<xref:System.NotSupportedException>).  
  
- The user lacks necessary permissions to view the path (<xref:System.Security.SecurityException>).  
  
- The user lacks necessary permissions (<xref:System.UnauthorizedAccessException>).  
  
## See also

- <xref:Microsoft.VisualBasic.MyServices.FileSystemProxy.GetFiles%2A>
- [How to: Find Subdirectories with a Specific Pattern](how-to-find-subdirectories-with-a-specific-pattern.md)
- [Troubleshooting: Reading from and Writing to Text Files](troubleshooting-reading-from-and-writing-to-text-files.md)
- [How to: Get the Collection of Files in a Directory](how-to-get-the-collection-of-files-in-a-directory.md)
