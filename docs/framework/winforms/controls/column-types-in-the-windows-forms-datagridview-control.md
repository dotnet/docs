---
title: "Column Types in the Windows Forms DataGridView Control"
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
  - "columns [Windows Forms], types"
  - "DataGridView control [Windows Forms], column types"
  - "data grids [Windows Forms], columns"
ms.assetid: f0a0a9f1-8757-4bfd-891f-d7d12870dbed
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Column Types in the Windows Forms DataGridView Control
The <xref:System.Windows.Forms.DataGridView> control uses several column types to display its information and enable users to modify or add information.  
  
 When you bind a <xref:System.Windows.Forms.DataGridView> control and set the <xref:System.Windows.Forms.DataGridView.AutoGenerateColumns%2A> property to `true`, columns are automatically generated using default column types appropriate for the data types contained in the bound data source.  
  
 You can also create instances of any of the column classes yourself and add them to the collection returned by the <xref:System.Windows.Forms.DataGridView.Columns%2A> property. You can create these instances for use as unbound columns, or you can manually bind them. Manually bound columns are useful, for example, when you want to replace an automatically generated column of one type with a column of another type.  
  
 The following table describes the various column classes available for use in the <xref:System.Windows.Forms.DataGridView> control.  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.Windows.Forms.DataGridViewTextBoxColumn>|Used with text-based values. Generated automatically when binding to numbers and strings.|  
|<xref:System.Windows.Forms.DataGridViewCheckBoxColumn>|Used with <xref:System.Boolean> and <xref:System.Windows.Forms.CheckState> values. Generated automatically when binding to values of these types.|  
|<xref:System.Windows.Forms.DataGridViewImageColumn>|Used to display images. Generated automatically when binding to byte arrays, <xref:System.Drawing.Image> objects, or <xref:System.Drawing.Icon> objects.|  
|<xref:System.Windows.Forms.DataGridViewButtonColumn>|Used to display buttons in cells. Not automatically generated when binding. Typically used as unbound columns.|  
|<xref:System.Windows.Forms.DataGridViewComboBoxColumn>|Used to display drop-down lists in cells. Not automatically generated when binding. Typically data-bound manually.|  
|<xref:System.Windows.Forms.DataGridViewLinkColumn>|Used to display links in cells. Not automatically generated when binding. Typically data-bound manually.|  
|Your custom column type|You can create your own column class by inheriting the <xref:System.Windows.Forms.DataGridViewColumn> class or any of its derived classes to provide custom appearance, behavior, or hosted controls. For more information, see [How to: Customize Cells and Columns in the Windows Forms DataGridView Control by Extending Their Behavior and Appearance](../../../../docs/framework/winforms/controls/customize-cells-and-columns-in-the-datagrid-by-extending-behavior.md)|  
  
 These column types are described in more detail in the following sections.  
  
## DataGridViewTextBoxColumn  
 The <xref:System.Windows.Forms.DataGridViewTextBoxColumn> is a general-purpose column type for use with text-based values such as numbers and strings. In editing mode, a <xref:System.Windows.Forms.TextBox> control is displayed in the active cell, enabling users to modify the cell value.  
  
 Cell values are automatically converted to strings for display. Values entered or modified by the user are automatically parsed to create a cell value of the appropriate data type. You can customize these conversions by handling the <xref:System.Windows.Forms.DataGridView.CellFormatting> and <xref:System.Windows.Forms.DataGridView.CellParsing> events of the <xref:System.Windows.Forms.DataGridView> control.  
  
 The cell value data type of a column is specified in the <xref:System.Windows.Forms.DataGridViewColumn.ValueType%2A> property of the column.  
  
## DataGridViewCheckBoxColumn  
 The <xref:System.Windows.Forms.DataGridViewCheckBoxColumn> is used with <xref:System.Boolean> and <xref:System.Windows.Forms.CheckState> values. <xref:System.Boolean> values display as two-state or three-state check boxes, depending on the value of the <xref:System.Windows.Forms.DataGridViewCheckBoxColumn.ThreeState%2A> property. When the column is bound to <xref:System.Windows.Forms.CheckState> values, the <xref:System.Windows.Forms.DataGridViewCheckBoxColumn.ThreeState%2A> property value is `true` by default.  
  
 Typically, check box cell values are intended either for storage, like any other data, or for performing bulk operations. If you want to respond immediately when users click a check box cell, you can handle the <xref:System.Windows.Forms.DataGridView.CellClick> event, but this event occurs before the cell value is updated. If you need the new value at the time of the click, one option is to calculate what the expected value will be based on the current value. Another approach is to commit the change immediately, and handle the <xref:System.Windows.Forms.DataGridView.CellValueChanged> event to respond to it. To commit the change when the cell is clicked, you must handle the <xref:System.Windows.Forms.DataGridView.CurrentCellDirtyStateChanged> event. In the handler, if the current cell is a check box cell, call the <xref:System.Windows.Forms.DataGridView.CommitEdit%2A> method and pass in the <xref:System.Windows.Forms.DataGridViewDataErrorContexts.Commit> value.  
  
