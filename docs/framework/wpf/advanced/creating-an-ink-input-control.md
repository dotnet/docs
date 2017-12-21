---
title: "Creating an Ink Input Control"
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
  - "ink strokes [WPF], managing"
  - "managing ink strokes [WPF]"
  - "ink input control [WPF]"
  - "input from mouse [WPF], accepting"
  - "mouse input [WPF], accepting"
  - "ink [WPF], rendering"
  - "ink strokes [WPF], collecting"
  - "rendering ink [WPF]"
  - "collecting ink strokes [WPF]"
  - "DynamicRenderer objects [WPF]"
  - "StylusPlugIn objects [WPF]"
ms.assetid: c31f3a67-cb3f-4ded-af9e-ed21f6575b26
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Creating an Ink Input Control
You can create a custom control that dynamically and statically renders ink. That is, render ink as a user draws a stroke, causing the ink to appear to "flow" from the tablet pen, and display ink after it is added to the control, either via the tablet pen, pasted from the Clipboard, or loaded from a file. To dynamically render ink, your control must use a <xref:System.Windows.Input.StylusPlugIns.DynamicRenderer>. To statically render ink, you must override the stylus event methods (<xref:System.Windows.UIElement.OnStylusDown%2A>, <xref:System.Windows.UIElement.OnStylusMove%2A>, and <xref:System.Windows.UIElement.OnStylusUp%2A>) to collect <xref:System.Windows.Input.StylusPoint> data, create strokes, and add them to an <xref:System.Windows.Controls.InkPresenter> (which renders the ink on the control).  
  
 This topic contains the following subsections:  
  
