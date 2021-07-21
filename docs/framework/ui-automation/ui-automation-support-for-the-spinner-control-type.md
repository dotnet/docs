---
title: "UI Automation Support for the Spinner Control Type"
description: Get information about UI Automation support for the Spinner control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, Spinner control type"
  - "Spinner control type"
  - "control types, Spinner"
ms.assetid: 3a29d185-65d8-42e3-bcc3-7f43e96f40c5
---
# UI Automation Support for the Spinner Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Spinner control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns.

 Spinner controls are used to select from a domain of items or a range of numbers.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Spinner control type. The UI Automation requirements apply to all spinner controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertain to spinner controls when they support the Range Value, Value, and Selection control patterns and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

 **Range Value or Value control pattern**

|Control View|Content View|
|------------------|------------------|
|Spinner<br /><br /> -   Edit (0 or 1)<br />-   Button (2)|Spinner|

 **Selection control pattern**

|Control View|Content View|
|------------------|------------------|
|Spinner<br /><br /> -   Edit (0 or 1)<br />-   Button (2)<br />-   List Item (0 or more)|Spinner<br /><br /> -   ListItem (0 or more)|

 To ensure that the two buttons in the control view subtree can be distinguished by automated test tools, assign the `SmallIncrement` or `SmallDecrement` `AutomationId` as appropriate. For some implementations, the associated Edit control may be a peer of the Spinner control.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to spinner controls. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|The spinner control's clickable point gives focus to the edit portion of the control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The spinner control typically gets its name from a static text label.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|Spinner controls have a static text label.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Spinner|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"spinner"|Localized string corresponding to the Spinner control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The spinner control must always be content.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The Spinner control must always be a control.|

<a name="Required_UI_Automation_Control_Patterns_and_Properties"></a>

## Required UI Automation Control Patterns and Properties

 The following table lists the UI Automation control patterns required to be supported by spinner controls. For more information about control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern/Pattern Property|Support/Value|Notes|
|---------------------------------------|--------------------|-----------|
|<xref:System.Windows.Automation.Provider.ISelectionProvider>|Depends|Spinner controls that have a list of items to be selected must support this pattern.|
|<xref:System.Windows.Automation.Provider.ISelectionProvider.CanSelectMultiple%2A>|False|Spinner controls are always single selection containers.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider>|Depends|Spinner controls that span a numeric range can support this pattern.|
|<xref:System.Windows.Automation.Provider.IValueProvider>|Depends|Spinner controls that span a discrete set of options or numbers can support this pattern.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all spinner controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent>|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ValuePatternIdentifiers.ValueProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.RangeValuePatternIdentifiers.ValueProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Spinner>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
