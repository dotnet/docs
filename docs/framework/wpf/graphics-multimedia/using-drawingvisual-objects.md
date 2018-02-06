---
title: "Using DrawingVisual Objects"
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
  - "visual layer [WPF], DrawingVisual objects"
  - "DrawingVisual objects in visual layer [WPF]"
ms.assetid: 0b4e711d-e640-40cb-81c3-8f5c59909b7d
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Using DrawingVisual Objects
This topic provides an overview of how to use <xref:System.Windows.Media.DrawingVisual> objects in the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] visual layer.  
  
<a name="drawingvisual_object"></a>   
## DrawingVisual Object  
 The <xref:System.Windows.Media.DrawingVisual> is a lightweight drawing class that is used to render shapes, images, or text. This class is considered lightweight because it does not provide layout or event handling, which improves its performance. For this reason, drawings are ideal for backgrounds and clip art.  
  
<a name="drawingvisual_host_container"></a>   
## DrawingVisual Host Container  
 In order to use <xref:System.Windows.Media.DrawingVisual> objects, you need to create a host container for the objects. The host container object must derive from the <xref:System.Windows.FrameworkElement> class, which provides the layout and event handling support that the <xref:System.Windows.Media.DrawingVisual> class lacks. The host container object does not display any visible properties, since its main purpose is to contain child objects. However, the <xref:System.Windows.UIElement.Visibility%2A> property of the host container must be set to <xref:System.Windows.Visibility.Visible>; otherwise, none of its child elements will be visible.  
  
 When you create a host container object for visual objects, you need to store the visual object references in a <xref:System.Windows.Media.VisualCollection>. Use the <xref:System.Windows.Media.VisualCollection.Add%2A> method to add a visual object to the host container. In the following example, a host container object is created, and three visual objects are added to its <xref:System.Windows.Media.VisualCollection>.  
  
 [!code-csharp[DrawingVisualSample#100](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DrawingVisualSample/CSharp/Window1.xaml.cs#100)]
 [!code-vb[DrawingVisualSample#100](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DrawingVisualSample/visualbasic/window1.xaml.vb#100)]  
  
> [!NOTE]
>  For the complete code sample from which the preceding code example was extracted, see [Hit Test Using DrawingVisuals Sample](http://go.microsoft.com/fwlink/?LinkID=159994).  
  
<a name="creating_drawingvisual_objects"></a>   
## Creating DrawingVisual Objects  
 When you create a <xref:System.Windows.Media.DrawingVisual> object, it has no drawing content. You can add text, graphics, or image content by retrieving the object's <xref:System.Windows.Media.DrawingContext> and drawing into it. A <xref:System.Windows.Media.DrawingContext> is returned by calling the <xref:System.Windows.Media.DrawingVisual.RenderOpen%2A> method of a <xref:System.Windows.Media.DrawingVisual> object.  
  
 To draw a rectangle into the <xref:System.Windows.Media.DrawingContext>, use the <xref:System.Windows.Media.DrawingContext.DrawRectangle%2A> method of the <xref:System.Windows.Media.DrawingContext> object. Similar methods exist for drawing other types of content. When you are finished drawing content into the <xref:System.Windows.Media.DrawingContext>, call the <xref:System.Windows.Media.DrawingContext.Close%2A> method to close the <xref:System.Windows.Media.DrawingContext> and persist the content.  
  
 In the following example, a <xref:System.Windows.Media.DrawingVisual> object is created, and a rectangle is drawn into its <xref:System.Windows.Media.DrawingContext>.  
  
 [!code-csharp[DrawingVisualSample#101](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DrawingVisualSample/CSharp/Window1.xaml.cs#101)]
 [!code-vb[DrawingVisualSample#101](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DrawingVisualSample/visualbasic/window1.xaml.vb#101)]  
  
<a name="creating_overrides"></a>   
## Creating Overrides for FrameworkElement Members  
 The host container object is responsible for managing its collection of visual objects. This requires that the host container implement member overrides for the derived <xref:System.Windows.FrameworkElement> class.  
  
 The following list describes the two members you must override:  
  
-   <xref:System.Windows.FrameworkElement.GetVisualChild%2A>: Returns a child at the specified index from the collection of child elements.  
  
-   <xref:System.Windows.FrameworkElement.VisualChildrenCount%2A>: Gets the number of visual child elements within this element.  
  
 In the following example, overrides for the two <xref:System.Windows.FrameworkElement> members are implemented.  
  
 [!code-csharp[DrawingVisualSample#102](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DrawingVisualSample/CSharp/Window1.xaml.cs#102)]
 [!code-vb[DrawingVisualSample#102](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DrawingVisualSample/visualbasic/window1.xaml.vb#102)]  
  
<a name="providing_hit_testing_support"></a>   
## Providing Hit Testing Support  
 The host container object can provide event handling even if it does not display any visible properties—however, its <xref:System.Windows.UIElement.Visibility%2A> property must be set to <xref:System.Windows.Visibility.Visible>. This allows you to create an event handling routine for the host container that can trap mouse events, such as the release of the left mouse button. The event handling routine can then implement hit testing by invoking the <xref:System.Windows.Media.VisualTreeHelper.HitTest%2A> method. The method's <xref:System.Windows.Media.HitTestResultCallback> parameter refers to a user-defined procedure that you can use to determine the resulting action of a hit test.  
  
 In the following example, hit testing support is implemented for the host container object and its children.  
  
 [!code-csharp[DrawingVisualSample#103](../../../../samples/snippets/csharp/VS_Snippets_Wpf/DrawingVisualSample/CSharp/Window1.xaml.cs#103)]
 [!code-vb[DrawingVisualSample#103](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/DrawingVisualSample/visualbasic/window1.xaml.vb#103)]  
  
## See Also  
 <xref:System.Windows.Media.DrawingVisual>  
 <xref:System.Windows.Media.VisualTreeHelper.HitTest%2A>  
 [WPF Graphics Rendering Overview](../../../../docs/framework/wpf/graphics-multimedia/wpf-graphics-rendering-overview.md)  
 [Hit Testing in the Visual Layer](../../../../docs/framework/wpf/graphics-multimedia/hit-testing-in-the-visual-layer.md)
