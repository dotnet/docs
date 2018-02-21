---
title: "ToolStrip Control Architecture"
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
  - "ToolStrip control [Windows Forms], architecture"
ms.assetid: 71df2d18-862e-4701-9ff9-c1fe606f94f2
caps.latest.revision: 32
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ToolStrip Control Architecture
The <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.ToolStripItem> classes provide a flexible, extensible system for displaying toolbar, status, and menu items. These classes are all contained in the <xref:System.Windows.Forms> namespace and they are all typically named with the "ToolStrip" prefix (such as <xref:System.Windows.Forms.ToolStripOverflow>) or with the "Strip" suffix (such as <xref:System.Windows.Forms.MenuStrip>).  
  
## ToolStrip  
 The following topics describe <xref:System.Windows.Forms.ToolStrip> and the controls that derive from it.  
  
 <xref:System.Windows.Forms.ToolStrip> is the abstract base class for <xref:System.Windows.Forms.MenuStrip>, <xref:System.Windows.Forms.StatusStrip>, and <xref:System.Windows.Forms.ContextMenuStrip>. The following object model shows the <xref:System.Windows.Forms.ToolStrip> inheritance hierarchy.  
  
 ![ToolStrip Object Model](../../../../docs/framework/winforms/controls/media/toolstripobjectmodel.gif "ToolStripObjectModel")  
ToolStrip object model  
  
 You can access all the items in a <xref:System.Windows.Forms.ToolStrip> through the <xref:System.Windows.Forms.ToolStrip.Items%2A> collection. You can access all the items in a <xref:System.Windows.Forms.ToolStripDropDownItem> through the <xref:System.Windows.Forms.ToolStripDropDownItem.DropDownItems%2A> collection. In a class derived from <xref:System.Windows.Forms.ToolStrip>, you can also use the <xref:System.Windows.Forms.ToolStrip.DisplayedItems%2A> property to access only those items that are currently displayed. These are the items that are not currently in an overflow menu.  
  
 The following items are specifically designed to work seamlessly with both <xref:System.Windows.Forms.ToolStripSystemRenderer> and <xref:System.Windows.Forms.ToolStripProfessionalRenderer> in all orientations. They are available by default at design time for the <xref:System.Windows.Forms.ToolStrip> control:  
  
-   <xref:System.Windows.Forms.ToolStripButton>  
  
-   <xref:System.Windows.Forms.ToolStripSeparator>  
  
-   <xref:System.Windows.Forms.ToolStripLabel>  
  
-   <xref:System.Windows.Forms.ToolStripDropDownButton>  
  
-   <xref:System.Windows.Forms.ToolStripSplitButton>  
  
-   <xref:System.Windows.Forms.ToolStripTextBox>  
  
-   <xref:System.Windows.Forms.ToolStripComboBox>  
  
### MenuStrip  
 <xref:System.Windows.Forms.MenuStrip> is the top-level container that supersedes <xref:System.Windows.Forms.MainMenu>. It also provides key handling and multiple document interface (MDI) features. Functionally, <xref:System.Windows.Forms.ToolStripDropDownItem> and <xref:System.Windows.Forms.ToolStripMenuItem> work along with <xref:System.Windows.Forms.MenuStrip>, although they are derived from <xref:System.Windows.Forms.ToolStripItem>.  
  
 The following items are specifically designed to work seamlessly with both <xref:System.Windows.Forms.ToolStripSystemRenderer> and <xref:System.Windows.Forms.ToolStripProfessionalRenderer> in all orientations. They are available by default at design time for the <xref:System.Windows.Forms.MenuStrip> control:  
  
-   <xref:System.Windows.Forms.ToolStripMenuItem>  
  
-   <xref:System.Windows.Forms.ToolStripTextBox>  
  
-   <xref:System.Windows.Forms.ToolStripComboBox>  
  
### StatusStrip  
 <xref:System.Windows.Forms.StatusStrip> replaces the <xref:System.Windows.Forms.StatusBar> control. Special features of <xref:System.Windows.Forms.StatusStrip> include a custom table layout, support for the form's sizing and moving grips, and the `Spring` property, which allows a <xref:System.Windows.Forms.ToolStripStatusLabel> to fill available space automatically.  
  
 The following items are specifically designed to work seamlessly with both <xref:System.Windows.Forms.ToolStripSystemRenderer> and <xref:System.Windows.Forms.ToolStripProfessionalRenderer> in all orientations. They are available by default at design time for the <xref:System.Windows.Forms.StatusStrip> control:  
  
-   <xref:System.Windows.Forms.ToolStripStatusLabel>  
  
-   <xref:System.Windows.Forms.ToolStripDropDownButton>  
  
-   <xref:System.Windows.Forms.ToolStripSplitButton>  
  
-   <xref:System.Windows.Forms.ToolStripProgressBar>  
  
