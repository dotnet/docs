---
title: "How to: Create a Professionally Styled ToolStrip Control"
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
  - "toolbars [Windows Forms]"
  - "ToolStripProfessionalRenderer class [Windows Forms]"
  - "ToolStripRenderer class [Windows Forms]"
  - "ToolStrip control [Windows Forms]"
ms.assetid: c208b2f6-8105-474b-9075-d582e1792870
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Create a Professionally Styled ToolStrip Control
You can give your application’s <xref:System.Windows.Forms.ToolStrip> controls a professional appearance and behavior (look and feel) by writing your own class derived from the <xref:System.Windows.Forms.ToolStripProfessionalRenderer> type.  
  
 There is extensive support for this feature in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)].  
  
 See [Walkthrough: Creating a Professionally Styled ToolStrip Control](../../../../docs/framework/winforms/controls/walkthrough-creating-a-professionally-styled-toolstrip-control.md).  
  
## Example  
 The following code example demonstrates how to use <xref:System.Windows.Forms.ToolStrip> controls to create a composite control that mimics the **Navigation Pane** provided by Microsoft® Outlook®.  
  
 [!code-csharp[System.Windows.Forms.ToolStrip.StackView#1](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/CS/StackView.cs#1)]
 [!code-vb[System.Windows.Forms.ToolStrip.StackView#1](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StackView/VB/StackView.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System.Drawing and System.Windows.Forms assemblies.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [Walkthrough: Creating a Professionally Styled ToolStrip Control](http://msdn.microsoft.com/library/ms233664\(v=vs.110\)).  
  
## See Also  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ToolStrip>  
 <xref:System.Windows.Forms.StatusStrip>  
 [ToolStrip Control](../../../../docs/framework/winforms/controls/toolstrip-control-windows-forms.md)  
 [How to: Provide Standard Menu Items to a Form](../../../../docs/framework/winforms/controls/how-to-provide-standard-menu-items-to-a-form.md)
