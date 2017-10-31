---
title: "Determining Object Type (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "classes [Visual Basic], discovering which an object belongs to"
  - "types [Visual Basic], determining Visual Basic object types"
  - "object variables [Visual Basic], testing values"
  - "TypeOf...Is expression, object type at run time"
  - "TypeName function"
  - "objects [Visual Basic], type determining"
ms.assetid: d95e7ad1-cd63-41d6-9a28-d7a1380d49c1
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Determining Object Type (Visual Basic)
Generic object variables (that is, variables you declare as `Object`) can hold objects from any class. When using variables of type `Object`, you may need to take different actions based on the class of the object; for example, some objects might not support a particular property or method. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides two means of determining which type of object is stored in an object variable: the `TypeName` function and the `TypeOf...Is` operator.  
  
## TypeName and TypeOf…Is  
 The `TypeName` function returns a string and is the best choice when you need to store or display the class name of an object, as shown in the following code fragment:  
  
 [!code-vb[VbVbalrOOP#92](../../../../visual-basic/misc/codesnippet/VisualBasic/determining-object-type_1.vb)]  
  
 The `TypeOf...Is` operator is the best choice for testing an object's type, because it is much faster than an equivalent string comparison using `TypeName`. The following code fragment uses `TypeOf...Is` within an `If...Then...Else` statement:  
  
 [!code-vb[VbVbalrOOP#93](../../../../visual-basic/misc/codesnippet/VisualBasic/determining-object-type_2.vb)]  
  
 A word of caution is due here. The `TypeOf...Is` operator returns `True` if an object is of a specific type, or is derived from a specific type. Almost everything you do with [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] involves objects, which include some elements not normally thought of as objects, such as strings and integers. These objects are derived from and inherit methods from <xref:System.Object>. When passed an `Integer` and evaluated with `Object`, the `TypeOf...Is` operator returns `True`. The following example reports that the parameter `InParam` is both an `Object` and an `Integer`:  
  
 [!code-vb[VbVbalrOOP#94](../../../../visual-basic/misc/codesnippet/VisualBasic/determining-object-type_3.vb)]  
  
 The following example uses both `TypeOf...Is` and `TypeName` to determine the type of object passed to it in the `Ctrl` argument. The `TestObject` procedure calls `ShowType` with three different kinds of controls.  
  
#### To run the example  
  
1.  Create a new Windows Application project and add a <xref:System.Windows.Forms.Button> control, a <xref:System.Windows.Forms.CheckBox> control, and a <xref:System.Windows.Forms.RadioButton> control to the form.  
  
2.  From the button on your form, call the `TestObject` procedure.  
  
3.  Add the following code to your form:  
  
     [!code-vb[VbVbalrOOP#95](../../../../visual-basic/misc/codesnippet/VisualBasic/determining-object-type_4.vb)]  
  
## See Also  
 <xref:Microsoft.VisualBasic.Information.TypeName%2A>  
 [Calling a Property or Method Using a String Name](../../../../visual-basic/programming-guide/language-features/early-late-binding/calling-a-property-or-method-using-a-string-name.md)  
 [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md)  
 [If...Then...Else Statement](../../../../visual-basic/language-reference/statements/if-then-else-statement.md)  
 [String Data Type](../../../../visual-basic/language-reference/data-types/string-data-type.md)  
 [Integer Data Type](../../../../visual-basic/language-reference/data-types/integer-data-type.md)
