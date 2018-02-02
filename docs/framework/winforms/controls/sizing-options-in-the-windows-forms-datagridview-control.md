---
title: "Sizing Options in the Windows Forms DataGridView Control"
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
  - "DataGridView control [Windows Forms], row sizing"
  - "data grids [Windows Forms], column sizing"
  - "DataGridView control [Windows Forms], column sizing"
  - "DataGridView control [Windows Forms], sizing options"
  - "data grids [Windows Forms], row sizing"
  - "data grids [Windows Forms], sizing options"
ms.assetid: a5620a9c-0d06-41e3-8934-c25ddb16c9e6
caps.latest.revision: 29
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Sizing Options in the Windows Forms DataGridView Control
<xref:System.Windows.Forms.DataGridView> rows, columns, and headers can change size as a result of many different occurrences. The following table shows these occurrences.  
  
|Occurrence|Description|  
|----------------|-----------------|  
|User resize|Users can make size adjustments by dragging or double-clicking row, column, or header dividers.|  
|Control resize|In column fill mode, column widths change when the control width changes; for example, when the control is docked to its parent form and the user resizes the form.|  
|Cell value change|In content-based automatic sizing modes, sizes change to fit new display values.|  
|Method call|Programmatic content-based resizing lets you make opportunistic size adjustments based on cell values at the time of the method call.|  
|Property setting|You can also set specific height and width values.|  
  
 By default, user resizing is enabled, automatic sizing is disabled, and cell values that are wider than their columns are clipped.  
  
 The following table shows scenarios that you can use to adjust the default behavior or to use specific sizing options to achieve particular effects.  
  
|Scenario|Implementation|  
|--------------|--------------------|  
|Use column fill mode for displaying similarly sized data in a relatively small number of columns that occupy the entire width of the control without displaying the horizontal scroll bar.|Set the <xref:System.Windows.Forms.DataGridView.AutoSizeColumnsMode%2A> property to <xref:System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill>.|  
|Use column fill mode with display values of varying sizes.|Set the <xref:System.Windows.Forms.DataGridView.AutoSizeColumnsMode%2A> property to <xref:System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill>. Initialize relative column widths by setting the column <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> properties or by calling the control <xref:System.Windows.Forms.DataGridView.AutoResizeColumns%2A> method after filling the control with data.|  
|Use column fill mode with values of varying importance.|Set the <xref:System.Windows.Forms.DataGridView.AutoSizeColumnsMode%2A> property to <xref:System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill>. Set large <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A> values for columns that must always display some of their data or use a sizing option other than fill mode for specific columns.|  
|Use column fill mode to avoid displaying the control background.|Set the <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A> property of the last column to <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill> and use other sizing options for the other columns. If the other columns use too much of the available space, set the <xref:System.Windows.Forms.DataGridViewColumn.MinimumWidth%2A> property of the last column.|  
|Display a fixed-width column, such as an icon or ID column.|Set <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A> to <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode.None> and <xref:System.Windows.Forms.DataGridViewColumn.Resizable%2A> to <xref:System.Windows.Forms.DataGridViewTriState.False> for the column. Initialize its width by setting the <xref:System.Windows.Forms.DataGridViewColumn.Width%2A> property or by calling the control <xref:System.Windows.Forms.DataGridView.AutoResizeColumn%2A> method after filling the control with data.|  
|Adjust sizes automatically whenever cell contents change to avoid clipping and to optimize the use of space.|Set an automatic sizing property to a value that represents a content-based sizing mode. To avoid a performance penalty when working with large amounts of data, use a sizing mode that calculates displayed rows only.|  
|Adjust sizes to fit values in displayed rows to avoid performance penalties when working with many rows.|Use the appropriate sizing-mode enumeration values with automatic or programmatic resizing. To adjust sizes to fit values in newly displayed rows while scrolling, call a resizing method in a <xref:System.Windows.Forms.DataGridView.Scroll> event handler. To customize user double-click resizing so that only values in displayed rows determine the new sizes, call a resizing method in a <xref:System.Windows.Forms.DataGridView.RowDividerDoubleClick> or <xref:System.Windows.Forms.DataGridView.ColumnDividerDoubleClick> event handler.|  
|Adjust sizes to fit cell contents only at specific times to avoid performance penalties or to enable user resizing.|Call a content-based resizing method in an event handler. For example, use the <xref:System.Windows.Forms.DataGridView.DataBindingComplete> event to initialize sizes after binding, and handle the <xref:System.Windows.Forms.DataGridView.CellValidated> or <xref:System.Windows.Forms.DataGridView.CellValueChanged> event to adjust sizes to compensate for user edits or changes in a bound data source.|  
|Adjust row heights for multiline cell contents.|Ensure that column widths are appropriate for displaying paragraphs of text and use automatic or programmatic content-based row sizing to adjust the heights. Also ensure that cells with multiline content are displayed using a <xref:System.Windows.Forms.DataGridViewCellStyle.WrapMode%2A> cell style value of <xref:System.Windows.Forms.DataGridViewTriState.True>.<br /><br /> Typically, you will use an automatic column sizing mode to maintain column widths or set them to specific widths before row heights are adjusted.|  
  
