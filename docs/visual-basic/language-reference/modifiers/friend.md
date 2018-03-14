---
title: "Friend (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Friend"
helpviewer_keywords: 
  - "Friend keyword [Visual Basic]"
  - "Friend access modifier"
  - "Friend keyword [Visual Basic], syntax"
  - "Protected Friend keyword combination"
  - "Friend keyword [Visual Basic], and Protected"
ms.assetid: b664605e-1c79-4728-b996-aa59c50846bc
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
---
# Friend (Visual Basic)
Specifies that one or more declared programming elements are accessible only from within the assembly that contains their declaration.  
  
## Remarks  
 In many cases, you want programming elements such as classes and structures to be used by the entire assembly, not only by the component that declares them. However, you might not want them to be accessible by code outside the assembly (for example, if the application is proprietary). If you want to limit access to an element in this way, you can declare it by using the `Friend` modifier.  
  
 Code in other classes, structures, and modules that are compiled to the same assembly can access all the `Friend` elements in that assembly.  
  
 `Friend` access is often the preferred level for an application's programming elements, and `Friend` is the default access level of an interface, a module, a class, or a structure.  
  
 You can use `Friend` only at the module, interface, or namespace level. Therefore, the declaration context for a `Friend` element must be a source file, a namespace, an interface, a module, a class, or a structure; it can't be a procedure.  
  
 You can use the `Friend` modifier in conjunction with the [Protected](../../../visual-basic/language-reference/modifiers/protected.md) modifier in the same declaration. This combination confers both `Friend` access and protected access on the declared elements, so they are accessible from anywhere in the same assembly, from their own class, and from derived classes. You can specify `Protected Friend` only on members of classes.  
  
 For a comparison of `Friend` and the other access modifiers, see [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
> [!NOTE]
>  You can specify that another assembly is a friend assembly, which allows it to access all types and members that are marked as `Friend`. For more information, see [Friend Assemblies](../../programming-guide/concepts/assemblies-gac/friend-assemblies.md).  
  
## Example  
 The following class uses the `Friend` modifier to allow other programming elements within the same assembly to access certain members.  
  
 [!code-vb[VbVbalrAccessModifiers#1](../../../visual-basic/language-reference/modifiers/codesnippet/VisualBasic/friend_1.vb)]  
  
## Usage  
 You can use the `Friend` modifier in these contexts:  
  
 [Class Statement](../../../visual-basic/language-reference/statements/class-statement.md)  
  
 [Const Statement](../../../visual-basic/language-reference/statements/const-statement.md)  
  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)  
  
 [Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md)  
  
 [Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md)  
  
 [Enum Statement](../../../visual-basic/language-reference/statements/enum-statement.md)  
  
 [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)  
  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
  
 [Interface Statement](../../../visual-basic/language-reference/statements/interface-statement.md)  
  
 [Module Statement](../../../visual-basic/language-reference/statements/module-statement.md)  
  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
 [Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md)  
  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
  
## See Also  
 <xref:System.Runtime.CompilerServices.InternalsVisibleToAttribute>  
 [Public](../../../visual-basic/language-reference/modifiers/public.md)  
 [Protected](../../../visual-basic/language-reference/modifiers/protected.md)  
 [Private](../../../visual-basic/language-reference/modifiers/private.md)  
 [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md)  
 [Procedures](../../../visual-basic/programming-guide/language-features/procedures/index.md)  
 [Structures](../../../visual-basic/programming-guide/language-features/data-types/structures.md)  
 [Objects and Classes](../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)
