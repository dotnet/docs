---
title: "Controls with Built-In Owner-Drawing Support"
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
  - "drawing [Windows Forms], owner"
  - "drawing [Windows Forms], custom"
  - "controls [Windows Forms], changing appearance"
  - "custom drawing"
  - "owner drawing"
ms.assetid: 3823d01e-9610-43e6-864d-99f9b7c2b351
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Controls with Built-In Owner-Drawing Support
Owner drawing in Windows Forms, which is also known as custom drawing, is a technique for changing the visual appearance of certain controls.  
  
> [!NOTE]
>  The word "control" in this topic is used to mean classes that derive from either <xref:System.Windows.Forms.Control> or <xref:System.ComponentModel.Component>.  
  
 Typically, Windows handles painting automatically by using property settings such as <xref:System.Windows.Forms.Control.BackColor%2A> to determine the appearance of a control. With owner drawing, you take over the painting process, changing elements of appearance that are not available by using properties. For example, many controls let you set the color of the text that is displayed, but you are limited to a single color. Owner drawing enables you to do things like display part of the text in black and part in red.  
  
 In practice, owner drawing is similar to drawing graphics on a form. For example, you could use graphics methods in a handler for the form's <xref:System.Windows.Forms.Control.Paint> event to emulate a `ListBox` control, but you would have to write your own code to handle all user interaction. With owner drawing, the control uses your code to draw its contents but otherwise retains all its intrinsic capabilities. You can use graphics methods to draw each item in the control or to customize some aspects of each item while you use the default appearance for other aspects of each item.  
  
## Owner Drawing in Windows Forms Controls  
 To perform owner drawing in controls that support it, you will typically set one property and handle one or more events.  
  
 Most controls that support owner drawing have an `OwnerDraw` or `DrawMode` property that indicates whether the control will raise its drawing-related event or events when it paints itself.  
  
 Controls that do not have an `OwnerDraw` or `DrawMode` property include the `DataGridView` control, which provides drawing events that occur automatically, and the `ToolStrip` control, which is drawn using an external rendering class that has its own drawing-related events.  
  
 There are many different kinds of drawing events, but a typical drawing event occurs in order to draw a single item within a control. The event handler receives an `EventArgs` object that contains information about the item being drawn and tools you can use to draw it. For example, this object typically contains the item's index number within its parent collection, a <xref:System.Drawing.Rectangle> that indicates the item's display boundaries, and a <xref:System.Drawing.Graphics> object for calling paint methods. For some events, the `EventArgs` object provides additional information about the item and methods that you can call to paint some aspects of the item by default, such as the background or a focus rectangle.  
  
 To create a reusable control that contains your owner-drawn customizations, create a new class that derives from a control class that supports owner drawing. Rather than handling drawing events, include your owner-drawing code in overrides for the appropriate `On`*EventName* method or methods in the new class. Make sure that you call the base class `On`*EventName* method or methods in this case so that users of your control can handle owner-drawing events and provide additional customization.  
  
 The following Windows Forms controls support owner drawing in all versions of the .NET Framework:  
  
-   <xref:System.Windows.Forms.ListBox>  
  
-   <xref:System.Windows.Forms.ComboBox>  
  
-   <xref:System.Windows.Forms.MenuItem> (used by <xref:System.Windows.Forms.MainMenu> and <xref:System.Windows.Forms.ContextMenu>)  
  
-   <xref:System.Windows.Forms.TabControl>  
  
 The following controls support owner drawing only in [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)]:  
  
-   <xref:System.Windows.Forms.ToolTip>  
  
-   <xref:System.Windows.Forms.ListView>  
  
-   <xref:System.Windows.Forms.TreeView>  
  
 The following controls support owner drawing and are new in [!INCLUDE[dnprdnext](../../../../includes/dnprdnext-md.md)]:  
  
-   <xref:System.Windows.Forms.DataGridView>  
  
-   <xref:System.Windows.Forms.ToolStrip>  
  
 The following sections provide additional details for each of these controls.  
  
