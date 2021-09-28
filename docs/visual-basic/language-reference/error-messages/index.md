---
description: "Learn more about: Error messages in Visual Basic"
title: Visual Basic error messages
titleSuffix: ""
ms.date: 10/13/2020
helpviewer_keywords:
  - "errors [Visual Basic]"
  - "error messages"
ms.assetid: f2dda05b-baef-41f5-8bb1-598bd7cf239f
---
# Error messages in Visual Basic

When you compile or run a Visual Basic application, the following types of errors can occur:

- Compile-time errors, which occur when you compile an application.

- Run-time errors, which occur when an application is running.

For information about how to troubleshoot a specific error, see [Additional Resources for Visual Basic Programmers](../../getting-started/additional-resources.md).

## Run-time errors

If a Visual Basic application tries to perform an action that the system can't execute, a run-time error occurs, and Visual Basic throws an <xref:System.Exception> object. Visual Basic can generate custom errors of any data type, including `Exception` objects, by using the `Throw` statement. An application can identify the error by displaying the error number and message of a caught exception. If an error isn't caught, the application ends.

The code can trap and examine run-time errors. If you enclose the code that produces the error in a `Try` block, you can catch any thrown error within a matching `Catch` block. For information about how to trap errors at run time and respond to them in your code, see [Try...Catch...Finally Statement](../statements/try-catch-finally-statement.md).

## Compile-time errors

If the Visual Basic compiler encounters a problem in the code, a compile-time error occurs. In the Visual Studio code editor, you can easily identify which line of code caused the error because a wavy line appears under that line of code. The error message appears if you either point to the wavy underline or open the **Error List**, which also shows other messages.

If an identifier has a wavy underline and a short underline appears under the rightmost character, you can generate a stub for the class, constructor, method, property, field, or enum. For more information, see [Generate From Usage (Visual Studio)](/visualstudio/ide/visual-csharp-intellisense#generate-from-usage).

By resolving warnings from the Visual Basic compiler, you might be able to write code that runs faster and has fewer bugs. These warnings identify code that may cause errors when the application is run. For example, the compiler warns you if you try to invoke a member of an unassigned object variable, return from a function without setting the return value, or execute a `Try` block with errors in the logic to catch exceptions. For more information about warnings, including how to turn them on and off, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).
