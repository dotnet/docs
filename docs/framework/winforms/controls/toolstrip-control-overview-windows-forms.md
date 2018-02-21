---
title: "ToolStrip Control Overview (Windows Forms)"
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
  - "Toolstrip"
helpviewer_keywords: 
  - "ToolStrip control [Windows Forms], about ToolStrip control"
  - "toolbars [Windows Forms], what's new in Windows Forms"
  - "toolbars [Windows Forms]"
  - "what's new [Windows Forms], toolbars"
ms.assetid: 81d067ed-297c-4dad-90de-1bcac15336ec
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ToolStrip Control Overview (Windows Forms)
The Windows Forms <xref:System.Windows.Forms.ToolStrip> control and its associated classes provide a common framework for combining user interface elements into toolbars, status bars, and menus. <xref:System.Windows.Forms.ToolStrip> controls offer a rich design-time experience that includes in-place activation and editing, custom layout, and rafting, which is the ability of toolbars to share horizontal or vertical space.  
  
 Although <xref:System.Windows.Forms.ToolStrip> replaces and adds functionality to the control in previous versions, <xref:System.Windows.Forms.ToolBar> is retained for both backward compatibility and future use if desired.  
  
## Features of the ToolStrip Controls  
 Use the <xref:System.Windows.Forms.ToolStrip> control to:  
  
-   Present a common user interface across containers.  
  
-   Create easily customized, commonly employed toolbars that support advanced user interface and layout features, such as docking, rafting, buttons with text and images, drop-down buttons and controls, overflow buttons, and run-time reordering of <xref:System.Windows.Forms.ToolStrip> items.  
  
-   Support overflow and run-time item reordering. The overflow feature moves items to a drop-down menu when there is not enough room to display them in a <xref:System.Windows.Forms.ToolStrip>.  
  
-   Support the typical appearance and behavior of the operating system through a common rendering model.  
  
-   Handle events consistently for all containers and contained items, in the same way you handle events for other controls.  
  
-   Drag items from one <xref:System.Windows.Forms.ToolStrip> to another or within a <xref:System.Windows.Forms.ToolStrip>.  
  
-   Create drop-down controls and user interface type editors with advanced layouts in a <xref:System.Windows.Forms.ToolStripDropDown>.  
  
 Use the <xref:System.Windows.Forms.ToolStripControlHost> class to use other controls on a <xref:System.Windows.Forms.ToolStrip> and gain <xref:System.Windows.Forms.ToolStrip> functionality for them.  
  
 You can extend the functionality and modify the appearance and behavior by using the <xref:System.Windows.Forms.ToolStripRenderer>, <xref:System.Windows.Forms.ToolStripProfessionalRenderer>, and <xref:System.Windows.Forms.ToolStripManager> along with the <xref:System.Windows.Forms.ToolStripRenderMode> and <xref:System.Windows.Forms.ToolStripManagerRenderMode> enumerations.  
  
 The <xref:System.Windows.Forms.ToolStrip> control is highly configurable and extensible, and it provides many properties, methods, and events to customize appearance and behavior. Below are some noteworthy members:  
  
### Important ToolStrip Members  
  
|Name|Description|  
|----------|-----------------|  
|<xref:System.Windows.Forms.ToolStrip.Dock%2A>|Gets or sets which edge of the parent container a <xref:System.Windows.Forms.ToolStrip> is docked to.|  
|<xref:System.Windows.Forms.ToolStrip.AllowItemReorder%2A>|Gets or sets a value indicating whether drag-and-drop and item reordering are handled privately by the <xref:System.Windows.Forms.ToolStrip> class.|  
|<xref:System.Windows.Forms.ToolStrip.LayoutStyle%2A>|Gets or sets a value indicating how the <xref:System.Windows.Forms.ToolStrip> lays out its items.|  
|<xref:System.Windows.Forms.ToolStripItem.Overflow%2A>|Gets or sets whether a <xref:System.Windows.Forms.ToolStripItem> is attached to the <xref:System.Windows.Forms.ToolStrip> or <xref:System.Windows.Forms.ToolStripOverflowButton> or can float between the two.|  
|<xref:System.Windows.Forms.ToolStrip.IsDropDown%2A>|Gets a value indicating whether a <xref:System.Windows.Forms.ToolStripItem> displays other items in a drop-down list when the <xref:System.Windows.Forms.ToolStripItem> is clicked.|  
|<xref:System.Windows.Forms.ToolStrip.OverflowButton%2A>|Gets the <xref:System.Windows.Forms.ToolStripItem> that is the overflow button for a <xref:System.Windows.Forms.ToolStrip> with overflow enabled.|  
|<xref:System.Windows.Forms.ToolStrip.Renderer%2A>|Gets or sets a <xref:System.Windows.Forms.ToolStripRenderer> used to customize the appearance and behavior (look and feel) of a <xref:System.Windows.Forms.ToolStrip>.|  
|<xref:System.Windows.Forms.ToolStrip.RenderMode%2A>|Gets or sets the painting styles to be applied to the <xref:System.Windows.Forms.ToolStrip>.|  
|<xref:System.Windows.Forms.ToolStrip.RendererChanged>|Raised when the <xref:System.Windows.Forms.ToolStrip.Renderer%2A> property changes.|  
  
 The <xref:System.Windows.Forms.ToolStrip> control's flexibility is achieved through the use of a number of companion classes. Below are some of the most noteworthy:  
  