### ContextMenuStrip  
 <xref:System.Windows.Forms.ContextMenuStrip> replaces <xref:System.Windows.Forms.ContextMenu>. You can associate a <xref:System.Windows.Forms.ContextMenuStrip> with any control, and a right mouse click automatically displays the context menu (or shortcut menu). You can show a <xref:System.Windows.Forms.ContextMenuStrip> programmatically by using the <xref:System.Windows.Forms.ToolStripDropDown.Show%2A> method. <xref:System.Windows.Forms.ContextMenuStrip> supports cancelable <xref:System.Windows.Forms.ToolStripDropDown.Opening> and <xref:System.Windows.Forms.ToolStripDropDown.Closing> events to handle dynamic population and multiple-click scenarios. <xref:System.Windows.Forms.ContextMenuStrip> supports images, menu-item check state, text, access keys, shortcuts, and cascading menus.  
  
 The following items are specifically designed to work seamlessly with both <xref:System.Windows.Forms.ToolStripSystemRenderer> and <xref:System.Windows.Forms.ToolStripProfessionalRenderer> in all orientations. They are available by default at design time for the <xref:System.Windows.Forms.ContextMenuStrip> control:  
  
-   <xref:System.Windows.Forms.ToolStripMenuItem>  
  
-   <xref:System.Windows.Forms.ToolStripSeparator>  
  
-   <xref:System.Windows.Forms.ToolStripTextBox>  
  
-   <xref:System.Windows.Forms.ToolStripComboBox>  
  
### ToolStrip Generic Features  
 The following topics describe features and behavior that are generic to the <xref:System.Windows.Forms.ToolStrip> and derived controls.  
  
#### Painting  
 You can do custom painting in <xref:System.Windows.Forms.ToolStrip> controls in several ways. As with other Windows Forms controls, the <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.ToolStripItem> both have overridable `OnPaint` methods and `Paint` events. As with regular painting, the coordinate system is relative to the client area of the control; that is, the upper left-hand corner of the control is 0, 0. The `Paint` event and `OnPaint` method for a <xref:System.Windows.Forms.ToolStripItem> behave like other control paint events.  
  
 The <xref:System.Windows.Forms.ToolStrip> controls also provide finer access to the rendering of the items and container through the <xref:System.Windows.Forms.ToolStripRenderer> class, which has overridable methods for painting the background, item background, item image, item arrow, item text, and border of the <xref:System.Windows.Forms.ToolStrip>. The event arguments for these methods expose several properties such as rectangles, colors, and text formats that you can adjust as desired.  
  
 To adjust just a few aspects of how an item is painted, you typically override the <xref:System.Windows.Forms.ToolStripRenderer>.  
  
 If you are writing a new item and want to control all aspects of the painting, override the `OnPaint` method. From within `OnPaint`, you can use methods from the <xref:System.Windows.Forms.ToolStripRenderer>.  
  
 By default, the <xref:System.Windows.Forms.ToolStrip> is double buffered, taking advantage of the <xref:System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer> setting.  
  
#### Parenting  
 The concept of container ownership and parenting is more complex in <xref:System.Windows.Forms.ToolStrip> controls than in other Windows Forms container controls. That is necessary to support dynamic scenarios such as overflow, sharing drop-down items across multiple <xref:System.Windows.Forms.ToolStrip> items, and to support the generation of a <xref:System.Windows.Forms.ContextMenuStrip> from a control.  
  
 The following list describes members related to parenting and explains their use.  
  
-   <xref:System.Windows.Forms.ToolStripDropDown.OwnerItem%2A> accesses the item that is the source of the drop-down item. This is similar to <xref:System.Windows.Forms.ContextMenuStrip.SourceControl%2A>, but instead of returning a control, it returns a <xref:System.Windows.Forms.ToolStripItem>.  
  
-   <xref:System.Windows.Forms.ContextMenuStrip.SourceControl%2A> determines which control is the source of the <xref:System.Windows.Forms.ContextMenuStrip> when multiple controls share the same <xref:System.Windows.Forms.ContextMenuStrip>.  
  
-   <xref:System.Windows.Forms.ToolStripItem.GetCurrentParent%2A> is a read-only accessor to the <xref:System.Windows.Forms.ToolStripItem.Parent%2A> property. A parent differs from an owner in that a parent denotes the returned current <xref:System.Windows.Forms.ToolStrip> in which the item is displayed, which might be in the overflow area.  
  
-   <xref:System.Windows.Forms.ToolStripItem.Owner%2A> returns the <xref:System.Windows.Forms.ToolStrip> whose Items collection contains the current <xref:System.Windows.Forms.ToolStripItem>. This is the best way to reference <xref:System.Windows.Forms.ToolStrip.ImageList%2A> or other properties in the top-level <xref:System.Windows.Forms.ToolStrip> without writing special code to handle overflow.  
  
#### Behavior of Inherited Controls  
 The following controls are locked whenever they are used in inheritance:  
  
-   <xref:System.Windows.Forms.ToolStrip>  
  
-   <xref:System.Windows.Forms.MenuStrip>  
  
-   <xref:System.Windows.Forms.ContextMenuStrip>  
  
-   <xref:System.Windows.Forms.StatusStrip>  
  
