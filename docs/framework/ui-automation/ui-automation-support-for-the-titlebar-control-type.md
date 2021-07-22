---
title: "UI Automation Support for the TitleBar Control Type"
description: Get information about UI Automation support for the TitleBar control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Title Bar"
  - "Title Bar control type"
  - "UI Automation, Title Bar control type"
ms.assetid: 3b7a4e13-0305-45d5-bc33-1f4133c50782
---
# UI Automation Support for the TitleBar Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the TitleBar control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns.

 Title bar controls represent titles or caption bars in a window.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the TitleBar control type. The UI Automation requirements apply to all title bar controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to title bar controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|TitleBar<br /><br /> -   Menu (0 or 1)<br />-   Button (0 or more)|Not applicable. (the title bar control has no content.)|

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to TitleBar controls. For more information about UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The bounding rectangle of a title bar must encompass all of the controls contained within it.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|False|Title bars never have keyboard focus.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|""|The title bar is not content; its textual information is exposed on the parent window.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|The title bar control usually does not have a label.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|TitleBar|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"title bar"|Localized string corresponding to the TitleBar control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|False|The title bar control is never content.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The title bar control must always be a control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty>|Depends|This control will return a value depending on whether the title bar is visible on the screen.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.HelpTextProperty>|""|It is not necessary to expose Help text.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AcceleratorKeyProperty>|""|Title bars never have accelerator keys.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AccessKeyProperty>|""|The title bar control does not have an access key.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The TitleBar control type is not required to support any control patterns. Its functionality is exposed through the Window control pattern on the Window control.

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all title bar controls. For more information about events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Never|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.TitleBar>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
