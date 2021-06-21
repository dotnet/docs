---
description: "Learn more about: How to: Create a File in Visual Basic"
title: "How to: Create a File"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "text files [Visual Basic], creating"
  - "files [Visual Basic], creating"
ms.assetid: 0253bb6d-5519-4a50-b882-b93ef5cca0d9
---
# How to: Create a File in Visual Basic

This example creates an empty text file at the specified path using the <xref:System.IO.File.Create%2A> method in the <xref:System.IO.File> class.  
  
## Example  

 [!code-vb[VbFileIOMisc#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIOMisc/VB/class2.vb#1)]  
  
## Compiling the Code  

 Use the `file` variable to write to the file.  
  
## Robust Programming  

 If the file already exists, it is replaced.  
  
 The following conditions may cause an exception:  
  
- The path name is malformed. For example, it contains illegal characters or is only white space (<xref:System.ArgumentException>).  
  
- The path is read-only (<xref:System.IO.IOException>).  
  
- The path name is `Nothing` (<xref:System.ArgumentNullException>).  
  
- The path name is too long (<xref:System.IO.PathTooLongException>).  
  
- The path is invalid (<xref:System.IO.DirectoryNotFoundException>).  
  
- The path is only a colon ":" (<xref:System.NotSupportedException>).  
  
## .NET Framework Security  

 A <xref:System.Security.SecurityException> may be thrown in partial-trust environments.  
  
 The call to the <xref:System.IO.File.Create%2A> method requires <xref:System.Security.Permissions.FileIOPermission>.  
  
 An <xref:System.UnauthorizedAccessException> is thrown if the user does not have permission to create the file.  
  
## See also

- <xref:System.IO>
- <xref:System.IO.File.Create%2A>
- [Using Libraries from Partially Trusted Code](/previous-versions/dotnet/framework/code-access-security/using-libraries-from-partially-trusted-code)
- [Code Access Security Basics](/previous-versions/dotnet/framework/code-access-security/code-access-security-basics)
