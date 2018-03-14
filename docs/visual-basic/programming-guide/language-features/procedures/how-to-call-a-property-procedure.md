---
title: "How to: Call a Property Procedure (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Visual Basic code, procedures"
  - "Visual Basic code, properties"
  - "procedures [Visual Basic], calling"
  - "properties [Visual Basic], property procedures"
  - "procedure calls [Visual Basic], property procedures"
ms.assetid: 96bc4d74-d9c3-4b7a-954d-58ac8553cd94
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Call a Property Procedure (Visual Basic)
You call a property procedure by storing a value in the property or retrieving its value. You access a property the same way you access a variable.  
  
 The property's `Set` procedure stores a value, and its `Get` procedure retrieves the value. However, you do not explicitly call these procedures by name. You use the property in an assignment statement or an expression, just as you would store or retrieve the value of a variable. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] makes the calls to the property's procedures.  
  
### To call a property's Get procedure  
  
1.  Use the property name in an expression the same way you would use a variable name. You can use a property anywhere you can use a variable or a constant.  
  
     -or-  
  
     Use the property name following the equal (`=`) sign in an assignment statement.  
  
     The following example reads the value of the <xref:Microsoft.VisualBasic.DateAndTime.Now%2A> property, implicitly calling its `Get` procedure.  
  
     [!code-vb[VbVbalrDateProperties#4](./codesnippet/VisualBasic/how-to-call-a-property-procedure_1.vb)]  
  
2.  If the property takes arguments, follow the property name with parentheses to enclose the argument list. If there are no arguments, you can optionally omit the parentheses.  
  
3.  Place the arguments in the argument list within the parentheses, separated by commas. Be sure you supply the arguments in the same order that the property defines the corresponding parameters.  
  
 The value of the property participates in the expression just as a variable or constant would, or it is stored in the variable or property on the left side of the assignment statement.  
  
### To call a property's Set procedure  
  
1.  Use the property name on the left side of an assignment statement.  
  
     The following example sets the value of the <xref:Microsoft.VisualBasic.DateAndTime.TimeOfDay%2A> property, implicitly calling the `Set` procedure.  
  
     [!code-vb[VbVbcnProcedures#11](./codesnippet/VisualBasic/how-to-call-a-property-procedure_2.vb)]  
  
2.  If the property takes arguments, follow the property name with parentheses to enclose the argument list. If there are no arguments, you can optionally omit the parentheses.  
  
3.  Place the arguments in the argument list within the parentheses, separated by commas. Be sure you supply the arguments in the same order that the property defines the corresponding parameters.  
  
 The value generated on the right side of the assignment statement is stored in the property.  
  
## See Also  
 [Property Procedures](./property-procedures.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Property Statement](../../../../visual-basic/language-reference/statements/property-statement.md)  
 [Differences Between Properties and Variables in Visual Basic](./differences-between-properties-and-variables.md)  
 [How to: Create a Property](./how-to-create-a-property.md)  
 [How to: Declare a Property with Mixed Access Levels](./how-to-declare-a-property-with-mixed-access-levels.md)  
 [How to: Declare and Call a Default Property in Visual Basic](./how-to-declare-and-call-a-default-property.md)  
 [How to: Put a Value in a Property](./how-to-put-a-value-in-a-property.md)  
 [How to: Get a Value from a Property](./how-to-get-a-value-from-a-property.md)  
 [Get Statement](../../../../visual-basic/language-reference/statements/get-statement.md)  
 [Set Statement](../../../../visual-basic/language-reference/statements/set-statement.md)
