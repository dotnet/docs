---
title: "Localizability Review"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "world-ready applications, localizability"
  - "application development [.NET Framework], localization"
  - "localizability [.NET Framework]"
  - "international applications [.NET Framework], localizability"
  - "globalization [.NET Framework], localizability"
  - "culture, localizability"
  - "localization [.NET Framework], localizability"
  - "global applications, localizability"
  - "localizing resources"
ms.assetid: 3aee2fbb-de47-4e37-8fe4-ddebb9719247
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Localizability Review
The localizability review is an intermediate step in the development of a world-ready application. It verifies that a globalized application is ready for localization and identifies any code or any aspects of the user interface that require special handling. This step also helps ensure that the localization process will not introduce any functional defects into your application. When all the issues raised by the localizability review have been addressed, your application is ready for localization. If the localizability review is thorough, you should not have to modify any source code during the localization process.  
  
 The localizability review consists of the following three checks:  
  
-   [Are the globalization recommendations implemented?](#global)  
  
-   [Are culture-sensitive features handled correctly?](#culture)  
  
-   [Have you tested your application with international data?](#test)  
  
<a name="global"></a>   
## Implementing globalization recommendations  
 If you have designed and developed your application with localization in mind, and if you have followed the recommendations discussed in the [Globalization](../../../docs/standard/globalization-localization/globalization.md) article, the localizability review will largely be a quality assurance pass. Otherwise, during this stage you should review and implement the recommendations for [globalization](../../../docs/standard/globalization-localization/globalization.md), and fix the errors in source code that prevent localization.  
  
<a name="culture"></a>   
## Handling culture-sensitive features  
 The .NET Framework does not provide programmatic support in a number of areas that vary widely by culture. In most cases, you have to write custom code to handle feature areas like the following:  
  
-   Addresses.  
  
-   Telephone numbers.  
  
-   Paper sizes.  
  
-   Units of measure used for lengths, weights, area, volume, and temperatures. Although the .NET Framework does not offer built-in support for converting between units of measure, you can use the <xref:System.Globalization.RegionInfo.IsMetric%2A?displayProperty=nameWithType> property to determine whether a particular country or region uses the metric system, as the following example illustrates.  
  
     [!code-csharp[Conceptual.Localizability#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.localizability/cs/ismetric1.cs#1)]
     [!code-vb[Conceptual.Localizability#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.localizability/vb/ismetric1.vb#1)]  
  
<a name="test"></a>   
## Testing your application  
 Before you localize your application, you should test it by using international data on international versions of the operating system. Although most of the user interface will not be localized at this point, you will be able to detect problems such as the following:  
  
-   Serialized data that does not deserialize correctly across operating system versions.  
  
-   Numeric data that does not reflect the conventions of the current culture. For example, numbers may be displayed with inaccurate group separators, decimal separators, or currency symbols.  
  
-   Date and time data that does not reflect the conventions of the current culture. For example, numbers that represent the month and day may appear in the wrong order, date separators may be incorrect, or time zone information may be incorrect.  
  
-   Resources that cannot be found because you have not identified a default culture for your application.  
  
-   Strings that are displayed in an unusual order for the specific culture.  
  
-   String comparisons or comparisons for equality that return unexpected results.  
  
 If you've followed the globalization recommendations when developing your application, handled culture-sensitive features correctly, and identified and addressed the localization issues that arose during testing, you can proceed to the next step, [Localization](../../../docs/standard/globalization-localization/localization.md).  
  
## See Also  
 [Globalization and Localization](../../../docs/standard/globalization-localization/index.md)  
 [Localization](../../../docs/standard/globalization-localization/localization.md)  
 [Globalization](../../../docs/standard/globalization-localization/globalization.md)  
 [Resources in Desktop Apps](../../../docs/framework/resources/index.md)
