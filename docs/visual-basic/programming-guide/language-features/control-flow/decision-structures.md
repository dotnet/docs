---
title: "Decision Structures (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "statements [Visual Basic], control flow"
  - "If statement [Visual Basic], decision structures"
  - "If statement [Visual Basic], If...Then...Else"
  - "control flow [Visual Basic], decision structures"
  - "decision structures [Visual Basic]"
  - "conditional statements [Visual Basic], decision structures"
ms.assetid: 2e2e0895-4483-442a-b17c-26aead751ec2
caps.latest.revision: 29
author: dotnet-bot
ms.author: dotnetcontent
---
# Decision Structures (Visual Basic)
[!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] lets you test conditions and perform different operations depending on the results of that test. You can test for a condition being true or false, for various values of an expression, or for various exceptions generated when you execute a series of statements.  
  
 The following illustration shows a decision structure that tests for a condition being true and takes different actions depending on whether it is true or false.  
  
 ![Flow chart of an If...Then...Else construction](../../../../visual-basic/programming-guide/language-features/control-flow/media/ifthenelse.gif "IfThenElse")  
Taking different actions when a condition is true and when it is false  
  
## If...Then...Else Construction  
 `If...Then...Else` constructions let you test for one or more conditions and run one or more statements depending on each condition. You can test conditions and take actions in the following ways:  
  
-   Run one or more statements if a condition is `True`  
  
-   Run one or more statements if a condition is `False`  
  
-   Run some statements if a condition is `True` and others if it is `False`  
  
-   Test an additional condition if a prior condition is `False`  
  
 The control structure that offers all these possibilities is the [If...Then...Else Statement](../../../../visual-basic/language-reference/statements/if-then-else-statement.md). You can use a single-line version if you have just one test and one statement to run. If you have a more complex set of conditions and actions, you can use the multiple-line version.  
  
## Select...Case Construction  
 The `Select...Case` construction lets you evaluate an expression one time and run different sets of statements based on different possible values. For more information, see [Select...Case Statement](../../../../visual-basic/language-reference/statements/select-case-statement.md).  
  
## Try...Catch...Finally Construction  
 `Try...Catch...Finally` constructions let you run a set of statements under an environment that retains control if any one of your statements causes an exception. You can take different actions for different exceptions. You can optionally specify a block of code that runs before you exit the whole `Try...Catch...Finally` construction, regardless of what occurs. For more information, see [Try...Catch...Finally Statement](../../../../visual-basic/language-reference/statements/try-catch-finally-statement.md).  
  
> [!NOTE]
>  For many control structures, when you click a keyword, all of the keywords in the structure are highlighted. For instance, when you click `If` in an `If...Then...Else` construction, all instances of `If`, `Then`, `ElseIf`, `Else`, and `End If` in the construction are highlighted. To move to the next or previous highlighted keyword, press CTRL+SHIFT+DOWN ARROW or CTRL+SHIFT+UP ARROW.  
  
## See Also  
 [Control Flow](../../../../visual-basic/programming-guide/language-features/control-flow/index.md)  
 [Loop Structures](../../../../visual-basic/programming-guide/language-features/control-flow/loop-structures.md)  
 [Other Control Structures](../../../../visual-basic/programming-guide/language-features/control-flow/other-control-structures.md)  
 [Nested Control Structures](../../../../visual-basic/programming-guide/language-features/control-flow/nested-control-structures.md)  
 [If Operator](../../../../visual-basic/language-reference/operators/if-operator.md)
