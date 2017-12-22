---
title: "DataGrid Control Overview (Windows Forms)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "DataGrid"
helpviewer_keywords: 
  - "datasets [Windows Forms], binding to DataGrid control"
  - "data binding [Windows Forms], DataGrid control"
  - "columns [Windows Forms], DataGrid control"
  - "data sources [Windows Forms], binding to DataGrid control"
  - "tables [Windows Forms], binding to DataGrid control"
  - "DataGrid control [Windows Forms], data binding"
  - "DataGrid control [Windows Forms], about DataGrid control"
  - "parent tables in DataGrid control"
  - "tables [Windows Forms], displaying in DataGrid control"
  - "data grids [Windows Forms], about data grids"
  - "multiple tables in DataGrid control"
  - "data [Windows Forms], resorting"
  - "data [Windows Forms], navigating"
  - "parent table navigation in DataGrid"
  - "child tables [Windows Forms], dataGrid control"
ms.assetid: 85604bce-bc03-49d9-9030-dda8896c44b1
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DataGrid Control Overview (Windows Forms)
> [!NOTE]
>  The <xref:System.Windows.Forms.DataGridView> control replaces and adds functionality to the <xref:System.Windows.Forms.DataGrid> control; however, the <xref:System.Windows.Forms.DataGrid> control is retained for both backward compatibility and future use, if you choose. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).  
  
 The Windows Forms <xref:System.Windows.Forms.DataGrid> control displays data in a series of rows and columns. The simplest case is when the grid is bound to a data source with a single table that contains no relationships. In that case, the data appears in simple rows and columns, as in a spreadsheet. For more information about binding data to other controls, see [Data Binding and Windows Forms](../../../../docs/framework/winforms/data-binding-and-windows-forms.md).  
  
 If the <xref:System.Windows.Forms.DataGrid> is bound to data with multiple related tables, and if navigation is enabled on the grid, the grid will display expanders in each row. With an expander, the user can move from a parent table to a child table. Clicking a node displays the child table, and clicking a back button displays the original parent table. In this manner, the grid displays the hierarchical relationships between tables.  
  
 The following screen shot shows a DataGrid bound to data with multiple tables.  
  
 ![A DataGrid bound to data with multiple tables](../../../../docs/framework/winforms/controls/media/vbcontrol1.gif "vbControl1")  
A DataGrid bound to data with multiple tables  
  
 The <xref:System.Windows.Forms.DataGrid> can provide a user interface for a dataset, navigation between related tables, and rich formatting and editing capabilities.  
  
 The display and manipulation of data are separate functions: The control handles the user interface, whereas data updates are handled by the Windows Forms data-binding architecture and by [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] data providers. Therefore, multiple controls bound to the same data source will stay in sync.  
  
> [!NOTE]
>  If you are familiar with the DataGrid control in Visual Basic 6.0, you will find some significant differences in the Windows Forms <xref:System.Windows.Forms.DataGrid> control.  
  
 When the grid is bound to a <xref:System.Data.DataSet>, the columns and rows are automatically created, formatted, and filled. For more information, see [Data Binding and Windows Forms](../../../../docs/framework/winforms/data-binding-and-windows-forms.md). Following the generation of the <xref:System.Windows.Forms.DataGrid> control, you can add, delete, rearrange, and format columns and rows depending on your needs.  
  
## Binding Data to the Control  
 For the <xref:System.Windows.Forms.DataGrid> control to work, it should be bound to a data source using the <xref:System.Windows.Forms.DataGrid.DataSource%2A> and <xref:System.Windows.Forms.DataGrid.DataMember%2A> properties at design time or the <xref:System.Windows.Forms.DataGrid.SetDataBinding%2A> method at run time. This binding points the <xref:System.Windows.Forms.DataGrid> to an instantiated data-source object, such as a <xref:System.Data.DataSet> or <xref:System.Data.DataTable>). The <xref:System.Windows.Forms.DataGrid> control shows the results of actions that are performed on the data. Most data-specific actions are not performed through the <xref:System.Windows.Forms.DataGrid> , but instead through the data source.  
  
 If the data in the bound dataset is updated through any mechanism, the <xref:System.Windows.Forms.DataGrid> control reflects the changes. If the data grid and its table styles and column styles have the `ReadOnly` property set to `false`, the data in the dataset can be updated through the <xref:System.Windows.Forms.DataGrid> control.  
  
 Only one table can be shown in the <xref:System.Windows.Forms.DataGrid> at a time. If a parent-child relationship is defined between tables, the user can move between the related tables to select the table to be displayed in the <xref:System.Windows.Forms.DataGrid> control. For information about binding a <xref:System.Windows.Forms.DataGrid> control to an [!INCLUDE[vstecado](../../../../includes/vstecado-md.md)] data source at either design time or run time, see [How to: Bind the Windows Forms DataGrid Control to a Data Source](../../../../docs/framework/winforms/controls/how-to-bind-the-windows-forms-datagrid-control-to-a-data-source.md).  
  
 Valid data sources for the <xref:System.Windows.Forms.DataGrid> include:  
  
