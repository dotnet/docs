---
title: "Set Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Set"
helpviewer_keywords: 
  - "property procedures [Visual Basic], Set statements"
  - "Set statement [Visual Basic]"
  - "Set statement [Visual Basic], syntax"
  - "write-only properties"
  - "properties [Visual Basic], write-only"
ms.assetid: 9ecc27b4-df84-420d-9075-db25455fb3cd
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# Set Statement (Visual Basic)
Declares a `Set` property procedure used to assign a value to a property.  
  
## Syntax  
  
```  
[ <attributelist> ] [ accessmodifier ] Set (ByVal value [ As datatype ])  
    [ statements ]  
End Set  
```  
  
## Parts  
 `attributelist`  
 Optional. See [Attribute List](../../../visual-basic/language-reference/statements/attribute-list.md).  
  
 `accessmodifier`  
 Optional on at most one of the `Get` and `Set` statements in this property. Can be one of the following:  
  
-   [Protected](../../../visual-basic/language-reference/modifiers/protected.md)  
  
-   [Friend](../../../visual-basic/language-reference/modifiers/friend.md)  
  
-   [Private](../../../visual-basic/language-reference/modifiers/private.md)  
  
-   `Protected Friend`  
  
 See [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
 `value`  
 Required. Parameter containing the new value for the property.  
  
 `datatype`  
 Required if `Option Strict` is `On`. Data type of the `value` parameter. The data type specified must be the same as the data type of the property where this `Set` statement is declared.  
  
 `statements`  
 Optional. One or more statements that run when the `Set` property procedure is called.  
  
 `End Set`  
 Required. Terminates the definition of the `Set` property procedure.  
  
## Remarks  
 Every property must have a `Set` property procedure unless the property is marked `ReadOnly`. The `Set` procedure is used to set the value of the property.  
  
 Visual Basic automatically calls a property's `Set` procedure when an assignment statement provides a value to be stored in the property.  
  
 Visual Basic passes a parameter to the `Set` procedure during property assignments. If you do not supply a parameter for `Set`, the integrated development environment (IDE) uses an implicit parameter named `value`. The parameter holds the value to be assigned to the property. You typically store this value in a private local variable and return it whenever the `Get` procedure is called.  
  
 The body of the property declaration can contain only the property's `Get` and `Set` procedures between the [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md) and the `End Property` statement. It cannot store anything other than those procedures. In particular, it cannot store the property's current value. You must store this value outside the property, because if you store it inside either of the property procedures, the other property procedure cannot access it. The usual approach is to store the value in a [Private](../../../visual-basic/language-reference/modifiers/private.md) variable declared at the same level as the property. You must define a `Set` procedure inside the property to which it applies.  
  
 The `Set` procedure defaults to the access level of its containing property unless you use `accessmodifier` in the `Set` statement.  
  
## Rules  
  
-   **Mixed Access Levels.** If you are defining a read-write property, you can optionally specify a different access level for either the `Get` or the `Set` procedure, but not both. If you do this, the procedure access level must be more restrictive than the property's access level. For example, if the property is declared `Friend`, you can declare the `Set` procedure `Private`, but not `Public`.  
  
     If you are defining a `WriteOnly` property, the `Set` procedure represents the entire property. You cannot declare a different access level for `Set`, because that would set two access levels for the property.  
  
## Behavior  
  
-   **Returning from a Property Procedure.** When the `Set` procedure returns to the calling code, execution continues following the statement that provided the value to be stored.  
  
     `Set` property procedures can return using either the [Return Statement](../../../visual-basic/language-reference/statements/return-statement.md) or the [Exit Statement](../../../visual-basic/language-reference/statements/exit-statement.md).  
  
     The `Exit Property` and `Return` statements cause an immediate exit from a property procedure. Any number of `Exit Property` and `Return` statements can appear anywhere in the procedure, and you can mix `Exit Property` and `Return` statements.  
  
## Example  
 The following example uses the `Set` statement to set the value of a property.  
  
 [!code-vb[VbVbalrStatements#55](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/set-statement_1.vb)]  
  
## See Also  
 [Get Statement](../../../visual-basic/language-reference/statements/get-statement.md)  
 [Property Statement](../../../visual-basic/language-reference/statements/property-statement.md)  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
 [Property Procedures](../../../visual-basic/programming-guide/language-features/procedures/property-procedures.md)
