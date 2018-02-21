---
title: "How to: Dock Controls on Windows Forms"
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
  - "controls [Windows Forms], docking"
  - "Explorer-style applications [Windows Forms], creating"
  - "Windows Forms controls, filling client area"
ms.assetid: bc11f2e4-e90a-4830-b0e2-f43b6e2b8bec
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Dock Controls on Windows Forms
You can dock controls to the edges of your form or have them fill the control's container (either a form or a container control). For example, Windows Explorer docks its <xref:System.Windows.Forms.TreeView> control to the left side of the window and its <xref:System.Windows.Forms.ListView> control to the right side of the window. Use the <xref:System.Windows.Forms.Control.Dock%2A> property for all visible Windows Forms controls to define the docking mode.  
  
> [!NOTE]
>  Controls are docked in reverse z-order.  
  
 The <xref:System.Windows.Forms.Control.Dock%2A> property interacts with the <xref:System.Windows.Forms.Control.AutoSize%2A> property. For more information, see [AutoSize Property Overview](../../../../docs/framework/winforms/controls/autosize-property-overview.md).  
  
### To dock a control  
  
1.  Select the control that you want to dock.  
  
2.  In the Properties window, click the arrow to the right of the <xref:System.Windows.Forms.Control.Dock%2A> property.  
  
     An editor is displayed that shows a series of boxes representing the edges and the center of the form.  
  
3.  Click the button that represents the edge of the form where you want to dock the control. To fill the contents of the control's form or container control, click the center box. Click **(none)** to disable docking.  
  
     The control is automatically resized to fit the boundaries of the docked edge.  
  
    > [!NOTE]
    >  Inherited controls must be `Protected` to be able to be docked. To change the access level of a control, set its **Modifier** property in the Properties window.  
  
## See Also  
 [Windows Forms Controls](../../../../docs/framework/winforms/controls/index.md)  
 [Arranging Controls on Windows Forms](../../../../docs/framework/winforms/controls/arranging-controls-on-windows-forms.md)  
 [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](../../../../docs/framework/winforms/controls/labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)  
 [Windows Forms Controls by Function](../../../../docs/framework/winforms/controls/windows-forms-controls-by-function.md)  
 [How to: Anchor and Dock Child Controls in a FlowLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-flowlayoutpanel-control.md)  
 [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md)  
 [AutoSize Property Overview](../../../../docs/framework/winforms/controls/autosize-property-overview.md)  
 [How to: Anchor Controls on Windows Forms](../../../../docs/framework/winforms/controls/how-to-anchor-controls-on-windows-forms.md)
