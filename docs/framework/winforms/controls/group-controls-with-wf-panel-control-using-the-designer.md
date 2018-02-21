---
title: "How to: Group Controls with the Windows Forms Panel Control Using the Designer"
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
  - "Panel control [Windows Forms], grouping controls"
  - "controls [Windows Forms], grouping"
  - "Windows Forms controls, grouping"
ms.assetid: 7e1cd708-fdb1-49d8-9ca2-5640b276bf2e
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Group Controls with the Windows Forms Panel Control Using the Designer
Windows Forms <xref:System.Windows.Forms.Panel> controls are used to group other controls. There are three reasons to group controls. One is visual grouping of related form elements for a clear user interface; another is programmatic grouping, of radio buttons for example; the last is for moving the controls as a unit at design time.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To create a group of controls  
  
1.  Drag a <xref:System.Windows.Forms.Panel> control from the **Windows Forms** tab of the Toolbox onto a form.  
  
2.  Add other controls to the panel, drawing each inside the panel.  
  
     If you have existing controls that you want to enclose in a panel, you can select all the controls, cut them to the Clipboard, select the <xref:System.Windows.Forms.Panel> control, and then paste them into the panel. You can also drag them into the panel.  
  
3.  (Optional) If you want to add a border to a panel, set its <xref:System.Windows.Forms.BorderStyle> property. There are three choices: <xref:System.Windows.Forms.BorderStyle.Fixed3D>, <xref:System.Windows.Forms.BorderStyle.FixedSingle>, and <xref:System.Windows.Forms.BorderStyle.None>.  
  
## See Also  
 [Panel Control](../../../../docs/framework/winforms/controls/panel-control-windows-forms.md)  
 [Panel Control Overview](../../../../docs/framework/winforms/controls/panel-control-overview-windows-forms.md)  
 [How to: Set the Background of a Panel](../../../../docs/framework/winforms/controls/how-to-set-the-background-of-a-windows-forms-panel.md)
