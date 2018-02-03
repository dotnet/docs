---
title: "Sizing Options in the DataGrid Control"
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
  - "DataGrid control [WPF], sizing"
  - "size [WPF], DataGrid"
  - "automatically size DataGrid [WPF]"
ms.assetid: 96a0e47e-b010-4302-98ef-2daac446d8db
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Sizing Options in the DataGrid Control
Various options are available to control how the <xref:System.Windows.Controls.DataGrid> sizes itself. The <xref:System.Windows.Controls.DataGrid>, and individual rows and columns in the <xref:System.Windows.Controls.DataGrid>, can be set to size automatically to their contents or can be set to specific values. By default, the <xref:System.Windows.Controls.DataGrid> will grow and shrink to fit the size of its contents.  
  
## Sizing the DataGrid  
  
### Cautions When Using Automatic Sizing  
 By default, the <xref:System.Windows.FrameworkElement.Height%2A> and <xref:System.Windows.FrameworkElement.Width%2A> properties of the <xref:System.Windows.Controls.DataGrid> are set to <xref:System.Double.NaN?displayProperty=nameWithType> ("`Auto`" in XAML), and the <xref:System.Windows.Controls.DataGrid> will adjust to the size of its contents.  
  
 When placed inside a container that does not restrict the size of its children, such as a <xref:System.Windows.Controls.Canvas> or <xref:System.Windows.Controls.StackPanel>, the <xref:System.Windows.Controls.DataGrid> will stretch beyond the visible bounds of the container and scrollbars will not be shown. This condition has both usability and performance implications.  
  
 When bound to a data set, if the <xref:System.Windows.FrameworkElement.Height%2A> of the <xref:System.Windows.Controls.DataGrid> is not restricted, it will continue to add a row for each data item in the bound data set. This can cause the <xref:System.Windows.Controls.DataGrid> to grow outside the visible bounds of your application as rows are added. The <xref:System.Windows.Controls.DataGrid> will not show scrollbars in this case because its <xref:System.Windows.FrameworkElement.Height%2A> will continue to grow to accommodate the new rows.  
  
 An object is created for each row in the <xref:System.Windows.Controls.DataGrid>. If you are working with a large data set and you allow the <xref:System.Windows.Controls.DataGrid> to automatically size itself, the creation of a large number of objects may affect the performance of your application.  
  
 To avoid these issues when you work with large data sets, it is recommended that you specifically set the <xref:System.Windows.FrameworkElement.Height%2A> of the <xref:System.Windows.Controls.DataGrid> or place it in a container that will restrict its <xref:System.Windows.FrameworkElement.Height%2A>, such as a <xref:System.Windows.Controls.Grid>. When the <xref:System.Windows.FrameworkElement.Height%2A> is restricted, the <xref:System.Windows.Controls.DataGrid> will only create the rows that will fit within its specified <xref:System.Windows.FrameworkElement.Height%2A>, and will recycle those rows as needed to display new data.  
  
### Setting the DataGrid Size  
 The <xref:System.Windows.Controls.DataGrid> can be set to automatically size within specified boundaries, or the <xref:System.Windows.Controls.DataGrid> can be set to a specific size. The following table shows the properties that can be set to control the <xref:System.Windows.Controls.DataGrid> size.  
  
|Property|Description|  
|--------------|-----------------|  
|<xref:System.Windows.FrameworkElement.Height%2A>|Sets a specific height for the <xref:System.Windows.Controls.DataGrid>.|  
|<xref:System.Windows.FrameworkElement.MaxHeight%2A>|Sets the upper bound for the height of the <xref:System.Windows.Controls.DataGrid>. The <xref:System.Windows.Controls.DataGrid> will grow vertically until it reaches this height.|  
|<xref:System.Windows.FrameworkElement.MinHeight%2A>|Sets the lower bound for the height of the <xref:System.Windows.Controls.DataGrid>. The <xref:System.Windows.Controls.DataGrid> will shrink vertically until it reaches this height.|  
|<xref:System.Windows.FrameworkElement.Width%2A>|Sets a specific width for the <xref:System.Windows.Controls.DataGrid>.|  
|<xref:System.Windows.FrameworkElement.MaxWidth%2A>|Sets the upper bound for the width of the <xref:System.Windows.Controls.DataGrid>. The <xref:System.Windows.Controls.DataGrid> will grow horizontally until it reaches this width.|  
|<xref:System.Windows.FrameworkElement.MinWidth%2A>|Sets the lower bound for the width of the <xref:System.Windows.Controls.DataGrid>. The <xref:System.Windows.Controls.DataGrid> will shrink horizontally until it reaches this width.|  
  
