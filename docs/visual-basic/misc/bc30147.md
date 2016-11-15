---
title: "&#39;Return&#39; statements are not valid in the Immediate window | Microsoft Docs"
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
  - "bc30147"
  - "vbc30147"
helpviewer_keywords: 
  - "BC30147"
ms.assetid: ed3647ce-1450-4c60-96c6-2bfe49cf62d5
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# &#39;Return&#39; statements are not valid in the Immediate window
The `Return` statement performs branching and is not permitted in a debugging context.  
  
 **Error ID:** BC30147  
  
### To correct this error  
  
-   Do not issue a `Return` statement in the **Immediate** window.  
  
## See Also  
 [Immediate Window](/visual-studio/ide/reference/immediate-window)