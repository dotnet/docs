---
description: "Learn more about: Loop Structures (Visual Basic)"
title: "Loop Structures"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "control flow [Visual Basic], loops"
  - "For keyword [Visual Basic], loop structures"
  - "loops"
  - "loop structures [Visual Basic]"
  - "statements [Visual Basic], loop"
  - "Do statement [Visual Basic], Do loops"
  - "conditional statements [Visual Basic], loop structures"
ms.assetid: ecacb09b-a4c9-42be-98b2-a15d368b5db8
---
# Loop Structures (Visual Basic)

Visual Basic loop structures allow you to run one or more lines of code repetitively. You can repeat the statements in a loop structure until a condition is `True`, until a condition is `False`, a specified number of times, or once for each element in a collection.  
  
 The following illustration shows a loop structure that runs a set of statements until a condition becomes true:  
  
 ![Flow chart that shows a Do...Until loop.](./media/loop-structures/do-until-loop-true-condition.gif)  
  
## While Loops  

 The `While`...`End While` construction runs a set of statements as long as the condition specified in the `While` statement is `True`. For more information, see [While...End While Statement](../../../language-reference/statements/while-end-while-statement.md).  
  
## Do Loops  

 The `Do`...`Loop` construction allows you to test a condition at either the beginning or the end of a loop structure. You can also specify whether to repeat the loop while the condition remains `True` or until it becomes `True`. For more information, see [Do...Loop Statement](../../../language-reference/statements/do-loop-statement.md).  
  
## For Loops  

 The `For`...`Next` construction performs the loop a set number of times. It uses a loop control variable, also called a *counter*, to keep track of the repetitions. You specify the starting and ending values for this counter, and you can optionally specify the amount by which it increases from one repetition to the next. For more information, see [For...Next Statement](../../../language-reference/statements/for-next-statement.md).  
  
## For Each Loops  

 The `For Each`...`Next` construction runs a set of statements once for each element in a collection. You specify the loop control variable, but you do not have to determine starting or ending values for it. For more information, see [For Each...Next Statement](../../../language-reference/statements/for-each-next-statement.md).  
  
## See also

- [Control Flow](index.md)
- [Decision Structures](decision-structures.md)
- [Other Control Structures](other-control-structures.md)
- [Nested Control Structures](nested-control-structures.md)
