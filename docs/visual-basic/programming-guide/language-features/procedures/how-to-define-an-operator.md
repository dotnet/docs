---
title: "How to: Define an Operator (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "procedures [Visual Basic], defining"
  - "Visual Basic code, procedures"
  - "operators [Visual Basic], defining"
  - "procedures [Visual Basic], operator"
  - "Visual Basic code, operators"
  - "syntax [Visual Basic], Operator procedures"
  - "operators [Visual Basic], overloading"
  - "operator procedures [Visual Basic], about operator procedures"
  - "return values [Visual Basic], Operator procedures"
  - "operator overloading"
ms.assetid: d4b0e253-092a-4e6e-9fe2-01f562140a29
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Define an Operator (Visual Basic)
If you have defined a class or structure, you can define the behavior of a standard operator (such as `*`, `<>`, or `And`) when one or both of the operands is of the type of your class or structure.  
  
 Define the standard operator as an operator procedure within the class or structure. All operator procedures must be `Public` `Shared`.  
  
 Defining an operator on a class or structure is also called *overloading* the operator.  
  
## Example  
 The following example defines the `+` operator for a structure called `height`. The structure uses heights measured in feet and inches. One *inch* is 2.54 centimeters, and one *foot* is 12 inches. To ensure normalized values (inches < 12.0), the constructor performs *modulo* 12 arithmetic. The `+` operator uses the constructor to generate normalized values.  
  
 [!code-vb[VbVbcnProcedures#25](./codesnippet/VisualBasic/how-to-define-an-operator_1.vb)]  
  
 You can test the structure `height` with the following code.  
  
 [!code-vb[VbVbcnProcedures#26](./codesnippet/VisualBasic/how-to-define-an-operator_2.vb)]  
  
 For more information and examples, see [Operator Overloading in Visual Basic 2005](http://go.microsoft.com/fwlink/?LinkId=101703).  
  
## See Also  
 [Operator Procedures](./operator-procedures.md)  
 [How to: Define a Conversion Operator](./how-to-define-a-conversion-operator.md)  
 [How to: Call an Operator Procedure](./how-to-call-an-operator-procedure.md)  
 [How to: Use a Class that Defines Operators](./how-to-use-a-class-that-defines-operators.md)  
 [Operator Statement](../../../../visual-basic/language-reference/statements/operator-statement.md)  
 [Structure Statement](../../../../visual-basic/language-reference/statements/structure-statement.md)  
 [How to: Declare a Structure](../../../../visual-basic/programming-guide/language-features/data-types/how-to-declare-a-structure.md)  
 [Mod Operator](../../../../visual-basic/language-reference/operators/mod-operator.md)
