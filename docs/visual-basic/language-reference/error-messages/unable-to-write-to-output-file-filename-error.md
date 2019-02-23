---
title: "Unable to write to output file '<filename>': <error>"
ms.date: 07/20/2015
f1_keywords: 
  - "vbc31019"
  - "bc31019"
helpviewer_keywords: 
  - "BC31019"
ms.assetid: 0845b245-11bb-46fd-95ca-f6cef3c318ef
---
# Unable to write to output file '\<filename>': \<error>
There was a problem creating the file.  
  
 An output file cannot be opened for writing. The file (or the folder containing the file) may be opened for exclusive use by another process, or it may have its read-only attribute set.  
  
 Common situations where a file is opened exclusively are:  
  
-   The application is already running and using its files. To solve this problem, make sure that the application is not running.  
  
-   Another application has opened the file. To solve this problem, make sure that no other application is accessing the files. It is not always obvious which application is accessing your files; in that case, restarting the computer might be the easiest way to terminate the application.  
  
 If even one of the project output files is marked as read-only, this exception will be thrown.  
  
 **Error ID:** BC31019  
  
## To correct this error  
  
1.  Compile the program again to see if the error recurs.  
  
2.  If the error continues, save your work and restart Visual Studio.  
  
3.  If the error continues, restart the computer.  
  
4.  If the error recurs, reinstall Visual Basic.  
  
5.  If the error persists after reinstallation, notify Microsoft Product Support Services.  
  
### To check file attributes in File Explorer  
  
1.  Open the folder you are interested in.  
  
2.  Click the **Views** icon and choose **Details**.  
  
3.  Right-click the column header, and choose **Attributes** from the drop-down list.  
  
### To change the attributes of a file or folder  
  
1.  In **File Explorer**, right-click the file or folder and choose **Properties**.  
  
2.  In the **Attributes** section of the **General** tab, clear the **Read-only** box.  
  
3.  Press **OK**.  
  
## See also
- [Talk to Us](/visualstudio/ide/talk-to-us)
