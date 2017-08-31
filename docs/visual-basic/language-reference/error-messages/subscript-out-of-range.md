---
title: "Subscript out of range (Visual Basic) | Microsoft Docs"
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
  - "vbrID9"
dev_langs: 
  - "VB"
ms.assetid: d0344a65-ec02-4caf-8d3c-9977392ca353
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Subscript out of range (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

An array subscript is not valid because it falls outside the allowable range. The lowest subscript value for a dimension is always 0, and the highest subscript value is returned by the `GetUpperBound` method for that dimension.  
  
### To correct this error  
  
-   Change the subscript so it falls within the valid range.  
  
## See Also  
 <xref:System.Array.GetUpperBound%2A?displayProperty=fullName>   
 [Arrays](../../../visual-basic/programming-guide/language-features/arrays/index.md)