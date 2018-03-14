---
title: "DataGridView Control Scenarios (Windows Forms)"
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
  - "data [Windows Forms], displaying in tabular format"
  - "data grids [Windows Forms], about data grids"
  - "DataGridView control [Windows Forms], scenarios"
ms.assetid: 09a5fd05-3447-47ec-a4ec-6082a2b7f0dd
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DataGridView Control Scenarios (Windows Forms)
With the <xref:System.Windows.Forms.DataGridView> control, you can display tabular data from a variety of data sources. For simple uses, you can manually populate a <xref:System.Windows.Forms.DataGridView> and manipulate the data directly through the control. Typically, however, you will store your data in an external data source and bind the control to it through a <xref:System.Windows.Forms.BindingSource> component.  
  
 This topic describes some of the common scenarios that involve the <xref:System.Windows.Forms.DataGridView> control.  
  
## Scenario 1: Displaying Small Amounts of Data  
 You do not have to store your data in an external data source to display it in the <xref:System.Windows.Forms.DataGridView> control. If you are working with a small amount of data, you can populate the control yourself and manipulate the data through the control. This is called *unbound mode*. For more information, see [How to: Create an Unbound Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-create-an-unbound-windows-forms-datagridview-control.md).  
  
### Scenario Key Points  
  
-   In unbound mode, you populate the control manually.  
  
-   Unbound mode is particularly suited for small amounts of read-only data.  
  
-   Unbound mode is also suited for spreadsheet-like or sparsely populated tables.  
  
## Scenario 2: Viewing and Updating Data Stored in an External Data Source  
 You can use the <xref:System.Windows.Forms.DataGridView> control as a user interface (UI) through which users can access data kept in a data source such as a database table or a collection of business objects. For more information, see [How to: Bind Data to the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-bind-data-to-the-windows-forms-datagridview-control.md).  
  
### Scenario Key Points  
  
-   Bound mode lets you connect to a data source, automatically generate columns based on the data source properties or database columns, and automatically populate the control.  
  
-   Bound mode is suited for heavy user interaction with data. Data can be formatted for display, and user-specified data can be parsed into the format expected by the data source. Data entry formatting errors and database constraint errors can be detected so that users can be warned and erroneous cells can be corrected.  
  
-   Additional functionality such as column sorting, freezing, and reordering enable users to view data in the way most convenient for their workflow.  
  
-   Clipboard support enables users to copy data from your application into other applications.  
  
## Scenario 3: Advanced Data  
 If you have special needs that the standard data binding model does not address, you can manage the interaction between the control and your data by implementing *virtual mode*. Implementing virtual mode means implementing one or more event handlers that let the control request information about cells as the information is needed.  
  
 For example, if you work with large amounts of data, you may want to implement virtual mode to ensure optimal efficiency. Virtual mode is also useful for maintaining the values of unbound columns that you display along with columns retrieved from another data source.  
  
 For more information about virtual mode, see [Walkthrough: Implementing Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-wf-datagridview-control.md).  
  
### Scenario Key Points  
  
-   Virtual mode is suited for displaying very large amounts of data when you need to fine-tune performance.  
  
## Scenario 4: Automatically Resizing Rows and Columns  
 When you display data that is regularly updated, you can automatically resize rows and columns to ensure that all content is visible. The <xref:System.Windows.Forms.DataGridView> control provides several options that let you enable or disable manual resizing, resize programmatically at specific times, or resize automatically whenever content changes. For more information, see [Sizing Options in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/sizing-options-in-the-windows-forms-datagridview-control.md).  
  
### Scenario Key Points  
  
-   Manual resizing enables users to adjust cell heights and widths.  
  
-   Automatic resizing enables you to maintain cell sizes so that cell content is never clipped.  
  
-   Programmatic resizing enables you to resize cells at specific times to avoid the performance penalty of continuous automatic resizing.  
  
## Scenario 5: Simple Customization  
 The <xref:System.Windows.Forms.DataGridView> control provides many ways for you to alter its basic appearance and behavior. For more information, see [Cell Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/cell-styles-in-the-windows-forms-datagridview-control.md).  
  
### Scenario Key Points  
  
-   <xref:System.Windows.Forms.DataGridViewCellStyle> objects let you provide color, font, formatting, and positioning information at multiple levels and for individual elements of the control.  
  
-   Cell styles can be layered and shared by multiple elements, letting you reuse code.  
  
## Scenario 6: Advanced Customization  
 The <xref:System.Windows.Forms.DataGridView> control provides many ways for you to customize its appearance and behavior.  
  
### Scenario Key Points  
  
-   You can provide your own cell painting code. For more information, see [How to: Customize the Appearance of Cells in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customize-the-appearance-of-cells-in-the-datagrid.md).  
  
-   You can provide your own row painting. This is useful, for example, to create rows with content that spans multiple columns. For more information, see [How to: Customize the Appearance of Rows in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customize-the-appearance-of-rows-in-the-datagrid.md).  
  
-   You can implement your own cell and column classes to customize cell appearance. For more information, see [How to: Customize Cells and Columns in the Windows Forms DataGridView Control by Extending Their Behavior and Appearance](../../../../docs/framework/winforms/controls/customize-cells-and-columns-in-the-datagrid-by-extending-behavior.md).  
  
-   You can implement your own cell and column classes to host controls other than the ones provided by the built-in column types. For more information, see [How to: Host Controls in Windows Forms DataGridView Cells](../../../../docs/framework/winforms/controls/how-to-host-controls-in-windows-forms-datagridview-cells.md).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 [DataGridView Control Overview](../../../../docs/framework/winforms/controls/datagridview-control-overview-windows-forms.md)
