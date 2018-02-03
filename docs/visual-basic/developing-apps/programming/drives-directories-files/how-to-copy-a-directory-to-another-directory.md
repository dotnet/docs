---
title: "How to: Copy a Directory to Another Directory in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "I/O [Visual Basic], copying directories"
  - "I/O [Visual Basic], copying folders"
  - "folders [Visual Basic], copying"
  - "directories [Visual Basic], copying"
ms.assetid: 2a370bd7-10ba-4219-afc4-4519d031eb6c
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Copy a Directory to Another Directory in Visual Basic
Use the <xref:Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory%2A> method to copy a directory to another directory. This method copies the contents of the directory as well as the directory itself. If the target directory does not exist, it will be created. If a directory with the same name exists in the target location and `overwrite` is set to `False`, the contents of the two directories will be merged. You can specify a new name for the directory during the operation.  
  
 When copying files within a directory, exceptions may be thrown that are caused by specific file, such as a file existing during a merge while `overwrite` is set to `False`. When such exceptions are thrown, they are consolidated into a single exception, whose `Data` property holds entries in which the file or directory path is the key and the specific exception message is contained in the corresponding value.  
  
### To copy a directory to another directory  
  
-   Use the `CopyDirectory` method, specifying source and destination directory names. The following example copies the directory named `TestDirectory1` into `TestDirectory2`, overwriting existing files.  
  
     [!code-vb[VbVbcnMyFileSystem#16](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-copy-a-directory-to-another-directory_1.vb)]  
  
     This code example is also available as an IntelliSense code snippet. In the code snippet picker, it is located in **File system - Processing Drives, Folders, and Files**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The new name specified for the directory contains a colon (:) or slash (\ or /) (<xref:System.ArgumentException>).  
  
-   The path is not valid for one of the following reasons: it is a zero-length string, it contains only white space, it contains invalid characters, or it is a device path (starts with \\\\.\\) (<xref:System.ArgumentException>).  
  
-   The path is not valid because it is `Nothing` (<xref:System.ArgumentNullException>).  
  
-   `destinationDirectoryName` is `Nothing` or an empty string (<xref:System.ArgumentNullException>)  
  
-   The source directory does not exist (<xref:System.IO.DirectoryNotFoundException>).  
  
-   The source directory is a root directory (<xref:System.IO.IOException>).  
  
-   The combined path points to an existing file (<xref:System.IO.IOException>).  
  
-   The source path and target path are the same (<xref:System.IO.IOException>).  
  
-   `ShowUI` is set to `UIOption.AllDialogs` and the user cancels the operation, or one or more files in the directory cannot be copied (<xref:System.OperationCanceledException>).  
  
-   The operation is cyclic (<xref:System.InvalidOperationException>).  
  
-   The path contains a colon (:) (<xref:System.NotSupportedException>).  
  
-   The path exceeds the system-defined maximum length (<xref:System.IO.PathTooLongException>).  
  
-   A file or folder name in the path contains a colon (:) or is in an invalid format (<xref:System.NotSupportedException>).  
  
-   The user lacks necessary permissions to view the path (<xref:System.Security.SecurityException>).  
  
-   A destination file exists but cannot be accessed (<xref:System.UnauthorizedAccessException>).  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory%2A>  
 [How to: Find Subdirectories with a Specific Pattern](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-find-subdirectories-with-a-specific-pattern.md)  
 [How to: Get the Collection of Files in a Directory](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-get-the-collection-of-files-in-a-directory.md)
