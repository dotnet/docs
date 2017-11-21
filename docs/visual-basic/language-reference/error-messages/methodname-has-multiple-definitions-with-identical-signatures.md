---
title: "&#39;&lt;methodname&gt;&#39; has multiple definitions with identical signatures"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30269"
  - "bc30269"
helpviewer_keywords: 
  - "BC30269"
ms.assetid: 39489621-6617-4e5c-9b24-c2faf8273891
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;&lt;methodname&gt;&#39; has multiple definitions with identical signatures
A `Function` or `Sub` procedure declaration uses the identical procedure name and argument list as a previous declaration. One possible cause is an attempt to overload the original procedure. Overloaded procedures must have different argument lists.  
  
 **Error ID:** BC30269  
  
## To correct this error  
  
-   Change the procedure name or the argument list, or remove the duplicate declaration.  
  
## See Also  
 [References to Declared Elements](../../../visual-basic/programming-guide/language-features/declared-elements/references-to-declared-elements.md)  
 [Considerations in Overloading Procedures](../../../visual-basic/programming-guide/language-features/procedures/considerations-in-overloading-procedures.md)