-   <xref:System.Windows.Forms.ToolStripPanel> that includes the panels in a <xref:System.Windows.Forms.ToolStripContainer> and also individual <xref:System.Windows.Forms.ToolStripPanel> controls.  
  
 For example, create a new Windows Forms application by using one or more of the controls in the previous list. Set the access modifier of one or more controls to `public` or `protected`, and then build the project. Add a form that inherits from the first form, and then select an inherited control. The control appears locked, behaving as if its access modifier was `private`.  
  
#### ToolStripContainer Support of Inheritance  
 The <xref:System.Windows.Forms.ToolStripContainer> control supports limited inherited scenarios, similar to the following example:  
  
1.  Create a new Windows Forms application.  
  
2.  Add a <xref:System.Windows.Forms.ToolStripContainer> to the form.  
  
3.  Set the access modifier of the <xref:System.Windows.Forms.ToolStripContainer> to `public` or `protected`.  
  
4.  Add any combination of <xref:System.Windows.Forms.ToolStrip>, <xref:System.Windows.Forms.MenuStrip>, and <xref:System.Windows.Forms.ContextMenuStrip> controls to the <xref:System.Windows.Forms.ToolStripPanel> regions of the <xref:System.Windows.Forms.ToolStripContainer>.  
  
5.  Build the project.  
  
6.  Add a form that inherits from the first form.  
  
7.  Select the inherited <xref:System.Windows.Forms.ToolStripContainer> on the form.  
  
#### Inherited Behavior of Child Controls  
 After you complete the previous steps, the following inherited behavior occurs:  
  
-   In the designer, the control appears with an inherited icon.  
  
-   The <xref:System.Windows.Forms.ToolStripPanel> controls are locked; you cannot select or rearrange their contents.  
  
-   You can add controls to the <xref:System.Windows.Forms.ToolStripContentPanel>, move the controls, and make them child controls of the <xref:System.Windows.Forms.ToolStripContentPanel>.  
  
-   Your changes persist after building the form.  
  
    > [!NOTE]
    >  Remove the access modifiers from all <xref:System.Windows.Forms.ToolStripPanel> controls that are part of a <xref:System.Windows.Forms.ToolStripContainer>. The access modifier of the <xref:System.Windows.Forms.ToolStripContainer> governs the whole control.  
  
#### Partial Trust  
 The limitations of `ToolStrip`s under partial trust are designed to prevent inadvertent entry of personal information that might be used by unauthorized persons or services. The protective measures are as follows:  
  
-   `ToolStripDropDown` controls require <xref:System.Security.Permissions.UIPermissionWindow.AllWindows> to display items in a <xref:System.Windows.Forms.ToolStripControlHost>. This applies to both intrinsic controls such as <xref:System.Windows.Forms.ToolStripTextBox>, <xref:System.Windows.Forms.ToolStripComboBox>, and <xref:System.Windows.Forms.ToolStripProgressBar> as well as to user-created controls. If this requirement is not met, these items are not displayed. No exception is thrown.  
  
-   Setting the <xref:System.Windows.Forms.ToolStripDropDown.AutoClose%2A> property to `false` is not allowed, and the cancelable <xref:System.Windows.Forms.ToolStripDropDown.Closing> event parameter is ignored. This makes it impossible to enter more than one keystroke without dismissing the drop-down item. If this requirement is not met, such items are not displayed. No exception is thrown.  
  
-   Many keystroke handling events will not be raised if they occur in partial trust contexts other than <xref:System.Security.Permissions.UIPermissionWindow.AllWindows>.  
  
-   Access keys are not processed when <xref:System.Security.Permissions.UIPermissionWindow.AllWindows> is not granted.  
  
#### Usage  
 The following usage patterns have a bearing on <xref:System.Windows.Forms.ToolStrip> layout, keyboard interaction, and end-user behavior:  
  
-   Joined in a <xref:System.Windows.Forms.ToolStripPanel>  
  
     The <xref:System.Windows.Forms.ToolStrip> can be repositioned within the <xref:System.Windows.Forms.ToolStripPanel> and across <xref:System.Windows.Forms.ToolStripPanel>s. The `Dock` property is ignored, and if the <xref:System.Windows.Forms.ToolStrip.Stretch%2A> property is `false`, the size of the <xref:System.Windows.Forms.ToolStrip> grows as items are added to the <xref:System.Windows.Forms.ToolStripPanel>. Typically, the <xref:System.Windows.Forms.ToolStrip> does not participate in the tab order.  
  
-   Docked  
  
     The <xref:System.Windows.Forms.ToolStrip> is placed on one side of a container in a fixed position, and its size expands over the entire edge to which it is docked. Typically, the <xref:System.Windows.Forms.ToolStrip> does not participate in the tab order.  
  
-   Absolutely positioned  
  
     The <xref:System.Windows.Forms.ToolStrip> is like other controls, in that it is placed by the <xref:System.Windows.Forms.Control.Location%2A> property, has a fixed size, and typically participates in the tab order.  
  
#### Keyboard Interaction  
  
##### Access Keys  
 Combined with or following the ALT key, access keys are one way to activate a control using the keyboard. <xref:System.Windows.Forms.ToolStrip> supports both explicit and implicit access keys. Explicit definition uses an ampersand (&) character preceding the letter. Implicit definition uses an algorithm that attempts to find a matching item based on the order of characters in a given `Text` property.  
  
