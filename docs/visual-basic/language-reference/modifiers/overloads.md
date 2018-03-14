---
title: "Overloads (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Overloads"
  - "Overloads"
helpviewer_keywords: 
  - "Overloads keyword [Visual Basic]"
  - "hiding by signature"
  - "Shadows keyword [Visual Basic]"
  - "signature, hiding by"
ms.assetid: 0c6820b8-25b2-4664-bc59-5ca93c99c042
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# Overloads (Visual Basic)
Specifies that a property or procedure redeclares one or more existing properties or procedures with the same name.  
  
## Remarks  
 *Overloading* is the practice of supplying more than one definition for a given property or procedure name in the same scope. Redeclaring a property or procedure with a different signature is sometimes called *hiding by signature*.  
  
## Rules  
  
-   **Declaration Context.** You can use `Overloads` only in a property or procedure declaration statement.  
  
-   **Combined Modifiers.** You cannot specify `Overloads` together with [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md) in the same procedure declaration.  
  
-   **Required Differences.** The *signature* in this declaration must be different from the signature of every property or procedure that it overloads. The signature comprises the property or procedure name together with the following:  
  
    -   the number of parameters  
  
    -   the order of the parameters  
  
    -   the data types of the parameters  
  
    -   the number of type parameters (for a generic procedure)  
  
    -   the return type (only for a conversion operator procedure)  
  
     All overloads must have the same name, but each must differ from all the others in one or more of the preceding respects. This allows the compiler to distinguish which version to use when code calls the property or procedure.  
  
-   **Disallowed Differences.** Changing one or more of the following is not valid for overloading a property or procedure, because they are not part of the signature:  
  
    -   whether or not it returns a value (for a procedure)  
  
    -   the data type of the return value (except for a conversion operator)  
  
    -   the names of the parameters or type parameters  
  
    -   the constraints on the type parameters (for a generic procedure)  
  
    -   parameter modifier keywords (such as `ByRef` or `Optional`)  
  
    -   property or procedure modifier keywords (such as `Public` or `Shared`)  
  
-   **Optional Modifier.** You do not have to use the `Overloads` modifier when you are defining multiple overloaded properties or procedures in the same class. However, if you use `Overloads` in one of the declarations, you must use it in all of them.  
  
-   **Shadowing and Overloading.** `Overloads` can also be used to shadow an existing member, or set of overloaded members, in a base class. When you use `Overloads` in this way, you declare the property or method with the same name and the same parameter list as the base class member, and you do not supply the `Shadows` keyword.  
  
 If you use `Overrides`, the compiler implicitly adds `Overloads` so that your library APIs work with C# more easily.  
  
 The `Overloads` modifier can be used in these contexts:  
  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
  
 [Operator Statement](../../../visual-basic/language-reference/statements/operator-statement.md)  
  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
  
## See Also  
 [Shadows](../../../visual-basic/language-reference/modifiers/shadows.md)  
 [Procedure Overloading](../../../visual-basic/programming-guide/language-features/procedures/procedure-overloading.md)  
 [Generic Types in Visual Basic](../../../visual-basic/programming-guide/language-features/data-types/generic-types.md)  
 [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md)  
 [How to: Define a Conversion Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-a-conversion-operator.md)
