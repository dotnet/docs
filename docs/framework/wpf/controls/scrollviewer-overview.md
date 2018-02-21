---
title: "ScrollViewer Overview"
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
  - "controls [WPF], ScrollViewer"
  - "ScrollViewer control [WPF], about ScrollViewer control"
ms.assetid: 94a13b94-cfdf-4b12-a1aa-90cb50c6e9b9
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ScrollViewer Overview
Content within a user interface is often larger than a computer screen's display area. The <xref:System.Windows.Controls.ScrollViewer> control provides a convenient way to enable scrolling of content in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] applications. This topic introduces the <xref:System.Windows.Controls.ScrollViewer> element and provides several usage examples.  
  
<a name="what_is_a_scrollviewer_element"></a>   
## The ScrollViewer Control  
 There are two predefined elements that enable scrolling in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications: <xref:System.Windows.Controls.Primitives.ScrollBar> and <xref:System.Windows.Controls.ScrollViewer>. The <xref:System.Windows.Controls.ScrollViewer> control encapsulates horizontal and vertical <xref:System.Windows.Controls.Primitives.ScrollBar> elements and a content container (such as a <xref:System.Windows.Controls.Panel> element) in order to display other visible elements in a scrollable area. You must build a custom object in order to use the <xref:System.Windows.Controls.Primitives.ScrollBar> element for content scrolling. However, you can use the <xref:System.Windows.Controls.ScrollViewer> element by itself because it is a composite control that encapsulates <xref:System.Windows.Controls.Primitives.ScrollBar> functionality.  
  
 The <xref:System.Windows.Controls.ScrollViewer> control responds to both mouse and keyboard commands, and defines numerous methods with which to scroll content by predetermined increments. You can use the <xref:System.Windows.Controls.ScrollViewer.ScrollChanged> event to detect a change in a <xref:System.Windows.Controls.ScrollViewer> state.  
  
 A <xref:System.Windows.Controls.ScrollViewer> can only have one child, typically a <xref:System.Windows.Controls.Panel> element that can host a <xref:System.Windows.Controls.Panel.Children%2A> collection of elements. The <xref:System.Windows.Controls.ContentPresenter.Content%2A> property defines the sole child of the <xref:System.Windows.Controls.ScrollViewer>.  
  
<a name="scrollviewer_physical_vs_logical"></a>   
## Physical vs. Logical Scrolling  
 Physical scrolling is used to scroll content by a predetermined physical increment, typically by a value that is declared in pixels. Logical scrolling is used to scroll to the next item in the logical tree. Physical scrolling is the default scroll behavior for most <xref:System.Windows.Controls.Panel> elements. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] supports both types of scrolling.  
  
#### The IScrollInfo Interface  
 The <xref:System.Windows.Controls.Primitives.IScrollInfo> interface represents the main scrolling region within a <xref:System.Windows.Controls.ScrollViewer> or derived control. The interface defines scrolling properties and methods that can be implemented by <xref:System.Windows.Controls.Panel> elements that require scrolling by logical unit, rather than by a physical increment. Casting an instance of <xref:System.Windows.Controls.Primitives.IScrollInfo> to a derived <xref:System.Windows.Controls.Panel> and then using its scrolling methods provides a useful way to scroll to the next logical unit in a child collection, rather than by pixel increment. By default, the <xref:System.Windows.Controls.ScrollViewer> control supports scrolling by physical units.  
  
 <xref:System.Windows.Controls.StackPanel> and <xref:System.Windows.Controls.VirtualizingStackPanel> both implement <xref:System.Windows.Controls.Primitives.IScrollInfo> and natively support logical scrolling. For layout controls that natively support logical scrolling, you can still achieve physical scrolling by wrapping the host <xref:System.Windows.Controls.Panel> element in a <xref:System.Windows.Controls.ScrollViewer> and setting the <xref:System.Windows.Controls.ScrollViewer.CanContentScroll%2A> property to `false`.  
  
 The following code example demonstrates how to cast an instance of <xref:System.Windows.Controls.Primitives.IScrollInfo> to a <xref:System.Windows.Controls.StackPanel> and use content scrolling methods (<xref:System.Windows.Controls.Primitives.IScrollInfo.LineUp%2A> and <xref:System.Windows.Controls.Primitives.IScrollInfo.LineDown%2A>) defined by the interface.  
  
 [!code-csharp[IScrollInfoMethods#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/IScrollInfoMethods/CSharp/Window1.xaml.cs#3)]
 [!code-vb[IScrollInfoMethods#3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/IScrollInfoMethods/VisualBasic/Window1.xaml.vb#3)]  
  
<a name="scrollviewer_markup_syntax_and_sample"></a>   
## Defining and Using a ScrollViewer Element  
 The following example creates a <xref:System.Windows.Controls.ScrollViewer> in a window that contains some text and a rectangle. <xref:System.Windows.Controls.Primitives.ScrollBar> elements appear only when they are necessary. When you resize the window, the <xref:System.Windows.Controls.Primitives.ScrollBar> elements appear and disappear, due to updated values of the <xref:System.Windows.Controls.ScrollViewer.ComputedHorizontalScrollBarVisibility%2A> and <xref:System.Windows.Controls.ScrollViewer.ComputedVerticalScrollBarVisibility%2A> properties.  
  
 [!code-cpp[ScrollViewer#1](../../../../samples/snippets/cpp/VS_Snippets_Wpf/ScrollViewer/CPP/ScrollViewer_wcp.cpp#1)]
 [!code-csharp[ScrollViewer#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ScrollViewer/CSharp/ScrollViewer_wcp.cs#1)]
 [!code-vb[ScrollViewer#1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ScrollViewer/VisualBasic/ScrollViewer.vb#1)]
 [!code-xaml[ScrollViewer#1](../../../../samples/snippets/xaml/VS_Snippets_Wpf/ScrollViewer/XAML/Pane1.xaml#1)]  
  
<a name="scrollviewer_styling_scrollviewer"></a>   
## Styling a ScrollViewer  
 Like all controls in Windows Presentation Foundation, the <xref:System.Windows.Controls.ScrollViewer> can be styled in order to change the default rendering behavior of the control. For additional information on control styling, see [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md).  
  
<a name="scrollviewer_scroll_vs_paginate"></a>   
## Paginating Documents  
 For document content, an alternative to scrolling is to choose a document container that supports pagination. <xref:System.Windows.Documents.FlowDocument> is for documents that are designed to be hosted within a viewing control, such as <xref:System.Windows.Controls.FlowDocumentPageViewer>, that supports paginating content across multiple pages, preventing the need for scrolling. <xref:System.Windows.Controls.DocumentViewer> provides a solution for viewing <xref:System.Windows.Documents.FixedDocument> content, which uses traditional scrolling to display content outside the realm of the display area.  
  
 For additional information about document formats and presentation options, see [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md).  
  
## See Also  
 <xref:System.Windows.Controls.ScrollViewer>  
 <xref:System.Windows.Controls.Primitives.ScrollBar>  
 <xref:System.Windows.Controls.Primitives.IScrollInfo>  
 [Create a Scroll Viewer](http://msdn.microsoft.com/library/c8e46af7-b417-441b-aa30-791cbdbd43ef)  
 [Documents in WPF](../../../../docs/framework/wpf/advanced/documents-in-wpf.md)  
 [ScrollBar Styles and Templates](../../../../docs/framework/wpf/controls/scrollbar-styles-and-templates.md)  
 [Controls](../../../../docs/framework/wpf/advanced/optimizing-performance-controls.md)
