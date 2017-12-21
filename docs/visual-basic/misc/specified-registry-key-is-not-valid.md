---
title: "Specified registry key is not valid because it contains two or more consecutive backslashes"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
ms.assetid: 0d78b6f7-5759-45b4-8c37-c6902ada76ff
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Specified registry key is not valid because it contains two or more consecutive backslashes
A registry key specified with a path contains two or more consecutive backslashes. This may be a result of combining several strings to form the path and inadvertently including too many backslashes.  
  
## To correct this error  
  
-   Examine the registry key being specified to determine where and why the extra backslashes are being inserted.  
  
## See Also  
 [How to: Parse File Paths](../../visual-basic/developing-apps/programming/drives-directories-files/how-to-parse-file-paths.md)  
 [My.Computer.Registry](xref:Microsoft.VisualBasic.MyServices.RegistryProxy)
