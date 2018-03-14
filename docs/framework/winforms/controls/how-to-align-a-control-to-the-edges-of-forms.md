---
title: "How to: Align a Control to the Edges of Forms"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "Dock property [Windows Forms], aligning controls (using code)"
  - "forms [Windows Forms], aligning controls"
  - "controls [Windows Forms], aligning on forms"
  - "custom controls [Windows Forms], docking using code"
ms.assetid: 5994cb59-242b-4e75-bd0e-62879c34d702
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Align a Control to the Edges of Forms
You can make your control align to the edge of your forms by setting the <xref:System.Windows.Forms.Control.Dock%2A> property. This property designates where your control resides in the form. The <xref:System.Windows.Forms.Control.Dock%2A> property can be set to the following values:  
  
|Setting|Effect on your control|  
|-------------|----------------------------|  
|<xref:System.Windows.Forms.DockStyle.Bottom>|Docks to the bottom of the form.|  
|<xref:System.Windows.Forms.DockStyle.Fill>|Fills all remaining space in the form.|  
|<xref:System.Windows.Forms.DockStyle.Left>|Docks to the left side of the form.|  
|<xref:System.Windows.Forms.DockStyle.None>|Does not dock anywhere, and it appears at the location specified by its <xref:System.Windows.Forms.Control.Location%2A> property.|  
|<xref:System.Windows.Forms.DockStyle.Right>|Docks to the right side of the form.|  
|<xref:System.Windows.Forms.DockStyle.Top>|Docks to the top of the form.|  
  
 There is design-time support for this feature in Visual Studio.  
  
### To set the Dock property for your control at run time  
  
1.  Set the <xref:System.Windows.Forms.Control.Dock%2A> property to the appropriate value in code.  
  
    ```vb  
    ' To set the Dock property internally.  
    Me.Dock = DockStyle.Top  
    ' To set the Dock property from another object.  
    UserControl1.Dock = DockStyle.Top  
    ```  
  
    ```csharp  
    // To set the Dock property internally.  
    this.Dock = DockStyle.Top;  
    // To set the Dock property from another object.  
    UserControl1.Dock = DockStyle.Top;  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.Control.Dock%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.Control.Anchor%2A?displayProperty=nameWithType>  
 [Developing Custom Windows Forms Controls with the .NET Framework](../../../../docs/framework/winforms/controls/developing-custom-windows-forms-controls.md)  
 [How to: Anchor and Dock Child Controls in a FlowLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-flowlayoutpanel-control.md)  
 [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md)  
 [AutoSize Property Overview](../../../../docs/framework/winforms/controls/autosize-property-overview.md)
