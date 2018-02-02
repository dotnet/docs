---
title: "Statement cannot end a block outside of a line &#39;If&#39; statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc32005"
  - "bc32005"
helpviewer_keywords: 
  - "BC32005"
ms.assetid: 4039f51b-e0ee-4789-a89b-45d06de06b5d
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Statement cannot end a block outside of a line &#39;If&#39; statement
A single-line `If` statement contains several statements separated by colons (:), one of which is an `End` statement for a control block outside the single-line `If`. Single-line `If` statements do not use the `End If` statement.  
  
 **Error ID:** BC32005  
  
## To correct this error  
  
-   Move the single-line `If` statement outside the control block that contains the `End If` statement.  
  
## See Also  
 [If...Then...Else Statement](../../../visual-basic/language-reference/statements/if-then-else-statement.md)