## Resizing with the Mouse  
 By default, users can resize rows, columns, and headers that do not use an automatic sizing mode based on cell values. To prevent users from resizing with other modes, such as column fill mode, set one or more of the following <xref:System.Windows.Forms.DataGridView> properties:  
  
-   <xref:System.Windows.Forms.DataGridView.AllowUserToResizeColumns%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.AllowUserToResizeRows%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.ColumnHeadersHeightSizeMode%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.RowHeadersWidthSizeMode%2A>  
  
 You can also prevent users from resizing individual rows or columns by setting their <xref:System.Windows.Forms.DataGridViewBand.Resizable%2A> properties. By default, the <xref:System.Windows.Forms.DataGridViewBand.Resizable%2A> property value is based on the <xref:System.Windows.Forms.DataGridView.AllowUserToResizeColumns%2A> property value for columns and the <xref:System.Windows.Forms.DataGridView.AllowUserToResizeRows%2A> property value for rows. If you explicitly set <xref:System.Windows.Forms.DataGridViewBand.Resizable%2A> to <xref:System.Windows.Forms.DataGridViewTriState.True> or <xref:System.Windows.Forms.DataGridViewTriState.False>, however, the specified value overrides the control value is for that row or column. Set <xref:System.Windows.Forms.DataGridViewBand.Resizable%2A> to <xref:System.Windows.Forms.DataGridViewTriState.NotSet> to restore the inheritance.  
  
 Because <xref:System.Windows.Forms.DataGridViewTriState.NotSet> restores the value inheritance, the <xref:System.Windows.Forms.DataGridViewBand.Resizable%2A> property will never return a <xref:System.Windows.Forms.DataGridViewTriState.NotSet> value unless the row or column has not been added to a <xref:System.Windows.Forms.DataGridView> control. If you need to determine whether the <xref:System.Windows.Forms.DataGridViewBand.Resizable%2A> property value of a row or column is inherited, examine its <xref:System.Windows.Forms.DataGridViewElement.State%2A> property. If the <xref:System.Windows.Forms.DataGridViewElement.State%2A> value includes the <xref:System.Windows.Forms.DataGridViewElementStates.ResizableSet> flag, the <xref:System.Windows.Forms.DataGridViewBand.Resizable%2A> property value is not inherited.  
  
## Automatic Sizing  
 There are two kinds of automatic sizing in the <xref:System.Windows.Forms.DataGridView> control: column fill mode and content-based automatic sizing.  
  
 Column fill mode causes the visible columns in the control to fill the width of the control's display area. For more information about this mode, see [Column Fill Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/column-fill-mode-in-the-windows-forms-datagridview-control.md).  
  
 You can also configure rows, columns, and headers to automatically adjust their sizes to fit their cell contents. In this case, size adjustment occurs whenever cell contents change.  
  
