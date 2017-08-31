---
title: "Statement is not valid in a namespace | Microsoft Docs"
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
  - "vbc30001"
  - "bc30001"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC30001"
ms.assetid: 43c1b509-15f9-4e91-bcad-90bcb5f6f191
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Statement is not valid in a namespace
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The statement cannot appear at the level of a namespace. The only declarations allowed at namespace level are module, interface, class, delegate, enumeration, and structure declarations.  
  
 **Error ID:** BC30001  
  
### To correct this error  
  
-   Move the statement to a location within a module, class, interface, structure, enumeration, or delegate definition.  
  
## See Also  
 [Scope in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/scope.md)   
 [Namespaces in Visual Basic](../../../visual-basic/programming-guide/program-structure/namespaces.md)