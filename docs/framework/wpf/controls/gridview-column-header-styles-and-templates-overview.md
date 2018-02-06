---
title: "GridView Column Header Styles and Templates Overview"
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
  - "column headers [WPF], customizing"
  - "ListView controls [WPF], GridView column header styles"
  - "controls [WPF], ListView"
  - "headers [WPF], customizing"
  - "GridView view mode [WPF], customizing column headers"
ms.assetid: 74835674-a39e-4ab5-9418-ad7f6ab7b956
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# GridView Column Header Styles and Templates Overview
This overview discusses the order of precedence for properties that you use to customize a column header in the <xref:System.Windows.Controls.GridView> view mode of a <xref:System.Windows.Controls.ListView> control.  
  
## Customizing a Column Header in a GridView  
 The properties that define the content, layout, and style of a column header in a <xref:System.Windows.Controls.GridView> are found on many related classes. Some of these properties have functionality that is similar or the same.  
  
 The rows in the following table show groups of properties that perform the same function. You can use these properties to customize the column headers in a <xref:System.Windows.Controls.GridView>. The order of precedence for related properties is from right to left where the property in the farthest right column has the highest precedence. For example, if a <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> is set on the <xref:System.Windows.Controls.GridViewColumnHeader> object and the <xref:System.Windows.Controls.GridViewColumn.HeaderTemplateSelector%2A> is set on the associated <xref:System.Windows.Controls.GridViewColumn>, the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> takes precedence. In this scenario, the <xref:System.Windows.Controls.GridViewColumn.HeaderTemplateSelector%2A> has no effect.  
  
 **Related properties for column headers in a GridView**  
  
|||||  
|-|-|-|-|  
|**Classes**|<xref:System.Windows.Controls.GridView>|<xref:System.Windows.Controls.GridViewColumn>|<xref:System.Windows.Controls.GridViewColumnHeader>|  
|**Context Menu Properties**|<xref:System.Windows.Controls.GridView.ColumnHeaderContextMenu%2A>|Not applicable|<xref:System.Windows.FrameworkElement.ContextMenu%2A>|  
|**ToolTip**<br /><br /> **Properties**|<xref:System.Windows.Controls.GridView.ColumnHeaderToolTip%2A>|Not applicable|<xref:System.Windows.FrameworkElement.ToolTip%2A>|  
|**Header Template**<br /><br /> **Properties**|<xref:System.Windows.Controls.GridView.ColumnHeaderTemplate%2A> <sup>1</sup>/<br /><br /> <xref:System.Windows.Controls.GridView.ColumnHeaderTemplateSelector%2A>|<xref:System.Windows.Controls.GridViewColumn.HeaderTemplate%2A> <sup>1</sup>/<br /><br /> <xref:System.Windows.Controls.GridViewColumn.HeaderTemplateSelector%2A>|<xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> <sup>1</sup>/<br /><br /> <xref:System.Windows.Controls.ContentControl.ContentTemplateSelector%2A>|  
|**Style Properties**|<xref:System.Windows.Controls.GridView.ColumnHeaderContainerStyle%2A>|<xref:System.Windows.Controls.GridViewColumn.HeaderContainerStyle%2A>|<xref:System.Windows.FrameworkElement.Style%2A>|  
  
 <sup>1</sup>For **Header Template Properties**, if you set both the template and template selector properties, the template property takes precedence. For example, if you set both the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> and <xref:System.Windows.Controls.ContentControl.ContentTemplateSelector%2A> properties, the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> property takes precedence.  
  
## See Also  
 [How-to Topics](../../../../docs/framework/wpf/controls/listview-how-to-topics.md)  
 [ListView Overview](../../../../docs/framework/wpf/controls/listview-overview.md)  
 [GridView Overview](../../../../docs/framework/wpf/controls/gridview-overview.md)
