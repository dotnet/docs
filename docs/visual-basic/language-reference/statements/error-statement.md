---
title: "Error Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.error"
helpviewer_keywords: 
  - "Error statement [Visual Basic], syntax"
  - "Error statement [Visual Basic]"
  - "Error keyword [Visual Basic]"
  - "run-time errors [Visual Basic], codes"
  - "errors [Visual Basic], simulating"
ms.assetid: 85cd5c59-5224-4f02-aaf5-fcfefab17a29
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Error Statement
Simulates the occurrence of an error.  
  
## Syntax  
  
```  
Error errornumber  
```  
  
## Parts  
 `errornumber`  
 Required. Can be any valid error number.  
  
## Remarks  
 The `Error` statement is supported for backward compatibility. In new code, especially when creating objects, use the `Err` object's `Raise` method to generate run-time errors.  
  
 If `errornumber` is defined, the `Error` statement calls the error handler after the properties of the `Err` object are assigned the following default values:  
  
|Property|Value|  
|--------------|-----------|  
|`Number`|Value specified as argument to `Error` statement. Can be any valid error number.|  
|`Source`|Name of the current Visual Basic project.|  
|`Description`|String expression corresponding to the return value of the `Error` function for the specified `Number`, if this string exists. If the string does not exist, `Description` contains a zero-length string ("").|  
|`HelpFile`|The fully qualified drive, path, and file name of the appropriate Visual Basic Help file.|  
|`HelpContext`|The appropriate Visual Basic Help file context ID for the error corresponding to the `Number` property.|  
|`LastDLLError`|Zero.|  
  
 If no error handler exists, or if none is enabled, an error message is created and displayed from the `Err` object properties.  
  
> [!NOTE]
>  Some Visual Basic host applications cannot create objects. See your host application's documentation to determine whether it can create classes and objects.  
  
## Example  
 This example uses the `Error` statement to generate error number 11.  
  
```  
On Error Resume Next   ' Defer error handling.  
Error 11   ' Simulate the "Division by zero" error.  
```  
  
## Requirements  
 **Namespace:** [Microsoft.VisualBasic](../../../visual-basic/language-reference/runtime-library-members.md)  
  
 **Assembly:** Visual Basic Runtime Library (in Microsoft.VisualBasic.dll)  
  
## See Also  
 <xref:Microsoft.VisualBasic.ErrObject.Clear%2A>  
 <xref:Microsoft.VisualBasic.Information.Err%2A>  
 <xref:Microsoft.VisualBasic.ErrObject.Raise%2A>  
 [On Error Statement](../../../visual-basic/language-reference/statements/on-error-statement.md)  
 [Resume Statement](../../../visual-basic/language-reference/statements/resume-statement.md)  
 [Error Messages](../../../visual-basic/language-reference/error-messages/index.md)
