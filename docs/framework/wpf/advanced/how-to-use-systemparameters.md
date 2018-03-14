---
title: "How to: Use SystemParameters"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "classes [WPF], SystemParameters"
ms.assetid: 02e7a5de-94eb-4953-b91c-52e6c872ad5b
caps.latest.revision: 24
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use SystemParameters
This example shows how to access and use the properties of <xref:System.Windows.SystemParameters> in order to style or customize a button.  
  
## Example  
 System resources expose several system based settings as resources in order to help you create visuals that are consistent with system settings. <xref:System.Windows.SystemParameters> is a class that contains both system parameter value properties, and resource keys that bind to the values. For example, <xref:System.Windows.SystemParameters.FullPrimaryScreenHeight%2A> is a <xref:System.Windows.SystemParameters> property value and <xref:System.Windows.SystemParameters.FullPrimaryScreenHeightKey%2A> is the corresponding resource key.  
  
 In [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you can use the members of <xref:System.Windows.SystemParameters> as either a static property usage, or a dynamic resource references (with the static property value as the key). Use a dynamic resource reference if you want the system based value to update automatically while the application runs; otherwise, use a static reference. Resource keys have the suffix `Key` appended to the property name.  
  
 The following example shows how to access and use the static values of <xref:System.Windows.SystemParameters> to style or customize a button. This markup example sizes a button by applying <xref:System.Windows.SystemParameters> values to a button.  
  
 [!code-xaml[SystemRes_snip#ParameterStaticResources](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SystemRes_snip/CSharp/Pane1.xaml#parameterstaticresources)]  
  
 To use the values of <xref:System.Windows.SystemParameters> in code, you do not have to use either static references or dynamic resource references. Instead, use the values of the <xref:System.Windows.SystemParameters> class. Although the non-key properties are apparently defined as static properties, the runtime behavior of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] as hosted by the system will reevaluate the properties in realtime, and will properly account for user-driven changes to system values. The following example shows how to set the width and height of a button by using <xref:System.Windows.SystemParameters> values.  
  
 [!code-csharp[SystemRes_snip#ParameterResourcesCode](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SystemRes_snip/CSharp/Pane1.xaml.cs#parameterresourcescode)]
 [!code-vb[SystemRes_snip#ParameterResourcesCode](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/SystemRes_snip/VisualBasic/Pane1.xaml.vb#parameterresourcescode)]  
  
## See Also  
 <xref:System.Windows.SystemParameters>  
 [Paint an Area with a System Brush](../../../../docs/framework/wpf/graphics-multimedia/how-to-paint-an-area-with-a-system-brush.md)  
 [Use SystemFonts](../../../../docs/framework/wpf/advanced/how-to-use-systemfonts.md)  
 [Use System Parameters Keys](../../../../docs/framework/wpf/advanced/how-to-use-system-parameters-keys.md)  
 [How-to Topics](../../../../docs/framework/wpf/advanced/resources-how-to-topics.md)
