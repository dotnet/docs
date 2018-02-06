---
title: "How to: Animate a Property by Using a Storyboard"
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
  - "animation [WPF], Storyboards"
  - "Storyboards [WPF], animation"
ms.assetid: f4a314e9-1da2-4367-85fc-1232487efa7a
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Animate a Property by Using a Storyboard
This example shows how to use a <xref:System.Windows.Media.Animation.Storyboard> to animate properties. To animate a property by using a <xref:System.Windows.Media.Animation.Storyboard>, create an animation for each property that you want to animate and also create a <xref:System.Windows.Media.Animation.Storyboard> to contain the animations.  
  
 The type of property determines the type of animation to use. For example, to animate a property that takes <xref:System.Double> values, use a <xref:System.Windows.Media.Animation.DoubleAnimation>. The <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> and <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A> attached properties specify the object and property to which the animation is applied.  
  
 To start a storyboard in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)], use a <xref:System.Windows.Media.Animation.BeginStoryboard> action and an <xref:System.Windows.EventTrigger>. The <xref:System.Windows.EventTrigger> begins the <xref:System.Windows.Media.Animation.BeginStoryboard> action when the event that is specified by its <xref:System.Windows.EventTrigger.RoutedEvent%2A> property occurs. The <xref:System.Windows.Media.Animation.BeginStoryboard> action starts the <xref:System.Windows.Media.Animation.Storyboard>.  
  
 The following example uses <xref:System.Windows.Media.Animation.Storyboard> objects to animate two <xref:System.Windows.Controls.Button> controls. To make the first button change in size, its <xref:System.Windows.FrameworkElement.Width%2A> is animated. To make the second button change color, the <xref:System.Windows.Media.SolidColorBrush.Color%2A> property of the <xref:System.Windows.Media.SolidColorBrush> is used to set the <xref:System.Windows.Controls.Control.Background%2A> of the button that is animated.  
  
## Example  
 [!code-xaml[AnimatePropertyStoryboards#1](../../../../samples/snippets/xaml/VS_Snippets_Wpf/AnimatePropertyStoryboards/XAML/StoryboardExample.xaml#1)]  
  
> [!NOTE]
>  Although animations can target both a <xref:System.Windows.FrameworkElement> object, such as a <xref:System.Windows.Controls.Control> or <xref:System.Windows.Controls.Panel>, and a <xref:System.Windows.Freezable> object, such as a <xref:System.Windows.Media.Brush> or <xref:System.Windows.Media.Transform>, only framework elements have a <xref:System.Windows.FrameworkElement.Name%2A> property. To assign a name to a freezable so that it can be targeted by an animation, use the [x:Name Directive](../../../../docs/framework/xaml-services/x-name-directive.md), as the previous example shows.  
  
 If you use code, you must create a <xref:System.Windows.NameScope> for a <xref:System.Windows.FrameworkElement> and register the names of the objects to animate with that <xref:System.Windows.FrameworkElement>. To start the animations in code, use a <xref:System.Windows.Media.Animation.BeginStoryboard> action with an <xref:System.Windows.EventTrigger>. Optionally, you can use an event handler and the <xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method of <xref:System.Windows.Media.Animation.Storyboard>. The following example shows how to use the <xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method.  
  
 [!code-csharp[AnimatePropertyStoryboards#11](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AnimatePropertyStoryboards/CSharp/StoryboardExample.cs#11)]
 [!code-vb[AnimatePropertyStoryboards#11](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/AnimatePropertyStoryboards/VisualBasic/StoryboardExample.vb#11)]  
  
 For more information about animation and storyboards, see [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
 If you use code, you are not limited to using <xref:System.Windows.Media.Animation.Storyboard> objects in order to animate properties. For more information and examples, see [Animate a Property Without Using a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-a-property-without-using-a-storyboard.md) and [Animate a Property by Using an AnimationClock](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-a-property-by-using-an-animationclock.md).
