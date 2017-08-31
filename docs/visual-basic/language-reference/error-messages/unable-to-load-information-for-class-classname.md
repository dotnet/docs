---
title: "Unable to load information for class &#39;&lt;classname&gt;&#39; | Microsoft Docs"
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
  - "vbc30712"
  - "bc30712"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30712"
ms.assetid: c7ffbd6d-05c6-4261-b44b-1bcd521bb350
caps.latest.revision: 10
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Unable to load information for class &#39;&lt;classname&gt;&#39;
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

A reference was made to a class that is not available.  
  
 **Error ID:** BC30712  
  
### To correct this error  
  
1.  Verify that the class is defined and that you spelled the name correctly.  
  
2.  Try accessing one of the members declared in the module. In some cases, the debugging environment cannot locate members because the modules where they are declared have not been loaded yet.  
  
## See Also  
 [Debugging in Visual Studio](/visual-studio/debugger/debugging-in-visual-studio)