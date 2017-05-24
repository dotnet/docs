---
title: "&#39;Sub New&#39; cannot handle events | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbc30497"
  - "bc30497"
helpviewer_keywords: 
  - "BC30497"
ms.assetid: b8a546c4-914e-49de-b553-9fc0f41424ed
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent

translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# &#39;Sub New&#39; cannot handle events
You attempted to combine `Sub New` with `Handles`, which is invalid. Use the `Handles` keyword at the end of a procedure declaration to cause it to handle events raised by an object variable declared using the `WithEvents` keyword.  
  
 **Error ID:** BC30497  
  
## To correct this error  
  
1.  Do not use `New` in this context.  
  
## See Also  
 [Handles](../../visual-basic/language-reference/statements/handles-clause.md)   
 [Dim Statement](../../visual-basic/language-reference/statements/dim-statement.md)   
 [WithEvents](../../visual-basic/language-reference/modifiers/withevents.md)