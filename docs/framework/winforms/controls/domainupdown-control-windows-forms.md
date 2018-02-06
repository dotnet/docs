---
title: "DomainUpDown Control (Windows Forms)"
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
  - "DomainUpDown control [Windows Forms]"
  - "spin button control [Windows Forms], up-down controls"
  - "up-down controls"
  - "spin button control"
  - "up-down controls [Windows Forms], spin button controls"
ms.assetid: fb7cf017-e931-4a95-9d21-8caee4ee122a
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DomainUpDown Control (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.DomainUpDown> control looks like a combination of a text box and a pair of buttons for moving up or down through a list. The control displays and sets a text string from a list of choices. The user can select the string by clicking up and down buttons to move through a list, by pressing the UP and DOWN ARROW keys, or by typing a string that matches an item in the list. One possible use for this control is for selecting items from an alphabetically sorted list of names. (To sort the list, set the <xref:System.Windows.Forms.DomainUpDown.Sorted%2A> property to `true`.) The function of this control is very similar to the list box or combo box, but it takes up very little space.  
  
 The key properties of the control are <xref:System.Windows.Forms.DomainUpDown.Items%2A>, <xref:System.Windows.Forms.UpDownBase.ReadOnly%2A>, and <xref:System.Windows.Forms.DomainUpDown.Wrap%2A>. The <xref:System.Windows.Forms.DomainUpDown.Items%2A> property contains the list of objects whose text values are displayed in the control. If <xref:System.Windows.Forms.UpDownBase.ReadOnly%2A> is set to `false`, the control automatically completes text that the user types and matches it to a value in the list. If <xref:System.Windows.Forms.DomainUpDown.Wrap%2A> is set to `true`, scrolling past the last item will take you to the first item in the list and vice versa. The key methods of the control are <xref:System.Windows.Forms.DomainUpDown.UpButton%2A> and <xref:System.Windows.Forms.DomainUpDown.DownButton%2A>.  
  
 This control displays only text strings. If you want a control that displays numeric values, use the <xref:System.Windows.Forms.NumericUpDown> control. For more information, see [NumericUpDown Control](../../../../docs/framework/winforms/controls/numericupdown-control-windows-forms.md) .  
  
## In This Section  
 [DomainUpDown Control Overview](../../../../docs/framework/winforms/controls/domainupdown-control-overview-windows-forms.md)  
 Introduces the general concepts of the <xref:System.Windows.Forms.DomainUpDown> control, which allows users to browse through and select from a list of text strings.  
  
 [How to: Add Items to Windows Forms DomainUpDown Controls Programmatically](../../../../docs/framework/winforms/controls/how-to-add-items-to-windows-forms-domainupdown-controls-programmatically.md)  
 Describes how to specify the text strings the <xref:System.Windows.Forms.DomainUpDown> control should display.  
  
 [How to: Remove Items from Windows Forms DomainUpDown Controls](../../../../docs/framework/winforms/controls/how-to-remove-items-from-windows-forms-domainupdown-controls.md)  
 Describes how to delete items from the <xref:System.Windows.Forms.DomainUpDown> control in code.  
  
## Reference  
 <xref:System.Windows.Forms.DomainUpDown>  
 Describes this class and has links to all its members.  
  
 <xref:System.Windows.Forms.NumericUpDown>  
 Describes this class and has links to all its members..  
  
## Related Sections  
 [Controls You Can Use On Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)  
 Provides a complete list of Windows Forms controls, with links to information on their use.
