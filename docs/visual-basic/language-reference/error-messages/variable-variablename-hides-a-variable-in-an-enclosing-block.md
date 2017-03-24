---
title: "Variable &#39;&lt;variablename&gt;&#39; hides a variable in an enclosing block | Microsoft Docs"
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
  - "vbc30616"
  - "bc30616"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30616"
ms.assetid: e7658ebc-da45-451b-a409-a0f8915f0beb
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Variable &#39;&lt;variablename&gt;&#39; hides a variable in an enclosing block
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

A variable enclosed in a block has the same name as another local variable.  
  
 **Error ID:** BC30616  
  
### To correct this error  
  
-   Rename the variable in the enclosed block so that it is not the same as any other local variables. For example:  
  
    ```  
    Dim a, b, x As Integer  
    If a = b Then  
       Dim y As Integer = 20 ' Uniquely named block variable.  
    End If  
    ```  
  
-   A common cause for this error is the use of `Catch e As Exception` inside an event handler. If this is the case, name the `Catch` block variable `ex` rather than `e`.  
  
-   Another common source of this error is an attempt to access a local variable declared within a `Try` block in a separate `Catch` block. To correct this, declare the variable outside the `Try...Catch...Finally` structure.  
  
## See Also  
 [Try...Catch...Finally Statement](../../../visual-basic/language-reference/statements/try-catch-finally-statement.md)   
 [Variable Declaration](../../../visual-basic/programming-guide/language-features/variables/variable-declaration.md)