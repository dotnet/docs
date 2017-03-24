---
title: "Function &#39;&lt;procedurename&gt;&#39; doesn&#39;t return a value on all code paths | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "bc42105"
  - "vbc42105"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC42105"
ms.assetid: b6929bf4-a365-4a70-8dc9-6b0fc09e1468
caps.latest.revision: 12
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Function &#39;&lt;procedurename&gt;&#39; doesn&#39;t return a value on all code paths
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Function '\<procedurename>' doesn't return a value on all code paths. Are you missing a 'Return' statement?  
  
 A `Function` procedure has at least one possible path through its code that does not return a value.  
  
 You can return a value from a `Function` procedure in any of the following ways:  
  
-   Include the value in a [Return Statement](../../../visual-basic/language-reference/statements/return-statement.md).  
  
-   Assign the value to the `Function` procedure name and then perform an `Exit Function` statement.  
  
-   Assign the value to the `Function` procedure name and then perform the `End Function` statement.  
  
 If control passes to `Exit Function` or `End Function` and you have not assigned any value to the procedure name, the procedure returns the default value of the return data type. For more information, see "Behavior" in [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md).  
  
 By default, this message is a warning. For more information on hiding warnings or treating warnings as errors, see [Configuring Warnings in Visual Basic](/visual-studio/ide/configuring-warnings-in-visual-basic).  
  
 **Error ID:** BC42105  
  
### To correct this error  
  
-   Check your control flow logic and make sure you assign a value before every statement that causes a return.  
  
     It is easier to guarantee that every return from the procedure returns a value if you always use the `Return` statement. If you do this, the last statement before `End Function` should be a `Return` statement.  
  
## See Also  
 [Function Procedures](../../../visual-basic/programming-guide/language-features/procedures/function-procedures.md)   
 [Function Statement](../../../visual-basic/language-reference/statements/function-statement.md)   
 [Compile Page, Project Designer (Visual Basic)](/visual-studio/ide/reference/compile-page-project-designer-visual-basic)