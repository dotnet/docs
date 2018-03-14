---
title: "Walkthrough: Creating an MDI Form with Menu Merging and ToolStrip Controls"
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
  - "ToolStripPanel control [Windows Forms]"
  - "MDI [Windows Forms], creating forms"
  - "multiple document interface forms"
  - "MDI forms"
  - "ToolStrip control [Windows Forms]"
  - "MDI forms [Windows Forms], creating"
  - "MDI forms [Windows Forms], walkthroughs"
ms.assetid: fbab4221-74af-42d0-bbf4-3c97f7b2e544
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Creating an MDI Form with Menu Merging and ToolStrip Controls
The <xref:System.Windows.Forms?displayProperty=nameWithType> namespace supports multiple document interface (MDI) applications, and the <xref:System.Windows.Forms.MenuStrip> control supports menu merging. MDI forms can also <xref:System.Windows.Forms.ToolStrip> controls.  
  
 This walkthrough demonstrates how to use <xref:System.Windows.Forms.ToolStripPanel> controls with an MDI form. The form also supports menu merging with child menus. The following tasks are illustrated in this walkthrough:  
  
-   Creating a Windows Forms project.  
  
-   Creating the main menu for your form. The actual name of the menu will vary.  
  
-   Adding the <xref:System.Windows.Forms.ToolStripPanel> control to the **Toolbox**.  
  
-   Creating a child form.  
  
-   Arranging <xref:System.Windows.Forms.ToolStripPanel> controls by z-order.  
  
 When you are finished, you will have an MDI form that supports menu merging and movable <xref:System.Windows.Forms.ToolStrip> controls.  
  
 To copy the code in this topic as a single listing, see [How to: Create an MDI Form with Menu Merging and ToolStrip Controls](../../../../docs/framework/winforms/controls/how-to-create-an-mdi-form-with-menu-merging-and-toolstrip-controls.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Prerequisites  
 In order to complete this walkthrough, you will need:  
  
-   Sufficient permissions to be able to create and run Windows Forms application projects on the computer where [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] is installed.  
  
## Creating the Project  
 The first step is to create the project and set up the form.  
  
#### To create the project  
  
1.  Create a Windows Application project called **MdiForm**.  
  
     For more information, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa).  
  
2.  In the Windows Forms Designer, select the form.  
  
3.  In the Properties window, set the value of the <xref:System.Windows.Forms.Form.IsMdiContainer%2A> to `true`.  
  
## Creating the Main Menu  
 The parent MDI form contains the main menu. The main menu has one menu item named **Window**. With the **Window** menu item, you can create child forms. Menu items from child forms are merged into the main menu.  
  
#### To create the Main menu  
  
1.  From the **Toolbox**, drag a <xref:System.Windows.Forms.MenuStrip> control onto the form.  
  
2.  Add a <xref:System.Windows.Forms.ToolStripMenuItem> to the <xref:System.Windows.Forms.MenuStrip> control and name it **Window**.  
  
3.  Select the <xref:System.Windows.Forms.MenuStrip> control.  
  
4.  In the Properties window, set the value of the <xref:System.Windows.Forms.MenuStrip.MdiWindowListItem%2A> property to `ToolStripMenuItem1`.  
  
5.  Add a subitem to the **Window** menu item, and then name the subitem **New**.  
  
6.  In the Properties window, click **Events**.  
  
7.  Double-click the <xref:System.Windows.Forms.ToolStripItem.Click> event.  
  
     The Windows Forms Designer generates an event handler for the <xref:System.Windows.Forms.ToolStripItem.Click> event.  
  