## DataGridViewImageColumn  
 The <xref:System.Windows.Forms.DataGridViewImageColumn> is used to display images. Image columns can be populated automatically from a data source, populated manually for unbound columns, or populated dynamically in a handler for the <xref:System.Windows.Forms.DataGridView.CellFormatting> event.  
  
 The automatic population of an image column from a data source works with byte arrays in a variety of image formats, including all formats supported by the <xref:System.Drawing.Image> class and the OLE Picture format used by Microsoft® Access and the Northwind sample database.  
  
 Populating an image column manually is useful when you want to provide the functionality of a <xref:System.Windows.Forms.DataGridViewButtonColumn>, but with a customized appearance. You can handle the <xref:System.Windows.Forms.DataGridView.CellClick?displayProperty=nameWithType> event to respond to clicks within an image cell.  
  
 Populating the cells of an image column in a handler for the <xref:System.Windows.Forms.DataGridView.CellFormatting> event is useful when you want to provide images for calculated values or values in non-image formats. For example, you may have a "Risk" column with string values such as `"high"`, `"middle"`, and `"low"` that you want to display as icons. Alternately, you may have an "Image" column that contains the locations of images that must be loaded rather than the binary content of the images.  
  
## DataGridViewButtonColumn  
 With the <xref:System.Windows.Forms.DataGridViewButtonColumn>, you can display a column of cells that contain buttons. This is useful when you want to provide an easy way for your users to perform actions on particular records, such as placing an order or displaying child records in a separate window.  
  
 Button columns are not generated automatically when data-binding a <xref:System.Windows.Forms.DataGridView> control. To use button columns, you must create them manually and add them to the collection returned by the <xref:System.Windows.Forms.DataGridView.Columns%2A?displayProperty=nameWithType> property.  
  
 You can respond to user clicks in button cells by handling the <xref:System.Windows.Forms.DataGridView.CellClick?displayProperty=nameWithType> event.  
  
## DataGridViewComboBoxColumn  
 With the <xref:System.Windows.Forms.DataGridViewComboBoxColumn>, you can display a column of cells that contain drop-down list boxes. This is useful for data entry in fields that can only contain particular values, such as the Category column of the Products table in the Northwind sample database.  
  
 You can populate the drop-down list used for all cells the same way you would populate a <xref:System.Windows.Forms.ComboBox> drop-down list, either manually through the collection returned by the <xref:System.Windows.Forms.DataGridViewComboBoxColumn.Items%2A> property, or by binding it to a data source through the <xref:System.Windows.Forms.DataGridViewComboBoxColumn.DataSource%2A>, <xref:System.Windows.Forms.DataGridViewComboBoxColumn.DisplayMember%2A>, and <xref:System.Windows.Forms.DataGridViewComboBoxColumn.ValueMember%2A> properties. For more information, see [ComboBox Control](../../../../docs/framework/winforms/controls/combobox-control-windows-forms.md).  
  
 You can bind the actual cell values to the data source used by the <xref:System.Windows.Forms.DataGridView> control by setting the <xref:System.Windows.Forms.DataGridViewColumn.DataPropertyName%2A> property of the <xref:System.Windows.Forms.DataGridViewComboBoxColumn?displayProperty=nameWithType>.  
  
 Combo box columns are not generated automatically when data-binding a <xref:System.Windows.Forms.DataGridView> control. To use combo box columns, you must create them manually and add them to the collection returned by the <xref:System.Windows.Forms.DataGridView.Columns%2A> property.  
  
## DataGridViewLinkColumn  
 With the <xref:System.Windows.Forms.DataGridViewLinkColumn>, you can display a column of cells that contain hyperlinks. This is useful for URL values in the data source or as an alternative to the button column for special behaviors such as opening a window with child records.  
  
 Link columns are not generated automatically when data-binding a <xref:System.Windows.Forms.DataGridView> control. To use link columns, you must create them manually and add them to the collection returned by the <xref:System.Windows.Forms.DataGridView.Columns%2A> property.  
  
 You can respond to user clicks on links by handling the <xref:System.Windows.Forms.DataGridView.CellContentClick> event. This event is distinct from the <xref:System.Windows.Forms.DataGridView.CellClick> and <xref:System.Windows.Forms.DataGridView.CellMouseClick> events, which occur when a user clicks anywhere in a cell.  
  
 The <xref:System.Windows.Forms.DataGridViewLinkColumn> class provides several properties for modifying the appearance of links before, during, and after they are clicked.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridViewColumn>  
 <xref:System.Windows.Forms.DataGridViewButtonColumn>  
 <xref:System.Windows.Forms.DataGridViewCheckBoxColumn>  
 <xref:System.Windows.Forms.DataGridViewComboBoxColumn>  
 <xref:System.Windows.Forms.DataGridViewImageColumn>  
 <xref:System.Windows.Forms.DataGridViewTextBoxColumn>  
 <xref:System.Windows.Forms.DataGridViewLinkColumn>  
 [DataGridView Control](../../../../docs/framework/winforms/controls/datagridview-control-windows-forms.md)  
 [How to: Display Images in Cells of the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-display-images-in-cells-of-the-windows-forms-datagridview-control.md)  
 [How to: Work with Image Columns in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-work-with-image-columns-in-the-windows-forms-datagridview-control.md)  
 [Customizing the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customizing-the-windows-forms-datagridview-control.md)
