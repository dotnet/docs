---
title: "&#39;&lt;name&gt;&#39; cannot refer to itself through its default instance, use &#39;Me&#39; instead | Microsoft Docs"
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
  - "vbc31139"
  - "bc31139"
helpviewer_keywords: 
  - "BC31139"
ms.assetid: 459e5d5a-d526-4cd0-934e-96e4e1eb51bb
caps.latest.revision: 10
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
# &#39;&lt;name&gt;&#39; cannot refer to itself through its default instance, use &#39;Me&#39; instead
An attempt has been made from inside a form to refer to that form as a default instance. This can cause the form to call itself recursively.  
  
 In most circumstances, you should use `Me` to when referring to the current instance of the form, instead of using the default instance.  
  
 **Error ID:** BC31139  
  
### To correct this error  
  
-   Use `Me` to refer to the object.  
  
## See Also  
 [Debugger Basics](/visual-studio/debugger/debugger-basics)