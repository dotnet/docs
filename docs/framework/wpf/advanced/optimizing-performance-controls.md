---
title: "Optimizing Performance: Controls"
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
  - "controls [WPF], improving performance"
  - "container recycling [WPF]"
  - "user interface virtualization [WPF]"
ms.assetid: 45a31c43-ea8a-4546-96c8-0631b9934179
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Optimizing Performance: Controls
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] includes many of the common user-interface (UI) components that are used in most Windows applications. This topic contains techniques for improving the performance of your UI.  
  
 
  
<a name="Displaying"></a>   
## Displaying Large Data Sets  
 WPF controls such as the <xref:System.Windows.Controls.ListView> and <xref:System.Windows.Controls.ComboBox> are used to display lists of items in an application. If the list to display is large, the application's performance can be affected. This is because the standard layout system creates a layout container for each item associated with the list control, and computes its layout size and position. Typically, you do not have to display all the items at the same time; instead you display a subset, and the user scrolls through the list. In this case, it makes sense to use UI *virtualization*, which means the item container generation and associated layout computation for an item is deferred until the item is visible.  
  
 UI Virtualization is an important aspect of list controls. UI virtualization should not be confused with data virtualization. UI virtualization stores only visible items in memory but in a data-binding scenario stores the entire data structure in memory. In contrast, data virtualization stores only the data items that are visible on the screen in memory.  
  
 By default, UI virtualization is enabled for the <xref:System.Windows.Controls.ListView> and <xref:System.Windows.Controls.ListBox> controls when their list items are bound to data. <xref:System.Windows.Controls.TreeView> virtualization can be enabled by setting the <!--zz <xref:System.Windows.Controls.VirtualizingStackPanel.IsVirtualizing%2A?displayProperty=nameWithType> --> `IsVirtualizing` attached property to `true`. If you want to enable UI virtualization for custom controls that derive from <xref:System.Windows.Controls.ItemsControl> or existing item controls that use the <xref:System.Windows.Controls.StackPanel> class, such as <xref:System.Windows.Controls.ComboBox>, you can set the <xref:System.Windows.Controls.ItemsControl.ItemsPanel%2A> to <xref:System.Windows.Controls.VirtualizingStackPanel> and set <xref:System.Windows.Controls.VirtualizingPanel.IsVirtualizing%2A> to `true`. Unfortunately, you can disable UI virtualization for these controls without realizing it. The following is a list of conditions that disable UI virtualization.  
  
-   Item containers are added directly to the <xref:System.Windows.Controls.ItemsControl>. For example, if an application explicitly adds <xref:System.Windows.Controls.ListBoxItem> objects to a <xref:System.Windows.Controls.ListBox>, the <xref:System.Windows.Controls.ListBox> does not virtualize the <xref:System.Windows.Controls.ListBoxItem> objects.  
  
-   Item containers in the <xref:System.Windows.Controls.ItemsControl> are of different types. For example, a <xref:System.Windows.Controls.Menu> that uses <xref:System.Windows.Controls.Separator> objects cannot implement item recycling because the <xref:System.Windows.Controls.Menu> contains objects of type <xref:System.Windows.Controls.Separator> and <xref:System.Windows.Controls.MenuItem>.  
  
-   Setting <xref:System.Windows.Controls.ScrollViewer.CanContentScroll%2A> to `false`.  
  
-   Setting <!--zz <xref:System.Windows.Controls.VirtualizingStackPanel.IsVirtualizing%2A>-->  `IsVirtualizing`  to `false`.  
  
 An important consideration when you virtualize item containers is whether you have additional state information associated with an item container that belongs with the item. In this case, you must save the additional state. For example, you might have an item contained in an <xref:System.Windows.Controls.Expander> control and the <xref:System.Windows.Controls.Expander.IsExpanded%2A> state is bound to the item's container, and not to the item itself. When the container is reused for a new item, the current value of <xref:System.Windows.Controls.Expander.IsExpanded%2A> is used for the new item. In addition, the old item loses the correct <xref:System.Windows.Controls.Expander.IsExpanded%2A> value.  
  
 Currently, no WPF controls offer built-in support for data virtualization.  
  
<a name="Container"></a>   
## Container Recycling  
 An optimization to UI virtualization added in the .NET Framework 3.5 SP1 for controls that inherit from <xref:System.Windows.Controls.ItemsControl> is *container recycling,* which can also improve scrolling performance.  When an <xref:System.Windows.Controls.ItemsControl> that uses UI virtualization is populated, it creates an item container for each item that scrolls into view and destroys the item container for each item that scrolls out of view. *Container recycling* enables the control to reuse the existing item containers for different data items, so that item containers are not constantly created and destroyed as the user scrolls the <xref:System.Windows.Controls.ItemsControl>. You can choose to enable item recycling by setting the <xref:System.Windows.Controls.VirtualizingPanel.VirtualizationMode%2A> attached property to <xref:System.Windows.Controls.VirtualizationMode.Recycling>.  
  
 Any <xref:System.Windows.Controls.ItemsControl> that supports virtualization can use container recycling.  For an example of how to enable container recycling on a <xref:System.Windows.Controls.ListBox>, see [Improve the Scrolling Performance of a ListBox](../../../../docs/framework/wpf/controls/how-to-improve-the-scrolling-performance-of-a-listbox.md).  
  
