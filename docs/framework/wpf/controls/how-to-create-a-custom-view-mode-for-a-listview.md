---
title: "How to: Create a Custom View Mode for a ListView"
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
  - "ListView controls [WPF], creating custom View mode"
ms.assetid: 71077349-eeb9-4344-ab29-b5df96df3314
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Custom View Mode for a ListView
This example shows how to create a custom <xref:System.Windows.Controls.ListView.View%2A> mode for a <xref:System.Windows.Controls.ListView> control.  
  
## Example  
 You must use the <xref:System.Windows.Controls.ViewBase> class when you create a custom view for the <xref:System.Windows.Controls.ListView> control. The following example shows a view mode that is called `PlainView`, which is derived from the <xref:System.Windows.Controls.ViewBase> class.  
  
 [!code-csharp[ListViewCustomView#PlainView](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCustomView/CSharp/PlainView.cs#plainview)]
 [!code-vb[ListViewCustomView#PlainView](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ListViewCustomView/visualbasic/plainview.vb#plainview)]  
  
 To apply a style to the custom view, use the <xref:System.Windows.Style> class. The following example defines a <xref:System.Windows.Style> for the `PlainView` view mode. In the previous example, this style is set as the value of the <xref:System.Windows.Controls.ViewBase.DefaultStyleKey%2A> property that is defined for `PlainView`.  
  
 [!code-xaml[ListViewCustomView#PlainViewStyle](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCustomView/CSharp/Themes/Generic.xaml#plainviewstyle)]  
  
 To define the layout of data in a custom view mode, define a <xref:System.Windows.DataTemplate> object. The following example defines a <xref:System.Windows.DataTemplate> that can be used to display data in the `PlainView` view mode.  
  
 [!code-xaml[ListViewCustomView#PlainViewDataTemplate](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCustomView/CSharp/Window1.xaml#plainviewdatatemplate)]  
  
 The following example shows how to define a <xref:System.Windows.ResourceKey> for the `PlainView` view mode that uses the <xref:System.Windows.DataTemplate> that is defined in the previous example.  
  
 [!code-xaml[ListViewCustomView#PlainViewtileView](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCustomView/CSharp/Window1.xaml#plainviewtileview)]  
  
 A <xref:System.Windows.Controls.ListView> control can use a custom view if you set the <xref:System.Windows.Controls.ListView.View%2A> property to the resource key. The following example shows how to specify `PlainView` as the view mode for a <xref:System.Windows.Controls.ListView>.  
  
 [!code-csharp[ListViewCustomView#ListViewtileViewmode](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCustomView/CSharp/Window1.xaml.cs#listviewtileviewmode)]
 [!code-vb[ListViewCustomView#ListViewtileViewmode](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ListViewCustomView/visualbasic/window1.xaml.vb#listviewtileviewmode)]  
  
 For the complete sample, see [ListView with Multiple Views Sample](http://go.microsoft.com/fwlink/?LinkID=160013).  
  
## See Also  
 <xref:System.Windows.Controls.ListView>  
 <xref:System.Windows.Controls.GridView>  
 [How-to Topics](../../../../docs/framework/wpf/controls/listview-how-to-topics.md)  
 [ListView Overview](../../../../docs/framework/wpf/controls/listview-overview.md)  
 [GridView Overview](../../../../docs/framework/wpf/controls/gridview-overview.md)
