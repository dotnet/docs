---
title: "Protected (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Protected"
helpviewer_keywords: 
  - "Protected Friend keyword combination"
  - "Protected keyword [Visual Basic], and Friend"
  - "Protected keyword [Visual Basic], syntax"
  - "Protected access modifier"
  - "Protected keyword [Visual Basic]"
ms.assetid: 74ad3d56-309f-49d2-b60c-1d0157d010e8
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Protected (Visual Basic)
Specifies that one or more declared programming elements are accessible only from within their own class or from a derived class.  
  
## Remarks  
 Sometimes a programming element declared in a class contains sensitive data or restricted code, and you want to limit access to the element. However, if the class is inheritable and you expect a hierarchy of derived classes, it might be necessary for these derived classes to access the data or code. In such a case, you want the element to be accessible both from the base class and from all derived classes. To limit access to an element in this manner, you can declare it with `Protected`.  
  
## Rules  
  
-   **Declaration Context.** You can use `Protected` only at class level. This means the declaration context for a `Protected` element must be a class, and cannot be a source file, namespace, interface, module, structure, or procedure.  
  
-   **Combined Modifiers.** You can use the `Protected` modifier together with the [Friend](../../../visual-basic/language-reference/modifiers/friend.md) modifier in the same declaration. This combination makes the declared elements accessible from anywhere in the same assembly, from their own class, and from derived classes. You can specify `Protected Friend` only on members of classes.  
  
## Behavior  
  
-   **Access Level.** All code in a class can access its elements. Code in any class that derives from a base class can access all the `Protected` elements of the base class. This is true for all generations of derivation. This means that a class can access `Protected` elements of the base class of the base class, and so on.  
  
     Protected access is not a superset or subset of friend access.  
  
-   **Access Modifiers.** The keywords that specify access level are called *access modifiers*. For a comparison of the access modifiers, see [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
 The `Protected` modifier can be used in these contexts:  
  
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
 [Friend](../../../visual-basic/language-reference/modifiers/friend.md)  
 [Private](../../../visual-basic/language-reference/modifiers/private.md)  
 [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md)  
 [Procedures](../../../visual-basic/programming-guide/language-features/procedures/index.md)  
 [Structures](../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)
