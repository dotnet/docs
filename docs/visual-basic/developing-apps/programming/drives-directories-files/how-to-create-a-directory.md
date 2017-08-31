---
title: "How to: Create a Directory in Visual Basic | Microsoft Docs"
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
  - "directories [Visual Basic], creating"
  - "folders [Visual Basic], creating"
ms.assetid: 0351a2ca-24d8-43b5-bb39-9b99e6401cff
caps.latest.revision: 19
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Create a Directory in Visual Basic
[!INCLUDE[vs2017banner](../../../../includes/vs2017banner.md)]

Use the `CreateDirectory` method of the `My.Computer.FileSystem` object to create directories.  
  
 If the directory already exists, no exception is thrown.  
  
### To create a directory  
  
-   Use the `CreateDirectory` method by specifying the full path of the location where the directory should be created. This example creates the directory `NewDirectory` in `C:\Documents and Settings\All Users\Documents`.  
  
     [!code-vb[VbVbcnMyFileSystem#2](../../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnMyFileSystem/VB/Class1.vb#2)]  
  
## Robust Programming  
 The following conditions may cause an exception:  
  
-   The directory name is malformed. For example, it contains illegal characters or is only white space (<xref:System.ArgumentException>).  
  
-   The parent directory of the directory to be created is read-only (<xref:System.IO.IOException>).  
  
-   The directory name is `Nothing` (<xref:System.ArgumentNullException>).  
  
-   The directory name is too long (<xref:System.IO.PathTooLongException>).  
  
-   The directory name is a colon ":" (<xref:System.NotSupportedException>).  
  
-   The user does not have permission to create the directory (<xref:System.UnauthorizedAccessException>).  
  
-   The user lacks permissions in a partial-trust situation (<xref:System.Security.SecurityException>).  
  
## See Also  
 <xref:Microsoft.VisualBasic.FileIO.FileSystem.CreateDirectory%2A>   
 [Creating, Deleting, and Moving Files and Directories](../../../../visual-basic/developing-apps/programming/drives-directories-files/creating-deleting-and-moving-files-and-directories.md)