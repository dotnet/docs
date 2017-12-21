---
title: "RadioButton Control Overview (Windows Forms)"
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
  - "RadioButton"
helpviewer_keywords: 
  - "RadioButton control [Windows Forms], about RadioButton control"
  - "RadioButton control [Windows Forms], determining state"
  - "radio buttons [Windows Forms], determining state"
  - "radio buttons [Windows Forms], about radio buttons"
ms.assetid: cd11f0c2-d098-4022-adf9-1455bc166a13
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# RadioButton Control Overview (Windows Forms)
Windows Forms <xref:System.Windows.Forms.RadioButton> controls present a set of two or more mutually exclusive choices to the user. While radio buttons and check boxes may appear to function similarly, there is an important difference: when a user selects a radio button, the other radio buttons in the same group cannot be selected as well. In contrast, any number of check boxes can be selected. Defining a radio button group tells the user, "Here is a set of choices from which you can choose one and only one."  
  
## Using the Control  
 When a <xref:System.Windows.Forms.RadioButton> control is clicked, its <xref:System.Windows.Forms.RadioButton.Checked%2A> property is set to `true` and the <xref:System.Windows.Forms.Control.Click> event handler is called. The <xref:System.Windows.Forms.RadioButton.CheckedChanged> event is raised when the value of the <xref:System.Windows.Forms.RadioButton.Checked%2A> property changes. If the <xref:System.Windows.Forms.RadioButton.AutoCheck%2A> property is set to `true` (the default), when the radio button is selected all others in the group are automatically cleared. This property is usually only set to `false` when validation code is used to make sure the radio button selected is an allowable option. The text displayed within the control is set with the <xref:System.Windows.Forms.Control.Text%2A> property, which can contain access key shortcuts. An access key enables a user to "click" the control by pressing the ALT key with the access key. For more information, see [How to: Create Access Keys for Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-create-access-keys-for-windows-forms-controls.md) and [How to: Set the Text Displayed by a Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-set-the-text-displayed-by-a-windows-forms-control.md).  
  
 The <xref:System.Windows.Forms.RadioButton> control can appear like a command button, which appears to have been depressed if selected, if the <xref:System.Windows.Forms.RadioButton.Appearance%2A> property is set to <xref:System.Windows.Forms.Appearance.Button>. Radio buttons can also display images using the <xref:System.Windows.Forms.ButtonBase.Image%2A> and <xref:System.Windows.Forms.ButtonBase.ImageList%2A> properties. For more information, see [How to: Set the Image Displayed by a Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-set-the-image-displayed-by-a-windows-forms-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.RadioButton>  
 [Panel Control Overview](../../../../docs/framework/winforms/controls/panel-control-overview-windows-forms.md)  
 [GroupBox Control Overview](../../../../docs/framework/winforms/controls/groupbox-control-overview-windows-forms.md)  
 [CheckBox Control Overview](../../../../docs/framework/winforms/controls/checkbox-control-overview-windows-forms.md)  
 [How to: Create Access Keys for Windows Forms Controls](../../../../docs/framework/winforms/controls/how-to-create-access-keys-for-windows-forms-controls.md)  
 [How to: Set the Text Displayed by a Windows Forms Control](../../../../docs/framework/winforms/controls/how-to-set-the-text-displayed-by-a-windows-forms-control.md)  
 [How to: Group Windows Forms RadioButton Controls to Function as a Set](../../../../docs/framework/winforms/controls/how-to-group-windows-forms-radiobutton-controls-to-function-as-a-set.md)  
 [RadioButton Control](../../../../docs/framework/winforms/controls/radiobutton-control-windows-forms.md)