##### Shortcut Keys  
 The shortcut keys used by a <xref:System.Windows.Forms.MenuStrip> use a combination of the <xref:System.Windows.Forms.Keys> enumeration (which is not order-specific) to define the shortcut key. You can also use the <xref:System.Windows.Forms.ToolStripMenuItem.ShortcutKeyDisplayString%2A> property to display a shortcut key with text only, such as displaying "Del" instead of "Delete."  
  
##### Navigation  
 The ALT key activates the <xref:System.Windows.Forms.MenuStrip> pointed to by <xref:System.Windows.Forms.Form.MainMenuStrip%2A>. From there, CTRL+TAB navigates between <xref:System.Windows.Forms.ToolStrip> controls within `ToolStripPanel`s. The TAB key and the arrow keys on the numeric keypad navigate between items in a <xref:System.Windows.Forms.ToolStrip>. A special algorithm handles navigation in the overflow region. SPACEBAR selects a <xref:System.Windows.Forms.ToolStripButton>, <xref:System.Windows.Forms.ToolStripDropDownButton>, or <xref:System.Windows.Forms.ToolStripSplitButton>.  
  
##### Focus and Validation  
 When activated by the ALT key, the <xref:System.Windows.Forms.MenuStrip> or <xref:System.Windows.Forms.ToolStrip> typically neither take nor remove the focus from the control that currently has the focus. If there is a control hosted within the <xref:System.Windows.Forms.MenuStrip> or a drop-down of the <xref:System.Windows.Forms.MenuStrip>, the control gains focus when the user presses the TAB key. In general, the <xref:System.Windows.Forms.Control.GotFocus>, <xref:System.Windows.Forms.Control.LostFocus>, <xref:System.Windows.Forms.Control.Enter>, and <xref:System.Windows.Forms.Control.Leave> events of <xref:System.Windows.Forms.MenuStrip> might not be raised when they are activated by the keyboard. In such cases, use the <xref:System.Windows.Forms.MenuStrip.MenuActivate> and <xref:System.Windows.Forms.MenuStrip.MenuDeactivate> events instead.  
  
 By default, <xref:System.Windows.Forms.ToolStrip.CausesValidation%2A> is `false`. Call <xref:System.Windows.Forms.ContainerControl.Validate%2A> explicitly on your form to perform validation.  
  
#### Layout  
 You control <xref:System.Windows.Forms.ToolStrip> layout by choosing one of the members of <xref:System.Windows.Forms.ToolStripLayoutStyle> with the <xref:System.Windows.Forms.ToolStrip.LayoutStyle%2A> property.  
  
##### Stack Layouts  
 Stacking is the arranging of items beside each other at both ends of the <xref:System.Windows.Forms.ToolStrip>. The following list describes the stack layouts.  
  
-   <xref:System.Windows.Forms.ToolStripLayoutStyle.StackWithOverflow> is the default. This setting causes the <xref:System.Windows.Forms.ToolStrip> to alter its layout automatically in accordance with the <xref:System.Windows.Forms.ToolStrip.Orientation%2A> property to handle dragging and docking scenarios.  
  
-   <xref:System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow> renders the <xref:System.Windows.Forms.ToolStrip> items beside each other vertically.  
  
-   <xref:System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow> renders the <xref:System.Windows.Forms.ToolStrip> items beside each other horizontally.  
  
##### Other Features of Stack Layouts  
 <xref:System.Windows.Forms.ToolStripItem.Alignment%2A> determines the end of the <xref:System.Windows.Forms.ToolStrip> to which the item is aligned.  
  
 When items do not fit within the <xref:System.Windows.Forms.ToolStrip>, an overflow button automatically appears. The <xref:System.Windows.Forms.ToolStripItem.Overflow%2A> property setting determines whether an item appears in the overflow area always, as needed, or never.  
  
 In the <xref:System.Windows.Forms.ToolStrip.LayoutCompleted> event, you can inspect the <xref:System.Windows.Forms.ToolStripItem.Placement%2A> property to determine whether an item was placed on the main <xref:System.Windows.Forms.ToolStrip>, the overflow <xref:System.Windows.Forms.ToolStrip>, or if it is not currently showing at all. The typical reasons why an item is not displayed are that the item did not fit on the main <xref:System.Windows.Forms.ToolStrip> and its <xref:System.Windows.Forms.ToolStripItem.Overflow%2A> property was set to <xref:System.Windows.Forms.ToolStripItemOverflow.Never>.  
  
 Make a <xref:System.Windows.Forms.ToolStrip> movable by putting it in a <xref:System.Windows.Forms.ToolStripPanel> and setting its <xref:System.Windows.Forms.ToolStrip.GripStyle%2A> to <xref:System.Windows.Forms.ToolStripGripStyle.Visible>.  
  
##### Other Layout Options  
 The other layout options are <xref:System.Windows.Forms.ToolStripLayoutStyle.Flow> and <xref:System.Windows.Forms.ToolStripLayoutStyle.Table>.  
  
