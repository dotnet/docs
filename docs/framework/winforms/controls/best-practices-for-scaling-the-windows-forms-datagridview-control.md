---
title: "Best Practices for Scaling the Windows Forms DataGridView Control"
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
  - "DataGridView control [Windows Forms], row sharing"
  - "data grids [Windows Forms], best practices"
  - "DataGridView control [Windows Forms], shared rows"
  - "DataGridView control [Windows Forms], best practices"
  - "best practices [Windows Forms], dataGridView control"
  - "DataGridView control [Windows Forms], scaling"
ms.assetid: 8321a8a6-6340-4fd1-b475-fa090b905aaf
caps.latest.revision: 31
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Best Practices for Scaling the Windows Forms DataGridView Control
The <xref:System.Windows.Forms.DataGridView> control is designed to provide maximum scalability. If you need to display large amounts of data, you should follow the guidelines described in this topic to avoid consuming large amounts of memory or degrading the responsiveness of the user interface (UI). This topic discusses the following issues:  
  
-   Using cell styles efficiently  
  
-   Using shortcut menus efficiently  
  
-   Using automatic resizing efficiently  
  
-   Using the selected cells, rows, and columns collections efficiently  
  
-   Using shared rows  
  
-   Preventing rows from becoming unshared  
  
 If you have special performance needs, you can implement virtual mode and provide your own data management operations. For more information, see [Data Display Modes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-display-modes-in-the-windows-forms-datagridview-control.md).  
  
## Using Cell Styles Efficiently  
 Each cell, row, and column can have its own style information. Style information is stored in <xref:System.Windows.Forms.DataGridViewCellStyle> objects. Creating cell style objects for many individual <xref:System.Windows.Forms.DataGridView> elements can be inefficient, especially when working with large amounts of data. To avoid a performance impact, use the following guidelines:  
  
-   Avoid setting cell style properties for individual <xref:System.Windows.Forms.DataGridViewCell> or <xref:System.Windows.Forms.DataGridViewRow> objects. This includes the row object specified by the <xref:System.Windows.Forms.DataGridView.RowTemplate%2A> property. Each new row that is cloned from the row template will receive its own copy of the template's cell style object. For maximum scalability, set cell style properties at the <xref:System.Windows.Forms.DataGridView> level. For example, set the <xref:System.Windows.Forms.DataGridView.DefaultCellStyle%2A?displayProperty=nameWithType> property rather than the <xref:System.Windows.Forms.DataGridViewCell.Style%2A?displayProperty=nameWithType> property.  
  
-   If some cells require formatting other than default formatting, use the same <xref:System.Windows.Forms.DataGridViewCellStyle> instance across groups of cells, rows, or columns. Avoid directly setting properties of type <xref:System.Windows.Forms.DataGridViewCellStyle> on individual cells, rows, and columns. For an example of cell style sharing, see [How to: Set Default Cell Styles for the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-set-default-cell-styles-for-the-windows-forms-datagridview-control.md). You can also avoid a performance penalty when setting cell styles individually by handling the <xref:System.Windows.Forms.DataGridView.CellFormatting> event handler. For an example, see [How to: Customize Data Formatting in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-customize-data-formatting-in-the-windows-forms-datagridview-control.md).  
  
-   When determining a cell's style, use the <xref:System.Windows.Forms.DataGridViewCell.InheritedStyle%2A?displayProperty=nameWithType> property rather than the <xref:System.Windows.Forms.DataGridViewCell.Style%2A?displayProperty=nameWithType> property. Accessing the <xref:System.Windows.Forms.DataGridViewCell.Style%2A> property creates a new instance of the <xref:System.Windows.Forms.DataGridViewCellStyle> class if the property has not already been used. Additionally, this object might not contain the complete style information for the cell if some styles are inherited from the row, column, or control. For more information about cell style inheritance, see [Cell Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/cell-styles-in-the-windows-forms-datagridview-control.md).  
  
## Using Shortcut Menus Efficiently  
 Each cell, row, and column can have its own shortcut menu. Shortcut menus in the <xref:System.Windows.Forms.DataGridView> control are represented by <xref:System.Windows.Forms.ContextMenuStrip> controls. Just as with cell style objects, creating shortcut menus for many individual <xref:System.Windows.Forms.DataGridView> elements will negatively impact performance. To avoid this penalty, use the following guidelines:  
  
-   Avoid creating shortcut menus for individual cells and rows. This includes the row template, which is cloned along with its shortcut menu when new rows are added to the control. For maximum scalability, use only the control's <xref:System.Windows.Forms.Control.ContextMenuStrip%2A> property to specify a single shortcut menu for the entire control.  
  
