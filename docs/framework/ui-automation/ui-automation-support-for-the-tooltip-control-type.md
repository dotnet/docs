---
title: "UI Automation Support for the ToolTip Control Type"
description: Get information about UI Automation support for the ToolTip control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, ToolTip control type"
  - "ToolTip control type"
  - "control types, ToolTip"
ms.assetid: c3779d78-3164-43ae-8dae-bfaeafffdd65
---
# UI Automation Support for the ToolTip Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the ToolTip control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns.

 Tool tip controls are pop-up windows that contain text.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the ToolTip control type. The UI Automation requirements apply to all tool tip controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to tool tip controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|ToolTip<br /><br /> -   Text (0 or more)<br />-   Image (0 or more)|ToolTip|

 Tool tip controls appear only in the Content View of the UI Automation tree if they can receive keyboard focus. Otherwise, all of the tool tip's information is available from the `HelpTextProperty` on the UI Automation element that the tool tip is referring to.

 Tool tips should appear beneath the control that their information is referring to. Clients must listen for the `ToolTipOpenedEvent` to ensure that they consistently obtain information contained in tool tips.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to tool tip controls. For more information about UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|The clickable point should be the part of the tool tip that will dismiss the control. Some tool tips do not have this ability and will not have a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The name of the tool tip control is the text that is displayed within the tool tip.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|`Null`|Tool tip controls are always self-labeled by their contents.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|ToolTip|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"tool tip"|Localized string corresponding to the ToolTip control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|Depends|If the tool tip control can receive keyboard focus, it must be in the Content View of the tree. If it is text only, then it is available as the HelpTextProperty from the control that raised it.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The tool tip control must always be a control.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by tool tip controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IWindowProvider>|Depends|Tool tips that can be closed by clicking a UI item must support WindowPattern so that they can closed automatically.|
|<xref:System.Windows.Automation.Provider.ITextProvider>|Depends|For better accessibility, a tool tip control can support the Text control pattern, although it is not required. The Text control pattern is useful when the text has rich style and attributes (for example, color, bold, and italics).|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 Tool tip controls must raise the `ToolTipOpenedEvent` when they appear on the screen. The event will include a reference to the UI Automation element of the tool tip itself.

 The following table lists the UI Automation events required to be supported by all tool tip controls. For more information about events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.TextPatternIdentifiers.TextSelectionChangedEvent>|Depends|None|
|<xref:System.Windows.Automation.TextPatternIdentifiers.TextChangedEvent>|Depends|None|
|<xref:System.Windows.Automation.WindowPatternIdentifiers.WindowClosedEvent>|Depends|None|
|<xref:System.Windows.Automation.WindowPatternIdentifiers.WindowOpenedEvent>|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ToolTipOpenedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ToolTipClosedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.WindowPatternIdentifiers.WindowVisualStateProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.ToolTip>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