##### Flow Layout  
 <xref:System.Windows.Forms.ToolStripLayoutStyle.Flow> layout is the default for <xref:System.Windows.Forms.ContextMenuStrip>, <xref:System.Windows.Forms.ToolStripDropDownMenu>, and <xref:System.Windows.Forms.ToolStripOverflow>. It is similar to the <xref:System.Windows.Forms.FlowLayoutPanel>. The features of <xref:System.Windows.Forms.ToolStripLayoutStyle.Flow> layout are as follows:  
  
-   All of the features of <xref:System.Windows.Forms.FlowLayoutPanel> are exposed by the <xref:System.Windows.Forms.ToolStrip.LayoutSettings%2A> property. You must cast the <xref:System.Windows.Forms.LayoutSettings> class to a <xref:System.Windows.Forms.FlowLayoutSettings> class.  
  
-   You can use the <xref:System.Windows.Forms.ToolStripItem.Dock%2A> and <xref:System.Windows.Forms.ToolStripItem.Anchor%2A> properties in code to align the items within the row.  
  
-   The <xref:System.Windows.Forms.ToolStripItem.Alignment%2A> property is ignored.  
  
-   In the <xref:System.Windows.Forms.ToolStrip.LayoutCompleted> event, you can inspect the <xref:System.Windows.Forms.ToolStripItem.Placement%2A> property to determine whether an item was placed on the main <xref:System.Windows.Forms.ToolStrip> or did not fit.  
  
-   The grip is not rendered, and therefore a <xref:System.Windows.Forms.ToolStrip> in <xref:System.Windows.Forms.ToolStripLayoutStyle.Flow> layout style in a <xref:System.Windows.Forms.ToolStripPanel> cannot be moved.  
  
-   The <xref:System.Windows.Forms.ToolStrip> overflow button is not rendered, and <xref:System.Windows.Forms.ToolStripItem.Overflow%2A> is ignored.  
  
##### Table Layout  
 <xref:System.Windows.Forms.ToolStripLayoutStyle.Table> layout is the default for <xref:System.Windows.Forms.StatusStrip>. It is similar to <xref:System.Windows.Forms.TableLayoutPanel>. The features of <xref:System.Windows.Forms.ToolStripLayoutStyle.Flow> layout are as follows:  
  
-   All of the features of <xref:System.Windows.Forms.TableLayoutPanel> are exposed by the <xref:System.Windows.Forms.ToolStrip.LayoutSettings%2A> property. You must cast the <xref:System.Windows.Forms.LayoutSettings> class to a <xref:System.Windows.Forms.TableLayoutSettings> class.  
  
-   You can use the <xref:System.Windows.Forms.ToolStripItem.Dock%2A> and <xref:System.Windows.Forms.ToolStripItem.Anchor%2A> properties in code to align the items within the table cell.  
  
-   The <xref:System.Windows.Forms.ToolStripItem.Alignment%2A> property is ignored.  
  
-   In the <xref:System.Windows.Forms.ToolStrip.LayoutCompleted> event, you can inspect the <xref:System.Windows.Forms.ToolStripItem.Placement%2A> property to determine whether an item was placed on the main <xref:System.Windows.Forms.ToolStrip> or did not fit.  
  
-   The grip is not rendered, and therefore a <xref:System.Windows.Forms.ToolStrip> in <xref:System.Windows.Forms.ToolStripLayoutStyle.Table> layout style in a <xref:System.Windows.Forms.ToolStripPanel> cannot be moved.  
  
-   The <xref:System.Windows.Forms.ToolStrip> overflow button is not rendered, and <xref:System.Windows.Forms.ToolStripItem.Overflow%2A> is ignored.  
  
## ToolStripItem  
 The following topics describe <xref:System.Windows.Forms.ToolStripItem> and the controls that derive from it.  
  
 <xref:System.Windows.Forms.ToolStripItem> is the abstract base class for all the items that go into a <xref:System.Windows.Forms.ToolStrip>. The following object model shows the <xref:System.Windows.Forms.ToolStripItem> inheritance hierarchy.  
  
 ![ToolStripItem Object Model](../../../../docs/framework/winforms/controls/media/toolstripitemobjectmodel.gif "ToolStripItemObjectModel")  
ToolStripItem object model  
  
 <xref:System.Windows.Forms.ToolStripItem> classes either inherit directly from <xref:System.Windows.Forms.ToolStripItem>, or they inherit indirectly from <xref:System.Windows.Forms.ToolStripItem> through <xref:System.Windows.Forms.ToolStripControlHost> or <xref:System.Windows.Forms.ToolStripDropDownItem>.  
  
 <xref:System.Windows.Forms.ToolStripItem> controls must be contained in a <xref:System.Windows.Forms.ToolStrip>, <xref:System.Windows.Forms.MenuStrip>, <xref:System.Windows.Forms.StatusStrip>, or <xref:System.Windows.Forms.ContextMenuStrip> and cannot be added directly to a form. The various container classes are designed to contain an appropriate subset of <xref:System.Windows.Forms.ToolStripItem> controls.  
  
 The following table lists the stock <xref:System.Windows.Forms.ToolStripItem> controls and the containers in which they look best. Although any <xref:System.Windows.Forms.ToolStrip> item can be hosted in any <xref:System.Windows.Forms.ToolStrip>-derived container, these items were designed to look best in the following containers:  
  
