---
title: "How to: Call an Operator Procedure (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "operator procedures [Visual Basic], calling"
  - "procedures [Visual Basic], operator"
  - "procedure calls [Visual Basic], operator overloading"
  - "syntax [Visual Basic], Operator procedures"
  - "operators [Visual Basic], overloading"
  - "return values [Visual Basic], Operator procedures"
  - "overloaded operators [Visual Basic], calling"
  - "operator overloading"
ms.assetid: 0dce42cc-f0b0-4c14-9f62-018b21f33497
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Call an Operator Procedure (Visual Basic)
You call an operator procedure by using the operator symbol in an expression. In the case of a conversion operator, you call the [CType Function](../../../../visual-basic/language-reference/functions/ctype-function.md) to convert a value from one data type to another.  
  
 You do not call operator procedures explicitly. You just use the operator, or the `CType` function, in an assignment statement or an expression, the same way you ordinarily use an operator. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] makes the call to the operator procedure.  
  
 Defining an operator on a class or structure is also called *overloading* the operator.  
  
### To call an operator procedure  
  
1.  Use the operator symbol in an expression in the ordinary way.  
  
2.  Be sure the data types of the operands are appropriate for the operator, and in the correct order.  
  
3.  The operator contributes to the value of the expression as expected.  
  
### To call a conversion operator procedure  
  
1.  Use `CType` inside an expression.  
  
2.  Be sure the data types of the operands are appropriate for the conversion, and in the correct order.  
  
3.  `CType` calls the conversion operator procedure and returns the converted value.  
  
## Example  
 The following example creates two <xref:System.TimeSpan> structures, adds them together, and stores the result in a third <xref:System.TimeSpan> structure. The <xref:System.TimeSpan> structure defines operator procedures to overload several standard operators.  
  
 [!code-vb[VbVbcnProcedures#29](./codesnippet/VisualBasic/how-to-call-an-operator-procedure_1.vb)]  
  
 Because <xref:System.TimeSpan> overloads the standard `+` operator, the previous example calls an operator procedure when it calculates the value of `combinedSpan`.  
  
 For an example of calling a conversation operator procedure, see [How to: Use a Class that Defines Operators](./how-to-use-a-class-that-defines-operators.md).  
  
## Compiling the Code  
 Be sure the class or structure you are using defines the operator you want to use.  
  
## See Also  
 [Operator Procedures](./operator-procedures.md)  
 [How to: Define an Operator](./how-to-define-an-operator.md)  
 [How to: Define a Conversion Operator](./how-to-define-a-conversion-operator.md)  
 [Operator Statement](../../../../visual-basic/language-reference/statements/operator-statement.md)  
 [Widening](../../../../visual-basic/language-reference/modifiers/widening.md)  
 [Narrowing](../../../../visual-basic/language-reference/modifiers/narrowing.md)  
 [Structure Statement](../../../../visual-basic/language-reference/statements/structure-statement.md)  
 [How to: Declare a Structure](../../../../visual-basic/programming-guide/language-features/data-types/how-to-declare-a-structure.md)  
 [Implicit and Explicit Conversions](../../../../visual-basic/programming-guide/language-features/data-types/implicit-and-explicit-conversions.md)  
 [Widening and Narrowing Conversions](../../../../visual-basic/programming-guide/language-features/data-types/widening-and-narrowing-conversions.md)
