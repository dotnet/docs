---
title: "How to: Create a File in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "text files [Visual Basic], creating"
  - "files [Visual Basic], creating"
ms.assetid: 0253bb6d-5519-4a50-b882-b93ef5cca0d9
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Create a File in Visual Basic
This example creates an empty text file at the specified path using the <xref:System.IO.File.Create%2A> method in the <xref:System.IO.File> class.  
  
## Example  
 [!code-vb[VbFileIOMisc#1](../../../../visual-basic/developing-apps/programming/drives-directories-files/codesnippet/VisualBasic/how-to-create-a-file_1.vb)]  
  
## Compiling the Code  
 Use the `file` variable to write to the file.  
  
## Robust Programming  
 If the file already exists, it is replaced.  
  
 The following conditions may cause an exception:  
  
-   The path name is malformed. For example, it contains illegal characters or is only white space (<xref:System.ArgumentException>).  
  
-   The path is read-only (<xref:System.IO.IOException>).  
  
-   The path name is `Nothing` (<xref:System.ArgumentNullException>).  
  
-   The path name is too long (<xref:System.IO.PathTooLongException>).  
  
-   The path is invalid (<xref:System.IO.DirectoryNotFoundException>).  
  
-   The path is only a colon ":" (<xref:System.NotSupportedException>).  
  
## .NET Framework Security  
 A <xref:System.Security.SecurityException> may be thrown in partial-trust environments.  
  
 The call to the <xref:System.IO.File.Create%2A> method requires <xref:System.Security.Permissions.FileIOPermission>.  
  
 An <xref:System.UnauthorizedAccessException> is thrown if the user does not have permission to create the file.  
  
## See Also  
 <xref:System.IO>  
 <xref:System.IO.File.Create%2A>  
 [Using Libraries from Partially Trusted Code](../../../../framework/misc/using-libraries-from-partially-trusted-code.md)  
 [Code Access Security Basics](../../../../framework/misc/code-access-security-basics.md)
