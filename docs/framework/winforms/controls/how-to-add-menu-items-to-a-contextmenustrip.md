---
title: "How to: Add Menu Items to a ContextMenuStrip"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "ContextMenuStrips [Windows Forms], adding menu items"
  - "shortcut menus [Windows Forms], adding items"
  - "context menus [Windows Forms], adding menu items"
ms.assetid: 1ec14776-3ea2-4752-bd22-4fae0fd19e1a
---
# How to: Add Menu Items to a ContextMenuStrip
You can add just one menu item or several items at a time to a <xref:System.Windows.Forms.ContextMenuStrip>.  
  
### To add a single menu item to a ContextMenuStrip  
  
-   Use the <xref:System.Windows.Forms.ToolStripItemCollection.Add%2A> method to add one menu item to a <xref:System.Windows.Forms.ContextMenuStrip>.  
  
    ```vb  
    Me.contextMenuStrip1.Items.Add(Me.toolStripMenuItem1)  
    ```  
  
    ```csharp  
    this.contextMenuStrip1.Items.Add(toolStripMenuItem1);  
    ```  
  
### To add several menu items to a ContextMenuStrip  
  
-   Use the <xref:System.Windows.Forms.ToolStripItemCollection.AddRange%2A> method to add several menu items to a <xref:System.Windows.Forms.ContextMenuStrip>.  
  
    ```vb  
    Me.contextMenuStrip1.Items.AddRange(New _  
       System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem1, _  
          Me.toolStripMenuItem2})  
    ```  
  
    ```csharp  
    this.contextMenuStrip1.Items.AddRange(new   
       System.Windows.Forms.ToolStripItem[] {  
          this.toolStripMenuItem1, this.toolStripMenuItem2});  
    ```  
  
## See also
 [ContextMenuStrip Control](../../../../docs/framework/winforms/controls/contextmenustrip-control.md)
