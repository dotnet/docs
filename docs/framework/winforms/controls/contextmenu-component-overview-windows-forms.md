---
title: "ContextMenu Component Overview (Windows Forms)"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "ContextMenu"
helpviewer_keywords: 
  - "ContextMenu component [Windows Forms], about ContextMenu component"
  - "context menus [Windows Forms], ContextMenu component"
  - "shortcut menus [Windows Forms], ContextMenu component"
ms.assetid: 49d6398f-d3c4-4679-84fa-1de07b68b05e
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ContextMenu Component Overview (Windows Forms)
> [!IMPORTANT]
>  Although <xref:System.Windows.Forms.MenuStrip> and <xref:System.Windows.Forms.ContextMenuStrip> replace and add functionality to the <xref:System.Windows.Forms.MainMenu> and <xref:System.Windows.Forms.ContextMenu> controls of previous versions, <xref:System.Windows.Forms.MainMenu> and <xref:System.Windows.Forms.ContextMenu> are retained for both backward compatibility and future use if you choose.  
  
 With the Windows Forms <xref:System.Windows.Forms.ContextMenu> component, you can provide users with an easily accessible shortcut menu of frequently used commands that are associated with the selected object. The items in a shortcut menu are frequently a subset of the items from main menus that appear elsewhere in the application. A user can typically access a shortcut menu by right-clicking the mouse. On Windows Forms, shortcut menus are associated with controls.  
  
## Key Properties  
 You can associate a shortcut menu with a control by setting the control's <xref:System.Windows.Forms.Control.ContextMenu%2A> property to the <xref:System.Windows.Forms.ContextMenu> component. A single shortcut menu can be associated with multiple controls, but each control can have only one shortcut menu.  
  
 The key property of the <xref:System.Windows.Forms.ContextMenu> component is the <xref:System.Windows.Forms.Menu.MenuItems%2A> property. You can add menu items by programmatically creating <xref:System.Windows.Forms.MenuItem> objects and adding them to the <xref:System.Windows.Forms.Menu.MenuItemCollection> of the shortcut menu. Because the items in a shortcut menu are usually drawn from other menus, you will most frequently add items to a shortcut menu by copying them.  
  
## See Also  
 <xref:System.Windows.Forms.ContextMenu>  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ContextMenuStrip>
