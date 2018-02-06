---
title: "Property Animation Techniques Overview"
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
  - "cpp"
helpviewer_keywords: 
  - "animation [WPF], properties [WPF], methods for"
  - "properties [WPF], methods for animating"
ms.assetid: 74f61413-f8c0-4e75-bf04-951886426c8b
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Property Animation Techniques Overview
This topic describes the different approaches for animating properties: storyboards, local animations, clocks, and per-frame animations.  
  
<a name="prerequisites"></a>   
## Prerequisites  
 To understand this topic, you should be familiar with the basic animation features described in the [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
<a name="summary"></a>   
## Different Ways to Animate  
 Because there are many different scenarios for animating properties, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides several approaches for animating properties.  
  
 For each approach, the following table indicates whether it can be used per-instance, in styles, in control templates, or in data templates; whether it can be used in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)]; and whether the approach enables you to interactively control the animation.  "Per-Instance" refers to the technique of applying an animation or storyboard directly to instances of an object, rather than in a style, control template, or data template.  
  
|Animation technique|Scenarios|Supports XAML|Interactively controllable|  
|-------------------------|---------------|-------------------|--------------------------------|  
|Storyboard animation|Per-instance, <xref:System.Windows.Style>, <xref:System.Windows.Controls.ControlTemplate>, <xref:System.Windows.DataTemplate>|Yes|Yes|  
|Local animation|Per-instance|No|No|  
|Clock animation|Per-instance|No|Yes|  
|Per-frame animation|Per-instance|No|N/A|  
  
<a name="storyboard_animations"></a>   
## Storyboard Animations  
 Use a <xref:System.Windows.Media.Animation.Storyboard> when you want to define and apply your animations in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], interactively control your animations after they start, create a complex tree of animations, or animate in a <xref:System.Windows.Style>, <xref:System.Windows.Controls.ControlTemplate> or <xref:System.Windows.DataTemplate>. For an object to be animated by a <xref:System.Windows.Media.Animation.Storyboard>, it must be a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>, or it must be used to set a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>. For more details, see the [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md).  
  
 A <xref:System.Windows.Media.Animation.Storyboard> is a special type of container <xref:System.Windows.Media.Animation.Timeline> that provides targeting information for the animations it contains. To animate with a <xref:System.Windows.Media.Animation.Storyboard>, you complete the following three steps.  
  
1.  Declare a <xref:System.Windows.Media.Animation.Storyboard> and one or more animations.  
  
2.  Use the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> and <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A> attached properties to specify the target object and property of each animation.  
  
3.  (Code only) Define a <xref:System.Windows.NameScope> for a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>. Register the names of the objects to animate with that <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>.  
  
4.  Begin the <xref:System.Windows.Media.Animation.Storyboard>.  
  
 Beginning a <xref:System.Windows.Media.Animation.Storyboard> applies animations to the properties they animate and starts them. There are two ways to begin a <xref:System.Windows.Media.Animation.Storyboard>: you can use the <xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method provided by the <xref:System.Windows.Media.Animation.Storyboard> class, or you can use a <xref:System.Windows.Media.Animation.BeginStoryboard> action. The only way to animate in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] is to use a <xref:System.Windows.Media.Animation.BeginStoryboard> action. A <xref:System.Windows.Media.Animation.BeginStoryboard> action can be used in an <xref:System.Windows.EventTrigger>, property <xref:System.Windows.Trigger>, or a <xref:System.Windows.DataTrigger>.  
  
 The following table shows the different places where each <xref:System.Windows.Media.Animation.Storyboard> begin technique is supported: per-instance, style, control template, and data template.  
  