> [!NOTE]
>  If you maintain cell values in a custom data cache using virtual mode, automatic sizing occurs when the user edits a cell value but does not occur when you alter a cached value outside of a <xref:System.Windows.Forms.DataGridView.CellValuePushed> event handler. In this case, call the <xref:System.Windows.Forms.DataGridView.UpdateCellValue%2A> method to force the control to update the cell display and apply the current automatic sizing modes.  
  
 If content-based automatic sizing is enabled for one dimension only—that is, for rows but not columns, or for columns but not rows—and <xref:System.Windows.Forms.DataGridViewCellStyle.WrapMode%2A> is also enabled, size adjustment also occurs whenever the other dimension changes. For example, if rows but not columns are configured for automatic sizing and <xref:System.Windows.Forms.DataGridViewCellStyle.WrapMode%2A> is enabled, users can drag column dividers to change the width of a column and row heights will automatically adjust so that cell contents are still fully displayed.  
  
 If you configure both rows and columns for content-based automatic sizing and <xref:System.Windows.Forms.DataGridViewCellStyle.WrapMode%2A> is enabled, the <xref:System.Windows.Forms.DataGridView> control will adjust sizes whenever cell contents changed and will use an ideal cell height-to-width ratio when calculating new sizes.  
  
 To configure the sizing mode for headers and rows and for columns that do not override the control value, set one or more of the following <xref:System.Windows.Forms.DataGridView> properties:  
  
-   <xref:System.Windows.Forms.DataGridView.ColumnHeadersHeightSizeMode%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.RowHeadersWidthSizeMode%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.AutoSizeColumnsMode%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.AutoSizeRowsMode%2A>  
  
 To override the control's column sizing mode for an individual column, set its <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A> property to a value other than <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet>. The sizing mode for a column is actually determined by its <xref:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode%2A> property. The value of this property is based on the column's <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A> property value unless that value is <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode.NotSet>, in which case the control's <xref:System.Windows.Forms.DataGridView.AutoSizeColumnsMode%2A> value is inherited.  
  
 Use content-based automatic resizing with caution when working with large amounts of data. To avoid performance penalties, use the automatic sizing modes that calculate sizes based only on the displayed rows rather than analyzing every row in the control. For maximum performance, use programmatic resizing instead so that you can resize at specific times, such as immediately after new data is loaded.  
  
 Content-based automatic sizing modes do not affect rows, columns, or headers that you have hidden by setting the row or column <xref:System.Windows.Forms.DataGridViewBand.Visible%2A> property or the control <xref:System.Windows.Forms.DataGridView.RowHeadersVisible%2A> or <xref:System.Windows.Forms.DataGridView.ColumnHeadersVisible%2A> properties to `false`. For example, if a column is hidden after it is automatically sized to fit a large cell value, the hidden column will not change its size if the row containing the large cell value is deleted. Automatic sizing does not occur when visibility changes, so changing the column <xref:System.Windows.Forms.DataGridViewColumn.Visible%2A> property back to `true` will not force it to recalculate its size based on its current contents.  
  
 Programmatic content-based resizing affects rows, columns, and headers regardless of their visibility.  
  
## Programmatic Resizing  
 When automatic sizing is disabled, you can programmatically set the exact width or height of rows, columns, or headers through the following properties:  
  
-   <xref:System.Windows.Forms.DataGridView.RowHeadersWidth%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.DataGridView.ColumnHeadersHeight%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.DataGridViewRow.Height%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.DataGridViewColumn.Width%2A?displayProperty=nameWithType>  
  
 You can also programmatically resize rows, columns, and headers to fit their contents using the following methods:  
  
-   <xref:System.Windows.Forms.DataGridView.AutoResizeColumn%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.AutoResizeColumns%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.AutoResizeColumnHeadersHeight%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.AutoResizeRow%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.AutoResizeRows%2A>  
  
