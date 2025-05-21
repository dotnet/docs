---
description: "Learn more about: Other Control Structures (Visual Basic)"
title: "Other Control Structures"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "statements [Visual Basic], control flow"
  - "control structures [Visual Basic]"
ms.assetid: 24b811f7-98ba-40ec-8dd3-4d528cfa4574
ms.topic: article
---
# Other Control Structures (Visual Basic)

Visual Basic provides control structures that help you dispose of a resource or reduce the number of times you have to repeat an object reference.  
  
## Using...End Using Construction  

 The `Using...End Using` construction establishes a statement block within which you make use of a resource such as a SQL connection. You can optionally acquire the resource with the `Using` statement. When you exit the `Using` block, Visual Basic automatically disposes of the resource so that it is available for other code to use. The resource must be local and disposable. For more information, see [Using Statement](../../../language-reference/statements/using-statement.md).  
  
## With...End With Construction  

 The `With...End With` construction lets you specify an object reference once and then run a series of statements that access its members. This can simplify your code and improve performance because Visual Basic does not have to re-establish the reference for each statement that accesses it. For more information, see [With...End With Statement](../../../language-reference/statements/with-end-with-statement.md).  
  
## See also

- [Control Flow](index.md)
- [Decision Structures](decision-structures.md)
- [Loop Structures](loop-structures.md)
- [Nested Control Structures](nested-control-structures.md)
- [Using Statement](../../../language-reference/statements/using-statement.md)
- [With...End With Statement](../../../language-reference/statements/with-end-with-statement.md)
