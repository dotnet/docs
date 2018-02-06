---
title: "How to: Rename a File in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "I/O [Visual Basic], renaming files"
  - "files [Visual Basic], renaming"
ms.assetid: 0ea7e0c8-2cb2-4bf5-a00d-7b6e3c08a3bc
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Rename a File in Visual Basic
Use the `RenameFile` method of the `My.Computer.FileSystem` object to rename a file by supplying the current location, file name, and the new file name. This method cannot be used to move a file; use the `MoveFile` method to move and rename the file.  
  
### To rename a file  
  
-   Use the `My.Computer.FileSystem.RenameFile` method to rename a file. This example renames the file named `Test.txt` to `SecondTest.txt`.  
  
     [!code-vb[VbVbcnMyFileSystem#9](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-rename-a-file_1.vb)]  
  
 This code example is also available as an IntelliSense code snippet. In the code snippet picker, the snippet is located in **File system - Processing Drives, Folders, and Files**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The path is not valid for one of the following reasons: it is a zero-length string, it contains only white space, it contains invalid characters, or it is a device path (starts with \\\\.\\) (<xref:System.ArgumentException>).  
  
-   `newName` contains path information (<xref:System.ArgumentException>).  
  
-   The path is not valid because it is `Nothing` (<xref:System.ArgumentNullException>).  
  
-   `newName` is `Nothing` or an empty string (<xref:System.ArgumentNullException>).  
  
-   The source file is not valid or does not exist (<xref:System.IO.FileNotFoundException>).  
  
-   There is an existing file or directory with the name specified in `newName` (<xref:System.IO.IOException>).  
  
-   The path exceeds the system-defined maximum length (<xref:System.IO.PathTooLongException>).  
  
-   A file or directory name in the path contains a colon (:) or is in an invalid format (<xref:System.NotSupportedException>).  
  
-   The user lacks necessary permissions to view the path (<xref:System.Security.SecurityException>).  
  
-   The user does not have the required permission (<xref:System.UnauthorizedAccessException>).  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.RenameFile%2A>  
 [How to: Move a File](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-move-a-file.md)  
 [Creating, Deleting, and Moving Files and Directories](../../../../visual-basic/developing-apps/programming/drives-directories-files/creating-deleting-and-moving-files-and-directories.md)  
 [How to: Create a Copy of a File in the Same Directory](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-create-a-copy-of-a-file-in-the-same-directory.md)  
 [How to: Create a Copy of a File in a Different Directory](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-create-a-copy-of-a-file-in-a-different-directory.md)
