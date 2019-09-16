---
title: "How to: Dock Controls on Windows Forms"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "controls [Windows Forms], docking"
  - "Explorer-style applications [Windows Forms], creating"
  - "Windows Forms controls, filling client area"
ms.assetid: bc11f2e4-e90a-4830-b0e2-f43b6e2b8bec
author: gewarren
ms.author: gewarren
manager: jillfra
---
# How to: Dock controls on Windows Forms

You can dock controls to the edges of your form or have them fill the control's container (either a form or a container control). For example, Windows Explorer docks its <xref:System.Windows.Forms.TreeView> control to the left side of the window and its <xref:System.Windows.Forms.ListView> control to the right side of the window. Use the <xref:System.Windows.Forms.Control.Dock%2A> property for all visible Windows Forms controls to define the docking mode.

> [!NOTE]
> Controls are docked in reverse z-order.

The <xref:System.Windows.Forms.Control.Dock%2A> property interacts with the <xref:System.Windows.Forms.Control.AutoSize%2A> property. For more information, see [AutoSize Property Overview](autosize-property-overview.md).

## To dock a control

1. In Visual Studio, select the control that you want to dock.

2. In the **Properties** window, click the arrow to the right of the <xref:System.Windows.Forms.Control.Dock%2A> property.

   An editor is displayed that shows a series of boxes representing the edges and the center of the form.

3. Click the button that represents the edge of the form where you want to dock the control. To fill the contents of the control's form or container control, click the center box. Click **(none)** to disable docking.

   The control is automatically resized to fit the boundaries of the docked edge.

   > [!NOTE]
   > Inherited controls must be `Protected` to be able to be docked. To change the access level of a control, set its **Modifier** property in the **Properties** window.

## See also

- [Windows Forms Controls](index.md)
- [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)
- [Controls to Use on Windows Forms](controls-to-use-on-windows-forms.md)
- [Windows Forms Controls by Function](windows-forms-controls-by-function.md)
- [How to: Anchor and Dock Child Controls in a FlowLayoutPanel Control](how-to-anchor-and-dock-child-controls-in-a-flowlayoutpanel-control.md)
- [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md)
- [AutoSize Property Overview](autosize-property-overview.md)
- [How to: Anchor Controls on Windows Forms](how-to-anchor-controls-on-windows-forms.md)