-   <xref:System.Data.DataTable> class  
  
-   <xref:System.Data.DataView> class  
  
-   <xref:System.Data.DataSet> class  
  
-   <xref:System.Data.DataViewManager> class  
  
 If your source is a dataset, the dataset might be an object in the form or an object passed to the form by an XML Web service. You can bind to either typed or untyped datasets.  
  
 You can also bind a <xref:System.Windows.Forms.DataGrid> control to additional structures if the objects in the structure, such as the elements in an array, expose public properties. The grid will display all the public properties of the elements in the structure. For example, if you bind the <xref:System.Windows.Forms.DataGrid> control to an array of customer objects, the grid will display all the public properties of those customer objects. In some instances, this means that although you can bind to the structure, the resulting bound structure might not have practical application. For example, you can bind to an array of integers, but because the `Integer` data type does not support a public property, the grid cannot display any data.  
  
 You can bind to the following structures if their elements expose public properties:  
  
-   Any component that implements the <xref:System.Collections.IList> interface. This includes single-dimension arrays.  
  
-   Any component that implements the <xref:System.ComponentModel.IListSource> interface.  
  
-   Any component that implements the <xref:System.ComponentModel.IBindingList> interface.  
  
 For more information about possible data sources, see [Data Sources Supported by Windows Forms](../../../../docs/framework/winforms/data-sources-supported-by-windows-forms.md).  
  
## Grid Display  
 A common use of the <xref:System.Windows.Forms.DataGrid> control is to display a single table of data from a dataset. However, the control can also be used to display multiple tables, including related tables. The display of the grid is adjusted automatically according to the data source. The following table shows what is displayed for various configurations.  
  
|Contents of data set|What is displayed|  
|--------------------------|-----------------------|  
|Single table.|Table is displayed in a grid.|  
|Multiple tables.|The grid can display a tree view that users can navigate to locate the table they want to display.|  
|Multiple related tables.|The grid can display a tree view to select tables with, or you can specify that the grid display the parent table. Records in the parent table let users navigate to related child rows.|  
  
