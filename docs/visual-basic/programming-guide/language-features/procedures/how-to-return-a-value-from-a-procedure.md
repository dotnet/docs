---
title: "How to: Return a Value from a Procedure (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "Visual Basic code, procedures"
  - "procedures [Visual Basic], returning from"
  - "procedures [Visual Basic], returning a value"
ms.assetid: 4bcc4724-2b4e-4df8-9b4b-16054607f87d
---
# How to: Return a Value from a Procedure (Visual Basic)
A `Function` procedure returns a value to the calling code either by executing a `Return` statement or by encountering an `Exit Function` or `End Function` statement.  
  
### To return a value using the Return statement  
  
1. Put a `Return` statement at the point where the procedure's task is completed.  
  
2. Follow the `Return` keyword with an expression that yields the value you want to return to the calling code.  
  
3. You can have more than one `Return` statement in the same procedure.  
  
     The following `Function` procedure calculates the longest side, or hypotenuse, of a right triangle, and returns it to the calling code.  
  
     [!code-vb[VbVbcnProcedures#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#1)]  
  
     The following example shows a typical call to `hypotenuse`, which stores the returned value.  
  
     [!code-vb[VbVbcnProcedures#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnProcedures/VB/Class1.vb#6)]  
  
### To return a value using Exit Function or End Function  
  
1. In at least one place in the `Function` procedure, assign a value to the procedure's name.  
  
2. When you execute an `Exit Function` or `End Function` statement, Visual Basic returns the value most recently assigned to the procedure's name.  
  
3. You can have more than one `Exit Function` statement in the same procedure, and you can mix `Return` and `Exit Function` statements in the same procedure.  
  
4. You can have only one `End Function` statement in a `Function` procedure.  
  
     For more information and an example, see "Return Value" in [Function Statement](../../../../visual-basic/language-reference/statements/function-statement.md).  
  
## See also

- [Procedures](./index.md)
- [Sub Procedures](./sub-procedures.md)
- [Property Procedures](./property-procedures.md)
- [Operator Procedures](./operator-procedures.md)
- [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)
- [Function Statement](../../../../visual-basic/language-reference/statements/function-statement.md)
- [Return Statement](../../../../visual-basic/language-reference/statements/return-statement.md)
- [How to: Create a Procedure that Returns a Value](./how-to-create-a-procedure-that-returns-a-value.md)
- [How to: Call a Procedure That Returns a Value](./how-to-call-a-procedure-that-returns-a-value.md)
