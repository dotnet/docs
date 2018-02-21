---
title: "Custom Animations Overview"
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
  - "custom classes [WPF], animation"
  - "key frames [WPF], custom"
  - "custom key frames [WPF]"
  - "animation [WPF], custom classes"
  - "custom animation classes [WPF]"
ms.assetid: 9be69d50-3384-4938-886f-08ce00e4a7a6
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Custom Animations Overview
This topic describes how and when to extend the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation system by creating custom key frames, animation classes, or by using per-frame callback to bypass it.  
  
<a name="prerequisites"></a>   
## Prerequisites  
 To understand this topic, you should be familiar with the different types of animations provided by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)]. For more information, see the From/To/By Animations Overview, the [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md), and the [Path Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/path-animations-overview.md).  
  
 Because the animation classes inherit from the <xref:System.Windows.Freezable> class, you should be familiar with <xref:System.Windows.Freezable> objects and how to inherit from <xref:System.Windows.Freezable>. For more information, see the [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md).  
  
<a name="extendingtheanimationsystem"></a>   
## Extending the Animation System  
 There are a number of ways to extend the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation system, depending on the level of built-in functionality you want to use.  There are three primary extensibility points in the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation engine:  
  
-   Create a custom key frame object by inheriting from one of the *\<Type>*KeyFrame classes, such as <xref:System.Windows.Media.Animation.DoubleKeyFrame>. This approach uses most of the built-in functionality of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation engine.  
  
-   Create your own animation class by inheriting from <xref:System.Windows.Media.Animation.AnimationTimeline> or one of the *\<Type>*AnimationBase classes.  
  
-   Use per-frame callback to generate animations on a per-frame basis. This approach completely bypasses the animation and timing system.  
  
 The following table describes some the scenarios for extending the animation system.  
  
