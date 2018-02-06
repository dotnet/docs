---
title: "Freezable Objects Overview"
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
  - "Freezable objects [WPF], description"
  - "unfreezing Freezable objects [WPF]"
  - "classes [WPF], Freezable"
ms.assetid: 89c71692-4f43-4057-b611-67c6a8a863a2
caps.latest.revision: 30
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Freezable Objects Overview
This topic describes how to effectively use and create <xref:System.Windows.Freezable> objects, which provide special features that can help improve application performance. Examples of freezable objects include brushes, pens, transformations, geometries, and animations.  
  
<a name="whatisafreezable"></a>   
## What Is a Freezable?  
 A <xref:System.Windows.Freezable> is a special type of object that has two states: unfrozen and frozen. When unfrozen, a <xref:System.Windows.Freezable> appears to behave like any other object. When frozen, a <xref:System.Windows.Freezable> can no longer be modified.  
  
 A <xref:System.Windows.Freezable> provides a <xref:System.Windows.Freezable.Changed> event to notify observers of any modifications to the object. Freezing a <xref:System.Windows.Freezable> can improve its performance, because it no longer needs to spend resources on change notifications. A frozen <xref:System.Windows.Freezable> can also be shared across threads, while an unfrozen <xref:System.Windows.Freezable> cannot.  
  
 Although the <xref:System.Windows.Freezable> class has many applications, most <xref:System.Windows.Freezable> objects in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] are related to the graphics sub-system.  
  
 The <xref:System.Windows.Freezable> class makes it easier to use certain graphics system objects and can help improve application performance. Examples of types that inherit from <xref:System.Windows.Freezable> include the <xref:System.Windows.Media.Brush>, <xref:System.Windows.Media.Transform>, and <xref:System.Windows.Media.Geometry> classes. Because they contain unmanaged resources, the system must monitor these objects for modifications, and then update their corresponding unmanaged resources when there is a change to the original object. Even if you don't actually modify a graphics system object, the system must still spend some of its resources monitoring the object, in case you do change it.  
  
 For example, suppose you create a <xref:System.Windows.Media.SolidColorBrush> brush and use it to paint the background of a button.  
  
 [!code-csharp[freezablesample_procedural#FrozenExamplePart1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/freezablesample_procedural/CSharp/freezablesample.cs#frozenexamplepart1)]
 [!code-vb[freezablesample_procedural#FrozenExamplePart1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/freezablesample_procedural/visualbasic/freezablesample.vb#frozenexamplepart1)]  
  
 When the button is rendered, the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] graphics sub-system uses the information you provided to paint a group of pixels to create the appearance of a button. Although you used a solid color brush to describe how the button should be painted, your solid color brush doesn't actually do the painting. The graphics system generates fast, low-level objects for the button and the brush, and it is those objects that actually appear on the screen.  
  
 If you were to modify the brush, those low-level objects would have to be regenerated. The freezable class is what gives a brush the ability to find its corresponding generated, low-level objects and to update them when it changes. When this ability is enabled, the brush is said to be "unfrozen."  
  
 A freezable's <xref:System.Windows.Freezable.Freeze%2A> method enables you to disable this self-updating ability. You can use this method to make the brush become "frozen," or unmodifiable.  
  
> [!NOTE]
>  Not every Freezable object can be frozen. To avoid throwing an <xref:System.InvalidOperationException>, check the value of the Freezable object's <xref:System.Windows.Freezable.CanFreeze%2A> property to determine whether it can be frozen before attempting to freeze it.  
  
 [!code-csharp[freezablesample_procedural#FrozenExamplePart2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/freezablesample_procedural/CSharp/freezablesample.cs#frozenexamplepart2)]
 [!code-vb[freezablesample_procedural#FrozenExamplePart2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/freezablesample_procedural/visualbasic/freezablesample.vb#frozenexamplepart2)]  
  
 When you no longer need to modify a freezable, freezing it provides performance benefits. If you were to freeze the brush in this example, the graphics system would no longer need to monitor it for changes. The graphics system can also make other optimizations, because it knows the brush won't change.  
  
> [!NOTE]
>  For convenience, freezable objects remain unfrozen unless you explicitly freeze them.  
  
<a name="frozenfreezables"></a>   
## Using Freezables  
 Using an unfrozen freezable is like using any other type of object. In the following example, the color of a <xref:System.Windows.Media.SolidColorBrush> is changed from yellow to red after it's used to paint the background of a button. The graphics system works behind the scenes to automatically change the button from yellow to red the next time the screen is refreshed.  
  
 [!code-csharp[freezablesample_procedural#UnFrozenExampleShort](../../../../samples/snippets/csharp/VS_Snippets_Wpf/freezablesample_procedural/CSharp/freezablesample.cs#unfrozenexampleshort)]
 [!code-vb[freezablesample_procedural#UnFrozenExampleShort](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/freezablesample_procedural/visualbasic/freezablesample.vb#unfrozenexampleshort)]  
  
### Freezing a Freezable  
 To make a <xref:System.Windows.Freezable> unmodifiable, you call its <xref:System.Windows.Freezable.Freeze%2A> method. When you freeze an object that contains freezable objects, those objects are frozen as well. For example, if you freeze a <xref:System.Windows.Media.PathGeometry>, the figures and segments it contains would be frozen too.  
  
 A Freezable **can't** be frozen if any of the following are true:  
  
-   It has animated or data bound properties.  
  
-   It has properties set by a dynamic resource. (See the [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md) for more information about dynamic resources.)  
  
-   It contains <xref:System.Windows.Freezable> sub-objects that can't be frozen.  
  
 If these conditions are false, and you don't intend to modify the <xref:System.Windows.Freezable>, then you should freeze it to gain the performance benefits described earlier.  
  
 Once you call a freezable's <xref:System.Windows.Freezable.Freeze%2A> method, it can no longer be modified. Attempting to modify a frozen object causes an <xref:System.InvalidOperationException> to be thrown. The following code throws an exception, because we attempt to modify the brush after it's been frozen.  
  
 [!code-csharp[freezablesample_procedural#ExceptionExample](../../../../samples/snippets/csharp/VS_Snippets_Wpf/freezablesample_procedural/CSharp/freezablesample.cs#exceptionexample)]
 [!code-vb[freezablesample_procedural#ExceptionExample](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/freezablesample_procedural/visualbasic/freezablesample.vb#exceptionexample)]  
  
 To avoid throwing this exception, you can use the <xref:System.Windows.Freezable.IsFrozen%2A> method to determine whether a <xref:System.Windows.Freezable> is frozen.  
  
 [!code-csharp[freezablesample_procedural#CheckIsFrozenExample](../../../../samples/snippets/csharp/VS_Snippets_Wpf/freezablesample_procedural/CSharp/freezablesample.cs#checkisfrozenexample)]
 [!code-vb[freezablesample_procedural#CheckIsFrozenExample](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/freezablesample_procedural/visualbasic/freezablesample.vb#checkisfrozenexample)]  
  
 In the preceding code example, a modifiable copy was made of a frozen object using the <xref:System.Windows.Freezable.Clone%2A> method. The next section discusses cloning in more detail.  
  
 **Note** Because a frozen freezable cannot be animated, the animation system will automatically create modifiable clones of frozen <xref:System.Windows.Freezable> objects when you try to animate them with a <xref:System.Windows.Media.Animation.Storyboard>. To eliminate the performance overhead caused by cloning, leave an object unfrozen if you intend to animate it. For more information about animating with storyboards, see the [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md).  
  
### Freezing from Markup  
 To freeze a <xref:System.Windows.Freezable> object declared in markup, you use the `PresentationOptions:Freeze` attribute. In the following example, a <xref:System.Windows.Media.SolidColorBrush> is declared as a page resource and frozen. It is then used to set the background of a button.  
  
 [!code-xaml[FreezableSample#FreezeFromMarkupWholePage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FreezableSample/CS/FreezeFromMarkupExample.xaml#freezefrommarkupwholepage)]  
  
 To use the `Freeze` attribute, you must map to the presentation options namespace: `http://schemas.microsoft.com/winfx/2006/xaml/presentation/options`. `PresentationOptions` is the recommended prefix for mapping this namespace:  
  
```  
xmlns:PresentationOptions="http://schemas.microsoft.com/winfx/2006/xaml/presentation/options"   
```  
  
 Because not all XAML readers recognize this attribute, it's recommended that you use the [mc:Ignorable Attribute](../../../../docs/framework/wpf/advanced/mc-ignorable-attribute.md) to mark the `Presentation:Freeze` attribute as ignorable:  
  
```  
xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"  
mc:Ignorable="PresentationOptions"  
```  
  
 For more information, see the [mc:Ignorable Attribute](../../../../docs/framework/wpf/advanced/mc-ignorable-attribute.md) page.  
  
### "Unfreezing" a Freezable  
 Once frozen, a <xref:System.Windows.Freezable> can never be modified or unfrozen; however, you can create an unfrozen clone using the <xref:System.Windows.Freezable.Clone%2A> or <xref:System.Windows.Freezable.CloneCurrentValue%2A> method.  
  
 In the following example, the button's background is set with a brush and that brush is then frozen. An unfrozen copy is made of the brush using the <xref:System.Windows.Freezable.Clone%2A> method. The clone is modified and used to change the button's background from yellow to red.  
  
 [!code-csharp[freezablesample_procedural#CloneExample](../../../../samples/snippets/csharp/VS_Snippets_Wpf/freezablesample_procedural/CSharp/freezablesample.cs#cloneexample)]
 [!code-vb[freezablesample_procedural#CloneExample](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/freezablesample_procedural/visualbasic/freezablesample.vb#cloneexample)]  
  
> [!NOTE]
>  Regardless of which clone method you use, animations are never copied to the new <xref:System.Windows.Freezable>.  
  
 The <xref:System.Windows.Freezable.Clone%2A> and <xref:System.Windows.Freezable.CloneCurrentValue%2A> methods produce deep copies of the freezable. If the freezable contains other frozen freezable objects, they are also cloned and made modifiable. For example, if you clone a frozen <xref:System.Windows.Media.PathGeometry> to make it modifiable, the figures and segments it contains are also copied and made modifiable.  
  
<a name="createyourownfreezableclass"></a>   
## Creating Your Own Freezable Class  
 A class that derives from <xref:System.Windows.Freezable> gains the following features.  
  
-   Special states: a read-only (frozen) and a writable state.  
  
-   Thread safety: a frozen <xref:System.Windows.Freezable> can be shared across threads.  
  
-   Detailed change notification: Unlike other <xref:System.Windows.DependencyObject>s, Freezable objects provide change notifications when sub-property values change.  
  
-   Easy cloning: the Freezable class has already implemented several methods that produce deep clones.  
  
 A <xref:System.Windows.Freezable> is a type of <xref:System.Windows.DependencyObject>, and therefore uses the dependency property system. Your class properties don't have to be dependency properties, but using dependency properties will reduce the amount of code you have to write, because the <xref:System.Windows.Freezable> class was designed with dependency properties in mind. For more information about the dependency property system, see the [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md).  
  
 Every <xref:System.Windows.Freezable> subclass must override the <xref:System.Windows.Freezable.CreateInstanceCore%2A> method. If your class uses dependency properties for all its data, you're finished.  
  
 If your class contains non-dependency property data members, you must also override the following methods:  
  
-   <xref:System.Windows.Freezable.CloneCore%2A>  
  
-   <xref:System.Windows.Freezable.CloneCurrentValueCore%2A>  
  
-   <xref:System.Windows.Freezable.GetAsFrozenCore%2A>  
  
-   <xref:System.Windows.Freezable.GetCurrentValueAsFrozenCore%2A>  
  
-   <xref:System.Windows.Freezable.FreezeCore%2A>  
  
 You must also observe the following rules for accessing and writing to data members that are not dependency properties:  
  
-   At the beginning of any [!INCLUDE[TLA#tla_api](../../../../includes/tlasharptla-api-md.md)] that reads non-dependency property data members, call the <xref:System.Windows.Freezable.ReadPreamble%2A> method.  
  
-   At the beginning of any API that writes non-dependency property data members, call the <xref:System.Windows.Freezable.WritePreamble%2A> method. (Once you've called <xref:System.Windows.Freezable.WritePreamble%2A> in an [!INCLUDE[TLA2#tla_api](../../../../includes/tla2sharptla-api-md.md)], you don't need to make an additional call to <xref:System.Windows.Freezable.ReadPreamble%2A> if you also read non-dependency property data members.)  
  
-   Call the <xref:System.Windows.Freezable.WritePostscript%2A> method before exiting methods that write to non-dependency property data members.  
  
 If your class contains non-dependency-property data members that are <xref:System.Windows.DependencyObject> objects, you must also call the <xref:System.Windows.Freezable.OnFreezablePropertyChanged%2A> method each time you change on of their values, even if you're setting the member to `null`.  
  
> [!NOTE]
>  It's very important that you begin each <xref:System.Windows.Freezable> method you override with a call to the base implementation.  
  
 For an example of a custom <xref:System.Windows.Freezable> class, see the [Custom Animation Sample](http://go.microsoft.com/fwlink/?LinkID=159981).  
  
## See Also  
 <xref:System.Windows.Freezable>  
 [Custom Animation Sample](http://go.microsoft.com/fwlink/?LinkID=159981)  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)