> [!NOTE]
>  <xref:System.Windows.Forms.ToolStripDropDown> does not appear in the designer toolbox.  
  
|Contained item|ToolStrip|MenuStrip|ContextMenuStrip|StatusStrip|ToolStripDropDown|  
|--------------------|---------------|---------------|----------------------|-----------------|-----------------------|  
|<xref:System.Windows.Forms.ToolStripButton>|Yes|No|No|No|Yes|  
|<xref:System.Windows.Forms.ToolStripComboBox>|Yes|Yes|Yes|No|Yes|  
|<xref:System.Windows.Forms.ToolStripSplitButton>|Yes|No|No|Yes|Yes|  
|<xref:System.Windows.Forms.ToolStripLabel>|Yes|No|No|Yes|Yes|  
|<xref:System.Windows.Forms.ToolStripSeparator>|Yes|Yes|Yes|No|Yes|  
|<xref:System.Windows.Forms.ToolStripDropDownButton>|Yes|No|No|Yes|Yes|  
|<xref:System.Windows.Forms.ToolStripTextBox>|Yes|Yes|Yes|No|Yes|  
|<xref:System.Windows.Forms.ToolStripMenuItem>|No|Yes|Yes|No|No|  
|<xref:System.Windows.Forms.ToolStripStatusLabel>|No|No|No|Yes|No|  
|<xref:System.Windows.Forms.ToolStripProgressBar>|Yes|No|No|Yes|No|  
|<xref:System.Windows.Forms.ToolStripControlHost>|Yes|Yes|No|Yes|Yes|  
  
### ToolStripButton  
 <xref:System.Windows.Forms.ToolStripButton> is the button item for <xref:System.Windows.Forms.ToolStrip>. You can display it with various border styles, and you can use it to represent and activate operational states. You can also define it to have the focus by default.  
  
### ToolStripLabel  
 The <xref:System.Windows.Forms.ToolStripLabel> provides label functionality in <xref:System.Windows.Forms.ToolStrip> controls. The <xref:System.Windows.Forms.ToolStripLabel> is like a <xref:System.Windows.Forms.ToolStripButton> that does not get focus by default and that does not render as pushed or highlighted.  
  
 <xref:System.Windows.Forms.ToolStripLabel> as a hosted item supports access keys.  
  
 Use the <xref:System.Windows.Forms.LinkLabel.LinkColor%2A>, <xref:System.Windows.Forms.LinkLabel.LinkVisited%2A>, and <xref:System.Windows.Forms.LinkLabel.LinkBehavior%2A> properties on a <xref:System.Windows.Forms.ToolStripLabel> to support link control in a <xref:System.Windows.Forms.ToolStrip>.  
  
### ToolStripStatusLabel  
 <xref:System.Windows.Forms.ToolStripStatusLabel> is a version of <xref:System.Windows.Forms.ToolStripLabel> designed specifically for use in <xref:System.Windows.Forms.StatusStrip>. The special features include <xref:System.Windows.Forms.ToolStripStatusLabel.BorderStyle%2A>, <xref:System.Windows.Forms.ToolStripStatusLabel.BorderSides%2A>, and <xref:System.Windows.Forms.ToolStripStatusLabel.Spring%2A>.  
  
### ToolStripSeparator  
 The <xref:System.Windows.Forms.ToolStripSeparator> adds a vertical or horizontal line to a toolbar or menu, depending on the orientation. It provides grouping of or distinction between items, such as those on a menu.  
  
 You can add a <xref:System.Windows.Forms.ToolStripSeparator> at design time by choosing it from a drop-down list. However, you can also automatically create a <xref:System.Windows.Forms.ToolStripSeparator> by typing a hyphen (-) in either the designer template node or in the <xref:System.Windows.Forms.ToolStripItemCollection.Add%2A> method.  
  
### ToolStripControlHost  
 <xref:System.Windows.Forms.ToolStripControlHost> is the abstract base class for <xref:System.Windows.Forms.ToolStripComboBox>, <xref:System.Windows.Forms.ToolStripTextBox>, and <xref:System.Windows.Forms.ToolStripProgressBar>. <xref:System.Windows.Forms.ToolStripControlHost> can host other controls, including custom controls, in two ways:  
  
-   Construct a <xref:System.Windows.Forms.ToolStripControlHost> with a class that derives from <xref:System.Windows.Forms.Control>. To fully access the hosted control and properties, you must cast the <xref:System.Windows.Forms.ToolStripControlHost.Control%2A> property back to the actual class it represents.  
  
-   Extend <xref:System.Windows.Forms.ToolStripControlHost>, and in the inherited class's default constructor, call the base class constructor passing a class that derives from <xref:System.Windows.Forms.Control>. This option lets you wrap common control methods and properties for easy access in a <xref:System.Windows.Forms.ToolStrip>.  
  
