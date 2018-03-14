---
title: "How to: Anchor Controls on Windows Forms"
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
  - "Anchor property [Windows Forms], enabling resizable forms"
  - "Windows Forms controls, screen resolutions"
  - "resizing forms [Windows Forms]"
  - "Windows Forms controls, size"
  - "screen resolution and control display"
  - "controls [Windows Forms], anchoring"
  - "forms [Windows Forms], resizing"
  - "Windows Forms, resizing"
  - "controls [Windows Forms], positioning"
ms.assetid: 59ea914f-fbd3-427a-80fe-decd02f7ae6d
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Anchor Controls on Windows Forms
If you are designing a form that the user can resize at run time, the controls on your form should resize and reposition properly. To resize controls dynamically with the form, you can use the <xref:System.Windows.Forms.Control.Anchor%2A> property of Windows Forms controls. The <xref:System.Windows.Forms.Control.Anchor%2A> property defines an anchor position for the control. When a control is anchored to a form and the form is resized, the control maintains the distance between the control and the anchor positions. For example, if you have a <xref:System.Windows.Forms.TextBox> control that is anchored to the left, right, and bottom edges of the form, as the form is resized, the <xref:System.Windows.Forms.TextBox> control resizes horizontally so that it maintains the same distance from the right and left sides of the form. In addition, the control positions itself vertically so that its location is always the same distance from the bottom edge of the form. If a control is not anchored and the form is resized, the position of the control relative to the edges of the form is changed.  
  
 The <xref:System.Windows.Forms.Control.Anchor%2A> property interacts with the <xref:System.Windows.Forms.Control.AutoSize%2A> property. For more information, see [AutoSize Property Overview](../../../../docs/framework/winforms/controls/autosize-property-overview.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To anchor a control on a form  
  
1.  Select the control you want to anchor.  
  
    > [!NOTE]
    >  You can anchor multiple controls simultaneously by pressing the CTRL key, clicking each control to select it, and then following the rest of this procedure.  
  
2.  In the **Properties** window, click the arrow to the right of the <xref:System.Windows.Forms.Control.Anchor%2A> property.  
  
     An editor is displayed that shows a cross.  
  
3.  To set an anchor, click the top, left, right, or bottom section of the cross.  
  
     Controls are anchored to the top and left by default.  
  
4.  To clear a side of the control that has been anchored, click that arm of the cross.  
  
5.  To close the <xref:System.Windows.Forms.Control.Anchor%2A> property editor, click the <xref:System.Windows.Forms.Control.Anchor%2A> property name again.  
  
 When your form is displayed at run time, the control resizes to remain positioned at the same distance from the edge of the form. The distance from the anchored edge always remains the same as the distance defined when the control is positioned in the Windows Forms Designer.  
  
> [!NOTE]
>  Certain controls, such as the <xref:System.Windows.Forms.ComboBox> control, have a limit to their height. Anchoring the control to the bottom of its form or container cannot force the control to exceed its height limit.  
  
 Inherited controls must be `Protected` to be able to be anchored. To change the access level of a control, set its `Modifiers` property in the **Properties** window.  
  
## See Also  
 [Windows Forms Controls](../../../../docs/framework/winforms/controls/index.md)  
 [Arranging Controls on Windows Forms](../../../../docs/framework/winforms/controls/arranging-controls-on-windows-forms.md)  
 [AutoSize Property Overview](../../../../docs/framework/winforms/controls/autosize-property-overview.md)  
 [How to: Dock Controls on Windows Forms](../../../../docs/framework/winforms/controls/how-to-dock-controls-on-windows-forms.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-flowlayoutpanel.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md)  
 [Walkthrough: Laying Out Windows Forms Controls with Padding, Margins, and the AutoSize Property](../../../../docs/framework/winforms/controls/windows-forms-controls-padding-autosize.md)
