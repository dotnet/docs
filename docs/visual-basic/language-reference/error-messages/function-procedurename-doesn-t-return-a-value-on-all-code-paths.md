---
title: "Function &#39;&lt;procedurename&gt;&#39; doesn&#39;t return a value on all code paths"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "bc42105"
  - "vbc42105"
helpviewer_keywords: 
  - "BC42105"
ms.assetid: b6929bf4-a365-4a70-8dc9-6b0fc09e1468
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# Function &#39;&lt;procedurename&gt;&#39; doesn&#39;t return a value on all code paths
Function '\<procedurename>' doesn't return a value on all code paths. Are you missing a 'Return' statement?  
  
 A `Function` procedure has at least one possible path through its code that does not return a value.  
  
 You can return a value from a `Function` procedure in any of the following ways:  
  
-   Include the value in a [Return Statement](../../../visual-basic/language-reference/statements/return-statement.md).  
  
-   Assign the value to the `Function` procedure name and then perform an `Exit Function` statement.  
  
-   Assign the value to the `Function` procedure name and then perform the `End Function` statement.  
  
 If control passes to `Exit Function` or `End Function` and you have not assigned any value to the procedure name, the procedure returns the default value of the return data type. For more information, see "Behavior" in [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md).  
  
 By default, this message is a warning. For more information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visualstudio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC42105  
  
## To correct this error  
  
-   Check your control flow logic and make sure you assign a value before every statement that causes a return.  
  
     It is easier to guarantee that every return from the procedure returns a value if you always use the `Return` statement. If you do this, the last statement before `End Function` should be a `Return` statement.  
  
## See Also  
 [Function Procedures](../../../visual-basic/programming-guide/language-features/procedures/function-procedures.md)  
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)  
 [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic)
