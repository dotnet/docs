---
title: "How to: Create an MDI Form with Menu Merging and ToolStrip Controls"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "toolbars [Windows Forms]"
  - "ToolStripPanel control [Windows Forms]"
  - "ToolStrip control [Windows Forms]"
  - "MenuStrip control [Windows Forms]"
ms.assetid: 64992ed9-44af-4baf-b45f-863e6ab35711
---
# How to: Create an MDI Form with Menu Merging and ToolStrip Controls
The <xref:System.Windows.Forms?displayProperty=nameWithType> namespace supports multiple document interface (MDI) applications, and the <xref:System.Windows.Forms.MenuStrip> control supports menu merging. MDI forms can also <xref:System.Windows.Forms.ToolStrip> controls.  
  
 There is extensive support for this feature in Visual Studio.  
  
 Also see [Walkthrough: Creating an MDI Form with Menu Merging and ToolStrip Controls](walkthrough-creating-an-mdi-form-with-menu-merging-and-toolstrip-controls.md).  
  
## Example  
 The following code example demonstrates how to use <xref:System.Windows.Forms.ToolStripPanel> controls with an MDI form. The form also supports menu merging with child menus.  
  
 [!code-csharp[System.Windows.Forms.ToolStrip.MdiForm#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.MdiForm/CS/Form1.cs#1)]
 [!code-vb[System.Windows.Forms.ToolStrip.MdiForm#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.MdiForm/VB/Form1.vb#1)]  
  
## Compiling the Code  
 This code example requires:  
  
-   References to the System.Drawing and System.Windows.Forms assemblies.  
  
 For information about building this example from the command line for Visual Basic or Visual C#, see [Building from the Command Line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in Visual Studio by pasting the code into a new project.  
  
## See also

- [ToolStrip Control](toolstrip-control-windows-forms.md)
