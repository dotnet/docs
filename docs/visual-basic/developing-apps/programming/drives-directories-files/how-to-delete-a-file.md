---
title: "How to: Delete a File in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Delete method [Visual Basic]"
  - "files [Visual Basic], deleting"
  - "files [Visual Basic], manipulating"
  - "File object"
ms.assetid: 4b721769-3e45-4be7-b7fe-b08dc4141b44
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Delete a File in Visual Basic
The `DeleteFile` method of the `My.Computer.FileSystem` object allows you to delete a file. Among the options it offers are: whether to send the deleted file to the **Recycle Bin**, whether to ask the user to confirm that the file should be deleted, and what to do when the user cancels the operation.  
  
### To delete a text file  
  
-   Use the `DeleteFile` method to delete the file. The following code demonstrates how to delete the file named `test.txt`.  
  
     [!code-vb[VbVbcnMyFileSystem#22](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-delete-a-file_1.vb)]  
  
### To delete a text file and ask the user to confirm that the file should be deleted  
  
-   Use the `DeleteFile` method to delete the file, setting `showUI` to `AllDialogs`. The following code demonstrates how to delete the file named `test.txt` and allow the user to confirm that the file should be deleted.  
  
     [!code-vb[VbFileIOMisc#9](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-delete-a-file_2.vb)]  
  
### To delete a text file and send it to the Recycle Bin  
  
-   Use the `DeleteFile` method to delete the file, specifying `SendToRecycleBin` for the `recycle` parameter. The following code demonstrates how to delete the file named `test.txt` and send it to the **Recycle Bin**.  
  
     [!code-vb[VbFileIOMisc#10](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-delete-a-file_3.vb)]  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The path is not valid for one of the following reasons: it is a zero-length string, it contains only white space, it contains invalid characters, or it is a device path (starts with \\\\.\\) (<xref:System.ArgumentException>).  
  
-   The path is not valid because it is `Nothing` (<xref:System.ArgumentNullException>).  
  
-   The path exceeds the system-defined maximum length (<xref:System.IO.PathTooLongException>).  
  
-   A file or folder name in the path contains a colon (:) or is in an invalid format (<xref:System.NotSupportedException>).  
  
-   The file is in use (<xref:System.IO.IOException>).  
  
-   The user lacks necessary permissions to view the path (<xref:System.Security.SecurityException>).  
  
-   The file does not exist (<xref:System.IO.FileNotFoundException>).  
  
-   The user does not have permission to delete the file, or the file is read-only (<xref:System.UnauthorizedAccessException>).  
  
-   A partial-trust situation exists in which the user does not have sufficient permissions (<xref:System.Security.SecurityException>).  
  
-   The user cancelled the operation and `onUserCancel` is set to `ThrowException` (<xref:System.OperationCanceledException>).  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileIO.UICancelOption>  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem>  
 <xref:Microsoft.VisualBasic.FileIO.UIOption>  
 <xref:Microsoft.VisualBasic.FileIO.RecycleOption>  
 [How to: Get the Collection of Files in a Directory](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-get-the-collection-of-files-in-a-directory.md)
