---
title: "Differences Between the Windows Forms DataGridView and DataGrid Controls"
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
  - "data grids [Windows Forms"
  - "DataGrid control [Windows Forms], DataGridView control compared"
  - "DataGridView control [Windows Forms], DataGrid control compared"
ms.assetid: d412c786-140e-4210-8a56-a68467530a55
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Differences Between the Windows Forms DataGridView and DataGrid Controls
The <xref:System.Windows.Forms.DataGridView> control is a new control that replaces the <xref:System.Windows.Forms.DataGrid> control. The <xref:System.Windows.Forms.DataGridView> control provides numerous basic and advanced features that are missing in the <xref:System.Windows.Forms.DataGrid> control. Additionally, the architecture of the <xref:System.Windows.Forms.DataGridView> control makes it much easier to extend and customize than the <xref:System.Windows.Forms.DataGrid> control.  
  
 The following table describes a few of the primary features available in the <xref:System.Windows.Forms.DataGridView> control that are missing from the <xref:System.Windows.Forms.DataGrid> control.  
  
|DataGridView control feature|Description|  
|----------------------------------|-----------------|  
|Multiple column types|The <xref:System.Windows.Forms.DataGridView> control provides more built-in column types than the <xref:System.Windows.Forms.DataGrid> control. These column types meet the needs of most common scenarios, but are also easier to extend or replace than the column types in the <xref:System.Windows.Forms.DataGrid> control. For more information, see [Column Types in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/column-types-in-the-windows-forms-datagridview-control.md).|  
|Multiple ways to display data|The <xref:System.Windows.Forms.DataGrid> control is limited to displaying data from an external data source. The <xref:System.Windows.Forms.DataGridView> control, however, can display unbound data stored in the control, data from a bound data source, or bound and unbound data together. You can also implement virtual mode in the <xref:System.Windows.Forms.DataGridView> control to provide custom data management. For more information, see [Data Display Modes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-display-modes-in-the-windows-forms-datagridview-control.md).|  
|Multiple ways to customize the display of data|The <xref:System.Windows.Forms.DataGridView> control provides many properties and events that enable you to specify how data is formatted and displayed. For example, you can change the appearance of cells, rows, and columns depending on the data they contain, or you can replace data of one data type with equivalent data of another type. For more information, see [Data Formatting in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-formatting-in-the-windows-forms-datagridview-control.md).|  
|Multiple options for changing cell, row, column, and header appearance and behavior|The <xref:System.Windows.Forms.DataGridView> control enables you to work with individual grid components in numerous ways. For example, you can freeze rows and columns to prevent them from scrolling; hide rows, columns, and headers; change the way row, column, and header sizes are adjusted; change the way users make selections; and provide ToolTips and shortcut menus for individual cells, rows, and columns.|  
  
 The <xref:System.Windows.Forms.DataGrid> control is retained for backward compatibility and for special needs. For nearly all purposes, you should use the <xref:System.Windows.Forms.DataGridView> control. The only feature that is available in the <xref:System.Windows.Forms.DataGrid> control that is not available in the <xref:System.Windows.Forms.DataGridView> control is the hierarchical display of information from two related tables in a single control. You must use two <xref:System.Windows.Forms.DataGridView> controls to display information from two tables that are in a master/detail relationship.  
  
## Upgrading to the DataGridView Control  
 If you have existing applications that use the <xref:System.Windows.Forms.DataGrid> control in a simple data-bound scenario without customizations, you can simply replace the old control with the new control. Both controls use the standard Windows Forms data-binding architecture, so the <xref:System.Windows.Forms.DataGridView> control will display your bound data with no additional configuration needed. You might want to consider taking advantage of data-binding improvements, however, by binding your data to a <xref:System.Windows.Forms.BindingSource> component, which you can then bind to the <xref:System.Windows.Forms.DataGridView> control. For more information, see [BindingSource Component](../../../../docs/framework/winforms/controls/bindingsource-component.md).  
  
 Because the <xref:System.Windows.Forms.DataGridView> control has an entirely new architecture, there is no straightforward conversion path that will enable you to use <xref:System.Windows.Forms.DataGrid> customizations with the <xref:System.Windows.Forms.DataGridView> control. Many <xref:System.Windows.Forms.DataGrid> customizations are unnecessary with the <xref:System.Windows.Forms.DataGridView> control, however, because of the built-in features available in the new control. If you have created custom column types for the <xref:System.Windows.Forms.DataGrid> control that you want to use with the <xref:System.Windows.Forms.DataGridView> control, you will have to implement them again using the new architecture. For more information, see [Customizing the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customizing-the-windows-forms-datagridview-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGrid>  
 <xref:System.Windows.Forms.BindingSource>  
 [DataGridView Control](../../../../docs/framework/winforms/controls/datagridview-control-windows-forms.md)  
 [DataGrid Control](../../../../docs/framework/winforms/controls/datagrid-control-windows-forms.md)  
 [BindingSource Component](../../../../docs/framework/winforms/controls/bindingsource-component.md)  
 [Column Types in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/column-types-in-the-windows-forms-datagridview-control.md)  
 [Cell Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/cell-styles-in-the-windows-forms-datagridview-control.md)  
 [Data Display Modes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-display-modes-in-the-windows-forms-datagridview-control.md)  
 [Data Formatting in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-formatting-in-the-windows-forms-datagridview-control.md)  
 [Sizing Options in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/sizing-options-in-the-windows-forms-datagridview-control.md)  
 [Column Sort Modes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/column-sort-modes-in-the-windows-forms-datagridview-control.md)  
 [Selection Modes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/selection-modes-in-the-windows-forms-datagridview-control.md)  
 [Customizing the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customizing-the-windows-forms-datagridview-control.md)
