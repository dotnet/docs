---
title: "How to: Align a Control to the Edges of Forms at Design Time"
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
  - "custom controls [Windows Forms], docking using designer"
  - "Dock property [Windows Forms], aligning controls (using designer)"
ms.assetid: 51f08998-5e3b-4330-be58-a4edd0eb60f4
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Align a Control to the Edges of Forms at Design Time
You can make your control align to the edge of your forms by setting the <xref:System.Windows.Forms.Control.Dock%2A>. This property designates where your control resides in the form. The <xref:System.Windows.Forms.Control.Dock%2A> property can be set to the following values:  
  
|Setting|Effect on your control|  
|-------------|----------------------------|  
|<xref:System.Windows.Forms.DockStyle.Bottom>|Docks to the bottom of the form.|  
|<xref:System.Windows.Forms.DockStyle.Fill>|Fills all remaining space in the form.|  
|<xref:System.Windows.Forms.DockStyle.Left>|Docks to the left side of the form.|  
|<xref:System.Windows.Forms.DockStyle.None>|Does not dock anywhere, and it appears at the location specified by its <xref:System.Windows.Forms.Control.Location%2A>.|  
|<xref:System.Windows.Forms.DockStyle.Right>|Docks to the right side of the form.|  
|<xref:System.Windows.Forms.DockStyle.Top>|Docks to the top of the form.|  
  
 These values can also be set in code. For more information, see [How to: Align a Control to the Edges of Forms](../../../../docs/framework/winforms/controls/how-to-align-a-control-to-the-edges-of-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To set the Dock property for your control at design time  
  
1.  In the Windows Forms Designer, select your control.  
  
2.  In the **Properties** window, click the drop-down box next to the <xref:System.Windows.Forms.Control.Dock%2A> property.  
  
     A graphical interface representing the six possible <xref:System.Windows.Forms.Control.Dock%2A> settings is displayed.  
  
3.  Choose the appropriate setting.  
  
4.  Your control will now dock in the manner specified by the setting.  
  
## See Also  
 <xref:System.Windows.Forms.Control.Dock%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.Control.Anchor%2A?displayProperty=nameWithType>  
 [How to: Align a Control to the Edges of Forms](../../../../docs/framework/winforms/controls/how-to-align-a-control-to-the-edges-of-forms.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-snaplines.md)  
 [How to: Anchor Controls on Windows Forms](../../../../docs/framework/winforms/controls/how-to-anchor-controls-on-windows-forms.md)  
 [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md)  
 [How to: Anchor and Dock Child Controls in a FlowLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-flowlayoutpanel-control.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-tablelayoutpanel.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using a FlowLayoutPanel](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-a-flowlayoutpanel.md)  
 [Developing Windows Forms Controls at Design Time](../../../../docs/framework/winforms/controls/developing-windows-forms-controls-at-design-time.md)
