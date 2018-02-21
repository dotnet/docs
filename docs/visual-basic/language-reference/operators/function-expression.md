---
title: "Function Expression (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Function expression [Visual Basic]"
  - "functions [Visual Basic], function expressions"
  - "lambda expressions [Visual Basic], function expression"
ms.assetid: e8a47a45-4b8a-4f45-a623-7653625dffbc
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Function Expression (Visual Basic)
Declares the parameters and code that define a function lambda expression.  
  
## Syntax  
  
```  
Function ( [ parameterlist ] ) expression  
- or -  
Function ( [ parameterlist ] )  
  [ statements ]  
End Function  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`parameterlist`|Optional. A list of local variable names that represent the parameters of this procedure. The parentheses must be present even when the list is empty. See [Parameter List](../../../visual-basic/language-reference/statements/parameter-list.md).|  
|`expression`|Required. A single expression. The type of the expression is the return type of the function.|  
|`statements`|Required. A list of statements that returns a value by using the `Return` statement. (See [Return Statement](../../../visual-basic/language-reference/statements/return-statement.md).) The type of the value returned is the return type of the function.|  
  
## Remarks  
 A *lambda expression* is a function without a name that calculates and returns a value. You can use a lambda expression anywhere you can use a delegate type, except as an argument to `RemoveHandler`. For more information about delegates, and the use of lambda expressions with delegates, see [Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md) and [Relaxed Delegate Conversion](../../../visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion.md).  
  
## Lambda Expression Syntax  
 The syntax of a lambda expression resembles that of a standard function. The differences are as follows:  
  
-   A lambda expression does not have a name.  
  
-   Lambda expressions cannot have modifiers, such as `Overloads` or `Overrides`.  
  
-   Lambda expressions do not use an `As` clause to designate the return type of the function. Instead, the type is inferred from the value that the body of a single-line lambda expression evaluates to, or the return value of a multiline lambda expression. For example, if the body of a single-line lambda expression is `Where cust.City = "London"`, its return type is `Boolean`.  
  
-   The body of a single-line lambda expression must be an expression, not a statement. The body can consist of a call to a function procedure, but not a call to a sub procedure.  
  
-   Either all parameters must have specified data types or all must be inferred.  
  
-   Optional and Paramarray parameters are not permitted.  
  
-   Generic parameters are not permitted.  
  
## Example  
 The following examples show two ways to create simple lambda expressions. The first uses a `Dim` to provide a name for the function. To call the function, you send in a value for the parameter.  
  
 [!code-vb[VbVbalrLambdas#1](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/function-expression_1.vb)]  
  
 [!code-vb[VbVbalrLambdas#2](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/function-expression_2.vb)]  
  
## Example  
 Alternatively, you can declare and run the function at the same time.  
  
 [!code-vb[VbVbalrLambdas#3](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/function-expression_3.vb)]  
  
## Example  
 Following is an example of a lambda expression that increments its argument and returns the value. The example shows both the single-line and multiline lambda expression syntax for a function. For more examples, see [Lambda Expressions](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md).  
  
 [!code-vb[VbVbalrLambdas#14](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/function-expression_4.vb)]  
  
## Example  
 Lambda expressions underlie many of the query operators in [!INCLUDE[vbteclinqext](~/includes/vbteclinqext-md.md)], and can be used explicitly in method-based queries. The following example shows a typical [!INCLUDE[vbteclinq](~/includes/vbteclinq-md.md)] query, followed by the translation of the query into method format.  
  
```vb  
Dim londonCusts = From cust In db.Customers  
                       Where cust.City = "London"  
                       Select cust  
  
' This query is compiled to the following code:  
Dim londonCusts = db.Customers.  
                  Where(Function(cust) cust.City = "London").  
                  Select(Function(cust) cust)  
```  
  
 For more information about query methods, see [Queries](../../../visual-basic/language-reference/queries/queries.md). For more information about standard query operators, see [Standard Query Operators Overview](../../programming-guide/concepts/linq/standard-query-operators-overview.md).  
  
## See Also  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
 [Lambda Expressions](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md)  
 [Operators and Expressions](../../../visual-basic/programming-guide/language-features/operators-and-expressions/index.md)  
 [Statements](../../../visual-basic/programming-guide/language-features/statements.md)  
 [Value Comparisons](../../../visual-basic/programming-guide/language-features/operators-and-expressions/value-comparisons.md)  
 [Boolean Expressions](../../../visual-basic/programming-guide/language-features/operators-and-expressions/boolean-expressions.md)  
 [If Operator](../../../visual-basic/language-reference/operators/if-operator.md)  
 [Relaxed Delegate Conversion](../../../visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion.md)
