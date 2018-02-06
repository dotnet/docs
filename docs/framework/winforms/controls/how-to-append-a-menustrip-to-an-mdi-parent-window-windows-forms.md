---
title: "How to: Append a MenuStrip to an MDI Parent Window (Windows Forms)"
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
  - "MenuStrip control [Windows Forms], merging"
  - "MenuStrip control [Windows Forms], appending"
  - "MDI [Windows Forms], merging menu items"
ms.assetid: ab70c936-b452-4653-b417-17be57bb795b
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Append a MenuStrip to an MDI Parent Window (Windows Forms)
In some applications, the kind of a multiple-document interface (MDI) child window can be different from the MDI parent window. For example, the MDI parent might be a spreadsheet, and the MDI child might be a chart. In that case, you want to update the contents of the MDI parent's menu with the contents of the MDI child's menu as MDI child windows of different kinds are activated.  
  
 The following procedure uses the <xref:System.Windows.Forms.Form.IsMdiContainer%2A>, <xref:System.Windows.Forms.ToolStrip.AllowMerge%2A>, <xref:System.Windows.Forms.MergeAction>, and <xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A> properties to append the MDI child menu to the MDI parent menu. Closing the MDI child window removes the appended menu from the MDI parent.  
  
 Also see [Multiple-Document Interface (MDI) Applications](http://msdn.microsoft.com/library/xyhh2e7e\(v=vs.110\)).  
  
### To append a menu item to an MDI parent  
  
1.  Create a form and set its <xref:System.Windows.Forms.Form.IsMdiContainer%2A> property to `true`.  
  
2.  Add a <xref:System.Windows.Forms.MenuStrip> to `Form1` and set the <xref:System.Windows.Forms.ToolStrip.AllowMerge%2A> property of the <xref:System.Windows.Forms.MenuStrip> to `true`.  
  
3.  Set the <xref:System.Windows.Forms.ToolStripItem.Visible%2A> property of the `Form1`<xref:System.Windows.Forms.MenuStrip> to `false`.  
  
4.  Add a top-level menu item to the `Form1`<xref:System.Windows.Forms.MenuStrip> and set its <xref:System.Windows.Forms.Control.Text%2A> property to `&File`.  
  
5.  Add a submenu item to the `&File` menu item and set its <xref:System.Windows.Forms.Form.Text%2A> property to `&Open`.  
  
6.  Add a form to the project, add a <xref:System.Windows.Forms.MenuStrip> to the form, and set the <xref:System.Windows.Forms.ToolStrip.AllowMerge%2A> property of the `Form2`<xref:System.Windows.Forms.MenuStrip> to `true`.  
  
7.  Add a top-level menu item to the `Form2`<xref:System.Windows.Forms.MenuStrip> and set its <xref:System.Windows.Forms.Form.Text%2A> property to `&Special`.  
  
8.  Add two submenu items to the `&Special` menu item and set their <xref:System.Windows.Forms.Form.Text%2A> properties to `Command&1` and `Command&2`, respectively.  
  
9. Set the <xref:System.Windows.Forms.MergeAction> property of the `&Special`, `Command&1`, and `Command&2` menu items to <xref:System.Windows.Forms.MergeAction.Append>.  
  
10. Create an event handler for the <xref:System.Windows.Forms.Control.Click> event of the `&New`<xref:System.Windows.Forms.ToolStripMenuItem>.  
  
11. Within the event handler, insert code similar to the following code example to create and display new instances of `Form2` as MDI children of `Form1`.  
  
    ```vb  
    Private Sub openToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles openToolStripMenuItem.Click  
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
