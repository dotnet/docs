---
title: "UI Automation Support for the Slider Control Type"
description: Get information about UI Automation support for the Slider control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Slider"
  - "UI Automation, Slider control type"
  - "Slider control type"
ms.assetid: 045ea62f-7b50-46cf-a5a9-8eb97704355f
---
# UI Automation Support for the Slider Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Slider control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control types.

 The Slider control is a composite control with buttons that enable a user with a mouse to set a numerical range or select from a set of items.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Slider control type. The UI Automation requirements apply to all slider controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the Control View and the Content View of the UI Automation tree that pertains to slider controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Slider<br /><br /> -   Button (2 or 4)<br />-   Thumb (only 1)<br />-   List Item (0 or more)|Slider<br /><br /> -   List Item (0 or more)|

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to the Slider control type. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes|The majority of slider controls must raise the <xref:System.Windows.Automation.NoClickablePointException> because the entire bounding rectangle of the slider control is occupied by child controls.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The name of the edit control is typically generated from a static text label. If there is not a static text label, a property value for `Name` must be assigned by the application developer. The `Name` property should never contain the textual contents of the edit control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|If there is a static text label associated with the control, then this property must expose a reference to that control. If the text control is a subcomponent of another control, it will not have a `LabeledBy` property set.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Slider|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"slider"|Localized string corresponding to the Edit Control Type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The edit control is always included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The edit control is always included in the control view of the UI Automation tree.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by all slider controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.ISelectionProvider>|Depends|A slider should support the Selection control pattern if the content represents one value among a discrete set of options. When the Selection control pattern is supported, the corresponding selection must be exposed as one or more child list items of the slider.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider>|Depends|A slider should support the RangeValue control pattern if the content can be set to a value within a numerical range.|
|<xref:System.Windows.Automation.Provider.IValueProvider>|Depends|A slider should support the Value control pattern if the content represents one value among a discrete set of options.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all slider controls.

 For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent>|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event|Required|None|
|<xref:System.Windows.Automation.RangeValuePatternIdentifiers.ValueProperty> property-changed event|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Slider>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
