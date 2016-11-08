---
title: "&#39;GoTo&#39; statements are not valid in the Immediate window | Microsoft Docs"
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
  - "bc30133"
  - "vbc30133"
helpviewer_keywords: 
  - "BC30133"
ms.assetid: e5901616-6aec-4718-b452-90b2143301b0
caps.latest.revision: 9
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
# &#39;GoTo&#39; statements are not valid in the Immediate window
The `GoTo` statement performs branching and is not permitted in a debugging context.  
  
 **Error ID:** BC30133  
  
### To correct this error  
  
-   Do not issue a `GoTo` statement in the **Immediate** window.  
  
## See Also  
 [Immediate Window](/visual-studio/ide/reference/immediate-window)