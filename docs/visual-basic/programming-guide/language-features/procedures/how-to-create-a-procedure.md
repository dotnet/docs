---
title: "How to: Create a Procedure (Visual Basic)"
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
  - "Visual Basic code, reusing"
  - "procedure declarations"
  - "procedures [Visual Basic], about procedures"
ms.assetid: 4f779247-0b50-47e8-9e5c-ab5cf39ac0d2
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Create a Procedure (Visual Basic)
You enclose a procedure between a starting declaration statement (`Sub` or `Function`) and an ending declaration statement (`End Sub` or `End Function`). All the procedure's code lies between these statements.  
  
 A procedure cannot contain another procedure, so its starting and ending statements must be outside any other procedure.  
  
 If you have code that performs the same task in different places, you can write the task once as a procedure and then call it from different places in your code.  
  
### To create a procedure that does not return a value  
  
1.  Outside any other procedure, use a `Sub` statement, followed by an `End Sub` statement.  
  
2.  In the `Sub` statement, follow the `Sub` keyword with the name of the procedure, then the parameter list in parentheses.  
  
3.  Place the procedure's code statements between the `Sub` and `End Sub` statements.  
  
### To create a procedure that returns a value  
  
1.  Outside any other procedure, use a `Function` statement, followed by an `End Function` statement.  
  
2.  In the `Function` statement, follow the `Function` keyword with the name of the procedure, then the parameter list in parentheses, and then an `As` clause specifying the data type of the return value.  
  
3.  Place the procedure's code statements between the `Function` and `End Function` statements.  
  
4.  Use a `Return` statement to return the value to the calling code.  
  
### To connect your new procedure with the old, repetitive blocks of code  
  
1.  Make sure you define the new procedure in a place where the old code has access to it.  
  
2.  In your old, repetitive code block, replace the statements that perform the repetitive task with a single statement that calls the `Sub` or `Function` procedure.  
  
3.  If your procedure is a `Function` that returns a value, ensure that your calling statement performs an action with the returned value, such as storing it in a variable, or else the value will be lost.  
  
## Example  
 The following `Function` procedure calculates the longest side, or hypotenuse, of a right triangle, given the values for the other two sides.  
  
 [!code-vb[VbVbcnProcedures#1](./codesnippet/VisualBasic/how-to-create-a-procedure_1.vb)]  
  
## See Also  
 [Procedures](./index.md)  
 [Sub Procedures](./sub-procedures.md)  
 [Function Procedures](./function-procedures.md)  
 [Property Procedures](./property-procedures.md)  
 [Operator Procedures](./operator-procedures.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Recursive Procedures](./recursive-procedures.md)  
 [Procedure Overloading](./procedure-overloading.md)  
 [Objects and Classes](../../../../visual-basic/programming-guide/language-features/objects-and-classes/index.md)  
 [Object-Oriented Programming](http://msdn.microsoft.com/library/1cf6e655-3f30-45f1-9a5d-4a88ca24a1c2)