### ListBox and ComboBox Controls  
 The <xref:System.Windows.Forms.ListBox> and <xref:System.Windows.Forms.ComboBox> controls enable you to draw individual items in the control either all in one size, or in varying sizes.  
  
> [!NOTE]
>  Although the <xref:System.Windows.Forms.CheckedListBox> control is derived from the <xref:System.Windows.Forms.ListBox> control, it does not support owner drawing.  
  
 To draw each item the same size, set the `DrawMode` property to <xref:System.Windows.Forms.DrawMode.OwnerDrawFixed> and handle the `DrawItem` event.  
  
 To draw each item using a different size, set the `DrawMode` property to <xref:System.Windows.Forms.DrawMode.OwnerDrawVariable> and handle both the `MeasureItem` and `DrawItem` events. The `MeasureItem` event lets you indicate the size of an item before the `DrawItem` event occurs for that item.  
  
 For more information, including code examples, see the following topics:  
  
-   <xref:System.Windows.Forms.ListBox.DrawMode%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ListBox.MeasureItem?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ListBox.DrawItem?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ComboBox.DrawMode%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ComboBox.MeasureItem?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ComboBox.DrawItem?displayProperty=nameWithType>  
  
-   [How to: Create Variable Sized Text in a ComboBox Control](../../../../docs/framework/winforms/controls/how-to-create-variable-sized-text-in-a-combobox-control.md)  
  
### MenuItem Component  
 The <xref:System.Windows.Forms.MenuItem> component represents a single menu item in a <xref:System.Windows.Forms.MainMenu> or <xref:System.Windows.Forms.ContextMenu> component.  
  
 To draw a <xref:System.Windows.Forms.MenuItem>, set its `OwnerDraw` property to `true` and handle its `DrawItem` event. To customize the size of the menu item before the `DrawItem` event occurs, handle the item's `MeasureItem` event.  
  
 For more information, including code examples, see the following reference topics:  
  
-   <xref:System.Windows.Forms.MenuItem.OwnerDraw%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.MenuItem.DrawItem?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.MenuItem.MeasureItem?displayProperty=nameWithType>  
  
### TabControl Control  
 The <xref:System.Windows.Forms.TabControl> control enables you to draw individual tabs in the control. Owner drawing affects only the tabs; the <xref:System.Windows.Forms.TabPage> contents are not affected.  
  
 To draw each tab in a <xref:System.Windows.Forms.TabControl>, set the `DrawMode` property to <xref:System.Windows.Forms.TabDrawMode.OwnerDrawFixed> and handle the `DrawItem` event. This event occurs once for each tab only when the tab is visible in the control.  
  
 For more information, including code examples, see the following reference topics:  
  
-   <xref:System.Windows.Forms.TabControl.DrawMode%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.TabControl.DrawItem?displayProperty=nameWithType>  
  
### ToolTip Component  
 The <xref:System.Windows.Forms.ToolTip> component enables you to draw the entire ToolTip when it is displayed.  
  
 To draw a <xref:System.Windows.Forms.ToolTip>, set its `OwnerDraw` property to `true` and handle its `Draw` event. To customize the size of the <xref:System.Windows.Forms.ToolTip> before the `Draw` event occurs, handle the `Popup` event and set the <xref:System.Windows.Forms.PopupEventArgs.ToolTipSize%2A> property in the event handler.  
  
 For more information, including code examples, see the following reference topics:  
  
-   <xref:System.Windows.Forms.ToolTip.OwnerDraw%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ToolTip.Draw?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ToolTip.Popup?displayProperty=nameWithType>  
  
### ListView Control  
 The <xref:System.Windows.Forms.ListView> control enables you to draw individual items, subitems, and column headers in the control.  
  
 To enable owner drawing in the control, set the `OwnerDraw` property to `true`.  
  
 To draw each item in the control, handle the `DrawItem` event.  
  
 To draw each subitem or column header in the control when the <xref:System.Windows.Forms.ListView.View%2A> property is set to <xref:System.Windows.Forms.View.Details>, handle the `DrawSubItem` and `DrawColumnHeader` events.  
  
 For more information, including code examples, see the following reference topics:  
  
