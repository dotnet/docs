---
title: "CheckBox Control Overview (Windows Forms)"
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
  - "CheckBox"
helpviewer_keywords: 
  - "CheckBox control [Windows Forms], about CheckBox control"
  - "data binding [Windows Forms], checkbox controls"
  - "check boxes [Windows Forms], about check boxes"
ms.assetid: 085a4e0b-9046-473f-b141-d0edddfb2ebb
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# CheckBox Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.CheckBox> control indicates whether a particular condition is on or off. It is commonly used to present a Yes/No or True/False selection to the user. You can use check box controls in groups to display multiple choices from which the user can select one or more.  
  
 The check box control is similar to the radio button control in that each is used to indicate a selection that is made by the user. They differ in that only one radio button in a group can be selected at a time. With the check box control, however, any number of check boxes may be selected.  
  
 A check box may be connected to elements in a database using simple data binding. Multiple check boxes may be grouped using the <xref:System.Windows.Forms.GroupBox> control. This is useful for visual appearance and also for user interface design, since grouped controls can be moved around together on the form designer. For more information, see [Windows Forms Data Binding](../../../../docs/framework/winforms/windows-forms-data-binding.md) and [GroupBox Control](../../../../docs/framework/winforms/controls/groupbox-control-windows-forms.md).  
  
 The <xref:System.Windows.Forms.CheckBox> control has two important properties, <xref:System.Windows.Forms.CheckBox.Checked%2A> and <xref:System.Windows.Forms.CheckBox.CheckState%2A>. The <xref:System.Windows.Forms.CheckBox.Checked%2A> property returns either `true` or `false`. The <xref:System.Windows.Forms.CheckBox.CheckState%2A> property returns either <xref:System.Windows.Forms.CheckState.Checked> or <xref:System.Windows.Forms.CheckState.Unchecked>; or, if the <xref:System.Windows.Forms.CheckBox.ThreeState%2A> property is set to `true`, <xref:System.Windows.Forms.CheckBox.CheckState%2A> may also return <xref:System.Windows.Forms.CheckState.Indeterminate>. In the indeterminate state, the box is displayed with a dimmed appearance to indicate the option is unavailable.  
  
## See Also  
 <xref:System.Windows.Forms.CheckBox>  
 [How to: Set Options with Windows Forms CheckBox Controls](../../../../docs/framework/winforms/controls/how-to-set-options-with-windows-forms-checkbox-controls.md)  
 [How to: Respond to Windows Forms CheckBox Clicks](../../../../docs/framework/winforms/controls/how-to-respond-to-windows-forms-checkbox-clicks.md)  
 [CheckBox Control](../../../../docs/framework/winforms/controls/checkbox-control-windows-forms.md)
