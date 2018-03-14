---
title: "On Error Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.OnError"
helpviewer_keywords: 
  - "Visual Basic code, control flow"
  - "Resume Next statement [Visual Basic]"
  - "errors [Visual Basic], trapping"
  - "error handling, On Error statement"
  - "Next statement [Visual Basic], On Error"
  - "control flow [Visual Basic], branching"
  - "Error keyword [Visual Basic]"
  - "execution [Visual Basic], conditional"
  - "Resume statement [Visual Basic], and On Error statement"
  - "Error statement [Visual Basic], and On Error statement"
  - "GoTo statement [Visual Basic], and On Error statement"
  - "branching [Visual Basic], on error"
  - "conditional statements [Visual Basic], On Error"
  - "On Error statement [Visual Basic], syntax"
  - "On keyword [Visual Basic]"
  - "run-time errors [Visual Basic], handling"
  - "On Error statement [Visual Basic]"
ms.assetid: ff947930-fb84-40cf-bd66-1ea219561d5c
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# On Error Statement (Visual Basic)
Enables an error-handling routine and specifies the location of the routine within a procedure; can also be used to disable an error-handling routine.  
  
 Without error handling, any run-time error that occurs is fatal: an error message is displayed, and execution stops.  
  
 Whenever possible, we suggest you use structured exception handling in your code, rather than using unstructured exception handling and the `On Error` statement. For more information, see [Try...Catch...Finally Statement](../../../visual-basic/language-reference/statements/try-catch-finally-statement.md).  
  
> [!NOTE]
>  The `Error` keyword is also used in the [Error Statement](../../../visual-basic/language-reference/statements/error-statement.md), which is supported for backward compatibility.  
  
## Syntax  
  
