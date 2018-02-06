---
title: "How to: Hide ToolStripMenuItems"
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
  - "ToolStripMenuItems [Windows Forms], hiding"
  - "MenuStrip control [Windows Forms], hiding menu items"
  - "menus [Windows Forms], hiding menu items"
  - "menu items [Windows Forms], hiding"
  - "hiding menu items"
ms.assetid: 418a768f-808a-44cd-8cef-f4e161883621
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Hide ToolStripMenuItems
Hiding menu items is a way to control the user interface of your application and restrict user commands. Often, you will want to hide an entire menu when all of the menu items on it are unavailable. This presents fewer distractions for the user. Furthermore, you might want to both hide and disable the menu or menu item, as hiding alone does not prevent the user from accessing a menu command by using a shortcut key.  
  
### To hide any menu item programmatically  
  
-   Within the method where you set the properties of the menu item, add code to set the <xref:System.Windows.Forms.ToolStripItem.Visible%2A> property to `false`.  
  
    ```vb  
    MenuItem3.Visible = False  
    ```  
  
    ```csharp  
    menuItem3.Visible = false;  
    ```  
  
    ```cpp  
    menuItem3->Visible = false;  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.ToolStripItem.Visible%2A>  
 <xref:System.Windows.Forms.MenuStrip>  
 [MenuStrip Control Overview](../../../../docs/framework/winforms/controls/menustrip-control-overview-windows-forms.md)  
 [How to: Disable ToolStripMenuItems](../../../../docs/framework/winforms/controls/how-to-disable-toolstripmenuitems.md)
