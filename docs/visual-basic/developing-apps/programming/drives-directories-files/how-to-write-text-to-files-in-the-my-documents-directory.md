---
title: "How to: Write Text to Files in the My Documents Directory in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "files [Visual Basic], writing to"
  - "text, writing to files"
  - "examples [Visual Basic], text files"
  - "writing to files [Visual Basic], in My Documents"
ms.assetid: 1c726124-781d-4976-9baa-ed46814ff3fe
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Write Text to Files in the My Documents Directory in Visual Basic
The `My.Computer.FileSystem.SpecialDirectories` object allows you to access special directories, such as the **MyDocuments** directory.  
  
## Procedure  
  
#### To write new text files in the My Documents directory  
  
1.  Use the `My.Computer.FileSystem.SpecialDirectories.MyDocuments` property to supply the path.  
  
     [!code-vb[VbFileIOWrite#1](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-write-text-to-files-in-the-my-documents-directory_1.vb)]  
  
2.  Use the `WriteAllText` method to write text to the specified file.  
  
     [!code-vb[VbVbcnMyFileSystem#14](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-write-text-to-files-in-the-my-documents-directory_2.vb)]  
  
## Example  
 [!code-vb[VbFileIOWrite#2](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-write-text-to-files-in-the-my-documents-directory_3.vb)]  
  
## Compiling the Code  
 Replace `test.txt` with the name of the file you want to write to.  
  
## Robust Programming  
 This code rethrows all the exceptions that may occur when writing text to the file. You can reduce the likelihood of exceptions by using Windows Forms controls such as the [OpenFileDialog](../../../../framework/winforms/controls/openfiledialog-component-windows-forms.md) and the [SaveFileDialog](../../../../framework/winforms/controls/savefiledialog-component-windows-forms.md) components that limit the user choices to valid file names. Using these controls is not foolproof, however. The file system can change between the time the user selects a file and the time that the code executes. Exception handling is therefore nearly always necessary when with working with files.  
  
## .NET Framework Security  
 If you are running in a partial-trust context, the code might throw an exception due to insufficient privileges. For more information, see [Code Access Security Basics](../../../../framework/misc/code-access-security-basics.md).  
  
 This example creates a new file. If an application needs to create a file, that application needs Create permission for the folder. Permissions are set using access control lists. If the file already exists, the application needs only Write permission, a lesser privilege. Where possible, it is more secure to create the file during deployment, and only grant Read privileges to a single file, rather than to grant Create privileges for a folder. Also, it is more secure to write data to user folders than to the root folder or the **Program Files** folder. For more information, see [ACL Technology Overview](http://msdn.microsoft.com/library/06fbf66d-6f02-4378-b863-b2f12e349045).  
  
## See Also  
 <xref:System.IO.Path.Combine%2A?displayProperty=nameWithType>  
 <xref:Microsoft.VisualBasic.Devices.Computer>  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem>  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.WriteAllText%2A>  
 <xref:Microsoft.VisualBasic.FileIO.SpecialDirectories>
