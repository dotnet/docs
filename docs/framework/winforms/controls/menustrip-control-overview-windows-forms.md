---
title: "MenuStrip Control Overview (Windows Forms)"
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
  - "MenuStrip"
helpviewer_keywords: 
  - "MenuStrip control [Windows Forms], about MenuStrip control"
  - "menus [Windows Forms], creating"
ms.assetid: f45516e5-bf01-4468-b851-d45f4c33c055
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# MenuStrip Control Overview (Windows Forms)
Menus expose functionality to your users by holding commands that are grouped by a common theme.  
  
 The <xref:System.Windows.Forms.MenuStrip> control is new to this version of Visual Studio and the .NET Framework. With the control, you can easily create menus like those found in Microsoft Office.  
  
 The <xref:System.Windows.Forms.MenuStrip> control supports the multiple-document interface (MDI) and menu merging, tool tips, and overflow. You can enhance the usability and readability of your menus by adding access keys, shortcut keys, check marks, images, and separator bars.  
  
 The <xref:System.Windows.Forms.MenuStrip> control replaces and adds functionality to the <xref:System.Windows.Forms.MainMenu> control; however, the <xref:System.Windows.Forms.MainMenu> control is retained for backward compatibility and future use if you choose.  
  
## Ways to Use the MenuStrip Control  
 Use the <xref:System.Windows.Forms.MenuStrip> control to:  
  
-   Create easily customized, commonly employed menus that support advanced user interface and layout features, such as text and image ordering and alignment, drag-and-drop operations, MDI, overflow, and alternate modes of accessing menu commands.  
  
-   Support the typical appearance and behavior of the operating system.  
  
-   Handle events consistently for all containers and contained items, in the same way you handle events for other controls.  
  
 The following table shows some particularly important properties of <xref:System.Windows.Forms.MenuStrip> and associated classes.  
  
|Property|Description|  
|--------------|-----------------|  
|<xref:System.Windows.Forms.MenuStrip.MdiWindowListItem%2A>|Gets or sets the <xref:System.Windows.Forms.ToolStripMenuItem> that is used to display a list of MDI child forms.|  
|<xref:System.Windows.Forms.ToolStripItem.MergeAction%2A?displayProperty=nameWithType>|Gets or sets how child menus are merged with parent menus in MDI applications.|  
|<xref:System.Windows.Forms.ToolStripItem.MergeIndex%2A?displayProperty=nameWithType>|Gets or sets the position of a merged item within a menu in MDI applications.|  
|<xref:System.Windows.Forms.Form.IsMdiContainer%2A?displayProperty=nameWithType>|Gets or sets a value indicating whether the form is a container for MDI child forms.|  
|<xref:System.Windows.Forms.MenuStrip.ShowItemToolTips%2A>|Gets or sets a value indicating whether tool tips are shown for the <xref:System.Windows.Forms.MenuStrip>.|  
|<xref:System.Windows.Forms.MenuStrip.CanOverflow%2A>|Gets or sets a value indicating whether the <xref:System.Windows.Forms.MenuStrip> supports overflow functionality.|  
|<xref:System.Windows.Forms.ToolStripMenuItem.ShortcutKeys%2A>|Gets or sets the shortcut keys associated with the <xref:System.Windows.Forms.ToolStripMenuItem>.|  
|<xref:System.Windows.Forms.ToolStripMenuItem.ShowShortcutKeys%2A>|Gets or sets a value indicating whether the shortcut keys that are associated with the <xref:System.Windows.Forms.ToolStripMenuItem> are displayed next to the <xref:System.Windows.Forms.ToolStripMenuItem>.|  
  
 The following table shows the important <xref:System.Windows.Forms.MenuStrip> companion classes.  
  
|Class|Description|  
|-----------|-----------------|  
|<xref:System.Windows.Forms.ToolStripMenuItem>|Represents a selectable option displayed on a <xref:System.Windows.Forms.MenuStrip> or <xref:System.Windows.Forms.ContextMenuStrip>.|  
|<xref:System.Windows.Forms.ContextMenuStrip>|Represents a shortcut menu.|  
|<xref:System.Windows.Forms.ToolStripDropDown>|Represents a control that allows the user to select a single item from a list that is displayed when the user clicks a <xref:System.Windows.Forms.ToolStripDropDownButton> or a higher-level menu item.|  
|<xref:System.Windows.Forms.ToolStripDropDownItem>|Provides basic functionality for controls derived from <xref:System.Windows.Forms.ToolStripItem> that display drop-down items when clicked.|  
  
## See Also  
 <xref:System.Windows.Forms.ToolStrip>  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ContextMenuStrip>  
 <xref:System.Windows.Forms.StatusStrip>  
 <xref:System.Windows.Forms.ToolStripItem>  
 <xref:System.Windows.Forms.ToolStripDropDown>