8.  Insert the following code into the event handler.  
  
     [!code-csharp[System.Windows.Forms.ToolStrip.MdiForm#2](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.MdiForm/CS/Form1.cs#2)]
     [!code-vb[System.Windows.Forms.ToolStrip.MdiForm#2](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.ToolStrip.MdiForm/VB/Form1.vb#2)]  
  
## Adding the ToolStripPanel Control to the Toolbox  
 When you use <xref:System.Windows.Forms.MenuStrip> controls with an MDI form you must have the <xref:System.Windows.Forms.ToolStripPanel> control. You must add the <xref:System.Windows.Forms.ToolStripPanel> control to the **Toolbox** to build your MDI form in the Windows Forms Designer.  
  
#### To add the ToolStripPanel control to the Toolbox  
  
1.  Open the **Toolbox**, and then click the **All Windows Forms** tab to show the available Windows Forms controls.  
  
2.  Right-click to open the shortcut menu, and select **Choose Items**.  
  
3.  In the **Choose Toolbox Items** dialog box, scroll down the **Name** column until you find **ToolStripPanel**.  
  
4.  Select the check box by **ToolStripPanel**, and then click **OK**.  
  
     The <xref:System.Windows.Forms.ToolStripPanel> control appears in the **Toolbox**.  
  
## Creating a Child Form  
 In this procedure, you will define a separate child form class that has its own <xref:System.Windows.Forms.MenuStrip> control. The menu items for this form are merged with those of the parent form.  
  
#### To define a child form  
  
1.  Add a new form named `ChildForm` to the project.  
  
     For more information, see [How to: Add Windows Forms to a Project](http://msdn.microsoft.com/library/3d7bb25f-fd90-47cf-9378-fa0d764686c1).  
  
2.  From the **Toolbox**, drag a <xref:System.Windows.Forms.MenuStrip> control onto the child form.  
  
3.  Click the <xref:System.Windows.Forms.MenuStrip> control's smart tag glyph (![Smart Tag Glyph](../../../../docs/framework/winforms/controls/media/vs-winformsmttagglyph.gif "VS_WinFormSmtTagGlyph")), and then select **Edit Items**.  
  
4.  In the **Items Collection Editor** dialog box, add a new <xref:System.Windows.Forms.ToolStripMenuItem> named **ChildMenuItem** to the child menu.  
  
     For more information, see [ToolStrip Items Collection Editor](http://msdn.microsoft.com/library/e681f3ab-94ba-4b2b-ac64-1dfad46caa25).  
  
## Testing the Form  
  
#### To test your form  
  
1.  Press F5 to compile and run your form.  
  
2.  Click the **Window** menu item to open the menu, and then click **New**.  
  
     A new child form is created in the form's MDI client area. The child form's menu is merged with the main menu.  
  
3.  Close the child form.  
  
     The child form's menu is removed from the main menu.  
  
4.  Click **New** several times.  
  
     The child forms are automatically listed under the W**indow** menu item because the <xref:System.Windows.Forms.MenuStrip> control's <xref:System.Windows.Forms.MenuStrip.MdiWindowListItem%2A> property is assigned.  
  
## Adding ToolStrip Support  
 In this procedure, you will add four <xref:System.Windows.Forms.ToolStrip> controls to the MDI parent form. Each <xref:System.Windows.Forms.ToolStrip> control is added inside a <xref:System.Windows.Forms.ToolStripPanel> control, which is docked to the edge of the form.  
  
#### To add ToolStrip controls to the MDI parent form  
  
1.  From the **Toolbox**, drag a <xref:System.Windows.Forms.ToolStripPanel> control onto the form.  
  
2.  With the <xref:System.Windows.Forms.ToolStripPanel> control selected, double-click the <xref:System.Windows.Forms.ToolStrip> control in the **Toolbox**.  
  
     A <xref:System.Windows.Forms.ToolStrip> control is created in the <xref:System.Windows.Forms.ToolStripPanel> control.  
  
3.  Select the <xref:System.Windows.Forms.ToolStripPanel> control.  
  
4.  In the Properties window, change the value of the control's <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Left>.  
  
     The <xref:System.Windows.Forms.ToolStripPanel> control docks to the left side of the form, underneath the main menu. The MDI client area resizes to fit the <xref:System.Windows.Forms.ToolStripPanel> control.  
  
5.  Repeat steps 1 through 4.  
  
     Dock the new <xref:System.Windows.Forms.ToolStripPanel> control to the top of the form.  
  
     The <xref:System.Windows.Forms.ToolStripPanel> control is docked underneath the main menu, but to the right of the first <xref:System.Windows.Forms.ToolStripPanel> control. This step illustrates the importance of z-order in correctly positioning <xref:System.Windows.Forms.ToolStripPanel> controls.  
  
6.  Repeat steps 1 through 4 for two more <xref:System.Windows.Forms.ToolStripPanel> controls.  
  
     Dock the new <xref:System.Windows.Forms.ToolStripPanel> controls to the right and bottom of the form.  
  
## Arranging ToolStripPanel Controls by Z-order  
 The position of a docked <xref:System.Windows.Forms.ToolStripPanel> control on your MDI form is determined by the control's position in the z-order. You can easily arrange the z-order of your controls in the Document Outline window.  
  
#### To arrange ToolStripPanel controls by Z-order  
  
1.  In the **View** menu, click **Other Windows**, and then click **Document Outline**.  
  
     The arrangement of your <xref:System.Windows.Forms.ToolStripPanel> controls from the previous procedure is nonstandard. This is because the z-order is not correct. Use the Document Outline window to change the z-order of the controls.  
  
2.  In the Document Outline window, select **ToolStripPanel4**.  
  
3.  Click the down-arrow button repeatedly, until **ToolStripPanel4** is at the bottom of the list.  
  
     The **ToolStripPanel4** control is docked to the bottom of the form, underneath the other controls.  
  
4.  Select **ToolStripPanel2**.  
  
5.  Click the down-arrow button one time to position the control third in the list.  
  
     The **ToolStripPanel2** control is docked to the top of the form, underneath the main menu and above the other controls.  
  
6.  Select various controls in the **Document Outline** window and move them to different positions in the z-order. Note the effect of the z-order on the placement of docked controls. Use CTRL-Z or **Undo** on the **Edit** menu to undo your changes.  
  
## Checkpoint  
  
#### To test your form  
  
1.  Press F5 to compile and run your form.  
  
2.  Click the grip of a <xref:System.Windows.Forms.ToolStrip> control and drag the control to different positions on the form.  
  
     You can drag a <xref:System.Windows.Forms.ToolStrip> control from one <xref:System.Windows.Forms.ToolStripPanel> control to another.  
  
## Next Steps  
 In this walkthrough, you have created an MDI parent form with <xref:System.Windows.Forms.ToolStrip> controls and menu merging. You can use the <xref:System.Windows.Forms.ToolStrip> family of controls for many other purposes:  
  
-   Create shortcut menus for your controls with <xref:System.Windows.Forms.ContextMenuStrip>. For more information, see [ContextMenu Component Overview](../../../../docs/framework/winforms/controls/contextmenu-component-overview-windows-forms.md).  
  
-   Created a form with an automatically populated standard menu. For more information, see [Walkthrough: Providing Standard Menu Items to a Form](../../../../docs/framework/winforms/controls/walkthrough-providing-standard-menu-items-to-a-form.md).  
  
-   Give your <xref:System.Windows.Forms.ToolStrip> controls a professional appearance. For more information, see [How to: Set the ToolStrip Renderer for an Application](../../../../docs/framework/winforms/controls/how-to-set-the-toolstrip-renderer-for-an-application.md).  
  
## See Also  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ToolStrip>  
 <xref:System.Windows.Forms.StatusStrip>  
 [How to: Create MDI Parent Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-parent-forms.md)  
 [How to: Create MDI Child Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-child-forms.md)  
 [How to: Insert a MenuStrip into an MDI Drop-Down Menu](../../../../docs/framework/winforms/controls/how-to-insert-a-menustrip-into-an-mdi-drop-down-menu-windows-forms.md)  
 [ToolStrip Control](../../../../docs/framework/winforms/controls/toolstrip-control-windows-forms.md)
