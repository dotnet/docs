---
title: "&#39;Line&#39; statements are no longer supported (Visual Basic Compiler Error)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30830"
  - "vbc30830"
helpviewer_keywords: 
  - "BC30830"
ms.assetid: 4734bc1d-882e-4555-b498-1f1ec0399d16
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;Line&#39; statements are no longer supported (Visual Basic Compiler Error)
Line statements are no longer supported. File I/O functionality is available as `Microsoft.VisualBasic.FileSystem.LineInput` and graphics functionality is available as `System.Drawing.Graphics.DrawLine`.  
  
 **Error ID:** BC30830  
  
## To correct this error  
  
1.  If performing file access, use `Microsoft.VisualBasic.FileSystem.LineInput`.  
  
2.  If performing graphics, use `System.Drawing.Graphics.Drawline`.  
  
## See Also  
 <xref:System.IO>  
 <xref:System.Drawing>  
 [File Access with Visual Basic](../../../visual-basic/developing-apps/programming/drives-directories-files/file-access.md)
