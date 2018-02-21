---
title: "How to: Get a Value from a Property (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "property values [Visual Basic]"
  - "Visual Basic code, procedures"
  - "values [Visual Basic], properties"
  - "Visual Basic code, properties"
  - "properties [Visual Basic], values"
ms.assetid: 3954423e-6ab7-4a4c-b55c-a8d27be47891
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Get a Value from a Property (Visual Basic)
You retrieve a property's value by including the property name in an expression.  
  
 The property's `Get` procedure retrieves the value, but you do not explicitly call it by name. You use the property just as you would use a variable. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] makes the calls to the property's procedures.  
  
### To retrieve a value from a property  
  
1.  Use the property name in an expression the same way you would use a variable name. You can use a property anywhere you can use a variable or a constant.  
  
     -or-  
  
     Use the property name following the equal (`=`) sign in an assignment statement.  
  
     The following example reads the value of the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] `Now` property, implicitly calling its `Get` procedure.  
  
     [!code-vb[VbVbalrDateProperties#4](./codesnippet/VisualBasic/how-to-get-a-value-from-a-property_1.vb)]  
  
2.  If the property takes arguments, follow the property name with parentheses to enclose the argument list. If there are no arguments, you can optionally omit the parentheses.  
  
3.  Place the arguments in the argument list within the parentheses, separated by commas. Be sure you supply the arguments in the same order that the property defines the corresponding parameters.  
  
 The value of the property participates in the expression just as a variable or constant would, or it is stored in the variable or property on the left side of the assignment statement.  
  
## See Also  
 [Procedures](./index.md)  
 [Property Procedures](./property-procedures.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Property Statement](../../../../visual-basic/language-reference/statements/property-statement.md)  
 [Differences Between Properties and Variables in Visual Basic](./differences-between-properties-and-variables.md)  
 [How to: Create a Property](./how-to-create-a-property.md)  
 [How to: Declare a Property with Mixed Access Levels](./how-to-declare-a-property-with-mixed-access-levels.md)  
 [How to: Call a Property Procedure](./how-to-call-a-property-procedure.md)  
 [How to: Declare and Call a Default Property in Visual Basic](./how-to-declare-and-call-a-default-property.md)  
 [How to: Put a Value in a Property](./how-to-put-a-value-in-a-property.md)
