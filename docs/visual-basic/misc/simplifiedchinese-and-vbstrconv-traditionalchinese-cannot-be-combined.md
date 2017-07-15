---
title: "SimplifiedChinese and VbStrConv.TraditionalChinese cannot be combined | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-visual-basic"

ms.topic: "article"
f1_keywords: 
  - "vbrArgument_StrConvSCandTC"
ms.assetid: d8e6a11b-f549-43b5-8337-0594340e1325
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent

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
# SimplifiedChinese and VbStrConv.TraditionalChinese cannot be combined
Your application is attempting to combine the `VbStrConv` enumeration members `SimplifiedChinese` and `TraditionalChinese`, which are mutually exclusive.  
  
## To correct this error  
  
-   Remove either `VbStrConv.SimplifiedChinese` or `VbStrConv.TraditionalChinese`.  
  
## See Also  
 <xref:System.Globalization>   
 [NOTINBUILD VbStrConv Enumeration](https://msdn.microsoft.com/library/3a1cfsz3(v=vs.90).aspx)   
 [Introduction to International Applications Based on the .NET Framework](/visualstudio/ide/introduction-to-international-applications-based-on-the-dotnet-framework)