-   If you require multiple shortcut menus for multiple rows or cells, handle the <xref:System.Windows.Forms.DataGridView.CellContextMenuStripNeeded> or <xref:System.Windows.Forms.DataGridView.RowContextMenuStripNeeded> events. These events let you manage the shortcut menu objects yourself, allowing you to tune performance.  
  
## Using Automatic Resizing Efficiently  
 Rows, columns, and headers can be automatically resized as cell content changes so that the entire contents of cells are displayed without clipping. Changing sizing modes can also resize rows, columns, and headers. To determine the correct size, the <xref:System.Windows.Forms.DataGridView> control must examine the value of each cell that it must accommodate. When working with large data sets, this analysis can negatively impact the performance of the control when automatic resizing occurs. To avoid performance penalties, use the following guidelines:  
  
-   Avoid using automatic sizing on a <xref:System.Windows.Forms.DataGridView> control with a large set of rows. If you do use automatic sizing, only resize based on the displayed rows. Use only the displayed rows in virtual mode as well.  
  
    -   For rows and columns, use the `DisplayedCells` or `DisplayedCellsExceptHeaders` field of the <xref:System.Windows.Forms.DataGridViewAutoSizeRowsMode>, <xref:System.Windows.Forms.DataGridViewAutoSizeColumnsMode>, and <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode> enumerations.  
  
    -   For row headers, use the <xref:System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders> or <xref:System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader> field of the <xref:System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode> enumeration.  
  
-   For maximum scalability, turn off automatic sizing and use programmatic resizing.  
  
 For more information, see [Sizing Options in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/sizing-options-in-the-windows-forms-datagridview-control.md).  
  
## Using the Selected Cells, Rows, and Columns Collections Efficiently  
 The <xref:System.Windows.Forms.DataGridView.SelectedCells%2A> collection does not perform efficiently with large selections. The <xref:System.Windows.Forms.DataGridView.SelectedRows%2A> and <xref:System.Windows.Forms.DataGridView.SelectedColumns%2A> collections can also be inefficient, although to a lesser degree because there are many fewer rows than cells in a typical <xref:System.Windows.Forms.DataGridView> control, and many fewer columns than rows. To avoid performance penalties when working with these collections, use the following guidelines:  
  
-   To determine whether all the cells in the <xref:System.Windows.Forms.DataGridView> have been selected before you access the contents of the <xref:System.Windows.Forms.DataGridView.SelectedCells%2A> collection, check the return value of the <xref:System.Windows.Forms.DataGridView.AreAllCellsSelected%2A> method. Note, however, that this method can cause rows to become unshared. For more information, see the next section.  
  
-   Avoid using the <xref:System.Collections.ICollection.Count%2A> property of the <xref:System.Windows.Forms.DataGridViewSelectedCellCollection?displayProperty=nameWithType> to determine the number of selected cells. Instead, use the <xref:System.Windows.Forms.DataGridView.GetCellCount%2A?displayProperty=nameWithType> method and pass in the <xref:System.Windows.Forms.DataGridViewElementStates.Selected?displayProperty=nameWithType> value. Similarly, use the <xref:System.Windows.Forms.DataGridViewRowCollection.GetRowCount%2A?displayProperty=nameWithType> and <xref:System.Windows.Forms.DataGridViewColumnCollection.GetColumnCount%2A?displayProperty=nameWithType> methods to determine the number of selected elements, rather than accessing the selected row and column collections.  
  
-   Avoid cell-based selection modes. Instead, set the <xref:System.Windows.Forms.DataGridView.SelectionMode%2A?displayProperty=nameWithType> property to <xref:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect?displayProperty=nameWithType> or <xref:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect?displayProperty=nameWithType>.  
  
## Using Shared Rows  
 Efficient memory use is achieved in the <xref:System.Windows.Forms.DataGridView> control through shared rows. Rows will share as much information about their appearance and behavior as possible by sharing instances of the <xref:System.Windows.Forms.DataGridViewRow> class.  
  
 While sharing row instances saves memory, rows can easily become unshared. For example, whenever a user interacts directly with a cell, its row becomes unshared. Because this cannot be avoided, the guidelines in this topic are useful only when working with very large amounts of data and only when users will interact with a relatively small part of the data each time your program is run.  
  
 A row cannot be shared in an unbound <xref:System.Windows.Forms.DataGridView> control if any of its cells contain values. When the <xref:System.Windows.Forms.DataGridView> control is bound to an external data source or when you implement virtual mode and provide your own data source, the cell values are stored outside the control rather than in cell objects, allowing the rows to be shared.  
  
 A row object can only be shared if the state of all its cells can be determined from the state of the row and the states of the columns containing the cells. If you change the state of a cell so that it can no longer be deduced from the state of its row and column, the row cannot be shared.  
  
 For example, a row cannot be shared in any of the following situations:  
  
