---
title: "Handles clause requires a WithEvents variable defined in the containing type or one of its base types"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc30506"
  - "bc30506"
helpviewer_keywords: 
  - "BC30506"
ms.assetid: 5b66f6a8-f050-4e03-a57f-a64e85f80cb5
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# Handles clause requires a WithEvents variable defined in the containing type or one of its base types
You did not supply a `WithEvents` variable in your `Handles` clause. The `Handles` keyword at the end of a procedure declaration causes it to handle events raised by an object variable declared using the `WithEvents` keyword.  
  
 **Error ID:** BC30506  
  
## To correct this error  
  
-   Supply the necessary `WithEvents` variable.  
  
## See Also  
 [Handles](../../../visual-basic/language-reference/statements/handles-clause.md)
