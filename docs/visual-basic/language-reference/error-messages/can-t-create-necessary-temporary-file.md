---
title: "Can&#39;t create necessary temporary file | Microsoft Docs"
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
  - "vbrID322"
dev_langs: 
  - "VB"
ms.assetid: 53617b5b-eb06-4188-b4c2-8607cb9fbc79
caps.latest.revision: 6
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Can&#39;t create necessary temporary file
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Either the drive is full that contains the directory specified by the TEMP environment variable, or the TEMP environment variable specifies an invalid or read-only drive or directory.  
  
### To correct this error  
  
1.  Delete files from the drive, if full.  
  
2.  Specify a different drive in the TEMP environment variable.  
  
3.  Specify a valid drive for the TEMP environment variable.  
  
4.  Remove the read-only restriction from the currently specified drive or directory.  
  
## See Also  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)