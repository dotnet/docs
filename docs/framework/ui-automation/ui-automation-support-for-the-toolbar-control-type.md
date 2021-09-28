---
title: "UI Automation Support for the ToolBar Control Type"
description: Get information about UI Automation support for the ToolBar control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Toolbar"
  - "UI Automation, Toolbar control type"
  - "ToolBar control type"
ms.assetid: 85152efd-f4c5-430c-8878-3371cc598616
---
# UI Automation Support for the ToolBar Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the ToolBar control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns. Tool bar controls enable end users to activate commands and tools contained within a application.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the ToolBar control type. The UI Automation requirements apply to all tool bar controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to tool bar controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|ToolBar<br /><br /> -   Various controls (0 or more)|ToolBar<br /><br /> -   Various controls (0 or more)|

 A tool bar control can contain any type of control within its subtree. They most often contain buttons, combo boxes, and split buttons.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to tool bar controls. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|Depends|The tool bar control does not need a name unless more than one is used within an application. If more than one is present, each must have a distinguishing name (for example, Formatting or Outlining).|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|`Null`|Tool bar controls never have a label.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|ToolBar|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"tool bar"|Localized string corresponding to the ToolBar control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The tool bar control is always content.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The tool bar control must always be a control.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by tool bar controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.ExpandCollapsePattern>|Depends|If the tool bar can be expanded and collapsed to show more items, then it must support this pattern.|
|<xref:System.Windows.Automation.DockPattern>|Depends|If the tool bar can be docked to different parts of the screen, then it must support this pattern.|
|<xref:System.Windows.Automation.TransformPattern>|Depends|If the tool bar can be resized, rotated, or moved, it must support this pattern.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all tool bar controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.ToolBar>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
