---
title: "Object Variable Values (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "object variables [Visual Basic], values"
  - "values [Visual Basic], of object variables"
  - "data types [Visual Basic], object variable"
  - "variables [Visual Basic], object"
ms.assetid: 31555704-58a3-49f1-9a0a-6421f605664f
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Object Variable Values (Visual Basic)
A variable of the [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md) can refer to data of any type. The value you store in an `Object` variable is kept elsewhere in memory, while the variable itself holds a pointer to the data.  
  
## Object Classifier Functions  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] supplies functions that return information about what an `Object` variable refers to, as shown in the following table.  
  
|Function|Returns True if the Object variable refers to|  
|--------------|---------------------------------------------------|  
|<xref:Microsoft.VisualBasic.Information.IsArray%2A>|An array of values, rather than a single value|  
|<xref:Microsoft.VisualBasic.Information.IsDate%2A>|A [Date Data Type](../../../../visual-basic/language-reference/data-types/date-data-type.md) value, or a string that can be interpreted as a date and time value|  
|<xref:Microsoft.VisualBasic.Information.IsDBNull%2A>|An object of type <xref:System.DBNull>, which represents missing or nonexistent data|  
|<xref:Microsoft.VisualBasic.Information.IsError%2A>|An exception object, which derives from <xref:System.Exception>|  
|<xref:Microsoft.VisualBasic.Information.IsNothing%2A>|[Nothing](../../../../visual-basic/language-reference/nothing.md), that is, no object is currently assigned to the variable|  
|<xref:Microsoft.VisualBasic.Information.IsNumeric%2A>|A number, or a string that can be interpreted as a number|  
|<xref:Microsoft.VisualBasic.Information.IsReference%2A>|A reference type (such as a string, array, delegate, or class type)|  
  
 You can use these functions to avoid submitting an invalid value to an operation or a procedure.  
  
## TypeOf Operator  
 You can also use the [TypeOf Operator](../../../../visual-basic/language-reference/operators/typeof-operator.md) to determine whether an object variable currently refers to a specific data type. The `TypeOf`...`Is` expression evaluates to `True` if the run-time type of the operand is derived from or implements the specified type.  
  
 The following example uses `TypeOf` on object variables referring to value and reference types.  
  
```  
' The following statement puts a value type (Integer) in an Object variable.  
Dim num As Object = 10  
' The following statement puts a reference type (Form) in an Object variable.  
Dim frm As Object = New Form()  
If TypeOf num Is Long Then Debug.WriteLine("num is Long")  
If TypeOf num Is Integer Then Debug.WriteLine("num is Integer")  
If TypeOf num Is Short Then Debug.WriteLine("num is Short")  
If TypeOf num Is Object Then Debug.WriteLine("num is Object")  
If TypeOf frm Is Form Then Debug.WriteLine("frm is Form")  
If TypeOf frm Is Label Then Debug.WriteLine("frm is Label")  
If TypeOf frm Is Object Then Debug.WriteLine("frm is Object")  
```  
  
 The preceding example writes the following lines to the **Debug** window:  
  
 `num is Integer`  
  
 `num is Object`  
  
 `frm is Form`  
  
 `frm is Object`  
  
 The object variable `num` refers to data of type `Integer`, and `frm` refers to an object of class <xref:System.Windows.Forms.Form>.  
  
## Object Arrays  
 You can declare and use an array of `Object` variables. This is useful when you need to handle a variety of data types and object classes. All the elements in an array must have the same declared data type. Declaring this data type as `Object` allows you to store objects and class instances alongside other data types in the array.  
  
## See Also  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)  
 [Object Variable Declaration](../../../../visual-basic/programming-guide/language-features/variables/object-variable-declaration.md)  
 [Object Variable Assignment](../../../../visual-basic/programming-guide/language-features/variables/object-variable-assignment.md)  
 [How to: Refer to the Current Instance of an Object](../../../../visual-basic/programming-guide/language-features/variables/how-to-refer-to-the-current-instance-of-an-object.md)  
 [How to: Determine What Type an Object Variable Refers To](../../../../visual-basic/programming-guide/language-features/variables/how-to-determine-what-type-an-object-variable-refers-to.md)  
 [How to: Determine Whether Two Objects Are Related](../../../../visual-basic/programming-guide/language-features/variables/how-to-determine-whether-two-objects-are-related.md)  
 [How to: Determine Whether Two Objects Are Identical](../../../../visual-basic/programming-guide/language-features/variables/how-to-determine-whether-two-objects-are-identical.md)  
 [Data Types](../../../../visual-basic/programming-guide/language-features/data-types/index.md)
