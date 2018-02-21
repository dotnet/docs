---
title: "Data Binding and Windows Forms"
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
  - "master-details lists"
  - "data [Windows Forms], data binding"
  - "reports [Windows Forms], Windows Forms"
  - "lookup tables [Windows Forms], data binding"
  - "data [Windows Forms], complex data binding"
  - "data binding [Windows Forms], Windows Forms"
  - "data [Windows Forms], simple data binding"
  - "Windows Forms controls, data binding"
  - "data-bound controls [Windows Forms], Windows Forms"
ms.assetid: 419aac5e-819b-4aad-88b0-73a2f8c0bd27
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Data Binding and Windows Forms
In Windows Forms, you can bind to not just traditional data sources, but also to almost any structure that contains data. You can bind to an array of values that you calculate at run time, read from a file, or derive from the values of other controls.  
  
 In addition, you can bind any property of any control to the data source. In traditional data binding, you typically bind the display property—for example, the <xref:System.Windows.Forms.Control.Text%2A> property of a <xref:System.Windows.Forms.TextBox> control—to the data source. With the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)], you also have the option of setting other properties through binding as well. You might use binding to perform the following tasks:  
  
-   Setting the graphic of an image control.  
  
-   Setting the background color of one or more controls.  
  
-   Setting the size of controls.  
  
 Essentially, data binding is an automatic way of setting any run-time accessible property of any control on a form.  
  
## Types of Data Binding  
 Windows Forms can take advantage of two types of data binding: simple binding and complex binding. Each offers different advantages.  
  
|Type of data binding|Description|  
|--------------------------|-----------------|  
|Simple data binding|The ability of a control to bind to a single data element, such as a value in a column in a dataset table. This is the type of binding typical for controls such as a <xref:System.Windows.Forms.TextBox> control or <xref:System.Windows.Forms.Label> control, which are controls that typically only displays a single value. In fact, any property on a control can be bound to a field in a database. There is extensive support for this feature in [!INCLUDE[vsprvs](../../../includes/vsprvs-md.md)].<br /><br /> For more information, see:<br /><br /> -   [Interfaces Related to Data Binding](../../../docs/framework/winforms/interfaces-related-to-data-binding.md)<br />-   [How to: Navigate Data in Windows Forms](../../../docs/framework/winforms/how-to-navigate-data-in-windows-forms.md)<br />-   [How to: Create a Simple-Bound Control on a Windows Form](../../../docs/framework/winforms/how-to-create-a-simple-bound-control-on-a-windows-form.md)|  
|Complex data binding|The ability of a control to bind to more than one data element, typically more than one record in a database. Complex binding is also called list-based binding. Examples of controls that support complex binding are the <xref:System.Windows.Forms.DataGridView>, <xref:System.Windows.Forms.ListBox>, and <xref:System.Windows.Forms.ComboBox> controls. For an example of complex data binding, see [How to: Bind a Windows Forms ComboBox or ListBox Control to Data](../../../docs/framework/winforms/controls/how-to-bind-a-windows-forms-combobox-or-listbox-control-to-data.md).|  
  
## BindingSource Component  
 To simplify data binding, Windows Forms enables you to bind a data source to the <xref:System.Windows.Forms.BindingSource> component and then bind controls to the <xref:System.Windows.Forms.BindingSource>. You can use the <xref:System.Windows.Forms.BindingSource> in simple or complex binding scenarios. In either case, the <xref:System.Windows.Forms.BindingSource> acts as an intermediary between the data source and bound controls providing change notification currency management and other services.  
  
## Common Scenarios That Employ Data Binding  
 Nearly every commercial application uses information read from data sources of one type or another, usually through data binding. The following list shows a few of the most common scenarios that utilize data binding as the method of data presentation and manipulation.  
  
|Scenario|Description|  
|--------------|-----------------|  
|Reporting|Reports provide a flexible way for you to display and summarize your data in a printed document. It is very common to create a report that prints selected contents of a data source either to the screen or to a printer. Common reports include lists, invoices, and summaries. Items are usually formatted into columns of lists, with sub-items organized under each list item, but you should choose the layout that best suits the data.|  
|Data entry|A common way to enter large amounts of related data or to prompt users for information is through a data entry form. Users can enter information or select choices using text boxes, option buttons, drop-down lists, and check boxes. Information is then submitted and stored in a database, whose structure is based on the information entered.|  
|Master/detail relationship|A master/detail application is one format for looking at related data. Specifically, there are two tables of data with a relation connecting them—in the classic business example, a "Customers" table and an "Orders" table with a relationship between them linking customers and their respective orders. For more information about creating a master/detail application with two Windows Forms <xref:System.Windows.Forms.DataGridView> controls, see [How to: Create a Master/Detail Form Using Two Windows Forms DataGridView Controls](../../../docs/framework/winforms/controls/create-a-master-detail-form-using-two-datagridviews.md)|  
|Lookup Table|Another common data presentation/manipulation scenario is the table lookup. Often, as part of a larger data display, a <xref:System.Windows.Forms.ComboBox> control is used to display and manipulate data. The key is that the data displayed in the <xref:System.Windows.Forms.ComboBox> control is different than the data written to the database. For example, if you have a <xref:System.Windows.Forms.ComboBox> control displaying the items available from a grocery store, you would probably like to see the names of the products (bread, milk, eggs). However, to ease information retrieval within the database and for database normalization, you would probably store the information for the specific items of a given order as item numbers (#501, #603, and so on). Thus, there is an implicit connection between the "friendly name" of the grocery item in the <xref:System.Windows.Forms.ComboBox> control on your form and the related item number that is present in an order. This is the essence of a table lookup. For more information, see [How to: Create a Lookup Table with the Windows Forms BindingSource Component](../../../docs/framework/winforms/controls/how-to-create-a-lookup-table-with-the-windows-forms-bindingsource-component.md).|  
  
## See Also  
 <xref:System.Windows.Forms.Binding>  
 [Windows Forms Data Binding](../../../docs/framework/winforms/windows-forms-data-binding.md)  
 [How to: Bind the Windows Forms DataGrid Control to a Data Source](../../../docs/framework/winforms/controls/how-to-bind-the-windows-forms-datagrid-control-to-a-data-source.md)  
 [BindingSource Component](../../../docs/framework/winforms/controls/bindingsource-component.md)
