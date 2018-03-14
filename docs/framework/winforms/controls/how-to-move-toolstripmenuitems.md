---
title: "How to: Move ToolStripMenuItems"
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
  - "ToolStripMenuItems [Windows Forms], moving"
  - "menus [Windows Forms], arranging items"
  - "ToolStripMenuItems [Windows Forms], dragging and dropping"
  - "menu items [Windows Forms], moving"
  - "menu items [Windows Forms], cutting and pasting"
  - "menu items [Windows Forms], dragging and dropping"
  - "MenuStrip control [Windows Forms], arranging items"
  - "ToolStripMenuItems [Windows Forms], cutting and pasting"
ms.assetid: cab9e03e-4edd-4c25-b3e3-bd1edc602bd9
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Move ToolStripMenuItems
At design time, you can move entire top-level menus and their menu items to a different place on the <xref:System.Windows.Forms.MenuStrip>. You can also move individual menu items between top-level menus or change the position of menu items within a menu.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To move a top-level menu and its menu items to another top-level location  
  
1.  Click and hold down the left mouse button on the menu that you want to move.  
  
2.  Drag the insertion point to the top-level menu that is before the intended new location and release the left mouse button.  
  
     The selected menu moves to the right of the insertion point.  
  
### To move a top-level menu and its menu items to a drop-down location  
  
1.  Left-click the menu that you want to move and press CTRL+X, or right-click the menu and select **Cut** from the shortcut menu.  
  
2.  In the destination top-level menu, left-click the menu item above the intended new location and press CTRL+V, or right-click the menu item above the intended new location and select **Paste** from the shortcut menu.  
  
     The menu that you cut is inserted after the selected menu item.  
  
### To move a menu item within a menu using the Items Collection Editor  
  
1.  Right-click the menu that contains the menu item you want to move.  
  
2.  From the shortcut menu, choose **Edit DropDownItems**.  
  
3.  In the **Items Collection Editor**, left-click the menu item you want to move.  
  
4.  Click the UP and DOWN ARROW keys to move the menu item within the menu.  
  
5.  Click **OK**.  
  
### To move a menu item within a menu using the keyboard  
  
1.  Press and hold down the ALT key.  
  
2.  Click and hold the left mouse button on the menu item that you want to move.  
  
3.  Drag the menu item to the new location and release the left mouse button.  
  
### To move a menu item to another menu  
  
1.  Left-click the menu item that you want to move and press CTRL+X, or right-click the menu item and choose **Cut** from the shortcut menu.  
  
2.  Left-click the menu that will contain the menu item that you cut.  
  
3.  Left-click the menu item that is before the intended new location and press CTRL+V, or right-click the menu item that is before the intended new location and select **Paste** from the shortcut menu.  
  
     The menu item that you cut is inserted after the selected menu item.  
  
## See Also  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ToolStripMenuItem>  
 [MenuStrip Control Overview](../../../../docs/framework/winforms/controls/menustrip-control-overview-windows-forms.md)
