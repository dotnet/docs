---
title: "How to: Detect When the Mouse Pointer Is Over a ToolStripItem"
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
  - "toolbars [Windows Forms], detecting mouse movement"
  - "ToolStrip control [Windows Forms], detecting mouse movement"
  - "ToolStripItem class [Windows Forms], detecting mouse movement"
  - "mouse [Windows Forms], detecting movement on toolbars"
ms.assetid: d38b5082-aba7-4f6c-841b-bd9714e307fd
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Detect When the Mouse Pointer Is Over a ToolStripItem
Use the following procedure to detect when the mouse pointer is over a <xref:System.Windows.Forms.ToolStripItem>.  
  
### To detect when the pointer is over a ToolStripItem  
  
-   Use the <xref:System.Windows.Forms.ToolStripItem.Selected%2A> property for items in which <xref:System.Windows.Forms.ToolStripItem.CanSelect%2A> is `true`.  
  
     This will prevent you from having to synchronize the <xref:System.Windows.Forms.ToolStripItem.MouseEnter> and <xref:System.Windows.Forms.ToolStripItem.MouseLeave> events.  
  
## See Also  
 <xref:System.Windows.Forms.ToolStripItem>  
 <xref:System.Windows.Forms.ToolStripItem.Selected%2A>  
 [ToolStrip Control Overview](../../../../docs/framework/winforms/controls/toolstrip-control-overview-windows-forms.md)
