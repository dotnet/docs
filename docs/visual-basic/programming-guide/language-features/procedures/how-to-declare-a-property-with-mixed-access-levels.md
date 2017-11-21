---
title: "How to: Declare a Property with Mixed Access Levels (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "access levels [Visual Basic], properties"
  - "procedures [Visual Basic], defining"
  - "Visual Basic code, procedures"
  - "mixed access levels"
  - "Visual Basic code, properties"
  - "properties [Visual Basic], access levels"
  - "Property statement [Visual Basic], declaring mixed access levels"
ms.assetid: fdbb2d97-279a-4956-b26c-cbdfbc34915a
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Declare a Property with Mixed Access Levels (Visual Basic)
If you want the `Get` and `Set` procedures on a property to have different access levels, you can use the more permissive level in the `Property` statement and the more restrictive level in either the `Get` or `Set` statement. You use mixed access levels on a property when you want certain parts of the code to be able to get the property's value, and certain other parts of the code to be able to change the value.  
  
 For more information on access levels, see [Access levels in Visual Basic](../../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
### To declare a property with mixed access levels  
  
1.  Declare the property in the normal way, and specify the less restrictive access level (such as `Public`) in the `Property` statement.  
  
2.  Declare either the `Get` or the `Set` procedure specifying the more restrictive access level (such as `Friend`).  
  
3.  Do not specify an access level on the other property procedure. It assumes the access level declared in the `Property` statement. You can restrict access on only one of the property procedures.  
  
     [!code-vb[VbVbcnProcedures#10](./codesnippet/VisualBasic/how-to-declare-a-property-with-mixed-access-levels_1.vb)]  
  
     In the preceding example, the `Get` procedure has the same `Protected` access as the property itself, while the `Set` procedure has `Private` access. A class derived from `employee` can read the `salary` value, but only the `employee` class can set it.  
  
## See Also  
 [Procedures](./index.md)  
 [Property Procedures](./property-procedures.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Property Statement](../../../../visual-basic/language-reference/statements/property-statement.md)  
 [Differences Between Properties and Variables in Visual Basic](./differences-between-properties-and-variables.md)  
 [How to: Create a Property](./how-to-create-a-property.md)  
 [How to: Call a Property Procedure](./how-to-call-a-property-procedure.md)  
 [How to: Declare and Call a Default Property in Visual Basic](./how-to-declare-and-call-a-default-property.md)  
 [How to: Put a Value in a Property](./how-to-put-a-value-in-a-property.md)  
 [How to: Get a Value from a Property](./how-to-get-a-value-from-a-property.md)
