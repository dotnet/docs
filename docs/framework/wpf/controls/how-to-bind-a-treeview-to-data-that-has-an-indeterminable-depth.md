---
title: "How to: Bind a TreeView to Data That Has an Indeterminable Depth"
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
  - "TreeView control [WPF], binding to data of indeterminate depth"
ms.assetid: daddcd74-1b0f-4ffd-baeb-ec934c5e0f53
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Bind a TreeView to Data That Has an Indeterminable Depth
There might be times when you want to bind a <xref:System.Windows.Controls.TreeView> to a data source whose depth is not known.  This can occur when the data is recursive in nature, such as a file system, where folders can contain folders, or a company's organizational structure, where employees have other employees as direct reports.  
  
 The data source must have a hierarchical object model. For example, an `Employee` class might contain a collection of Employee objects that are the direct reports of an employee. If the data is represented in a way that is not hierarchical, you must build a hierarchical representation of the data.  
  
 When you set the <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A?displayProperty=nameWithType> property and if the <xref:System.Windows.Controls.ItemsControl> generates an <xref:System.Windows.Controls.ItemsControl> for each child item, then the child <xref:System.Windows.Controls.ItemsControl> uses the same <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> as the parent. For example, if you set the <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> property on a data-bound <xref:System.Windows.Controls.TreeView>, each <xref:System.Windows.Controls.TreeViewItem> that is generated uses the <xref:System.Windows.DataTemplate> that was assigned to the <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> property of the <xref:System.Windows.Controls.TreeView>.  
  
 The <xref:System.Windows.HierarchicalDataTemplate> enables you to specify the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> for a <xref:System.Windows.Controls.TreeViewItem>, or any <xref:System.Windows.Controls.HeaderedItemsControl>, on the data template. When you set the <xref:System.Windows.HierarchicalDataTemplate.ItemsSource%2A?displayProperty=nameWithType> property, that value is used when the <xref:System.Windows.HierarchicalDataTemplate> is applied. By using a <xref:System.Windows.HierarchicalDataTemplate>, you can recursively set the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> for each <xref:System.Windows.Controls.TreeViewItem> in the <xref:System.Windows.Controls.TreeView>.  
  
## Example  
 The following example demonstrates how to bind a <xref:System.Windows.Controls.TreeView> to hierarchical data and use a <xref:System.Windows.HierarchicalDataTemplate> to specify the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> for each <xref:System.Windows.Controls.TreeViewItem>.  The <xref:System.Windows.Controls.TreeView> binds to XML data that represents the employees in a company.  Each `Employee` element can contain other `Employee` elements to indicate who reports to whom. Because the data is recursive, the <xref:System.Windows.HierarchicalDataTemplate> can be applied to each level.  
  
 [!code-xaml[TreeViewWithUnknownDepth#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/TreeViewWithUnknownDepth/CS/Window1.xaml#1)]  
  
## See Also  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [Data Templating Overview](../../../../docs/framework/wpf/data/data-templating-overview.md)
