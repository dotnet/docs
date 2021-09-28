---
description: "Learn more about: How to: Move a File in Visual Basic"
title: "How to: Move a File"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "files [Visual Basic], moving"
ms.assetid: 53a7457b-5815-41ad-b37d-28537c1fb77a
---
# How to: Move a File in Visual Basic

The `My.Computer.FileSystem.MoveFile` method can be used to move a file to another folder. If the target structure does not exist, it will be created.  
  
### To move a file  
  
- Use the `MoveFile` method to move the file, specifying the file name and location for both the source file and the target file. This example moves the file named `test.txt` from `TestDir1` to `TestDir2`. Note that the target file name is specified even though it is the same as the source file name.  
  
     [!code-vb[VbVbcnMyFileSystem#24](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyFileSystem/VB/Class1.vb#24)]  
  
### To move a file and rename it  
  
- Use the `MoveFile` method to move the file, specifying the source file name and location, the target location, and the new name at the target location. This example moves the file named `test.txt` from `TestDir1` to `TestDir2` and renames it `nexttest.txt`.  
  
     [!code-vb[VbVbcnMyFileSystem#25](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyFileSystem/VB/Class1.vb#25)]  
  
## Robust Programming  

 The following conditions may cause an exception:  
  
- The path is not valid for one of the following reasons: it is a zero-length string, it contains only white space, it contains invalid characters, or it is a device path (starts with \\\\.\\) (<xref:System.ArgumentException>).  
  
- The path is not valid because it is `Nothing` (<xref:System.ArgumentNullException>).  
  
- `destinationFileName` is `Nothing` or an empty string (<xref:System.ArgumentNullException>).  
  
- The source file is not valid or does not exist (<xref:System.IO.FileNotFoundException>).  
  
- The combined path points to an existing directory, the destination file exists and `overwrite` is set to `False`, a file in the target directory with the same name is in use, or the user does not have sufficient permissions to access the file (<xref:System.IO.IOException>).  
  
- A file or directory name in the path contains a colon (:) or is in an invalid format (<xref:System.NotSupportedException>).  
  
- `showUI` is set to `True`, `onUserCancel` is set to `ThrowException`, and either the user has cancelled the operation or an unspecified I/O error occurs (<xref:System.OperationCanceledException>).  
  
- The path exceeds the system-defined maximum length (<xref:System.IO.PathTooLongException>).  
  
- The user lacks necessary permissions to view the path (<xref:System.Security.SecurityException>).  
  
- The user does not have required permission (<xref:System.UnauthorizedAccessException>).  
  
## See also

- <xref:Microsoft.VisualBasic.FileIO.FileSystem.MoveFile%2A>
- [How to: Rename a File](how-to-rename-a-file.md)
- [How to: Create a Copy of a File in a Different Directory](how-to-create-a-copy-of-a-file-in-a-different-directory.md)
- [How to: Parse File Paths](how-to-parse-file-paths.md)
