---
title: "While...End While Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.While"
  - "vb.While...EndWhile"
helpviewer_keywords: 
  - "While statement [Visual Basic], While...End While"
  - "While statement [Visual Basic]"
  - "While...End While statements [Visual Basic]"
ms.assetid: b931d1ce-e8ed-44d8-a13d-92a4f5458a1e
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# While...End While Statement (Visual Basic)
Runs a series of statements as long as a given condition is `True`.  
  
## Syntax  
  
```  
While condition  
    [ statements ]  
    [ Continue While ]  
    [ statements ]  
    [ Exit While ]  
    [ statements ]  
End While  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`condition`|Required. `Boolean` expression. If `condition` is `Nothing`, Visual Basic treats it as `False`.|  
|`statements`|Optional. One or more statements following `While`, which run every time `condition` is `True`.|  
|`Continue While`|Optional. Transfers control to the next iteration of the `While` block.|  
|`Exit While`|Optional. Transfers control out of the `While` block.|  
|`End While`|Required. Terminates the definition of the `While` block.|  
  
## Remarks  
 Use a `While...End While` structure when you want to repeat a set of statements an indefinite number of times, as long as a condition remains `True`. If you want more flexibility with where you test the condition or what result you test it for, you might prefer the [Do...Loop Statement](../../../visual-basic/language-reference/statements/do-loop-statement.md). If you want to repeat the statements a set number of times, the [For...Next Statement](../../../visual-basic/language-reference/statements/for-next-statement.md) is usually a better choice.  
  
> [!NOTE]
>  The `While` keyword is also used in the [Do...Loop Statement](../../../visual-basic/language-reference/statements/do-loop-statement.md), the [Skip While Clause](../../../visual-basic/language-reference/queries/skip-while-clause.md) and the [Take While Clause](../../../visual-basic/language-reference/queries/take-while-clause.md).  
  
 If `condition` is `True`, all of the `statements` run until the `End While` statement is encountered. Control then returns to the `While` statement, and `condition` is again checked. If `condition` is still `True`, the process is repeated. If it’s `False`, control passes to the statement that follows the `End While` statement.  
  
 The `While` statement always checks the condition before it starts the loop. Looping continues while the condition remains `True`. If `condition` is `False` when you first enter the loop, it doesn’t run even once.  
  
 The `condition` usually results from a comparison of two values, but it can be any expression that evaluates to a [Boolean Data Type](../../../visual-basic/language-reference/data-types/boolean-data-type.md) value (`True` or `False`). This expression can include a value of another data type, such as a numeric type, that has been converted to `Boolean`.  
  
 You can nest `While` loops by placing one loop within another. You can also nest different kinds of control structures within one another. For more information, see [Nested Control Structures](../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md).  
  
## Exit While  
 The [Exit While](../../../visual-basic/language-reference/statements/exit-statement.md) statement can provide another way to exit a `While` loop. `Exit While` immediately transfers control to the statement that follows the `End While` statement.  
  
 You typically use `Exit While` after some condition is evaluated (for example, in an `If...Then...Else` structure). You might want to exit a loop if you detect a condition that makes it unnecessary or impossible to continue iterating, such as an erroneous value or a termination request. You can use `Exit While` when you test for a condition that could cause an *endless loop*, which is a loop that could run an extremely large or even infinite number of times. You can then use `Exit While` to escape the loop.  
  
 You can place any number of `Exit While` statements anywhere in the `While` loop.  
  
 When used within nested `While` loops, `Exit While` transfers control out of the innermost loop and into the next higher level of nesting.  
  
 The `Continue While` statement immediately transfers control to the next iteration of the loop. For more information, see [Continue Statement](../../../visual-basic/language-reference/statements/continue-statement.md).  
  
## Example  
 In the following example, the statements in the loop continue to run until the `index` variable is greater than 10.  
  
 [!code-vb[VbVbalrStatements#171](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/while-end-while-statement_1.vb)]  
  
## Example  
 The following example illustrates the use of the `Continue While` and `Exit While` statements.  
  
 [!code-vb[VbVbalrStatements#172](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/while-end-while-statement_2.vb)]  
  
## Example  
 The following example reads all lines in a text file. The <xref:System.IO.File.OpenText%2A> method opens the file and returns a <xref:System.IO.StreamReader> that reads the characters. In the `While` condition, the <xref:System.IO.StreamReader.Peek%2A> method of the `StreamReader` determines whether the file contains additional characters.  
  
 [!code-vb[VbVbalrStatements#173](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/while-end-while-statement_3.vb)]  
  
## See Also  
 [Loop Structures](../../../visual-basic/programming-guide/language-features/control-flow/loop-structures.md)  
 [Do...Loop Statement](../../../visual-basic/language-reference/statements/do-loop-statement.md)  
 [For...Next Statement](../../../visual-basic/language-reference/statements/for-next-statement.md)  
 [Boolean Data Type](../../../visual-basic/language-reference/data-types/boolean-data-type.md)  
 [Nested Control Structures](../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md)  
 [Exit Statement](../../../visual-basic/language-reference/statements/exit-statement.md)  
 [Continue Statement](../../../visual-basic/language-reference/statements/continue-statement.md)
