---
title: "Column Sort Modes in the Windows Forms DataGridView Control"
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
  - "data grids [Windows Forms], sort modes"
  - "DataGridView control [Windows Forms], sort mode"
ms.assetid: 43715887-2df9-4da7-bcf1-b9c7c842b2bf
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Column Sort Modes in the Windows Forms DataGridView Control
<xref:System.Windows.Forms.DataGridView> columns have three sort modes. The sort mode for each column is specified through the <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A> property of the column, which can be set to one of the following <xref:System.Windows.Forms.DataGridViewColumnSortMode> enumeration values.  
  
|`DataGridViewColumnSortMode` value|Description|  
|----------------------------------------|-----------------|  
|<xref:System.Windows.Forms.DataGridViewColumnSortMode.Automatic>|Default for text box columns. Unless column headers are used for selection, clicking the column header automatically sorts the <xref:System.Windows.Forms.DataGridView> by this column and displays a glyph indicating the sort order.|  
|<xref:System.Windows.Forms.DataGridViewColumnSortMode.NotSortable>|Default for non–text box columns. You can sort this column programmatically; however, it is not intended for sorting, so no space is reserved for the sorting glyph.|  
|<xref:System.Windows.Forms.DataGridViewColumnSortMode.Programmatic>|You can sort this column programmatically, and space is reserved for the sorting glyph.|  
  
 You might want to change the sort mode for a column that defaults to <xref:System.Windows.Forms.DataGridViewColumnSortMode.NotSortable> if it contains values that can be meaningfully ordered. For example, if you have a database column containing numbers that represent item states, you can display these numbers as corresponding icons by binding an image column to the database column. You can then change the numerical cell values into image display values in a handler for the <xref:System.Windows.Forms.DataGridView.CellFormatting?displayProperty=nameWithType> event. In this case, setting the <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A> property to <xref:System.Windows.Forms.DataGridViewColumnSortMode.Automatic> will enable your users to sort the column. Automatic sorting will enable your users to group items that have the same state even if the states corresponding to the numbers do not have a natural sequence. Check box columns are another example where automatic sorting is useful for grouping items in the same state.  
  
 You can sort a <xref:System.Windows.Forms.DataGridView> programmatically by the values in any column or in multiple columns, regardless of the <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A> settings. Programmatic sorting is useful when you want to provide your own user interface (UI) for sorting or when you want to implement custom sorting. Providing your own sorting UI is useful, for example, when you set the <xref:System.Windows.Forms.DataGridView> selection mode to enable column header selection. In this case, although the column headers cannot be used for sorting, you still want the headers to display the appropriate sorting glyph, so you would set the <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A> property to <xref:System.Windows.Forms.DataGridViewColumnSortMode.Programmatic>.  
  
 Columns set to programmatic sort mode do not automatically display a sorting glyph. For these columns, you must display the glyph yourself by setting the <xref:System.Windows.Forms.DataGridViewColumnHeaderCell.SortGlyphDirection%2A?displayProperty=nameWithType> property. This is necessary if you want flexibility in custom sorting. For example, if you sort the <xref:System.Windows.Forms.DataGridView> by multiple columns, you might want to display multiple sorting glyphs or no sorting glyph.  
  
 Although you can programmatically sort a <xref:System.Windows.Forms.DataGridView> by any column, some columns, such as button columns, might not contain values that can be meaningfully ordered. For these columns, a <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A> property setting of <xref:System.Windows.Forms.DataGridViewColumnSortMode.NotSortable> indicates that it will never be used for sorting, so there is no need to reserve space in the header for the sorting glyph.  
  
 When a <xref:System.Windows.Forms.DataGridView> is sorted, you can determine both the sort column and the sort order by checking the values of the <xref:System.Windows.Forms.DataGridView.SortedColumn%2A> and <xref:System.Windows.Forms.DataGridView.SortOrder%2A> properties. These values are not meaningful after a custom sorting operation. For more information about custom sorting, see the Custom Sorting section later in this topic.  
  
 When a <xref:System.Windows.Forms.DataGridView> control containing both bound and unbound columns is sorted, the values in the unbound columns cannot be maintained automatically. To maintain these values, you must implement virtual mode by setting the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property to `true` and handling the <xref:System.Windows.Forms.DataGridView.CellValueNeeded> and <xref:System.Windows.Forms.DataGridView.CellValuePushed> events. For more information, see [How to: Implement Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-implement-virtual-mode-in-the-windows-forms-datagridview-control.md). Sorting by unbound columns in bound mode is not supported.  
  
