---
title: "How to: Call a Procedure That Returns a Value (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "procedure calls [Visual Basic], returning values"
  - "Visual Basic code, procedures"
  - "procedures [Visual Basic], calling"
  - "procedures [Visual Basic], returning a value"
ms.assetid: a445127b-0f5f-465a-98fb-3e514b93d115
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Call a Procedure That Returns a Value (Visual Basic)
A `Function` procedure returns a value to the calling code. You call it by including its name and arguments either on the right side of an assignment statement or in an expression.  
  
### To call a Function procedure within an expression  
  
1.  Use the `Function` procedure name the same way you would use a variable. You can use a `Function` procedure call anywhere you can use a variable or constant in an expression.  
  
2.  Follow the procedure name with parentheses to enclose the argument list. If there are no arguments, you can optionally omit the parentheses. However, using the parentheses makes your code easier to read.  
  
3.  Place the arguments in the argument list within the parentheses, separated by commas. Be sure you supply the arguments in the same order that the `Function` procedure defines the corresponding parameters.  
  
     Alternatively, you can pass one or more arguments by name. For more information, see [Passing Arguments by Position and by Name](./passing-arguments-by-position-and-by-name.md).  
  
4.  The value returned from the procedure participates in the expression just as the value of a variable or constant would.  
  
### To call a Function procedure in an assignment statement  
  
1.  Use the `Function` procedure name following the equal (`=`) sign in the assignment statement.  
  
2.  Follow the procedure name with parentheses to enclose the argument list. If there are no arguments, you can optionally omit the parentheses. However, using the parentheses makes your code easier to read.  
  
3.  Place the arguments in the argument list within the parentheses, separated by commas. Be sure you supply the arguments in the same order that the `Function` procedure defines the corresponding parameters, unless you are passing them by name.  
  
4.  The value returned from the procedure is stored in the variable or property on the left side of the assignment statement.  
  
## Example  
 The following example calls the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] <xref:Microsoft.VisualBasic.Interaction.Environ%2A> to retrieve the value of an operating system environment variable. The first line calls `Environ` within an expression, and the second line calls it in an assignment statement. `Environ` takes the variable name as its sole argument. It returns the variable's value to the calling code.  
  
 [!code-vb[VbVbcnProcedures#7](./codesnippet/VisualBasic/how-to-call-a-procedure-that-returns-a-value_1.vb)]  
  
## See Also  
 [Function Procedures](./function-procedures.md)  
 [Procedure Parameters and Arguments](./procedure-parameters-and-arguments.md)  
 [Function Statement](../../../../visual-basic/language-reference/statements/function-statement.md)  
 [How to: Create a Procedure that Returns a Value](./how-to-create-a-procedure-that-returns-a-value.md)  
 [How to: Return a Value from a Procedure](./how-to-return-a-value-from-a-procedure.md)  
 [How to: Call a Procedure that Does Not Return a Value](./how-to-call-a-procedure-that-does-not-return-a-value.md)
