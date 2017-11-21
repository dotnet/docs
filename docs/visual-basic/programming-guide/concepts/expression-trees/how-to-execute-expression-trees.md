---
title: "How to: Execute Expression Trees (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9dfb5ab3-f48f-417e-975f-f8f6f1cdc18d
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Execute Expression Trees (Visual Basic)
This topic shows you how to execute an expression tree. Executing an expression tree may return a value, or it may just perform an action such as calling a method.  
  
 Only expression trees that represent lambda expressions can be executed. Expression trees that represent lambda expressions are of type <xref:System.Linq.Expressions.LambdaExpression> or <xref:System.Linq.Expressions.Expression%601>. To execute these expression trees, call the <xref:System.Linq.Expressions.LambdaExpression.Compile%2A> method to create an executable delegate, and then invoke the delegate.  
  
> [!NOTE]
>  If the type of the delegate is not known, that is, the lambda expression is of type <xref:System.Linq.Expressions.LambdaExpression> and not <xref:System.Linq.Expressions.Expression%601>, you must call the <xref:System.Delegate.DynamicInvoke%2A> method on the delegate instead of invoking it directly.  
  
 If an expression tree does not represent a lambda expression, you can create a new lambda expression that has the original expression tree as its body, by calling the <xref:System.Linq.Expressions.Expression.Lambda%60%601%28System.Linq.Expressions.Expression%2CSystem.Collections.Generic.IEnumerable%7BSystem.Linq.Expressions.ParameterExpression%7D%29> method. Then, you can execute the lambda expression as described earlier in this section.  
  
## Example  
 The following code example demonstrates how to execute an expression tree that represents raising a number to a power by creating a lambda expression and executing it. The result, which represents the number raised to the power, is displayed.  
  
```vb  
' The expression tree to execute.  
Dim be As BinaryExpression = Expression.Power(Expression.Constant(2.0R), Expression.Constant(3.0R))  
  
' Create a lambda expression.  
Dim le As Expression(Of Func(Of Double)) = Expression.Lambda(Of Func(Of Double))(be)  
  
' Compile the lambda expression.  
Dim compiledExpression As Func(Of Double) = le.Compile()  
  
' Execute the lambda expression.  
Dim result As Double = compiledExpression()  
  
' Display the result.  
MsgBox(result)  
  
' This code produces the following output:  
' 8  
```  
  
## Compiling the Code  
  
-   Add a project reference to System.Core.dll if it is not already referenced.  
  
-   Include the System.Linq.Expressions namespace.  
  
## See Also  
 [Expression Trees (Visual Basic)](../../../../visual-basic/programming-guide/concepts/expression-trees/index.md)  
 [How to: Modify Expression Trees (Visual Basic)](../../../../visual-basic/programming-guide/concepts/expression-trees/how-to-modify-expression-trees.md)
