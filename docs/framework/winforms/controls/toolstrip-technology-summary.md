---
title: "ToolStrip Technology Summary"
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
  - "ToolStrip control [Windows Forms], technology summary"
  - "status bars [Windows Forms], technology summary"
  - "toolbars [Windows Forms], technology summary"
  - "menus [Windows Forms], technology summary"
ms.assetid: e8d61973-7af9-429f-9df5-05a899c15a7b
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ToolStrip Technology Summary
This topic summarizes information about the `ToolStrip` control and the classes that support its use.  
  
 The `ToolStrip` control and its associated classes provide a complete solution for creating toolbars, status bars, and menus.  
  
## Namespaces  
 <xref:System.Windows.Forms?displayProperty=nameWithType>  
  
## Background  
 With the `ToolStrip` control and its associated classes, you can create advanced toolbar functionality that has consistent and professional appearance and behavior. The `ToolStrip` control and classes offer the following improvements over previous controls:  
  
-   A more consistent event model.  
  
-   A more consistent design-time behavior that contains task lists and item collection editors.  
  
-   Custom rendering with `ToolStripManager` and `ToolStripRenderer`.  
  
-   Built-in rafting (sharing of horizontal or vertical space within the tool area when docked) with the `ToolStripContainer` and `ToolStripPanel`.  
  
-   Design-time and run-time reordering of items with the <xref:System.Windows.Forms.ToolStrip.AllowItemReorder%2A> property.  
  
-   Relocation of items to an overflow menu with the <xref:System.Windows.Forms.ToolStrip.CanOverflow%2A> property.  
  
-   Completely configurable control location with the `ToolStripContainer`, `ToolStripPanel`, and `ToolStripContentPanel`.  
  
-   Hosting of `ToolStrip`, traditional, or custom controls using `ToolStripControlHost`.  
  
-   Merging of `ToolStrip` controls using `ToolStripPanel`.  
  
 `ToolStrip` is the extensible base class for `MenuStrip`, `ContextMenuStrip`, and `StatusStrip`. These controls are <xref:System.Windows.Forms.ToolStripItem> containers that inherit common behavior and event handling, extended so that each implementation deals with the behavior that is appropriate for it. Controls that derive from <xref:System.Windows.Forms.ToolStripItem> are listed in the following table. The base `ToolStrip` class handles painting, user input, and drag-and-drop events for these controls.  
  
 The `ToolStrip`, `MenuStrip`, `ContextMenuStrip`, and `StatusStrip` controls replace the previous toolbar, menu, shortcut menu, and status bar controls, although those controls are retained for backward compatibility.  
  
## ToolStrip Classes at a Glance  
 The following table shows the ToolStrip classes grouped by technology area.  
  
|Technology area|Class|  
|---------------------|-----------|  
|Toolbar, Status, and Menu containers|<xref:System.Windows.Forms.ToolStrip><br /><br /> <xref:System.Windows.Forms.MenuStrip><br /><br /> <xref:System.Windows.Forms.ContextMenuStrip><br /><br /> <xref:System.Windows.Forms.StatusStrip><br /><br /> <xref:System.Windows.Forms.ToolStripDropDownMenu>|  
|ToolStrip items|<xref:System.Windows.Forms.ToolStripLabel><br /><br /> <xref:System.Windows.Forms.ToolStripDropDownItem><br /><br /> <xref:System.Windows.Forms.ToolStripMenuItem><br /><br /> <xref:System.Windows.Forms.ToolStripButton><br /><br /> <xref:System.Windows.Forms.ToolStripStatusLabel><br /><br /> <xref:System.Windows.Forms.ToolStripSeparator><br /><br /> <xref:System.Windows.Forms.ToolStripControlHost><br /><br /> <xref:System.Windows.Forms.ToolStripComboBox><br /><br /> <xref:System.Windows.Forms.ToolStripTextBox><br /><br /> <xref:System.Windows.Forms.ToolStripProgressBar><br /><br /> <xref:System.Windows.Forms.ToolStripDropDownButton><br /><br /> <xref:System.Windows.Forms.ToolStripSplitButton>|  
|Location|<xref:System.Windows.Forms.ToolStripContainer><br /><br /> <xref:System.Windows.Forms.ToolStripContentPanel><br /><br /> <xref:System.Windows.Forms.ToolStripPanel>|  
|Presentation and rendering|<xref:System.Windows.Forms.ToolStripManager><br /><br /> <xref:System.Windows.Forms.ToolStripRenderer><br /><br /> <xref:System.Windows.Forms.ToolStripProfessionalRenderer><br /><br /> <xref:System.Windows.Forms.ToolStripRenderMode><br /><br /> <xref:System.Windows.Forms.ToolStripManagerRenderMode>|  
  