## Sizing Rows and Row Headers  
  
### DataGrid Rows  
 By default, a <xref:System.Windows.Controls.DataGrid> row's <xref:System.Windows.FrameworkElement.Height%2A> property is set to <xref:System.Double.NaN?displayProperty=nameWithType> ("`Auto`" in XAML), and the row height will expand to the size of its contents. The height of all rows in the <xref:System.Windows.Controls.DataGrid> can be specified by setting the <xref:System.Windows.Controls.DataGrid.RowHeight%2A?displayProperty=nameWithType> property. Users can change the row height by dragging the row header dividers.  
  
### DataGrid Row Headers  
 To display row headers, the <xref:System.Windows.Controls.DataGrid.HeadersVisibility%2A> property must be set to <xref:System.Windows.Controls.DataGridHeadersVisibility.Row?displayProperty=nameWithType> or <xref:System.Windows.Controls.DataGridHeadersVisibility.All?displayProperty=nameWithType>. By default, row headers are displayed and they automatically size to fit their content. The row headers can be given a specific width by setting the <xref:System.Windows.Controls.DataGrid.RowHeaderWidth%2A?displayProperty=nameWithType> property.  
  
## Sizing Columns and Column Headers  
  
### DataGrid Columns  
 The <xref:System.Windows.Controls.DataGrid> uses values of the <xref:System.Windows.Controls.DataGridLength> and the <xref:System.Windows.Controls.DataGridLengthUnitType> structure to specify absolute or automatic sizing modes.  
  
 The following table shows the values provided by the <xref:System.Windows.Controls.DataGridLengthUnitType> structure.  
  
|Name|Description|  
|----------|-----------------|  
|<xref:System.Windows.Controls.DataGridLengthUnitType.Auto>|The default automatic sizing mode sizes <xref:System.Windows.Controls.DataGrid> columns based on the contents of both cells and column headers.|  
|<xref:System.Windows.Controls.DataGridLengthUnitType.SizeToCells>|The cell-based automatic sizing mode sizes <xref:System.Windows.Controls.DataGrid> columns based on the contents of cells in the column, not including column headers.|  
|<xref:System.Windows.Controls.DataGridLengthUnitType.SizeToHeader>|The header-based automatic sizing mode sizes <xref:System.Windows.Controls.DataGrid> columns based on the contents of column headers only.|  
|<xref:System.Windows.Controls.DataGridLengthUnitType.Pixel>|The pixel-based sizing mode sizes <xref:System.Windows.Controls.DataGrid> columns based on the numeric value provided.|  
|<xref:System.Windows.Controls.DataGridLengthUnitType.Star>|The star sizing mode is used to distribute available space by weighted proportions.<br /><br /> In XAML, star values are expressed as n* where n represents a numeric value. 1\* is equivalent to \*. For example, if two columns in a <xref:System.Windows.Controls.DataGrid> had widths of \* and 2\*, the first column would receive one portion of the available space and the second column would receive two portions of the available space.|  
  
 The <xref:System.Windows.Controls.DataGridLengthConverter> class can be used to convert data between numeric or string values and <xref:System.Windows.Controls.DataGridLength> values.  
  
 By default, the <xref:System.Windows.Controls.DataGrid.ColumnWidth%2A?displayProperty=nameWithType> property is set to <xref:System.Windows.Controls.DataGridLength.SizeToHeader%2A>, and the <xref:System.Windows.Controls.DataGridColumn.Width%2A?displayProperty=nameWithType> property is set to <xref:System.Windows.Controls.DataGridLength.Auto%2A>. When the sizing mode is set to <xref:System.Windows.Controls.DataGridLength.Auto%2A> or <xref:System.Windows.Controls.DataGridLength.SizeToCells%2A>, columns will grow to the width of their widest visible content. When scrolling, these sizing modes will cause columns to expand if content that is larger than the current column size is scrolled into view. The column will not shrink after the content is scrolled out of view.  
  
 Columns in the <xref:System.Windows.Controls.DataGrid> can also be set to automatically size only within specified boundaries, or columns can be set to a specific size. The following table shows the properties that can be set to control column sizes.  
  
