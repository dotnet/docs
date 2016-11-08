---
title: "&#39;End&#39; statements are not valid in the Immediate window | Microsoft Docs"
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
  - "bc30123"
  - "vbc30123"
helpviewer_keywords: 
  - "BC30123"
ms.assetid: 40a1f756-106b-4d8a-9d31-e41fdf3e7bf0
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
# &#39;End&#39; statements are not valid in the Immediate window
The `Stop` and `End` statements suspend execution and are not permitted in a debugging context.  
  
 **Error ID:** BC30123  
  
### To correct this error  
  
-   Do not issue a `End` or `Stop` statement in the **Immediate** window.  
  
## See Also  
 [Immediate Window](/visual-studio/ide/reference/immediate-window)