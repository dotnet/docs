---
title: "ToolTip Component Overview (Windows Forms)"
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
  - "ToolTip"
helpviewer_keywords: 
  - "tooltips [Windows Forms], about tooltips"
  - "ToolTip component [Windows Forms], about ToolTip component"
ms.assetid: 3fbc6f08-c882-4acd-a960-a08efe3c7e6e
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ToolTip Component Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.ToolTip> component displays text when the user points at controls. A ToolTip can be associated with any control. An example use of this component: to save space on a form, you can display a small icon on a button and use a ToolTip to explain the button's function.  
  
## Working with the ToolTip Component  
 A <xref:System.Windows.Forms.ToolTip> component provides a `ToolTip` property to multiple controls on a Windows Form or other container. For example, if you place one <xref:System.Windows.Forms.ToolTip> component on a form, you can display "Type your name here" for a <xref:System.Windows.Forms.TextBox> control and "Click here to save changes" for a <xref:System.Windows.Forms.Button> control.  
  
 The key methods of the <xref:System.Windows.Forms.ToolTip> component are <xref:System.Windows.Forms.ToolTip.SetToolTip%2A> and <xref:System.Windows.Forms.ToolTip.GetToolTip%2A>. You can use the <xref:System.Windows.Forms.ToolTip.SetToolTip%2A> method to set the ToolTips displayed for controls. For more information, see [How to: Set ToolTips for Controls on a Windows Form at Design Time](../../../../docs/framework/winforms/controls/how-to-set-tooltips-for-controls-on-a-windows-form-at-design-time.md). The key properties are <xref:System.Windows.Forms.ToolTip.Active%2A>, which must be set to `true` for the ToolTip to appear, and <xref:System.Windows.Forms.ToolTip.AutomaticDelay%2A>, which sets the length of time that the ToolTip string is shown, how long the user must point at the control for the ToolTip to appear, and how long it takes for subsequent ToolTip windows to appear. For more information, see [How to: Change the Delay of the Windows Forms ToolTip Component](../../../../docs/framework/winforms/controls/how-to-change-the-delay-of-the-windows-forms-tooltip-component.md).  
  
## See Also  
 <xref:System.Windows.Forms.ToolTip>  
 [How to: Set ToolTips for Controls on a Windows Form at Design Time](../../../../docs/framework/winforms/controls/how-to-set-tooltips-for-controls-on-a-windows-form-at-design-time.md)  
 [How to: Change the Delay of the Windows Forms ToolTip Component](../../../../docs/framework/winforms/controls/how-to-change-the-delay-of-the-windows-forms-tooltip-component.md)
