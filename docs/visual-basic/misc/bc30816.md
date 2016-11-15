---
title: "&#39;&lt;membername&gt;&#39; is not declared | Microsoft Docs"
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
  - "vbc30816"
  - "bc30816"
helpviewer_keywords: 
  - "BC30816"
ms.assetid: d6704bed-bb76-47c6-ac28-09608d5e6912
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
# &#39;&lt;membername&gt;&#39; is not declared
'`<membername>`' is not declared. `Debug` object functionality is available in `System.Diagnostics.Debug` in the `System` assembly.  
  
 The specified member name could not be found.  
  
 **Error ID:** BC30816  
  
### To correct this error  
  
1.  Verify the spelling of the member.  
  
2.  Use an `Imports` statement or fully qualify members defined in other namespaces. For example, the `WriteLine` function is declared in the `System.Diagnostics.Debug` namespace.  
  
## See Also  
 [Debugging in Visual Studio](/visual-studio/debugger/debugging-in-visual-studio)