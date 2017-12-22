---
title: "Animation Overview"
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
  - "Storyboards [WPF], animations"
  - "animations [WPF], overview"
ms.assetid: bd9ce563-725d-4385-87c9-d7ee38cf79ea
caps.latest.revision: 73
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Animation Overview
<a name="introduction"></a>
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides a powerful set of graphics and layout features that enable you to create attractive user interfaces and appealing documents. Animation can make an attractive user interface even more spectacular and usable. By just animating a background color or applying an animated <xref:System.Windows.Media.Transform>, you can create dramatic screen transitions or provide helpful visual cues.  
  
 This overview provides an introduction to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation and timing system. It focuses on the animation of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] objects by using storyboards.  

<a name="introducinganimations"></a>   
## Introducing Animations  
 Animation is an illusion that is created by quickly cycling through a series of images, each slightly different from the last. The brain perceives the group of images as a single changing scene. In film, this illusion is created by using cameras that record many photographs, or frames, each second. When the frames are played back by a projector, the audience sees a moving picture.  
  
 Animation on a computer is similar. For example, a program that makes a drawing of a rectangle fade out of view might work as follows.  
  
-   The program creates a timer.  
  
-   The program checks the timer at set intervals to see how much time has elapsed.  
  
-   Each time the program checks the timer, it computes the current opacity value for the rectangle based on how much time has elapsed.  
  
-   The program then updates the rectangle with the new value and redraws it.  
  
 Prior to [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], [!INCLUDE[TLA#tla_win](../../../../includes/tlasharptla-win-md.md)] developers had to create and manage their own timing systems or use special custom libraries. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] includes an efficient timing system that is exposed through managed code and [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] and that is deeply integrated into the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] framework. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation makes it easy to animate controls and other graphical objects.  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] handles all the behind-the-scenes work of managing a timing system and redrawing the screen efficiently. It provides timing classes that enable you to focus on the effects you want to create, instead of the mechanics of achieving those effects. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] also makes it easy to create your own animations by exposing animation base classes from which your classes can inherit, to produce customized animations. These custom animations gain many of the performance benefits of the standard animation classes.  
  
<a name="thewpftimingsystem"></a>   
## WPF Property Animation System  
 If you understand a few important concepts about the timing system, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animations can be easier to use. Most important is that, in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)], you animate objects by applying animation to their individual properties. For example, to make a framework element grow, you animate its <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties. To make an object fade from view, you animate its <xref:System.Windows.UIElement.Opacity%2A> property.  
  
 For a property to have animation capabilities, it must meet the following three requirements:  
  
-   It must be a dependency property.  
  
-   It must belong to a class that inherits from <xref:System.Windows.DependencyObject> and implements the <xref:System.Windows.Media.Animation.IAnimatable> interface.  
  
-   There must be a compatible animation type available. (If [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] does not provide one, you can create your own. See the [Custom Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/custom-animations-overview.md).)  
  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] contains many objects that have <xref:System.Windows.Media.Animation.IAnimatable> properties. Controls such as <xref:System.Windows.Controls.Button> and <xref:System.Windows.Controls.TabControl>, and also <xref:System.Windows.Controls.Panel> and <xref:System.Windows.Shapes.Shape> objects inherit from <xref:System.Windows.DependencyObject>. Most of their properties are dependency properties.  
  
 You can use animations almost anywhere, which includes in styles and control templates. Animations do not have to be visual; you can animate objects that are not part of the user interface if they meet the criteria that are described in this section.  
  
