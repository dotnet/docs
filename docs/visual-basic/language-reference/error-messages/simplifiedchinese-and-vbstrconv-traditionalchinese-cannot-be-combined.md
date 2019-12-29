---
title: "SimplifiedChinese and VbStrConv.TraditionalChinese cannot be combined"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrArgument_StrConvSCandTC"
ms.assetid: d8e6a11b-f549-43b5-8337-0594340e1325
---
# SimplifiedChinese and VbStrConv.TraditionalChinese cannot be combined
Your application is attempting to combine the `VbStrConv` enumeration members `SimplifiedChinese` and `TraditionalChinese`, which are mutually exclusive.  
  
## To correct this error  
  
- Remove either `VbStrConv.SimplifiedChinese` or `VbStrConv.TraditionalChinese`.  
  
## See also

- <xref:System.Globalization>

- [Develop globalized and localized apps](/visualstudio/ide/globalizing-and-localizing-applications)