### ToolStripComboBox  
 <xref:System.Windows.Forms.ToolStripComboBox> is the <xref:System.Windows.Forms.ComboBox> optimized for hosting in a <xref:System.Windows.Forms.ToolStrip>. A subset of the hosted control's properties and events are exposed at the <xref:System.Windows.Forms.ToolStripComboBox> level, but the underlying <xref:System.Windows.Forms.ComboBox> control is fully accessible through the <xref:System.Windows.Forms.ToolStripComboBox.ComboBox%2A> property.  
  
### ToolStripTextBox  
 <xref:System.Windows.Forms.ToolStripTextBox> is the <xref:System.Windows.Forms.TextBox> optimized for hosting in a <xref:System.Windows.Forms.ToolStrip>. A subset of the hosted control's properties and events are exposed at the <xref:System.Windows.Forms.ToolStripTextBox> level, but the underlying <xref:System.Windows.Forms.TextBox> control is fully accessible through the <xref:System.Windows.Forms.ToolStripTextBox.TextBox%2A> property.  
  
### ToolStripProgressBar  
 <xref:System.Windows.Forms.ToolStripProgressBar> is the <xref:System.Windows.Forms.ProgressBar> optimized for hosting in a <xref:System.Windows.Forms.ToolStrip>. A subset of the hosted control's properties and events are exposed at the <xref:System.Windows.Forms.ToolStripProgressBar> level, but the underlying <xref:System.Windows.Forms.ProgressBar> control is fully accessible through the <xref:System.Windows.Forms.ToolStripProgressBar.ProgressBar%2A> property.  
  
### ToolStripDropDownItem  
 <xref:System.Windows.Forms.ToolStripDropDownItem> is the abstract base class for <xref:System.Windows.Forms.ToolStripMenuItem>, <xref:System.Windows.Forms.ToolStripDropDownButton>, and <xref:System.Windows.Forms.ToolStripSplitButton>, which can host items directly or host additional items in a drop-down container. You do this by setting the <xref:System.Windows.Forms.ToolStripDropDownItem.DropDown%2A> property to a <xref:System.Windows.Forms.ToolStripDropDown> and setting the <xref:System.Windows.Forms.ToolStrip.Items%2A> property of the <xref:System.Windows.Forms.ToolStripDropDown>. Access these drop-down items directly through the <xref:System.Windows.Forms.ToolStripDropDownItem.DropDownItems%2A> property.  
  
### ToolStripMenuItem  
 <xref:System.Windows.Forms.ToolStripMenuItem> is a <xref:System.Windows.Forms.ToolStripDropDownItem> that works with <xref:System.Windows.Forms.ToolStripDropDownMenu> and <xref:System.Windows.Forms.ContextMenuStrip> to handle the special highlighting, layout, and column arrangement for menus.  
  
### ToolStripDropDownButton  
 <xref:System.Windows.Forms.ToolStripDropDownButton> looks like <xref:System.Windows.Forms.ToolStripButton>, but it shows a drop-down area when the user clicks it. Hide or show the drop-down arrow by setting the <xref:System.Windows.Forms.ToolStripDropDownButton.ShowDropDownArrow%2A> property. <xref:System.Windows.Forms.ToolStripDropDownButton> hosts a <xref:System.Windows.Forms.ToolStripOverflowButton> that displays items that overflow the <xref:System.Windows.Forms.ToolStrip>.  
  
### ToolStripSplitButton  
 <xref:System.Windows.Forms.ToolStripSplitButton> combines button and drop-down button functionality.  
  
 Use the <xref:System.Windows.Forms.ToolStripSplitButton.DefaultItem%2A> property to synchronize the <xref:System.Windows.Forms.Control.Click> event of the chosen drop-down item with the item shown on the button.  
  
### ToolStripItem Generic Features  
 <xref:System.Windows.Forms.ToolStripItem> provides the following generic features and options to inheriting controls:  
  
-   Core events  
  
-   Image handling  
  
-   Alignment  
  
-   Text and image relationship  
  
-   Display style  
  
#### Core Events  
 <xref:System.Windows.Forms.ToolStripItem> controls receive their own click, mouse, and paint events, and can perform some keyboard preprocessing also.  
  
#### Image Handling  
 The <xref:System.Windows.Forms.ToolStripItem.Image%2A>, <xref:System.Windows.Forms.ToolStripItem.ImageAlign%2A>, <xref:System.Windows.Forms.ToolStripItem.ImageIndex%2A>, <xref:System.Windows.Forms.ToolStripItem.ImageKey%2A>, and <xref:System.Windows.Forms.ToolStripItem.ImageScaling%2A> properties pertain to various aspects of image handling. Use images in <xref:System.Windows.Forms.ToolStrip> controls by setting these properties directly or by setting the run-time–only <xref:System.Windows.Forms.ToolStrip.ImageList%2A> property.  
  
 Image scaling is determined by the interaction of properties in both <xref:System.Windows.Forms.ToolStrip> and <xref:System.Windows.Forms.ToolStripItem>, as follows:  
  
