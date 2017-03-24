---
title: "Cannot save file to TEMP | Microsoft Docs"
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
  - "vbrID735"
ms.assetid: 1055fc15-9641-43b2-a40c-a0a9fbbb34b2
caps.latest.revision: 7
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Cannot save file to TEMP
Either a component cannot find a directory named TEMP, or the drive or partition containing the TEMP directory lacks sufficient space to save information.  
  
### To correct this error  
  
1.  Create a directory named "TEMP" and set the TEMP environment variable equal to its path.  
  
2.  Make space on the drive by erasing unnecessary files, or create a TEMP directory on another partition and set the TEMP environment variable equal to its path.  
  
## See Also  
 [Error Types](../../visual-basic/programming-guide/language-features/error-types.md)