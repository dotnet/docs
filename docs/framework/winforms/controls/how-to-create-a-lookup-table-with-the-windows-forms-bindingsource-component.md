---
title: "How to: Create a Lookup Table with the Windows Forms BindingSource Component"
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
  - "lookup tables"
  - "tables [Windows Forms], creating lookup tables"
  - "BindingSource component [Windows Forms], creating a lookup table"
  - "BindingSource component [Windows Forms], examples"
ms.assetid: 622fce80-879d-44be-abbf-8350ec22ca2b
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Lookup Table with the Windows Forms BindingSource Component
A lookup table is a table of data that has a column that displays data from records in a related table. In the following procedures, a <xref:System.Windows.Forms.ComboBox> control is used to display the field with the foreign-key relationship from the parent to the child table.  
  
 To help visualize these two tables and this relationship, here is an example of a parent and child table:  
  
 CustomersTable (parent table)  
  
|CustomerID|CustomerName|  
|----------------|------------------|  
|712|Paul Koch|  
|713|Tamara Johnston|  
  
 OrdersTable (child table)  
  
|OrderID|OrderDate|CustomerID|  
|-------------|---------------|----------------|  
|903|February 12, 2004|712|  
|904|February 13, 2004|713|  
  
 In this scenario, one table, CustomersTable, stores the actual information you want to display and save. But to save space, the table leaves out data that adds clarity. The other table, OrdersTable, contains only appearance-related information about which customer ID number is equivalent to which order date and order ID. There is no mention of the customers' names.  
  
 Four important properties are set on the [ComboBox Control](../../../../docs/framework/winforms/controls/combobox-control-windows-forms.md) control to create the lookup table.  
  
-   The <xref:System.Windows.Forms.ComboBox.DataSource%2A> property contains the name of the table.  
  
-   The <xref:System.Windows.Forms.ListControl.DisplayMember%2A> property contains the data column of that table that you want to display for the control text (the customer's name).  
  
-   The <xref:System.Windows.Forms.ListControl.ValueMember%2A> property contains the data column of that table with the stored information (the ID number in the parent table).  
  
-   The <xref:System.Windows.Forms.ListControl.SelectedValue%2A> property provides the lookup value for the child table, based on the <xref:System.Windows.Forms.ListControl.ValueMember%2A>.  
  
 The procedures below show you how to lay out your form as a lookup table and bind data to the controls on it. To successfully complete the procedures, you must have a data source with parent and child tables that have a foreign-key relationship, as mentioned previously.  
  
### To create the user interface  
  
1.  From the **ToolBox**, drag a <xref:System.Windows.Forms.ComboBox> control onto the form.  
  
     This control will display the column from parent table.  
  
2.  Drag other controls to display details from the child table. The format of the data in the table should determine which controls you choose. For more information, see [Windows Forms Controls by Function](../../../../docs/framework/winforms/controls/windows-forms-controls-by-function.md).  
  
3.  Drag a <xref:System.Windows.Forms.BindingNavigator> control onto the form; this will allow you to navigate the data in the child table.  
  
### To connect to the data and bind it to controls  
  
1.  Select the <xref:System.Windows.Forms.ComboBox> and click the Smart Task glyph to display the Smart Task dialog box.  
  
2.  Select **Use data bound items**.  
  
3.  Click the arrow next to the **Data Source** drop-down box. If a data source has previously been configured for the project or form, it will appear; otherwise, complete the following steps (This example uses the Customers and Orders tables of the Northwind sample database and refers to them in parentheses).  
  
    1.  Click **Add Project Data Source** to connect to data and create a data source.  
  
    2.  On the **Data Source Configuration Wizard** welcome page, click **Next**.  
  
    3.  Select **Database** on the **Choose a Data Source Type** page.  
  
    4.  Select a data connection from the list of available connections on the **Choose Your Data Connection** page. If your desired data connection is not available, select **New Connection** to create a new data connection.  
  
    5.  Click **Yes, save the connection** to save the connection string in the application configuration file.  
  
    6.  Select the database objects to bring into your application. In this case, select a parent table and child table (for example, Customers and Orders) with a foreign key relationship.  
  
    7.  Replace the default dataset name if you want.  
  
    8.  Click **Finish**.  
  
4.  In the **Display Member** drop-down box, select the column name (for example, ContactName) to be displayed in the combo box.  
  
5.  In the **Value Member** drop-down box, select the column (for example, CustomerID) to perform the lookup operation in the child table.  
  
6.  In the **Selected Value** drop-down box, navigate to **Project Data Sources** and the dataset you just created that contains the parent and child tables. Select the same property of the child table that is the Value Member of the parent table (for example, Orders.CustomerID). The appropriate <xref:System.Windows.Forms.BindingSource> , data set, and table adapter components will be created and added to the form.  
  
7.  Bind the <xref:System.Windows.Forms.BindingNavigator> control to the <xref:System.Windows.Forms.BindingSource> of the child table (for example, `OrdersBindingSource`).  
  
8.  Bind the controls other than the <xref:System.Windows.Forms.ComboBox> and <xref:System.Windows.Forms.BindingNavigator> control to the details fields from the child table's <xref:System.Windows.Forms.BindingSource> (for example, `OrdersBindingSource`) that you want to display.  
  
## See Also  
 <xref:System.Windows.Forms.BindingSource>  
 [BindingSource Component](../../../../docs/framework/winforms/controls/bindingsource-component.md)  
 [ComboBox Control](../../../../docs/framework/winforms/controls/combobox-control-windows-forms.md)  
 [Bind controls to data in Visual Studio](/visualstudio/data-tools/bind-controls-to-data-in-visual-studio)
