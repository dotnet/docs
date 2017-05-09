---
title: "How to: Improve the Performance of a TreeView | Microsoft Docs"
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
  - "TreeView control [WPF], improving the performance"
ms.assetid: b792c740-cf2b-4da8-8ba8-3d2e5a821874
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
---
# How to: Improve the Performance of a TreeView
If a <xref:System.Windows.Controls.TreeView> contains many items, the amount of time it takes to load may cause a significant delay in the user interface. You can improve the load time by setting the <xref:System.Windows.Controls.VirtualizingStackPanel.IsVirtualizing%2A?displayProperty=fullName> attached property to `true`.  The UI might also be slow to react when a user scrolls the <xref:System.Windows.Controls.TreeView> by using the mouse wheel or dragging the thumb of a scrollbar. You can improve the performance of the <xref:System.Windows.Controls.TreeView> when the user scrolls by setting the <xref:System.Windows.Controls.VirtualizingStackPanel.VirtualizationMode%2A?displayProperty=fullName> attached property to <xref:System.Windows.Controls.VirtualizationMode>.  
  
## Example  
  
## Description  
 The following example creates a <xref:System.Windows.Controls.TreeView> that sets <xref:System.Windows.Controls.VirtualizingStackPanel.IsVirtualizing%2A?displayProperty=fullName> to true and <xref:System.Windows.Controls.VirtualizingStackPanel.VirtualizationMode%2A?displayProperty=fullName> to <xref:System.Windows.Controls.VirtualizationMode> to optimize its performance.  
  
## Code  
 [!code-xml[RecycleItemContainerShippets#VirtualizingTreeView](../../../../samples/snippets/csharp/VS_Snippets_Wpf/RecycleItemContainerShippets/CSharp/Window1.xaml#virtualizingtreeview)]  
  
 The following example shows the data that the previous example uses.  
  
 [!code-csharp[RecycleItemContainerShippets#TreeViewData](../../../../samples/snippets/csharp/VS_Snippets_Wpf/RecycleItemContainerShippets/CSharp/Window1.xaml.cs#treeviewdata)]
 [!code-vb[RecycleItemContainerShippets#TreeViewData](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/RecycleItemContainerShippets/visualbasic/window1.xaml.vb#treeviewdata)]  
  
## See Also  
 [Controls](../../../../docs/framework/wpf/advanced/optimizing-performance-controls.md)