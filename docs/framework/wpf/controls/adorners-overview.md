---
title: "Adorners Overview"
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
  - "adorners [WPF], about adorners"
ms.assetid: 33d4c5c2-2daf-4e45-ba9a-5b673e2b8280
caps.latest.revision: 35
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Adorners Overview
Adorners are a special type of <xref:System.Windows.FrameworkElement>, used to provide visual cues to a user. Among other uses, Adorners can be used to add functional handles to elements or provide state information about a control.  
  
  
  
<a name="about_Adorners"></a>   
## About Adorners  
 An <xref:System.Windows.Documents.Adorner> is a custom <xref:System.Windows.FrameworkElement> that is bound to a <xref:System.Windows.UIElement>. Adorners are rendered in an <xref:System.Windows.Documents.AdornerLayer>, which is a rendering surface that is always on top of the adorned element or a collection of adorned elements. Rendering of an adorner is independent from rendering of the <xref:System.Windows.UIElement> that the adorner is bound to. An adorner is typically positioned relative to the element to which it is bound, using the standard 2-D coordinate origin located at the upper-left of the adorned element.  
  
 Common applications for adorners include:  
  
-   Adding functional handles to a <xref:System.Windows.UIElement> that enable a user to manipulate the element in some way (resize, rotate, reposition, etc.).  
  
-   Provide visual feedback to indicate various states, or in response to various events.  
  
-   Overlay visual decorations on a <xref:System.Windows.UIElement>.  
  
