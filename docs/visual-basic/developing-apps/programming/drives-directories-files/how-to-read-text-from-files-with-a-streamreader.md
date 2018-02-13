---
title: "How to: Read Text from Files with a StreamReader (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "reading files [Visual Basic], text"
  - "text, reading from files"
  - "reading text from files [Visual Basic]"
  - "files [Visual Basic], reading"
ms.assetid: 384033c6-18f9-4d59-9610-36371226558f
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Read Text from Files with a StreamReader (Visual Basic)
The `My.Computer.FileSystem` object provides methods to open a <xref:System.IO.TextReader> and a <xref:System.IO.TextWriter>. These methods, `OpenTextFileWriter` and `OpenTextFileReader`, are advanced methods that do not appear in IntelliSense unless you select the **All** tab.  
  
### To read a line from a file with a text reader  
  
-   Use the `OpenTextFileReader` method to open the <xref:System.IO.TextReader>, specifying the file. This example opens the file named `testfile.txt`, reads a line from it, and displays the line in a message box.  
  
     [!code-vb[VbFileIORead#1](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-read-text-from-files-with-a-streamreader_1.vb)]  
  
## Robust Programming  
 The file that is read must be a text file.  
  
 Do not make decisions about the contents of the file based on the name of the file. For example, the file Form1.vb may not be a Visual Basic source file.  
  
 Verify all inputs before using the data in your application. The contents of the file may not be what is expected, and methods to read from the file may fail.  
  
## .NET Framework Security  
 To read from a file, your assembly requires a privilege level granted by the <xref:System.Security.Permissions.FileIOPermission> class. If you are running in a partial-trust context, the code might throw an exception due to insufficient privileges. For more information, see [Code Access Security Basics](../../../../framework/misc/code-access-security-basics.md). The user also needs access to the file. For more information, see [ACL Technology Overview](http://msdn.microsoft.com/library/06fbf66d-6f02-4378-b863-b2f12e349045).  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem>  
 <xref:System.Windows.Forms.OpenFileDialog>  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileWriter%2A>  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.OpenTextFileReader%2A>  
 [SaveFileDialog Component](../../../../framework/winforms/controls/savefiledialog-component-windows-forms.md)  
 [Reading from Files](../../../../visual-basic/developing-apps/programming/drives-directories-files/reading-from-files.md)
