---
title: "How to: Reassign Existing Controls to a Different Parent"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "container controls [Windows Forms], Windows Forms"
  - "layout [Windows Forms], resizing"
  - "layout [Windows Forms], child controls"
ms.assetid: 5a5723ff-34e0-4b6f-a57b-be4ebe35cb34
author: jillre
ms.author: jillfra
manager: jillfra
---
# How to: Reassign existing controls to a different parent

You can assign controls that exist on your form to a new container control.

1. In Visual Studio, drag three <xref:System.Windows.Forms.Button> controls from the **Toolbox** onto the form. Position them near to each other, but leave them unaligned.

2. In the **Toolbox**, click the <xref:System.Windows.Forms.FlowLayoutPanel> control icon. (Do not drag the icon onto the form.)

3. Move the mouse pointer close to the three <xref:System.Windows.Forms.Button> controls.

   The pointer changes to a crosshair with the <xref:System.Windows.Forms.FlowLayoutPanel> control icon attached.

4. Click and hold the mouse button.

5. Drag the mouse pointer to draw the outline of the <xref:System.Windows.Forms.FlowLayoutPanel> control.

6. Draw the outline around the three <xref:System.Windows.Forms.Button> controls.

7. Release the mouse button.

   The three <xref:System.Windows.Forms.Button> controls are now inserted into the <xref:System.Windows.Forms.FlowLayoutPanel> control.

## See also

- <xref:System.Windows.Forms.FlowLayoutPanel>
- <xref:System.Windows.Forms.TableLayoutPanel>
- [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md)
- [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](walkthrough-arranging-controls-on-windows-forms-using-snaplines.md)
