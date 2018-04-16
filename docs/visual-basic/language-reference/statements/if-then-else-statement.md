---
title: "If...Then...Else Statement (Visual Basic)"
ms.date: 04/16/2018
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "conceptual"
f1_keywords: 
  - "vb.ElseIf"
  - "vb.Then"
  - "vb.If"
  - "vb.EndIf"
helpviewer_keywords: 
  - "ElseIf statement [Visual Basic], If...Then...Else"
  - "Then statement [Visual Basic], If...Then...Else"
  - "control flow [Visual Basic], branching"
  - "execution [Visual Basic], conditional"
  - "TypeOf...Is expression, and If...Then...Else statements"
  - "If...Then...Else statements"
  - "If statement [Visual Basic], If...Then...Else"
  - "If statement [Visual Basic]"
  - "Is operator [Visual Basic], in If...Then...Else statements"
  - "If Operator [Visual Basic]"
  - "branching [Visual Basic], conditional"
  - "If function [Visual Basic], and If...Then...Else statements"
  - "Else statement [Visual Basic]"
ms.assetid: 790068a2-1307-4e28-8a72-be5ebda099e9
caps.latest.revision: 29
author: dotnet-bot
ms.author: dotnetcontent
---
# If...Then...Else Statement (Visual Basic)
Conditionally executes a group of statements, depending on the value of an expression.  
  
## Syntax  
  
```  
' Multiline syntax:  
If condition [ Then ]  
    [ statements ]  
[ ElseIf elseifcondition [ Then ]  
    [ elseifstatements ] ]  
[ Else  
    [ elsestatements ] ]  
End If  
  
' Single-line syntax:  
If condition Then [ statements ] [ Else [ elsestatements ] ]  
```  

## Quick links to example code

This article includes several examples that illustrate uses of the `If`...`Then`...`Else` statement:

* [Multiline syntax example](#multi-line)
* [Nested syntax example](#nested)
* [Single-line syntax example](#single-line)

## Parts  
 `condition`  
 Required. Expression. Must evaluate to `True` or `False`, or to a data type that is implicitly convertible to `Boolean`.  
  
 If the expression is a [Nullable](../../../visual-basic/programming-guide/language-features/data-types/nullable-value-types.md) `Boolean` variable that evaluates to [Nothing](../../../visual-basic/language-reference/nothing.md), the condition is treated as if the expression is `False` and the `Else` block is executed.  
  
 `Then`  
 Required in the single-line syntax; optional in the multiline syntax.  
  
 `statements`  
 Optional. One or more statements following `If`...`Then` that are executed if `condition` evaluates to `True`.  
  
 `elseifcondition`  
 Required if `ElseIf` is present. Expression. Must evaluate to `True` or `False`, or to a data type that is implicitly convertible to `Boolean`.  
  
 `elseifstatements`  
 Optional. One or more statements following `ElseIf`...`Then` that are executed if `elseifcondition` evaluates to `True`.  
  
 `elsestatements`  
 Optional. One or more statements that are executed if no previous `condition` or `elseifcondition` expression evaluates to `True`.  
  
 `End If`  
 Terminates the multiline version of `If`...`Then`...`Else` block.  
  
## Remarks  
  
### Multiline syntax  
 When an `If`...`Then`...`Else` statement is encountered, `condition` is tested. If `condition` is `True`, the statements following `Then` are executed. If `condition` is `False`, each `ElseIf` statement (if there are any) is evaluated in order. When a `True` `elseifcondition` is found, the statements immediately following the associated `ElseIf` are executed. If no `elseifcondition` evaluates to `True`, or if there are no `ElseIf` statements, the statements following `Else` are executed. After executing the statements following `Then`, `ElseIf`, or `Else`, execution continues with the statement following `End If`.  
  
 The `ElseIf` and `Else` clauses are both optional. You can have as many `ElseIf` clauses as you want in an `If`...`Then`...`Else` statement, but no `ElseIf` clause can appear after an `Else` clause. `If`...`Then`...`Else` statements can be nested within each other.  
  
 In the multiline syntax, the `If` statement must be the only statement on the first line. The `ElseIf`, `Else`, and `End If` statements can be preceded only by a line label. The `If`...`Then`...`Else` block must end with an `End If` statement.  
  
> [!TIP]
>  The [Select...Case Statement](../../../visual-basic/language-reference/statements/select-case-statement.md) might be more useful when you evaluate a single expression that has several possible values.  
  
### Single-Line syntax  
 You can use the single-line syntax for a single condition with code to execute if it's true. However, the multiple-line syntax provides more structure and flexibility and is easier to read, maintain, and debug.  
  
 What follows the `Then` keyword is examined to determine whether a statement is a single-line `If`. If anything other than a comment appears after `Then` on the same line, the statement is treated as a single-line `If` statement. If `Then` is absent, it must be the start of a multiple-line `If`...`Then`...`Else`.  
  
 In the single-line syntax, you can have multiple statements executed as the result of an `If`...`Then` decision. All statements must be on the same line and be separated by colons.  

## Multiline syntax example

<a name="multi-line"></a>
 
 The following example illustrates the use of the multiline syntax of the `If`...`Then`...`Else` statement.  
  
 [!code-vb[VbVbalrStatements#101](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/if-then-else-statement_1.vb?highlight=11,14,17,19)]

## Nested syntax example

<a name="nested"></a>

 The following example contains nested `If`...`Then`...`Else` statements.  
  
 [!code-vb[VbVbalrStatements#102](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/if-then-else-statement_2.vb?highlight=14,15,17,19,20,21,23,25,26,28)]

## Single-Line syntax example
  
<a name="single-line"></a>
 The following example illustrates the use of the single-line syntax.  
  
 [!code-vb[VbVbalrStatements#103](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/if-then-else-statement_3.vb?highlight=18)]
  
## See also  
 <xref:Microsoft.VisualBasic.Interaction.Choose%2A>  
 <xref:Microsoft.VisualBasic.Interaction.Switch%2A>  
 [#If...Then...#Else Directives](../../../visual-basic/language-reference/directives/if-then-else-directives.md)  
 [Select...Case Statement](../../../visual-basic/language-reference/statements/select-case-statement.md)  
 [Nested Control Structures](../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md)  
 [Decision Structures](../../../visual-basic/programming-guide/language-features/control-flow/decision-structures.md)  
 [Logical and Bitwise Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/logical-and-bitwise-operators.md)  
 [If Operator](../../../visual-basic/language-reference/operators/if-operator.md)
