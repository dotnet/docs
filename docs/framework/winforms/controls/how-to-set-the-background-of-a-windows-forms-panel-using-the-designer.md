---
title: "How to: Set the Background of a Windows Forms Panel Using the Designer"
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
  - "background colors [Windows Forms], Windows Forms Panel controls"
  - "background images [Windows Forms], Windows Forms Panel controls"
  - "Panel control [Windows Forms], background"
  - "colors [Windows Forms], Windows Forms Panel controls"
ms.assetid: db83cf54-3c69-4b08-ac6c-25b9b5abb1b0
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set the Background of a Windows Forms Panel Using the Designer
A Windows Forms <xref:System.Windows.Forms.Panel> control can display both a background color and a background image. The <xref:System.Windows.Forms.Control.BackColor%2A> property sets the background color for controls that are contained in the panel, such as labels and radio buttons. If the <xref:System.Windows.Forms.Control.BackgroundImage%2A> property is not set, the <xref:System.Windows.Forms.Control.BackColor%2A> selection will fill all of the panel. If the <xref:System.Windows.Forms.Control.BackgroundImage%2A> property is set, the image will be displayed behind the controls that are contained in the panel.  
  
 The following procedure requires a **Windows Application** project with a form that contains a <xref:System.Windows.Forms.Panel> control. For information about how to set up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To set the background in the Windows Forms Designer  
  
1.  Select the <xref:System.Windows.Forms.Panel> control.  
  
2.  In the **Properties** window, click the arrow button next to the <xref:System.Windows.Forms.Control.BackColor%2A> property to display a window with three tabs.  
  
3.  Select the **Custom** tab to display a palette of colors.  
  
4.  Select the **Web** or **System** tab to display a list of predefined names for colors, and then select a color.  
  
5.  In the **Properties** window, click the arrow button next to the <xref:System.Windows.Forms.Control.BackgroundImage%2A> property.  
  
6.  In the **Open** dialog box, select the file that you want to display.  
  
## See Also  
 <xref:System.Windows.Forms.Control.BackColor%2A>  
 <xref:System.Windows.Forms.Control.BackgroundImage%2A>  
 [Panel Control](../../../../docs/framework/winforms/controls/panel-control-windows-forms.md)  
 [Panel Control Overview](../../../../docs/framework/winforms/controls/panel-control-overview-windows-forms.md)  
 [How to: Group Controls with the Windows Forms Panel Control Using the Designer](../../../../docs/framework/winforms/controls/group-controls-with-wf-panel-control-using-the-designer.md)
