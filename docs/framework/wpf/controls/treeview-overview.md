---
title: "TreeView Overview"
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
  - "expanding node [WPF]"
  - "TreeView control [WPF], about TreeView control"
  - "Control class [WPF], TreeView"
ms.assetid: 62212512-5a5c-4864-949e-b6a6a3a52c02
caps.latest.revision: 33
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# TreeView Overview
The <xref:System.Windows.Controls.TreeView> control provides a way to display information in a hierarchical structure by using collapsible nodes. This topic introduces the <xref:System.Windows.Controls.TreeView> and <xref:System.Windows.Controls.TreeViewItem> controls, and provides simple examples of their use.  
  
  
<a name="Simple_TreeView_Control"></a>   
## What Is a TreeView?  
 <xref:System.Windows.Controls.TreeView> is an <xref:System.Windows.Controls.ItemsControl> that nests the items by using <xref:System.Windows.Controls.TreeViewItem> controls. The following example creates a <xref:System.Windows.Controls.TreeView>.  
  
 [!code-xaml[TreeViewSnips#EmbeddedTVIs](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TreeViewSnips/CSharp/Window1.xaml#embeddedtvis)]  
  
<a name="Creating_a_TreeView"></a>   
## Creating a TreeView  
 The <xref:System.Windows.Controls.TreeView> control contains a hierarchy of <xref:System.Windows.Controls.TreeViewItem> controls. A <xref:System.Windows.Controls.TreeViewItem> control is a <xref:System.Windows.Controls.HeaderedItemsControl> that has a <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> and an <xref:System.Windows.Controls.ItemsControl.Items%2A> collection.  
  
 If you are defining a <xref:System.Windows.Controls.TreeView> by using [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)], you can explicitly define the <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> content of a <xref:System.Windows.Controls.TreeViewItem> control and the items that make up its collection. The previous illustration demonstrates this method.  
  
 You can also specify an <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> as a data source and then specify a <xref:System.Windows.Controls.HeaderedItemsControl.HeaderTemplate%2A> and <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> to define the <xref:System.Windows.Controls.TreeViewItem> content.  
  
 To define the layout of a <xref:System.Windows.Controls.TreeViewItem> control, you can also use <xref:System.Windows.HierarchicalDataTemplate> objects. For more information and an example, see [Use SelectedValue, SelectedValuePath, and SelectedItem](../../../../docs/framework/wpf/controls/how-to-use-selectedvalue-selectedvaluepath-and-selecteditem.md).  
  
 If an item is not a <xref:System.Windows.Controls.TreeViewItem> control, it is automatically enclosed by a <xref:System.Windows.Controls.TreeViewItem> control when the <xref:System.Windows.Controls.TreeView> control is displayed.  
  
<a name="Expanding_and_Collapsing_a_TreeViewItem"></a>   
## Expanding and Collapsing a TreeViewItem  
 If the user expands a <xref:System.Windows.Controls.TreeViewItem>, the <xref:System.Windows.Controls.TreeViewItem.IsExpanded%2A> property is set to `true`. You can also expand or collapse a <xref:System.Windows.Controls.TreeViewItem> without any direct user action by setting the <xref:System.Windows.Controls.TreeViewItem.IsExpanded%2A> property to `true` (expand) or `false` (collapse). When this property changes, an <xref:System.Windows.Controls.TreeViewItem.Expanded> or <xref:System.Windows.Controls.TreeViewItem.Collapsed> event occurs.  
  
 When the <xref:System.Windows.FrameworkElement.BringIntoView%2A> method is called on a <xref:System.Windows.Controls.TreeViewItem> control, the <xref:System.Windows.Controls.TreeViewItem> and its parent <xref:System.Windows.Controls.TreeViewItem> controls expand. If a <xref:System.Windows.Controls.TreeViewItem> is not visible or partially visible, the <xref:System.Windows.Controls.TreeView> scrolls to make it visible.  
  
<a name="TreeViewItem_Selection"></a>   
## TreeViewItem Selection  
 When a user clicks a <xref:System.Windows.Controls.TreeViewItem> control to select it, the <xref:System.Windows.Controls.TreeViewItem.Selected> event occurs, and its <xref:System.Windows.Controls.TreeViewItem.IsSelected%2A> property is set to `true`. The <xref:System.Windows.Controls.TreeViewItem> also becomes the <xref:System.Windows.Controls.TreeView.SelectedItem%2A> of the <xref:System.Windows.Controls.TreeView> control. Conversely, when the selection changes from a <xref:System.Windows.Controls.TreeViewItem> control, its <xref:System.Windows.Controls.TreeViewItem.Unselected> event occurs and its <xref:System.Windows.Controls.TreeViewItem.IsSelected%2A> property is set to `false`.  
  
 The <xref:System.Windows.Controls.TreeView.SelectedItem%2A> property on the <xref:System.Windows.Controls.TreeView> control is a read-only property; hence, you cannot explicitly set it. The <xref:System.Windows.Controls.TreeView.SelectedItem%2A> property is set if the user clicks on a <xref:System.Windows.Controls.TreeViewItem> control or when the <xref:System.Windows.Controls.TreeViewItem.IsSelected%2A> property is set to `true` on the <xref:System.Windows.Controls.TreeViewItem> control.  
  
 Use the <xref:System.Windows.Controls.TreeView.SelectedValuePath%2A> property to specify a <xref:System.Windows.Controls.TreeView.SelectedValue%2A> of a <xref:System.Windows.Controls.TreeView.SelectedItem%2A>. For more information, see [Use SelectedValue, SelectedValuePath, and SelectedItem](../../../../docs/framework/wpf/controls/how-to-use-selectedvalue-selectedvaluepath-and-selecteditem.md).  
  
 You can register an event handler on the <xref:System.Windows.Controls.TreeView.SelectedItemChanged> event in order to determine when a selected <xref:System.Windows.Controls.TreeViewItem> changes. The <xref:System.Windows.RoutedPropertyChangedEventArgs%601> that is provided to the event handler specifies the <xref:System.Windows.RoutedPropertyChangedEventArgs%601.OldValue%2A>, which is the previous selection, and the <xref:System.Windows.RoutedPropertyChangedEventArgs%601.NewValue%2A>, which is the current selection. Either value can be `null` if the application or user has not made a previous or current selection.  
  
<a name="TreeView_Style"></a>   
## TreeView Style  
 The default style for a <xref:System.Windows.Controls.TreeView> control places it inside a <xref:System.Windows.Controls.StackPanel> object that contains a <xref:System.Windows.Controls.ScrollViewer> control. When you set the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties for a <xref:System.Windows.Controls.TreeView>, these values are used to size the <xref:System.Windows.Controls.StackPanel> object that displays the <xref:System.Windows.Controls.TreeView>. If the content to display is larger than the display area, a <xref:System.Windows.Controls.ScrollViewer> automatically displays so that the user can scroll through the <xref:System.Windows.Controls.TreeView> content.  
  
 To customize the appearance of a <xref:System.Windows.Controls.TreeViewItem> control, set the <xref:System.Windows.FrameworkElement.Style%2A> property to a custom <xref:System.Windows.Style>.  
  
 The following example shows how to set the <xref:System.Windows.Controls.Control.Foreground%2A> and <xref:System.Windows.Controls.Control.FontSize%2A> property values for a <xref:System.Windows.Controls.TreeViewItem> control by using a <xref:System.Windows.FrameworkElement.Style%2A>.  
  
 [!code-xaml[TreeViewSimple#8](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TreeViewSimple/CS/Window1.xaml#8)]  
  
<a name="Adding_Images_and_oOther_Content_to_TreeView_Items"></a>   
## Adding Images and Other Content to TreeView Items  
 You can include more than one object in the <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> content of a <xref:System.Windows.Controls.TreeViewItem>. To include multiple objects in <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> content, enclose the objects inside a layout control, such as a <xref:System.Windows.Controls.Panel> or <xref:System.Windows.Controls.StackPanel>.  
  
 The following example shows how to define the <xref:System.Windows.Controls.HeaderedItemsControl.Header%2A> of a <xref:System.Windows.Controls.TreeViewItem> as a <xref:System.Windows.Controls.CheckBox> and <xref:System.Windows.Controls.TextBlock> that are both enclosed in a <xref:System.Windows.Controls.DockPanel> control.  
  
 [!code-xaml[TreeViewSnips#TVIHeader](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TreeViewSnips/CSharp/Window1.xaml#tviheader)]  
  
 The following example shows how to define a <xref:System.Windows.DataTemplate> that contains an <xref:System.Windows.Controls.Image> and a <xref:System.Windows.Controls.TextBlock> that are enclosed in a <xref:System.Windows.Controls.DockPanel> control. You can use a <xref:System.Windows.DataTemplate> to set the <xref:System.Windows.Controls.HeaderedItemsControl.HeaderTemplate%2A> or <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> for a <xref:System.Windows.Controls.TreeViewItem>.  
  
 [!code-xaml[TreeViewDataBinding#6](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TreeViewDataBinding/CSharp/Window1.xaml#6)]  
  
## See Also  
 <xref:System.Windows.Controls.TreeView>  
 <xref:System.Windows.Controls.TreeViewItem>  
 [How-to Topics](../../../../docs/framework/wpf/controls/treeview-how-to-topics.md)  
 [WPF Content Model](../../../../docs/framework/wpf/controls/wpf-content-model.md)
