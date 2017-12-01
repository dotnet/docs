---
title: "Sub Expression (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "lambda expressions [Visual Basic], sub expression"
  - "Sub Expression [Visual Basic]"
  - "subroutines [Visual Basic], sub expressions"
ms.assetid: 36b6bfd1-6539-4d8f-a5eb-6541a745ffde
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
---
# Sub Expression (Visual Basic)
Declares the parameters and code that define a subroutine lambda expression.  
  
## Syntax  
  
```  
Sub ( [ parameterlist ] ) statement  
- or -  
Sub ( [ parameterlist ] )  
  [ statements ]  
End Sub  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`parameterlist`|Optional. A list of local variable names that represent the parameters of the procedure. The parentheses must be present even when the list is empty. For more information, see [Parameter List](../../../visual-basic/language-reference/statements/parameter-list.md).|  
|`statement`|Required. A single statement.|  
|`statements`|Required. A list of statements.|  
  
## Remarks  
 A *lambda expression* is a subroutine that does not have a name and that executes one or more statements. You can use a lambda expression anywhere that you can use a delegate type, except as an argument to `RemoveHandler`. For more information about delegates, and the use of lambda expressions with delegates, see [Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md) and [Relaxed Delegate Conversion](../../../visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion.md).  
  
## Lambda Expression Syntax  
 The syntax of a lambda expression resembles that of a standard subroutine. The differences are as follows:  
  
-   A lambda expression does not have a name.  
  
-   A lambda expression cannot have a modifier, such as `Overloads` or `Overrides`.  
  
-   The body of a single-line lambda expression must be a statement, not an expression. The body can consist of a call to a sub procedure, but not a call to a function procedure.  
  
-   In a lambda expression, either all parameters must have specified data types or all parameters must be inferred.  
  
-   Optional and `ParamArray` parameters are not permitted in lambda expressions.  
  
-   Generic parameters are not permitted in lambda expressions.  
  
## Example  
 Following is an example of a lambda expression that writes a value to the console. The example shows both the single-line and multiline lambda expression syntax for a subroutine. For more examples, see [Lambda Expressions](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md).  
  
 [!code-vb[VbVbalrLambdas#15](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/sub-expression_1.vb)]  
  
## See Also  
 [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md)  
 [Lambda Expressions](../../../visual-basic/programming-guide/language-features/procedures/lambda-expressions.md)  
 [Operators and Expressions](../../../visual-basic/programming-guide/language-features/operators-and-expressions/index.md)  
 [Statements](../../../visual-basic/programming-guide/language-features/statements.md)  
 [Relaxed Delegate Conversion](../../../visual-basic/programming-guide/language-features/delegates/relaxed-delegate-conversion.md)
