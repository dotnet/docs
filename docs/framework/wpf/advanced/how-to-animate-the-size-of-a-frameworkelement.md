---
title: "How to: Animate the Size of a FrameworkElement"
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
  - "animation [WPF], FrameworkElement size"
  - "FrameworkElement [WPF], animating size of"
ms.assetid: d4cd5a13-c20d-4a6f-a2ba-14f2c9ce4cef
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Animate the Size of a FrameworkElement
To animate the size of a <xref:System.Windows.FrameworkElement>, you can either animate its <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties or use an animated <xref:System.Windows.Media.ScaleTransform>.  
  
 In the following example animates the size of two buttons using these two approaches. One button is resized by animating its <xref:System.Windows.FrameworkElement.Width%2A> property and another is resized by animating a <xref:System.Windows.Media.ScaleTransform> applied to its <xref:System.Windows.UIElement.RenderTransform%2A> property. Each button contains some text. Initially, the text appears the same in both buttons, but as the buttons are resized, the text in the second button becomes distorted.  
  
## Example  
 [!code-xaml[transformanimations_snip#1](../../../../samples/snippets/xaml/VS_Snippets_Wpf/transformanimations_snip/XAML/AnimatingSizeExample.xaml#1)]  
  
 When you transform an element, the entire element and its contents are transformed. When you directly alter the size of an element, as in the case of the first button, the element's contents are not resized unless their size and position depend on the size of their parent element.  
  
 Animating the size of an element by applying an animated transform to its <xref:System.Windows.UIElement.RenderTransform%2A> property provides better performance than animated its <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> directly, because the <xref:System.Windows.UIElement.RenderTransform%2A> property does not trigger a layout pass.  
  
 For more information about animating properties, see the [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md). For more information about transforms, see the [Transforms Overview](../../../../docs/framework/wpf/graphics-multimedia/transforms-overview.md).
