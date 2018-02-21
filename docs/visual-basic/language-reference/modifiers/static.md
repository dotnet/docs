---
title: "Static (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Static"
helpviewer_keywords: 
  - "static modifier"
  - "Static keyword [Visual Basic]"
ms.assetid: 19013910-4658-47b6-a22e-1744b527979e
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# Static (Visual Basic)
Specifies that one or more declared local variables are to continue to exist and retain their latest values after termination of the procedure in which they are declared.  
  
## Remarks  
 Normally, a local variable in a procedure ceases to exist as soon as the procedure stops. A static variable continues to exist and retains its most recent value. The next time your code calls the procedure, the variable is not reinitialized, and it still holds the latest value that you assigned to it. A static variable continues to exist for the lifetime of the class or module that it is defined in.  
  
## Rules  
  
-   **Declaration Context.** You can use `Static` only on local variables. This means the declaration context for a `Static` variable must be a procedure or a block in a procedure, and it cannot be a source file, namespace, class, structure, or module.  
  
     You cannot use `Static` inside a structure procedure.  
  
-   The data types of `Static` local variables cannot be inferred. For more information, see [Local Type Inference](../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md).  
  
-   **Combined Modifiers.** You cannot specify `Static` together with `ReadOnly`, `Shadows`, or `Shared` in the same declaration.  
  
## Behavior  
 When you declare a static variable in a `Shared` procedure, only one copy of the static variable is available for the whole application. You call a `Shared` procedure by using the class name, not a variable that points to an instance of the class.  
  
 When you declare a static variable in a procedure that isn't `Shared`, only one copy of the variable is available for each instance of the class. You call a non-shared procedure by using a variable that points to a specific instance of the class.  
  
## Example  
 The following example demonstrates the use of `Static`.  
  
 [!code-vb[VbVbalrKeywords#5](../../../visual-basic/language-reference/codesnippet/VisualBasic/static_1.vb)]  
  
 The `Static` variable `totalSales` is initialized to 0 only one time. Each time that you enter `updateSales`, `totalSales` still has the most recent value that you calculated for it.  
  
 The `Static` modifier can be used in this context:  
  
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
  
## See Also  
 [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md)  
 [Shared](../../../visual-basic/language-reference/modifiers/shared.md)  
 [Lifetime in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/lifetime.md)  
 [Variable Declaration](../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)  
 [Structures](../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Local Type Inference](../../../visual-basic/programming-guide/language-features/variables/local-type-inference.md)  
 [Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)
