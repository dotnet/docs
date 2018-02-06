---
title: "Do...Loop Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Do"
  - "vb.Loop"
  - "vb.Until"
helpviewer_keywords: 
  - "conditional statements [Visual Basic], Do�Loop"
  - "while statement [Visual Basic], Do...Loop"
  - "execution [Visual Basic], conditional"
  - "Do loops"
  - "Until keyword [Visual Basic], Do...Loop statement"
  - "Do...Loop statement"
  - "instructions, repeating"
  - "Do statement [Visual Basic]"
  - "Exit statement [Visual Basic], in Do...Loop statements"
  - "loop structures [Visual Basic], Do�Loop statements"
  - "do-while statements [Visual Basic]"
  - "loops, exiting"
  - "Loop keyword [Visual Basic], Do...Loop statement"
ms.assetid: 892f9096-b3e2-4aee-834d-83bc4e2c379d
caps.latest.revision: 37
author: dotnet-bot
ms.author: dotnetcontent
---
# Do...Loop Statement (Visual Basic)
Repeats a block of statements while a `Boolean` condition is `True` or until the condition becomes `True`.  
  
## Syntax  
  
```  
Do { While | Until } condition  
    [ statements ]  
    [ Continue Do ]  
    [ statements ]  
    [ Exit Do ]  
    [ statements ]  
Loop  
-or-  
Do  
    [ statements ]  
    [ Continue Do ]  
    [ statements ]  
    [ Exit Do ]  
    [ statements ]  
Loop { While | Until } condition  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`Do`|Required. Starts the definition of the `Do` loop.|  
|`While`|Required unless `Until` is used. Repeat the loop until `condition` is `False`.|  
|`Until`|Required unless `While` is used. Repeat the loop until `condition` is `True`.|  
|`condition`|Optional. `Boolean` expression. If `condition` is `Nothing`, Visual Basic treats it as `False`.|  
|`statements`|Optional. One or more statements that are repeated while, or until, `condition` is `True`.|  
|`Continue Do`|Optional. Transfers control to the next iteration of the `Do` loop.|  
|`Exit Do`|Optional. Transfers control out of the `Do` loop.|  
|`Loop`|Required. Terminates the definition of the `Do` loop.|  
  
## Remarks  
 Use a `Do...Loop` structure when you want to repeat a set of statements an indefinite number of times, until a condition is satisfied. If you want to repeat the statements a set number of times, the [For...Next Statement](../../../visual-basic/language-reference/statements/for-next-statement.md) is usually a better choice.  
  
 You can use either `While` or `Until` to specify `condition`, but not both.  
  
 You can test `condition` only one time, at either the start or the end of the loop. If you test `condition` at the start of the loop (in the `Do` statement), the loop might not run even one time. If you test at the end of the loop (in the `Loop` statement), the loop always runs at least one time.  
  
 The condition usually results from a comparison of two values, but it can be any expression that evaluates to a [Boolean Data Type](../../../visual-basic/language-reference/data-types/boolean-data-type.md) value (`True` or `False`). This includes values of other data types, such as numeric types, that have been converted to `Boolean`.  
  
 You can nest `Do` loops by putting one loop within another. You can also nest different kinds of control structures within each other. For more information, see [Nested Control Structures](../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md).  
  
> [!NOTE]
>  The `Do...Loop` structure gives you more flexibility than the [While...End While Statement](../../../visual-basic/language-reference/statements/while-end-while-statement.md) because it enables you to decide whether to end the loop when `condition` stops being `True` or when it first becomes `True`. It also enables you to test `condition` at either the start or the end of the loop.  
  
## Exit Do  
 The [Exit Do](../../../visual-basic/language-reference/statements/exit-statement.md) statement can provide an alternative way to exit a `Do…Loop`. `Exit Do` transfers control immediately to the statement that follows the `Loop` statement.  
  
 `Exit Do` is often used after some condition is evaluated, for example in an `If...Then...Else` structure. You might want to exit a loop if you detect a condition that makes it unnecessary or impossible to continue iterating, such as an erroneous value or a termination request. One use of `Exit Do` is to test for a condition that could cause an *endless loop*, which is a loop that could run a large or even infinite number of times. You can use `Exit Do` to escape the loop.  
  
 You can include any number of `Exit Do` statements anywhere in a `Do…Loop`.  
  
 When used within nested `Do` loops, `Exit Do` transfers control out of the innermost loop and into the next higher level of nesting.  
  
## Example  
 In the following example, the statements in the loop continue to run until the `index` variable is greater than 10. The `Until` clause is at the end of the loop.  
  
 [!code-vb[VbVbalrStatements#131](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/do-loop-statement_1.vb)]  
  
## Example  
 The following example uses a `While` clause instead of an `Until` clause, and `condition` is tested at the start of the loop instead of at the end.  
  
 [!code-vb[VbVbalrStatements#132](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/do-loop-statement_2.vb)]  
  
## Example  
 In the following example, `condition` stops the loop when the `index` variable is greater than 100. The `If` statement in the loop, however, causes the `Exit Do` statement to stop the loop when the index variable is greater than 10.  
  
 [!code-vb[VbVbalrStatements#133](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/do-loop-statement_3.vb)]  
  
## Example  
 The following example reads all lines in a text file. The <xref:System.IO.File.OpenText%2A> method opens the file and returns a <xref:System.IO.StreamReader> that reads the characters. In the `Do...Loop` condition, the <xref:System.IO.StreamReader.Peek%2A> method of the `StreamReader` determines whether there are any additional characters.  
  
 [!code-vb[VbVbalrStatements#134](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/do-loop-statement_4.vb)]  
  
## See Also  
 [Loop Structures](../../../visual-basic/programming-guide/language-features/control-flow/loop-structures.md)  
 [For...Next Statement](../../../visual-basic/language-reference/statements/for-next-statement.md)  
 [Boolean Data Type](../../../visual-basic/language-reference/data-types/boolean-data-type.md)  
 [Nested Control Structures](../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md)  
 [Exit Statement](../../../visual-basic/language-reference/statements/exit-statement.md)  
 [While...End While Statement](../../../visual-basic/language-reference/statements/while-end-while-statement.md)
