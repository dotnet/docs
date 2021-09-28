---
description: "Learn more about: Resume Statement"
title: "Resume Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.Resume"
  - "vb.ResumeNext"
helpviewer_keywords: 
  - "Next statement [Visual Basic], Resume"
  - "Resume Next statement [Visual Basic]"
  - "execution [Visual Basic], resuming"
  - "run-time errors [Visual Basic], resuming after"
  - "Resume statement [Visual Basic], syntax"
  - "errors [Visual Basic], resuming after"
  - "Error statement [Visual Basic], and Resume statement"
  - "execution"
  - "Resume statement [Visual Basic]"
ms.assetid: e24d058b-1a5c-4274-acb9-7d295d3ea537
---
# Resume Statement

Resumes execution after an error-handling routine is finished.  
  
 We suggest that you use structured exception handling in your code whenever possible, rather than using unstructured exception handling and the `On Error` and `Resume` statements. For more information, see [Try...Catch...Finally Statement](try-catch-finally-statement.md).  
  
## Syntax  
  
```vb  
Resume [ Next | line ]  
```  
  
## Parts  

 `Resume`  
 Required. If the error occurred in the same procedure as the error handler, execution resumes with the statement that caused the error. If the error occurred in a called procedure, execution resumes at the statement that last called out of the procedure containing the error-handling routine.  
  
 `Next`  
 Optional. If the error occurred in the same procedure as the error handler, execution resumes with the statement immediately following the statement that caused the error. If the error occurred in a called procedure, execution resumes with the statement immediately following the statement that last called out of the procedure containing the error-handling routine (or `On Error Resume Next` statement).  
  
 `line`  
 Optional. Execution resumes at the line specified in the required `line` argument. The `line` argument is a line label or line number and must be in the same procedure as the error handler.  
  
## Remarks  
  
> [!NOTE]
> We recommend that you use structured exception handling in your code whenever possible, rather than using unstructured exception handling and the `On Error` and `Resume` statements. For more information, see [Try...Catch...Finally Statement](try-catch-finally-statement.md).  
  
 If you use a `Resume` statement anywhere other than in an error-handling routine, an error occurs.  
  
 The `Resume` statement cannot be used in any procedure that contains a `Try...Catch...Finally` statement.  
  
## Example  

 This example uses the `Resume` statement to end error handling in a procedure and then resume execution with the statement that caused the error. Error number 55 is generated to illustrate use of the `Resume` statement.  
  
 [!code-vb[VbVbalrErrorHandling#16](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrErrorHandling/VB/Class1.vb#16)]  
  
## Requirements  

 **Namespace:** [Microsoft.VisualBasic](../runtime-library-members.md)  
  
 **Assembly:** Visual Basic Runtime Library (in Microsoft.VisualBasic.dll)  
  
## See also

- [Try...Catch...Finally Statement](try-catch-finally-statement.md)
- [Error Statement](error-statement.md)
- [On Error Statement](on-error-statement.md)
