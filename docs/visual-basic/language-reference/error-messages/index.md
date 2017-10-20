---
title: "Error Messages (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "errors [Visual Basic]"
  - "error messages"
  - "trappable errors"
  - "errors [Visual Basic], trappable"
ms.assetid: f2dda05b-baef-41f5-8bb1-598bd7cf239f
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# Error Messages (Visual Basic)
When you write, compile, or run a Visual Basic application, the following types of errors can occur:  
  
1.  Design-time errors, which occur when you write an application in Visual Studio.  
  
2.  Compile-time errors, which occur when you compile an application in Visual Studio or at a command prompt.  
  
3.  Run-time errors, which occur when you run an application in Visual Studio or as a stand-alone executable file.  
  
 For information about how to troubleshoot a specific error, see [Additional Resources for Visual Basic Programmers](../../../visual-basic/getting-started/additional-resources.md).  
  
## Run Time Errors  
 If a Visual Basic application tries to perform an action that the system can't execute, a run-time error occurs, and [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] throws an `Exception` object. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] can generate custom errors of any data type, including `Exception` objects, by using the `Throw` statement. An application can identify the error by displaying the error number and message of a caught exception. If an error isn't caught, the application ends.  
  
 The code can trap and examine run-time errors. If you enclose the code that produces the error in a `Try` block, you can catch any thrown error within a matching `Catch` block. For information about how to trap errors at run time and respond to them in your code, see [Try...Catch...Finally Statement](../../../visual-basic/language-reference/statements/try-catch-finally-statement.md).  
  
## Compile Time Errors  
 If the Visual Basic compiler encounters a problem in the code, a compile-time error occurs. In the Code Editor, you can easily identify which line of code caused the error because a wavy line appears under that line of code. The error message appears if you either point to the wavy underline or open the **Error List**, which also shows other messages.  
  
 If an identifier has a wavy underline and a short underline appears under the rightmost character, you can generate a stub for the class, constructor, method, property, field or enum. For more information, see [Generate From Usage](/visualstudio/ide/visual-csharp-intellisense#generate-from-usage).
  
 By resolving warnings from the Visual Basic compiler, you might be able to write code that runs faster and has fewer bugs. These warnings identify code that may cause errors when the application is run. For example, the compiler warns you if you try to invoke a member of an unassigned object variable, return from a function without setting the return value, or execute a `Try` block with errors in the logic to catch exceptions. For more information about warnings, including how to turn them on and off, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).
