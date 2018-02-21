---
title: "How to: Reassign Existing Controls to a Different Parent"
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
  - "container controls [Windows Forms], Windows Forms"
  - "layout [Windows Forms], resizing"
  - "layout [Windows Forms], child controls"
ms.assetid: 5a5723ff-34e0-4b6f-a57b-be4ebe35cb34
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Reassign Existing Controls to a Different Parent
You can assign controls that exist on your form to a new container control.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To reassign existing controls to a different parent  
  
1.  Drag three <xref:System.Windows.Forms.Button> controls from the **Toolbox** onto the form.  
  
     Position them near to each other, but leave them unaligned.  
  
2.  In the **Toolbox**, click the <xref:System.Windows.Forms.FlowLayoutPanel> control icon.  
  
     Do not drag the icon onto the form.  
  
3.  Move the mouse pointer close to the three <xref:System.Windows.Forms.Button> controls.  
  
     The pointer changes to a crosshair with the <xref:System.Windows.Forms.FlowLayoutPanel> control icon attached.  
  
4.  Click and hold the mouse button.  
  
5.  Drag the mouse pointer to draw the outline of the <xref:System.Windows.Forms.FlowLayoutPanel> control.  
  
6.  Draw the outline around the three <xref:System.Windows.Forms.Button> controls.  
  
7.  Release the mouse button.  
  
     The three <xref:System.Windows.Forms.Button> controls are now inserted into the <xref:System.Windows.Forms.FlowLayoutPanel> control.  
  
## See Also  
 <xref:System.Windows.Forms.FlowLayoutPanel>  
 <xref:System.Windows.Forms.TableLayoutPanel>  
 [Arranging Controls on Windows Forms](../../../../docs/framework/winforms/controls/arranging-controls-on-windows-forms.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-snaplines.md)