> [!NOTE]
>  Tables in a dataset are related using a <xref:System.Data.DataRelation>.  Also see [HYPERLINK "http://msdn.microsoft.com/library/dbwcse3d(v=vs.110)" Relationships in Datasets](http://msdn.microsoft.com/library/dbwcse3d\(v=vs.110\)) or [Relationships in Datasets](http://msdn.microsoft.com/library/dbwcse3d\(v=vs.120\)).  
  
 When the <xref:System.Windows.Forms.DataGrid> control is displaying a table and the <xref:System.Windows.Forms.DataGrid.AllowSorting%2A> property is set to `true`, data can be resorted by clicking the column headers. The user can also add rows and edit cells.  
  
 The relationships between a set of tables are displayed to users by using a parent/child structure of navigation. Parent tables are the highest level of data, and child tables are those data tables that are derived from the individual listings in the parent tables. Expanders are displayed in each parent row that contains a child table. Clicking an expander generates a list of Web-like links to the child tables. When the user selects a link, the child table is displayed. Clicking the show/hide parent rows icon (![show&#47;hide parent rows icon](../../../../docs/framework/winforms/controls/media/vbicon.gif "vbIcon")) will hide the information about the parent table or cause it to reappear if the user has previously hidden it. The user can click a back button to move back to the previously viewed table.  
  
## Columns and Rows  
 The <xref:System.Windows.Forms.DataGrid> consists of a collection of <xref:System.Windows.Forms.DataGridTableStyle> objects that are contained in the <xref:System.Windows.Forms.DataGrid> control's <xref:System.Windows.Forms.DataGrid.TableStyles%2A> property. A table style may contain a collection of <xref:System.Windows.Forms.DataGridColumnStyle> objects that are contained in the <xref:System.Windows.Forms.DataGridTableStyle.GridColumnStyles%2A> property of the <xref:System.Windows.Forms.DataGridTableStyle>.. You can edit the <xref:System.Windows.Forms.DataGrid.TableStyles%2A> and <xref:System.Windows.Forms.DataGridTableStyle.GridColumnStyles%2A> properties by using collection editors accessed through the **Properties** window.  
  
 Any <xref:System.Windows.Forms.DataGridTableStyle> associated with the <xref:System.Windows.Forms.DataGrid> control can be accessed through the <xref:System.Windows.Forms.GridTableStylesCollection>. The <xref:System.Windows.Forms.GridTableStylesCollection> can be edited in the designer with the <xref:System.Windows.Forms.DataGridTableStyle> collection editor, or programmatically through the <xref:System.Windows.Forms.DataGrid> control's <xref:System.Windows.Forms.DataGrid.TableStyles%2A> property.  
  
 ![Objects included in the DataGrid control](../../../../docs/framework/winforms/controls/media/vbcolumns1.gif "vbColumns1")  
The following illustration shows the objects included in the DataGrid control.  
  
 Table styles and column styles are synchronized with <xref:System.Data.DataTable> objects and <xref:System.Data.DataColumn> objects by setting their `MappingName` properties to the appropriate <xref:System.Data.DataTable.TableName%2A> and <xref:System.Data.DataColumn.ColumnName%2A> properties. When a <xref:System.Windows.Forms.DataGridTableStyle> that has no column styles is added to a <xref:System.Windows.Forms.DataGrid> control bound to a valid data source, and the <xref:System.Windows.Forms.DataGridTableStyle.MappingName%2A> property of that table style is set to a valid <xref:System.Data.DataTable.TableName%2A> property, a collection of <xref:System.Windows.Forms.DataGridColumnStyle> objects is created for that table style. For each <xref:System.Data.DataColumn> found in the <xref:System.Data.DataTable.Columns%2A> collection of the <xref:System.Data.DataTable>, a corresponding <xref:System.Windows.Forms.DataGridColumnStyle> is added to the <xref:System.Windows.Forms.GridColumnStylesCollection>. <xref:System.Windows.Forms.GridColumnStylesCollection> is accessed through the <xref:System.Windows.Forms.DataGridTableStyle.GridColumnStyles%2A> property of the <xref:System.Windows.Forms.DataGridTableStyle>. Columns can be added or deleted from the grid using the <xref:System.Windows.Forms.GridColumnStylesCollection.Add%2A> or <xref:System.Windows.Forms.GridColumnStylesCollection.Remove%2A> method on the <xref:System.Windows.Forms.GridColumnStylesCollection>. For more information, see [How to: Add Tables and Columns to the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-add-tables-and-columns-to-the-windows-forms-datagrid-control.md) and [How to: Delete or Hide Columns in the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-delete-or-hide-columns-in-the-windows-forms-datagrid-control.md).  
  
 A collection of column types extends the <xref:System.Windows.Forms.DataGridColumnStyle> class with rich formatting and editing capabilities. All column types inherit from the <xref:System.Windows.Forms.DataGridColumnStyle> base class. The class that is created depends on the <xref:System.Data.DataColumn.DataType%2A> property of the <xref:System.Data.DataColumn> from which the <xref:System.Web.UI.WebControls.DataGridColumn> is based. For example, a <xref:System.Data.DataColumn> that has its <xref:System.Data.DataColumn.DataType%2A> property set to <xref:System.Boolean> will be associated with the <xref:System.Windows.Forms.DataGridBoolColumn>. The following table describes each of these column types.  
  
|Column Type|Description|  
|-----------------|-----------------|  
|<xref:System.Windows.Forms.DataGridTextBoxColumn>|Accepts and displays data as formatted or unformatted strings. Editing capabilities are the same as they are for editing data in a simple <xref:System.Windows.Forms.TextBox>. Inherits from <xref:System.Windows.Forms.DataGridColumnStyle>.|  
|<xref:System.Windows.Forms.DataGridBoolColumn>|Accepts and displays `true`, `false`, and null values. Inherits from <xref:System.Windows.Forms.DataGridColumnStyle>.|  
  
 Double-clicking the right edge of a column resizes the column to display its full caption and widest entry.  
  
## Table Styles and Column Styles  
 As soon as you have established the default format of the <xref:System.Windows.Forms.DataGrid> control, you can customize the colors that will be used when certain tables are displayed within the data grid.  
  
 This is achieved by creating instances of the <xref:System.Windows.Forms.DataGridTableStyle> class. Table styles specify the formatting of specific tables, distinct from the default formatting of the <xref:System.Windows.Forms.DataGrid> control itself. Each table may have only one table style defined for it at a time.  
  
 Sometimes, you will want to have a specific column look different from the rest of the columns of a particular data table. You can create a customized set of column styles by using the <xref:System.Windows.Forms.DataGridTableStyle.GridColumnStyles%2A> property.  
  
 Column styles are related to columns in a dataset just like table styles are related to data tables. Just as each table may only have one table style defined for it at a time, so too can each column only have one column style defined for it, in a particular table style. This relationship is defined in the column's <xref:System.Windows.Forms.DataGridColumnStyle.MappingName%2A> property.  
  
 If you have created a table style without column styles added to it, [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] will add default column styles when the form and grid are created at run time. However, if you have created a table style and added any column styles to it, [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] will not create any column styles. Also, you will need to define column styles and assign them with the mapping name to have the columns that you want appear in the grid.  
  
 Because you specify which columns are included in the data grid by assigning them a column style and no column style has been assigned to the columns, you can include columns of data in the dataset that are not displayed in the grid. However, because the data column is included in the dataset, you can programmatically edit the data that is not displayed.  
  
> [!NOTE]
>  In general, create column styles and add them to the column styles collection before adding table styles to the table styles collection. When you add an empty table style to the collection, column styles are automatically generated for you. Consequently, an exception will be thrown if you try to add new column styles with duplicate <xref:System.Windows.Forms.DataGridColumnStyle.MappingName%2A> values to the column styles collection.  
>   
>  Sometimes, you will want to just tweak one column among many columns; for example, the dataset contains 50 columns and you only want 49 of them. In this case, it is easier to import all 50 columns and programmatically remove one, rather than programmatically adding each of the 49 individual columns you want.  
  
## Formatting  
 Formatting that can be applied to the <xref:System.Windows.Forms.DataGrid> control includes border styles, gridline styles, fonts, caption properties, data alignment, and alternating background colors between rows. For more information, see [How to: Format the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-format-the-windows-forms-datagrid-control.md).  
  
## Events  
 Besides the common control events such as <xref:System.Windows.Forms.Control.MouseDown>, <xref:System.Windows.Forms.Control.Enter>, and <xref:System.Windows.Forms.DataGrid.Scroll>, the <xref:System.Windows.Forms.DataGrid> control supports events associated with editing and navigation within the grid. The <xref:System.Windows.Forms.DataGrid.CurrentCell%2A> property determines which cell is selected. The <xref:System.Windows.Forms.DataGrid.CurrentCellChanged> event is raised when the user navigates to a new cell. When the user navigates to a new table through parent/child relations, the <xref:System.Windows.Forms.DataGrid.Navigate> event is raised. The <xref:System.Windows.Forms.DataGrid.BackButtonClick> event is raised when the user clicks the back button when the user is viewing a child table, and the <xref:System.Windows.Forms.DataGrid.ShowParentDetailsButtonClick> event is raised when the show/hide parent rows icon is clicked.  
  
## See Also  
 [DataGrid Control](../../../../docs/framework/winforms/controls/datagrid-control-windows-forms.md)  
 [How to: Bind the Windows Forms DataGrid Control to a Data Source](../../../../docs/framework/winforms/controls/how-to-bind-the-windows-forms-datagrid-control-to-a-data-source.md)  
 [How to: Add Tables and Columns to the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-add-tables-and-columns-to-the-windows-forms-datagrid-control.md)  
 [How to: Delete or Hide Columns in the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-delete-or-hide-columns-in-the-windows-forms-datagrid-control.md)  
 [How to: Format the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-format-the-windows-forms-datagrid-control.md)