-   <xref:System.Windows.Forms.DataGridView.AutoResizeRowHeadersWidth%2A>  
  
 These methods will resize rows, columns, or headers once rather than configuring them for continuous resizing. The new sizes are automatically calculated to display all cell contents without clipping. When you programmatically resize columns that have <xref:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode%2A> property values of <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill>, however, the calculated content-based widths are used to proportionally adjust the column <xref:System.Windows.Forms.DataGridViewColumn.FillWeight%2A> property values, and the actually column widths are then calculated according to these new proportions so that all columns fill the available display area of the control.  
  
 Programmatic resizing is useful to avoid performance penalties with continuous resizing. It is also useful to provide initial sizes for user-resizable rows, columns, and headers, and for column fill mode.  
  
 You will typically call the programmatic resizing methods at specific times. For example, you might programmatically resize all columns immediately after loading data, or you might programmatically resize a specific row after a particular cell value has been modified.  
  
## Customizing Content-based Sizing Behavior  
 You can customize sizing behaviors when working with derived <xref:System.Windows.Forms.DataGridView> cell, row, and column types by overriding the <xref:System.Windows.Forms.DataGridViewCell.GetPreferredSize%2A?displayProperty=nameWithType>, <xref:System.Windows.Forms.DataGridViewRow.GetPreferredHeight%2A?displayProperty=nameWithType>, or <xref:System.Windows.Forms.DataGridViewColumn.GetPreferredWidth%2A?displayProperty=nameWithType> methods or by calling protected resizing method overloads in a derived <xref:System.Windows.Forms.DataGridView> control. The protected resizing method overloads are designed to work in pairs to achieve an ideal cell height-to-width ratio, avoiding overly wide or tall cells. For example, if you call the `AutoResizeRows(DataGridViewAutoSizeRowsMode,Boolean)` overload of the <xref:System.Windows.Forms.DataGridView.AutoResizeRows%2A> method and pass in a value of `false` for the <xref:System.Boolean> parameter, the overload will calculate the ideal heights and widths for cells in the row, but it will adjust the row heights only. You must then call the <xref:System.Windows.Forms.DataGridView.AutoResizeColumns%2A> method to adjust the column widths to the calculated ideal.  
  
## Content-based Sizing Options  
 The enumerations used by sizing properties and methods have similar values for content-based sizing. With these values, you can limit which cells are used to calculate the preferred sizes. For all sizing enumerations, values with names that refer to displayed cells limit their calculations to cells in displayed rows. Excluding rows is useful to avoid a performance penalty when you are working with a large quantity of rows. You can also restrict calculations to cell values in header or nonheader cells.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.AllowUserToResizeColumns%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AllowUserToResizeRows%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.ColumnHeadersHeightSizeMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.RowHeadersWidthSizeMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewBand.Resizable%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AutoSizeColumnsMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AutoSizeRowsMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.AutoSizeMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.InheritedAutoSizeMode%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.RowHeadersWidth%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.ColumnHeadersHeight%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewRow.Height%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewColumn.Width%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AutoResizeColumn%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AutoResizeColumns%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AutoResizeColumnHeadersHeight%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AutoResizeRow%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AutoResizeRows%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridView.AutoResizeRowHeadersWidth%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.DataGridViewAutoSizeRowMode>  
 <xref:System.Windows.Forms.DataGridViewAutoSizeRowsMode>  
 <xref:System.Windows.Forms.DataGridViewAutoSizeColumnMode>  
 <xref:System.Windows.Forms.DataGridViewAutoSizeColumnsMode>  
 <xref:System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode>  
 <xref:System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode>  
 [Resizing Columns and Rows in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/resizing-columns-and-rows-in-the-windows-forms-datagridview-control.md)  
 [Column Fill Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/column-fill-mode-in-the-windows-forms-datagridview-control.md)  
 [How to: Set the Sizing Modes of the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-set-the-sizing-modes-of-the-windows-forms-datagridview-control.md)
