---
title: "ListView Overview"
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
  - "controls [WPF], ListView"
  - "ListView controls [WPF], about ListView control"
ms.assetid: 989e12b0-260e-4570-95c6-489284003ce2
caps.latest.revision: 25
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ListView Overview
The <xref:System.Windows.Controls.ListView> control provides the infrastructure to display a set of data items in different layouts or views. For example, a user may want to display data items in a table and also to sort its columns.  
  
  
<a name="WhatisaListView"></a>   
## What Is a ListView?  
 The <xref:System.Windows.Controls.ListView> control is an <xref:System.Windows.Controls.ItemsControl> that is derived from <xref:System.Windows.Controls.ListBox>. Typically, its items are members of a data collection and are represented as <xref:System.Windows.Controls.ListViewItem> objects. A <xref:System.Windows.Controls.ListViewItem> is a <xref:System.Windows.Controls.ContentControl> and can contain only a single child element. However, that child element can be any visual element.  
  
<a name="DefiningaListViewView"></a>   
## Defining a View Mode for a ListView  
 To specify a view mode for the content of a <xref:System.Windows.Controls.ListView> control, you set the <xref:System.Windows.Controls.ListView.View%2A> property. One view mode that [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides is <xref:System.Windows.Controls.GridView>, which displays a collection of data items in a table that has customizable columns.  
  
 The following example shows how to define a <xref:System.Windows.Controls.GridView> for a <xref:System.Windows.Controls.ListView> control that displays employee information.  
  
 [!code-xaml[ListViewCode#ListViewEmployee](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml#listviewemployee)]  
  
 The following illustration shows how the data appears for the previous example.  
  
 ![ListView with GridView output](../../../../docs/framework/wpf/controls/media/listviewgridview.JPG "ListViewGridView")  
  
 You can create a custom view mode by defining a class that inherits from the <xref:System.Windows.Controls.ViewBase> class. The <xref:System.Windows.Controls.ViewBase> class provides the infrastructure that you need to create a custom view. For more information about how to create a custom view, see [Create a Custom View Mode for a ListView](../../../../docs/framework/wpf/controls/how-to-create-a-custom-view-mode-for-a-listview.md).  
  
<a name="BindingDatatoaListView"></a>   
## Binding Data to a ListView  
 Use the <xref:System.Windows.Controls.ItemsControl.Items%2A> and <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> properties to specify items for a <xref:System.Windows.Controls.ListView> control. The following example sets the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> property to a data collection that is called `EmployeeInfoDataSource`.  
  
 [!code-xaml[ListViewCode#ItemsSource](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml#itemssource)]  
  
 In a <xref:System.Windows.Controls.GridView>, <xref:System.Windows.Controls.GridViewColumn> objects bind to specified data fields. The following example binds a <xref:System.Windows.Controls.GridViewColumn> object to a data field by specifying a <xref:System.Windows.Data.Binding> for the <xref:System.Windows.Controls.GridViewColumn.DisplayMemberBinding%2A> property.  
  
 [!code-csharp[ListViewCode#GridViewColumnProperties](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml.cs#gridviewcolumnproperties)]
 [!code-vb[ListViewCode#GridViewColumnProperties](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ListViewCode/visualbasic/window1.xaml.vb#gridviewcolumnproperties)]
 [!code-xaml[ListViewCode#GridViewColumnProperties](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewCode/CSharp/Window1.xaml#gridviewcolumnproperties)]  
  
 You can also specify a <xref:System.Windows.Data.Binding> as part of a <xref:System.Windows.DataTemplate> definition that you use to style the cells in a column. In the following example, the <xref:System.Windows.DataTemplate> that is identified with a <xref:System.Windows.ResourceKey> sets the <xref:System.Windows.Data.Binding> for a <xref:System.Windows.Controls.GridViewColumn>. Note that this example does not define the <xref:System.Windows.Controls.GridViewColumn.DisplayMemberBinding%2A> because doing so overrides the binding that is specified by <xref:System.Windows.DataTemplate>.  
  
 [!code-xaml[ListViewTemplate#GridViewCellTemplate](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewTemplate/CS/window1.xaml#gridviewcelltemplate)]  
  
 [!code-xaml[ListViewTemplate#CellTemplateProperty](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ListViewTemplate/CS/window1.xaml#celltemplateproperty)]  
  
<a name="StylingaListView"></a>   
## Styling a ListView That Implements a GridView  
 The <xref:System.Windows.Controls.ListView> control contains <xref:System.Windows.Controls.ListViewItem> objects, which represent the data items that are displayed. You can use the following properties to define the content and style of data items:  
  
-   On the <xref:System.Windows.Controls.ListView> control, use the <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A>, <xref:System.Windows.Controls.ItemsControl.ItemTemplateSelector%2A>, and <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> properties.  
  
-   On the <xref:System.Windows.Controls.ListViewItem> control, use the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> and <xref:System.Windows.Controls.ContentControl.ContentTemplateSelector%2A> properties.  
  
 To avoid alignment issues between cells in a <xref:System.Windows.Controls.GridView>, do not use the <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> to set properties or add content that affects the width of an item in a <xref:System.Windows.Controls.ListView>. For example, an alignment issue can occur when you set the <xref:System.Windows.FrameworkElement.Margin%2A> property in the <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A>. To specify properties or define content that affects the width of items in a <xref:System.Windows.Controls.GridView>, use the properties of the <xref:System.Windows.Controls.GridView> class and its related classes, such as <xref:System.Windows.Controls.GridViewColumn>.  
  
 For more information about how to use <xref:System.Windows.Controls.GridView> and its supporting classes, see [GridView Overview](../../../../docs/framework/wpf/controls/gridview-overview.md).  
  
 If you define an <xref:System.Windows.Controls.ItemsControl.ItemContainerStyle%2A> for a <xref:System.Windows.Controls.ListView> control and also define an <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A>, you must include a <xref:System.Windows.Controls.ContentPresenter> in the style in order for the <xref:System.Windows.Controls.ItemsControl.ItemTemplate%2A> to work correctly.  
  
 Do not use the <xref:System.Windows.Controls.Control.HorizontalContentAlignment%2A> and <xref:System.Windows.Controls.Control.VerticalContentAlignment%2A> properties for <xref:System.Windows.Controls.ListView> content that is displayed by using a <xref:System.Windows.Controls.GridView>. To specify the alignment of content in a column of a <xref:System.Windows.Controls.GridView>, define a <xref:System.Windows.Controls.GridViewColumn.CellTemplate%2A>.  
  
<a name="UsingtheSameViewMoreThanOnce"></a>   
## Sharing the Same View Mode  
 Two <xref:System.Windows.Controls.ListView> controls cannot share the same view mode at the same time. If you try to use the same view mode with more than one <xref:System.Windows.Controls.ListView> control, an exception occurs.  
  
 To specify a view mode that can be simultaneously used by more than one <xref:System.Windows.Controls.ListView>, use templates or styles. For an example of how to define views as <xref:System.Windows.FrameworkElement.Resources%2A>, see [ListView with Multiple Views Sample](http://go.microsoft.com/fwlink/?LinkID=160013).  
  
<a name="CreatingaCustomView"></a>   
## Creating a Custom View Mode  
 Customized views like <xref:System.Windows.Controls.GridView> are derived from the <xref:System.Windows.Controls.ViewBase> abstract class, which provides the tools to display data items that are represented as <xref:System.Windows.Controls.ListViewItem> objects.  
  
 For an example of a custom view mode, see [ListView with Multiple Views Sample](http://go.microsoft.com/fwlink/?LinkID=160013).  
  
## See Also  
 <xref:System.Windows.Controls.GridView>  
 <xref:System.Windows.Controls.ListView>  
 <xref:System.Windows.Controls.ListViewItem>  
 <xref:System.Windows.Data.Binding>  
 [GridView Overview](../../../../docs/framework/wpf/controls/gridview-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/controls/listview-how-to-topics.md)  
 [Controls](../../../../docs/framework/wpf/advanced/optimizing-performance-controls.md)
