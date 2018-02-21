---
title: "When to Use a Windows Forms ComboBox Instead of a ListBox"
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
  - "ListBox control [Windows Forms], adding and removing items"
  - "ListBox control [Windows Forms], vs. ComboBox"
  - "bound controls [Windows Forms], combo boxes"
  - "Windows Forms controls, data binding"
  - "ComboBox control [Windows Forms], compared to ListBox"
  - "combo boxes [Windows Forms], compared to list boxes"
  - "ListBox control [Windows Forms], accessing items"
  - "ListCount property"
ms.assetid: 7bcaea58-1cfa-46db-9baf-b75a69d8f9ec
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# When to Use a Windows Forms ComboBox Instead of a ListBox
The <xref:System.Windows.Forms.ComboBox> and the <xref:System.Windows.Forms.ListBox> controls have similar behaviors, and in some cases may be interchangeable. There are times, however, when one or the other is more appropriate to a task.  
  
 Generally, a combo box is appropriate when there is a list of suggested choices, and a list box is appropriate when you want to limit input to what is on the list. A combo box contains a text box field, so choices not on the list can be typed in. The exception is when the <xref:System.Windows.Forms.ComboBox.DropDownStyle%2A> property is set to <xref:System.Windows.Forms.ComboBoxStyle.DropDownList>. In that case, the control will select an item if you type its first letter.  
  
 In addition, combo boxes save space on a form. Because the full list is not displayed until the user clicks the down arrow, a combo box can easily fit in a small space where a list box would not fit. An exception is when the <xref:System.Windows.Forms.ComboBox.DropDownStyle%2A> property is set to <xref:System.Windows.Forms.ComboBoxStyle.Simple>: the full list is displayed, and the combo box takes up more room than a list box would.  
  
## See Also  
 <xref:System.Windows.Forms.ComboBox>  
 <xref:System.Windows.Forms.ListBox>  
 [How to: Add and Remove Items from a Windows Forms ComboBox, ListBox, or CheckedListBox Control](../../../../docs/framework/winforms/controls/add-and-remove-items-from-a-wf-combobox.md)  
 [How to: Sort the Contents of a Windows Forms ComboBox, ListBox, or CheckedListBox Control](../../../../docs/framework/winforms/controls/sort-the-contents-of-a-wf-combobox-listbox-or-checkedlistbox-control.md)  
 [Windows Forms Controls Used to List Options](../../../../docs/framework/winforms/controls/windows-forms-controls-used-to-list-options.md)
