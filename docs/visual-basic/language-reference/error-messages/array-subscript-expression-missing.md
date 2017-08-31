---
title: "Array subscript expression missing | Microsoft Docs"
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
  - "bc30306"
  - "vbc30306"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30306"
ms.assetid: 3c0d9732-ee37-436f-a1df-29d65712f48a
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Array subscript expression missing
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

An array initialization leaves out one or more of the subscripts that define the array bounds. For example, the statement might contain the expression `myArray (5,5,,10)`, which leaves out the third subscript.  
  
 **Error ID:** BC30306  
  
### To correct this error  
  
-   Supply the missing subscript.  
  
## See Also  
 [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md)