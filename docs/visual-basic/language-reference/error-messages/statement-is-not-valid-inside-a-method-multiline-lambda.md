---
title: "Statement is not valid inside a method-multiline lambda"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30024"
  - "bc30024"
helpviewer_keywords: 
  - "BC30024"
ms.assetid: 758e7a8f-429b-42c1-9a78-778e5b480e04
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Statement is not valid inside a method/multiline lambda
The statement is not valid within a `Sub`, `Function`, property `Get`, or property `Set` procedure. Some statements can be placed at the module or class level. Others, such as `Option Strict`, must be at namespace level and precede all other declarations.  
  
 **Error ID:** BC30024  
  
## To correct this error  
  
-   Remove the statement from the procedure.  
  
## See Also  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
 [Get Statement](../../../visual-basic/language-reference/statements/get-statement.md)  
 [Set Statement](../../../visual-basic/language-reference/statements/set-statement.md)
