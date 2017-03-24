---
title: "Cannot call friend function on object which is not an instance of defining class | Microsoft Docs"
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
  - "vbrID97"
ms.assetid: b9d821f0-8565-4f15-bb35-184789c69662
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Cannot call friend function on object which is not an instance of defining class
Either you tried to call the `Friend` procedure of a class, or you tried to access a `Friend` property or method either cross-process or cross-thread. A `Friend` procedure is callable from a module outside the class, but is part of the project in which the class is defined.  
  
### To correct this error  
  
-   Ensure that you are calling or accessing the procedure from a module that is part of the project in which the class is defined.  
  
## See Also  
 [Friend](../../visual-basic/language-reference/modifiers/friend.md)