-   The row contains a single selected cell that is not in a selected column.  
  
-   The row contains a cell with its <xref:System.Windows.Forms.DataGridViewCell.ToolTipText%2A> or <xref:System.Windows.Forms.DataGridViewCell.ContextMenuStrip%2A> properties set.  
  
-   The row contains a <xref:System.Windows.Forms.DataGridViewComboBoxCell> with its <xref:System.Windows.Forms.DataGridViewComboBoxCell.Items%2A> property set.  
  
 In bound mode or virtual mode, you can provide ToolTips and shortcut menus for individual cells by handling the <xref:System.Windows.Forms.DataGridView.CellToolTipTextNeeded> and <xref:System.Windows.Forms.DataGridView.CellContextMenuStripNeeded> events.  
  
 The <xref:System.Windows.Forms.DataGridView> control will automatically attempt to use shared rows whenever rows are added to the <xref:System.Windows.Forms.DataGridViewRowCollection>. Use the following guidelines to ensure that rows are shared:  
  
-   Avoid calling the `Add(Object[])` overload of the <xref:System.Windows.Forms.DataGridViewRowCollection.Add%2A> method and the `Insert(Object[])` overload of the <xref:System.Windows.Forms.DataGridViewRowCollection.Insert%2A> method of the <xref:System.Windows.Forms.DataGridView.Rows%2A?displayProperty=nameWithType> collection. These overloads automatically create unshared rows.  
  
-   Be sure that the row specified in the <xref:System.Windows.Forms.DataGridView.RowTemplate%2A?displayProperty=nameWithType> property can be shared in the following cases:  
  
    -   When calling the `Add()` or `Add(Int32)` overloads of the <xref:System.Windows.Forms.DataGridViewRowCollection.Add%2A> method or the `Insert(Int32,Int32)` overload of the <xref:System.Windows.Forms.DataGridViewRowCollection.Insert%2A> method of the <xref:System.Windows.Forms.DataGridView.Rows%2A?displayProperty=nameWithType> collection.  
  
    -   When increasing the value of the <xref:System.Windows.Forms.DataGridView.RowCount%2A?displayProperty=nameWithType> property.  
  
    -   When setting the <xref:System.Windows.Forms.DataGridView.DataSource%2A?displayProperty=nameWithType> property.  
  
-   Be sure that the row indicated by the `indexSource` parameter can be shared when calling the <xref:System.Windows.Forms.DataGridViewRowCollection.AddCopy%2A>, <xref:System.Windows.Forms.DataGridViewRowCollection.AddCopies%2A>, <xref:System.Windows.Forms.DataGridViewRowCollection.InsertCopy%2A>, and <xref:System.Windows.Forms.DataGridViewRowCollection.InsertCopies%2A> methods of the <xref:System.Windows.Forms.DataGridView.Rows%2A?displayProperty=nameWithType> collection.  
  
-   Be sure that the specified row or rows can be shared when calling the `Add(DataGridViewRow)` overload of the <xref:System.Windows.Forms.DataGridViewRowCollection.Add%2A> method, the <xref:System.Windows.Forms.DataGridViewRowCollection.AddRange%2A> method, the `Insert(Int32,DataGridViewRow)` overload of the <xref:System.Windows.Forms.DataGridViewRowCollection.Insert%2A> method, and the <xref:System.Windows.Forms.DataGridViewRowCollection.InsertRange%2A> method of the <xref:System.Windows.Forms.DataGridView.Rows%2A?displayProperty=nameWithType> collection.  
  
 To determine whether a row is shared, use the <xref:System.Windows.Forms.DataGridViewRowCollection.SharedRow%2A?displayProperty=nameWithType> method to retrieve the row object, and then check the object's <xref:System.Windows.Forms.DataGridViewBand.Index%2A> property. Shared rows always have an <xref:System.Windows.Forms.DataGridViewBand.Index%2A> property value of –1.  
  
## Preventing Rows from Becoming Unshared  
 Shared rows can become unshared as a result of code or user action. To avoid a performance impact, you should avoid causing rows to become unshared. During application development, you can handle the <xref:System.Windows.Forms.DataGridView.RowUnshared> event to determine when rows become unshared. This is useful when debugging row-sharing problems.  
  
 To prevent rows from becoming unshared, use the following guidelines:  
  
-   Avoid indexing the <xref:System.Windows.Forms.DataGridView.Rows%2A> collection or iterating through it with a `foreach` loop. You will not typically need to access rows directly. <xref:System.Windows.Forms.DataGridView> methods that operate on rows take row index arguments rather than row instances. Additionally, handlers for row-related events receive event argument objects with row properties that you can use to manipulate rows without causing them to become unshared.  
  
