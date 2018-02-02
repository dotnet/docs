---
title: "Initialization for Object Elements Not in an Object Tree"
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
  - "logical tree [WPF]"
  - "visual tree [WPF]"
  - "elements [WPF], initializing"
  - "initializing elements [WPF]"
ms.assetid: 7b8dfc9b-46ac-4ce8-b7bb-035734d688b7
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Initialization for Object Elements Not in an Object Tree
Some aspects of [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] initialization are deferred to processes that typically rely on that element being connected to either the logical tree or visual tree. This topic describes the steps that may be necessary in order to initialize an element that is not connected to either tree.  
  
 
  
## Elements and the Logical Tree  
 When you create an instance of a [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] class in code, you should be aware that several aspects of object initialization for a [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] class are deliberately not a part of the code that is executed when calling the class constructor. Particularly for a control class, most of the visual representation of that control is not defined by the constructor. Instead, the visual representation is defined by the control's template. The template potentially comes from a variety of sources, but most often the template is obtained from theme styles. Templates are effectively late-binding; the necessary template is not attached to the control in question until the control is ready for layout. And the control is not ready for layout until it is attached to a logical tree that connects to a rendering surface at the root. It is that root-level element that initiates the rendering of all of its child elements as defined in the logical tree.  
  
 The visual tree also participates in this process. Elements that are part of the visual tree through the templates are also not fully instantiated until connected.  
  
 The consequences of this behavior are that certain operations that rely on the completed visual characteristics of an element require additional steps. An example is if you are attempting to get the visual characteristics of a class that was constructed but not yet attached to a tree. For instance, if you want to call <xref:System.Windows.Media.Imaging.RenderTargetBitmap.Render%2A> on a <xref:System.Windows.Media.Imaging.RenderTargetBitmap> and the visual you are passing is an element not connected to a tree, that element is not visually complete until additional initialization steps are completed.  
  
### Using BeginInit and EndInit to Initialize the Element  
 Various classes in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] implement the <xref:System.ComponentModel.ISupportInitialize> interface. You use the <xref:System.ComponentModel.ISupportInitialize.BeginInit%2A> and <xref:System.ComponentModel.ISupportInitialize.EndInit%2A> methods of the interface to denote a region in your code that contains initialization steps (such as setting property values that affect rendering). After <xref:System.ComponentModel.ISupportInitialize.EndInit%2A> is called in the sequence, the layout system can process the element and start looking for an implicit style.  
  
 If the element you are setting properties on is a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> derived class, then you can call the class versions of <xref:System.Windows.FrameworkElement.BeginInit%2A> and <xref:System.Windows.FrameworkElement.EndInit%2A> rather than casting to <xref:System.ComponentModel.ISupportInitialize>.  
  
### Sample Code  
 The following example is sample code for a console application that uses rendering [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] and <xref:System.Windows.Markup.XamlReader.Load%28System.IO.Stream%29?displayProperty=nameWithType> of a loose [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] file to illustrate the proper placement of <xref:System.Windows.FrameworkElement.BeginInit%2A> and <xref:System.Windows.FrameworkElement.EndInit%2A> around other [!INCLUDE[TLA2#tla_api](../../../../includes/tla2sharptla-api-md.md)] calls that adjust properties that affect rendering.  
  
 The example illustrates the main function only. The functions `Rasterize` and `Save` (not shown) are utility functions that take care of image processing and IO.  
  
 [!code-csharp[InitializeElements#Main](../../../../samples/snippets/csharp/VS_Snippets_Wpf/InitializeElements/CSharp/initializeelements.cs#main)]
 [!code-vb[InitializeElements#Main](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/InitializeElements/VisualBasic/initializeelements.vb#main)]  
  
## See Also  
 [Trees in WPF](../../../../docs/framework/wpf/advanced/trees-in-wpf.md)  
 [WPF Graphics Rendering Overview](../../../../docs/framework/wpf/graphics-multimedia/wpf-graphics-rendering-overview.md)  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)
