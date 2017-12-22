---
title: "Virtual Mode in the Windows Forms DataGridView Control"
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
  - "DataGridView control [Windows Forms], virtual mode"
ms.assetid: feae5d43-2848-4b1a-8ea7-77085dc415b5
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Virtual Mode in the Windows Forms DataGridView Control
With virtual mode, you can manage the interaction between the <xref:System.Windows.Forms.DataGridView> control and a custom data cache. To implement virtual mode, set the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property to `true` and handle one or more of the events described in this topic. You will typically handle at least the `CellValueNeeded` event, which enables the control look up values in the data cache.  
  
## Bound Mode and Virtual Mode  
 Virtual mode is necessary only when you need to supplement or replace bound mode. In bound mode, you set the <xref:System.Windows.Forms.DataGridView.DataSource%2A> property and the control automatically loads the data from the specified source and submits user changes back to it. You can control which of the bound columns are displayed, and the data source itself typically handles operations such as sorting.  
  
## Supplementing Bound Mode  
 You can supplement bound mode by displaying unbound columns along with the bound columns. This is sometimes called "mixed mode" and is useful for displaying things like calculated values or user-interface (UI) controls.  
  
 Because unbound columns are outside the data source, they are ignored by the data source's sorting operations. Therefore, when you enable sorting in mixed mode, you must manage the unbound data in a local cache and implement virtual mode to let the <xref:System.Windows.Forms.DataGridView> control interact with it.  
  
 For more information about using virtual mode to maintain the values in unbound columns, see the examples in the <xref:System.Windows.Forms.DataGridViewCheckBoxColumn.ThreeState%2A?displayProperty=nameWithType> property and <xref:System.Windows.Forms.DataGridViewComboBoxColumn?displayProperty=nameWithType> class reference topics.  
  
## Replacing Bound Mode  
 If bound mode does not meet your performance needs, you can manage all your data in a custom cache through virtual-mode event handlers. For example, you can use virtual mode to implement a just-in-time data loading mechanism that retrieves only as much data from a networked database as is necessary for optimal performance. This scenario is particularly useful when working with large amounts of data over a slow network connection or with client machines that have a limited amount of RAM or storage space.  
  
 For more information about using virtual mode in a just-in-time scenario, see [Implementing Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-jit-data-loading-in-the-datagrid.md).  
  
## Virtual-Mode Events  
 If your data is read-only, the `CellValueNeeded` event may be the only event you will need to handle. Additional virtual-mode events let you enable specific functionality like user edits, row addition and deletion, and row-level transactions.  
  
 Some standard <xref:System.Windows.Forms.DataGridView> events (such as events that occur when users add or delete rows, or when cell values are edited, parsed, validated, or formatted) are useful in virtual mode, as well. You can also handle events that let you maintain values not typically stored in a bound data source, such as cell ToolTip text, cell and row error text, cell and row shortcut menu data, and row height data.  
  
 For more information about implementing virtual mode to manage read/write data with a row-level commit scope, see [Walkthrough: Implementing Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-wf-datagridview-control.md).  
  
 For an example that implements virtual mode with a cell-level commit scope, see the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property reference topic.  
  
 The following events occur only when the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property is set to `true`.  
  
|Event|Description|  
|-----------|-----------------|  
|<xref:System.Windows.Forms.DataGridView.CellValueNeeded>|Used by the control to retrieve a cell value from the data cache for display. This event occurs only for cells in unbound columns.|  
|<xref:System.Windows.Forms.DataGridView.CellValuePushed>|Used by the control to commit user input for a cell to the data cache. This event occurs only for cells in unbound columns.<br /><br /> Call the <xref:System.Windows.Forms.DataGridView.UpdateCellValue%2A> method when changing a cached value outside of a <xref:System.Windows.Forms.DataGridView.CellValuePushed> event handler to ensure that the current value is displayed in the control and to apply any automatic sizing modes currently in effect.|  
|<xref:System.Windows.Forms.DataGridView.NewRowNeeded>|Used by the control to indicate the need for a new row in the data cache.|  
|<xref:System.Windows.Forms.DataGridView.RowDirtyStateNeeded>|Used by the control to determine whether a row has any uncommitted changes.|  
|<xref:System.Windows.Forms.DataGridView.CancelRowEdit>|Used by the control to indicate that a row should revert to its cached values.|  
  
 The following events are useful in virtual mode, but can be used regardless of the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property setting.  
  
