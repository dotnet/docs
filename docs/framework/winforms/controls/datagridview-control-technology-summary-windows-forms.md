---
title: "DataGridView Control Technology Summary (Windows Forms)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "DataGridView control [Windows Forms], about DataGridView control"
  - "data grids [Windows Forms], about data grids"
ms.assetid: 094498c3-a126-4a3f-83fe-f69e96c7717b
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DataGridView Control Technology Summary (Windows Forms)
This topic summarizes information about the `DataGridView` control and the classes that support its use.  
  
 Displaying data in a tabular format is a task you are likely to perform frequently. The `DataGridView` control is designed to be a complete solution for presenting data in a grid.  
  
## Keywords  
 DataGridView, BindingSource, table, cell, data binding, virtual mode  
  
## Namespaces  
 <xref:System.Windows.Forms?displayProperty=nameWithType>  
  
 <xref:System.Data?displayProperty=nameWithType>  
  
## Related Technologies  
 `BindingSource`  
  
## Background  
 User interface (UI) designers frequently find it necessary to display tabular data to users. The [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] provides several ways to show data in a table or grid. The `DataGridView` control represents the latest evolution of this technology for Windows Forms applications.  
  
 The `DataGridView` control can display rows of data from a data store. Many types of data stores are supported. The data store can hold simple, untyped data, such as a one-dimensional array, or it can hold typed data, such as a <xref:System.Data.DataSet>. For more information, see [How to: Bind Data to the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-bind-data-to-the-windows-forms-datagridview-control.md).  
  
 The `DataGridView` control provides a powerful and flexible way to display data in a tabular format. You can use the control to show read-only or editable views of small to very large sets of data.  
  
 You can extend the `DataGridView` control in several ways to build custom behavior into your applications. For example, you can programmatically specify your own sorting algorithms, and you can create your own types of cells. You can easily customize the appearance of the `DataGridView` control by choosing among several properties. Many types of data stores can be used as a data source, or the `DataGridView` control can operate without a data source bound to it.  
  
## Implementing DataGridView Classes  
 There are several ways for you to take advantage of the `DataGridView` control's extensibility features. You can customize many aspects of the control through events and properties, but some customizations require you to create new classes derived from existing `DataGridView` classes.  
  
 The most typically used base classes are `DataGridViewCell` and `DataGridViewColumn`. You can derive your own cell class from `DataGridViewCell` or any of its child classes. Although you can add any cell type to any column, you will typically also derive a companion column class from `DataGridViewColumn` that hosts cells of your custom cell type by default.  
  
 You can implement the `IDataGridViewEditingCell` interface in your derived cell class to create a cell type that has editing functionality but does not host a control in editing mode. To create a control that you can host in a cell in editing mode, you can implement the `IDataGridViewEditingControl` interface in a class derived from <xref:System.Windows.Forms.Control>.  
  
 For more information, see [How to: Customize Cells and Columns in the Windows Forms DataGridView Control by Extending Their Behavior and Appearance](../../../../docs/framework/winforms/controls/customize-cells-and-columns-in-the-datagrid-by-extending-behavior.md) and [How to: Host Controls in Windows Forms DataGridView Cells](../../../../docs/framework/winforms/controls/how-to-host-controls-in-windows-forms-datagridview-cells.md).  
  
## DataGridView Classes at a Glance  
 <xref:System.Windows.Forms>  
  
|Technology Area|Classes/interfaces/configuration elements|  
|---------------------|-------------------------------------------------|  
|Data Binding|<xref:System.Windows.Forms.BindingSource>|  
|Data Presentation|<xref:System.Windows.Forms.DataGridView><br /><br /> <xref:System.Windows.Forms.DataGridViewCell> and derived classes<br /><br /> <xref:System.Windows.Forms.DataGridViewRow> and derived classes<br /><br /> <xref:System.Windows.Forms.DataGridViewColumn> and derived classes<br /><br /> <xref:System.Windows.Forms.DataGridViewCellStyle>|  
|<xref:System.Windows.Forms.DataGridView> Extensibility|<xref:System.Windows.Forms.DataGridViewCell> and derived classes<br /><br /> <xref:System.Windows.Forms.DataGridViewColumn> and derived classes<br /><br /> <xref:System.Windows.Forms.IDataGridViewEditingCell><br /><br /> <xref:System.Windows.Forms.IDataGridViewEditingControl>|  
  
## What's New  
 The <xref:System.Windows.Forms.DataGridView> control is designed to be a complete solution for displaying tabular data with Windows Forms. You should consider using the <xref:System.Windows.Forms.DataGridView> control before other solutions, such as <xref:System.Windows.Forms.DataGrid>, when you are authoring a new application. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).  
  
 The <xref:System.Windows.Forms.DataGridView> control can work in close conjunction with the <xref:System.Windows.Forms.BindingSource> component. This component is designed to be the primary data source of a form. It can manage the interaction between a <xref:System.Windows.Forms.DataGridView> control and its data source, regardless of the data source type.  
  
## See Also  
 [DataGridView Control Overview](../../../../docs/framework/winforms/controls/datagridview-control-overview-windows-forms.md)  
 [DataGridView Control Architecture](../../../../docs/framework/winforms/controls/datagridview-control-architecture-windows-forms.md)  
 [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md)
