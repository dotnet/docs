---
title: "&#39;System.STAThreadAttribute&#39; and &#39;System.MTAThreadAttribute&#39; cannot both be applied to &#39;|1&#39; | Microsoft Docs"
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
  - "bc31513"
  - "vbc31513"
helpviewer_keywords: 
  - "BC31513"
ms.assetid: 7efb4c8e-d31c-4273-9d85-8cd2bef4d120
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
# &#39;System.STAThreadAttribute&#39; and &#39;System.MTAThreadAttribute&#39; cannot both be applied to &#39;|1&#39;
The `System.STAThreadAttribute` and `System.MTAThreadAttribute` attributes are mutually exclusive.  
  
 **Error ID:** BC31513  
  
### To correct this error  
  
1.  Apply either `System.MTAThreadAttribute` or `System.STAThreadAttribute`, but not both.  
  
## See Also  
 <xref:System.STAThreadAttribute>   
 <xref:System.MTAThreadAttribute>   
 [NOT IN BUILD: Attributes in Visual Basic](http://msdn.microsoft.com/en-us/620bfc0e-4582-4c8b-8432-ebc5c3dccc22)