## Programmatic Sorting  
 You can sort a <xref:System.Windows.Forms.DataGridView> programmatically by calling its <xref:System.Windows.Forms.DataGridView.Sort%2A> method.  
  
 The `Sort(DataGridViewColumn,ListSortDirection)` overload of the <xref:System.Windows.Forms.DataGridView.Sort%2A> method takes a <xref:System.Windows.Forms.DataGridViewColumn> and a <xref:System.ComponentModel.ListSortDirection> enumeration value as parameters. This overload is useful when sorting by columns with values that can be meaningfully ordered, but which you do not want to configure for automatic sorting. When you call this overload and pass in a column with a <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A> property value of <xref:System.Windows.Forms.DataGridViewColumnSortMode.Automatic?displayProperty=nameWithType>, the <xref:System.Windows.Forms.DataGridView.SortedColumn%2A> and <xref:System.Windows.Forms.DataGridView.SortOrder%2A> properties are set automatically and the appropriate sorting glyph appears in the column header.  
  
> [!NOTE]
>  When the <xref:System.Windows.Forms.DataGridView> control is bound to an external data source by setting the <xref:System.Windows.Forms.DataGridView.DataSource%2A> property, the `Sort(DataGridViewColumn,ListSortDirection)` method overload does not work for unbound columns. Additionally, when the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property is `true`, you can call this overload only for bound columns. To determine whether a column is data-bound, check the <xref:System.Windows.Forms.DataGridViewColumn.IsDataBound%2A> property value. Sorting unbound columns in bound mode is not supported.  
  
## Custom Sorting  
 You can customize <xref:System.Windows.Forms.DataGridView> by using the `Sort(IComparer)` overload of the <xref:System.Windows.Forms.DataGridView.Sort%2A> method or by handling the <xref:System.Windows.Forms.DataGridView.SortCompare> event.  
  
 The `Sort(IComparer)` method overload takes an instance of a class that implements the <xref:System.Collections.IComparer> interface as a parameter. This overload is useful when you want to provide custom sorting; for example, when the values in a column do not have a natural sort order or when the natural sort order is inappropriate. In this case, you cannot use automatic sorting, but you might still want your users to sort by clicking the column headers. You can call this overload in a handler for the <xref:System.Windows.Forms.DataGridView.ColumnHeaderMouseClick> event if you do not use column headers for selection.  
  
> [!NOTE]
>  The `Sort(IComparer)` method overload works only when the <xref:System.Windows.Forms.DataGridView> control is not bound to an external data source and the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property value is `false`. To customize sorting for columns bound to an external data source, you must use the sorting operations provided by the data source. In virtual mode, you must provide your own sorting operations for unbound columns.  
  
 To use the `Sort(IComparer)` method overload, you must create your own class that implements the <xref:System.Collections.IComparer> interface. This interface requires your class to implement the <xref:System.Collections.IComparer.Compare%2A?displayProperty=nameWithType> method, to which the <xref:System.Windows.Forms.DataGridView> passes <xref:System.Windows.Forms.DataGridViewRow> objects as input when the `Sort(IComparer)` method overload is called. With this, you can calculate the correct row ordering based on the values in any column.  
  
 The `Sort(IComparer)` method overload does not set the <xref:System.Windows.Forms.DataGridView.SortedColumn%2A> and <xref:System.Windows.Forms.DataGridView.SortOrder%2A> properties, so you must always set the <xref:System.Windows.Forms.DataGridViewColumnHeaderCell.SortGlyphDirection%2A?displayProperty=nameWithType> property to display the sorting glyph.  
  
 As an alternative to the `Sort(IComparer)` method overload, you can provide custom sorting by implementing a handler for the <xref:System.Windows.Forms.DataGridView.SortCompare> event. This event occurs when users click the headers of columns configured for automatic sorting or when you call the `Sort(DataGridViewColumn,ListSortDirection)` overload of the <xref:System.Windows.Forms.DataGridView.Sort%2A> method. The event occurs for each pair of rows in the control, enabling you to calculate their correct order.  
  
> [!NOTE]
>  The <xref:System.Windows.Forms.DataGridView.SortCompare> event does not occur when the <xref:System.Windows.Forms.DataGridView.DataSource%2A> property is set or when the <xref:System.Windows.Forms.DataGridView.VirtualMode%2A> property value is `true`.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.Sort%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.SortedColumn%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.SortOrder%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.SortMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumnHeaderCell.SortGlyphDirection%2A?displayProperty=nameWithType>  
 [Sorting Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/sorting-data-in-the-windows-forms-datagridview-control.md)  
 [How to: Set the Sort Modes for Columns in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/set-the-sort-modes-for-columns-wf-datagridview-control.md)  
 [How to: Customize Sorting in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-customize-sorting-in-the-windows-forms-datagridview-control.md)
