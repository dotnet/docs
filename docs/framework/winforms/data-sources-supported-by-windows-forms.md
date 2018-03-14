---
title: "Data Sources Supported by Windows Forms"
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
  - "collections [Windows Forms], binding to"
  - "OLE DB providers [Windows Forms], Windows Forms"
  - "DataTable class [Windows Forms], binding and Windows Forms"
  - "Windows Forms, data binding"
  - "DataView class [Windows Forms], binding and Windows Forms"
  - "DataViewManager class [Windows Forms], binding and Windows Forms"
  - "Windows Forms, source data"
  - "arrays [Windows Forms]"
  - "data sources [Windows Forms]"
  - "data providers [Windows Forms]"
  - "DataSet class [Windows Forms], binding and Windows Forms"
  - "data [Windows Forms], data providers"
ms.assetid: 3d2c43f6-462b-4d35-9c86-13e9afe012e1
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Data Sources Supported by Windows Forms
Traditionally, data binding has been used within applications to take advantage of data stored in databases. With Windows Forms data binding, you can access data from databases as well as data in other structures, such as arrays and collections, so long as certain minimum requirements have been met.  
  
## Structures to Bind To  
 In Windows Forms, you can bind to a wide variety of structures, from simple objects (simple binding) to complex lists such as ADO.NET data tables (complex binding). For simple binding, Windows Forms supports binding to the public properties on the simple object. Windows Forms list-based binding generally requires that the object support the <xref:System.Collections.IList> interface or the <xref:System.ComponentModel.IListSource> interface. Additionally, if you are binding with through a <xref:System.Windows.Forms.BindingSource> component, you can bind to an object that supports the <xref:System.Collections.IEnumerable> interface. For more information about interfaces related to data binding, see [Interfaces Related to Data Binding](../../../docs/framework/winforms/interfaces-related-to-data-binding.md).  
  
 The following list shows the structures you can bind to in Windows Forms.  
  
 <xref:System.Windows.Forms.BindingSource>  
 A <xref:System.Windows.Forms.BindingSource> is the most common Windows Forms data source and acts a proxy between a data source and Windows Forms controls. The general <xref:System.Windows.Forms.BindingSource> usage pattern is to bind your controls to the <xref:System.Windows.Forms.BindingSource> and bind the <xref:System.Windows.Forms.BindingSource> to the data source (for example, an ADO.NET data table or a business object). The <xref:System.Windows.Forms.BindingSource> provides services that enable and improve the level of data binding support. For example, Windows Forms list based controls such as the <xref:System.Windows.Forms.DataGridView> and <xref:System.Windows.Forms.ComboBox> do not directly support binding to <xref:System.Collections.IEnumerable> data sources however, you can enable this scenario by binding through a <xref:System.Windows.Forms.BindingSource>. In this case, the <xref:System.Windows.Forms.BindingSource> will convert the data source to an <xref:System.Collections.IList>.  
  
 Simple objects  
 Windows Forms supports data binding control properties to public properties on the instance of an object using the <xref:System.Windows.Forms.Binding> type. Windows Forms also supports binding list based controls, such as a <xref:System.Windows.Forms.ListControl> to an object instance when a <xref:System.Windows.Forms.BindingSource> is used.  
  
 array or collection  
 To act as a data source, a list must implement the <xref:System.Collections.IList> interface; one example would be an array that is an instance of the <xref:System.Array> class. For more information on arrays, see [How to: Create an Array of Objects (Visual Basic)](http://msdn.microsoft.com/library/6b64e069-0387-400c-9081-3bdc581020c3).  
  
 In general, you should use <xref:System.ComponentModel.BindingList%601> when you create lists of objects for data binding. <xref:System.ComponentModel.BindingList%601> is a generic version of the <xref:System.ComponentModel.IBindingList> interface. The <xref:System.ComponentModel.IBindingList> interface extends the <xref:System.Collections.IList> interface by adding properties, methods and events necessary for two-way data binding.  
  
 <xref:System.Collections.IEnumerable>  
 Windows Forms controls can be bound to data sources that only support the <xref:System.Collections.IEnumerable> interface if they are bound through a <xref:System.Windows.Forms.BindingSource> component.  
  
 [!INCLUDE[vstecado](../../../includes/vstecado-md.md)] data objects  
 [!INCLUDE[vstecado](../../../includes/vstecado-md.md)] provides a number of data structures suitable for binding to. Each varies in its sophistication and complexity.  
  
-   <xref:System.Data.DataColumn>. A <xref:System.Data.DataColumn> is the essential building block of a <xref:System.Data.DataTable>, in that a number of columns comprise a table. Each <xref:System.Data.DataColumn> has a <xref:System.Data.DataColumn.DataType%2A> property that determines the kind of data the column holds (for example, the make of an automobile in a table describing cars). You can simple-bind a control (such as a <xref:System.Windows.Forms.TextBox> control's <xref:System.Windows.Forms.Control.Text%2A> property) to a column within a data table.  
  
-   <xref:System.Data.DataTable>. A <xref:System.Data.DataTable> is the representation of a table, with rows and columns, in [!INCLUDE[vstecado](../../../includes/vstecado-md.md)]. A data table contains two collections: <xref:System.Data.DataColumn>, representing the columns of data in a given table (which ultimately determine the kinds of data that can be entered into that table), and <xref:System.Data.DataRow>, representing the rows of data in a given table. You can complex-bind a control to the information contained in a data table (such as binding the <xref:System.Windows.Forms.DataGridView> control to a data table). However, when you bind to a <xref:System.Data.DataTable>, you are a really binding to the table's default view.  
  
-   <xref:System.Data.DataView>. A <xref:System.Data.DataView> is a customized view of a single data table that may be filtered or sorted. A data view is the data "snapshot" used by complex-bound controls. You can simple-bind or complex-bind to the data within a data view, but be aware that you are binding to a fixed "picture" of the data rather than a clean, updating data source.  
  
-   <xref:System.Data.DataSet>. A <xref:System.Data.DataSet> is a collection of tables, relationships, and constraints of the data in a database. You can simple-bind or complex-bind to the data within a dataset, but be aware that you are binding to the default <xref:System.Data.DataViewManager> for the <xref:System.Data.DataSet> (see the next bullet point).  
  
-   <xref:System.Data.DataViewManager>. A <xref:System.Data.DataViewManager> is a customized view of the entire <xref:System.Data.DataSet>, analogous to a <xref:System.Data.DataView>, but with relations included. With a <xref:System.Data.DataViewManager.DataViewSettings%2A> collection, you can set default filters and sort options for any views that the <xref:System.Data.DataViewManager> has for a given table.  
  
## See Also  
 [Change Notification in Windows Forms Data Binding](../../../docs/framework/winforms/change-notification-in-windows-forms-data-binding.md)  
 [Data Binding and Windows Forms](../../../docs/framework/winforms/data-binding-and-windows-forms.md)  
 [Windows Forms Data Binding](../../../docs/framework/winforms/windows-forms-data-binding.md)
