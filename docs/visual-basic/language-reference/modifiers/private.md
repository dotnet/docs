---
title: "Private (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Private"
helpviewer_keywords: 
  - "Private keyword [Visual Basic]"
  - "Private keyword [Visual Basic], syntax"
ms.assetid: aba74a2e-5824-4613-bf63-b9ec7787f4e6
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Private (Visual Basic)
Specifies that one or more declared programming elements are accessible only from within their declaration context, including from within any contained types.  
  
## Remarks  
 If a programming element represents proprietary functionality, or contains confidential data, you usually want to limit access to it as strictly as possible. You achieve the maximum limitation by allowing only the module, class, or structure that defines it to access it. To limit access to an element in this way, you can declare it with `Private`.  
  
## Rules  
  
-   **Declaration Context.** You can use `Private` only at module level. This means the declaration context for a `Private` element must be a module, class, or structure, and cannot be a source file, namespace, interface, or procedure.  
  
## Behavior  
  
-   **Access Level.** All code within a declaration context can access its `Private` elements. This includes code within a contained type, such as a nested class or an assignment expression in an enumeration. No code outside of the declaration context can access its `Private` elements.  
  
-   **Access Modifiers.** The keywords that specify access level are called *access modifiers*. For a comparison of the access modifiers, see [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
 The `Private` modifier can be used in these contexts:  
  
 [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md)  
  
 [Const Statement](../../../visual-basic/language-reference/statements/const-statement.md)  
  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)  
  
 [Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md)  
  
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
  
 [Enum Statement](../../../visual-basic/language-reference/statements/enum-statement.md)  
  
 [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)  
  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
  
 [Interface Statement](../../../visual-basic/language-reference/statements/interface-statement.md)  
  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
 [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)  
  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
  
## See Also  
 [Public](../../../visual-basic/language-reference/modifiers/public.md)  
 [Protected](../../../visual-basic/language-reference/modifiers/protected.md)  
 [Friend](../../../visual-basic/language-reference/modifiers/friend.md)  
 [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md)  
 [Procedures](../../../visual-basic/programming-guide/language-features/procedures/index.md)  
 [Structures](../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)