-   [How to: Collect Stylus Point Data and Create Ink Strokes](#CollectingStylusPointDataAndCreatingInkStrokes)  
  
-   [How to: Enable Your Control to Accept Input from the Mouse](#EnablingYourControlToAcceptInputTromTheMouse)  
  
-   [Putting it together](#PuttingItTogether)  
  
-   [Using Additional Plug-ins and DynamicRenderers](#UsingAdditionalPluginsAndDynamicRenderers)  
  
-   [Conclusion](#AdvancedInkHandling_Conclusion)  
  
<a name="CollectingStylusPointDataAndCreatingInkStrokes"></a>   
## How to: Collect Stylus Point Data and Create Ink Strokes  
 To create a control that collects and manages ink strokes do the following:  
  
1.  Derive a class from <xref:System.Windows.Controls.Control> or one of the classes derived from <xref:System.Windows.Controls.Control>, such as <xref:System.Windows.Controls.Label>.  
  
     [!code-csharp[AdvancedInkTopicsSamples#20](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControl.cs#20)]  
    [!code-csharp[AdvancedInkTopicsSamples#14](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControlSnippets.cs#14)]  
    [!code-csharp[AdvancedInkTopicsSamples#15](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControlSnippets.cs#15)]  
  
2.  Add an <xref:System.Windows.Controls.InkPresenter> to the class and set the <xref:System.Windows.Controls.ContentControl.Content%2A> property to the new <xref:System.Windows.Controls.InkPresenter>.  
  
     [!code-csharp[AdvancedInkTopicsSamples#16](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControlSnippets.cs#16)]  
  
3.  Attach the <xref:System.Windows.Input.StylusPlugIns.DynamicRenderer.RootVisual%2A> of the <xref:System.Windows.Input.StylusPlugIns.DynamicRenderer> to the <xref:System.Windows.Controls.InkPresenter> by calling the <xref:System.Windows.Controls.InkPresenter.AttachVisuals%2A> method, and add the <xref:System.Windows.Input.StylusPlugIns.DynamicRenderer> to the <xref:System.Windows.UIElement.StylusPlugIns%2A> collection. This allows the <xref:System.Windows.Controls.InkPresenter> to display the ink as the stylus point data is collected by your control.  
  
     [!code-csharp[AdvancedInkTopicsSamples#17](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControlSnippets.cs#17)]  
    [!code-csharp[AdvancedInkTopicsSamples#18](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControlSnippets.cs#18)]  
  
4.  Override the <xref:System.Windows.UIElement.OnStylusDown%2A> method.  In this method, capture the stylus with a call to <xref:System.Windows.Input.Stylus.Capture%2A>. By capturing the stylus, your control will to continue to receive <xref:System.Windows.UIElement.StylusMove> and <xref:System.Windows.UIElement.StylusUp> events even if the stylus leaves the control's boundaries. This is not strictly mandatory, but almost always desired for a good user experience. Create a new <xref:System.Windows.Input.StylusPointCollection> to gather <xref:System.Windows.Input.StylusPoint> data. Finally, add the initial set of <xref:System.Windows.Input.StylusPoint> data to the <xref:System.Windows.Input.StylusPointCollection>.  
  
     [!code-csharp[AdvancedInkTopicsSamples#7](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControl.cs#7)]  
  
5.  Override the <xref:System.Windows.UIElement.OnStylusMove%2A> method and add the <xref:System.Windows.Input.StylusPoint> data to the <xref:System.Windows.Input.StylusPointCollection> object that you created earlier.  
  
     [!code-csharp[AdvancedInkTopicsSamples#8](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControl.cs#8)]  
  
6.  Override the <xref:System.Windows.UIElement.OnStylusUp%2A> method and create a new <xref:System.Windows.Ink.Stroke> with the <xref:System.Windows.Input.StylusPointCollection> data. Add the new <xref:System.Windows.Ink.Stroke> you created to the <xref:System.Windows.Controls.InkPresenter.Strokes%2A> collection of the <xref:System.Windows.Controls.InkPresenter> and release stylus capture.  
  
     [!code-csharp[AdvancedInkTopicsSamples#10](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControl.cs#10)]  
  
<a name="EnablingYourControlToAcceptInputTromTheMouse"></a>   
## How to: Enable Your Control to Accept Input from the Mouse  
 If you add the preceding control to your application, run it, and use the mouse as an input device, you will notice that the strokes are not persisted. To persist the strokes when the mouse is used as the input device do the following:  
  
1.  Override the <xref:System.Windows.UIElement.OnMouseLeftButtonDown%2A> and create a new <xref:System.Windows.Input.StylusPointCollection> Get the position of the mouse when the event occurred and create a <xref:System.Windows.Input.StylusPoint> using the point data and add the <xref:System.Windows.Input.StylusPoint> to the <xref:System.Windows.Input.StylusPointCollection>.  
  
     [!code-csharp[AdvancedInkTopicsSamples#11](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControl.cs#11)]  
  
2.  Override the <xref:System.Windows.UIElement.OnMouseMove%2A> method. Get the position of the mouse when the event occurred and create a <xref:System.Windows.Input.StylusPoint> using the point data.  Add the <xref:System.Windows.Input.StylusPoint> to the <xref:System.Windows.Input.StylusPointCollection> object that you created earlier.  
  
     [!code-csharp[AdvancedInkTopicsSamples#12](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControl.cs#12)]  
  
3.  Override the <xref:System.Windows.UIElement.OnMouseLeftButtonUp%2A> method.  Create a new <xref:System.Windows.Ink.Stroke> with the <xref:System.Windows.Input.StylusPointCollection> data, and add the new <xref:System.Windows.Ink.Stroke> you created to the <xref:System.Windows.Controls.InkPresenter.Strokes%2A> collection of the <xref:System.Windows.Controls.InkPresenter>.  
  
     [!code-csharp[AdvancedInkTopicsSamples#13](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControl.cs#13)]  
  
<a name="PuttingItTogether"></a>   
## Putting it together  
 The following example is a custom control that collects ink when the user uses either the mouse or the pen.  
  
 [!code-csharp[AdvancedInkTopicsSamples#20](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControl.cs#20)]  
[!code-csharp[AdvancedInkTopicsSamples#6](../../../../samples/snippets/csharp/VS_Snippets_Wpf/AdvancedInkTopicsSamples/CSharp/StylusControl.cs#6)]  
  
<a name="UsingAdditionalPluginsAndDynamicRenderers"></a>   
## Using Additional Plug-ins and DynamicRenderers  
 Like the InkCanvas, your custom control can have custom <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> and additional <xref:System.Windows.Input.StylusPlugIns.DynamicRenderer> objects. Add these to the <xref:System.Windows.UIElement.StylusPlugIns%2A> collection. The order of the <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> objects in the <xref:System.Windows.Input.StylusPlugIns.StylusPlugInCollection> affects the appearance of the ink when it is rendered. Suppose you have a <xref:System.Windows.Input.StylusPlugIns.DynamicRenderer> called `dynamicRenderer` and a custom <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> called `translatePlugin` that offsets the ink from the tablet pen. If `translatePlugin` is the first <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> in the <xref:System.Windows.Input.StylusPlugIns.StylusPlugInCollection>, and `dynamicRenderer` is the second, the ink that "flows" will be offset as the user moves the pen. If `dynamicRenderer` is first, and `translatePlugin` is second, the ink will not be offset until the user lifts the pen.  
  
<a name="AdvancedInkHandling_Conclusion"></a>   
## Conclusion  
 You can create a control that collects and renders ink by overriding the stylus event methods. By creating your own control, deriving your own <xref:System.Windows.Input.StylusPlugIns.StylusPlugIn> classes, and inserting them the into <xref:System.Windows.Input.StylusPlugIns.StylusPlugInCollection>, you can implement virtually any behavior imaginable with digital ink. You have access to the <xref:System.Windows.Input.StylusPoint> data as it is generated, giving you the opportunity to  customize <xref:System.Windows.Input.Stylus> input and render it on the screen as appropriate for your application. Because you have such low-level access to the <xref:System.Windows.Input.StylusPoint> data, you can implement ink collection and render it with optimal performance for your application.  
  
## See Also  
 [Advanced Ink Handling](../../../../docs/framework/wpf/advanced/advanced-ink-handling.md)  
 [Accessing and Manipulating Pen Input](http://go.microsoft.com/fwlink/?LinkId=50752&clcid=0x409)
