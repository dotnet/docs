---
title: "Panel Control Overview (Windows Forms)"
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
  - "Panel"
helpviewer_keywords: 
  - "grouping controls [Windows Forms], Panel control"
  - "Panel control [Windows Forms], about Panel control"
ms.assetid: b6b83636-2c39-4dad-89d6-f0fa41049a74
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Panel Control Overview (Windows Forms)
Windows Forms <xref:System.Windows.Forms.Panel> controls are used to provide an identifiable grouping for other controls. Typically, you use panels to subdivide a form by function. For example, you may have an order form that specifies mailing options such as which overnight carrier to use. Grouping all options in a panel gives the user a logical visual cue. At design time all the controls can be moved easily — when you move the <xref:System.Windows.Forms.Panel> control, all its contained controls move, too. The controls grouped in a panel can be accessed through its <xref:System.Windows.Forms.Control.Controls%2A> property. This property returns a collection of <xref:System.Windows.Forms.Control> instances, so you will typically need to cast a control retrieved this way to its specific type.  
  
## Panel Versus GroupBox  
 The <xref:System.Windows.Forms.Panel> control is similar to the <xref:System.Windows.Forms.GroupBox> control; however, only the <xref:System.Windows.Forms.Panel> control can have scroll bars, and only the <xref:System.Windows.Forms.GroupBox> control displays a caption.  
  
## Key Properties  
 To display scroll bars, set the <xref:System.Windows.Forms.ScrollableControl.AutoScroll%2A> property to `true`. You can also customize the appearance of the panel by setting the <xref:System.Windows.Forms.Control.BackColor%2A>, <xref:System.Windows.Forms.Control.BackgroundImage%2A>, and <xref:System.Windows.Forms.Panel.BorderStyle%2A> properties. For more information on the <xref:System.Windows.Forms.Control.BackColor%2A> and <xref:System.Windows.Forms.Control.BackgroundImage%2A> properties, see [How to: Set the Background of a Panel](../../../../docs/framework/winforms/controls/how-to-set-the-background-of-a-windows-forms-panel.md). The <xref:System.Windows.Forms.Panel.BorderStyle%2A> property determines if the panel is outlined with no visible border (<xref:System.Windows.Forms.BorderStyle.None>), a plain line (<xref:System.Windows.Forms.BorderStyle.FixedSingle>), or a shadowed line (<xref:System.Windows.Forms.BorderStyle.Fixed3D>).  
  
## See Also  
 <xref:System.Windows.Forms.Panel>  
 [GroupBox Control](../../../../docs/framework/winforms/controls/groupbox-control-windows-forms.md)  
 [How to: Group Controls with the Windows Forms Panel Control Using the Designer](../../../../docs/framework/winforms/controls/group-controls-with-wf-panel-control-using-the-designer.md)  
 [How to: Set the Background of a Windows Forms Panel Using the Designer](../../../../docs/framework/winforms/controls/how-to-set-the-background-of-a-windows-forms-panel-using-the-designer.md)
