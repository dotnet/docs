---
title: "How to: Create a File in Visual Basic | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "text files, creating"
  - "files, creating"
ms.assetid: 0253bb6d-5519-4a50-b882-b93ef5cca0d9
caps.latest.revision: 15
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Create a File in Visual Basic
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

This example creates an empty text file at the specified path using the <xref:System.IO.File.Create%2A> method in the <xref:System.IO.File> class.  
  
## Example  
 [!code-vb[VbFileIOMisc#1](../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbFileIOMisc/VB/class2.vb#1)]  
  
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
 [Using Libraries from Partially Trusted Code](../Topic/Using%20Libraries%20from%20Partially%20Trusted%20Code.md)   
 [Code Access Security Basics](../Topic/Code%20Access%20Security%20Basics.md)