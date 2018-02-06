---
title: "How to: Insert a MenuStrip into an MDI Drop-Down Menu (Windows Forms)"
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
  - "MenuStrip control [Windows Forms], inserting"
  - "MenuStrip control [Windows Forms], merging"
  - "MDI [Windows Forms], merging menu items"
ms.assetid: 0fad444e-26d9-49af-8860-044d9c10d608
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Insert a MenuStrip into an MDI Drop-Down Menu (Windows Forms)
In some applications, the kind of a multiple-document interface (MDI) child window can be different from the MDI parent window. For example, the MDI parent might be a spreadsheet, and the MDI child might be a chart. In that case, you want to update the contents of the MDI parent's menu with the contents of the MDI child's menu as MDI child windows of different kinds are activated.  
  
 The following procedure uses the <xref:System.Windows.Forms.Form.IsMdiContainer%2A>, <xref:System.Windows.Forms.ToolStrip.AllowMerge%2A>, <xref:System.Windows.Forms.MergeAction>, and <xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A> properties to insert a group of menu items from the MDI child menu into the drop-down part of the MDI parent menu. Closing the MDI child window removes the inserted menu items from the MDI parent.  
  
### To insert a MenuStrip into an MDI drop-down menu  
  
1.  Create a form and set its <xref:System.Windows.Forms.Form.IsMdiContainer%2A> property to `true`.  
  
2.  Add a <xref:System.Windows.Forms.MenuStrip> to `Form1` and set the <xref:System.Windows.Forms.ToolStrip.AllowMerge%2A> property of the <xref:System.Windows.Forms.MenuStrip> to `true`.  
  
3.  Add a top-level menu item to the `Form1`<xref:System.Windows.Forms.MenuStrip> and set its <xref:System.Windows.Forms.Control.Text%2A> property to `&File`.  
  
4.  Add three submenu items to the `&File` menu item and set their <xref:System.Windows.Forms.ToolStripItem.Text%2A> properties to `&Open`, `&Import from`, and `E&xit`.  
  
5.  Add two submenu items to the `&Import from` submenu item and set their <xref:System.Windows.Forms.ToolStripItem.Text%2A> properties to `&Word` and `&Excel`.  
  
6.  Add a form to the project, add a <xref:System.Windows.Forms.MenuStrip> to the form, and set the <xref:System.Windows.Forms.ToolStrip.AllowMerge%2A> property of the `Form2`<xref:System.Windows.Forms.MenuStrip> to `true`.  
  
7.  Add a top-level menu item to the `Form2`<xref:System.Windows.Forms.MenuStrip> and set its <xref:System.Windows.Forms.ToolStripItem.Text%2A> property to `&File`.  
  
8.  Add submenu items to the `&File` menu of `Form2` in the following order: a <xref:System.Windows.Forms.ToolStripSeparator>, `&Save`, `&Close``and Save`, and another <xref:System.Windows.Forms.ToolStripSeparator>.  
  
9. Set the <xref:System.Windows.Forms.MergeAction> and <xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A> properties of the `Form2` menu items as shown in the following table.  
  
    |Form2 menu item|MergeAction value|MergeIndex value|  
    |---------------------|-----------------------|----------------------|  
    |File|MatchOnly|-1|  
    |Separator|Insert|2|  
    |Save|Insert|3|  
    |Save and Close|Insert|4|  
    |Separator|Insert|5|  
  
10. Create an event handler for the <xref:System.Windows.Forms.Control.Click> event of the `&Open`<xref:System.Windows.Forms.ToolStripMenuItem>.  
  
11. Within the event handler, insert code similar to the following code example to create and display new instances of `Form2` as MDI children of `Form1`.  
  
    ```vb  
    Private Sub openToolStripMenuItem_Click(ByVal sender As System.Object, _  
    ByVal e As System.EventArgs) Handles openToolStripMenuItem.Click  
        Dim NewMDIChild As New Form2()  
        'Set the parent form of the child window.  
            NewMDIChild.MdiParent = Me  
        'Display the new form.  
            NewMDIChild.Show()  
    End Sub  
    ```  
  
    ```csharp  
    private void openToolStripMenuItem_Click(object sender, EventArgs e)  
    {  
        Form2 newMDIChild = new Form2();  
        // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;  
        // Display the new form.  
            newMDIChild.Show();  
    }  
    ```  
  
12. Place code similar to the following code example in the `&Open`<xref:System.Windows.Forms.ToolStripMenuItem> to register the event handler.  
  
    ```vb  
    Private Sub openToolStripMenuItem_Click(sender As Object, e As _  
    EventArgs) Handles openToolStripMenuItem.Click  
    ```  
  
    ```csharp  
    this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);  
    ```  
  
## Compiling the Code  
 This example requires:  
  
-   Two <xref:System.Windows.Forms.Form> controls named `Form1` and `Form2`.  
  
-   A <xref:System.Windows.Forms.MenuStrip> control on `Form1` named `menuStrip1`, and a <xref:System.Windows.Forms.MenuStrip> control on `Form2` named `menuStrip2`.  
  
-   References to the <xref:System?displayProperty=nameWithType> and <xref:System.Windows.Forms?displayProperty=nameWithType> assemblies.  
  
## See Also  
 [How to: Create MDI Parent Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-parent-forms.md)  
 [How to: Create MDI Child Forms](../../../../docs/framework/winforms/advanced/how-to-create-mdi-child-forms.md)  
 [MenuStrip Control Overview](../../../../docs/framework/winforms/controls/menustrip-control-overview-windows-forms.md)