|Storyboard is begun using…|Per-instance|Style|Control template|Data template|Example|  
|--------------------------------|-------------------|-----------|----------------------|-------------------|-------------|  
|<xref:System.Windows.Media.Animation.BeginStoryboard> and an <xref:System.Windows.EventTrigger>|Yes|Yes|Yes|Yes|[Animate a Property by Using a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-a-property-by-using-a-storyboard.md)|  
|<xref:System.Windows.Media.Animation.BeginStoryboard> and a property <xref:System.Windows.Trigger>|No|Yes|Yes|Yes|[Trigger an Animation When a Property Value Changes](../../../../docs/framework/wpf/graphics-multimedia/how-to-trigger-an-animation-when-a-property-value-changes.md)|  
|<xref:System.Windows.Media.Animation.BeginStoryboard> and a <xref:System.Windows.DataTrigger>|No|Yes|Yes|Yes|[How to: Trigger an Animation When Data Changes](http://msdn.microsoft.com/library/a736bb3a-2ae5-479a-a33a-75a27055d863)|  
|<xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method|Yes|No|No|No|[Animate a Property by Using a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-a-property-by-using-a-storyboard.md)|  
  
 For more information about <xref:System.Windows.Media.Animation.Storyboard> objects, see the [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md).  
  
## Local Animations  
 Local animations provide a convenient way to animate a dependency property of any <xref:System.Windows.Media.Animation.Animatable> object. Use local animations when you want to apply a single animation to a property and you don't need to interactively control the animation after it starts. Unlike a <xref:System.Windows.Media.Animation.Storyboard> animation, a local animation can animate an object that isn't associated with a <xref:System.Windows.FrameworkElement> or a <xref:System.Windows.FrameworkContentElement>. You also don't have to define a <xref:System.Windows.NameScope> for this type of animation.  
  
 Local animations may only be used in code, and cannot be defined in styles, control templates, or data templates. A local animation cannot be interactively controlled after it is started.  
  
 To animate using a local animation, complete the following steps.  
  
1.  Create an <xref:System.Windows.Media.Animation.AnimationTimeline> object.  
  
2.  Use the <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A> method of the object that you want to animate to apply the <xref:System.Windows.Media.Animation.AnimationTimeline> to the property that you specify.  
  
 The following example shows how to animate the width and background color of a <xref:System.Windows.Controls.Button>.  
  
 [!code-cpp[animateproperty#11](../../../../samples/snippets/cpp/VS_Snippets_Wpf/animateproperty/CPP/LocalAnimationExample.cpp#11)]
 [!code-csharp[animateproperty#11](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animateproperty/CSharp/LocalAnimationExample.cs#11)]
 [!code-vb[animateproperty#11](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animateproperty/VisualBasic/LocalAnimationExample.vb#11)]  
  
## Clock Animations  
 Use <xref:System.Windows.Media.MediaPlayer.Clock%2A> objects when you want to animate without using a <xref:System.Windows.Media.Animation.Storyboard> and you want to create complex timing trees or interactively control animations after they start. You can use Clock objects to animate a dependency property of any <xref:System.Windows.Media.Animation.Animatable> object.  
  
 You cannot use <xref:System.Windows.Media.Animation.Clock> objects directly to animate in styles, control templates, or data templates. (The animation and timing system actually does use <xref:System.Windows.Media.Animation.Clock> objects to animate in styles, control templates, and data templates, but it must create those <xref:System.Windows.Media.Animation.Clock> objects for you from a <xref:System.Windows.Media.Animation.Storyboard>. For more information about the relationship between <xref:System.Windows.Media.Animation.Storyboard> objects and <xref:System.Windows.Media.Animation.Clock> objects, see the [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md).)  
  
 To apply a single <xref:System.Windows.Media.Animation.Clock> to a property, you complete the following steps.  
  
1.  Create an <xref:System.Windows.Media.Animation.AnimationTimeline> object.  
  
2.  Use the <xref:System.Windows.Media.Animation.AnimationTimeline.CreateClock%2A> method of the <xref:System.Windows.Media.Animation.AnimationTimeline> to create an <xref:System.Windows.Media.Animation.AnimationClock>.  
  
3.  Use the <xref:System.Windows.Media.Animation.Animatable.ApplyAnimationClock%2A> method of the object that you want to animate to apply the <xref:System.Windows.Media.Animation.AnimationClock> to the property you specify.  
  
 The following example shows how to create an <xref:System.Windows.Media.Animation.AnimationClock> and apply it to two similar properties.  
  
 [!code-csharp[timingbehaviors_procedural_snip#GraphicsMMCreateAnimationClockWholeClass](../../../../samples/snippets/csharp/VS_Snippets_Wpf/timingbehaviors_procedural_snip/CSharp/AnimationClockExample.cs#graphicsmmcreateanimationclockwholeclass)]
 [!code-vb[timingbehaviors_procedural_snip#GraphicsMMCreateAnimationClockWholeClass](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/timingbehaviors_procedural_snip/visualbasic/animationclockexample.vb#graphicsmmcreateanimationclockwholeclass)]  
  
 To create a timing tree and use it animate properties, you complete the following steps.  
  
1.  Use <xref:System.Windows.Media.Animation.ParallelTimeline> and <xref:System.Windows.Media.Animation.AnimationTimeline> objects to create the timing tree.  
  
2.  Use the <xref:System.Windows.Media.Animation.TimelineGroup.CreateClock%2A> of the root <xref:System.Windows.Media.Animation.ParallelTimeline> to create a <xref:System.Windows.Media.Animation.ClockGroup>.  
  
3.  Iterate through the <xref:System.Windows.Media.Animation.ClockGroup.Children%2A> of the <xref:System.Windows.Media.Animation.ClockGroup> and apply its child <xref:System.Windows.Media.Animation.Clock> objects. For each <xref:System.Windows.Media.Animation.AnimationClock> child, use the <xref:System.Windows.Media.Animation.Animatable.ApplyAnimationClock%2A> method of the object that you want to animate to apply the <xref:System.Windows.Media.Animation.AnimationClock> to the property you specify  
  
 For more information about Clock objects, see the [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md).  
  
## Per-Frame Animation: Bypass the Animation and Timing System  
 Use this approach when you need to completely bypass the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation system. One scenario for this approach is physics animations, where each step in the animation requires objects to be recomputed based on the last set of object interactions.  
  
 Per-frame animations cannot be defined inside styles, control templates, or data templates.  
  
 To animate frame-by-frame, you register for the <xref:System.Windows.Media.CompositionTarget.Rendering> event of the object that contains the objects you want to animate. This event handler method gets called once per frame. Each time that [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] marshals the persisted rendering data in the visual tree across to the composition tree, your event handler method is called.  
  
 In your event handler, perform whatever calculations are necessary for your animation effect and set the properties of the objects you want to animate with these values.  
  
 To obtain the presentation time for the current frame, the <xref:System.EventArgs> associated with this event can be cast as <xref:System.Windows.Media.RenderingEventArgs>, which provide a <xref:System.Windows.Media.RenderingEventArgs.RenderingTime%2A> property that you can use to obtain the current frame's rendering time.  
  
 For more information, see the <xref:System.Windows.Media.CompositionTarget.Rendering> page.  
  
## See Also  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md)  
 [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md)  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)
