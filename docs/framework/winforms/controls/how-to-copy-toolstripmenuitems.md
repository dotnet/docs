---
title: "How to: Copy ToolStripMenuItems"
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
  - "menu items [Windows Forms], copying and pasting"
  - "MenuStrip control [Windows Forms], arranging items"
  - "ToolStripMenuItems [Windows Forms], copying and pasting"
ms.assetid: 17ef4207-e92e-4db2-b648-27246e6517ad
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Copy ToolStripMenuItems
At design time, you can copy entire top-level menus and their submenu items to a different place on the <xref:System.Windows.Forms.MenuStrip>. You can also copy individual menu items between top-level menus or change the position of menu items within a menu.  
  
### To copy a top-level menu and its submenu items to another top-level location  
  
1.  Left-click the menu that you want to copy and press CTRL+C, or right-click the menu and select **Copy** from the shortcut menu.  
  
2.  Left-click the top-level menu that is after the intended new location and press CTRL+V, or right-click the top-level menu item that is before the intended new location and select **Paste** from the shortcut menu.  
  
     The menu that you copied is inserted before the selected top-level menu.  
  
### To copy a top-level menu and its submenu items to a drop-down location  
  
1.  Left-click the menu that you want to move and press CTRL+C, or right-click the menu and select **Copy** from the shortcut menu.  
  
2.  In the destination top-level menu, left-click the submenu item that is above the intended new location and press CTRL+V, or right-click the submenu item that is above the intended new location and select **Paste** from the shortcut menu.  
  
     The menu that you copied is inserted before the selected submenu item.  
  
### To copy a submenu item to another menu  
  
1.  Left-click the submenu item that you want to copy and press CTRL+C, or right-click the submenu item and choose **Copy** from the shortcut menu.  
  
2.  Left-click the menu that will contain the submenu item that you cut.  
  
3.  Left-click the submenu item that is before the intended new location and press CTRL+V, or right-click the submenu item that is before the intended new location and select **Paste** from the shortcut menu.  
  
     The submenu item that you copied is inserted before the selected submenu item.  
  
## See Also  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ToolStripMenuItem>  
 [MenuStrip Control Overview](../../../../docs/framework/winforms/controls/menustrip-control-overview-windows-forms.md)
