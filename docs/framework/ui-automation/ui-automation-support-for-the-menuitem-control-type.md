---
title: "UI Automation Support for the MenuItem Control Type"
description: Get information about UI Automation support for the MenuItem control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Menu Item"
  - "Menu Item control type"
  - "UI Automation, Menu Item control type"
ms.assetid: 54bce311-3d23-40b9-ba90-1bdbdaf8fbba
---

# UI Automation Support for the MenuItem Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

This topic provides information about Microsoft UI Automation support for the MenuItem control type. It describes the control's Microsoft UI Automation tree structure and provides the properties and control patterns that are required for the MenuItem control type.

A menu control allows hierarchal organization of elements associated with commands and event handlers. In a typical Microsoft Windows application, a menu bar contains several menu items (such as **File**, **Edit**, and **Window**), and each menu item displays a menu. A menu contains a collection of menu items (such as **New**, **Open**, and **Close**), which can be expanded to display additional menu items or perform a specific action when clicked. A menu item can be hosted in a menu, menu bar, or tool bar.

The following sections define the required UI Automation tree structure, properties, control patterns, and events for the MenuItem control type. The UI Automation requirements apply to all list controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

The following table depicts the control view and the content view of the UI Automation tree that pertains to menu item controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|MenuItem "Help"<br /><br /> <ul><li>Menu (sub menu of Help menu item)<br /><br /> <ul><li>MenuItem "Help Topics"</li><li>MenuItem "About Notepad"</li></ul></li></ul>|MenuItem "Help"<br /><br /> -   MenuItem "Help Topics"<br />-   MenuItem "About Notepad"|

The control view of the menu item control has the UI Automation tree structure shown above. Note that the **Help** menu item is included to better illustrate the structure in a typical menu to submenu hierarchy.

For the content view, Menu is absent from the UI Automation tree because it does not convey meaningful information to the end user.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

The following table lists the UI Automation properties whose value or definition is especially relevant to menu item controls. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|Property|Value|Description|
|--------------|-----------|-----------------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The menu item control is included in the content view of the UI Automation tree and is self labeled with a name.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|`Null`|No label.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|MenuItem|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"menu item"|Localized string corresponding to the MenuItem control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The menu item control is never included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The menu item control must always be included in the control view of the UI Automation tree.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

The following table lists the UI Automation control patterns required to be supported by menu item controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern Property|Support|Notes|
|------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IExpandCollapseProvider>|Depends|If the control can be expanded or collapsed, implement <xref:System.Windows.Automation.Provider.IExpandCollapseProvider>.|
|<xref:System.Windows.Automation.Provider.IInvokeProvider>|Depends|If the control executes a single action or command, implement <xref:System.Windows.Automation.Provider.IInvokeProvider>.|
|<xref:System.Windows.Automation.Provider.IToggleProvider>|Depends|If the control represents an option that can be turned on or off, implement <xref:System.Windows.Automation.Provider.IToggleProvider>.|
|<xref:System.Windows.Automation.Provider.ISelectionItemProvider>|Depends|If the control is used to select from a list of options among menu items, implement <xref:System.Windows.Automation.Provider.ISelectionItemProvider>.|

<a name="UI_Automation_Events_for_Menu_Item"></a>

## UI Automation Events for Menu Item

The following table lists the Microsoft UI Automation events associated with the menu item control.

|Event|Support|Explanation|
|-----------|-------------|-----------------|
|<xref:System.Windows.Automation.InvokePatternIdentifiers.InvokedEvent>|Depends|Must be raised if control supports Invoke control pattern.|
|<xref:System.Windows.Automation.TogglePatternIdentifiers.ToggleStateProperty> property-changed event.|Depends|Must be raised if control supports Toggle control pattern.|
|<xref:System.Windows.Automation.ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty> property-changed event.|Depends|Must be raised if control supports Expand Collapse control pattern.|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementSelectedEvent>|Depends|None.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

The following table lists the UI Automation events required to be supported by all menu item controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support/Value|Notes|
|---------------------------------------------------------------------------------|--------------------|-----------|
|<xref:System.Windows.Automation.InvokePatternIdentifiers.InvokedEvent>|Depends|None|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent>|Depends|None|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent>|Depends|None|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementSelectedEvent>|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.TogglePatternIdentifiers.ToggleStateProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

<a name="Legacy_Issues"></a>

## Legacy Issues

Toggle Pattern will only be supported when the Win32 menu item is checked and can be programmatically determined necessary to support Toggle Pattern. Because the Win32 menu item does not expose whether it has the ability to be checked, Invoke Pattern will be supported when the menu item is not checked. An exception will be made to always support Invoke Pattern even for menu items that should only support Toggle Pattern. This is so clients do not become confused that an element that was supporting Invoke Pattern (when menu item was unchecked) no longer supports the pattern once it becomes checked.

## See also

- <xref:System.Windows.Automation.ControlType.MenuItem>
- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
