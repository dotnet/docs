---
title: "NumericUpDown Control Overview (Windows Forms)"
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
  - "NumericUpDown"
helpviewer_keywords: 
  - "numeric spin button control [Windows Forms], Windows Forms"
  - "NumericUpDown control [Windows Forms], about NumericUpDown control"
  - "spin button control [Windows Forms], Windows Forms"
ms.assetid: cff3cf30-4d46-4381-87df-37bfe83c71c5
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# NumericUpDown Control Overview (Windows Forms)
The <xref:System.Windows.Forms.NumericUpDown> control looks like a combination of a text box and a pair of arrows that the user can click to adjust a value. The control displays and sets a single numeric value from a list of fixed numeric-value choices. The user can increase and decrease the number by clicking the up and down arrows, by pressing the UP and DOWN ARROW keys, or by typing a number in the text box part of the control. Clicking the UP ARROW key moves the number toward the maximum; clicking the DOWN ARROW key moves the number toward the minimum.  
  
 Because of its versatile functionality, this control is an obvious choice, for example, if you want to create a volume control for a music player application. The <xref:System.Windows.Forms.NumericUpDown> control is used in many Windows Control Panel applications.  
  
## Key Properties and Methods  
 The numbers displayed in the control's text box can be in a variety of formats, including hexadecimal. For more information, see [How to: Set the Format for the Windows Forms NumericUpDown Control](../../../../docs/framework/winforms/controls/how-to-set-the-format-for-the-windows-forms-numericupdown-control.md). The key properties of the control are <xref:System.Windows.Forms.NumericUpDown.Value%2A>, <xref:System.Windows.Forms.NumericUpDown.Maximum%2A> (default value 100), <xref:System.Windows.Forms.NumericUpDown.Minimum%2A> (default value 0), and <xref:System.Windows.Forms.NumericUpDown.Increment%2A> (default value 1). The <xref:System.Windows.Forms.NumericUpDown.Value%2A> property sets the current number selected in the control. The <xref:System.Windows.Forms.NumericUpDown.Increment%2A> property sets the amount that the number is adjusted by when the user clicks an up or down arrow. When focus moves off the control, any typed input will be validated against the minimum and maximum numeric values. You can increase the speed that the control moves through numbers, when the user continuously presses the up or down arrow, with the <xref:System.Windows.Forms.NumericUpDown.Accelerations%2A> property. The key methods of the control are <xref:System.Windows.Forms.NumericUpDown.UpButton%2A> and <xref:System.Windows.Forms.NumericUpDown.DownButton%2A>.  
  
## See Also  
 <xref:System.Windows.Forms.NumericUpDown>  
 [NumericUpDown Control](../../../../docs/framework/winforms/controls/numericupdown-control-windows-forms.md)  
 [How to: Set the Format for the Windows Forms NumericUpDown Control](../../../../docs/framework/winforms/controls/how-to-set-the-format-for-the-windows-forms-numericupdown-control.md)  
 [TextBox Control](../../../../docs/framework/winforms/controls/textbox-control-windows-forms.md)
