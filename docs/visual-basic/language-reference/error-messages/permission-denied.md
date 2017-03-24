---
title: "Permission denied (Visual Basic) | Microsoft Docs"
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
  - "vbrID70"
dev_langs: 
  - "VB"
ms.assetid: 71f46756-f522-4814-aab4-492bf9924245
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Permission denied (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

An attempt was made to write to a write-protected disk or to access a locked file.  
  
### To correct this error  
  
1.  To open a write-protected file, change the write-protection attribute of the file.  
  
2.  Make sure that another process has not locked the file, and wait to open the file until the other process releases it.  
  
3.  To access the registry, check that your user permissions include this type of registry access.  
  
## See Also  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)