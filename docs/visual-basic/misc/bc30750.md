---
title: "Information for the type of &#39;&lt;typename&gt;&#39; has not been loaded into the runtime | Microsoft Docs"
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
  - "vbc30750"
  - "bc30750"
helpviewer_keywords: 
  - "BC30750"
ms.assetid: b0f074f9-571d-48f8-b334-4fd34b61cd89
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
# Information for the type of &#39;&lt;typename&gt;&#39; has not been loaded into the runtime
A type was referenced that has not been loaded by the runtime.  
  
 **Error ID:** BC30750  
  
### To correct this error  
  
1.  Restructure your code so the type is defined within the current scope.  
  
2.  Verify that the member is defined and that you have spelled the member name correctly.  
  
3.  Try accessing one of the members declared in the module. In some cases, the debugging environment cannot locate members because the modules where they are declared are not loaded.  
  
## See Also  
 [Debugging in Visual Studio](/visual-studio/debugger/debugging-in-visual-studio)