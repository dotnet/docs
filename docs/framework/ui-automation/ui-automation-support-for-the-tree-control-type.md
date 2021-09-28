---
title: "UI Automation Support for the Tree Control Type"
description: Get information about UI Automation support for the Tree control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Tree"
  - "Tree control type"
  - "UI Automation, Tree control type"
ms.assetid: 312dd04d-a86b-4072-8b12-2beeabdff5e3
---
# UI Automation Support for the Tree Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Tree control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values, and control patterns.

 The Tree control type is used for containers whose contents have relevance as a hierarchy of nodes, as with the way files and folders are displayed in the left pane of Microsoft Windows Explorer. Each node has the potential to contain other nodes, called child nodes. Parent nodes, or nodes that contain child nodes, can be displayed as expanded or collapsed.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Tree control type. The UI Automation requirements apply to all tree controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to tree controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Tree<br /><br /> <ul><li>DataItem (0 or more)</li><li>TreeItem (0 or more)<br /><br /> <ul><li>TreeItem (0 or more)•    …</li></ul></li><li>ScrollBar (0, 1, 2)</li></ul>|Tree<br /><br /> <ul><li>DataItem (0 or more)</li><li>TreeItem (0 or more)<br /><br /> <ul><li>TreeItem (0 or more)•    …</li></ul></li></ul>|

 The control view of the UI Automation tree consists of:

- Zero to many items within the container (items can be based on the Tree Item, Data Item, or other control type).

- Zero, one or two scroll bars.

 The content view of the UI Automation tree consists of zero or many items within the container (items can be based on the Tree Item, Data Item, or other control type).

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to list controls. For more information about UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Tree controls have a clickable point that will cause the tree or one the items in the tree container to have the focus set on them. You get a clickable point for a tree only if you can click somewhere that doesn't cause one of the items to be selected/get focus.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Tree|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The tree control is always included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The tree control is always included in the control view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|If the tree control has a label associated with it, this property will return an <xref:System.Windows.Automation.AutomationElement> for that label. Otherwise, the property will return a null reference (`Nothing` in Microsoft Visual Basic .NET).|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"tree"|Localized string corresponding to the List control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The value of a tree control's name property usually comes from text that labels the control. If there is no text label, then the application developer must provide a value for this property.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by list controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern/Pattern Property|Support/Value|Notes|
|---------------------------------------|--------------------|-----------|
|<xref:System.Windows.Automation.Provider.ISelectionProvider>|Depends|Tree controls that contain a set of selectable items must implement this control pattern. This control pattern does not have to be implemented if selecting an item does not convey meaningful information to the user.|
|<xref:System.Windows.Automation.Provider.ISelectionProvider.CanSelectMultiple%2A>|See notes.|Implement this property if the tree control supports multiple selection (most tree controls do not support multiple selection).|
|<xref:System.Windows.Automation.Provider.ISelectionProvider.IsSelectionRequired%2A>|See notes.|The value of this property is exposed if the control requires that an item be selected.|
|<xref:System.Windows.Automation.Provider.IScrollProvider>|Depends|Implement this control pattern if the contents of the tree container can be scrolled.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all tree controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent>|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontallyScrollableProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalScrollPercentProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalViewSizeProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalScrollPercentProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticallyScrollableProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalViewSizeProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Tree>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
