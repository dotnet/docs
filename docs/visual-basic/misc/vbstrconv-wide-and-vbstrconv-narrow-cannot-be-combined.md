---
description: "Learn more about: VbStrConv.Wide and VbStrConv.Narrow cannot be combined"
title: "VbStrConv.Wide and VbStrConv.Narrow cannot be combined"
ms.date: 07/20/2015
f1_keywords: 
  - "vbrArgument_IllegalWideNarrow"
ms.assetid: a53b4e6a-36b1-4e36-b2c5-8196313ec599
---
# VbStrConv.Wide and VbStrConv.Narrow cannot be combined

Your application is trying to combine the `VbStrConv` enumeration members `Wide` and `Narrow`, which are mutually exclusive.  
  
## To correct this error  
  
1. Remove either `VbStrConv.Wide` or `VbStrConv.Narrow`.  
  
## See also

- <xref:System.Globalization>

- [Develop globalized and localized apps](/visualstudio/ide/globalizing-and-localizing-applications)
