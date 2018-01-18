---
title: "ListBox Control Overview (Windows Forms)"
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
  - "ListBox"
helpviewer_keywords: 
  - "list boxes [Windows Forms], about list boxes"
  - "ListBox control [Windows Forms], about ListBox control"
ms.assetid: 37ea226b-6fc8-4c70-936a-c6af4e0cad4c
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ListBox Control Overview (Windows Forms)
A Windows Forms <xref:System.Windows.Forms.ListBox> control displays a list from which the user can select one or more items. If the total number of items exceeds the number that can be displayed, a scroll bar is automatically added to the <xref:System.Windows.Forms.ListBox> control. When the <xref:System.Windows.Forms.ListBox.MultiColumn%2A> property is set to `true`, the list box displays items in multiple columns and a horizontal scroll bar appears. When the <xref:System.Windows.Forms.ListBox.MultiColumn%2A> property is set to `false`, the list box displays items in a single column and a vertical scroll bar appears. When <xref:System.Windows.Forms.ListBox.ScrollAlwaysVisible%2A> is set to `true`, the scroll bar appears regardless of the number of items. The <xref:System.Windows.Forms.ListBox.SelectionMode%2A> property determines how many list items can be selected at a time.  
  
## Ways to Change the ListBox Control  
 The <xref:System.Windows.Forms.ListBox.SelectedIndex%2A> property returns an integer value that corresponds to the first selected item in the list box. You can programmatically change the selected item by changing the <xref:System.Windows.Forms.ListBox.SelectedIndex%2A> value in code; the corresponding item in the list will appear highlighted on the Windows Form. If no item is selected, the <xref:System.Windows.Forms.ListBox.SelectedIndex%2A> value is -1. If the first item in the list is selected, the <xref:System.Windows.Forms.ListBox.SelectedIndex%2A> value is 0. When multiple items are selected, the <xref:System.Windows.Forms.ListBox.SelectedIndex%2A> value reflects the selected item that appears first in the list. The <xref:System.Windows.Forms.ListBox.SelectedItem%2A> property is similar to <xref:System.Windows.Forms.ListBox.SelectedIndex%2A>, but returns the item itself, usually a string value. The <xref:System.Windows.Forms.ListBox.ObjectCollection.Count%2A> property reflects the number of items in the list, and the value of the <xref:System.Windows.Forms.ListBox.ObjectCollection.Count%2A> property is always one more than the largest possible <xref:System.Windows.Forms.ListBox.SelectedIndex%2A> value because <xref:System.Windows.Forms.ListBox.SelectedIndex%2A> is zero-based.  
  
 To add or delete items in a <xref:System.Windows.Forms.ListBox> control, use the <xref:System.Windows.Forms.ListBox.ObjectCollection.Add%2A>, <xref:System.Windows.Forms.ListBox.ObjectCollection.Insert%2A>, <xref:System.Windows.Forms.ListBox.ObjectCollection.Clear%2A> or <xref:System.Windows.Forms.ListBox.ObjectCollection.Remove%2A> method. Alternatively, you can add items to the list by using the <xref:System.Windows.Forms.ListBox.Items%2A> property at design time.  
  
## See Also  
 <xref:System.Windows.Forms.ListBox>  
 [How to: Add and Remove Items from a Windows Forms ComboBox, ListBox, or CheckedListBox Control](../../../../docs/framework/winforms/controls/add-and-remove-items-from-a-wf-combobox.md)  
 [How to: Sort the Contents of a Windows Forms ComboBox, ListBox, or CheckedListBox Control](../../../../docs/framework/winforms/controls/sort-the-contents-of-a-wf-combobox-listbox-or-checkedlistbox-control.md)  
 [How to: Bind a Windows Forms ComboBox or ListBox Control to Data](../../../../docs/framework/winforms/controls/how-to-bind-a-windows-forms-combobox-or-listbox-control-to-data.md)  
 [ComboBox Control Overview](../../../../docs/framework/winforms/controls/combobox-control-overview-windows-forms.md)  
 [CheckedListBox Control Overview](../../../../docs/framework/winforms/controls/checkedlistbox-control-overview-windows-forms.md)  
 [Windows Forms Controls Used to List Options](../../../../docs/framework/winforms/controls/windows-forms-controls-used-to-list-options.md)  
 [How to: Create a Lookup Table for a Windows Forms ComboBox, ListBox, or CheckedListBox Control](../../../../docs/framework/winforms/controls/create-a-lookup-table-for-a-wf-combobox-listbox.md)
