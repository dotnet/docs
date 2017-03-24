---
title: "&#39;#ElseIf&#39; must be preceded by a matching &#39;#If&#39; or &#39;#ElseIf&#39; | Microsoft Docs"
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
  - "vbc30014"
  - "bc30014"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30014"
ms.assetid: 5215585e-2efa-485a-9efe-9833a1cc83a0
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# &#39;#ElseIf&#39; must be preceded by a matching &#39;#If&#39; or &#39;#ElseIf&#39;
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

`#ElseIf` is a conditional compilation directive. An `#ElseIf` clause must be preceded by a matching `#If` or `#ElseIf` clause.  
  
 **Error ID:** BC30014  
  
### To correct this error  
  
1.  Check that a preceding `#If` or `#ElseIf` has not been separated from this `#ElseIf` by an intervening conditional compilation block or an incorrectly placed `#End If`.  
  
2.  If the `#ElseIf` is preceded by a `#Else` directive, either remove the `#Else` or change it to an `#ElseIf`.  
  
3.  If everything else is in order, add an `#If` directive to the beginning of the conditional compilation block.  
  
## See Also  
 [#If...Then...#Else Directives](../../../visual-basic/language-reference/directives/if-then-else-directives.md)