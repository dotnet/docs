---
title: "Constant expression not representable in type &#39;&lt;typename&gt;&#39; | Microsoft Docs"
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
  - "bc30439"
  - "vbc30439"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30439"
ms.assetid: 0a842906-3bc5-4946-8a37-3e3da883ef63
caps.latest.revision: 10
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Constant expression not representable in type &#39;&lt;typename&gt;&#39;
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

You are trying to evaluate a constant that will not fit into the target type, usually because it is overflowing the range.  
  
 **Error ID:** BC30439  
  
### To correct this error  
  
1.  Change the target type to one that can handle the constant.  
  
## See Also  
 [Constants Overview](../../../visual-basic/programming-guide/language-features/constants-enums/constants-overview.md)   
 [Constants and Enumerations](../../../visual-basic/language-reference/constants-and-enumerations.md)