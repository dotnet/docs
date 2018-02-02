---
title: "Storyboards Overview"
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
  - "Storyboard syntax [WPF]"
  - "syntax [WPF], Storyboard"
  - "timelines [WPF]"
ms.assetid: 1a698c3c-30f1-4b30-ae56-57e8a39811bd
caps.latest.revision: 31
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Storyboards Overview
This topic shows how to use <xref:System.Windows.Media.Animation.Storyboard> objects to organize and apply animations. It describes how to interactively manipulate <xref:System.Windows.Media.Animation.Storyboard> objects and describes indirect property targeting syntax.  
  
<a name="prerequisites"></a>   
## Prerequisites  
 To understand this topic, you should be familiar with the different animation types and their basic features. For an introduction to animation, see the [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md). You should also know how to use attached properties. For more information about attached properties, see the [Attached Properties Overview](../../../../docs/framework/wpf/advanced/attached-properties-overview.md).  
  
<a name="whatisatimeline"></a>   
## What Is a Storyboard?  
 Animations are not the only useful type of timeline. Other timeline classes are provided to help you organize sets of timelines, and to apply timelines to properties. Container timelines derive from the <xref:System.Windows.Media.Animation.TimelineGroup> class, and include <xref:System.Windows.Media.Animation.ParallelTimeline> and <xref:System.Windows.Media.Animation.Storyboard>.  
  
 A <xref:System.Windows.Media.Animation.Storyboard> is a type of container timeline that provides targeting information for the timelines it contains. A Storyboard can contain any type of <xref:System.Windows.Media.Animation.Timeline>, including other container timelines and animations. <xref:System.Windows.Media.Animation.Storyboard> objects enable you to combine timelines that affect a variety of objects and properties into a single timeline tree, making it easy to organize and control complex timing behaviors. For example, suppose you want a button that does these three things.  
  
-   Grow and change color when the user selects the button.  
  
-   Shrink away and then grow back to its original size when clicked.  
  
-   Shrink and fade to 50 percent opacity when it becomes disabled.  
  
 In this case, you have multiple sets of animations that apply to the same object, and you want to play at different times, dependent on the state of the button. <xref:System.Windows.Media.Animation.Storyboard> objects enable you to organize animations and apply them in groups to one or more objects.  
  
<a name="wherecanyouuseastoryboard"></a>   
## Where Can You Use a Storyboard?  
 A <xref:System.Windows.Media.Animation.Storyboard> can be used to animate dependency properties of animatable classes (for more information about what makes a class animatable, see the [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)). However, because storyboarding is a framework-level feature, the object must belong to the <xref:System.Windows.NameScope> of a <xref:System.Windows.FrameworkElement> or a <xref:System.Windows.FrameworkContentElement>.  
  
 For example, you could use a <xref:System.Windows.Media.Animation.Storyboard> to do the following:  
  
-   Animate a <xref:System.Windows.Media.SolidColorBrush> (Non-framework element) that paints the Background of a Button (a type of <xref:System.Windows.FrameworkElement>),  
  
-   Animate a <xref:System.Windows.Media.SolidColorBrush> (Non-framework element) that paints the fill of a <xref:System.Windows.Media.GeometryDrawing> (Non-framework element) displayed using an <xref:System.Windows.Controls.Image> (<xref:System.Windows.FrameworkElement>).  
  
-   In code, animate a <xref:System.Windows.Media.SolidColorBrush> declared by a class that also contains a <xref:System.Windows.FrameworkElement>, if the <xref:System.Windows.Media.SolidColorBrush> registered its name with that <xref:System.Windows.FrameworkElement>.  
  
 However, you could not use a <xref:System.Windows.Media.Animation.Storyboard> to animate a <xref:System.Windows.Media.SolidColorBrush> that did not register its name with a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>, or was not used to set a property of a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>.  
  
