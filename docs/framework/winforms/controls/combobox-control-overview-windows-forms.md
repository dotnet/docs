---
title: "ComboBox Control Overview (Windows Forms)"
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
  - "ComboBox"
helpviewer_keywords: 
  - "drop-down lists [Windows Forms], Windows Forms"
  - "ComboBox control [Windows Forms], about ComboBox control"
  - "drop-down lists [Windows Forms], ComboBox control"
  - "combo boxes [Windows Forms], about combo boxes"
ms.assetid: a58b393f-a614-45d1-8961-857a024b5acd
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ComboBox Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.ComboBox> control is used to display data in a drop-down combo box. By default, the <xref:System.Windows.Forms.ComboBox> control appears in two parts: the top part is a text box that allows the user to type a list item. The second part is a list box that displays a list of items from which the user can select one. For more information on other styles of combo box, see [When to Use a Windows Forms ComboBox Instead of a ListBox](../../../../docs/framework/winforms/controls/when-to-use-a-windows-forms-combobox-instead-of-a-listbox.md).  
  
 The <xref:System.Windows.Forms.ComboBox.SelectedIndex%2A> property returns an integer value that corresponds to the selected list item. You can programmatically change the selected item by changing the <xref:System.Windows.Forms.ComboBox.SelectedIndex%2A> value in code; the corresponding item in the list will appear in the text box portion of the combo box. If no item is selected, the <xref:System.Windows.Forms.ComboBox.SelectedIndex%2A> value is -1. If the first item in the list is selected, then the <xref:System.Windows.Forms.ComboBox.SelectedIndex%2A> value is 0. The <xref:System.Windows.Forms.ComboBox.SelectedItem%2A> property is similar to <xref:System.Windows.Forms.ComboBox.SelectedIndex%2A> , but returns the item itself, usually a string value. The <xref:System.Windows.Forms.ComboBox.ObjectCollection.Count%2A> property reflects the number of items in the list, and the value of the <xref:System.Windows.Forms.ComboBox.ObjectCollection.Count%2A> property is always one more than the largest possible <xref:System.Windows.Forms.ComboBox.SelectedIndex%2A> value because <xref:System.Windows.Forms.ComboBox.SelectedIndex%2A> is zero-based.  
  
 To add or delete items in a <xref:System.Windows.Forms.ComboBox> control, use the <xref:System.Windows.Forms.ComboBox.ObjectCollection.Add%2A>, <xref:System.Windows.Forms.ComboBox.ObjectCollection.Insert%2A>, <xref:System.Windows.Forms.ComboBox.ObjectCollection.Clear%2A> or <xref:System.Windows.Forms.ComboBox.ObjectCollection.Remove%2A> method. Alternatively, you can add items to the list by using the <xref:System.Windows.Forms.ComboBox.Items%2A> property in the designer.  
  
## See Also  
 <xref:System.Windows.Forms.ComboBox>  
 [ListBox Control Overview](../../../../docs/framework/winforms/controls/listbox-control-overview-windows-forms.md)  
 [When to Use a Windows Forms ComboBox Instead of a ListBox](../../../../docs/framework/winforms/controls/when-to-use-a-windows-forms-combobox-instead-of-a-listbox.md)  
 [How to: Add and Remove Items from a Windows Forms ComboBox, ListBox, or CheckedListBox Control](../../../../docs/framework/winforms/controls/add-and-remove-items-from-a-wf-combobox.md)  
 [How to: Sort the Contents of a Windows Forms ComboBox, ListBox, or CheckedListBox Control](../../../../docs/framework/winforms/controls/sort-the-contents-of-a-wf-combobox-listbox-or-checkedlistbox-control.md)  
 [How to: Access Specific Items in a Windows Forms ComboBox, ListBox, or CheckedListBox Control](../../../../docs/framework/winforms/controls/access-specific-items-in-a-wf-combobox-listbox-or-checkedlistbox.md)  
 [How to: Bind a Windows Forms ComboBox or ListBox Control to Data](../../../../docs/framework/winforms/controls/how-to-bind-a-windows-forms-combobox-or-listbox-control-to-data.md)  
 [Windows Forms Controls Used to List Options](../../../../docs/framework/winforms/controls/windows-forms-controls-used-to-list-options.md)  
 [How to: Create a Lookup Table for a Windows Forms ComboBox, ListBox, or CheckedListBox Control](../../../../docs/framework/winforms/controls/create-a-lookup-table-for-a-wf-combobox-listbox.md)
