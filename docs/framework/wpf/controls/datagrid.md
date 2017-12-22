---
title: "DataGrid"
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
  - "DataGrid column types [WPF]"
  - "DataGrid scenarios [WPF]"
  - "DataGrid control [WPF]"
  - "controls [WPF], DataGrid"
  - "DataGrid [WPF], common tasks for"
  - "DataGrid [WPF], customizing the appearance of"
  - "DataGrid columns [WPF], using"
ms.assetid: bf89ea63-79b6-422b-bc9f-0485ad803216
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DataGrid
The <xref:System.Windows.Controls.DataGrid> control enables you to display and edit data from many different sources, such as from a SQL database, LINQ query, or any other bindable data source. For more information, see [Binding Sources Overview](../../../../docs/framework/wpf/data/binding-sources-overview.md).  
  
 Columns can display text, controls, such as a <xref:System.Windows.Controls.ComboBox>, or any other WPF content, such as images, buttons, or any content contained in a template. You can use a <xref:System.Windows.Controls.DataGridTemplateColumn> to display data defined in a template. The following table lists the column types that are provided by default.  
  
|Generated Column Type|Data Type|  
|---------------------------|---------------|  
|<xref:System.Windows.Controls.DataGridTextColumn>|<xref:System.String>|  
|<xref:System.Windows.Controls.DataGridCheckBoxColumn>|<xref:System.Boolean>|  
|<xref:System.Windows.Controls.DataGridComboBoxColumn>|<xref:System.Enum>|  
|<xref:System.Windows.Controls.DataGridHyperlinkColumn>|<xref:System.Uri>|  
  
 <xref:System.Windows.Controls.DataGrid> can be customized in appearance, such as cell font, color, and size. <xref:System.Windows.Controls.DataGrid> supports all styling and templating functionality of other WPF controls. <xref:System.Windows.Controls.DataGrid> also includes default and customizable behaviors for editing, sorting, and validation.  
  
 The following table lists some of the common tasks for <xref:System.Windows.Controls.DataGrid> and how to accomplish them. By viewing the related API, you can find more information and sample code.  
  
|Scenario|Approach|  
|--------------|--------------|  
|Alternating background colors|Set the <xref:System.Windows.Controls.ItemsControl.AlternationIndex%2A> property to 2 or more, and then assign a <xref:System.Windows.Media.Brush> to the <xref:System.Windows.Controls.DataGrid.RowBackground%2A> and <xref:System.Windows.Controls.DataGrid.AlternatingRowBackground%2A> properties.|  
|Define cell and row selection behavior|Set the <xref:System.Windows.Controls.DataGrid.SelectionMode%2A> and <xref:System.Windows.Controls.DataGrid.SelectionUnit%2A> properties.|  
|Customize the visual appearance of headers, cells, and rows|Apply a new <xref:System.Windows.Style> to the <xref:System.Windows.Controls.DataGrid.ColumnHeaderStyle%2A>, <xref:System.Windows.Controls.DataGrid.RowHeaderStyle%2A>, <xref:System.Windows.Controls.DataGrid.CellStyle%2A>, or <xref:System.Windows.Controls.DataGrid.RowStyle%2A> properties.|  
|Set sizing options|Set the <xref:System.Windows.FrameworkElement.Height%2A>, <xref:System.Windows.FrameworkElement.MaxHeight%2A>, <xref:System.Windows.FrameworkElement.MinHeight%2A>, <xref:System.Windows.FrameworkElement.Width%2A>, <xref:System.Windows.FrameworkElement.MaxWidth%2A>, or <xref:System.Windows.FrameworkElement.MinWidth%2A> properties. For more information, see [Sizing Options in the DataGrid Control](../../../../docs/framework/wpf/controls/sizing-options-in-the-datagrid-control.md).|  
|Access selected items|Check the <xref:System.Windows.Controls.DataGrid.SelectedCells%2A> property to get the selected cells and the <xref:System.Windows.Controls.Primitives.MultiSelector.SelectedItems%2A> property to get the selected rows. For more information, see <xref:System.Windows.Controls.DataGrid.SelectedCells%2A>.|  
|Customize end-user interactions|Set the <xref:System.Windows.Controls.DataGrid.CanUserAddRows%2A>, <xref:System.Windows.Controls.DataGrid.CanUserDeleteRows%2A>, <xref:System.Windows.Controls.DataGrid.CanUserReorderColumns%2A>, <xref:System.Windows.Controls.DataGrid.CanUserResizeColumns%2A>, <xref:System.Windows.Controls.DataGrid.CanUserResizeRows%2A>, and <xref:System.Windows.Controls.DataGrid.CanUserSortColumns%2A> properties.|  
|Cancel or change auto-generated columns|Handle the <xref:System.Windows.Controls.DataGrid.AutoGeneratingColumn> event.|  
|Freeze a column|Set the <xref:System.Windows.Controls.DataGrid.FrozenColumnCount%2A> property to 1 and move the column to the left-most position by setting the <xref:System.Windows.Controls.DataGridColumn.DisplayIndex%2A> property to 0.|  
|Use XML data as the data source|Bind the <xref:System.Windows.Controls.ItemsControl.ItemsSource%2A> on the <xref:System.Windows.Controls.DataGrid> to the XPath query that represents the collection of items. Create each column in the <xref:System.Windows.Controls.DataGrid>. Bind each column by setting the XPath on the binding to the query that gets the property on the item source. For an example, see <xref:System.Windows.Controls.DataGridTextColumn>.|  
  
## Related Topics  
  
|Title|Description|  
|-----------|-----------------|  
|[Walkthrough: Display Data from a SQL Server Database in a DataGrid Control](../../../../docs/framework/wpf/controls/walkthrough-display-data-from-a-sql-server-database-in-a-datagrid-control.md)|Describes how to set up a new WPF project, add an Entity Framework Element, set the source, and display the data in a <xref:System.Windows.Controls.DataGrid>.|  
|[How to: Add Row Details to a DataGrid Control](../../../../docs/framework/wpf/controls/how-to-add-row-details-to-a-datagrid-control.md)|Describes how to create row details for a <xref:System.Windows.Controls.DataGrid>.|  
|[How to: Implement Validation with the DataGrid Control](../../../../docs/framework/wpf/controls/how-to-implement-validation-with-the-datagrid-control.md)|Describes how to validate values in <xref:System.Windows.Controls.DataGrid> cells and rows, and display validation feedback.|  
|[Default Keyboard and Mouse Behavior in the DataGrid Control](../../../../docs/framework/wpf/controls/default-keyboard-and-mouse-behavior-in-the-datagrid-control.md)|Describes how to interact with the <xref:System.Windows.Controls.DataGrid> control by using the keyboard and mouse.|  
|[How to: Group, Sort, and Filter Data in the DataGrid Control](../../../../docs/framework/wpf/controls/how-to-group-sort-and-filter-data-in-the-datagrid-control.md)|Describes how to view data in a <xref:System.Windows.Controls.DataGrid> in different ways by grouping, sorting, and filtering the data.|  
|[Sizing Options in the DataGrid Control](../../../../docs/framework/wpf/controls/sizing-options-in-the-datagrid-control.md)|Describes how to control absolute and automatic sizing in the <xref:System.Windows.Controls.DataGrid>.|  
  
## See Also  
 <xref:System.Windows.Controls.DataGrid>  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [Data Templating Overview](../../../../docs/framework/wpf/data/data-templating-overview.md)  
 [Controls](../../../../docs/framework/wpf/controls/index.md)  
 [WPF Content Model](../../../../docs/framework/wpf/controls/wpf-content-model.md)
