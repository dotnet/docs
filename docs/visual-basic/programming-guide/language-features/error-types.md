---
title: "Error Types (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "exceptions, types"
  - "errors [Visual Basic], types"
  - "errors [Visual Basic], logic"
  - "errors [Visual Basic], syntax"
  - "logic errors [Visual Basic], Visual Basic"
  - "run-time errors [Visual Basic], types of errors"
  - "syntax errors [Visual Basic], Visual Basic"
ms.assetid: 3048aabf-8c97-4e13-9150-853769cb5f6f
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Error Types (Visual Basic)
In [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], errors (also called *exceptions*) fall into one of three categories: syntax errors, run-time errors, and logic errors.  
  
## Syntax Errors  
 *Syntax errors* are those that appear while you write code. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] checks your code as you type it in the **Code Editor** window and alerts you if you make a mistake, such as misspelling a word or using a language element improperly. Syntax errors are the most common type of errors. You can fix them easily in the coding environment as soon as they occur.  
  
> [!NOTE]
>  The `Option Explicit` statement is one means of avoiding syntax errors. It forces you to declare, in advance, all the variables to be used in the application. Therefore, when those variables are used in the code, any typographic errors are caught immediately and can be fixed.  
  
## Run-Time Errors  
 *Run-time errors* are those that appear only after you compile and run your code. These involve code that may appear to be correct in that it has no syntax errors, but that will not execute. For example, you might correctly write a line of code to open a file. But if the file is corrupted, the application cannot carry out the `Open` function, and it stops running. You can fix most run-time errors by rewriting the faulty code, and then recompiling and rerunning it.  
  
## Logic Errors  
 *Logic errors* are those that appear once the application is in use. They are most often unwanted or unexpected results in response to user actions. For example, a mistyped key or other outside influence might cause your application to stop working within expected parameters, or altogether. Logic errors are generally the hardest type to fix, since it is not always clear where they originate.  
  
## See Also  
 [Try...Catch...Finally Statement](../../../visual-basic/language-reference/statements/try-catch-finally-statement.md)  
 [Debugger Basics](/visualstudio/debugger/debugger-basics)
