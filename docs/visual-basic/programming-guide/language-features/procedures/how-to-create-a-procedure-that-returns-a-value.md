---
description: "Learn more about: How to: Create a Procedure that Returns a Value (Visual Basic)"
title: "How to: Create a Procedure that Returns a Value"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "procedures [Visual Basic], defining"
  - "Visual Basic code, procedures"
  - "procedures [Visual Basic], returning a value"
ms.assetid: 8ee19f95-a9ef-4033-963b-d224dca207c4
---
# How to: Create a Procedure that Returns a Value (Visual Basic)

You use a `Function` procedure to return a value to the calling code.  
  
### To create a procedure that returns a value  
  
1. Outside any other procedure, use a `Function` statement, followed by an `End Function` statement.  
  
2. In the `Function` statement, follow the `Function` keyword with the name of the procedure, and then the parameter list in parentheses.  
  
3. Follow the parentheses with an `As` clause to specify the data type of the returned value.  
  
4. Place the procedure's code statements between the `Function` and `End Function` statements.  
  
5. Use a `Return` statement to return the value to the calling code.  
  
     The following `Function` procedure calculates the longest side, or hypotenuse, of a right triangle, given the values for the other two sides.  
  
     [!code-vb[VbVbcnProcedures#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#1)]  
  
     The following example shows a typical call to `hypotenuse`.  
  
     [!code-vb[VbVbcnProcedures#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#6)]  
  
## See also

- [Procedures](./index.md)
- [Sub Procedures](./sub-procedures.md)
- [Property Procedures](./property-procedures.md)
- [Operator Procedures](./operator-procedures.md)
- [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)
- [Function Statement](../../../language-reference/statements/function-statement.md)
- [How to: Return a Value from a Procedure](./how-to-return-a-value-from-a-procedure.md)
- [How to: Call a Procedure That Returns a Value](./how-to-call-a-procedure-that-returns-a-value.md)