<a name="storyboardwalkthrough"></a>   
## Example: Make an Element Fade In and Out of View  
 This example shows how to use a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation to animate the value of a dependency property. It uses a <xref:System.Windows.Media.Animation.DoubleAnimation>, which is a type of animation that generates <xref:System.Double> values, to animate the <xref:System.Windows.UIElement.Opacity%2A> property of a <xref:System.Windows.Shapes.Rectangle>. As a result, the <xref:System.Windows.Shapes.Rectangle> fades in and out of view.  
  
 The first part of the example creates a <xref:System.Windows.Shapes.Rectangle> element. The steps that follow show how to create an animation and apply it to the rectangle's <xref:System.Windows.UIElement.Opacity%2A> property    .
  
 The following shows how to create a <xref:System.Windows.Shapes.Rectangle> element in a <xref:System.Windows.Controls.StackPanel> in XAML.  
  
 [!code-xaml[animation_ovws2#RectangleOpacityFadeExampleXaml_1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Window1.xaml#rectangleopacityfadeexamplexaml_1)]  
  
 The following shows how to create a <xref:System.Windows.Shapes.Rectangle> element in a <xref:System.Windows.Controls.StackPanel> in code.  
  
 [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Class1.cs#rectangleopacityfadeexamplecode_1)]
 [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/Class1.vb#rectangleopacityfadeexamplecode_1)]  
  
<a name="opacity_animation_step1"></a>   
### Part 1: Create a DoubleAnimation  
 One way to make an element fade in and out of view is to animate its <xref:System.Windows.UIElement.Opacity%2A> property. Because the <xref:System.Windows.UIElement.Opacity%2A> property is of type <xref:System.Double>, you need an animation that produces double values. A <xref:System.Windows.Media.Animation.DoubleAnimation> is one such animation. A <xref:System.Windows.Media.Animation.DoubleAnimation> creates a transition between two double values. To specify its starting value, you set its <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property. To specify its ending value, you set its <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property.  
  
1.  An opacity value of `1.0` makes the object completely opaque, and an opacity value of `0.0` makes it completely invisible. To make the animation transition from `1.0` to `0.0` you set its <xref:System.Windows.Media.Animation.DoubleAnimation.From%2A> property to `1.0` and its <xref:System.Windows.Media.Animation.DoubleAnimation.To%2A> property to `0.0`. The following shows how to create a <xref:System.Windows.Media.Animation.DoubleAnimation> in XAML.  
  
     [!code-xaml[animation_ovws2#RectangleOpacityFadeExampleXaml_2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Window1.xaml#rectangleopacityfadeexamplexaml_2)]  
  
     The following shows how to create a <xref:System.Windows.Media.Animation.DoubleAnimation> in code.  
  
     [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Class1.cs#rectangleopacityfadeexamplecode_2)]
     [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/Class1.vb#rectangleopacityfadeexamplecode_2)]  
  
2.  Next, you must specify a <xref:System.Windows.Media.Animation.Timeline.Duration%2A>. The <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of an animation specifies how long it takes to go from its starting value to its destination value. The following shows how to set the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> to five seconds in XAML.  
  
     [!code-xaml[animation_ovws2#RectangleOpacityFadeExampleXaml_3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Window1.xaml#rectangleopacityfadeexamplexaml_3)]  
  
     The following shows how to set the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> to five seconds in code.  
  
     [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Class1.cs#rectangleopacityfadeexamplecode_3)]
     [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/Class1.vb#rectangleopacityfadeexamplecode_3)]  
  
3.  The previous code showed an animation that transitions from `1.0` to `0.0`, which causes the target element to fade from completely opaque to completely invisible. To make the element fade back into view after it vanishes, set the <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A> property of the animation to `true`. To make the animation repeat indefinitely, set its <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property to <xref:System.Windows.Media.Animation.RepeatBehavior.Forever%2A>.The following shows how to set the <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A> and <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> properties in XAML.  
  
     [!code-xaml[animation_ovws2#RectangleOpacityFadeExampleXaml_4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Window1.xaml#rectangleopacityfadeexamplexaml_4)]  
  
     The following shows how to set the <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A> and <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> properties in code.  
  
     [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Class1.cs#rectangleopacityfadeexamplecode_4)]
     [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_4](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/Class1.vb#rectangleopacityfadeexamplecode_4)]  
  
<a name="opacity_animation_step2"></a>   
### Part 2: Create a Storyboard  
 To apply an animation to an object, you create a <xref:System.Windows.Media.Animation.Storyboard> and use the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> and <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A> attached properties to specify the object and property to animate.  
  
1.  Create the <xref:System.Windows.Media.Animation.Storyboard> and add the animation as its child. The following shows how to create the <xref:System.Windows.Media.Animation.Storyboard> in XAML.  
  
     [!code-xaml[animation_ovws2#RectangleOpacityFadeExampleXaml_5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Window1.xaml#rectangleopacityfadeexamplexaml_5)]    
  
     To create the <xref:System.Windows.Media.Animation.Storyboard> in code, declare a <xref:System.Windows.Media.Animation.Storyboard> variable at the class level.  
  
     [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_100](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/MainWindow.xaml.cs#rectangleopacityfadeexamplecode_100)]
     [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_100](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/MainWindow.xaml.vb#rectangleopacityfadeexamplecode_100)]  
  
     Then initialize the <xref:System.Windows.Media.Animation.Storyboard> and add the animation as its child.  
  
     [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_101](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/MainWindow.xaml.cs#rectangleopacityfadeexamplecode_101)]
     [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_101](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/MainWindow.xaml.vb#rectangleopacityfadeexamplecode_101)]  
  
2.  The <xref:System.Windows.Media.Animation.Storyboard> has to know where to apply the animation. Use the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A?displayProperty=nameWithType> attached property to specify the object to animate. The following shows how to set the target name of the <xref:System.Windows.Media.Animation.DoubleAnimation> to `MyRectangle` in XAML.  
  
     [!code-xaml[animation_ovws2#RectangleOpacityFadeExampleXaml_6](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Window1.xaml#rectangleopacityfadeexamplexaml_6)]  
  
     The following shows how to set the target name of the <xref:System.Windows.Media.Animation.DoubleAnimation> to `MyRectangle` in code.  
  
     [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_102](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/MainWindow.xaml.cs#rectangleopacityfadeexamplecode_102)]
     [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_102](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/MainWindow.xaml.vb#rectangleopacityfadeexamplecode_102)]  
  
3.  Use the <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A> attached property to specify the property to animate. The following shows how the animation is configured to target the <xref:System.Windows.UIElement.Opacity%2A> property of the <xref:System.Windows.Shapes.Rectangle> in XAML.
  
     [!code-xaml[animation_ovws2#RectangleOpacityFadeExampleXaml_7](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/Window1.xaml#rectangleopacityfadeexamplexaml_7)]  
  
     The following shows how the animation is configured to target the <xref:System.Windows.UIElement.Opacity%2A> property of the <xref:System.Windows.Shapes.Rectangle> in code.  
  
     [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_103](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/MainWindow.xaml.cs#rectangleopacityfadeexamplecode_103)]
     [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_103](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/MainWindow.xaml.vb#rectangleopacityfadeexamplecode_103)]  
  
 For more information about <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A> syntax and for additional examples, see the [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md).  
  
<a name="opacity_animation_step3"></a>   
### Part 3 (XAML): Associate the Storyboard with a Trigger  
 The easiest way to apply and start a <xref:System.Windows.Media.Animation.Storyboard> in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] is to use an event trigger. This section shows how to associate the <xref:System.Windows.Media.Animation.Storyboard> with a trigger in XAML.  
  
1.  Create a <xref:System.Windows.Media.Animation.BeginStoryboard> object and associate your storyboard with it. A <xref:System.Windows.Media.Animation.BeginStoryboard> is a type of <xref:System.Windows.TriggerAction> that applies and starts a <xref:System.Windows.Media.Animation.Storyboard>.  
  
     [!code-xaml[animation_ovws_snippet#RectangleOpacityFadeExampleInline_3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/RectangleOpacityFadeExample.xaml#rectangleopacityfadeexampleinline_3)]  
  
2.  Create an <xref:System.Windows.EventTrigger> and add the <xref:System.Windows.Media.Animation.BeginStoryboard> to its <xref:System.Windows.EventTrigger.Actions%2A> collection. Set the <xref:System.Windows.EventTrigger.RoutedEvent%2A> property of the <xref:System.Windows.EventTrigger> to the routed event that you want to start the <xref:System.Windows.Media.Animation.Storyboard>. (For more information about routed events, see the [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md).)  
  
     [!code-xaml[animation_ovws_snippet#RectangleOpacityFadeExampleInline_2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/RectangleOpacityFadeExample.xaml#rectangleopacityfadeexampleinline_2)]  
  
3.  Add the <xref:System.Windows.EventTrigger> to the <xref:System.Windows.FrameworkElement.Triggers%2A> collection of the Rectangle.  
  
     [!code-xaml[animation_ovws_snippet#RectangleOpacityFadeExampleInline_1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/RectangleOpacityFadeExample.xaml#rectangleopacityfadeexampleinline_1)]  
  
<a name="opacity_animation_step3code"></a>   
### Part 3 (Code): Associate the Storyboard with an Event Handler  
 The easiest way to apply and start a <xref:System.Windows.Media.Animation.Storyboard> in code is to use an event handler. This section shows how to associate the <xref:System.Windows.Media.Animation.Storyboard> with an event handler in code.  
  
1.  Register for the <xref:System.Windows.FrameworkElement.Loaded> event of the rectangle.  
  
     [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_104](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/MainWindow.xaml.cs#rectangleopacityfadeexamplecode_104)]
     [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_104](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/MainWindow.xaml.vb#rectangleopacityfadeexamplecode_104)]  
  
2.  Declare the event handler. In the event handler, use the <xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method to apply the storyboard.  
  
     [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode_105](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/MainWindow.xaml.cs#rectangleopacityfadeexamplecode_105)]
     [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode_105](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/MainWindow.xaml.vb#rectangleopacityfadeexamplecode_105)]  
  
### Complete Example  
 The following shows how to create a rectangle that fades in and out of view in XAML.  
  
 [!code-xaml[animation_ovws2#RectangleOpacityFadeExampleXaml](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/MainWindow.xaml#rectangleopacityfadeexamplexaml)]  
  
 The following shows how to create a rectangle that fades in and out of view in code.  
  
 [!code-csharp[animation_ovws2#RectangleOpacityFadeExampleCode](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws2/CSharp/MainWindow.xaml.cs#rectangleopacityfadeexamplecode)]
 [!code-vb[animation_ovws2#RectangleOpacityFadeExampleCode](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws2/VisualBasic/MainWindow.xaml.vb#rectangleopacityfadeexamplecode)]  
  
<a name="animationtypes"></a>   
## Animation Types  
 Because animations generate property values, different animation types exist for different property types. To animate a property that takes a <xref:System.Double>, such as the <xref:System.Windows.FrameworkElement.Width%2A> property of an element, use an animation that produces <xref:System.Double> values. To animate a property that takes a <xref:System.Windows.Point>, use an animation that produces <xref:System.Windows.Point> values, and so on. Because of the number of different property types, there are several animation classes in the <xref:System.Windows.Media.Animation> namespace. Fortunately, they follow a strict naming convention that makes it easy to differentiate between them:  
  
-   \<*Type*>Animation  
  
     Known as a "From/To/By" or "basic" animation, these animate between a starting and destination value, or by adding an offset value to its starting value.  
  
    -   To specify a starting value, set the From property of the animation.  
  
    -   To specify an ending value, set the To property of the animation.  
  
    -   To specify an offset value, set the By property of the animation.  
  
     The examples in this overview use these animations, because they are the simplest to use. From/To/By animations are described in detail in the From/To/By Animations Overview.  
  
-   \<*Type*>AnimationUsingKeyFrames  
  
     Key frame animations are more powerful than From/To/By animations because you can specify any number of target values and even control their interpolation method. Some types can only be animated with key frame animations. Key frame animations are described in detail in the [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md).  
  
-   \<*Type*>AnimationUsingPath  
  
     Path animations enable you to use a geometric path in order to produce animated values.  
  
-   \<*Type*>AnimationBase  
  
     Abstract class that, when you implement it, animates a \<*Type*> value. This class serves as the base class for \<*Type*>Animation and \<*Type*>AnimationUsingKeyFrames classes. You have to deal directly with these classes only if you want to create your own custom animations. Otherwise, use a \<*Type*>Animation or KeyFrame\<*Type*>Animation.  
  
 In most cases, you will want to use the \<*Type*>Animation classes, such as <xref:System.Windows.Media.Animation.DoubleAnimation> and <xref:System.Windows.Media.Animation.ColorAnimation>.  
  
 The following table shows several common animation types and some properties with which they are used.  
  
|Property type|Corresponding basic (From/To/By) animation|Corresponding key frame animation|Corresponding Path Animation|Usage example|  
|-------------------|----------------------------------------------------|---------------------------------------|----------------------------------|-------------------|  
|<xref:System.Windows.Media.Color>|<xref:System.Windows.Media.Animation.ColorAnimation>|<xref:System.Windows.Media.Animation.ColorAnimationUsingKeyFrames>|None|Animate the <xref:System.Windows.Media.SolidColorBrush.Color%2A> of a <xref:System.Windows.Media.SolidColorBrush> or a <xref:System.Windows.Media.GradientStop>.|  
|<xref:System.Double>|<xref:System.Windows.Media.Animation.DoubleAnimation>|<xref:System.Windows.Media.Animation.DoubleAnimationUsingKeyFrames>|<xref:System.Windows.Media.Animation.DoubleAnimationUsingPath>|Animate the <xref:System.Windows.FrameworkElement.Width%2A> of a <xref:System.Windows.Controls.DockPanel> or the <xref:System.Windows.FrameworkElement.Height%2A> of a <xref:System.Windows.Controls.Button>.|  
|<xref:System.Windows.Point>|<xref:System.Windows.Media.Animation.PointAnimation>|<xref:System.Windows.Media.Animation.PointAnimationUsingKeyFrames>|<xref:System.Windows.Media.Animation.PointAnimationUsingPath>|Animate the <xref:System.Windows.Media.EllipseGeometry.Center%2A> position of an <xref:System.Windows.Media.EllipseGeometry>.|  
|<xref:System.String>|None|<xref:System.Windows.Media.Animation.StringAnimationUsingKeyFrames>|None|Animate the <xref:System.Windows.Controls.TextBlock.Text%2A> of a <xref:System.Windows.Controls.TextBlock> or the <xref:System.Windows.Controls.ContentControl.Content%2A> of a <xref:System.Windows.Controls.Button>.|  
  
<a name="animationsaretimelines"></a>   
### Animations Are Timelines  
 All the animation types inherit from the <xref:System.Windows.Media.Animation.Timeline> class; therefore, all animations are specialized types of timelines. A <xref:System.Windows.Media.Animation.Timeline> defines a segment of time. You can specify the *timing behaviors* of a timeline: its <xref:System.Windows.Media.Animation.Timeline.Duration%2A>, how many times it is repeated, and even how fast time progresses for it.  
  
 Because an animation is a <xref:System.Windows.Media.Animation.Timeline>, it also represents a segment of time. An animation also calculates output values as it progresses though its specified segment of time (or <xref:System.Windows.Media.Animation.Timeline.Duration%2A>). As the animation progresses, or "plays," it updates the property that it is associated with.  
  
 Three frequently used timing properties are <xref:System.Windows.Media.Animation.Timeline.Duration%2A>, <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A>, and <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A>.  
  
#### The Duration Property  
 As previously mentioned, a timeline represents a segment of time. The length of that segment is determined by the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> of the timeline, which is usually specified by using a <xref:System.Windows.Duration.TimeSpan%2A> value. When a timeline reaches the end of its duration, it has completed an iteration.  
  
 An animation uses its <xref:System.Windows.Media.Animation.Timeline.Duration%2A> property to determine its current value. If you do not specify a <xref:System.Windows.Media.Animation.Timeline.Duration%2A> value for an animation, it uses 1 second, which is the default.  
  
 The following syntax shows a simplified version of the [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] attribute syntax for the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> property.  
  
*hours* `:` *minutes* `:` *seconds*
  
 The following table shows several <xref:System.Windows.Duration> settings and their resulting values.  
  
|Setting|Resulting value|  
|-------------|---------------------|  
|0:0:5.5|5.5 seconds.|  
|0:30:5.5|30 minutes and 5.5 seconds.|  
|1:30:5.5|1 hour, 30 minutes, and 5.5 seconds.|  
  
 One way to specify a <xref:System.Windows.Duration> in code is to use the <xref:System.TimeSpan.FromSeconds%2A> method to create a <xref:System.TimeSpan>, then declare a new <xref:System.Windows.Duration> structure using that <xref:System.TimeSpan>.  
  
 For more information about <xref:System.Windows.Duration> values and the complete [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] syntax, see the <xref:System.Windows.Duration> structure.  
  
#### AutoReverse  
 The <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A> property specifies whether a timeline plays backward after it reaches the end of its <xref:System.Windows.Media.Animation.Timeline.Duration%2A>. If you set this animation property to `true`, an animation reverses after it reaches the end of its <xref:System.Windows.Media.Animation.Timeline.Duration%2A>, playing from its ending value back to its starting value. By default, this property is `false`.  
  
#### RepeatBehavior  
 The <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property specifies how many times a timeline plays. By default, timelines have an iteration count of `1.0`, which means they play one time and do not repeat at all.  
  
 For more information about these properties and others, see the [Timing Behaviors Overview](../../../../docs/framework/wpf/graphics-multimedia/timing-behaviors-overview.md).  
  
<a name="applyanimationstoproperty"></a>   
## Applying an Animation to a Property  
 The previous sections describe the different types of animations and their timing properties. This section shows how to apply the animation to the property that you want to animate. <xref:System.Windows.Media.Animation.Storyboard> objects provide one way to apply animations to properties. A <xref:System.Windows.Media.Animation.Storyboard> is a *container timeline* that provides targeting information for the animations it contains.  
  
### Targeting Objects and Properties  
 The <xref:System.Windows.Media.Animation.Storyboard> class provides the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> and <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A> attached properties. By setting these properties on an animation, you tell the animation what to animate. However, before an animation can target an object, the object must usually be given a name.  
  
 Assigning a name to a <xref:System.Windows.FrameworkElement> differs from assigning a name to a <xref:System.Windows.Freezable> object. Most controls and panels are framework elements; however, most purely graphical objects, such as brushes, transforms, and geometries, are freezable objects. If you are not sure whether a type is a <xref:System.Windows.FrameworkElement> or a <xref:System.Windows.Freezable>, refer to the **Inheritance Hierarchy** section of its reference documentation.  
  
-   To make a <xref:System.Windows.FrameworkElement> an animation target, you give it a name by setting its <xref:System.Windows.FrameworkElement.Name%2A> property. In code, you must also use the <xref:System.Windows.FrameworkElement.RegisterName%2A> method to register the element name with the page to which it belongs.  
  
-   To make a <xref:System.Windows.Freezable> object an animation target in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you use the [x:Name Directive](../../../../docs/framework/xaml-services/x-name-directive.md) to assign it a name. In code, you just use the <xref:System.Windows.FrameworkElement.RegisterName%2A> method to register the object with the page to which it belongs.  
  
 The sections that follow provide an example of naming an element in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] and code. For more detailed information about naming and targeting, see the [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md).  
  
### Applying and Starting Storyboards  
 To start a storyboard in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you associate it with an <xref:System.Windows.EventTrigger>. An <xref:System.Windows.EventTrigger> is an object that describes what actions to take when a specified event occurs. One of those actions can be a <xref:System.Windows.Media.Animation.BeginStoryboard> action, which you use to start your storyboard. Event triggers are similar in concept to event handlers because they enable you to specify how your application responds to a particular event. Unlike event handlers, event triggers can be fully described in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)]; no other code is required.  
  
 To start a <xref:System.Windows.Media.Animation.Storyboard> in code, you can use an <xref:System.Windows.EventTrigger> or use the <xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method of the <xref:System.Windows.Media.Animation.Storyboard> class.  
  
<a name="controllingstoryboards"></a>   
## Interactively Control a Storyboard  
 The previous example showed how to start a <xref:System.Windows.Media.Animation.Storyboard> when an event occurs. You can also interactively control a <xref:System.Windows.Media.Animation.Storyboard> after it starts: you can pause, resume, stop, advance it to its fill period, seek, and remove the <xref:System.Windows.Media.Animation.Storyboard>. For more information and an example that shows how to interactively control a <xref:System.Windows.Media.Animation.Storyboard>, see the [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md).  
  
<a name="fillbehaviorsection"></a>   
## What Happens After an Animation Ends?  
 The <xref:System.Windows.Media.Animation.FillBehavior> property specifies how a timeline behaves when it ends. By default, a timeline starts <xref:System.Windows.Media.Animation.ClockState.Filling> when it ends. An animation that is <xref:System.Windows.Media.Animation.ClockState.Filling> holds its final output value.  
  
 The <xref:System.Windows.Media.Animation.DoubleAnimation> in the previous example does not end because its <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> property is set to <xref:System.Windows.Media.Animation.RepeatBehavior.Forever%2A>. The following example animates a rectangle by using a similar animation. Unlike the previous example, the <xref:System.Windows.Media.Animation.Timeline.RepeatBehavior%2A> and <xref:System.Windows.Media.Animation.Timeline.AutoReverse%2A> properties of this animation are left at their default values. Therefore, the animation progresses from 1 to 0 over five seconds and then stops.  
  
 [!code-xaml[animation_ovws_snippet#FillBehaviorExampleRectangleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snippet/CS/FillBehaviorExample.xaml#fillbehaviorexamplerectangleinline)]  
  
 [!code-csharp[animation_ovws_procedural_snip#FillBehaviorExampleRectangleInline](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_procedural_snip/CSharp/FillBehaviorExample.cs#fillbehaviorexamplerectangleinline)]
 [!code-vb[animation_ovws_procedural_snip#FillBehaviorExampleRectangleInline](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws_procedural_snip/visualbasic/fillbehaviorexample.vb#fillbehaviorexamplerectangleinline)]  
  
 Because its <xref:System.Windows.Media.Animation.Timeline.FillBehavior%2A> was not changed from its default value, which is <xref:System.Windows.Media.Animation.FillBehavior.HoldEnd>, the animation holds it final value, 0, when it ends. Therefore, the <xref:System.Windows.UIElement.Opacity%2A> of the rectangle remains at 0 after the animation ends. If you set the <xref:System.Windows.UIElement.Opacity%2A> of the rectangle to another value, your code appears to have no effect, because the animation is still affecting the <xref:System.Windows.UIElement.Opacity%2A> property.  
  
 One way to regain control of an animated property in code is to use the <xref:System.Windows.Media.Animation.Animatable.BeginAnimation%2A> method and specify null for the <xref:System.Windows.Media.Animation.AnimationTimeline> parameter. For more information and an example, see [Set a Property After Animating It with a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-set-a-property-after-animating-it-with-a-storyboard.md).  
  
 Note that, although setting a property value that has an <xref:System.Windows.Media.Animation.ClockState.Active> or <xref:System.Windows.Media.Animation.ClockState.Filling> animation appears to have no effect, the property value does change. For more information, see the [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md).  
  
<a name="databindingAndAnimatingAnimationsSection"></a>   
## Data Binding and Animating Animations  
 Most animation properties can be data bound or animated; for example, you can animate the <xref:System.Windows.Media.Animation.Timeline.Duration%2A> property of a <xref:System.Windows.Media.Animation.DoubleAnimation>. However, because of the way the timing system works, data bound or animated animations do not behave like other data bound or animated objects. To understand their behavior, it helps to understand what it means to apply an animation to a property.  
  
 Refer to the example in the previous section that showed how to animate the <xref:System.Windows.UIElement.Opacity%2A> of a rectangle. When the rectangle in the previous example is loaded, its event trigger applies the <xref:System.Windows.Media.Animation.Storyboard>. The timing system creates a copy of the <xref:System.Windows.Media.Animation.Storyboard> and its animation. These copies are frozen (made read-only) and <xref:System.Windows.Media.Animation.Clock> objects are created from them. These clocks do the actual work of animating the targeted properties.  
  
 The timing system creates a clock for the <xref:System.Windows.Media.Animation.DoubleAnimation> and applies it to the object and property that is specified by the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> and <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A> of the <xref:System.Windows.Media.Animation.DoubleAnimation>. In this case, the timing system applies the clock to the <xref:System.Windows.UIElement.Opacity%2A> property of the object that is named "MyRectangle."  
  
 Although a clock is also created for the <xref:System.Windows.Media.Animation.Storyboard>, the clock is not applied to any properties. Its purpose is to control its child clock, the clock that is created for the <xref:System.Windows.Media.Animation.DoubleAnimation>.  
  
 For an animation to reflect data binding or animation changes, its clock must be regenerated. Clocks are not regenerated for you automatically. To make an animation reflect changes, reapply its storyboard by using a <xref:System.Windows.Media.Animation.BeginStoryboard> or the <xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method. When you use either of these methods, the animation restarts. In code, you can use the <xref:System.Windows.Media.Animation.Storyboard.Seek%2A> method to shift the storyboard back to its previous position.  
  
 For an example of a data bound animation, see [Key Spline Animation Sample](http://go.microsoft.com/fwlink/?LinkID=160011). For more information about how the animation and timing system works, see [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md).  
  
<a name="otherWaysToAnimateSection"></a>   
## Other Ways to Animate  
 The examples in this overview show how to animate by using storyboards. When you use code, you can animate in several other ways. For more information, see the [Property Animation Techniques Overview](../../../../docs/framework/wpf/graphics-multimedia/property-animation-techniques-overview.md).  
  
<a name="animation_samples"></a>   
## Animation Samples  
 The following samples can help you start adding animation to your applications.  
  
-   [From, To, and By Animation Target Values Sample](http://go.microsoft.com/fwlink/?LinkID=159988)  
  
     Demonstrates different From/To/By settings.  
  
-   [Animation Timing Behavior Sample](http://go.microsoft.com/fwlink/?LinkID=159970)  
  
     Demonstrates the different ways you can control the timing behavior of an animation. This sample also shows how to data bind the destination value of an animation.  
  
<a name="related_topics"></a>   
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md)|Describes how the timing system uses the <xref:System.Windows.Media.Animation.Timeline> and <xref:System.Windows.Media.Animation.Clock> classes, which allow you to create animations.|  
|[Animation Tips and Tricks](../../../../docs/framework/wpf/graphics-multimedia/animation-tips-and-tricks.md)|Lists helpful tips for solving issues with animations, such as performance.|  
|[Custom Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/custom-animations-overview.md)|Describes how to extend the animation system with key frames, animation classes, or per-frame callbacks.|  
|From/To/By Animations Overview|Describes how to create an animation that transitions between two values.|  
|[Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md)|Describes how to create an animation with multiple target values, including the ability to control the interpolation method.|  
|[Easing Functions](../../../../docs/framework/wpf/graphics-multimedia/easing-functions.md)|Explains how to apply mathematical formulas to your animations to get realistic behavior, such as bouncing.|  
|[Path Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/path-animations-overview.md)|Describes how to move or rotate an object along a complex path.|  
|[Property Animation Techniques Overview](../../../../docs/framework/wpf/graphics-multimedia/property-animation-techniques-overview.md)|Describes property animations using storyboards, local animations, clocks, and per-frame animations.|  
|[Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md)|Describes how to use storyboards with multiple timelines to create complex animations.|  
|[Timing Behaviors Overview](../../../../docs/framework/wpf/graphics-multimedia/timing-behaviors-overview.md)|Describes the <xref:System.Windows.Media.Animation.Timeline> types and properties used in animations.|  
|[Timing Events Overview](../../../../docs/framework/wpf/graphics-multimedia/timing-events-overview.md)|Describes the events available on the <xref:System.Windows.Media.Animation.Timeline> and <xref:System.Windows.Media.Animation.Clock> objects for executing code at points in the timeline, such as begin, pause, resume, skip, or stop.|  
|[How-to Topics](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-how-to-topics.md)|Contains code examples for using animations and timelines in your application.|  
|[Clocks How-to Topics](../../../../docs/framework/wpf/graphics-multimedia/clocks-how-to-topics.md)|Contains code examples for using the <xref:System.Windows.Media.Animation.Clock> object in your application.|  
|[Key-Frame How-to Topics](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animation-how-to-topics.md)|Contains code examples for using key-frame animations in your application.|  
|[Path Animation How-to Topics](../../../../docs/framework/wpf/graphics-multimedia/path-animation-how-to-topics.md)|Contains code examples for using path animations in your application.|  
  
<a name="reference"></a>   
## Reference  
 <xref:System.Windows.Media.Animation.Timeline>  
  
 <xref:System.Windows.Media.Animation.Storyboard>  
  
 <xref:System.Windows.Media.Animation.BeginStoryboard>  
  
 <xref:System.Windows.Media.Animation.Clock>
