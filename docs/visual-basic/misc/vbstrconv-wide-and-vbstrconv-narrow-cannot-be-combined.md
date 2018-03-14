---
title: "VbStrConv.Wide and VbStrConv.Narrow cannot be combined"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrArgument_IllegalWideNarrow"
ms.assetid: a53b4e6a-36b1-4e36-b2c5-8196313ec599
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# VbStrConv.Wide and VbStrConv.Narrow cannot be combined
Your application is trying to combine the `VbStrConv` enumeration members `Wide` and `Narrow`, which are mutually exclusive.  
  
## To correct this error  
  
1.  Remove either `VbStrConv.Wide` or `VbStrConv.Narrow`.  
  
## See Also  
 <xref:System.Globalization>  
   
 [Introduction to International Applications Based on the .NET Framework](/visualstudio/ide/introduction-to-international-applications-based-on-the-dotnet-framework)
