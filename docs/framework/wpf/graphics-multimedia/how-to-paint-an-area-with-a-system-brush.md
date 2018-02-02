---
title: "How to: Paint an Area with a System Brush"
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
  - "system brushes [WPF], painting with"
  - "painting [WPF], with system brushes"
  - "brushes [WPF], painting with system brushes [WPF]"
ms.assetid: 5141a763-9235-42cb-a6bb-afc75513eac7
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Paint an Area with a System Brush
The <xref:System.Windows.SystemColors> class provides access to system brushes and colors, such as <xref:System.Windows.SystemColors.ControlBrush%2A>, <xref:System.Windows.SystemColors.ControlBrushKey%2A>, and <xref:System.Windows.SystemColors.DesktopBrush%2A>. A system brush is a <xref:System.Windows.Media.SolidColorBrush> object that paints an area with the specified system color. A system brush always produces a solid fill; it can't be used to create a gradient.  
  
 You can use system brushes as either a static or a dynamic resource. Use a dynamic resource if you want the brush to update automatically if the user changes the system brush as the application is running; otherwise, use a static resource. The SystemColors class contains a variety of static properties that follow a strict naming convention:  
  
-   *\<SystemColor>*Brush  
  
     Gets a static reference to a <xref:System.Windows.Media.SolidColorBrush> of the specified system color.  
  
-   *\<SystemColor>*BrushKey  
  
     Gets a dynamic reference to a <xref:System.Windows.Media.SolidColorBrush> of the specified system color.  
  
-   *\<SystemColor>*Color  
  
     Gets a static reference to a <xref:System.Windows.Media.Color> structure of the specified system color.  
  
-   *\<SystemColor>*ColorKey  
  
     Gets a dynamic reference to the <xref:System.Windows.Media.Color> structure of the specified system color.  
  
 A system color is a <xref:System.Windows.Media.Color> structure that can be used to configure a brush. For example, you can create a gradient using system colors by setting the <xref:System.Windows.Media.GradientStop.Color%2A> properties of a <xref:System.Windows.Media.LinearGradientBrush> object's gradient stops with system colors. For an example, see [Use System Colors in a Gradient](../../../../docs/framework/wpf/graphics-multimedia/how-to-use-system-colors-in-a-gradient.md).  
  
## Example  
 The following example uses a dynamic system brush reference to set the Background of a button.  
  
 [!code-xaml[brushsamples_snip#GraphicsMMDynamicSystemColorDesktopBrushKeyExampleWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/brushsamples_snip/CS/DynamicSystemBrushExample.xaml#graphicsmmdynamicsystemcolordesktopbrushkeyexamplewholepage)]  
  
 The next example uses a static system brush reference to set the Background of a button.  
  
 [!code-xaml[brushsamples_snip#GraphicsMMStaticSystemColorDesktopBrushExampleWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/brushsamples_snip/CS/StaticSystemBrushExample.xaml#graphicsmmstaticsystemcolordesktopbrushexamplewholepage)]  
  
 For an example showing how to use a system color in a gradient, see [Use System Colors in a Gradient](../../../../docs/framework/wpf/graphics-multimedia/how-to-use-system-colors-in-a-gradient.md).  
  
## See Also  
 [Use System Colors in a Gradient](../../../../docs/framework/wpf/graphics-multimedia/how-to-use-system-colors-in-a-gradient.md)  
 [Painting with Solid Colors and Gradients Overview](../../../../docs/framework/wpf/graphics-multimedia/painting-with-solid-colors-and-gradients-overview.md)