-   <xref:System.Windows.Forms.ToolStrip.ImageScalingSize%2A> is the scale of the final image as determined by the combination of the image's <xref:System.Windows.Forms.ToolStripItem.ImageScaling%2A> setting and the container's <xref:System.Windows.Forms.ToolStrip.AutoSize%2A> setting.  
  
    -   If <xref:System.Windows.Forms.ToolStrip.AutoSize%2A> is `true` (the default) and <xref:System.Windows.Forms.ToolStripItemImageScaling> is <xref:System.Windows.Forms.ToolStripItemImageScaling.SizeToFit>, no image scaling occurs, and the <xref:System.Windows.Forms.ToolStrip> size is that of the largest item, or a prescribed minimum size.  
  
    -   If <xref:System.Windows.Forms.ToolStrip.AutoSize%2A> is `false` and <xref:System.Windows.Forms.ToolStripItemImageScaling> is <xref:System.Windows.Forms.ToolStripItemImageScaling.None>, neither image nor <xref:System.Windows.Forms.ToolStrip> scaling occurs.  
  
#### Alignment  
 The value of the <xref:System.Windows.Forms.ToolStripItem.Alignment%2A> property determines the end of the <xref:System.Windows.Forms.ToolStrip> at which an item appears. The <xref:System.Windows.Forms.ToolStripItem.Alignment%2A> property works only when the layout style of the <xref:System.Windows.Forms.ToolStrip> is set to one of the stack overflow values.  
  
 Items are placed on the <xref:System.Windows.Forms.ToolStrip> in the order in which the items appear in the Items collection. To programmatically change where an item is laid out, use the <xref:System.Windows.Forms.ToolStripItemCollection.Insert%2A> method to move the item in the collection. This method moves the item but does not duplicate it.  
  
#### Text and Image Relationship  
 The <xref:System.Windows.Forms.ToolStripItem.TextImageRelation%2A> property defines the relative placement of the image with respect to the text on a <xref:System.Windows.Forms.ToolStripItem>. Items that lack an image, text, or both are treated as special cases so that the <xref:System.Windows.Forms.ToolStripItem> does not display a blank spot for the missing element or elements.  
  
#### Display Style  
 <xref:System.Windows.Forms.ToolStripItem.DisplayStyle%2A> allows you to set the values of an item's Text and Image properties while displaying only what you want. This is typically used to change only the display style when showing the same item in a different context.  
  
## Accessory Classes  
 Classes that provide various other functionality include:  
  
-   <xref:System.Windows.Forms.ToolStripManager> supports <xref:System.Windows.Forms.ToolStrip>-related tasks for entire applications, such as merging, settings, and renderer options.  
  
-   <xref:System.Windows.Forms.ToolStripRenderer> allows you to apply a particular style or theme to a <xref:System.Windows.Forms.ToolStrip> easily.  
  
-   <xref:System.Windows.Forms.ToolStripProfessionalRenderer> creates pens and brushes based on a replaceable color table (<xref:System.Windows.Forms.ProfessionalColorTable>).  
  
-   <xref:System.Windows.Forms.ToolStripSystemRenderer> applies system colors and a flat visual style to <xref:System.Windows.Forms.ToolStrip> applications.  
  
-   <xref:System.Windows.Forms.ToolStripContainer> is similar to <xref:System.Windows.Forms.SplitContainer>. It uses four docked side panels (instances of <xref:System.Windows.Forms.ToolStripPanel>) and one central panel (an instance of <xref:System.Windows.Forms.ToolStripContentPanel>) to create a typical arrangement. You cannot remove the side panels, but you can hide them. You can neither remove nor hide the central panel. You can arrange one or more <xref:System.Windows.Forms.ToolStrip>, <xref:System.Windows.Forms.MenuStrip>, or <xref:System.Windows.Forms.StatusStrip> controls in the side panels, and you can use the central panel for other controls. The <xref:System.Windows.Forms.ToolStripContentPanel> also provides a way to get renderer support into the body of your form for a consistent appearance. <xref:System.Windows.Forms.ToolStripContainer> does not support multiple document interface (MDI).  
  
-   <xref:System.Windows.Forms.ToolStripPanel> provides space for moving and arranging <xref:System.Windows.Forms.ToolStrip> controls. You can use only one panel if you so choose, and <xref:System.Windows.Forms.ToolStripPanel> works well in MDI scenarios.  
  
## See Also  
 [ToolStrip Control Overview](../../../../docs/framework/winforms/controls/toolstrip-control-overview-windows-forms.md)  
 [ToolStrip Technology Summary](../../../../docs/framework/winforms/controls/toolstrip-technology-summary.md)  
 [ToolStrip Control](../../../../docs/framework/winforms/controls/toolstrip-control-windows-forms.md)  
 [MenuStrip Control](../../../../docs/framework/winforms/controls/menustrip-control-windows-forms.md)  
 [StatusStrip Control](../../../../docs/framework/winforms/controls/statusstrip-control.md)  
 [ContextMenuStrip Control](../../../../docs/framework/winforms/controls/contextmenustrip-control.md)  
 [BindingNavigator Control](../../../../docs/framework/winforms/controls/bindingnavigator-control-windows-forms.md)
