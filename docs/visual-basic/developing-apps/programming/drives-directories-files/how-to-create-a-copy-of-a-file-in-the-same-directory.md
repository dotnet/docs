---
title: "How to: Create a Copy of a File in the Same Directory in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "File.Copy"
helpviewer_keywords: 
  - "My.Computer.FileSystem.CopyFile method, copying files [Visual Basic]"
  - "files [Visual Basic], copying"
  - "CopyFile method [Visual Basic], copying files in Visual Basic"
  - "I/O [Visual Basic], copying files"
ms.assetid: b2fdda86-e666-42c2-9706-9527e9fa68ff
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Create a Copy of a File in the Same Directory in Visual Basic
Use the `My.Computer.FileSystem.CopyFile` method to copy files. The parameters allow you to overwrite existing files, rename the file, show the progress of the operation, and allow the user to cancel the operation.  
  
### To create a copy of a file in the same folder  
  
-   Use the `CopyFile` method, supplying the target file and the location. The following example creates a copy of `test.txt` called `test2.txt`.  
  
     [!code-vb[VbVbcnMyFileSystem#51](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-create-a-copy-of-a-file-in-the-same-directory_1.vb)]  
  
### To create a copy of a file in the same folder, overwriting existing files  
  
-   Use the `CopyFile` method, supplying the target file and location, and setting `overwrite` to `True`. The following example creates a copy of `test.txt` called `test2.txt` and overwrites any existing files by that name.  
  
     [!code-vb[VbVbcnMyFileSystem#52](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-create-a-copy-of-a-file-in-the-same-directory_2.vb)]  
  
## Robust Programming  
 The following conditions may cause an exception to be thrown:  
  
-   The path is not valid for one of the following reasons: it is a zero-length string, it contains only white space, it contains invalid characters, or it is a device path (starts with \\\\.\\) (<xref:System.ArgumentException>).  
  
-   The system could not retrieve the absolute path (<xref:System.ArgumentException>).  
  
-   The path is not valid because it is `Nothing` (<xref:System.ArgumentNullException>).  
  
-   The source file is not valid or does not exist (<xref:System.IO.FileNotFoundException>).  
  
-   The combined path points to an existing directory (<xref:System.IO.IOException>).  
  
-   The destination file exists and `overwrite` is set to `False` (<xref:System.IO.IOException>).  
  
-   The user does not have sufficient permissions to access the file (<xref:System.IO.IOException>).  
  
-   A file in the target folder with the same name is in use (<xref:System.IO.IOException>).  
  
-   A file or folder name in the path contains a colon (:) or is in an invalid format (<xref:System.NotSupportedException>).  
  
-   `ShowUI` is set to `True`, `onUserCancel` is set to `ThrowException`, and the user has cancelled the operation (<xref:System.OperationCanceledException>).  
  
-   `ShowUI` is set to `True`, `onUserCancel` is set to `ThrowException`, and an unspecified I/O error occurs (<xref:System.OperationCanceledException>).  
  
-   The path exceeds the system-defined maximum length (<xref:System.IO.PathTooLongException>).  
  
-   The user does not have required permission (<xref:System.UnauthorizedAccessException>).  
  
-   The user lacks necessary permissions to view the path (<xref:System.Security.SecurityException>).  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem>  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.CopyFile%2A>  
 <xref:Microsoft.VisualBasic.FileIO.UICancelOption>  
 [How to: Copy Files with a Specific Pattern to a Directory](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-copy-files-with-a-specific-pattern-to-a-directory.md)  
 [How to: Create a Copy of a File in a Different Directory](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-create-a-copy-of-a-file-in-a-different-directory.md)  
 [How to: Copy a Directory to Another Directory](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-copy-a-directory-to-another-directory.md)  
 [How to: Rename a File](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-rename-a-file.md)
