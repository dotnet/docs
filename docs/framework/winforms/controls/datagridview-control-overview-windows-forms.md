---
title: "DataGridView Control Overview (Windows Forms)"
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
  - "DataGridView"
helpviewer_keywords: 
  - "DataGridView control [Windows Forms], about DataGridView control"
  - "grid controls [Windows Forms]"
  - "tables [Windows Forms], displaying in DataGridView control"
  - "tables [Windows Forms], binding to DataGridView control"
  - "columns [Windows Forms], DataGridView control"
  - "bound controls [Windows Forms], dataGridView control"
  - "datasets [Windows Forms], binding to DataGridView control"
  - "data grids [Windows Forms], about data grids"
  - "data [Windows Forms], resorting"
  - "data [Windows Forms], navigating"
  - "grids [Windows Forms]"
  - "data binding [Windows Forms], DataGridView control"
  - "data sources [Windows Forms], binding to DataGridView control"
  - "DataGridView control [Windows Forms], data binding"
ms.assetid: 0a45c661-89dc-4390-9cc6-c47eee501488
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DataGridView Control Overview (Windows Forms)
> [!NOTE]
>  The <xref:System.Windows.Forms.DataGridView> control replaces and adds functionality to the <xref:System.Windows.Forms.DataGrid> control; however, the <xref:System.Windows.Forms.DataGrid> control is retained for both backward compatibility and future use, if you choose. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).  
  
 With the <xref:System.Windows.Forms.DataGridView> control, you can display and edit tabular data from many different kinds of data sources.  
  
 Binding data to the <xref:System.Windows.Forms.DataGridView> control is straightforward and intuitive, and in many cases it is as simple as setting the <xref:System.Windows.Forms.DataGridView.DataSource%2A> property. When you bind to a data source that contains multiple lists or tables, set the <xref:System.Windows.Forms.DataGridView.DataMember%2A> property to a string that specifies the list or table to bind to.  
  
 The <xref:System.Windows.Forms.DataGridView> control supports the standard Windows Forms data binding model, so it will bind to instances of classes described in the following list:  
  
-   Any class that implements the <xref:System.Collections.IList> interface, including one-dimensional arrays.  
  
-   Any class that implements the <xref:System.ComponentModel.IListSource> interface, such as the <xref:System.Data.DataTable> and <xref:System.Data.DataSet> classes.  
  
-   Any class that implements the <xref:System.ComponentModel.IBindingList> interface, such as the <xref:System.ComponentModel.BindingList%601> class.  
  
-   Any class that implements the <xref:System.ComponentModel.IBindingListView> interface, such as the <xref:System.Windows.Forms.BindingSource> class.  
  
 The <xref:System.Windows.Forms.DataGridView> control supports data binding to the public properties of the objects returned by these interfaces or to the properties collection returned by an <xref:System.ComponentModel.ICustomTypeDescriptor> interface, if implemented on the returned objects.  
  
 Typically, you will bind to a <xref:System.Windows.Forms.BindingSource> component and bind the <xref:System.Windows.Forms.BindingSource> component to another data source or populate it with business objects. The <xref:System.Windows.Forms.BindingSource> component is the preferred data source because it can bind to a wide variety of data sources and can resolve many data binding issues automatically. For more information, see [BindingSource Component](../../../../docs/framework/winforms/controls/bindingsource-component.md).  
  
 The <xref:System.Windows.Forms.DataGridView> control can also be used in *unbound* mode, with no underlying data store. For a code example that uses an unbound <xref:System.Windows.Forms.DataGridView> control, see [Walkthrough: Creating an Unbound Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/walkthrough-creating-an-unbound-windows-forms-datagridview-control.md).  
  
 The <xref:System.Windows.Forms.DataGridView> control is highly configurable and extensible, and it provides many properties, methods, and events to customize its appearance and behavior. When you want your Windows Forms application to display tabular data, consider using the <xref:System.Windows.Forms.DataGridView> control before others (for example, <xref:System.Windows.Forms.DataGrid>). If you are displaying a small grid of read-only values, or if you are enabling a user to edit a table with millions of records, the <xref:System.Windows.Forms.DataGridView> control will provide you with a readily programmable, memory-efficient solution.  
  
## In This Section  
 [DataGridView Control Technology Summary](../../../../docs/framework/winforms/controls/datagridview-control-technology-summary-windows-forms.md)  
 Summarizes <xref:System.Windows.Forms.DataGridView> control concepts and the use of related classes.  
  
 [DataGridView Control Architecture](../../../../docs/framework/winforms/controls/datagridview-control-architecture-windows-forms.md)  
 Describes the architecture of the <xref:System.Windows.Forms.DataGridView> control, explaining its type hierarchy and inheritance structure.  
  
 [DataGridView Control Scenarios](../../../../docs/framework/winforms/controls/datagridview-control-scenarios-windows-forms.md)  
 Describes the most common scenarios in which <xref:System.Windows.Forms.DataGridView> controls are used.  
  
 [DataGridView Control Code Directory](../../../../docs/framework/winforms/controls/datagridview-control-code-directory-windows-forms.md)  
 Provides links to code examples in the documentation for various <xref:System.Windows.Forms.DataGridView> tasks. These examples are categorized by task type.  
  
## Related Sections  
 [Column Types in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/column-types-in-the-windows-forms-datagridview-control.md)  
 Discusses the column types in the Windows Forms <xref:System.Windows.Forms.DataGridView> control used to display information and allow users to modify or add information.  
  
 [Displaying Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/displaying-data-in-the-windows-forms-datagridview-control.md)  
 Provides topics that describe how to populate the control with data either manually, or from an external data source.  
  
 [Customizing the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customizing-the-windows-forms-datagridview-control.md)  
 Provides topics that describe custom painting <xref:System.Windows.Forms.DataGridView> cells and rows, and creating derived cell, column, and row types.  
  
 [Performance Tuning in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/performance-tuning-in-the-windows-forms-datagridview-control.md)  
 Provides topics that describe how to use the control efficiently to avoid performance problems when working with large amounts of data.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.BindingSource>  
 [DataGridView Control](../../../../docs/framework/winforms/controls/datagridview-control-windows-forms.md)  
 [Default Functionality in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/default-functionality-in-the-windows-forms-datagridview-control.md)  
 [Default Keyboard and Mouse Handling in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/default-keyboard-and-mouse-handling-in-the-windows-forms-datagridview-control.md)
