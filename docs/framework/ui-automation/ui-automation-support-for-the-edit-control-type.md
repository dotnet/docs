---
title: "UI Automation Support for the Edit Control Type"
description: Get information about UI Automation support for the Edit control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Edit"
  - "Edit control type"
  - "UI Automation, Edit control type"
ms.assetid: 6db9d231-c0a0-4e17-910e-ac80357f774f
---

# UI Automation Support for the Edit Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

This topic provides information about UI Automation support for the Edit control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values, and control patterns.

Edit controls enable a user to view and edit a simple line of text without rich formatting support.

The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Edit control type. The UI Automation requirements apply to all edit controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

The following table depicts the control view and the content view of the UI Automation tree that pertains to edit controls and describes what can be contained in each view. For more information about the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Edit|Edit|

The controls that implement the Edit control type will always have zero scroll bars in the control view of the UI Automation tree because it is a single-line control. The single line of text may wrap in some layout scenarios. The Edit control type is best suited for holding small amounts of editable or selectable text.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

The following table lists the UI Automation properties whose value or definition is especially relevant to edit controls. For more information about UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|The edit control must have a clickable point that gives input focus to the edit portion of the control when a user clicks the mouse there.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The name of the edit control is typically generated from a static text label. If there is not a static text label, a property value for `Name` must be assigned by the application developer. The `Name` property should never contain the textual contents of the edit control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|If there is a static text label associated with the control, then this property must expose a reference to that control. If the text control is a subcomponent of another control, it will not have a `LabeledBy` property set.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Edit|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"edit"|Localized string corresponding to the Edit control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The edit control is always included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The edit control is always included in the control view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsPasswordProperty>|See notes.|Must be set to true on edit controls that contain passwords. If an edit control does contain Password contents then this property can be used by a screen reader to determine whether keystrokes should be read out as the user types them.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns and Properties

The following table lists the control patterns required to be supported by all edit controls. For more information about control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern/Control Pattern Property|Support/Value|Notes|
|-----------------------------------------------|--------------------|-----------|
|<xref:System.Windows.Automation.Provider.ITextProvider>|Depends|Edit controls should support the Text control pattern because detailed text information should always be available for clients.|
|<xref:System.Windows.Automation.Provider.IValueProvider>|Depends|All edit controls that take a string must expose the Value pattern.|
|<xref:System.Windows.Automation.Provider.IValueProvider.IsReadOnly%2A>|See notes.|This property must be set to indicate whether the control can have a value set programmatically or is editable by the user.|
|<xref:System.Windows.Automation.Provider.IValueProvider.Value%2A>|See notes.|This property will return the textual contents of the edit control. If the `IsPasswordProperty` is set to `true`, this property must raise an `InvalidOperationException` when requested.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider>|Depends|All edit controls that take a numeric range must expose Range Value control pattern.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider.Minimum%2A>|See notes.|This property must be the smallest value that the edit control's contents can be set to.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider.Maximum%2A>|See notes.|This property must be the largest value that the edit control's contents can be set to.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider.SmallChange%2A>|See notes.|This property must indicate the number of decimal places that the value can be set to. If the edit only take integers, the `SmallChangeProperty` must be 1. If the edit takes a range from 1.0 to 2.0, then the `SmallChangeProperty` must be 0.1. If the edit control takes a range from 1.00 to 2.00 then the `SmallChangeProperty` must be 0.001.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider.LargeChange%2A>|`Null`|This property does not need to be exposed on an edit control.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider.Value%2A>|See notes.|This property will indicate the numeric contents of the edit control. When a more precise value is set by a UI Automation client within the ranges specified in the `Minimum` and `Maximum` properties, the Value property will automatically be rounded to the closest accepted value.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

The following table lists the UI Automation events required to be supported by all edit controls. For more information about events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent>|Required|None|
|<xref:System.Windows.Automation.TextPatternIdentifiers.TextSelectionChangedEvent>|Required|None|
|<xref:System.Windows.Automation.TextPatternIdentifiers.TextChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ValuePatternIdentifiers.ValueProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontallyScrollableProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalScrollPercentProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalViewSizeProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalScrollPercentProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticallyScrollableProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalViewSizeProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.RangeValuePatternIdentifiers.ValueProperty> property-changed event.|Depends|If the control supports the range Value control pattern, it must support this event.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Edit>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
