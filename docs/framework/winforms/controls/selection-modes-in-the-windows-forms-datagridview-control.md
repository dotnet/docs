---
title: "Selection Modes in the Windows Forms DataGridView Control"
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
  - "selection [Windows Forms], modes in DataGridView control"
  - "DataGridView control [Windows Forms], selection mode"
ms.assetid: a3ebfd3d-0525-479d-9d96-d9e017289b36
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Selection Modes in the Windows Forms DataGridView Control
Sometimes you want your application to perform actions based on user selections within a <xref:System.Windows.Forms.DataGridView> control. Depending on the actions, you may want to restrict the kinds of selection that are possible. For example, suppose your application can print a report for the currently selected record. In this case, you may want to configure the <xref:System.Windows.Forms.DataGridView> control so that clicking anywhere within a row always selects the entire row, and so that only one row at a time can be selected.  
  
 You can specify the selections allowed by setting the <xref:System.Windows.Forms.DataGridView.SelectionMode%2A?displayProperty=nameWithType> property to one of the following <xref:System.Windows.Forms.DataGridViewSelectionMode> enumeration values.  
  
|DataGridViewSelectionMode value|Description|  
|-------------------------------------|-----------------|  
|<xref:System.Windows.Forms.DataGridViewSelectionMode.CellSelect>|Clicking a cell selects it. Row and column headers cannot be used for selection.|  
|<xref:System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect>|Clicking a cell selects it. Clicking a column header selects the entire column. Column headers cannot be used for sorting.|  
|<xref:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect>|Clicking a cell or a column header selects the entire column. Column headers cannot be used for sorting.|  
|<xref:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect>|Clicking a cell or a row header selects the entire row.|  
|<xref:System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect>|Default selection mode. Clicking a cell selects it. Clicking a row header selects the entire row.|  
  
> [!NOTE]
>  Changing the selection mode at run time automatically clears the current selection.  
  
 By default, users can select multiple rows, columns, or cells by dragging with the mouse, pressing CTRL or SHIFT while selecting to extend or modify a selection, or clicking the top-left header cell to select all cells in the control. To prevent this behavior, set the <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> property to `false`.  
  
 The <xref:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect> and <xref:System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect> modes allow users to delete rows by selecting them and pressing the DELETE key. Users can delete rows only when the current cell is not in edit mode, the <xref:System.Windows.Forms.DataGridView.AllowUserToDeleteRows%2A> property is set to `true`, and the underlying data source supports user-driven row deletion. Note that these settings do not prevent programmatic row deletion.  
  
## Programmatic Selection  
 The current selection mode restricts the behavior of programmatic selection as well as user selection. You can change the current selection programmatically by setting the `Selected` property of any cells, rows, or columns present in the <xref:System.Windows.Forms.DataGridView> control. You can also select all cells in the control through the <xref:System.Windows.Forms.DataGridView.SelectAll%2A> method, depending on the selection mode. To clear the selection, use the <xref:System.Windows.Forms.DataGridView.ClearSelection%2A> method.  
  
 If the <xref:System.Windows.Forms.DataGridView.MultiSelect%2A> property is set to `true`, you can add <xref:System.Windows.Forms.DataGridView> elements to or remove them from the selection by changing the `Selected` property of the element. Otherwise, setting the `Selected` property to `true` for one element automatically removes other elements from the selection.  
  
 Note that changing the value of the <xref:System.Windows.Forms.DataGridView.CurrentCell%2A> property does not alter the current selection.  
  
 You can retrieve a collection of the currently selected cells, rows, or columns through the <xref:System.Windows.Forms.DataGridView.SelectedCells%2A>, <xref:System.Windows.Forms.DataGridView.SelectedRows%2A>, and <xref:System.Windows.Forms.DataGridView.SelectedColumns%2A> properties of the <xref:System.Windows.Forms.DataGridView> control. Accessing these properties is inefficient when every cell in the control is selected. To avoid a performance penalty in this case, use the <xref:System.Windows.Forms.DataGridView.AreAllCellsSelected%2A> method first. Additionally, accessing these collections to determine the number of selected cells, rows, or columns can be inefficient. Instead, you should use the <xref:System.Windows.Forms.DataGridView.GetCellCount%2A>, <xref:System.Windows.Forms.DataGridViewRowCollection.GetRowCount%2A>, or <xref:System.Windows.Forms.DataGridViewColumnCollection.GetColumnCount%2A> method, passing in the <xref:System.Windows.Forms.DataGridViewElementStates.Selected> value.  
  
> [!TIP]
>  Example code that demonstrates the programmatic use of selected cells can be found in the <xref:System.Windows.Forms.DataGridView> class overview.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.MultiSelect%2A>  
 <xref:System.Windows.Forms.DataGridView.SelectionMode%2A>  
 <xref:System.Windows.Forms.DataGridViewSelectionMode>  
 [Selection and Clipboard Use with the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/selection-and-clipboard-use-with-the-windows-forms-datagridview-control.md)  
 [How to: Set the Selection Mode of the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-set-the-selection-mode-of-the-windows-forms-datagridview-control.md)
