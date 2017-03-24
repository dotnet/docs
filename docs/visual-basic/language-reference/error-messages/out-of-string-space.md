---
title: "Out of string space (Visual Basic) | Microsoft Docs"
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
  - "vbrID14"
dev_langs: 
  - "VB"
ms.assetid: 16681c75-a400-422d-9351-c691d3c7614e
caps.latest.revision: 10
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Out of string space (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

With Visual Basic, you can use very large strings. However, the requirements of other programs and the way you work with your strings can still cause this error.  
  
### To correct this error  
  
1.  Make sure that an expression requiring temporary string creation during evaluation is not causing the error.  
  
2.  Remove any unnecessary applications from memory to create more space.  
  
## See Also  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)   
 [String Manipulation Summary](../../../visual-basic/language-reference/keywords/string-manipulation-summary.md)