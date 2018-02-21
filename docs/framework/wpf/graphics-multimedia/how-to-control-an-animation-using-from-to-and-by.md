---
title: "How to: Control an Animation using From, To, and By"
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
  - "animation [WPF], From/to/by"
  - "basic animation [WPF]"
  - "animation [WPF], basic animation"
  - "From/to/by animation"
ms.assetid: 59afba57-6fc1-44c8-987e-8a5f4142adad
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Control an Animation using From, To, and By
A "From/To/By" or "basic animation" creates a transition between two target values (see [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md) for an introduction to different types of animations). To set the target values of a basic animation, use its <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A>, <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A>, and <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> properties.  The following table summarizes how the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A>, <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A>, and <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> properties may be used together or separately to determine an animation's target values.  
  
|Properties specified|Resulting behavior|  
|--------------------------|------------------------|  
|<xref:System.Windows.Media.Animation.DoubleAnimation.From%2A>|The animation progresses from the value specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property to the base value of the property being animated or to a previous animation's output value, depending on how the previous animation is configured.|  
|<xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> and <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A>|The animation progresses from the value specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property to the value specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property.|  
|<xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> and <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A>|The animation progresses from the value specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property to the value specified by the sum of the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> and <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> properties.|  
|<xref:System.Windows.Media.Animation.DoubleAnimation.To%2A>|The animation progresses from the animated property's base value or a previous animation's output value to the value specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property.|  
|<xref:System.Windows.Media.Animation.DoubleAnimation.By%2A>|The animation progresses from the base value of the property being animated or a previous animation's output value to the sum of that value and the value specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property.|  
  
> [!NOTE]
>  Do not set both the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property and the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property on the same animation.  
  
 To use other interpolation methods or animate between more than two target values, use a key frame animation. See [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md) for more information.  
  
 For information about applying multiple animations to a single property, see [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md).  
  
 The example below shows the different effects of setting <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A>, <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A>, and <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> properties on animations.  
  
## Example  
 [!code-xaml[BasicAnimations_snippet#AnimationTargetValuesWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/BasicAnimations_snippet/CS/AnimationTargetValuesExample.xaml#animationtargetvalueswholepage)]  
  
## See Also  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md)  
 [From, To, and By Animation Target Values Sample](http://go.microsoft.com/fwlink/?LinkID=159988)