-   If you need to access a row object, use the <xref:System.Windows.Forms.DataGridViewRowCollection.SharedRow%2A?displayProperty=nameWithType> method and pass in the row's actual index. Note, however, that modifying a shared row object retrieved through this method will modify all the rows that share this object. The row for new records is not shared with other rows, however, so it will not be affected when you modify any other row. Note also that different rows represented by a shared row may have different shortcut menus. To retrieve the correct shortcut menu from a shared row instance, use the <xref:System.Windows.Forms.DataGridViewRow.GetContextMenuStrip%2A> method and pass in the row's actual index. If you access the shared row's <xref:System.Windows.Forms.DataGridViewRow.ContextMenuStrip%2A> property instead, it will use the shared row index of -1 and will not retrieve the correct shortcut menu.  
  
-   Avoid indexing the <xref:System.Windows.Forms.DataGridViewRow.Cells%2A?displayProperty=nameWithType> collection. Accessing a cell directly will cause its parent row to become unshared, instantiating a new <xref:System.Windows.Forms.DataGridViewRow>. Handlers for cell-related events receive event argument objects with cell properties that you can use to manipulate cells without causing rows to become unshared. You can also use the <xref:System.Windows.Forms.DataGridView.CurrentCellAddress%2A> property to retrieve the row and column indexes of the current cell without accessing the cell directly.  
  
-   Avoid cell-based selection modes. These modes cause rows to become unshared. Instead, set the <xref:System.Windows.Forms.DataGridView.SelectionMode%2A?displayProperty=nameWithType> property to <xref:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect?displayProperty=nameWithType> or <xref:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect?displayProperty=nameWithType>.  
  
-   Do not handle the <xref:System.Windows.Forms.DataGridViewRowCollection.CollectionChanged?displayProperty=nameWithType> or <xref:System.Windows.Forms.DataGridView.RowStateChanged?displayProperty=nameWithType> events. These events cause rows to become unshared. Also, do not call the <xref:System.Windows.Forms.DataGridViewRowCollection.OnCollectionChanged%2A?displayProperty=nameWithType> or <xref:System.Windows.Forms.DataGridView.OnRowStateChanged%2A?displayProperty=nameWithType> methods, which raise these events.  
  
-   Do not access the <xref:System.Windows.Forms.DataGridView.SelectedCells%2A?displayProperty=nameWithType> collection when the <xref:System.Windows.Forms.DataGridView.SelectionMode%2A?displayProperty=nameWithType> property value is <xref:System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect>, <xref:System.Windows.Forms.DataGridViewSelectionMode.ColumnHeaderSelect>, <xref:System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect>, or <xref:System.Windows.Forms.DataGridViewSelectionMode.RowHeaderSelect>. This causes all selected rows to become unshared.  
  
-   Do not call the <xref:System.Windows.Forms.DataGridView.AreAllCellsSelected%2A?displayProperty=nameWithType> method. This method can cause rows to become unshared.  
  
-   Do not call the <xref:System.Windows.Forms.DataGridView.SelectAll%2A?displayProperty=nameWithType> method when the <xref:System.Windows.Forms.DataGridView.SelectionMode%2A?displayProperty=nameWithType> property value is <xref:System.Windows.Forms.DataGridViewSelectionMode.CellSelect>. This causes all rows to become unshared.  
  
-   Do not set the <xref:System.Windows.Forms.DataGridViewCell.ReadOnly%2A> or <xref:System.Windows.Forms.DataGridViewCell.Selected%2A> property of a cell to `false` when the corresponding property in its column is set to `true`. This causes all rows to become unshared.  
  
-   Do not access the <xref:System.Windows.Forms.DataGridViewRowCollection.List%2A?displayProperty=nameWithType> property. This causes all rows to become unshared.  
  
-   Do not call the `Sort(IComparer)` overload of the <xref:System.Windows.Forms.DataGridView.Sort%2A> method. Sorting with a custom comparer causes all rows to become unshared.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 [Performance Tuning in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/performance-tuning-in-the-windows-forms-datagridview-control.md)  
 [Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/virtual-mode-in-the-windows-forms-datagridview-control.md)  
 [Data Display Modes in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-display-modes-in-the-windows-forms-datagridview-control.md)  
 [Cell Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/cell-styles-in-the-windows-forms-datagridview-control.md)  
 [How to: Set Default Cell Styles for the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-set-default-cell-styles-for-the-windows-forms-datagridview-control.md)  
 [Sizing Options in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/sizing-options-in-the-windows-forms-datagridview-control.md)
