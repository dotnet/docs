---
title: "Error Types (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "exceptions, types"
  - "errors [Visual Basic], types"
  - "errors [Visual Basic], logic"
  - "errors [Visual Basic], syntax"
  - "logic errors [Visual Basic], Visual Basic"
  - "run-time errors [Visual Basic], types of errors"
  - "syntax errors [Visual Basic], Visual Basic"
ms.assetid: 3048aabf-8c97-4e13-9150-853769cb5f6f
---
# Error Types (Visual Basic)
In Visual Basic, errors fall into one of three categories: syntax errors, run-time errors, and logic errors.

## Syntax Errors
 *Syntax errors* are those that appear while you write code. If you're using Visual Studio, Visual Basic checks your code as you type it in the **Code Editor** window and alerts you if you make a mistake, such as misspelling a word or using a language element improperly. If you compile from the command line, Visual Basic displays a compiler error with information about the syntax error. Syntax errors are the most common type of errors. You can fix them easily in the coding environment as soon as they occur.

> [!NOTE]
> The `Option Explicit` statement is one means of avoiding syntax errors. It forces you to declare, in advance, all the variables to be used in the application. Therefore, when those variables are used in the code, any typographic errors are caught immediately and can be fixed.

## Run-Time Errors
 *Run-time errors* are those that appear only after you compile and run your code. These involve code that may appear to be correct in that it has no syntax errors, but that will not execute. For example, you might correctly write a line of code to open a file. But if the file does not exist, the application cannot open the file, and it throws an exception. You can fix most run-time errors by rewriting the faulty code or by using [exception handling](../../language-reference/statements/try-catch-finally-statement.md), and then recompiling and rerunning it.
  
## Logic Errors
 *Logic errors* are those that appear once the application is in use. They are most often faulty assumptions made by the developer, or unwanted or unexpected results in response to user actions. For example, a mistyped key might provide incorrect information to a method, or you may assume that a valid value is always supplied to a method when that is not the case. Although logic errors can be handled by using [exception handling](../../language-reference/statements/try-catch-finally-statement.md) (for example, by testing whether an argument is `Nothing` and throwing an <xref:System.ArgumentNullException>), most commonly they should be addressed by correcting the error in logic and recompiling the application.

## See also

- [Try...Catch...Finally Statement](../../../visual-basic/language-reference/statements/try-catch-finally-statement.md)
- [Debugger Basics](/visualstudio/debugger/debugger-basics)
