---
title: "Merging Menu Items in the Windows Forms MenuStrip Control"
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
  - "MenuStrip [Windows Forms], merging"
  - "merging [Windows Forms], general concepts"
ms.assetid: 95e113ba-f362-4dda-8a76-6d95ddc45cee
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Merging Menu Items in the Windows Forms MenuStrip Control
If you have a multiple-document interface (MDI) application, you can merge menu items or whole menus from the child form into the menus of the parent form.  
  
 This topic describes the basic concepts associated with merging menu items in an MDI application.  
  
## General Concepts  
 Merging procedures involve both a target and a source control:  
  
-   The target is the <xref:System.Windows.Forms.MenuStrip> control on the main or MDI parent form into which you are merging menu items.  
  
-   The source is the <xref:System.Windows.Forms.MenuStrip> control on the MDI child form that contains the menu items you want to merge into the target menu.  
  
 The <xref:System.Windows.Forms.MenuStrip.MdiWindowListItem%2A> property identifies the menu item whose drop-down list you will populate with the titles of the current MDI parent form's MDI children. For example, you typically list MDI children that are currently open on the **Window** menu.  
  
 The <xref:System.Windows.Forms.ToolStripMenuItem.IsMdiWindowListEntry%2A> property identifies which menu items come from a <xref:System.Windows.Forms.MenuStrip> on an MDI child form.  
  
 You can merge menu items manually or automatically. The menu items merge in the same way for both methods, but the merge is activated differently, as discussed in the "Manual Merging" and "Automatic Merging" sections later in this topic. In both manual and automatic merging, each merge action affects the next merge action.  
  
 <xref:System.Windows.Forms.MenuStrip> merging moves menu items from one <xref:System.Windows.Forms.ToolStrip> to another rather than cloning them, as was the case with <xref:System.Windows.Forms.MainMenu>.  
  
## MergeAction Values  
 You set the merge action on menu items in the source <xref:System.Windows.Forms.MenuStrip> using the <xref:System.Windows.Forms.MergeAction> property.  
  
 The following table describes the meaning and typical use of the available merge actions.  
  
|MergeAction Value|Description|Typical Use|  
|-----------------------|-----------------|-----------------|  
|<xref:System.Windows.Forms.MergeAction.Append>|(Default) Adds the source item to the end of the target item's collection.|Adding menu items to the end of the menu when some part of the program is activated.|  
|<xref:System.Windows.Forms.MergeAction.Insert>|Adds the source item to the target item's collection, in the location specified by the <xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A> property set on the source item.|Adding menu items to the middle or the beginning of the menu when some part of the program is activated.<br /><br /> If the value of <xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A> is the same for both menu items, they are added in reverse order. Set <xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A> appropriately to preserve the original order.|  
|<xref:System.Windows.Forms.MergeAction.Replace>|Finds a text match, or uses the <xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A> value if no text match is found, and then replaces the matching target menu item with the source menu item.|Replacing a target menu item with a source menu item of the same name that does something different.|  
|<xref:System.Windows.Forms.MergeAction.MatchOnly>|Finds a text match, or uses the <xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A> value if no text match is found, and then adds all the drop-down items from the source to the target.|Building a menu structure that inserts or adds menu items into a submenu, or removes menu items from a submenu. For example, you can add a menu item from an MDI child to a main <xref:System.Windows.Forms.MenuStrip>**Save As** menu.<br /><br /> <xref:System.Windows.Forms.MergeAction.MatchOnly> allows you to navigate through the menu structure without taking any action. It provides a way to evaluate the subsequent items.|  
|<xref:System.Windows.Forms.MergeAction.Remove>|Finds a text match, or uses the <xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A> value if no text match is found, and then removes the item from the target.|Removing a menu item from the target <xref:System.Windows.Forms.MenuStrip>.|  
  
## Manual Merging  
 Only <xref:System.Windows.Forms.MenuStrip> controls participate in automatic merging. To combine the items of other controls, such as <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.StatusStrip> controls, you must merge them manually, by calling the <xref:System.Windows.Forms.ToolStripManager.Merge%2A> and <xref:System.Windows.Forms.ToolStripManager.RevertMerge%2A> methods in your code as required.  
  
## Automatic Merging  
 You can use automatic merging for MDI applications by activating the source form. To use a <xref:System.Windows.Forms.MenuStrip> in an MDI application, set the <xref:System.Windows.Forms.Form.MainMenuStrip%2A> property to the target <xref:System.Windows.Forms.MenuStrip> so that merging actions performed on the source <xref:System.Windows.Forms.MenuStrip> are reflected in the target <xref:System.Windows.Forms.MenuStrip>.  
  
 You can trigger automatic merging by activating the <xref:System.Windows.Forms.MenuStrip> on the MDI source. Upon activation, the source <xref:System.Windows.Forms.MenuStrip> is merged into the MDI target. When a new form becomes active, the merge is reverted on the last form and triggered on the new form. You can control this behavior by setting the <xref:System.Windows.Forms.ToolStripItem.MergeAction%2A> property as needed on each <xref:System.Windows.Forms.ToolStripItem>, and by setting the <xref:System.Windows.Forms.ToolStrip.AllowMerge%2A> property on each <xref:System.Windows.Forms.MenuStrip>.  
  
## See Also  
 <xref:System.Windows.Forms.ToolStripManager>  
 <xref:System.Windows.Forms.MenuStrip>  
 [MenuStrip Control](../../../../docs/framework/winforms/controls/menustrip-control-windows-forms.md)  
 [How to: Create an MDI Window List with MenuStrip](../../../../docs/framework/winforms/controls/how-to-create-an-mdi-window-list-with-menustrip-windows-forms.md)  
 [How to: Set Up Automatic Menu Merging for MDI Applications](../../../../docs/framework/winforms/controls/how-to-set-up-automatic-menu-merging-for-mdi-applications.md)
