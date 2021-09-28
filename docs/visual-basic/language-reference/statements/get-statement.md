---
description: "Learn more about: Get Statement"
title: "Get Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Get"
helpviewer_keywords: 
  - "Get statement [Visual Basic], syntax"
  - "Get statement [Visual Basic]"
  - "properties [Visual Basic], read-only"
  - "read-only properties"
  - "Get keyword [Visual Basic]"
  - "property procedures [Visual Basic], Get statements"
ms.assetid: 56b05cdc-bd64-4dfd-bb12-824eacec6f94
---
# Get Statement

Declares a `Get` property procedure used to retrieve the value of a property.  
  
## Syntax  
  
```vb  
[ <attributelist> ] [ accessmodifier ] Get()  
    [ statements ]  
End Get  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`attributelist`|Optional. See [Attribute List](attribute-list.md).|  
|`accessmodifier`|Optional on at most one of the `Get` and `Set` statements in this property. Can be one of the following:<br /><br /> -   [Protected](../modifiers/protected.md)<br />-   [Friend](../modifiers/friend.md)<br />-   [Private](../modifiers/private.md)<br />-   `Protected Friend`<br /><br /> See [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).|  
|`statements`|Optional. One or more statements that run when the `Get` property procedure is called.|  
|`End Get`|Required. Terminates the definition of the `Get` property procedure.|  
  
## Remarks  

 Every property must have a `Get` property procedure unless the property is marked `WriteOnly`. The `Get` procedure is used to return the current value of the property.  
  
 Visual Basic automatically calls a property's `Get` procedure when an expression requests the property's value.  
  
 The body of the property declaration can contain only the property's `Get` and `Set` procedures between the [Property Statement](property-statement.md) and the `End Property` statement. It cannot store anything other than those procedures. In particular, it cannot store the property's current value. You must store this value outside the property, because if you store it inside either of the property procedures, the other property procedure cannot access it. The usual approach is to store the value in a [Private](../modifiers/private.md) variable declared at the same level as the property. You must define a `Get` procedure inside the property to which it applies.  
  
 The `Get` procedure defaults to the access level of its containing property unless you use `accessmodifier` in the `Get` statement.  
  
## Rules  
  
- **Mixed Access Levels.** If you are defining a read-write property, you can optionally specify a different access level for either the `Get` or the `Set` procedure, but not both. If you do this, the procedure access level must be more restrictive than the property's access level. For example, if the property is declared `Friend`, you can declare the `Get` procedure `Private`, but not `Public`.  
  
     If you are defining a `ReadOnly` property, the `Get` procedure represents the entire property. You cannot declare a different access level for `Get`, because that would set two access levels for the property.  
  
- **Return Type.** The [Property Statement](property-statement.md) can declare the data type of the value it returns. The `Get` procedure automatically returns that data type. You can specify any data type or the name of an enumeration, structure, class, or interface.  
  
     If the `Property` statement does not specify `returntype`, the procedure returns `Object`.  
  
## Behavior  
  
- **Returning from a Procedure.** When the `Get` procedure returns to the calling code, execution continues within the statement that requested the property value.  
  
     `Get` property procedures can return a value using either the [Return Statement](return-statement.md) or by assigning the return value to the property name. For more information, see "Return Value" in [Function Statement](function-statement.md).  
  
     The `Exit Property` and `Return` statements cause an immediate exit from a property procedure. Any number of `Exit Property` and `Return` statements can appear anywhere in the procedure, and you can mix `Exit Property` and `Return` statements.  
  
- **Return Value.** To return a value from a `Get` procedure, you can either assign the value to the property name or include it in a [Return Statement](return-statement.md). The `Return` statement simultaneously assigns the `Get` procedure return value and exits the procedure.  
  
     If you use `Exit Property` without assigning a value to the property name, the `Get` procedure returns the default value for the property's data type. For more information, see "Return Value" in [Function Statement](function-statement.md).  
  
     The following example illustrates two ways the read-only property `quoteForTheDay` can return the value held in the private variable `quoteValue`.  
  
     [!code-vb[VbVbalrStatements#27](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#27)]  
  
     [!code-vb[VbVbalrStatements#28](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#28)]  
  
     [!code-vb[VbVbalrStatements#29](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#29)]  
  
## Example  

 The following example uses the `Get` statement to return the value of a property.  
  
 [!code-vb[VbVbalrStatements#30](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#30)]  
  
## See also

- [Set Statement](set-statement.md)
- [Property Statement](property-statement.md)
- [Exit Statement](exit-statement.md)
- [Objects and Classes](../../programming-guide/language-features/objects-and-classes/index.md)
- [Walkthrough: Defining Classes](../../programming-guide/language-features/objects-and-classes/walkthrough-defining-classes.md)