```  
On Error { GoTo [ line | 0 | -1 ] | Resume Next }  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`GoTo` `line`|Enables the error-handling routine that starts at the line specified in the required `line` argument. The `line` argument is any line label or line number. If a run-time error occurs, control branches to the specified line, making the error handler active. The specified line must be in the same procedure as the `On Error` statement, or a compile-time error will occur.|  
|`GoTo` 0|Disables enabled error handler in the current procedure and resets it to `Nothing`.|  
|`GoTo` -1|Disables enabled exception in the current procedure and resets it to `Nothing`.|  
|`Resume Next`|Specifies that when a run-time error occurs, control goes to the statement immediately following the statement where the error occurred, and execution continues from that point. Use this form rather than `On Error GoTo` when accessing objects.|  
  
## Remarks  
  
> [!NOTE]
>  We recommend that you use structured exception handling in your code whenever possible, rather than using unstructured exception handling and the `On Error` statement. For more information, see [Try...Catch...Finally Statement](../../../visual-basic/language-reference/statements/try-catch-finally-statement.md).  
  
 An "enabled" error handler is one that is turned on by an `On Error` statement. An "active" error handler is an enabled handler that is in the process of handling an error.  
  
 If an error occurs while an error handler is active (between the occurrence of the error and a `Resume`, `Exit Sub`, `Exit Function`, or `Exit Property` statement), the current procedure's error handler cannot handle the error. Control returns to the calling procedure.  
  
 If the calling procedure has an enabled error handler, it is activated to handle the error. If the calling procedure's error handler is also active, control passes back through previous calling procedures until an enabled, but inactive, error handler is found. If no such error handler is found, the error is fatal at the point at which it actually occurred.  
  
 Each time the error handler passes control back to a calling procedure, that procedure becomes the current procedure. Once an error is handled by an error handler in any procedure, execution resumes in the current procedure at the point designated by the `Resume` statement.  
  
> [!NOTE]
>  An error-handling routine is not a `Sub` procedure or a `Function` procedure. It is a section of code marked by a line label or a line number.  
  
## Number Property  
 Error-handling routines rely on the value in the `Number` property of the `Err` object to determine the cause of the error. The routine should test or save relevant property values in the `Err` object before any other error can occur or before a procedure that might cause an error is called. The property values in the `Err` object reflect only the most recent error. The error message associated with `Err.Number` is contained in `Err.Description`.  
  
## Throw Statement  
 An error that is raised with the `Err.Raise` method sets the `Exception` property to a newly created instance of the <xref:System.Exception> class. In order to support the raising of exceptions of derived exception types, a `Throw` statement is supported in the language. This takes a single parameter that is the exception instance to be thrown. The following example shows how these features can be used with the existing exception handling support:  
  
 [!code-vb[VbVbalrErrorHandling#17](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/on-error-statement_1.vb)]  
  
 Notice that the `On Error GoTo` statement traps all errors, regardless of the exception class.  
  
## On Error Resume Next  
 `On Error Resume Next` causes execution to continue with the statement immediately following the statement that caused the run-time error, or with the statement immediately following the most recent call out of the procedure containing the `On Error Resume Next` statement. This statement allows execution to continue despite a run-time error. You can place the error-handling routine where the error would occur rather than transferring control to another location within the procedure. An `On Error Resume Next` statement becomes inactive when another procedure is called, so you should execute an `On Error Resume Next` statement in each called routine if you want inline error handling within that routine.  
  
> [!NOTE]
>  The `On Error Resume Next` construct may be preferable to `On Error GoTo` when handling errors generated during access to other objects. Checking `Err` after each interaction with an object removes ambiguity about which object was accessed by the code. You can be sure which object placed the error code in `Err.Number`, as well as which object originally generated the error (the object specified in `Err.Source`).  
  
## On Error GoTo 0  
 `On Error GoTo 0` disables error handling in the current procedure. It doesn't specify line 0 as the start of the error-handling code, even if the procedure contains a line numbered 0. Without an `On Error GoTo 0` statement, an error handler is automatically disabled when a procedure is exited.  
  
## On Error GoTo -1  
 `On Error GoTo -1` disables the exception in the current procedure. It does not specify line -1 as the start of the error-handling code, even if the procedure contains a line numbered -1. Without an `On Error GoTo -1` statement, an exception is automatically disabled when a procedure is exited.  
  
 To prevent error-handling code from running when no error has occurred, place an `Exit Sub`, `Exit Function`, or `Exit Property` statement immediately before the error-handling routine, as in the following fragment:  
  
 [!code-vb[VbVbalrErrorHandling#18](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/on-error-statement_2.vb)]  
  
 Here, the error-handling code follows the `Exit Sub` statement and precedes the `End Sub` statement to separate it from the procedure flow. You can place error-handling code anywhere in a procedure.  
  
## Untrapped Errors  
 Untrapped errors in objects are returned to the controlling application when the object is running as an executable file. Within the development environment, untrapped errors are returned to the controlling application only if the proper options are set. See your host application's documentation for a description of which options should be set during debugging, how to set them, and whether the host can create classes.  
  
 If you create an object that accesses other objects, you should try to handle any unhandled errors they pass back. If you cannot, map the error codes in `Err.Number` to one of your own errors and then pass them back to the caller of your object. You should specify your error by adding your error code to the `VbObjectError` constant. For example, if your error code is 1052, assign it as follows:  
  
 [!code-vb[VbVbalrErrorHandling#19](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/on-error-statement_3.vb)]  
  
> [!CAUTION]
>  System errors during calls to Windows dynamic-link libraries (DLLs) do not raise exceptions and cannot be trapped with Visual Basic error trapping. When calling DLL functions, you should check each return value for success or failure (according to the API specifications), and in the event of a failure, check the value in the `Err` object's `LastDLLError` property.  
  
## Example  
 This example first uses the `On Error GoTo` statement to specify the location of an error-handling routine within a procedure. In the example, an attempt to divide by zero generates error number 6. The error is handled in the error-handling routine, and control is then returned to the statement that caused the error. The `On Error GoTo 0` statement turns off error trapping. Then the `On Error Resume Next` statement is used to defer error trapping so that the context for the error generated by the next statement can be known for certain. Note that `Err.Clear` is used to clear the `Err` object's properties after the error is handled.  
  
 [!code-vb[VbVbalrErrorHandling#20](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/on-error-statement_4.vb)]  
  
## Requirements  
 **Namespace:** [Microsoft.VisualBasic](../../../visual-basic/language-reference/runtime-library-members.md)  
  
 **Assembly:** Visual Basic Runtime Library (in Microsoft.VisualBasic.dll)  
  
## See Also  
 <xref:Microsoft.VisualBasic.Information.Err%2A>  
 <xref:Microsoft.VisualBasic.ErrObject.Number%2A>  
 <xref:Microsoft.VisualBasic.ErrObject.Description%2A>  
 <xref:Microsoft.VisualBasic.ErrObject.LastDllError%2A>  
 [End Statement](../../../visual-basic/language-reference/statements/end-statement.md)  
 [Exit Statement](../../../visual-basic/language-reference/statements/exit-statement.md)  
 [Resume Statement](../../../visual-basic/language-reference/statements/resume-statement.md)  
 [Error Messages](../../../visual-basic/language-reference/error-messages/index.md)  
 [Try...Catch...Finally Statement](../../../visual-basic/language-reference/statements/try-catch-finally-statement.md)
