---
title: "How to: Apply Animations to Text"
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
  - "typography [WPF], animations"
  - "animation [WPF], text"
ms.assetid: eec3d26c-0a21-420f-8012-671621c47089
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Apply Animations to Text
Animations can alter the display and appearance of text in your application. The following examples use different types of animations to affect the display of text in a <xref:System.Windows.Controls.TextBlock> control.  
  
## Example  
 The following example uses a <xref:System.Windows.Media.Animation.DoubleAnimation> to animate the width of the text block. The width value changes from the width of the text block to 0 over a duration of 10 seconds, and then reverses the width values and continues. This type of animation creates a wipe effect.  
  
 [!code-xaml[TextAnimationSample#TextAnimationSample1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TextAnimationSample/CS/Window1.xaml#textanimationsample1)]  
  
 The following example uses a <xref:System.Windows.Media.Animation.DoubleAnimation> to animate the opacity of the text block. The opacity value changes from 1.0 to 0 over a duration of 5 seconds, and then reverses the opacity values and continues.  
  
 [!code-xaml[TextAnimationSample#TextAnimationSample2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TextAnimationSample/CS/Window1.xaml#textanimationsample2)]  
  
 The following diagram shows the effect of the <xref:System.Windows.Controls.TextBlock> control changing its opacity from `1.00` to `0.00` during the 5-second interval defined by the <xref:System.Windows.Media.Animation.Timeline.Duration%2A>.  
  
 ![Text changing opacity from 1.00 to 0.00](../../../../docs/framework/wpf/advanced/media/fadedtext01.png "FadedText01")  
Text Opacity changing from 1.00 to 0.00  
  
 The following example uses a <xref:System.Windows.Media.Animation.ColorAnimation> to animate the foreground color of the text block. The foreground color value changes from one color to a second color over a duration of 5 seconds, and then reverses the color values and continues.  
  
 [!code-xaml[TextAnimationSample#TextAnimationSample3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TextAnimationSample/CS/Window1.xaml#textanimationsample3)]  
  
 The following example uses a <xref:System.Windows.Media.Animation.DoubleAnimation> to rotate the text block. The text block performs a full rotation over a duration of 20 seconds, and then continues to repeat the rotation.  
  
 [!code-xaml[TextAnimationSample#TextAnimationSample4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TextAnimationSample/CS/Window1.xaml#textanimationsample4)]  
  
## See Also  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)
