---
title: "How to: Hide ToolStripMenuItems Using the Designer"
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
  - "ToolStripMenuItems [Windows Forms], hiding menu items in designer"
  - "MenuStrip control [Windows Forms], hiding menu items in designer"
  - "menu items [Windows Forms], hiding"
ms.assetid: 8f1b057e-3d8a-4f11-88df-935f7b29a836
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Hide ToolStripMenuItems Using the Designer
Hiding menu items is a way to control the user interface (UI) of your application and restrict user commands. Often, you will want to hide an entire menu when all of the menu items on it are unavailable. This presents fewer distractions for the user. Furthermore, you might want to both hide and disable the menu or menu item, as hiding alone does not prevent the user from accessing a menu command by using a shortcut key. For more information on disabling menu items, see [How to: Disable ToolStripMenuItems Using the Designer](../../../../docs/framework/winforms/controls/how-to-disable-toolstripmenuitems-using-the-designer.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To hide a top-level menu and its submenu items  
  
1.  Select the top-level menu item and set its <xref:System.Windows.Forms.ToolStripItem.Visible%2A> or <xref:System.Windows.Forms.ToolStripItem.Available%2A> property to `false`.  
  
     When you hide the top-level menu item, all menu items within that menu are also hidden. If you click somewhere other than on the <xref:System.Windows.Forms.MenuStrip> after setting <xref:System.Windows.Forms.ToolStripItem.Visible%2A> to `false`, the entire top-level menu item and its submenu items disappear from your form, thus showing you the run-time effect of your action. To display the hidden top-level menu item at design time, click on the <xref:System.Windows.Forms.MenuStrip> in the **Component Tray**, in **Document Outline**, or at the top of the property grid.  
  
> [!NOTE]
>  You will rarely hide an entire menu except for multiple document interface (MDI) child menus in a merging scenario.  
  
### To hide a submenu item  
  
1.  Select the submenu item and set its <xref:System.Windows.Forms.ToolStripItem.Visible%2A> property to `false`.  
  
     When you hide a submenu item, it remains visible on your form at design time so that you can easily select it for further work. It will actually be hidden at run time.  
  
## See Also  
 <xref:System.Windows.Forms.ToolStripItem.Visible%2A>  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ToolStripMenuItem.Enabled%2A>  
 <xref:System.Windows.Forms.ToolStripItem.Available%2A>  
 <xref:System.Windows.Forms.ToolStripMenuItem.Overflow%2A>  
 [MenuStrip Control Overview](../../../../docs/framework/winforms/controls/menustrip-control-overview-windows-forms.md)  
 [How to: Disable ToolStripMenuItems Using the Designer](../../../../docs/framework/winforms/controls/how-to-disable-toolstripmenuitems-using-the-designer.md)