|Events|Description|  
|------------|-----------------|  
|<xref:System.Windows.Forms.DataGridView.UserDeletingRow><br /><br /> <xref:System.Windows.Forms.DataGridView.UserDeletedRow><br /><br /> <xref:System.Windows.Forms.DataGridView.RowsRemoved><br /><br /> <xref:System.Windows.Forms.DataGridView.RowsAdded>|Used by the control to indicate when rows are deleted or added, letting you update the data cache accordingly.|  
|<xref:System.Windows.Forms.DataGridView.CellFormatting><br /><br /> <xref:System.Windows.Forms.DataGridView.CellParsing><br /><br /> <xref:System.Windows.Forms.DataGridView.CellValidating><br /><br /> <xref:System.Windows.Forms.DataGridView.CellValidated><br /><br /> <xref:System.Windows.Forms.DataGridView.RowValidating><br /><br /> <xref:System.Windows.Forms.DataGridView.RowValidated>|Used by the control to format cell values for display and to parse and validate user input.|  
|<xref:System.Windows.Forms.DataGridView.CellToolTipTextNeeded>|Used by the control to retrieve cell ToolTip text when the <xref:System.Windows.Forms.DataGridView.DataSource%2A> property is set or the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property is `true`.<br /><br /> Cell ToolTips are displayed only when the <xref:System.Windows.Forms.DataGridView.ShowCellToolTips%2A> property value is `true`.|  
|<xref:System.Windows.Forms.DataGridView.CellErrorTextNeeded><br /><br /> <xref:System.Windows.Forms.DataGridView.RowErrorTextNeeded>|Used by the control to retrieve cell or row error text when the <xref:System.Windows.Forms.DataGridView.DataSource%2A> property is set or the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property is `true`.<br /><br /> Call the <xref:System.Windows.Forms.DataGridView.UpdateCellErrorText%2A> method or the <xref:System.Windows.Forms.DataGridView.UpdateRowErrorText%2A> method when you change the cell or row error text to ensure that the current value is displayed in the control.<br /><br /> Cell and row error glyphs are displayed when the <xref:System.Windows.Forms.DataGridView.ShowCellErrors%2A> and <xref:System.Windows.Forms.DataGridView.ShowRowErrors%2A> property values are `true`.|  
|<xref:System.Windows.Forms.DataGridView.CellContextMenuStripNeeded><br /><br /> <xref:System.Windows.Forms.DataGridView.RowContextMenuStripNeeded>|Used by the control to retrieve a cell or row <xref:System.Windows.Forms.ContextMenuStrip> when the control <xref:System.Windows.Forms.DataGridView.DataSource%2A> property is set or the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property is `true`.|  
|<xref:System.Windows.Forms.DataGridView.RowHeightInfoNeeded><br /><br /> <xref:System.Windows.Forms.DataGridView.RowHeightInfoPushed>|Used by the control to retrieve or store row height information in the data cache. Call the <xref:System.Windows.Forms.DataGridView.UpdateRowHeightInfo%2A> method when changing the cached row height information outside of a <xref:System.Windows.Forms.DataGridView.RowHeightInfoPushed> event handler to ensure that the current value is used in the display of the control.|  
  
## Best Practices in Virtual Mode  
 If you are implementing virtual mode in order to work efficiently with large amounts of data, you will also want to ensure that you are working efficiently with the <xref:System.Windows.Forms.DataGridView> control itself. For more information about the efficient use of cell styles, automatic sizing, selections, and row sharing, see [Best Practices for Scaling the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/best-practices-for-scaling-the-windows-forms-datagridview-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.VirtualMode%2A>  
 [Performance Tuning in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/performance-tuning-in-the-windows-forms-datagridview-control.md)  
 [Best Practices for Scaling the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/best-practices-for-scaling-the-windows-forms-datagridview-control.md)  
 [Walkthrough: Implementing Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-wf-datagridview-control.md)  
 [Implementing Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-jit-data-loading-in-the-datagrid.md)
