---
title: "How to: Change the Appearance of ToolStrip Text and Images in Windows Forms"
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
  - "ToolStrip control [Windows Forms], appearance"
  - "toolbars [Windows Forms], images"
  - "examples [Windows Forms], toolbars"
  - "toolbars [Windows Forms], appearance"
  - "ToolStrip control [Windows Forms], images"
  - "ToolStrip control [Windows Forms], text"
  - "toolbars [Windows Forms], text"
ms.assetid: d62dc9d1-2edd-4dfa-aed7-1335d6e13d86
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Change the Appearance of ToolStrip Text and Images in Windows Forms
You can control whether text and images are displayed on a <xref:System.Windows.Forms.ToolStripItem> and how they are aligned relative to each other and the <xref:System.Windows.Forms.ToolStrip>.  
  
### To define what is displayed on a ToolStripItem  
  
-   Set the <xref:System.Windows.Forms.ToolStripItem.DisplayStyle%2A> property to the desired value. The possibilities are `Image`, `ImageAndText`, `None`, and `Text`. The default is `ImageAndText`.  
  
    ```vb  
    ToolStripButton2.DisplayStyle = _  
        System.Windows.Forms.ToolStripItemDisplayStyle.Image  
    ```  
  
    ```csharp  
    toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;  
    ```  
  
### To align text on a ToolStripItem  
  
-   Set the <xref:System.Windows.Forms.ToolStripItem.TextAlign%2A> property to the desired value. The possibilities are any combination of top, middle, and bottom with left, center, and right. The default is `MiddleCenter`.  
  
    ```vb  
    ToolStripSplitButton1.TextAlign = _  
        System.Drawing.ContentAlignment.MiddleRight  
    ```  
  
    ```csharp  
    toolStripSplitButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;  
    ```  
  
### To align an image on a ToolStripItem  
  
-   Set the <xref:System.Windows.Forms.ToolStripItem.ImageAlign%2A> property to the desired value. The possibilities are any combination of top, middle, and bottom with left, center, and right. The default is `MiddleLeft`.  
  
    ```vb  
    ToolStripSplitButton1.ImageAlign = _  
        System.Drawing.ContentAlignment.MiddleRight  
    ```  
  
    ```csharp  
    toolStripSplitButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;  
    ```  
  
### To define how ToolStripItem text and images are displayed relative to each other  
  
-   Set the <xref:System.Windows.Forms.ToolStripItem.TextImageRelation%2A> property to the desired value. The possibilities are `ImageAboveText`, `ImageBeforeText`, `Overlay`, `TextAboveImage`, and `TextBeforeImage`. The default is `ImageBeforeText`.  
  
    ```vb  
    ToolStripButton1.TextImageRelation = _  
        System.Windows.Forms.TextImageRelation.ImageAboveText  
    ```  
  
    ```csharp  
    toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.ToolStrip>  
 [ToolStrip Control Overview](../../../../docs/framework/winforms/controls/toolstrip-control-overview-windows-forms.md)  
 [ToolStrip Control Architecture](../../../../docs/framework/winforms/controls/toolstrip-control-architecture.md)  
 [ToolStrip Technology Summary](../../../../docs/framework/winforms/controls/toolstrip-technology-summary.md)
