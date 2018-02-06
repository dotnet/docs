---
title: "How to: Add Enhancements to ToolStripMenuItems"
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
  - "commands [Windows Forms], grouping on menus"
  - "check marks [Windows Forms], adding to menus"
  - "ToolStripMenuItems [Windows Forms], displaying access keys"
  - "menus [Windows Forms], grouping commands"
  - "menu items [Windows Forms], displaying shortcut keys"
  - "ToolStripMenuItems"
  - "separators [Windows Forms], displaying on menus"
  - "menu items [Windows Forms], showing separators"
  - "menu items [Windows Forms], adding check marks"
  - "ToolStripMenuItems [Windows Forms], adding check marks"
  - "menu items [Windows Forms], adding images"
  - "ToolStripSeparators [Windows Forms], displaying on MenuStrips"
  - "menu items [Windows Forms], displaying access keys"
  - "ToolStripMenuItems [Windows Forms], displaying shortcut keys"
  - "ToolStripMenuItems [Windows Forms], adding images"
  - "keyboard shortcuts [Windows Forms], displaying on menus"
  - "images [Windows Forms], adding to menus"
  - "ToolStripMenuItems [Windows Forms], showing separator bars"
ms.assetid: aa5f19bb-b545-4378-bfa6-36ba592f0d7c
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add Enhancements to ToolStripMenuItems
You can enhance the usability of <xref:System.Windows.Forms.MenuStrip> and <xref:System.Windows.Forms.ContextMenuStrip> controls in the following ways:  
  
-   Add check marks to designate whether a feature is turned on or off, such as whether a ruler is displayed along the margin of a word-processing application, or to indicate which file in a list of files is being displayed, such as on a **Window** menu.  
  
-   Add images that visually represent menu commands.  
  
-   Display shortcut keys to provide a keyboard alternative to the mouse for performing commands. For example, pressing CTRL+C performs the **Copy** command.  
  
-   Display access keys to provide a keyboard alternative to the mouse for menu navigation. For example, pressing ALT+F chooses the **File** menu.  
  
-   Show separator bars to group related commands and make menus more readable.  
  
### To display a check mark on a menu command  
  
-   Set its <xref:System.Windows.Forms.ToolStripMenuItem.Checked%2A> property to `true`.  
  
     This also sets the <xref:System.Windows.Forms.ToolStripMenuItem.CheckState%2A> property to `true`. Use this procedure only if you want the menu command to appear as checked by default, regardless of whether it is selected.  
  
### To display a check mark that changes state with each click  
  
-   Set the menu command's <xref:System.Windows.Forms.ToolStripMenuItem.CheckOnClick%2A> property to `true`.  
  
### To add an image to a menu command  
  
-   Set the menu command's <xref:System.Windows.Forms.ToolStripItem.Image%2A> property to the name of the image. If the <xref:System.Windows.Forms.ToolStripItemDisplayStyle> property of this menu command is set to <xref:System.Windows.Forms.ToolStripItemDisplayStyle.Text> or <xref:System.Windows.Forms.ToolStripItemDisplayStyle.None>, the image cannot be displayed.  
  
> [!NOTE]
>  The image margin can also show a check mark if you so choose. Also, you can set the <xref:System.Windows.Forms.ToolStripMenuItem.Checked%2A> property of the image to `true`, and the image will appear with a hatched border around it at run time.  
  
### To display a shortcut key for a menu command  
  
-   Set the menu command's <xref:System.Windows.Forms.ToolStripMenuItem.ShortcutKeys%2A> property to the desired keyboard combination, such as CTRL+O for the **Open** menu command, and set the <xref:System.Windows.Forms.ToolStripMenuItem.ShowShortcutKeys%2A> property to `true`.  
  
### To display custom shortcut keys for a menu command  
  
-   Set the menu command's <xref:System.Windows.Forms.ToolStripMenuItem.ShortcutKeyDisplayString%2A> property to the desired keyboard combination, such as CTRL+SHIFT+O rather than SHIFT+CTRL+O, and set the <xref:System.Windows.Forms.ToolStripMenuItem.ShowShortcutKeys%2A> property to `true`.  
  
### To display an access key for a menu command  
  
-   When you set the <xref:System.Windows.Forms.ToolStripItem.Text%2A> property for the menu command, enter an ampersand (&) before the letter you want to be underlined as the access key. For example, typing `&Open` as the <xref:System.Windows.Forms.ToolStripItem.Text%2A> property of a menu item will result in a menu command that appears as **O**pen.  
  
     To navigate to this menu command, press ALT to give focus to the <xref:System.Windows.Forms.MenuStrip>, and press the access key of the menu name. When the menu opens and shows items with access keys, you only need to press the access key to select the menu command.  
  
> [!NOTE]
>  Avoid defining duplicate access keys, such as defining ALT+F twice in the same menu system. The selection order of duplicate access keys cannot be guaranteed.  
  
### To display a separator bar between menu commands  
  
-   After you define your <xref:System.Windows.Forms.MenuStrip> and the items it will contain, use the <xref:System.Windows.Forms.ToolStripItemCollection.AddRange%2A> or <xref:System.Windows.Forms.ToolStripItemCollection.Add%2A> method to add the menu commands and <xref:System.Windows.Forms.ToolStripSeparator> controls to the <xref:System.Windows.Forms.MenuStrip> in the order you want.  
  
    ```vb  
    ' This code adds a top-level File menu to the MenuStrip.  
    Me.menuStrip1.Items.Add(New ToolStripMenuItem() _  
    {Me.fileToolStripMenuItem})  
  
    ' This code adds the New and Open menu commands, a separator bar,   
    ' and the Save and Exit menu commands to the top-level File menu,   
    ' in that order.  
    Me.fileToolStripMenuItem.DropDownItems.AddRange(New _  
    ToolStripMenuItem() {Me.newToolStripMenuItem, _  
    Me.openToolStripMenuItem, Me.toolStripSeparator1, _  
    Me.saveToolStripMenuItem, Me.exitToolStripMenuItem})  
    ```  
  
    ```csharp  
    // This code adds a top-level File menu to the MenuStrip.  
    this.menuStrip1.Items.Add(new ToolStripItem[]_  
    {this.fileToolStripMenuItem});  
  
    // This code adds the New and Open menu commands, a separator bar,   
    // and the Save and Exit menu commands to the top-level File menu,   
    // in that order.  
    this.fileToolStripMenuItem.DropDownItems.AddRange(new _  
    ToolStripItem[] {  
    this.newToolStripMenuItem,  
    this.openToolStripMenuItem,  
    this.toolStripSeparator1,  
    this.saveToolStripMenuItem,  
    this.exitToolStripMenuItem});  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ToolStripMenuItem>  
 [MenuStrip Control Overview](../../../../docs/framework/winforms/controls/menustrip-control-overview-windows-forms.md)
