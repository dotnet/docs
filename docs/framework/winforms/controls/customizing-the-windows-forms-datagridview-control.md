---
title: "Customizing the Windows Forms DataGridView Control"
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
  - "data grids [Windows Forms], customization"
  - "DataGridView control [Windows Forms], customization"
ms.assetid: 01ea5d4c-a736-4596-b0e9-a67a1b86e15f
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Customizing the Windows Forms DataGridView Control
The `DataGridView` control provides several properties that you can use to adjust the appearance and basic behavior (look and feel) of its cells, rows, and columns. If you have special needs that go beyond the capabilities of the <xref:System.Windows.Forms.DataGridViewCellStyle> class, however, you can also implement owner drawing for the control or extend its capabilities by creating custom cells, columns, and rows.  
  
 To paint cells and rows yourself, you can handle various `DataGridView` painting events. To modify existing functionality or provide new functionality, you can create your own types derived from the existing `DataGridViewCell`, `DataGridViewColumn`, and `DataGridViewRow` types. You can also provide new editing capabilities by creating derived types that display a control of your choosing when a cell is in edit mode.  
  
## In This Section  
 [How to: Customize the Appearance of Cells in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customize-the-appearance-of-cells-in-the-datagrid.md)  
 Describes how to handle the <xref:System.Windows.Forms.DataGridView.CellPainting> event in order to paint cells manually.  
  
 [How to: Customize the Appearance of Rows in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customize-the-appearance-of-rows-in-the-datagrid.md)  
 Describes how to handle the <xref:System.Windows.Forms.DataGridView.RowPrePaint> and <xref:System.Windows.Forms.DataGridView.RowPostPaint> events in order to paint rows with a custom, gradient background and content that spans multiple columns.  
  
 [How to: Customize Cells and Columns in the Windows Forms DataGridView Control by Extending Their Behavior and Appearance](../../../../docs/framework/winforms/controls/customize-cells-and-columns-in-the-datagrid-by-extending-behavior.md)  
 Describes how to create custom types derived from `DataGridViewCell` and `DataGridViewColumn` in order to highlight cells when the mouse pointer rests on them.  
  
 [How to: Disable Buttons in a Button Column in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/disable-buttons-in-a-button-column-in-the-datagrid.md)  
 Describes how to create custom types derived from <xref:System.Windows.Forms.DataGridViewButtonCell> and <xref:System.Windows.Forms.DataGridViewButtonColumn> in order to display disabled buttons in a button column.  
  
 [How to: Host Controls in Windows Forms DataGridView Cells](../../../../docs/framework/winforms/controls/how-to-host-controls-in-windows-forms-datagridview-cells.md)  
 Describes how to implement the `IDataGridViewEditingControl` interface and create custom types derived from `DataGridViewCell` and `DataGridViewColumn` in order to display a <xref:System.Windows.Forms.DateTimePicker> control when a cell is in edit mode.  
  
## Reference  
 <xref:System.Windows.Forms.DataGridView>  
 Provides reference documentation for the <xref:System.Windows.Forms.DataGridView> control.  
  
 <xref:System.Windows.Forms.DataGridViewCell>  
 Provides reference documentation for the <xref:System.Windows.Forms.DataGridViewCell> class.  
  
 <xref:System.Windows.Forms.DataGridViewRow>  
 Provides reference documentation for the <xref:System.Windows.Forms.DataGridViewRow> class.  
  
 <xref:System.Windows.Forms.DataGridViewColumn>  
 Provides reference documentation for the <xref:System.Windows.Forms.DataGridViewColumn> class.  
  
 <xref:System.Windows.Forms.IDataGridViewEditingControl>  
 Provides reference documentation for the <xref:System.Windows.Forms.IDataGridViewEditingControl> interface.  
  
## Related Sections  
 [Basic Formatting and Styling in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/basic-formatting-and-styling-in-the-windows-forms-datagridview-control.md)  
 Provides topics that describe how to modify the basic appearance of the control and the display formatting of cell data.  
  
## See Also  
 [DataGridView Control](../../../../docs/framework/winforms/controls/datagridview-control-windows-forms.md)  
 [Column Types in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/column-types-in-the-windows-forms-datagridview-control.md)
