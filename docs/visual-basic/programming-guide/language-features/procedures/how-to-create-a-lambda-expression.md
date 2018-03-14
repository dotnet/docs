---
title: "How to: Create a Lambda Expression (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "lambda expressions [Visual Basic]"
  - "expressions [Visual Basic], lambda"
ms.assetid: 3279bd5c-80f7-410a-a7ba-f7085ed36aa5
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Create a Lambda Expression (Visual Basic)
A *lambda expression* is a function or subroutine that does not have a name. A lambda expression can be used wherever a delegate type is valid.  
  
### To create a single-line lambda expression function  
  
1.  In any situation where a delegate type could be used, type the keyword `Function`, as in the following example:  
  
     `Dim add1 =`   `Function`  
  
2.  In parentheses, directly after `Function`, type the parameters of the function. Notice that you do not specify a name after `Function`.  
  
     `Dim add1 = Function`   `(num As Integer)`  
  
3.  Following the parameter list, type a single expression as the body of the function. The value that the expression evaluates to is the value returned by the function. You do not use an `As` clause to specify the return type.  
  
     [!code-vb[VbVbalrLambdas#1](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_1.vb)]  
  
     You call the lambda expression by passing in an integer argument.  
  
     [!code-vb[VbVbalrLambdas#2](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_2.vb)]  
  
4.  Alternatively, the same result is accomplished by the following example:  
  
     [!code-vb[VbVbalrLambdas#3](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_3.vb)]  
  
### To create a single-line lambda expression subroutine  
  
1.  In any situation where a delegate type could be used, type the keyword `Sub`, as shown in the following example.  
  
     `Dim add1 =`   `Sub`  
  
2.  In parentheses, directly after `Sub`, type the parameters of the subroutine. Notice that you do not specify a name after `Sub`.  
  
     `Dim add1 = Sub`   `(msg As String)`  
  
3.  Following the parameter list, type a single statement as the body of the subroutine.  
  
     [!code-vb[VbVbalrLambdas#17](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_4.vb)]  
  
     You call the lambda expression by passing in a string argument.  
  
     [!code-vb[VbVbalrLambdas#18](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_5.vb)]  
  
### To create a multiline lambda expression function  
  
1.  In any situation where a delegate type could be used, type the keyword `Function`, as shown in the following example.  
  
     `Dim add1 =`   `Function`  
  
2.  In parentheses, directly after `Function`, type the parameters of the function. Notice that you do not specify a name after `Function`.  
  
     `Dim add1 = Function`   `(index As Integer)`  
  
3.  Press ENTER. The `End Function` statement is automatically added.  
  
4.  Within the body of the function, add the following code to create an expression and return the value. You do not use an `As` clause to specify the return type.  
  
     [!code-vb[VbVbalrLambdas#19](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_6.vb)]  
  
     You call the lambda expression by passing in an integer argument.  
  
     [!code-vb[VbVbalrLambdas#20](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_7.vb)]  
  
### To create a multiline lambda expression subroutine  
  
1.  In any situation where a delegate type could be used, type the keyword `Sub`, as shown in the following example:  
  
     `Dim add1 =`   `Sub`  
  
2.  In parentheses, directly after `Sub`, type the parameters of the subroutine. Notice that you do not specify a name after `Sub`.  
  
     `Dim add1 = Sub`  `(msg As String)`  
  
3.  Press ENTER. The `End Sub` statement is automatically added.  
  
4.  Within the body of the function, add the following code to execute when the subroutine is invoked.  
  
     [!code-vb[VbVbalrLambdas#21](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_8.vb)]  
  
     You call the lambda expression by passing in a string argument.  
  
     [!code-vb[VbVbalrLambdas#22](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_9.vb)]  
  
## Example  
 A common use of lambda expressions is to define a function that can be passed in as the argument for a parameter whose type is `Delegate`. In the following example, the <xref:System.Diagnostics.Process.GetProcesses%2A> method returns an array of the processes running on the local computer. The <xref:System.Linq.Enumerable.Where%2A> method from the <xref:System.Linq.Enumerable> class requires a `Boolean` delegate as its argument. The lambda expression in the example is used for that purpose. It returns `True` for each process that has only one thread, and those are selected in `filteredList`.  
  
 [!code-vb[VbVbalrLambdas#10](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_10.vb)]  
  
 The previous example is equivalent to the following code, which is written in [!INCLUDE[vbteclinqext](~/includes/vbteclinqext-md.md)] syntax:  
  
 [!code-vb[VbVbalrLambdas#11](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-a-lambda-expression_11.vb)]  
  
## See Also  
 <xref:System.Linq.Enumerable>  
 [Lambda Expressions](./lambda-expressions.md)  
 [Function Statement](../../../../visual-basic/language-reference/statements/function-statement.md)  
 [Sub Statement](../../../../visual-basic/language-reference/statements/sub-statement.md)  
 [Delegates](../../../../visual-basic/programming-guide/language-features/delegates/index.md)  
 [How to: Pass Procedures to Another Procedure in Visual Basic](../../../../visual-basic/programming-guide/language-features/delegates/how-to-pass-procedures-to-another-procedure.md)  
 [Delegate Statement](../../../../visual-basic/language-reference/statements/delegate-statement.md)  
 [Introduction to LINQ in Visual Basic](../../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)
