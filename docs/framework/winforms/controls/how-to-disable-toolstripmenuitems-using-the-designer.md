---
title: "How to: Disable ToolStripMenuItems Using the Designer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "ToolStripMenuItems [Windows Forms], disabling in designer"
  - "MenuStrip control [Windows Forms], disabling menu items in designer"
  - "menu items [Windows Forms], disabling"
  - "menus [Windows Forms], disabling items"
ms.assetid: 985e311e-7d67-4205-b5a3-d045b68a4a03
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Disable ToolStripMenuItems Using the Designer
You can limit or broaden the commands a user may make by enabling and disabling menu items in response to user activities. Menu items are enabled by default when they are created, but this can be adjusted through the <xref:System.Windows.Forms.ToolStripMenuItem.Enabled%2A> property. You can manipulate this property at design time in the **Properties** window or programmatically by setting it in code. For more information, see [How to: Disable ToolStripMenuItems](../../../../docs/framework/winforms/controls/how-to-disable-toolstripmenuitems.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To disable a menu item at design time  
  
1.  With the menu item selected on the form, set the <xref:System.Windows.Forms.ToolStripMenuItem.Enabled%2A> property to `false`.  
  
    > [!TIP]
    >  Disabling the first or top-level menu item in a menu disables all the menu items contained within the menu. Likewise, disabling a menu item that has submenu items disables the submenu items. If all the commands on a given menu are unavailable to the user, it is considered good programming practice to both hide and disable the entire menu, as this presents a clean user interface. You should both hide and disable the menu, as hiding alone does not prevent access to a menu command via a shortcut key. Set the <xref:System.Windows.Forms.ToolStripItem.Visible%2A> property of a top-level menu item to `false` to hide the entire menu.  
  
## See Also  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ToolStripMenuItem>  
 [How to: Hide ToolStripMenuItems](../../../../docs/framework/winforms/controls/how-to-hide-toolstripmenuitems.md)  
 [MenuStrip Control Overview](../../../../docs/framework/winforms/controls/menustrip-control-overview-windows-forms.md)
