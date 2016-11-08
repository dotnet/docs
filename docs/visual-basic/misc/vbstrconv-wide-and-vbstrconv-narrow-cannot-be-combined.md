---
title: "VbStrConv.Wide and VbStrConv.Narrow cannot be combined | Microsoft Docs"
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
  - "vbrArgument_IllegalWideNarrow"
ms.assetid: a53b4e6a-36b1-4e36-b2c5-8196313ec599
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
# VbStrConv.Wide and VbStrConv.Narrow cannot be combined
Your application is trying to combine the `VbStrConv` enumeration members `Wide` and `Narrow`, which are mutually exclusive.  
  
### To correct this error  
  
1.  Remove either `VbStrConv.Wide` or `VbStrConv.Narrow`.  
  
## See Also  
 <xref:System.Globalization>   
 [NOTINBUILD VbStrConv Enumeration](http://msdn.microsoft.com/en-us/59f83dd9-6361-47df-a836-02ba9d4cb936)   
 [Introduction to International Applications Based on the .NET Framework](/visual-studio/ide/introduction-to-international-applications-based-on-the-dotnet-framework)