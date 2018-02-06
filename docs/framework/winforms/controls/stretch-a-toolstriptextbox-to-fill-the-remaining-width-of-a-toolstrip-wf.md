---
title: "How to: Stretch a ToolStripTextBox to Fill the Remaining Width of a ToolStrip (Windows Forms)"
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
  - "text boxes [Windows Forms], stretching in ToolStrip control [Windows Forms]"
  - "ToolStrip control [Windows Forms], stretching a text box"
ms.assetid: 0e610fbf-85fe-414c-900c-9704a5dd5cc6
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Stretch a ToolStripTextBox to Fill the Remaining Width of a ToolStrip (Windows Forms)
When you set the <xref:System.Windows.Forms.ToolStrip.Stretch%2A> property of a <xref:System.Windows.Forms.ToolStrip> control to `true`, the control fills its container from end to end, and resizes when its container resizes. In this configuration, you may find it useful to stretch an item in the control, such as a <xref:System.Windows.Forms.ToolStripTextBox>, to fill the available space and to resize when the control resizes. This stretching is useful, for example, if you want to achieve appearance and behavior similar to the address bar in Microsoft® Internet Explorer.  
  
## Example  
 The following code example provides a class derived from <xref:System.Windows.Forms.ToolStripTextBox> called `ToolStripSpringTextBox`. This class overrides the <xref:System.Windows.Forms.ToolStripTextBox.GetPreferredSize%2A> method to calculate the available width of the parent <xref:System.Windows.Forms.ToolStrip> control after the combined width of all other items has been subtracted. This code example also provides a <xref:System.Windows.Forms.Form> class and a `Program` class to demonstrate the new behavior.  
  
 [!code-csharp[ToolStripSpringTextBox#00](../../../../samples/snippets/csharp/VS_Snippets_Winforms/ToolStripSpringTextBox/cs/ToolStripSpringTextBox.cs#00)]
 [!code-vb[ToolStripSpringTextBox#00](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/ToolStripSpringTextBox/vb/ToolStripSpringTextBox.vb#00)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Drawing, and System.Windows.Forms assemblies.  
  
## See Also  
 <xref:System.Windows.Forms.ToolStrip>  
 <xref:System.Windows.Forms.ToolStrip.Stretch%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.ToolStripTextBox>  
 <xref:System.Windows.Forms.ToolStripTextBox.GetPreferredSize%2A?displayProperty=nameWithType>  
 [ToolStrip Control Architecture](../../../../docs/framework/winforms/controls/toolstrip-control-architecture.md)  
 [How to: Use the Spring Property Interactively in a StatusStrip](../../../../docs/framework/winforms/controls/how-to-use-the-spring-property-interactively-in-a-statusstrip.md)
