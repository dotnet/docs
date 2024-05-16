---
title: "UI Automation Support for the Menu Control Type"
description: Get information about UI Automation support for the Menu control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Menu"
  - "UI Automation, Menu control type"
  - "Menu control type"
ms.assetid: 016323cb-f800-4938-b77b-2eb25d646090
---
# UI Automation Support for the Menu Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about Microsoft UI Automation support for the Menu control type. It describes the control's Microsoft UI Automation tree structure and provides the properties and control patterns for specific control scenarios.

 A menu control allows hierarchal organization of elements associated with commands and event handlers. In a typical Microsoft Windows application, a menu bar contains several menu buttons (such as **File**, **Edit**, and **Window**), and each menu button displays a menu. A menu contains a collection of menu items (such as **New**, **Open**, and **Close**), which can be expanded to display additional menu items or to perform a specific action when clicked.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Menu control type. The UI Automation requirements apply to all list controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to menu controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Menu<br /><br /> -   MenuItem (1 or many)|Not applicable (unless the menu control is a context menu that is a parent of an object that is not a menu item)<br /><br /> -   MenuItem (1 or many)|

 Menu controls always appear in the control view and the content view of the UI Automation tree. Menu control types should appear under the control that their information is referring to. UI Automation clients must listen for `MenuOpenedEvent` to ensure that they consistently obtain information conveyed by menu controls. Context menu controls are a special case. They appear as children of the Desktop.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to the Menu control type. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|Not Supported|The menu control does not require a Name property to be set.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|`Null`|No label is anticipated with a typical menu control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Menu|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|False|The menu control is not included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The menu control is always included in the control view of the UI Automation tree.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 There are no required control patterns for the Menu control type.

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 Menu controls must raise `MenuOpenedEvent` when they appear on the screen. The `MenuOpenedEvent` will include the text of the control. The `MenuClosedEvent` must be raised when a menu disappears from the screen.

 The following table lists the UI Automation events required to be supported by all menu controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support/Value|Notes|
|---------------------------------------------------------------------------------|--------------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.MenuOpenedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.MenuClosedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Menu>
- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
