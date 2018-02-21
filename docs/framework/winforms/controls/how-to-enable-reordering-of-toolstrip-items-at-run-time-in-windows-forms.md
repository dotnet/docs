---
title: "How to: Enable Reordering of ToolStrip Items at Run Time in Windows Forms"
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
  - "ToolStrip control [Windows Forms], examples"
  - "examples [Windows Forms], toolbars"
  - "toolbars [Windows Forms], rearranging controls"
  - "ToolStrip control [Windows Forms], reordering items"
ms.assetid: 8480b69a-379f-4dc2-8dcf-365ed93692b2
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Enable Reordering of ToolStrip Items at Run Time in Windows Forms
You can enable the user to rearrange <xref:System.Windows.Forms.ToolStripItem> controls on the <xref:System.Windows.Forms.ToolStrip>.  
  
### To enable ToolStripItem rearrangement at run time  
  
-   Set the <xref:System.Windows.Forms.ToolStrip.AllowItemReorder%2A> property to `true`. By default, <xref:System.Windows.Forms.ToolStrip.AllowItemReorder%2A> is `false`.  
  
     At run time, the user holds down the ALT key and the left mouse button to drag a <xref:System.Windows.Forms.ToolStripItem> to a different location on the <xref:System.Windows.Forms.ToolStrip>.  
  
    ```vb  
    toolStrip1.AllowItemReorder = True  
    ```  
  
    ```csharp  
    toolStrip1.AllowItemReorder = true;  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.ToolStrip>  
 <xref:System.Windows.Forms.ToolStrip.AllowItemReorder%2A>  
 [ToolStrip Control Overview](../../../../docs/framework/winforms/controls/toolstrip-control-overview-windows-forms.md)  
 [ToolStrip Control Architecture](../../../../docs/framework/winforms/controls/toolstrip-control-architecture.md)  
 [ToolStrip Technology Summary](../../../../docs/framework/winforms/controls/toolstrip-technology-summary.md)
