---
title: "WithEvents (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.WithEvents"
  - "WithEvents"
helpviewer_keywords: 
  - "WithEvents keyword [Visual Basic]"
ms.assetid: 19d461f5-d72f-4de9-8c1d-0a6650316990
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# WithEvents (Visual Basic)
Specifies that one or more declared member variables refer to an instance of a class that can raise events.  
  
## Remarks  
 When a variable is defined using `WithEvents`, you can declaratively specify that a method handles the variable's events using the `Handles` keyword.  
  
 You can use `WithEvents` only at class or module level. This means the declaration context for a `WithEvents` variable must be a class or module and cannot be a source file, namespace, structure, or procedure.  
  
 You cannot use `WithEvents` on a structure member.  
  
 You can declare only individual variables—not arrays—with `WithEvents`.  
  
## Rules  
  
-   **Element Types.** You must declare `WithEvents` variables to be object variables so that they can accept class instances. However, you cannot declare them as `Object`. You must declare them as the specific class that can raise the events.  
  
 The `WithEvents` modifier can be used in this context: [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
  
## See Also  
 [Handles](../../../visual-basic/language-reference/statements/handles-clause.md)  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)  
 [Events](../../../visual-basic/programming-guide/language-features/events/index.md)