<a name="Supporting"></a>   
## Supporting Bidirectional Virtualization  
 <xref:System.Windows.Controls.VirtualizingStackPanel> offers built-in support for UI virtualization in one direction, either horizontally or vertically. If you want to use bidirectional virtualization for your controls, you must implement a custom panel that extends the <xref:System.Windows.Controls.VirtualizingStackPanel> class. The <xref:System.Windows.Controls.VirtualizingStackPanel> class exposes virtual methods such as <xref:System.Windows.Controls.VirtualizingStackPanel.OnViewportSizeChanged%2A>, <xref:System.Windows.Controls.VirtualizingStackPanel.LineUp%2A>, <xref:System.Windows.Controls.VirtualizingStackPanel.PageUp%2A>, and <xref:System.Windows.Controls.VirtualizingStackPanel.MouseWheelUp%2A>.These virtual methods enable you to detect a change in the visible part of a list and handle it accordingly.  
  
<a name="Optimizing"></a>   
## Optimizing Templates  
 The visual tree contains all the visual elements in an application.  In addition to the objects directly created, it also contains objects due to template expansion.  For example, when you create a <xref:System.Windows.Controls.Button>, you also get <xref:Microsoft.Windows.Themes.ClassicBorderDecorator> and <xref:System.Windows.Controls.ContentPresenter> objects in the visual tree.  If you haven't optimized your control templates, you may be creating a lot of extra unnecessary objects in the visual tree.   For more information on the visual tree, see [WPF Graphics Rendering Overview](../../../../docs/framework/wpf/graphics-multimedia/wpf-graphics-rendering-overview.md).  
  
<a name="Deferred"></a>   
## Deferred Scrolling  
 By default, when the user drags the thumb on a scrollbar, the content view continuously updates.  If scrolling is slow in your control, consider using deferred scrolling.  In deferred scrolling, the content is updated only when the user releases the thumb.  
  
 To implement deferred scrolling, set the <xref:System.Windows.Controls.ScrollViewer.IsDeferredScrollingEnabled%2A> property to `true`.  <xref:System.Windows.Controls.ScrollViewer.IsDeferredScrollingEnabled%2A> is an attached property and can be set on <xref:System.Windows.Controls.ScrollViewer> and any control that has a <xref:System.Windows.Controls.ScrollViewer> in its control template.  
  
<a name="Controls"></a>   
## Controls That Implement Performance Features  
 The following table lists the common controls for displaying data and their support of performance features.  See the previous sections for information on how to enable these features.  
  
|Control|Virtualization|Container recycling|Deferred scrolling|  
|-------------|--------------------|-------------------------|------------------------|  
|<xref:System.Windows.Controls.ComboBox>|Can be enabled|Can be enabled|Can be enabled|  
|<xref:System.Windows.Controls.ContextMenu>|Can be enabled|Can be enabled|Can be enabled|  
|<xref:System.Windows.Controls.DocumentViewer>|Not available|Not available|Can be enabled|  
|<xref:System.Windows.Controls.ListBox>|Default|Can be enabled|Can be enabled|  
|<xref:System.Windows.Controls.ListView>|Default|Can be enabled|Can be enabled|  
|<xref:System.Windows.Controls.TreeView>|Can be enabled|Can be enabled|Can be enabled|  
|<xref:System.Windows.Controls.ToolBar>|Not available|Not available|Can be enabled|  
  
> [!NOTE]
>  For an example of how to enable virtualization and container recycling on a <xref:System.Windows.Controls.TreeView>, see [Improve the Performance of a TreeView](../../../../docs/framework/wpf/controls/how-to-improve-the-performance-of-a-treeview.md).  
  
## See Also  
 [Layout](../../../../docs/framework/wpf/advanced/layout.md)  
 [Layout and Design](../../../../docs/framework/wpf/advanced/optimizing-performance-layout-and-design.md)  
 [Data Binding](../../../../docs/framework/wpf/advanced/optimizing-performance-data-binding.md)  
 [Controls](../../../../docs/framework/wpf/controls/index.md)  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [Walkthrough: Caching Application Data in a WPF Application](../../../../docs/framework/wpf/advanced/walkthrough-caching-application-data-in-a-wpf-application.md)
