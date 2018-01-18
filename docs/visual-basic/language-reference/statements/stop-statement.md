---
title: "Stop Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Stop"
helpviewer_keywords: 
  - "breakpoints, Stop statements"
  - "Stop statements [Visual Basic], syntax"
  - "Stop statements [Visual Basic]"
  - "execution [Visual Basic], suspending"
  - "processing, interrupting"
  - "processes, interrupting"
  - "execution [Visual Basic], stopping"
ms.assetid: c9a9fde0-d649-4662-9bef-bd0146ebc2a7
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# Stop Statement (Visual Basic)
Suspends execution.  
  
## Syntax  
  
```  
Stop  
```  
  
## Remarks  
 You can place `Stop` statements anywhere in procedures to suspend execution. Using the `Stop` statement is similar to setting a breakpoint in the code.  
  
 The `Stop` statement suspends execution, but unlike `End`, it does not close any files or clear any variables, unless it is encountered in a compiled executable (.exe) file.  
  
> [!NOTE]
>  If the `Stop` statement is encountered in code that is running outside of the integrated development environment (IDE), the debugger is invoked. This is true regardless of whether the code was compiled in debug or retail mode.  
  
## Example  
 This example uses the `Stop` statement to suspend execution for each iteration through the `For...Next` loop.  
  
 [!code-vb[VbVbalrStatements#56](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/stop-statement_1.vb)]  
  
## See Also  
 [End Statement](../../../visual-basic/language-reference/statements/end-statement.md)