-   Visually mask or override part or all of a <xref:System.Windows.UIElement>.  
  
 [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides a basic framework for adorning visual elements. The following table lists the primary types used when adorning objects, and their purpose. Several usage examples follow.  
  
|||  
|-|-|  
|<xref:System.Windows.Documents.Adorner>|An abstract base class from which all concrete adorner implementations inherit.|  
|<xref:System.Windows.Documents.AdornerLayer>|A class representing a rendering layer for the adorner(s) of one or more adorned elements.|  
|<xref:System.Windows.Documents.AdornerDecorator>|A class that enables an adorner layer to be associated with a collection of elements.|  
  
<a name="implement_custom_Adorner"></a>   
## Implementing a Custom Adorner  
 The adorners framework provided by [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] is intended primarily to support the creation of custom adorners. A custom adorner is created by implementing a class that inherits from the abstract <xref:System.Windows.Documents.Adorner> class.  
  
> [!NOTE]
>  The parent of an <xref:System.Windows.Documents.Adorner> is the <xref:System.Windows.Documents.AdornerLayer> that renders the <xref:System.Windows.Documents.Adorner>, not the element being adorned.  
  
 The following example shows a class that implements a simple adorner. The example adorner simply adorns the corners of a <xref:System.Windows.UIElement> with circles.  
  
 [!code-csharp[Adorners_SimpleCircleAdorner#_SimpleCircleAdornerBody](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/CSharp/Window1.xaml.cs#_simplecircleadornerbody)]
 [!code-vb[Adorners_SimpleCircleAdorner#_SimpleCircleAdornerBody](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/VisualBasic/Window1.xaml.vb#_simplecircleadornerbody)]  
  
 The following image shows the SimpleCircleAdorner applied to a <xref:System.Windows.Controls.TextBox>.  
  
 ![Adorners Example: An adorned TextBox](../../../../docs/framework/wpf/controls/media/adornedtextbox.png "AdornedTextBox")  
  
<a name="rendering_behavior_for_Adorners"></a>   
## Rendering Behavior for Adorners  
 It is important to note that adorners do not include any inherent rendering behavior; ensuring that an adorner renders is the responsibility of the adorner implementer.   A common way of implementing rendering behavior is to override the <xref:System.Windows.UIElement.OnRender%2A> method and use one or more <xref:System.Windows.Media.DrawingContext> objects to render the adorner's visuals as needed (as shown in the example above).  
  
> [!NOTE]
>  Anything placed in the adorner layer is rendered on top of the rest of any styles you have set. In other words, adorners are always visually on top and cannot be overridden using z-order.  
  
<a name="adorner_events_hittest"></a>   
## Events and Hit Testing  
 Adorners receive input events just like any other <xref:System.Windows.FrameworkElement>.  Because an adorner always has a higher z-order than the element it adorns, the adorner receives input events (such as <xref:System.Windows.UIElement.Drop> or <xref:System.Windows.UIElement.MouseMove>) that may be intended for the underlying adorned element.  An adorner can listen for certain input events and pass these on to the underlying adorned element by re-raising the event.  
  
 To enable pass-through hit testing of elements under an adorner, set the hit test <xref:System.Windows.UIElement.IsHitTestVisible%2A> property to **false** on the adorner.  For more information about hit testing, see  
  
 [Hit Testing in the Visual Layer](../../../../docs/framework/wpf/graphics-multimedia/hit-testing-in-the-visual-layer.md).  
  
<a name="adorn_single_element"></a>   
## Adorning a Single UIElement  
 To bind an adorner to a particular <xref:System.Windows.UIElement>, follow these steps:  
  
1.  Call the static method <xref:System.Windows.Documents.AdornerLayer.GetAdornerLayer%2A> to get an <xref:System.Windows.Documents.AdornerLayer> object for the <xref:System.Windows.UIElement> to be adorned. <xref:System.Windows.Documents.AdornerLayer.GetAdornerLayer%2A> walks up the visual tree, starting at the specified <xref:System.Windows.UIElement>, and returns the first adorner layer it finds. (If no adorner layers are found, the method returns null.)  
  
2.  Call the <xref:System.Windows.Documents.AdornerLayer.Add%2A> method to bind the adorner to the target <xref:System.Windows.UIElement>.  
  
 The following example binds a SimpleCircleAdorner (shown above) to a <xref:System.Windows.Controls.TextBox> named *myTextBox*.  
  
 [!code-csharp[Adorners_SimpleCircleAdorner#_AdornSingleElement](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/CSharp/Window1.xaml.cs#_adornsingleelement)]
 [!code-vb[Adorners_SimpleCircleAdorner#_AdornSingleElement](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/VisualBasic/Window1.xaml.vb#_adornsingleelement)]  
  
> [!NOTE]
>  Using [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] to bind an adorner to another element is currently not supported.  
  
<a name="adorn_children_panel"></a>   
## Adorning the Children of a Panel  
 To bind an adorner to the children of a <xref:System.Windows.Controls.Panel>, follow these steps:  
  
1.  Call the `static` method <xref:System.Windows.Documents.AdornerLayer.GetAdornerLayer%2A> to find an adorner layer for the element whose children are to be adorned.  
  
2.  Enumerate through the children of the parent element and call the <xref:System.Windows.Documents.AdornerLayer.Add%2A> method to bind an adorner to each child element.  
  
 The following example binds a SimpleCircleAdorner (shown above) to the children of a <xref:System.Windows.Controls.StackPanel> named *myStackPanel*.  
  
 [!code-csharp[Adorners_SimpleCircleAdorner#_AdornChildren](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/CSharp/Window1.xaml.cs#_adornchildren)]
 [!code-vb[Adorners_SimpleCircleAdorner#_AdornChildren](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Adorners_SimpleCircleAdorner/VisualBasic/Window1.xaml.vb#_adornchildren)]  
  
## See Also  
 <xref:System.Windows.Media.AdornerHitTestResult>  
 [Shapes and Basic Drawing in WPF Overview](../../../../docs/framework/wpf/graphics-multimedia/shapes-and-basic-drawing-in-wpf-overview.md)  
 [Painting with Images, Drawings, and Visuals](../../../../docs/framework/wpf/graphics-multimedia/painting-with-images-drawings-and-visuals.md)  
 [Drawing Objects Overview](../../../../docs/framework/wpf/graphics-multimedia/drawing-objects-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/controls/adorners-how-to-topics.md)
