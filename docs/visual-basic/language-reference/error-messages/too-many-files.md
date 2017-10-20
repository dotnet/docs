---
title: "Too many files"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrID67"
ms.assetid: 2ff203e2-bba6-43ae-b72f-8e92a881c98f
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
---
# Too many files
Either more files have been created in the root directory than the operating system permits, or more files have been opened than the number specified in the **files=** setting in your CONFIG.SYS file.  
  
## To correct this error  
  
1.  If your program is opening, closing, or saving files in the root directory, change your program so that it uses a subdirectory.  
  
2.  Increase the number of files specified in your **files=** setting in your CONFIG.SYS file, and restart your computer.  
  
## See Also  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)
