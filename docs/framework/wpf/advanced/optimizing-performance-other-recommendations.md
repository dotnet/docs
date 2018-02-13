---
title: "Optimizing Performance: Other Recommendations"
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
  - "Terminal Services rendering [WPF]"
  - "opacity [WPF]"
  - "hit-test objects [WPF]"
  - "ScrollBarVisibility enumeration [WPF]"
  - "brushes [WPF], performance"
ms.assetid: d028cc65-7e97-4a4f-9859-929734eaf40d
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Optimizing Performance: Other Recommendations
<a name="introduction"></a> This topic provides performance recommendations in addition to the ones covered by the topics in the [Optimizing WPF Application Performance](../../../../docs/framework/wpf/advanced/optimizing-wpf-application-performance.md) section.  
  
 This topic contains the following sections:  
  
-   [Opacity on Brushes Versus Opacity on Elements](#Opacity)  
  
-   [Navigation to Object](#Navigation_Objects)  
  
-   [Hit Testing on Large 3D Surfaces](#Hit_Testing)  
  
-   [CompositionTarget.Rendering Event](#CompositionTarget_Rendering_Event)  
  
-   [Avoid Using ScrollBarVisibility=Auto](#Avoid_Using_ScrollBarVisibility)  
  
-   [Configure Font Cache Service to Reduce Start-up Time](#FontCache)  
  
<a name="Opacity"></a>   
## Opacity on Brushes Versus Opacity on Elements  
 When you use a <xref:System.Windows.Media.Brush> to set the <xref:System.Windows.Shapes.Shape.Fill%2A> or <xref:System.Windows.Shapes.Shape.Stroke%2A> of an element, it is better to set the <xref:System.Windows.Media.Brush.Opacity%2A?displayProperty=nameWithType> value rather than the setting the element's <xref:System.Windows.UIElement.Opacity%2A> property. Modifying an element's <xref:System.Windows.UIElement.Opacity%2A> property can cause [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] to create a temporary surface.  
  
<a name="Navigation_Objects"></a>   
## Navigation to Object  
 The <xref:System.Windows.Navigation.NavigationWindow> object derives from <xref:System.Windows.Window> and extends it with content navigation support, primarily by aggregating <xref:System.Windows.Navigation.NavigationService> and the journal. You can update the client area of <xref:System.Windows.Navigation.NavigationWindow> by specifying either a [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)] or an object. The following sample shows both methods:  
  
 [!code-csharp[Performance#PerformanceSnippet14](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/TestNavigation.xaml.cs#performancesnippet14)]
 [!code-vb[Performance#PerformanceSnippet14](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Performance/visualbasic/testnavigation.xaml.vb#performancesnippet14)]  
  
 Each <xref:System.Windows.Navigation.NavigationWindow> object has a journal that records the user's navigation history in that window. One of the purposes of the journal is to allow users to retrace their steps.  
  
 When you navigate using a [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)], the journal stores only the [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)] reference. This means that each time you revisit the page, it is dynamically reconstructed, which may be time consuming depending on the complexity of the page. In this case, the journal storage cost is low, but the time to reconstitute the page is potentially high.  
  
 When you navigate using an object, the journal stores the entire visual tree of the object. This means that each time you revisit the page, it renders immediately without having to be reconstructed. In this case, the journal storage cost is high, but the time to reconstitute the page is low.  
  
 When you use the <xref:System.Windows.Navigation.NavigationWindow> object, you will need to keep in mind how the journaling support impacts your application's performance. For more information, see [Navigation Overview](../../../../docs/framework/wpf/app-development/navigation-overview.md).  
  
<a name="Hit_Testing"></a>   
## Hit Testing on Large 3D Surfaces  
 Hit testing on large 3D surfaces is a very performance intensive operation in terms of CPU consumption. This is especially true when the 3D surface is animating. If you do not require hit testing on these surfaces, then disable hit testing. Objects that are derived from <xref:System.Windows.UIElement> can disable hit testing by setting the <xref:System.Windows.UIElement.IsHitTestVisible%2A> property to `false`.  
  
<a name="CompositionTarget_Rendering_Event"></a>   
## CompositionTarget.Rendering Event  
 The <xref:System.Windows.Media.CompositionTarget.Rendering?displayProperty=nameWithType> event causes [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] to continuously animate. If you use this event, detach it at every opportunity.  
  
<a name="Avoid_Using_ScrollBarVisibility"></a>   
## Avoid Using ScrollBarVisibility=Auto  
 Whenever possible, avoid using the <xref:System.Windows.Controls.ScrollBarVisibility.Auto?displayProperty=nameWithType> value for the `HorizontalScrollBarVisibility` and `VerticalScrollBarVisibility` properties. These properties are defined for <xref:System.Windows.Controls.RichTextBox>, <xref:System.Windows.Controls.ScrollViewer>, and <xref:System.Windows.Controls.TextBox> objects, and as an attached property for the <xref:System.Windows.Controls.ListBox> object. Instead, set <xref:System.Windows.Controls.ScrollBarVisibility> to <xref:System.Windows.Controls.ScrollBarVisibility.Disabled>, <xref:System.Windows.Controls.ScrollBarVisibility.Hidden>, or <xref:System.Windows.Controls.ScrollBarVisibility.Visible>.  
  
 The <xref:System.Windows.Controls.ScrollBarVisibility.Auto> value is intended for cases when space is limited and scrollbars should only be displayed when necessary. For example, it may be useful to use this <xref:System.Windows.Controls.ScrollBarVisibility> value with a <xref:System.Windows.Controls.ListBox> of 30 items as opposed to a <xref:System.Windows.Controls.TextBox> with hundreds of lines of text.  
  
<a name="FontCache"></a>   
## Configure Font Cache Service to Reduce Start-up Time  
 The [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] Font Cache service shares font data between [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications. The first [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] application you run starts this service if the service is not already running. If you are using [!INCLUDE[TLA#tla_winvista](../../../../includes/tlasharptla-winvista-md.md)], you can set the "[!INCLUDE[TLA#tla_wpf](../../../../includes/tlasharptla-wpf-md.md)] Font Cache 3.0.0.0" service from "Manual" (the default) to "Automatic (Delayed Start)" to reduce the initial start-up time of [!INCLUDE[TLA2#tla_wpf](../../../../includes/tla2sharptla-wpf-md.md)] applications.  
  
## See Also  
 [Planning for Application Performance](../../../../docs/framework/wpf/advanced/planning-for-application-performance.md)  
 [Taking Advantage of Hardware](../../../../docs/framework/wpf/advanced/optimizing-performance-taking-advantage-of-hardware.md)  
 [Layout and Design](../../../../docs/framework/wpf/advanced/optimizing-performance-layout-and-design.md)  
 [2D Graphics and Imaging](../../../../docs/framework/wpf/advanced/optimizing-performance-2d-graphics-and-imaging.md)  
 [Object Behavior](../../../../docs/framework/wpf/advanced/optimizing-performance-object-behavior.md)  
 [Application Resources](../../../../docs/framework/wpf/advanced/optimizing-performance-application-resources.md)  
 [Text](../../../../docs/framework/wpf/advanced/optimizing-performance-text.md)  
 [Data Binding](../../../../docs/framework/wpf/advanced/optimizing-performance-data-binding.md)  
 [Animation Tips and Tricks](../../../../docs/framework/wpf/graphics-multimedia/animation-tips-and-tricks.md)
