---
title: "SimplifiedChinese and VbStrConv.TraditionalChinese cannot be combined"
ms.date: 07/20/2015
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
---
# SimplifiedChinese and VbStrConv.TraditionalChinese cannot be combined
Your application is attempting to combine the `VbStrConv` enumeration members `SimplifiedChinese` and `TraditionalChinese`, which are mutually exclusive.  
  
## To correct this error  
  
-   Remove either `VbStrConv.SimplifiedChinese` or `VbStrConv.TraditionalChinese`.  
  
## See Also  
 <xref:System.Globalization>  
   
 [Introduction to International Applications Based on the .NET Framework](/visualstudio/ide/introduction-to-international-applications-based-on-the-dotnet-framework)
