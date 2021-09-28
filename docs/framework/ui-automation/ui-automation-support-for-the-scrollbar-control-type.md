---
title: "UI Automation Support for the ScrollBar Control Type"
description: Get information about UI Automation support for the ScrollBar control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, Scroll Bar control type"
  - "control types, Scroll Bar"
  - "Scroll Bar control type"
ms.assetid: 329891d7-b609-49e6-920a-09ea8a627d07
---
# UI Automation Support for the ScrollBar Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the ScrollBar control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns.

 Scroll bar controls enable a user to scroll content within a window or item container. The control is made up of a set of buttons and a thumb control.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the ScrollBar control type. The UI Automation requirements apply to all list controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to scroll bar controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|ScrollBar<br /><br /> -   Button (2 or 4)<br />-   Thumb (0 or1)|Not applicable. The scroll bar control does not contain content.|

 The scroll bar control always has three to five children. Because the subtree has more than one button control, you must set a specific <xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty> value to each item to make them discoverable for test automation tools.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to scroll bar controls. Note that a scroll bar control never has content; its functionality is exposed through the Scroll control pattern, which is supported on the container being scrolled.

 For more information about UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|`Null`|The scroll bar control does not have content elements and the `NameProperty` is not required to be set.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|Not a number.|The scroll bar control does not have clickable points.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|`Null`|Scroll bars do not have labels.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|ScrollBar|This value is the same for all frameworks. Scroll bars that function as sliders must use the Slider control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"scroll bar"|Localized string that corresponds to the Button control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|False|The scroll bar control is never a content element. If the scroll bar is a standalone control, then it must fulfill the Slider control type and return `ControlType.Slider` for the `ControlType` property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The scroll bar must always be a control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.OrientationProperty>|True|The scroll bar control must always expose its horizontal or vertical orientation.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by scroll bar controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md). Note that when a scroll bar is used as a control for mouse manipulation only, it does not support control patterns. If it is used as a slider control within an application, it must be given the Slider control type.

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IScrollProvider>|Never|The Scroll control pattern is never directly supported on the scroll bar.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider>|Depends|This functionality is required to be supported only if the Scroll control pattern is not supported on the container that has the scroll bar.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all scroll bar controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support/Value|Notes|
|---------------------------------------------------------------------------------|--------------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontallyScrollableProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalScrollPercentProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalViewSizeProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalScrollPercentProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticallyScrollableProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalViewSizeProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.RangeValuePatternIdentifiers.ValueProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.ScrollBar>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
