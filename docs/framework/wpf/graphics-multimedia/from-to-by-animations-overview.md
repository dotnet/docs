---
title: "From-To-By Animations Overview"
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
  - "animation [WPF], From/to/by"
  - "From/to/by animation"
ms.assetid: 516fce0a-e7f8-49b8-b018-53b3d409a8a3
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# From/To/By Animations Overview
This topic describes how to use From/To/By animations to animate dependency properties. A From/To/By animation creates a transition between two values.  
  
<a name="prereq"></a>   
## Prerequisites  
 To understand this topic, you should be familiar with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animations features. For an introduction to animation features, see the [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
<a name="whatisanimation"></a>   
## What Is a From/To/By Animation?  
 A From/To/By animation is a type of <xref:System.Windows.Media.Animation.AnimationTimeline> that creates a transition between a starting value and an ending value. The amount of time that the transition takes to complete is determined by the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of that animation.  
  
 You can apply a From/To/By animation to a property by using a <xref:System.Windows.Media.Animation.Storyboard> in markup and code, or by using the <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A> method in code. You may also use a From/To/By Animation to create an <xref:System.Windows.Media.Animation.AnimationClock> and apply it to one or more properties. For more information about the different methods for applying animations, see the [Property Animation Techniques Overview](../../../../docs/framework/wpf/graphics-multimedia/property-animation-techniques-overview.md).  
  
 From/To/By animations can have no more than two target values. If you require an animation that has more than two target values, use a key-frame animation. Key-frame animations are described in the [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md).  
  
<a name="animation_types"></a>   
## From/To/By Animation Types  
 Because animations generate property values, there are different animation types for different property types. To animate a property that takes a <xref:System.Double>, such as the <xref:System.Windows.FrameworkElement.Width%2A> property of an element, use an animation that produces <xref:System.Double> values. To animate a property that takes a <xref:System.Windows.Point>, use an animation that produces <xref:System.Windows.Point> values, and so on.  
  
 From/To/By animation classes belong to the <xref:System.Windows.Media.Animation> namespace and use the following naming convention:  
  
 *\<Type>* `Animation`  
  
 Where *\<Type>* is the type of value that the class animates.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides the following From/To/By animation classes.  
  
|Property type|Corresponding From/To/By animation class|  
|-------------------|------------------------------------------------|  
|<xref:System.Byte>|<xref:System.Windows.Media.Animation.ByteAnimation>|  
|<xref:System.Windows.Media.Color>|<xref:System.Windows.Media.Animation.ColorAnimation>|  
|<xref:System.Decimal>|<xref:System.Windows.Media.Animation.DecimalAnimation>|  
|<xref:System.Double>|<xref:System.Windows.Media.Animation.DoubleAnimation>|  
|<xref:System.Int16>|<xref:System.Windows.Media.Animation.Int16Animation>|  
|<xref:System.Int32>|<xref:System.Windows.Media.Animation.Int32Animation>|  
|<xref:System.Int64>|<xref:System.Windows.Media.Animation.Int64Animation>|  
|<xref:System.Windows.Point>|<xref:System.Windows.Media.Animation.PointAnimation>|  
|<xref:System.Windows.Media.Media3D.Quaternion>|<xref:System.Windows.Media.Animation.QuaternionAnimation>|  
|<xref:System.Windows.Rect>|<xref:System.Windows.Media.Animation.RectAnimation>|  
|<xref:System.Windows.Media.Media3D.Rotation3D>|<xref:System.Windows.Media.Animation.Rotation3DAnimation>|  
|<xref:System.Single>|<xref:System.Windows.Media.Animation.SingleAnimation>|  
|<xref:System.Windows.Size>|<xref:System.Windows.Media.Animation.SizeAnimation>|  
|<xref:System.Windows.Thickness>|<xref:System.Windows.Media.Animation.ThicknessAnimation>|  
|<xref:System.Windows.Media.Media3D.Vector3D>|<xref:System.Windows.Media.Animation.Vector3DAnimation>|  
|<xref:System.Windows.Vector>|<xref:System.Windows.Media.Animation.VectorAnimation>|  
  
<a name="anim_values"></a>   
## Target Values  
 A From/To/By animation creates a transition between two target values. It is common to specify a starting value (set it by using the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property) and an ending value (set it by using the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property). However, you can also specify only a starting value, a destination value, or an offset value. In these cases, the animation obtains the missing target value from the property that is being animated. The following list describes the different ways to specify the target values of an animation.  
  
-   **Starting Value**  
  
     Use the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property when you want to explicitly specify the starting value of an animation. You can use the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property by itself, or with the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> or <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property. If you specify only the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property, the animation transitions from that value to the base value of the animated property.  
  
-   **Ending Value**  
  
     To specify an ending value of an animation, use its <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property. If you use the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property by itself, the animation obtains its starting value from the property that is being animated or from the output of another animation that is applied to the same property. You can use the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property together with the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property to explicitly specify starting and ending values for the animation.  
  
-   **Offset Value**  
  
     The <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property enables you to specify an offset instead of an explicit starting or ending value for the animation. The <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property of an animation specifies by how much the animation changes a value over its duration. You can use the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property by itself or with the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property. If you specify only the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property, the animation adds the offset value to the base value of the property or to the output of another animation.  
  
<a name="examples"></a>   
## Using From/To/By Values  
 The following sections describe how to use the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A>, <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A>, and <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> properties together or separately.  
  
 The examples in this section each use a <xref:System.Windows.Media.Animation.DoubleAnimation>, which is a type of From/To/By animation, to animate the <xref:System.Windows.FrameworkElement.Width%2A> property of a <xref:System.Windows.Shapes.Rectangle> that is 10 device independent pixels high and 100 device independent pixels wide.  
  
 Although each example uses a <xref:System.Windows.Media.Animation.DoubleAnimation>, the From, To, and By properties of all From/To/By animations behave identically. Although each of these examples uses a <xref:System.Windows.Media.Animation.Storyboard>, you can use From/To/By animations in other ways. For more information, see [Property Animation Techniques Overview](../../../../docs/framework/wpf/graphics-multimedia/property-animation-techniques-overview.md).  
  
### From/To  
 When you set the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> and <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> values together, the animation progresses from the value that is specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property, to the value that is specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property.  
  
 The following example sets the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property of the <xref:System.Windows.Media.Animation.DoubleAnimation> to 50 and its <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property to 300. As a result, the <xref:System.Windows.FrameworkElement.Width%2A> of the <xref:System.Windows.Shapes.Rectangle> is animated from 50 to 300.  
  
 [!code-csharp[basicvalues_snip#FromToAnimationInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/basicvalues_snip/CSharp/AnimationTargetValuesExample.cs#fromtoanimationinline)]
 [!code-vb[basicvalues_snip#FromToAnimationInline](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/basicvalues_snip/VisualBasic/AnimationTargetValuesExample.vb#fromtoanimationinline)]  
  
### To  
 When you set just the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property, the animation progresses from the base value of the animated property, or from the output of a composing animation that was previously applied to the same property, to the value that is specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property.  
  
 ("Composing animation" refers to an <xref:System.Windows.Media.Animation.ClockState.Active> or <xref:System.Windows.Media.Animation.ClockState.Filling> animation that previously applied to the same property that is still in effect when the current animation was applied by using the <xref:System.Windows.Media.Animation.HandoffBehavior.Compose> handoff behavior.)  
  
 The following example sets just the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property of the <xref:System.Windows.Media.Animation.DoubleAnimation> to 300. Because no starting value was specified, the <xref:System.Windows.Media.Animation.DoubleAnimation> uses the base value (100) of the <xref:System.Windows.FrameworkElement.Width%2A> property as its starting value. The <xref:System.Windows.FrameworkElement.Width%2A> of the <xref:System.Windows.Shapes.Rectangle> is animated from 100 to the animation's target value of 300.  
  
 [!code-csharp[basicvalues_snip#ToAnimationInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/basicvalues_snip/CSharp/AnimationTargetValuesExample.cs#toanimationinline)]
 [!code-vb[basicvalues_snip#ToAnimationInline](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/basicvalues_snip/VisualBasic/AnimationTargetValuesExample.vb#toanimationinline)]  
  
### By  
 When you set just the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property of an animation, the animation progresses from the base value of the property that is being animated, or from the output of a composing animation to the sum of that value and the value that is specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property.  
  
 The following example sets just the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property of the <xref:System.Windows.Media.Animation.DoubleAnimation> to 300. Because the example does not specify a starting value, the <xref:System.Windows.Media.Animation.DoubleAnimation> uses the base value of the <xref:System.Windows.FrameworkElement.Width%2A> property, 100, as its starting value. The ending value is determined by adding the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> value of the animation, 300, to its starting value, 100: 400. As a result, the <xref:System.Windows.FrameworkElement.Width%2A> of the <xref:System.Windows.Shapes.Rectangle> is animated from 100 to 400.  
  
 [!code-csharp[basicvalues_snip#ByAnimationInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/basicvalues_snip/CSharp/AnimationTargetValuesExample.cs#byanimationinline)]
 [!code-vb[basicvalues_snip#ByAnimationInline](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/basicvalues_snip/VisualBasic/AnimationTargetValuesExample.vb#byanimationinline)]  
  
### From/By  
 When you set the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> and <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> properties of an animation, the animation progresses from the value that is specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property, to the value that is specified by the sum of the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> and <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> properties.  
  
 The following example sets the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property of the <xref:System.Windows.Media.Animation.DoubleAnimation> to 50 and its <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property to 300. The ending value is determined by adding the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> value of the animation, 300, to its starting value, 50: 350. As a result, the <xref:System.Windows.FrameworkElement.Width%2A> of the <xref:System.Windows.Shapes.Rectangle> is animated from 50 to 350.  
  
 [!code-csharp[basicvalues_snip#FromByAnimationInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/basicvalues_snip/CSharp/AnimationTargetValuesExample.cs#frombyanimationinline)]
 [!code-vb[basicvalues_snip#FromByAnimationInline](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/basicvalues_snip/VisualBasic/AnimationTargetValuesExample.vb#frombyanimationinline)]  
  
### From  
 When you specify just the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> value of an animation, the animation progresses from the value that is specified by the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property, to the base value of the property that is being animated or to the output of a composing animation.  
  
 The following example sets just the <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property of the <xref:System.Windows.Media.Animation.DoubleAnimation> to 50. Because no ending value was specified, the <xref:System.Windows.Media.Animation.DoubleAnimation> uses the base value of the <xref:System.Windows.FrameworkElement.Width%2A> property, 100, as its ending value. The <xref:System.Windows.FrameworkElement.Width%2A> of the <xref:System.Windows.Shapes.Rectangle> is animated from 50 to the base value of the <xref:System.Windows.FrameworkElement.Width%2A> property, 100.  
  
 [!code-csharp[basicvalues_snip#FromAnimationInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/basicvalues_snip/CSharp/AnimationTargetValuesExample.cs#fromanimationinline)]
 [!code-vb[basicvalues_snip#FromAnimationInline](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/basicvalues_snip/VisualBasic/AnimationTargetValuesExample.vb#fromanimationinline)]  
  
### To/By  
 If you set both the <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> and the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> properties of an animation, the <xref:System.Windows.Media.Animation.DoubleAnimation.By%2A> property is ignored.  
  
<a name="otheranimationtypes"></a>   
## Other Animation Types  
 From/To/By animations are not the only type of animations that [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides: it also provides key-frame animations and path animations.  
  
-   A key-frame animation animates along any number of destination values, described using key frames. For more information, see the [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md).  
  
-   A path animation generates output values from a <xref:System.Windows.Media.PathGeometry>. For more information, see the [Path Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/path-animations-overview.md).  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] also enables you to create your own custom animation types. For more information, see the [Custom Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/custom-animations-overview.md).  
  
## See Also  
 <xref:System.Windows.Media.Animation.Timeline>  
 <xref:System.Windows.Media.Animation.Storyboard>  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md)  
 [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md)  
 [Path Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/path-animations-overview.md)  
 [Custom Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/custom-animations-overview.md)  
 [From, To, and By Animation Target Values Sample](http://go.microsoft.com/fwlink/?LinkID=159988)