|Property|Description|  
|--------------|-----------------|  
|<xref:System.Windows.Controls.DataGrid.MaxColumnWidth%2A?displayProperty=nameWithType>|Sets the upper bound for all columns in the <xref:System.Windows.Controls.DataGrid>.|  
|<xref:System.Windows.Controls.DataGridColumn.MaxWidth%2A?displayProperty=nameWithType>|Sets the upper bound for an individual column. Overrides <xref:System.Windows.Controls.DataGrid.MaxColumnWidth%2A?displayProperty=nameWithType>.|  
|<xref:System.Windows.Controls.DataGrid.MinColumnWidth%2A?displayProperty=nameWithType>|Sets the lower bound for all columns in the <xref:System.Windows.Controls.DataGrid>.|  
|<xref:System.Windows.Controls.DataGridColumn.MinWidth%2A?displayProperty=nameWithType>|Sets the lower bound for an individual column. Overrides <xref:System.Windows.Controls.DataGrid.MinColumnWidth%2A?displayProperty=nameWithType>.|  
|<xref:System.Windows.Controls.DataGrid.ColumnWidth%2A?displayProperty=nameWithType>|Sets a specific width for all columns in the <xref:System.Windows.Controls.DataGrid>.|  
|<xref:System.Windows.Controls.DataGridColumn.Width%2A?displayProperty=nameWithType>|Sets a specific width for an individual column. Overrides <xref:System.Windows.Controls.DataGrid.ColumnWidth%2A?displayProperty=nameWithType>.|  
  
### DataGrid Column Headers  
 By default, <xref:System.Windows.Controls.DataGrid> column headers are displayed. To hide column headers, the <xref:System.Windows.Controls.DataGrid.HeadersVisibility%2A> property must be set to <xref:System.Windows.Controls.DataGridHeadersVisibility.Row?displayProperty=nameWithType> or <xref:System.Windows.Controls.DataGridHeadersVisibility.None?displayProperty=nameWithType>. By default, when column headers are displayed, they automatically size to fit their content. The column headers can be given a specific height by setting the <xref:System.Windows.Controls.DataGrid.ColumnHeaderHeight%2A?displayProperty=nameWithType> property.  
  
### Resizing with the Mouse  
 Users can resize <xref:System.Windows.Controls.DataGrid> rows and columns by dragging the row or column header dividers. The <xref:System.Windows.Controls.DataGrid> also supports automatic resizing of rows and columns by double-clicking the row or column header divider. To prevent a user from resizing particular columns, set the <xref:System.Windows.Controls.DataGridColumn.CanUserResize%2A?displayProperty=nameWithType> property to `false` for the individual columns. To prevent users from resizing all columns, set the <xref:System.Windows.Controls.DataGrid.CanUserResizeColumns%2A?displayProperty=nameWithType> property to `false`. To prevent users from resizing all rows, set the <xref:System.Windows.Controls.DataGrid.CanUserResizeRows%2A?displayProperty=nameWithType> property to `false`.  
  
## See Also  
 <xref:System.Windows.Controls.DataGrid>  
 <xref:System.Windows.Controls.DataGridColumn>  
 <xref:System.Windows.Controls.DataGridLength>  
 <xref:System.Windows.Controls.DataGridLengthConverter>
