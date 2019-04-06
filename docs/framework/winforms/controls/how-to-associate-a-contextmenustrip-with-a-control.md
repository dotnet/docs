---
title: "How to: Associate a ContextMenuStrip with a Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "context menus [Windows Forms], relating"
  - "ContextMenuStrips [Windows Forms], associating with controls"
  - "context menus [Windows Forms], associating with controls"
  - "ContextMenuStrips [Windows Forms], relating"
ms.assetid: 6fc40a42-5d69-427f-aa30-0a146193226b
---
# How to: Associate a ContextMenuStrip with a Control
After creating your controls and shortcut menus, use the following procedures to display a given shortcut menu when the user right-clicks the control. These procedures associate a <xref:System.Windows.Forms.ContextMenuStrip> with a Windows Form and with a <xref:System.Windows.Forms.ToolStrip> control.  
  
### To associate a ContextMenuStrip with a Windows Form  
  
1.  Set the <xref:System.Windows.Forms.Control.ContextMenuStrip%2A> property to the name of the associated <xref:System.Windows.Forms.ContextMenuStrip>.  
  
### To associate a ContextMenuStrip with a ToolStrip control  
  
1.  Set the control's <xref:System.Windows.Forms.Control.ContextMenuStrip%2A> property to the name of the associated <xref:System.Windows.Forms.ContextMenuStrip>.  
  
## Example  
 The following code example creates a Windows Form and a <xref:System.Windows.Forms.ToolStrip>, and associates a different <xref:System.Windows.Forms.ContextMenuStrip> control with each of them.  
  
 [!code-csharp[System.Windows.Forms.ContextMenuStrip#1](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ContextMenuStrip/CS/form1.cs#1)]
 [!code-vb[System.Windows.Forms.ContextMenuStrip#1](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ContextMenuStrip/VB/form1.vb#1)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Data, System.Drawing and System.Windows.Forms assemblies.  
  
 For information about building this example from the command line for Visual Basic or Visual C#, see [Building from the Command Line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in Visual Studio by pasting the code into a new project.  
  
## See also

- <xref:System.Windows.Forms.ContextMenuStrip>
- <xref:System.Windows.Forms.Control.ContextMenuStrip%2A>
- <xref:System.Windows.Forms.ToolStrip>
- [How to: Add Menu Items to a ContextMenuStrip](how-to-add-menu-items-to-a-contextmenustrip.md)
- [ContextMenuStrip Control](contextmenustrip-control.md)