### Important ToolStrip Companion Classes  
  
|Name|Description|  
|----------|-----------------|  
|<xref:System.Windows.Forms.MenuStrip>|Replaces and adds functionality to the <xref:System.Windows.Forms.MainMenu> class.|  
|<xref:System.Windows.Forms.StatusStrip>|Replaces and adds functionality to the <xref:System.Windows.Forms.StatusBar> class.|  
|<xref:System.Windows.Forms.ContextMenuStrip>|Replaces and adds functionality to the <xref:System.Windows.Forms.ContextMenu> class.|  
|<xref:System.Windows.Forms.ToolStripItem>|Abstract base class that manages events and layout for all the elements that a <xref:System.Windows.Forms.ToolStrip>, <xref:System.Windows.Forms.ToolStripControlHost>, or <xref:System.Windows.Forms.ToolStripDropDown> can contain.|  
|<xref:System.Windows.Forms.ToolStripContainer>|Provides a container with a panel on each side of the form in which controls can be arranged in various ways.|  
|<xref:System.Windows.Forms.ToolStripRenderer>|Handles the painting functionality for <xref:System.Windows.Forms.ToolStrip> objects.|  
|<xref:System.Windows.Forms.ToolStripProfessionalRenderer>|Provides Microsoft Office-style appearance.|  
|<xref:System.Windows.Forms.ToolStripManager>|Controls <xref:System.Windows.Forms.ToolStrip> rendering and rafting, and the merging of <xref:System.Windows.Forms.MenuStrip>, <xref:System.Windows.Forms.ToolStripDropDownMenu>, and <xref:System.Windows.Forms.ToolStripMenuItem> objects.|  
|<xref:System.Windows.Forms.ToolStripManagerRenderMode>|Specifies the painting style (custom, Windows XP, or Microsoft Office Professional) applied to multiple <xref:System.Windows.Forms.ToolStrip> objects contained in a form.|  
|<xref:System.Windows.Forms.ToolStripRenderMode>|Specifies the painting style (custom, Windows XP, or Microsoft Office Professional) applied to one <xref:System.Windows.Forms.ToolStrip> object contained in a form.|  
|<xref:System.Windows.Forms.ToolStripControlHost>|Hosts other controls that are not specifically <xref:System.Windows.Forms.ToolStrip> controls but for which you want <xref:System.Windows.Forms.ToolStrip> functionality.|  
|<xref:System.Windows.Forms.ToolStripItemPlacement>|Specifies whether a <xref:System.Windows.Forms.ToolStripItem> is to be laid out on the main <xref:System.Windows.Forms.ToolStrip>, on the overflow <xref:System.Windows.Forms.ToolStrip>, or neither.|  
  
 For more information, see [ToolStrip Technology Summary](../../../../docs/framework/winforms/controls/toolstrip-technology-summary.md) and [ToolStrip Control Architecture](../../../../docs/framework/winforms/controls/toolstrip-control-architecture.md).  
  
## See Also  
 <xref:System.Windows.Forms.ToolStrip>  
 <xref:System.Windows.Forms.MenuStrip>  
 <xref:System.Windows.Forms.ContextMenuStrip>  
 <xref:System.Windows.Forms.StatusStrip>  
 <xref:System.Windows.Forms.ToolStripItem>  
 <xref:System.Windows.Forms.ToolStripDropDown>
