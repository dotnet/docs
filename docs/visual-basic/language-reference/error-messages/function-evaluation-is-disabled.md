---
title: "Function evaluation is disabled because a previous function evaluation timed out"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30957"
  - "vbc30957"
helpviewer_keywords: 
  - "BC30957"
ms.assetid: 561e593a-f50a-4b72-a708-4cab60ec7b28
---
# Function evaluation is disabled because a previous function evaluation timed out
Function evaluation is disabled because a previous function evaluation timed out. To re-enable function evaluation, step again or restart debugging.  
  
 In the Visual Studio debugger, an expression specifies a procedure call, but another evaluation has timed out.  
  
 Possible causes for a procedure call to time out include an infinite loop or *endless loop*. For more information, see [For...Next Statement](../../../visual-basic/language-reference/statements/for-next-statement.md).  
  
 A special case of an infinite loop is *recursion*. For more information, see [Recursive Procedures](../../../visual-basic/programming-guide/language-features/procedures/recursive-procedures.md).  
  
 **Error ID:** BC30957  
  
## To correct this error  
  
1. If possible, determine what the previous function evaluation was and what caused it to time out. Otherwise, you might encounter this error again.  
  
2. Either step the debugger again, or terminate and restart debugging.  
  
## See also

- [Debugging in Visual Studio](/visualstudio/debugger/debugger-feature-tour)
- [Navigating through Code with the Debugger](/visualstudio/debugger/navigating-through-code-with-the-debugger)
