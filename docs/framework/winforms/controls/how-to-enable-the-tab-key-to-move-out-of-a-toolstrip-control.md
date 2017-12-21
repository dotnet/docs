---
title: "How to: Enable the TAB Key to Move Out of a ToolStrip Control"
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
  - "controls [Windows Forms], moving between"
  - "TAB key [Windows Forms], enabling"
  - "ToolStrip control [Windows Forms], moving from"
ms.assetid: 40f9e88b-09a3-428e-8da8-c00bb65079c6
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Enable the TAB Key to Move Out of a ToolStrip Control
Use the following procedure to enable the user to press the TAB key to move out of a <xref:System.Windows.Forms.ToolStrip> to the next control in the tab order.  
  
 The <xref:System.Windows.Forms.ToolStrip> accepts the first press of the TAB key, and the arrow keys select items within the <xref:System.Windows.Forms.ToolStrip>. When the user presses the TAB key a second time, it takes the user to the next control in the tab order.  
  
### To enable the user to press the TAB key to move out of a ToolStrip to the next control  
  
-   Set the <xref:System.Windows.Forms.ToolStrip.TabStop%2A> property of the <xref:System.Windows.Forms.ToolStrip> to `true`.  
  
## See Also  
 <xref:System.Windows.Forms.ToolStrip>  
 <xref:System.Windows.Forms.ToolStrip.TabStop%2A>  
 [ToolStrip Control Overview](../../../../docs/framework/winforms/controls/toolstrip-control-overview-windows-forms.md)