|When you want to...|Use this approach|  
|-------------------------|-----------------------|  
|Customize the interpolation between values of a type that has a corresponding *\<Type>*AnimationUsingKeyFrames|Create a custom key frame. For more information, see the [Create a Custom Key Frame](#createacustomkeyframe) section.|  
|Customize more than just the interpolation between values of a type that has a corresponding *\<Type>*Animation.|Create a custom animation class that inherits from the *\<Type>*AnimationBase class that corresponds to the type you want to animate. For more information, see the [Create a Custom Animation Class](#createacustomanimationtype) section.|  
|Animate a type that has no corresponding [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation|Use an <xref:System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames> or create a class that inherits from <xref:System.Windows.Media.Animation.AnimationTimeline>. For more information, see the [Create a Custom Animation Class](#createacustomanimationtype) section.|  
|Animate multiple objects with values that are computed each frame and are based on the last set of object interactions|Use per-frame callback. For more information, see the [Create a Use Per-Frame Callback](#useperframecallback) section.|  
  
<a name="createacustomkeyframe"></a>   
## Create a Custom Key Frame  
 Creating a custom key frame class is the simplest way to extend the animation system. Use this approach when you want to a different interpolation method for a key-frame animation.  As described in the [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md), a key-frame animation uses key frame objects to generate its output values. Each key frame object performs three functions:  
  
-   Specifies a target value using its <xref:System.Windows.Media.Animation.IKeyFrame.Value%2A> property.  
  
-   Specifies the time at which that value should be reached using its <xref:System.Windows.Media.Animation.IKeyFrame.KeyTime%2A> property.  
  
-   Interpolates between the value of the previous key frame and its own value by implementing the InterpolateValueCore method.  
  
 **Implementation Instructions**  
  
 Derive from the *\<Type>*KeyFrame abstract class and implement the InterpolateValueCore method. The InterpolateValueCore method returns the current value of the key frame. It takes two parameters: the value of the previous key frame and a progress value that ranges from 0 to 1. A progress of 0 indicates the key frame has just started, and a value of 1 indicates that the key frame has just completed and should return the value specified by its <xref:System.Windows.Media.Animation.IKeyFrame.Value%2A> property.  
  
 Because the *\<Type>*KeyFrame classes inherit from the <xref:System.Windows.Freezable> class, you must also override <xref:System.Windows.Freezable.CreateInstanceCore%2A> core to return a new instance of your class. If the class does not use dependency properties to store its data or it requires extra initialization after creation, you might need to override additional methods; see the [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md) for more information.  
  
 After you've created your custom *\<Type>*KeyFrame animation, you can use it with the *\<Type>*AnimationUsingKeyFrames for that type.  
  
<a name="createacustomanimationtype"></a>   
## Create a Custom Animation Class  
 Creating your own animation type gives you more control over how an object in animated. There are two recommended ways to create your own animation type: you can derive from the <xref:System.Windows.Media.Animation.AnimationTimeline> class or the *\<Type>*AnimationBase class. Deriving from the *\<Type>*Animation or *\<Type>*AnimationUsingKeyFrames classes is not recommended.  
  
### Derive from \<Type>AnimationBase  
 Deriving from a *\<Type>*AnimationBase class is the simplest way to create a new animation type. Use this approach when you want to create a new animation for type that already has a corresponding *\<Type>*AnimationBase class.  
  
 **Implementation Instructions**  
  
 Derive from a *\<Type>*Animation class and implement the GetCurrentValueCore method. The GetCurrentValueCore method returns the current value of the animation. It takes three parameters: a suggested starting value, a suggested ending value, and an <xref:System.Windows.Media.Animation.AnimationClock>, which you use to determine the progress of the animation.  
  
 Because the *\<Type>*AnimationBase classes inherit from the <xref:System.Windows.Freezable> class, you must also override <xref:System.Windows.Freezable.CreateInstanceCore%2A> core to return a new instance of your class. If the class does not use dependency properties to store its data or it requires extra initialization after creation, you might need to override additional methods; see the [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md) for more information.  
  
 For more information, see the GetCurrentValueCore method documentation for the *\<Type>*AnimationBase class for the type that you want to animate. For an example, see the [Custom Animation Sample](http://go.microsoft.com/fwlink/?LinkID=159981)  
  
 **Alternative Approaches**  
  
 If you simply want to change how animation values are interpolated, considering deriving from one of the *\<Type>*KeyFrame classes. The key frame you create can be used with the corresponding *\<Type>*AnimationUsingKeyFrames provided by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
### Derive from AnimationTimeline  
 Derive from the <xref:System.Windows.Media.Animation.AnimationTimeline> class when you want to create an animation for a type that doesn't already have a matching [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation, or you want to create an animation that is not strongly typed.  
  
 **Implementation Instructions**  
  
 Derive from the <xref:System.Windows.Media.Animation.AnimationTimeline> class and override the following members:  
  
-   <xref:System.Windows.Freezable.CreateInstanceCore%2A> – If your new class is concrete, you must override <xref:System.Windows.Freezable.CreateInstanceCore%2A> to return a new instance of your class.  
  
-   <xref:System.Windows.Media.Animation.AnimationTimeline.GetCurrentValue%2A> – Override this method to return the current value of your animation. It takes three parameters: a default origin value, a default destination value, and an <xref:System.Windows.Media.Animation.AnimationClock>. Use the <xref:System.Windows.Media.Animation.AnimationClock> to obtain the current time or progress for the animation. You can choose whether to use the default origin and destination values.  
  
-   <xref:System.Windows.Media.Animation.AnimationTimeline.IsDestinationDefault%2A> – Override this property to indicate whether your animation uses the default destination value specified by the <xref:System.Windows.Media.Animation.AnimationTimeline.GetCurrentValue%2A> method.  
  
-   <xref:System.Windows.Media.Animation.AnimationTimeline.TargetPropertyType%2A> – Override this property to indicate the <xref:System.Type> of output your animation produces.  
  
 If the class does not use dependency properties to store its data or it requires extra initialization after creation, you might need to override additional methods; see the [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md) for more information.  
  
 The recommended paradigm (used by [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animations) is to use two inheritance levels:  
  
1.  Create an abstract *\<Type>*AnimationBase class that derives from <xref:System.Windows.Media.Animation.AnimationTimeline>. This class should override the <xref:System.Windows.Media.Animation.AnimationTimeline.TargetPropertyType%2A> method. It should also introduce a new abstract method, GetCurrentValueCore, and override <xref:System.Windows.Media.Animation.AnimationTimeline.GetCurrentValue%2A> so that it validates the types of the default origin value and default destination value parameters, then calls GetCurrentValueCore.  
  
2.  Create another class that inherits from your new *\<Type>*AnimationBase class and overrides the <xref:System.Windows.Freezable.CreateInstanceCore%2A> method, the GetCurrentValueCore method that you introduced, and the <xref:System.Windows.Media.Animation.AnimationTimeline.IsDestinationDefault%2A> property.  
  
 **Alternative Approaches**  
  
 If you want to animate a type that has no corresponding From/To/By animation or key-frame animation, consider using an <xref:System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames>. Because it is weakly typed, an <xref:System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames> can animate any type of value. The drawback to this approach is that <xref:System.Windows.Media.Animation.ObjectAnimationUsingKeyFrames> only supports discrete interpolation.  
  
<a name="useperframecallback"></a>   
## Use Per-Frame Callback  
 Use this approach when you need to completely bypass the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] animation system. One scenario for this approach is physics animations, where at each animation step a new direction or position of animated objects needs to be recomputed based on the  last set of object interactions.  
  
 **Implementation Instructions**  
  
 Unlike the other approaches described in this overview, to use per-frame callback you don't need to create a custom animation or key frame class.  
  
 Instead, you register for the <xref:System.Windows.Media.CompositionTarget.Rendering> event of the object that contains the objects you want to animate. This event handler method gets called once per frame. Each time that [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] marshals the persisted rendering data in the visual tree across to the composition tree, your event handler method is called.  
  
 In your event handler, perform your whatever calculations necessary for your animation effect and set the properties of the objects you want to animate with these values.  
  
 To obtain the presentation time of the current frame, the <xref:System.EventArgs> associated with this event can be cast as <xref:System.Windows.Media.RenderingEventArgs>, which provide a <xref:System.Windows.Media.RenderingEventArgs.RenderingTime%2A> property that you can use to obtain the current frame's rendering time.  
  
 For more information, see the <xref:System.Windows.Media.CompositionTarget.Rendering> page.  
  
## See Also  
 <xref:System.Windows.Media.Animation.AnimationTimeline>  
 <xref:System.Windows.Media.Animation.IKeyFrame>  
 [Property Animation Techniques Overview](../../../../docs/framework/wpf/graphics-multimedia/property-animation-techniques-overview.md)  
 [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md)  
 [Key-Frame Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/key-frame-animations-overview.md)  
 [Path Animations Overview](../../../../docs/framework/wpf/graphics-multimedia/path-animations-overview.md)  
 [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md)  
 [Animation and Timing System Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-and-timing-system-overview.md)  
 [Custom Animation Sample](http://go.microsoft.com/fwlink/?LinkID=159981)
