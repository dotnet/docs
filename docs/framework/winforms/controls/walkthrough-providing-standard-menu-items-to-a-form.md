---
title: "Walkthrough: Providing Standard Menu Items to a Form"
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
  - "menu items [Windows Forms], standard"
  - "toolbars [Windows Forms], walkthroughs"
  - "StatusStrip control [Windows Forms]"
  - "ToolStrip control [Windows Forms]"
ms.assetid: dac37d98-589e-4d6d-9673-6437e8943122
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Providing Standard Menu Items to a Form
You can provide a standard menu for your forms with the <xref:System.Windows.Forms.MenuStrip> control.  
  
 This walkthrough demonstrates how to use a <xref:System.Windows.Forms.MenuStrip> control to create a standard menu. The form also responds when a user selects a menu item. The following tasks are illustrated in this walkthrough:  
  
-   Creating a Windows Forms project.  
  
-   Creating a standard menu.  
  
-   Creating a <xref:System.Windows.Forms.StatusStrip> control.  
  
-   Handling menu item selection.  
  
 When you are finished, you will have a form with a standard menu that displays menu item selections in a <xref:System.Windows.Forms.StatusStrip> control.  
  
 To copy the code in this topic as a single listing, see [How to: Provide Standard Menu Items to a Form](../../../../docs/framework/winforms/controls/how-to-provide-standard-menu-items-to-a-form.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Prerequisites  
 In order to complete this walkthrough, you will need:  
  
-   Sufficient permissions to be able to create and run Windows Forms application projects on the computer where [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] is installed.  
  
## Creating the Project  
 The first step is to create the project and set up the form.  
  
#### To create the project  
  
1.  Create a Windows application project called **StandardMenuForm**.  
  
     For more information, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa).  
  
2.  In the Windows Forms Designer, select the form.  
  
## Creating a Standard Menu  
 The Windows Forms Designer can automatically populate a <xref:System.Windows.Forms.MenuStrip> control with standard menu items.  
  
#### To create a standard menu  
  
1.  From the **Toolbox**, drag a <xref:System.Windows.Forms.MenuStrip> control onto your form.  
  
2.  Click the <xref:System.Windows.Forms.MenuStrip> control's smart tag glyph (![Smart Tag Glyph](../../../../docs/framework/winforms/controls/media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")) and select **Insert Standard Items**.  
  
     The <xref:System.Windows.Forms.MenuStrip> control is populated with the standard menu items.  
  
3.  Click the **File** menu item to see its default menu items and corresponding icons.  
  
## Creating a StatusStrip Control  
 Use the <xref:System.Windows.Forms.StatusStrip> control to display status for your Windows Forms applications. In the current example, menu items selected by the user are displayed in a <xref:System.Windows.Forms.StatusStrip> control.  
  
#### To create a StatusStrip control  
  
1.  From the **Toolbox**, drag a <xref:System.Windows.Forms.StatusStrip> control onto your form.  
  
     The <xref:System.Windows.Forms.StatusStrip> control automatically docks to the bottom of the form.  
  
2.  Click the <xref:System.Windows.Forms.StatusStrip> control's drop-down button and select **StatusLabel** to add a <xref:System.Windows.Forms.ToolStripStatusLabel> control to the <xref:System.Windows.Forms.StatusStrip> control.  
  
## Handling Item Selection  
 Handle the <xref:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked> event to respond when the user selects a menu item.  
  
#### To handle item selection  
  
1.  Click the **File** menu item that you created in the Creating a Standard Menu section.  
  
2.  In the **Properties** window, click **Events**.  
  
3.  Double-click the <xref:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked> event.  
  
     The Windows Forms Designer generates an event handler for the <xref:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked> event.  
  
4.  Insert the following code into the event handler.  
  
     [!code-csharp[System.Windows.Forms.ToolStrip.StandardMenu#3](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StandardMenu/CS/Form1.cs#3)]
     [!code-vb[System.Windows.Forms.ToolStrip.StandardMenu#3](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StandardMenu/VB/Form1.vb#3)]  
  
5.  Insert the `UpdateStatus` utility method definition into the form.  
  
     [!code-csharp[System.Windows.Forms.ToolStrip.StandardMenu#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StandardMenu/CS/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.ToolStrip.StandardMenu#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.StandardMenu/VB/Form1.vb#2)]  
  
## Checkpoint  
  
#### To test your form  
  
1.  Press F5 to compile and run your form.  
  
2.  Click the **File** menu item to open the menu.  
  
3.  On the **File** menu, click one of the items to select it.  
  
     The <xref:System.Windows.Forms.StatusStrip> control displays the selected item.  
  
## Next Steps  
 In this walkthrough, you have created a form with a standard menu. You can use the <xref:System.Windows.Forms.ToolStrip> family of controls for many other purposes:  
  
-   Create shortcut menus for your controls with <xref:System.Windows.Forms.ContextMenuStrip>. For more information, see [ContextMenu Component Overview](../../../../docs/framework/winforms/controls/contextmenu-component-overview-windows-forms.md).  
  
-   Create a multiple document interface (MDI) form with docking <xref:System.Windows.Forms.ToolStrip> controls. For more information, see [Walkthrough: Creating an MDI Form with Menu Merging and ToolStrip Controls](../../../../docs/framework/winforms/controls/walkthrough-creating-an-mdi-form-with-menu-merging-and-toolstrip-controls.md).  
  
-   Give your <xref:System.Windows.Forms.ToolStrip> controls a professional appearance. For more information, see [How to: Set the ToolStrip Renderer for an Application](../../../../docs/framework/winforms/controls/how-to-set-the-toolstrip-renderer-for-an-application.md).  
  
## See Also  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ToolStrip>  
 <xref:System.Windows.Forms.StatusStrip>  
 [MenuStrip Control](../../../../docs/framework/winforms/controls/menustrip-control-windows-forms.md)
