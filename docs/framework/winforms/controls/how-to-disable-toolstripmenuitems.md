---
title: "How to: Disable ToolStripMenuItems"
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
  - "cpp"
helpviewer_keywords: 
  - "ToolStripMenuItems [Windows Forms], enabling"
  - "ToolStripMenuItems [Windows Forms], disabling"
  - "menu items [Windows Forms], disabling"
  - "disabling menu items"
  - "menu items [Windows Forms], enabling"
  - "menus [Windows Forms], disabling menu items"
ms.assetid: bcc1da84-50fd-41d2-8475-103b581d5654
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Disable ToolStripMenuItems
You can limit or broaden the commands a user may make by enabling and disabling menu items in response to user activities. Menu items are enabled by default when they are created, but this can be adjusted through the <xref:System.Windows.Forms.ToolStripMenuItem.Enabled%2A> property. You can manipulate this property at design time in the **Properties** window or programmatically by setting it in code.  
  
### To disable a menu item programmatically  
  
-   Within the method where you set the properties of the menu item, add code to set the <xref:System.Windows.Forms.ToolStripMenuItem.Enabled%2A> property to `false`.  
  
    ```vb  
    MenuItem1.Enabled = False  
    ```  
  
    ```csharp  
    menuItem1.Enabled = false;  
    ```  
  
    ```cpp  
    menuItem1->Enabled = false;  
    ```  
  
    > [!TIP]
    >  Disabling the first or top-level menu item in a menu hides all the menu items contained within the menu, but does not disable them. Likewise, disabling a menu item that has submenu items hides the submenu items, but does not disable them. If all the commands on a given menu are unavailable to the user, it is considered good programming practice to both hide and disable the entire menu, as this presents a clean user interface. You should hide and disable the menu, and disable every item and submenu item in the menu, because hiding alone does not prevent access to a menu command via a shortcut key. Set the <xref:System.Windows.Forms.ToolStripItem.Visible%2A> property of a top-level menu item to `false` to hide the entire menu.  
  
## See Also  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ToolStripMenuItem>  
 [How to: Hide ToolStripMenuItems](../../../../docs/framework/winforms/controls/how-to-hide-toolstripmenuitems.md)  
 [MenuStrip Control Overview](../../../../docs/framework/winforms/controls/menustrip-control-overview-windows-forms.md)