<a name="applyanimationswithastoryboard"></a>   
## How to Apply Animations with a Storyboard  
 To use a <xref:System.Windows.Media.Animation.Storyboard> to organize and apply animations, you add the animations as child timelines of the <xref:System.Windows.Media.Animation.Storyboard>. The <xref:System.Windows.Media.Animation.Storyboard> class provides the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A?displayProperty=nameWithType> and <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A?displayProperty=nameWithType> attached properties. You set these properties on an animation to specify its target object and property.  
  
 To apply animations to their targets, you begin the <xref:System.Windows.Media.Animation.Storyboard> using a trigger action or a method. In [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you use a <xref:System.Windows.Media.Animation.BeginStoryboard> object with an <xref:System.Windows.EventTrigger>, <xref:System.Windows.Trigger>, or <xref:System.Windows.DataTrigger>. In code, you can also use the  <xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method.  
  
 The following table shows the different places where each  <xref:System.Windows.Media.Animation.Storyboard> begin technique is supported: per-instance, style, control template, and data template. "Per-Instance" refers to the technique of applying an animation or storyboard directly to instances of an object, rather than in a style, control template, or data template.  
  
|Storyboard is begun using…|Per-instance|Style|Control template|Data template|Example|  
|--------------------------------|-------------------|-----------|----------------------|-------------------|-------------|  
|<xref:System.Windows.Media.Animation.BeginStoryboard> and an <xref:System.Windows.EventTrigger>|Yes|Yes|Yes|Yes|[Animate a Property by Using a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-a-property-by-using-a-storyboard.md)|  
|<xref:System.Windows.Media.Animation.BeginStoryboard> and a property <xref:System.Windows.Trigger>|No|Yes|Yes|Yes|[Trigger an Animation When a Property Value Changes](../../../../docs/framework/wpf/graphics-multimedia/how-to-trigger-an-animation-when-a-property-value-changes.md)|  
|<xref:System.Windows.Media.Animation.BeginStoryboard> and a <xref:System.Windows.DataTrigger>|No|Yes|Yes|Yes|[How to: Trigger an Animation When Data Changes](http://msdn.microsoft.com/library/a736bb3a-2ae5-479a-a33a-75a27055d863)|  
|<xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method|Yes|No|No|No|[Animate a Property by Using a Storyboard](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-a-property-by-using-a-storyboard.md)|  
  
 The following example uses a <xref:System.Windows.Media.Animation.Storyboard> to animate the <xref:System.Windows.FrameworkElement.Width%2A> of a <xref:System.Windows.Shapes.Rectangle> element and the <xref:System.Windows.Media.SolidColorBrush.Color%2A> of a <xref:System.Windows.Media.SolidColorBrush> used to paint that <xref:System.Windows.Shapes.Rectangle>.  
  
 [!code-xaml[storyboards_ovw_snip_XAML#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip_XAML/CS/StoryboardsExample.xaml#1)]  
  
 [!code-csharp[storyboards_ovw_snip#100](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/StoryboardsExample.cs#100)]  
  
 The following sections describe the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> and <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A> attached properties in more detail.  
  
<a name="targetingelementsandfreezables"></a>   
## Targeting Framework Elements, Framework Content Elements, and Freezables  
 The previous section mentioned that, for an animation to find its target, it must know the target's name and the property to animate. Specifying the property to animate is straight forward: simply set <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A?displayProperty=nameWithType> with the name of the property to animate.  You specify the name of the object whose property you want to animate by setting the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A?displayProperty=nameWithType> property on the animation.  
  
 For the <xref:System.Windows.Setter.TargetName%2A> property to work, the targeted object must have a name. Assigning a name to a <xref:System.Windows.FrameworkElement> or a <xref:System.Windows.FrameworkContentElement> in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] is different than assigning a name to a <xref:System.Windows.Freezable> object.  
  
 Framework elements are those classes that inherit from the <xref:System.Windows.FrameworkElement> class. Examples of framework elements include <xref:System.Windows.Window>, <xref:System.Windows.Controls.DockPanel>, <xref:System.Windows.Controls.Button>, and <xref:System.Windows.Shapes.Rectangle>. Essentially all windows, panels, and controls are elements. Framework content elements are those classes that inherit from the <xref:System.Windows.FrameworkContentElement> class. Examples of framework content elements include <xref:System.Windows.Documents.FlowDocument> and <xref:System.Windows.Documents.Paragraph>. If you're not sure whether a type is a framework element or a framework content element, check to see whether it has a Name property. If it does, it's probably a framework element or a framework content element. To be sure, check the Inheritance Hierarchy section of its type page.  
  
 To enable the targeting of a framework element or a framework content element in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you set its <xref:System.Windows.FrameworkElement.Name%2A> property. In code, you also need to use the <xref:System.Windows.NameScope.RegisterName%2A> method to register the element's name with the element for which you've created a <xref:System.Windows.NameScope>.  
  
 The following example, taken from the preceding example, assigns the name `MyRectangle` a <xref:System.Windows.Shapes.Rectangle>, a type of <xref:System.Windows.FrameworkElement>.  
  
 [!code-xaml[storyboards_ovw_snip_XAML#2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip_XAML/CS/StoryboardsExample.xaml#2)]  
  
 [!code-csharp[storyboards_ovw_snip#102](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/StoryboardsExample.cs#102)]  
  
 After it has a name, you can animate a property of that element.  
  
 [!code-xaml[storyboards_ovw_snip_XAML#5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip_XAML/CS/StoryboardsExample.xaml#5)]  
  
 [!code-csharp[storyboards_ovw_snip#105](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/StoryboardsExample.cs#105)]  
  
 <xref:System.Windows.Freezable> types are those classes that inherit from the <xref:System.Windows.Freezable> class. Examples of <xref:System.Windows.Freezable> include <xref:System.Windows.Media.SolidColorBrush>, <xref:System.Windows.Media.RotateTransform>, and <xref:System.Windows.Media.GradientStop>.  
  
 To enable the targeting of a <xref:System.Windows.Freezable> by an animation in  [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you use the [x:Name Directive](../../../../docs/framework/xaml-services/x-name-directive.md) to assign it a name. In code, you use the  <xref:System.Windows.NameScope.RegisterName%2A> method to register its name with the element for which you've created a <xref:System.Windows.NameScope>.  
  
 The following example assigns a name to a <xref:System.Windows.Freezable> object.  
  
 [!code-xaml[storyboards_ovw_snip_XAML#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip_XAML/CS/StoryboardsExample.xaml#3)]  
  
 [!code-csharp[storyboards_ovw_snip#103](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/StoryboardsExample.cs#103)]  
  
 The object can then be targeted by an animation.  
  
 [!code-xaml[storyboards_ovw_snip_XAML#7](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip_XAML/CS/StoryboardsExample.xaml#7)]  
  
 [!code-csharp[storyboards_ovw_snip#107](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/StoryboardsExample.cs#107)]  
  
 <xref:System.Windows.Media.Animation.Storyboard> objects use name scopes to resolve the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> property. For more information about WPF name scopes, see [WPF XAML Namescopes](../../../../docs/framework/wpf/advanced/wpf-xaml-namescopes.md). If the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> property is omitted, the animation targets the element on which it is defined, or, in the case of styles, the styled element.  
  
 Sometimes a name can't be assigned to a <xref:System.Windows.Freezable> object. For example, if a <xref:System.Windows.Freezable> is declared as a resource or used to set a property value in a style, it can't be given a name. Because it doesn't have a name, it can't be targeted directly—but it can be targeted indirectly. The following sections describe how to use indirect targeting.  
  
<a name="pathsyntaxforchangeable"></a>   
## Indirect Targeting  
 There are times a <xref:System.Windows.Freezable> can't be targeted directly by an animation, such as when the <xref:System.Windows.Freezable> is declared as a resource or used to set a property value in a style. In these cases, even though you can't target it directly, you can still animate the <xref:System.Windows.Freezable> object. Instead of setting the <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> property with the name of the <xref:System.Windows.Freezable>, you give it the name of the element to which the <xref:System.Windows.Freezable> "belongs." For example, a <xref:System.Windows.Media.SolidColorBrush> used to set the <xref:System.Windows.Shapes.Shape.Fill%2A> of a rectangle element belongs to that rectangle. To animate the brush, you would set the animation's <xref:System.Windows.Media.Animation.Storyboard.TargetProperty%2A> with a chain of properties that starts at the property of the framework element or framework content element the <xref:System.Windows.Freezable> was used to set and ends with the <xref:System.Windows.Freezable> property to animate.  
  
 [!code-xaml[storyboards_ovw_snip_XAML#33](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip_XAML/CS/IndirectTargetingExample.xaml#33)]  
  
 [!code-csharp[storyboards_ovw_snip#134](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/IndirectTargetingExample.xaml.cs#134)]  
  
 Note that, if the <xref:System.Windows.Freezable> is frozen, a clone will be made, and that clone will be animated. When this happens, the original object's <xref:System.Windows.Media.Animation.Animatable.HasAnimatedProperties%2A> property continues to return `false`, because the original object is not actually animated. For more information about cloning, see the [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md).  
  
 Also note that, when using indirect property targeting, it's possible to target objects that don't exist. For example, you might assume that the <xref:System.Windows.Controls.Control.Background%2A> of a particular button was set with a <xref:System.Windows.Media.SolidColorBrush> and try to animate its Color, when in fact a <xref:System.Windows.Media.LinearGradientBrush> was used to set the button's Background. In these cases, no exception is thrown; the animation fails to have a visible effect because <xref:System.Windows.Media.LinearGradientBrush> does not react to changes to the <xref:System.Windows.Media.SolidColorBrush.Color%2A> property.  
  
 The following sections describe indirect property targeting syntax in more detail.  
  
<a name="xamlsyntaxchangeableproperty"></a>   
### Indirectly Targeting a Property of a Freezable in XAML  
 To target a property of a freezable in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], use the following syntax.  
  
||  
|-|  
|*ElementPropertyName* `.` *FreezablePropertyName*|  
  
 Where  
  
-   *ElementPropertyName* is the property of the <xref:System.Windows.FrameworkElement> which the <xref:System.Windows.Freezable> is used to set, and  
  
-   *FreezablePropertyName* is the property of the <xref:System.Windows.Freezable> to animate.  
  
 The following code shows how to animate the <xref:System.Windows.Media.SolidColorBrush.Color%2A> of a <xref:System.Windows.Media.SolidColorBrush> used to set the  
  
 <xref:System.Windows.Shapes.Shape.Fill%2A> of a rectangle element.  
  
 [!code-xaml[storyboards_ovw_snip_XAML#32](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip_XAML/CS/IndirectTargetingExample.xaml#32)]  
  
 Sometimes you need to target a freezable contained in a collection or array.  
  
 To target a freezable contained in a collection, you use the following path syntax.  
  
||  
|-|  
|*ElementPropertyName* `.Children[` *CollectionIndex* `].` *FreezablePropertyName*|  
  
 Where *CollectionIndex* is the index of the object in its array or collection.  
  
 For example, suppose that a rectangle has a <xref:System.Windows.Media.TransformGroup> resource applied to its <xref:System.Windows.UIElement.RenderTransform%2A> property, and you want to animate one of the transforms it contains.  
  
 [!code-xaml[storyboards_ovw_snip_XAML#34](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip_XAML/CS/IndirectTargetingExample.xaml#34)]  
  
 The following code shows how to animate the <xref:System.Windows.Media.RotateTransform.Angle%2A> property of the <xref:System.Windows.Media.RotateTransform> shown in the previous example.  
  
 [!code-xaml[storyboards_ovw_snip_XAML#35](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip_XAML/CS/IndirectTargetingExample.xaml#35)]  
  
<a name="targetingpropertyofchangeableincode"></a>   
### Indirectly Targeting a Property of a Freezable in Code  
 In code, you create a <xref:System.Windows.PropertyPath> object. When you create the <xref:System.Windows.PropertyPath>, you specify a <xref:System.Windows.PropertyPath.Path%2A> and <xref:System.Windows.PropertyPath.PathParameters%2A>.  
  
 To create <xref:System.Windows.PropertyPath.PathParameters%2A>, you create an array of type <xref:System.Windows.DependencyProperty> that contains a list of dependency property identifier fields. The first identifier field is for the property of the <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> that the <xref:System.Windows.Freezable> is used to set. The next identifier field represents the property of the <xref:System.Windows.Freezable> to target. Think of it as a chain of properties that connects the <xref:System.Windows.Freezable> to the <xref:System.Windows.FrameworkElement> object.  
  
 The following is an example of a dependency property chain that targets the <xref:System.Windows.Media.SolidColorBrush.Color%2A> of a <xref:System.Windows.Media.SolidColorBrush> used to set the <xref:System.Windows.Shapes.Shape.Fill%2A> of a rectangle element.  
  
 [!code-csharp[storyboards_ovw_snip#135](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/IndirectTargetingExample.xaml.cs#135)]  
  
 You also need to specify a <xref:System.Windows.PropertyPath.Path%2A>. A <xref:System.Windows.PropertyPath.Path%2A> is a <xref:System.String> that tells the <xref:System.Windows.PropertyPath.Path%2A> how to interpret its <xref:System.Windows.PropertyPath.PathParameters%2A>. It uses the following syntax.  
  
||  
|-|  
|`(` *OwnerPropertyArrayIndex* `).(` *FreezablePropertyArrayIndex* `)`|  
  
 Where  
  
-   *OwnerPropertyArrayIndex* is the index of the <xref:System.Windows.DependencyProperty> array that contains the identifier of the <xref:System.Windows.FrameworkElement> object's property that the <xref:System.Windows.Freezable> is used to set, and  
  
-   *FreezablePropertyArrayIndex* is the index of the <xref:System.Windows.DependencyProperty> array that contains the identifier of property to target.  
  
 The following example shows the <xref:System.Windows.PropertyPath.Path%2A> that would accompany the <xref:System.Windows.PropertyPath.PathParameters%2A> defined in the preceding example.
  
 [!code-csharp[storyboards_ovw_snip#PropertyChainAndPath](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/IndirectTargetingExample.xaml.cs#propertychainandpath)]  
  
 The following example combines the code in the previous examples to animate the <xref:System.Windows.Media.SolidColorBrush.Color%2A> of a <xref:System.Windows.Media.SolidColorBrush> used to set the <xref:System.Windows.Shapes.Shape.Fill%2A> of a rectangle element.  
  
 [!code-csharp[storyboards_ovw_snip#137](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/IndirectTargetingExample.xaml.cs#137)]  
  
 Sometimes you need to target a freezable contained in a collection or array. For example, suppose that a rectangle has a <xref:System.Windows.Media.TransformGroup> resource applied to its <xref:System.Windows.UIElement.RenderTransform%2A> property, and you want to animate one of the transforms it contains.  
  
 [!code-xaml[storyboards_ovw_snip#142](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/IndirectTargetingExample.xaml#142)]  
  
 To target a <xref:System.Windows.Freezable> contained in a collection, you use the following path syntax.  
  
||  
|-|  
|`(` *OwnerPropertyArrayIndex* `).(` *CollectionChildrenPropertyArrayIndex* `)` `[` *CollectionIndex* `].(` *FreezablePropertyArrayIndex* `)`|  
  
 Where *CollectionIndex* is the index of the object in its array or collection.  
  
 To target the <xref:System.Windows.Media.RotateTransform.Angle%2A> property of the <xref:System.Windows.Media.RotateTransform>, the second transform in the <xref:System.Windows.Media.TransformGroup>, you would use the following <xref:System.Windows.PropertyPath.Path%2A> and <xref:System.Windows.PropertyPath.PathParameters%2A>.  
  
 [!code-csharp[storyboards_ovw_snip#139](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/IndirectTargetingExample.xaml.cs#139)]  
  
 The following example shows the complete code for animating the <xref:System.Windows.Media.RotateTransform.Angle%2A> of a <xref:System.Windows.Media.RotateTransform> contained within a <xref:System.Windows.Media.TransformGroup>.  
  
 [!code-csharp[storyboards_ovw_snip#138](../../../../samples/snippets/csharp/VS_Snippets_Wpf/storyboards_ovw_snip/CSharp/IndirectTargetingExample.xaml.cs#138)]  
  
### Indirectly Targeting with a Freezable as the Starting Point  
 The previous sections described how to indirectly target a <xref:System.Windows.Freezable> by starting with a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> and creating a property chain to a <xref:System.Windows.Freezable> sub-property. You can also use a <xref:System.Windows.Freezable> as a starting point and indirectly target one of its <xref:System.Windows.Freezable> sub-properties. One additional restriction applies when using a <xref:System.Windows.Freezable> as a starting point for indirect targeting: the starting <xref:System.Windows.Freezable> and every <xref:System.Windows.Freezable> between it and the indirectly targeted sub-property must not be frozen.  
  
<a name="controllable_storyboards"></a>   
## Interactively Controlling a Storyboard in XAML  
 To start a storyboard in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)], you use a <xref:System.Windows.Media.Animation.BeginStoryboard> trigger action. <xref:System.Windows.Media.Animation.BeginStoryboard> distributes the animations to the objects and properties they animate, and starts the storyboard. (For details about this process, see the [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md).) If you give the <xref:System.Windows.Media.Animation.BeginStoryboard> a name by specifying its <xref:System.Windows.Media.Animation.BeginStoryboard.Name%2A> property, you make it a controllable storyboard. You can then interactively control the storyboard after it's started. The following is a list of controllable storyboard actions that you use with event triggers to control a storyboard.  
  
-   <xref:System.Windows.Media.Animation.PauseStoryboard>: Pauses the storyboard.  
  
-   <xref:System.Windows.Media.Animation.ResumeStoryboard>: Resumes a paused storyboard.  
  
-   <xref:System.Windows.Media.Animation.SetStoryboardSpeedRatio>: Changes the storyboard's speed.  
  
-   <xref:System.Windows.Media.Animation.SkipStoryboardToFill>: Advances a storyboard to the end of its fill period, if it has one.  
  
-   <xref:System.Windows.Media.Animation.StopStoryboard>: Stops the storyboard.  
  
-   <xref:System.Windows.Media.Animation.RemoveStoryboard>: Removes the storyboard.  
  
 In the following example, controllable storyboard actions are used to interactively control a storyboard.  
  
 [!code-xaml[animation_ovws_snip#ControllableStoryboardExampleWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_snip/CS/ControllableStoryboardExample.xaml#controllablestoryboardexamplewholepage)]  
  
<a name="controllable_storyboards_procedural"></a>   
## Interactively Controlling a Storyboard by Using Code  
 The previous examples have shown how to animate using trigger actions. In code, you may also control a storyboard using interactive methods of the <xref:System.Windows.Media.Animation.Storyboard> class. For a <xref:System.Windows.Media.Animation.Storyboard> to be made interactive in code, you must use the appropriate overload of the storyboard's <xref:System.Windows.Media.Animation.Storyboard.Begin%2A> method and specify `true` to make it controllable. See the <xref:System.Windows.Media.Animation.Storyboard.Begin%28System.Windows.FrameworkElement%2CSystem.Boolean%29> page for more information.  
  
 The following list shows the methods that can be used to manipulate a <xref:System.Windows.Media.Animation.Storyboard> after it has started:  
  
-   <xref:System.Windows.Media.Animation.Storyboard.Pause%2A>  
  
-   <xref:System.Windows.Media.Animation.Storyboard.Resume%2A>  
  
-   <xref:System.Windows.Media.Animation.Storyboard.Seek%2A>  
  
-   <xref:System.Windows.Media.Animation.Storyboard.SkipToFill%2A>  
  
-   <xref:System.Windows.Media.Animation.Storyboard.Stop%2A>  
  
-   <xref:System.Windows.Media.Animation.Storyboard.Remove%2A>  
  
 The advantage to using these methods is that you don't need to create <xref:System.Windows.Trigger> or <xref:System.Windows.TriggerAction> objects; you just need a reference to the controllable <xref:System.Windows.Media.Animation.Storyboard> you want to manipulate.  
  
 **Note:** All interactive actions taken on a <xref:System.Windows.Media.Animation.Clock>, and therefore also on a <xref:System.Windows.Media.Animation.Storyboard> will occur on the next tick of the timing engine which will happen shortly before the next render. For example, if you use the <xref:System.Windows.Media.Animation.Storyboard.Seek%2A> method to jump to another point in an animation, the property value does not change instantly, rather, the value changes on the next tick of the timing engine.  
  
 The following example shows how to apply and control animations using the interactive methods of the <xref:System.Windows.Media.Animation.Storyboard> class.  
  
 [!code-csharp[animation_ovws_procedural_snip#ControllableStoryboardExampleWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/animation_ovws_procedural_snip/CSharp/ControllableStoryboardExample.cs#controllablestoryboardexamplewholepage)]
 [!code-vb[animation_ovws_procedural_snip#ControllableStoryboardExampleWholePage](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/animation_ovws_procedural_snip/visualbasic/controllablestoryboardexample.vb#controllablestoryboardexamplewholepage)]  
  
<a name="usingstoryboardsinstyles"></a>   
## Animate in a Style  
 You can use <xref:System.Windows.Media.Animation.Storyboard> objects to define animations in a <xref:System.Windows.Style>. Animating with a <xref:System.Windows.Media.Animation.Storyboard> in a <xref:System.Windows.Style> is similar to using a <xref:System.Windows.Media.Animation.Storyboard> elsewhere, with the following three exceptions:  
  
-   You don't specify a <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A>; the <xref:System.Windows.Media.Animation.Storyboard> always targets the element to which the <xref:System.Windows.Style> is applied. To target <xref:System.Windows.Freezable> objects, you must use indirect targeting. For more information about indirect targeting, see the [Indirect Targeting](#pathsyntaxforchangeable) section.  
  
-   You can't specify a <xref:System.Windows.EventTrigger.SourceName%2A> for an <xref:System.Windows.EventTrigger> or a <xref:System.Windows.Trigger>.  
  
-   You can't use dynamic resource references or data binding expressions to set <xref:System.Windows.Media.Animation.Storyboard> or animation property values. That's because everything inside a <xref:System.Windows.Style> must be thread-safe, and the timing system must <xref:System.Windows.Freezable.Freeze%2A><xref:System.Windows.Media.Animation.Storyboard> objects to make them thread-safe. A <xref:System.Windows.Media.Animation.Storyboard> cannot be frozen if it or its child timelines contain dynamic resource references or data binding expressions. For more information about freezing and other <xref:System.Windows.Freezable> features, see the [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md).  
  
-   In [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you can't declare event handlers for <xref:System.Windows.Media.Animation.Storyboard> or animation events.  
  
 For an example showing how to define a storyboard in a style, see the [Animate in a Style](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-in-a-style.md) example.  
  
<a name="defineAStoryboardInAControlTemplateSection"></a>   
## Animate in a ControlTemplate  
 You can use <xref:System.Windows.Media.Animation.Storyboard> objects to define animations in a <xref:System.Windows.Controls.ControlTemplate>. Animating with a <xref:System.Windows.Media.Animation.Storyboard> in a <xref:System.Windows.Controls.ControlTemplate> is similar to using a <xref:System.Windows.Media.Animation.Storyboard> elsewhere, with the following two exceptions:  
  
-   The <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> may only refer to child objects of the <xref:System.Windows.Controls.ControlTemplate>. If <xref:System.Windows.Media.Animation.Storyboard.TargetName%2A> is not specified, the animation targets the element to which the <xref:System.Windows.Controls.ControlTemplate> is applied.  
  
-   The <xref:System.Windows.EventTrigger.SourceName%2A> for an <xref:System.Windows.EventTrigger> or a <xref:System.Windows.Trigger> may only refer to child objects of the <xref:System.Windows.Controls.ControlTemplate>.  
  
-   You can't use dynamic resource references or data binding expressions to set <xref:System.Windows.Media.Animation.Storyboard> or animation property values. That's because everything inside a <xref:System.Windows.Controls.ControlTemplate> must be thread-safe, and the timing system must <xref:System.Windows.Freezable.Freeze%2A><xref:System.Windows.Media.Animation.Storyboard> objects to make them thread-safe. A <xref:System.Windows.Media.Animation.Storyboard> cannot be frozen if it or its child timelines contain dynamic resource references or data binding expressions. For more information about freezing and other <xref:System.Windows.Freezable> features, see the [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md).  
  
-   In [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], you can't declare event handlers for <xref:System.Windows.Media.Animation.Storyboard> or animation events.  
  
 For an example showing how to define a storyboard in a <xref:System.Windows.Controls.ControlTemplate>, see the [Animate in a ControlTemplate](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-in-a-controltemplate.md) example.  
  
<a name="animateWhenAPropertyValueChanges"></a>   
## Animate When a Property Value Changes  
 In styles and control templates, you can use Trigger objects to start a storyboard when a property changes. For examples, see [Trigger an Animation When a Property Value Changes](../../../../docs/framework/wpf/graphics-multimedia/how-to-trigger-an-animation-when-a-property-value-changes.md) and [Animate in a ControlTemplate](../../../../docs/framework/wpf/graphics-multimedia/how-to-animate-in-a-controltemplate.md).  
  
 Animations applied by property <xref:System.Windows.Trigger> objects behave in a more complex fashion than <xref:System.Windows.EventTrigger> animations or animations started using <xref:System.Windows.Media.Animation.Storyboard> methods.  They "handoff" with animations defined by other <xref:System.Windows.Trigger> objects, but compose with <xref:System.Windows.EventTrigger> and method-triggered animations.  
  
## See Also  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Property Animation Techniques Overview](../../../../docs/framework/wpf/graphics-multimedia/property-animation-techniques-overview.md)  
 [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md)
