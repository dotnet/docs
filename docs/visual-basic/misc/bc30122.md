---
title: "&#39;Stop&#39; statements are not valid in the Immediate window | Microsoft Docs"
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
  - "bc30122"
  - "vbc30122"
helpviewer_keywords: 
  - "BC30122"
ms.assetid: c4197217-23b4-4777-a93a-022ba6c7e154
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
# &#39;Stop&#39; statements are not valid in the Immediate window
The `Stop` and `End` statements suspend execution and are not permitted in a debugging context.  
  
 **Error ID:** BC30122  
  
### To correct this error  
  
-   Do not issue a `Stop` or `End` statement in the **Immediate** window.  
  
## See Also  
 [Immediate Window](/visual-studio/ide/reference/immediate-window)