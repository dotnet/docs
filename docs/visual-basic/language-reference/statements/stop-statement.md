---
title: "Stop Statement (Visual Basic)"
ms.date: 07/20/2015
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
> If the `Stop` statement is encountered in code that is running outside of the integrated development environment (IDE), the debugger is invoked. This is true regardless of whether the code was compiled in debug or retail mode.  
  
## Example  
 This example uses the `Stop` statement to suspend execution for each iteration through the `For...Next` loop.  
  
 [!code-vb[VbVbalrStatements#56](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrStatements/VB/Class1.vb#56)]  
  
## See also

- [End Statement](../../../visual-basic/language-reference/statements/end-statement.md)
