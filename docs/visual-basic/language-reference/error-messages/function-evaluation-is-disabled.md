---
title: "Function evaluation is disabled because a previous function evaluation timed out"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc30957"
  - "vbc30957"
helpviewer_keywords: 
  - "BC30957"
ms.assetid: 561e593a-f50a-4b72-a708-4cab60ec7b28
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
---
# Function evaluation is disabled because a previous function evaluation timed out
Function evaluation is disabled because a previous function evaluation timed out. To re-enable function evaluation, step again or restart debugging.  
  
 In the Visual Studio debugger, an expression specifies a procedure call, but another evaluation has timed out.  
  
 Possible causes for a procedure call to time out include an infinite loop or *endless loop*. For more information, see [For...Next Statement](../../../visual-basic/language-reference/statements/for-next-statement.md).  
  
 A special case of an infinite loop is *recursion*. For more information, see [Recursive Procedures](../../../visual-basic/programming-guide/language-features/procedures/recursive-procedures.md).  
  
 **Error ID:** BC30957  
  
## To correct this error  
  
1.  If possible, determine what the previous function evaluation was and what caused it to time out. Otherwise, you might encounter this error again.  
  
2.  Either step the debugger again, or terminate and restart debugging.  
  
## See Also  
 [Debugging in Visual Studio](/visualstudio/debugger/debugging-in-visual-studio)  
 [Navigating through Code with the Debugger](/visualstudio/debugger/navigating-through-code-with-the-debugger)
