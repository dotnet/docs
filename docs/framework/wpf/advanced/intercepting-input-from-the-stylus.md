---
title: "Intercepting Input from the Stylus"
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
  - "architecture [WPF], "
  - ", "
  - ", "
  - ", "
ms.assetid: 791bb2f0-4e5c-4569-ac3c-211996808d44
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Intercepting Input from the Stylus
The <xref:System.Windows.Input.StylusPlugIns> architecture provides a mechanism for implementing low-level control over <xref:System.Windows.Input.Stylus> input and the creation of digital ink <xref:System.Windows.Ink.Stroke> objects. The <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> class provides a mechanism for you to implement custom behavior and apply it to the stream of data coming from the stylus device for the optimal performance.  
  
 This topic contains the following subsections:  
  
-   [Architecture](#Architecture)  
  
-   [Implementing Stylus Plug-ins](#ImplementingStylusPlugins)  
  
-   [Adding Your Plug-in to an InkCanvas](#AddingYourPluginToAnInkCanvas)  
  
-   [Conclusion](#Conclusion)  
  
<a name="Architecture"></a>   
## Architecture  
 The <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> is the evolution of the [StylusInput](http://go.microsoft.com/fwlink/?LinkId=50753&clcid=0x409) APIs, described in [Accessing and Manipulating Pen Input](http://go.microsoft.com/fwlink/?LinkId=50752&clcid=0x409), in the [Microsoft Windows XP Tablet PC Edition Software Development Kit 1.7](http://go.microsoft.com/fwlink/?linkid=11782&clcid=0x409).  
  
 Each <xref:System.Windows.UIElement> has a <xref:System.Windows.UIElement.StylusPlugIns%2A> property that is a <xref:System.Windows.Input.StylusPlugIns.StylusPlugInCollection>. You can add a <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> to an element's <xref:System.Windows.UIElement.StylusPlugIns%2A> property to manipulate <xref:System.Windows.Input.StylusPoint> data as it is generated. <xref:System.Windows.Input.StylusPoint> data consists of all the properties supported by the system digitizer, including the <xref:System.Windows.Input.StylusPoint.X%2A> and <xref:System.Windows.Input.StylusPoint.Y%2A> point data, as well as <xref:System.Windows.Input.StylusPoint.PressureFactor%2A> data.  
  
 Your <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> objects are inserted directly into the stream of data coming from the <xref:System.Windows.Input.Stylus> device when you add the <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> to the <xref:System.Windows.UIElement.StylusPlugIns%2A> property. The order in which plug-ins are added to the <xref:System.Windows.UIElement.StylusPlugIns%2A> collection dictates the order in which they will receive <xref:System.Windows.Input.StylusPoint> data. For example, if you add a filter plug-in that restricts input to a particular region, and then add a plug-in that recognizes gestures as they are written, the plug-in that recognizes gestures will receive filtered <xref:System.Windows.Input.StylusPoint> data.  
  
<a name="ImplementingStylusPlugins"></a>   
## Implementing Stylus Plug-ins  
 To implement a plug-in, derive a class from <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn>. This class is applied o the stream of data as it comes in from the <xref:System.Windows.Input.Stylus>. In this class you can modify the values of the <xref:System.Windows.Input.StylusPoint> data.  
  
> [!CAUTION]
>  If a <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> throws or causes an exception, the application will close. You should thoroughly test controls that consume a <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> and only use a control if you are certain the <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> will not throw an exception.  
  
 The following example demonstrates a plug-in that restricts the stylus input by modifying the <xref:System.Windows.Input.StylusPoint.X%2A> and <xref:System.Windows.Input.StylusPoint.Y%2A> values in the <xref:System.Windows.Input.StylusPoint> data as it comes in from the <xref:System.Windows.Input.Stylus> device.  
  
 [!code-csharp[AdvancedInkTopicsSamples#19](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/DynamicRenderer.cs#19)]
 [!code-vb[AdvancedInkTopicsSamples#19](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/AdvancedInkTopicsSamples/VisualBasic/DynamicRenderer.vb#19)]  
[!code-csharp[AdvancedInkTopicsSamples#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/DynamicRenderer.cs#3)]
[!code-vb[AdvancedInkTopicsSamples#3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/AdvancedInkTopicsSamples/VisualBasic/DynamicRenderer.vb#3)]  
  
<a name="AddingYourPluginToAnInkCanvas"></a>   
## Adding Your Plug-in to an InkCanvas  
 The easiest way to use your custom plug-in is to implement a class that derives from InkCanvas and add it to the <xref:System.Windows.UIElement.StylusPlugIns%2A> property.  
  
 The following example demonstrates a custom <xref:System.Windows.Controls.InkCanvas> that filters the ink.  
  
 [!code-csharp[AdvancedInkTopicsSamples#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/Window1.xaml.cs#4)]  
  
 If you add a `FilterInkCanvas` to your application and run it, you will notice that the ink isn't restricted to a region until after the user completes a stroke. This is because the <xref:System.Windows.Controls.InkCanvas> has a <xref:System.Windows.Controls.InkCanvas.DynamicRenderer%2A> property, which is a <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> and is already a member of the <xref:System.Windows.UIElement.StylusPlugIns%2A> collection. The custom <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> you added to the <xref:System.Windows.UIElement.StylusPlugIns%2A> collection receives the <xref:System.Windows.Input.StylusPoint> data after <xref:System.Windows.Input.StylusPlugIns.DynamicRenderer> receives data. As a result, the <xref:System.Windows.Input.StylusPoint> data will not be filtered until after the user lifts the pen to end a stroke. To filter the ink as the user draws it, you must insert the `FilterPlugin` before the <xref:System.Windows.Input.StylusPlugIns.DynamicRenderer>.  
  
 The following C# code demonstrates a custom <xref:System.Windows.Controls.InkCanvas> that filters the ink as it is drawn.  
  
 [!code-csharp[AdvancedInkTopicsSamples#5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/Window1.xaml.cs#5)]  
  
<a name="Conclusion"></a>   
## Conclusion  
 By deriving your own <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> classes and inserting them into <xref:System.Windows.Input.StylusPlugIns.StylusPlugInCollection> collections, you can greatly enhance the behavior of your digital ink. You have access to the <xref:System.Windows.Input.StylusPoint> data as it is generated, giving you the opportunity to customize the <xref:System.Windows.Input.Stylus> input. Because you have such low-level access to the <xref:System.Windows.Input.StylusPoint> data, you can implement ink collection and rendering with optimal performance for your application.  
  
## See Also  
 [Advanced Ink Handling](../../../../docs/framework/wpf/advanced/advanced-ink-handling.md)  
 [Accessing and Manipulating Pen Input](http://go.microsoft.com/fwlink/?LinkId=50752&clcid=0x409)
