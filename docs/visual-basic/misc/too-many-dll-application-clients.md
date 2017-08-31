---
title: "Too many DLL application clients | Microsoft Docs"
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
  - "vbrID47"
ms.assetid: 4b87780b-67ad-4c96-9253-db954a751dad
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Too many DLL application clients
The dynamic-link library (DLL) for [!INCLUDE[vbprvb](../../includes/vbprvb-md.md)] can only accommodate access by a limited number of host applications. Your application and other applications that are [!INCLUDE[vbprvb](../../includes/vbprvb-md.md)] hosts (some of which may be accessed by your application) are all attempting to access the [!INCLUDE[vbprvb](../../includes/vbprvb-md.md)] DLL at the same time.  
  
### To correct this error  
  
-   Reduce the number of open applications accessing [!INCLUDE[vbprvb](../../includes/vbprvb-md.md)].  
  
## See Also  
 [Error Types](../../visual-basic/programming-guide/language-features/error-types.md)