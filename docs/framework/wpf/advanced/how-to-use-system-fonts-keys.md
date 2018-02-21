---
title: "How to: Use System Fonts Keys"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "resource keys [WPF], SystemFonts class"
ms.assetid: 036ebea7-5677-4f60-8ba4-56c9f9d9b8bd
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use System Fonts Keys
System resources expose a number of system metrics as resources to help developers create visuals that are consistent with system settings. <xref:System.Windows.SystemFonts> is a class that contains both system font values and system font resources that bind to the values—for example, <xref:System.Windows.SystemFonts.CaptionFontFamily%2A> and <xref:System.Windows.SystemFonts.CaptionFontFamilyKey%2A>.  
  
 System font metrics can be used as either static or dynamic resources. Use a dynamic resource if you want the font metric to update automatically while the application runs; otherwise use a static resource.  
  
> [!NOTE]
>  Dynamic resources have the keyword *Key* appended to the property name.  
  
 The following example shows how to access and use system font dynamic resources to style or customize a button. This [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] example creates a button style that assigns <xref:System.Windows.SystemFonts> values to a button.  
  
## Example  
 [!code-xaml[SystemRes_snip#FontDynamicResources](../../../../samples/snippets/csharp/VS_Snippets_Wpf/SystemRes_snip/CSharp/MyApp.xaml#fontdynamicresources)]  
  
## See Also  
 [Paint an Area with a System Brush](../../../../docs/framework/wpf/graphics-multimedia/how-to-paint-an-area-with-a-system-brush.md)  
 [Use SystemParameters](../../../../docs/framework/wpf/advanced/how-to-use-systemparameters.md)  
 [Use SystemFonts](../../../../docs/framework/wpf/advanced/how-to-use-systemfonts.md)
