---
title: "&#39;Module&#39; statements can occur only at file or namespace level"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30617"
  - "vbc30617"
helpviewer_keywords: 
  - "BC30617"
ms.assetid: 5e9de8e5-d26b-4fb2-9e28-814413fe9cef
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;Module&#39; statements can occur only at file or namespace level
`Module` statements must appear at the top of your source file immediately after `Option` and `Imports` statements, global attributes, and namespace declarations, but before all other declarations.  
  
 **Error ID:** BC30617  
  
## To correct this error  
  
-   Move the `Module` statement to the top of your namespace declaration or source file.  
  
## See Also  
 [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md)
