---
title: "How to: Create a Lookup Table for a Windows Forms ComboBox, ListBox, or CheckedListBox Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "CheckedListBox control [Windows Forms], creating lookup tables"
  - "lookup tables"
  - "list boxes [Windows Forms], lookup tables"
  - "ListBox control [Windows Forms], lookup tables"
  - "ComboBox control [Windows Forms], lookup table"
  - "lookup tables [Windows Forms], creating for controls"
  - "combo boxes [Windows Forms], lookup tables"
  - "ListBox control [Windows Forms], creating lookup tables"
ms.assetid: 4ce35f12-1f4e-4317-92d1-af8686a8cfaa
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Lookup Table for a Windows Forms ComboBox, ListBox, or CheckedListBox Control
Sometimes it is useful to display data in a user-friendly format on a Windows Form, but store the data in a format that is more meaningful to your program. For example, an order form for food might display the menu items by name in a list box. However, the data table recording the order would contain the unique ID numbers representing the food. The following tables show an example of how to store and display order-form data for food.  
  
### OrderDetailsTable  
  
|OrderID|ItemID|Quantity|  
|-------------|------------|--------------|  
|4085|12|1|  
|4086|13|3|  
  
### ItemTable  
  
|ID|Name|  
|--------|----------|  
|12|Potato|  
|13|Chicken|  
  
 In this scenario, one table, **OrderDetailsTable**, stores the actual information you are concerned with displaying and saving. But to save space, it does so in a fairly cryptic fashion. The other table, **ItemTable**, contains only appearance-related information about which ID number is equivalent to which food name, and nothing about the actual food orders.  
  
 The **ItemTable** is connected to the <xref:System.Windows.Forms.ComboBox>, <xref:System.Windows.Forms.ListBox>, or <xref:System.Windows.Forms.CheckedListBox> control through three properties. The `DataSource` property contains the name of this table. The `DisplayMember` property contains the data column of that table that you want to display in the control (the food name). The `ValueMember` property contains the data column of that table with the stored information (the ID number).  
  
 The **OrderDetailsTable** is connected to the control by its bindings collection, accessed through the <xref:System.Windows.Forms.Control.DataBindings%2A> property. When you add a binding object to the collection, you connect a control property to a specific data member (the column of ID numbers) in a data source (the **OrderDetailsTable**). When a selection is made in the control, this table is where the form input is saved.  
  
### To create a lookup table  
  
1.  Add a <xref:System.Windows.Forms.ComboBox>, <xref:System.Windows.Forms.ListBox>, or <xref:System.Windows.Forms.CheckedListBox> control to the form.  
  
2.  Connect to your data source.  
  
3.  Establish a data relation between the two tables. See [Introduction to DataRelation Objects](http://msdn.microsoft.com/library/89d8a881-8265-41f2-a88b-61311ab06192).  
  
4.  Set the following properties. They can be set in code or in the designer.  
  
    |Property|Setting|  
    |--------------|-------------|  
    |<xref:System.Windows.Forms.ListControl.DataSource%2A>|The table that contains information about which ID number is equivalent to which item. In the previous scenario, this is `ItemTable`.|  
    |<xref:System.Windows.Forms.ListControl.DisplayMember%2A>|The column of the data source table that you want to display in the control. In the previous scenario, this is `"Name"` (to set in code, use quotation marks).|  
    |<xref:System.Windows.Forms.ListControl.ValueMember%2A>|The column of the data source table that contains the stored information. In the previous scenario, this is `"ID"` (to set in code, use quotation marks).|  
  
5.  In a procedure, call the <xref:System.Windows.Forms.ControlBindingsCollection.Add%2A> method of the <xref:System.Windows.Forms.ControlBindingsCollection> class to bind the control's <xref:System.Windows.Forms.ListControl.SelectedValue%2A> property to the table recording the form input. You can also do this in the Designer instead of in code, by accessing the control's <xref:System.Windows.Forms.Control.DataBindings%2A> property in the **Properties** window. In the previous scenario, this is `OrderDetailsTable`, and the column is `"ItemID"`.  
  
    ```vb  
    ListBox1.DataBindings.Add("SelectedValue", OrderDetailsTable, "ItemID")  
    ```  
  
    ```csharp  
    listBox1.DataBindings.Add("SelectedValue", OrderDetailsTable, "ItemID");  
    ```  
  
## See Also  
 [Data Binding and Windows Forms](../../../../docs/framework/winforms/data-binding-and-windows-forms.md)  
 [ListBox Control Overview](../../../../docs/framework/winforms/controls/listbox-control-overview-windows-forms.md)  
 [ComboBox Control Overview](../../../../docs/framework/winforms/controls/combobox-control-overview-windows-forms.md)  
 [CheckedListBox Control Overview](../../../../docs/framework/winforms/controls/checkedlistbox-control-overview-windows-forms.md)  
 [Windows Forms Controls Used to List Options](../../../../docs/framework/winforms/controls/windows-forms-controls-used-to-list-options.md)