## ToolStrip Design-Time Features  
 The <xref:System.Windows.Forms.ToolStrip> family of controls provides a rich set of tools and templates for in-place editing and defining the foundation of the user interface so that you can quickly create a working application.  
  
### Task Dialog Boxes  
 In Visual Studio, clicking the smart tag on a control in the designer displays a task list for convenient access to many frequently used commands.  
  
-   [MenuStrip Tasks Dialog Box](http://msdn.microsoft.com/library/ms233645\(v=vs.110\))  
  
-   [ToolStrip Tasks Dialog Box](http://msdn.microsoft.com/library/ms233648\(v=vs.110\))  
  
-   [ContextMenuStrip Tasks Dialog Box](http://msdn.microsoft.com/library/ms233646\(v=vs.110\))  
  
-   [StatusStrip Tasks Dialog Box](http://msdn.microsoft.com/library/ms233642\(v=vs.110\))  
  
-   [ToolStripContainer Tasks Dialog Box](http://msdn.microsoft.com/library/ms233647\(v=vs.110\))  
  
### Items Collection Editors  
 In Visual Studio, when you click **Edit Items** on the task list or right-click the control and select **Edit Items** in the shortcut menu, the collection editor for the control is displayed. Collection editors let you add, remove, and reorder items that the control contains. You can also view and change the properties for the control and the control's items.  
  
-   [MenuStrip Items Collection Editor](http://msdn.microsoft.com/library/ms233625\(v=vs.110\))  
  
-   [StatusStrip Items Collection Editor](http://msdn.microsoft.com/library/ms233631\(v=vs.110\))  
  
-   [ContextMenuStrip Items Collection Editor](http://msdn.microsoft.com/library/ms233641\(v=vs.110\))  
  
-   [ToolStrip Items Collection Editor](http://msdn.microsoft.com/library/ms233643\(v=vs.110\))  
  
## Hosting Controls  
 The <xref:System.Windows.Forms.ToolStripControlHost> class provides built-in wrappers for <xref:System.Windows.Forms.ToolStripComboBox>, <xref:System.Windows.Forms.ToolStripTextBox>, and <xref:System.Windows.Forms.ToolStripProgressBar> controls. You can also host any other existing or COM control in a <xref:System.Windows.Forms.ToolStripControlHost>.  
  
 For an example of control hosting, see [How to: Wrap a Windows Forms Control with ToolStripControlHost](../../../../docs/framework/winforms/controls/how-to-wrap-a-windows-forms-control-with-toolstripcontrolhost.md).  
  
## Rendering  
 <xref:System.Windows.Forms.ToolStrip> classes implement a rendering scheme that is significantly different from other Windows Forms controls. With this scheme, you can easily apply styles and themes.  
  
 To apply a style to a <xref:System.Windows.Forms.ToolStrip> and all the <xref:System.Windows.Forms.ToolStripItem> objects it contains, you do not have to handle the <xref:System.Windows.Forms.ToolStripItem.Paint> event for each item. Instead, you can set the <xref:System.Windows.Forms.ToolStrip.RenderMode%2A> property to one of the <xref:System.Windows.Forms.ToolStripRenderMode> values other than <xref:System.Windows.Forms.ToolStripRenderMode.Custom>. Alternatively, you can set the <xref:System.Windows.Forms.ToolStrip.Renderer%2A> directly to any class that inherits from the <xref:System.Windows.Forms.ToolStripRenderer> class. Setting this property automatically sets the <xref:System.Windows.Forms.ToolStrip.RenderMode%2A>.  
  
 You can apply the same style to multiple <xref:System.Windows.Forms.ToolStrip> objects in the same application by setting the <xref:System.Windows.Forms.ToolStrip.RenderMode%2A> to <xref:System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode> and setting the <xref:System.Windows.Forms.ToolStripManager.RenderMode%2A> or <xref:System.Windows.Forms.ToolStripManager.Renderer%2A> property to <xref:System.Windows.Forms.ToolStripManagerRenderMode> that you want or <xref:System.Windows.Forms.ToolStripRenderer> value, respectively.  
  
 For examples of rendering, see [How to: Create and Set a Custom Renderer for the ToolStrip Control in Windows Forms](../../../../docs/framework/winforms/controls/create-and-set-a-custom-renderer-for-the-toolstrip-control-in-wf.md).  
  
## Styles and Themes  
 <xref:System.Windows.Forms.ToolStrip> and associated classes provide an easy way to support visual styles and custom appearance that do not require overriding the <xref:System.Windows.Forms.ToolStripItem.OnPaint%2A> methods for each item. Use the <xref:System.Windows.Forms.ToolStripItem.DisplayStyle%2A> and the <xref:System.Windows.Forms.ToolStrip.RenderMode%2A> and <xref:System.Windows.Forms.ToolStrip.Renderer%2A> properties.  
  
## Rafting and Docking  
 You can raft, dock, or absolutely position <xref:System.Windows.Forms.ToolStrip> controls. <xref:System.Windows.Forms.ToolStrip> items are laid out by the <xref:System.Windows.Forms.ToolStrip.LayoutEngine%2A> of the container.  
  
 *Rafting* is the ability of toolbars to share horizontal or vertical space. A Windows form can have a <xref:System.Windows.Forms.ToolStripContainer> that in turn has panels on the form's left, right, top, and bottom sides for positioning and rafting <xref:System.Windows.Forms.ToolStrip>, <xref:System.Windows.Forms.MenuStrip>, and <xref:System.Windows.Forms.StatusStrip> controls. Multiple <xref:System.Windows.Forms.ToolStrip> controls stack vertically if you put them in the left or right <xref:System.Windows.Forms.ToolStripContainer>. They stack horizontally if you put them in the top or bottom <xref:System.Windows.Forms.ToolStripContainer>. You can use the central <xref:System.Windows.Forms.ToolStripContentPanel> of the <xref:System.Windows.Forms.ToolStripContainer> to position traditional controls on the form.  
  
 Any or all <xref:System.Windows.Forms.ToolStripContainer> controls are directly selectable at design time and can be deleted. A <xref:System.Windows.Forms.ToolStripContainer> is expandable and collapsible, and resizes with the controls that it contains.  
  
 *Docking* is the specifying of a control's simple location on the form's left, right, top, or bottom side.  
  
 The advantage of rafting over docking is that <xref:System.Windows.Forms.ToolStrip>, <xref:System.Windows.Forms.MenuStrip>, and <xref:System.Windows.Forms.StatusStrip> controls can share horizontal or vertical space with other controls.  
  
 Most of the <xref:System.Windows.Forms.ToolStrip> controls can be docked to the form like other controls instead of using rafting. You can also specify that a <xref:System.Windows.Forms.ToolStrip> control be freely positioned on the form by removing it from its <xref:System.Windows.Forms.ToolStripContainer> and setting its `Dock` property to `None`, or you can specify its absolute position by setting the respective <xref:System.Windows.Forms.Control.Location%2A> property. See [How to: Move a ToolStrip Out of a ToolStripContainer onto a Form](../../../../docs/framework/winforms/controls/how-to-move-a-toolstrip-out-of-a-toolstripcontainer-onto-a-form.md).  
  
 Use one or more <xref:System.Windows.Forms.ToolStripPanel> controls for more flexibility, especially for Multiple Document Interface (MDI) applications, or if you do not need a <xref:System.Windows.Forms.ToolStripContainer>. A <xref:System.Windows.Forms.ToolStripPanel> provides a dockable space for locating and rafting <xref:System.Windows.Forms.ToolStrip> controls but not traditional controls. By default, the <xref:System.Windows.Forms.ToolStripPanel> does not appear in the designer **Toolbox**, but you can put it there by right-clicking the **Toolbox**, and then click **Choose Items**. You can also programmatically access the <xref:System.Windows.Forms.ToolStripPanel> like any other class.  
  
 The <xref:System.Windows.Forms.ToolStrip>, <xref:System.Windows.Forms.MenuStrip>, and <xref:System.Windows.Forms.StatusStrip> let items overflow. This is similar to the way these items behave on Microsoft Office toolbars.  
  
## See Also  
 [ToolStrip Control Overview](../../../../docs/framework/winforms/controls/toolstrip-control-overview-windows-forms.md)  
 [ToolStrip Control Architecture](../../../../docs/framework/winforms/controls/toolstrip-control-architecture.md)
