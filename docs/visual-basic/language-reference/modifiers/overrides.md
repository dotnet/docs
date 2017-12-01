---
title: "Overrides (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "Overrides"
  - "vb.Overrides"
helpviewer_keywords: 
  - "properties [Visual Basic], redefining"
  - "procedures [Visual Basic], overriding"
  - "procedures [Visual Basic], redefining"
  - "overriding"
  - "Overrides keyword [Visual Basic]"
  - "overriding, Overrides keyword"
  - "properties [Visual Basic], overriding"
ms.assetid: 9f5e6144-ce10-465e-842b-1a8f8760af90
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Overrides (Visual Basic)
Specifies that a property or procedure overrides an identically named property or procedure inherited from a base class.  
  
## Remarks  
  
## Rules  
  
-   **Declaration Context.** You can use `Overrides` only in a property or procedure declaration statement.  
  
-   **Combined Modifiers.** You cannot specify `Overrides` together with `Shadows` or `Shared` in the same declaration. Because an overriding element is implicitly overridable, you cannot combine `Overridable` with `Overrides`.  
  
-   **Matching Signatures.** The signature of this declaration must exactly match the *signature* of the property or procedure that it overrides. This means the parameter lists must have the same number of parameters, in the same order, with the same data types.  
  
     In addition to the signature, the overriding declaration must also exactly match the following:  
  
    -   The access level  
  
    -   The return type, if any  
  
-   **Generic Signatures.** For a generic procedure, the signature includes the number of type parameters. Therefore, the overriding declaration must match the base class version in that respect as well.  
  
-   **Additional Matching.** In addition to matching the signature of the base class version, this declaration must also match it in the following respects:  
  
    -   Access-level modifier (such as [Public](../../../visual-basic/language-reference/modifiers/public.md))  
  
    -   Passing mechanism of each parameter ([ByVal](../../../visual-basic/language-reference/modifiers/byval.md) or [ByRef](../../../visual-basic/language-reference/modifiers/byref.md))  
  
    -   Constraint lists on each type parameter of a generic procedure  
  
-   **Shadowing and Overriding.** Both shadowing and overriding redefine an inherited element, but there are significant differences between the two approaches. For more information, see [Shadowing in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/shadowing.md).  
  
 If you use `Overrides`, the compiler implicitly adds `Overloads` so that your library APIs work with C# more easily.  
  
 The `Overrides` modifier can be used in these contexts:  
  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
  
## See Also  
 [MustOverride](../../../visual-basic/language-reference/modifiers/mustoverride.md)  
 [NotOverridable](../../../visual-basic/language-reference/modifiers/notoverridable.md)  
 [Overridable](../../../visual-basic/language-reference/modifiers/overridable.md)  
 [Keywords](../../../visual-basic/language-reference/keywords/index.md)  
 [Shadowing in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/shadowing.md)  
 [Generic Types in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)  
 [Type List](../../../visual-basic/language-reference/statements/type-list.md)