-   <xref:System.Windows.Forms.ListView.OwnerDraw%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ListView.DrawItem?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ListView.DrawSubItem?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.ListView.DrawColumnHeader?displayProperty=nameWithType>  
  
### TreeView Control  
 The <xref:System.Windows.Forms.TreeView> control enables you to draw individual nodes in the control.  
  
 To draw only the text displayed in each node, set the `DrawMode` property to <xref:System.Windows.Forms.TreeViewDrawMode.OwnerDrawText> and handle the `DrawNode` event to draw the text.  
  
 To draw all elements of each node, set the `DrawMode` property to <xref:System.Windows.Forms.TreeViewDrawMode.OwnerDrawAll> and handle the `DrawNode` event to draw whichever elements you need, such as text, icons, check boxes, plus and minus signs, and lines connecting the nodes.  
  
 For more information, including code examples, see the following reference topics:  
  
-   <xref:System.Windows.Forms.TreeView.DrawMode%2A?displayProperty=nameWithType>  
  
-   <xref:System.Windows.Forms.TreeView.DrawNode?displayProperty=nameWithType>  
  
### DataGridView Control  
 The <xref:System.Windows.Forms.DataGridView> control enables you to draw individual cells and rows in the control.  
  
 To draw individual cells, handle the `CellPainting` event.  
  
 To draw individual rows or elements of rows, handle one or both of the `RowPrePaint` and `RowPostPaint` events. The `RowPrePaint` event occurs before the cells in a row are painted, and the `RowPostPaint` event occurs after the cells are painted. You can handle both events and the `CellPainting` event to paint row background, individual cells, and row foreground separately, or you can provide specific customizations where you need them and use the default display for other elements of the row.  
  
 For more information, including code examples, see the following topics:  
  
-   <xref:System.Windows.Forms.DataGridView.CellPainting>  
  
-   <xref:System.Windows.Forms.DataGridView.RowPrePaint>  
  
-   <xref:System.Windows.Forms.DataGridView.RowPostPaint>  
  
-   [How to: Customize the Appearance of Cells in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customize-the-appearance-of-cells-in-the-datagrid.md)  
  
-   [How to: Customize the Appearance of Rows in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customize-the-appearance-of-rows-in-the-datagrid.md)  
  
### ToolStrip Control  
 <xref:System.Windows.Forms.ToolStrip> and derived controls enable you to customize any aspect of their appearance.  
  
 To provide custom rendering for <xref:System.Windows.Forms.ToolStrip> controls, set the `Renderer` property of a <xref:System.Windows.Forms.ToolStrip>, <xref:System.Windows.Forms.ToolStripManager>, <xref:System.Windows.Forms.ToolStripPanel>, or <xref:System.Windows.Forms.ToolStripContentPanel> to a `ToolStripRenderer` object and handle one or more of the many drawing events provided by the `ToolStripRenderer` class. Alternatively, set a `Renderer` property to an instance of your own class derived from `ToolStripRenderer`, <xref:System.Windows.Forms.ToolStripProfessionalRenderer>, or <xref:System.Windows.Forms.ToolStripSystemRenderer> that implements or overrides specific `On`*EventName* methods.  
  
 For more information, including code examples, see the following topics:  
  
-   <xref:System.Windows.Forms.ToolStripRenderer>  
  
-   [How to: Create and Set a Custom Renderer for the ToolStrip Control in Windows Forms](../../../../docs/framework/winforms/controls/create-and-set-a-custom-renderer-for-the-toolstrip-control-in-wf.md)  
  
-   [How to: Custom Draw a ToolStrip Control](../../../../docs/framework/winforms/controls/how-to-custom-draw-a-toolstrip-control.md)  
  
## See Also  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)
