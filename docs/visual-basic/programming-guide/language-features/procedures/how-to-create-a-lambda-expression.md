---
title: "How to: Create a Lambda Expression"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "lambda expressions [Visual Basic]"
  - "expressions [Visual Basic], lambda"
ms.assetid: 3279bd5c-80f7-410a-a7ba-f7085ed36aa5
---
# How to: Create a Lambda Expression (Visual Basic)
A *lambda expression* is a function or subroutine that does not have a name. A lambda expression can be used wherever a delegate type is valid.  
  
### To create a single-line lambda expression function  
  
1. In any situation where a delegate type could be used, type the keyword `Function`, as in the following example:  
  
     `Dim add1 =`   `Function`  
  
2. In parentheses, directly after `Function`, type the parameters of the function. Notice that you do not specify a name after `Function`.  
  
     `Dim add1 = Function`   `(num As Integer)`  
  
3. Following the parameter list, type a single expression as the body of the function. The value that the expression evaluates to is the value returned by the function. You do not use an `As` clause to specify the return type.  
  
     [!code-vb[VbVbalrLambdas#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class1.vb#1)]  
  
     You call the lambda expression by passing in an integer argument.  
  
     [!code-vb[VbVbalrLambdas#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class1.vb#2)]  
  
4. Alternatively, the same result is accomplished by the following example:  
  
     [!code-vb[VbVbalrLambdas#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class1.vb#3)]  
  
### To create a single-line lambda expression subroutine  
  
1. In any situation where a delegate type could be used, type the keyword `Sub`, as shown in the following example.  
  
     `Dim add1 =`   `Sub`  
  
2. In parentheses, directly after `Sub`, type the parameters of the subroutine. Notice that you do not specify a name after `Sub`.  
  
     `Dim add1 = Sub`   `(msg As String)`  
  
3. Following the parameter list, type a single statement as the body of the subroutine.  
  
     [!code-vb[VbVbalrLambdas#17](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class1.vb#17)]  
  
     You call the lambda expression by passing in a string argument.  
  
     [!code-vb[VbVbalrLambdas#18](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class1.vb#18)]  
  
### To create a multiline lambda expression function  
  
1. In any situation where a delegate type could be used, type the keyword `Function`, as shown in the following example.  
  
     `Dim add1 =`   `Function`  
  
2. In parentheses, directly after `Function`, type the parameters of the function. Notice that you do not specify a name after `Function`.  
  
     `Dim add1 = Function`   `(index As Integer)`  
  
3. Press ENTER. The `End Function` statement is automatically added.  
  
4. Within the body of the function, add the following code to create an expression and return the value. You do not use an `As` clause to specify the return type.  
  
     [!code-vb[VbVbalrLambdas#19](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class1.vb#19)]  
  
     You call the lambda expression by passing in an integer argument.  
  
     [!code-vb[VbVbalrLambdas#20](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class1.vb#20)]  
  
### To create a multiline lambda expression subroutine  
  
1. In any situation where a delegate type could be used, type the keyword `Sub`, as shown in the following example:  
  
     `Dim add1 =`   `Sub`  
  
2. In parentheses, directly after `Sub`, type the parameters of the subroutine. Notice that you do not specify a name after `Sub`.  
  
     `Dim add1 = Sub`  `(msg As String)`  
  
3. Press ENTER. The `End Sub` statement is automatically added.  
  
4. Within the body of the function, add the following code to execute when the subroutine is invoked.  
  
     [!code-vb[VbVbalrLambdas#21](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class1.vb#21)]  
  
     You call the lambda expression by passing in a string argument.  
  
     [!code-vb[VbVbalrLambdas#22](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class1.vb#22)]  
  
## Example  
 A common use of lambda expressions is to define a function that can be passed in as the argument for a parameter whose type is `Delegate`. In the following example, the <xref:System.Diagnostics.Process.GetProcesses%2A> method returns an array of the processes running on the local computer. The <xref:System.Linq.Enumerable.Where%2A> method from the <xref:System.Linq.Enumerable> class requires a `Boolean` delegate as its argument. The lambda expression in the example is used for that purpose. It returns `True` for each process that has only one thread, and those are selected in `filteredList`.  
  
 [!code-vb[VbVbalrLambdas#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class4.vb#10)]  
  
 The previous example is equivalent to the following code, which is written in Language-Integrated Query (LINQ) syntax:  
  
 [!code-vb[VbVbalrLambdas#11](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrLambdas/VB/Class5.vb#11)]  
  
## See also

- <xref:System.Linq.Enumerable>
- [Lambda Expressions](./lambda-expressions.md)
- [Function Statement](../../../../visual-basic/language-reference/statements/function-statement.md)
- [Sub Statement](../../../../visual-basic/language-reference/statements/sub-statement.md)
- [Delegates](../../../../visual-basic/programming-guide/language-features/delegates/index.md)
- [How to: Pass Procedures to Another Procedure in Visual Basic](../../../../visual-basic/programming-guide/language-features/delegates/how-to-pass-procedures-to-another-procedure.md)
- [Delegate Statement](../../../../visual-basic/language-reference/statements/delegate-statement.md)
- [Introduction to LINQ in Visual Basic](../../../../visual-basic/programming-guide/language-features/linq/introduction-to-linq.md)
