---
title: "Optimizing Performance: Layout and Design"
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
  - "layout [WPF], optimizing performance"
  - "design considerations [WPF]"
  - "layout pass [WPF]"
ms.assetid: 005f4cda-a849-448b-916b-38d14d9a96fe
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Optimizing Performance: Layout and Design
The design of your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application can impact its performance by creating unnecessary overhead in calculating layout and validating object references. The construction of objects, particularly at run time, can affect the performance characteristics of your application.  
  
 This topic provides performance recommendations in these areas.  
  
## Layout  
 The term "layout pass" describes the process of measuring and arranging the members of a <xref:System.Windows.Controls.Panel>-derived object's collection of children, and then drawing them onscreen. The layout pass is a mathematically-intensive process—the larger the number of children in the collection, the greater the number of calculations required. For example, each time a child <xref:System.Windows.UIElement> object in the collection changes its position, it has the potential to trigger a new pass by the layout system. Because of the close relationship between object characteristics and layout behavior, it's important to understand the type of events that can invoke the layout system. Your application will perform better by reducing as much as possible any unnecessary invocations of the layout pass.  
  
 The layout system completes two passes for each child member in a collection: a measure pass, and an arrange pass. Each child object provides its own overridden implementation of the <xref:System.Windows.UIElement.Measure%2A> and <xref:System.Windows.UIElement.Arrange%2A> methods in order to provide its own specific layout behavior. At its simplest, layout is a recursive system that leads to an element being sized, positioned, and drawn onscreen.  
  
-   A child <xref:System.Windows.UIElement> object begins the layout process by first having its core properties measured.  
  
-   The object's <xref:System.Windows.FrameworkElement> properties that are related to size, such as <xref:System.Windows.FrameworkElement.Width%2A>, <xref:System.Windows.FrameworkElement.Height%2A>, and <xref:System.Windows.FrameworkElement.Margin%2A>, are evaluated.  
  
-   <xref:System.Windows.Controls.Panel>-specific logic is applied, such as the <xref:System.Windows.Controls.DockPanel.Dock%2A> property of the <xref:System.Windows.Controls.DockPanel>, or the <xref:System.Windows.Controls.StackPanel.Orientation%2A> property of the <xref:System.Windows.Controls.StackPanel>.  
  
-   Content is arranged, or positioned, after all child objects have been measured.  
  
-   The collection of child objects is drawn to the screen.  
  
 The layout pass process is invoked again if any of the following actions occur:  
  
-   A child object is added to the collection.  
  
-   A <xref:System.Windows.FrameworkElement.LayoutTransform%2A> is applied to the child object.  
  
-   The <xref:System.Windows.UIElement.UpdateLayout%2A> method is called for the child object.  
  
-   When a change occurs to the value of a dependency property that is marked with metadata affecting the measure or arrange passes.  
  
### Use the Most Efficient Panel where Possible  
 The complexity of the layout process is directly based on the layout behavior of the <xref:System.Windows.Controls.Panel>-derived elements you use. For example, a <xref:System.Windows.Controls.Grid> or <xref:System.Windows.Controls.StackPanel> control provides much more functionality than a <xref:System.Windows.Controls.Canvas> control. The price for this greater increase in functionality is a greater increase in performance costs. However, if you do not require the functionality that a <xref:System.Windows.Controls.Grid> control provides, you should use the less costly alternatives, such as a <xref:System.Windows.Controls.Canvas> or a custom panel.  
  
 For more information, see [Panels Overview](../../../../docs/framework/wpf/controls/panels-overview.md).  
  
### Update Rather than Replace a RenderTransform  
 You may be able to update a <xref:System.Windows.Media.Transform> rather than replacing it as the value of a <xref:System.Windows.UIElement.RenderTransform%2A> property. This is particularly true in scenarios that involve animation. By updating an existing <xref:System.Windows.Media.Transform>, you avoid initiating an unnecessary layout calculation.  
  
### Build Your Tree Top-Down  
 When a node is added or removed from the logical tree, property invalidations are raised on the node's parent and all its children. As a result, a top-down construction pattern should always be followed to avoid the cost of unnecessary invalidations on nodes that have already been validated. The following table shows the difference in execution speed between building a tree top-down versus bottom-up, where the tree is 150 levels deep with a single <xref:System.Windows.Controls.TextBlock> and <xref:System.Windows.Controls.DockPanel> at each level.  
  
|**Action**|**Tree building (in ms)**|**Render—includes tree building (in ms)**|  
|----------------|---------------------------------|-------------------------------------------------|  
|Bottom-up|366|454|  
|Top-down|11|96|  
  
 The following code example demonstrates how to create a tree top down.  
  
 [!code-csharp[Performance#PerformanceSnippet1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/Performance/CSharp/Window1.xaml.cs#performancesnippet1)]
 [!code-vb[Performance#PerformanceSnippet1](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/Performance/visualbasic/window1.xaml.vb#performancesnippet1)]  
  
 For more information on the logical tree, see [Trees in WPF](../../../../docs/framework/wpf/advanced/trees-in-wpf.md).  
  
## See Also  
 [Optimizing WPF Application Performance](../../../../docs/framework/wpf/advanced/optimizing-wpf-application-performance.md)  
 [Planning for Application Performance](../../../../docs/framework/wpf/advanced/planning-for-application-performance.md)  
 [Taking Advantage of Hardware](../../../../docs/framework/wpf/advanced/optimizing-performance-taking-advantage-of-hardware.md)  
 [2D Graphics and Imaging](../../../../docs/framework/wpf/advanced/optimizing-performance-2d-graphics-and-imaging.md)  
 [Object Behavior](../../../../docs/framework/wpf/advanced/optimizing-performance-object-behavior.md)  
 [Application Resources](../../../../docs/framework/wpf/advanced/optimizing-performance-application-resources.md)  
 [Text](../../../../docs/framework/wpf/advanced/optimizing-performance-text.md)  
 [Data Binding](../../../../docs/framework/wpf/advanced/optimizing-performance-data-binding.md)  
 [Other Performance Recommendations](../../../../docs/framework/wpf/advanced/optimizing-performance-other-recommendations.md)  
 [Layout](../../../../docs/framework/wpf/advanced/layout.md)
