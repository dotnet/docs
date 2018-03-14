---
title: "How to: Download a File in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "downloading Internet resources [Visual Basic], files"
  - "downloading files [Visual Basic]"
  - "remote computers [Visual Basic], downloading from"
  - "files [Visual Basic], downloading"
  - "files [Visual Basic], transferring"
ms.assetid: ac479f81-c0e2-4b99-af73-217f446b73da
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Download a File in Visual Basic
The <xref:Microsoft.VisualBasic.Devices.Network.DownloadFile%2A> method can be used to download a remote file and store it to a specific location. If the `ShowUI` parameter is set to `True`, a dialog box is displayed showing the progress of the download and allowing users to cancel the operation. By default, existing files having the same name are not overwritten; if you want to overwrite existing files, set the `overwrite` parameter to `True`.  
  
 The following conditions may cause an exception:  
  
-   Drive name is not valid (<xref:System.ArgumentException>).  
  
-   Necessary authentication has not been supplied (<xref:System.UnauthorizedAccessException> or <xref:System.Security.SecurityException>).  
  
-   The server does not respond within the specified `connectionTimeout` (<xref:System.TimeoutException>).  
  
-   The request is denied by the Web site (<xref:System.Net.WebException>).  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
> [!IMPORTANT]
>  Do not make decisions about the contents of the file based on the name of the file. For example, the file Form1.vb may not be a Visual Basic source file. Verify all inputs before using the data in your application. The contents of the file may not be what is expected, and methods to read from the file may fail.  
  
### To download a file  
  
-   Use the `DownloadFile` method to download the file, specifying the target file's location as a string or URI and specifying the location at which to store the file. This example downloads the file `WineList.txt` from `http://www.cohowinery.com/downloads` and saves it to `C:\Documents and Settings\All Users\Documents`:  
  
     [!code-vb[VbResourceTasks#9](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-download-a-file_1.vb)]  
  
### To download a file, specifying a time-out interval  
  
-   Use the `DownloadFile` method to download the file, specifying the target file's location as a string or URI, specifying the location at which to store the file, and specifying the time-out interval in milliseconds (the default is 1000). This example downloads the file `WineList.txt` from `http://www.cohowinery.com/downloads` and saves it to `C:\Documents and Settings\All Users\Documents`, specifying a time-out interval of 500 milliseconds:  
  
     [!code-vb[VbResourceTasks#10](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-download-a-file_2.vb)]  
  
### To download a file, supplying a user name and password  
  
-   Use the `DownLoadFile` method to download the file, specifying the target file's location as a string or URI and specifying the location at which to store the file, the user name, and the password. This example downloads the file `WineList.txt` from `http://www.cohowinery.com/downloads` and saves it to `C:\Documents and Settings\All Users\Documents`, with the user name `anonymous` and a blank password.  
  
     [!code-vb[VbResourceTasks#11](../../../../visual-basic/developing-apps/programming/computer-resources/codesnippet/VisualBasic/how-to-download-a-file_3.vb)]  
  
    > [!IMPORTANT]
    >  The FTP protocol used by the `DownLoadFile` method sends information, including passwords, in plain text and should not be used for transmitting sensitive information.  
  
## See Also  
 <xref:Microsoft.VisualBasic.Devices.Network>  
 <xref:Microsoft.VisualBasic.Devices.Network.DownloadFile%2A>  
 [How to: Upload a File](../../../../visual-basic/developing-apps/programming/computer-resources/how-to-upload-a-file.md)  
 [How to: Parse File Paths](../../../../visual-basic/developing-apps/programming/drives-directories-files/how-to-parse-file-paths.md)
