---
title: "UI Automation Support for the ProgressBar Control Type"
description: Get information about UI Automation support for the ProgressBar control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Progress Bar"
  - "ProgressBar control type"
  - "UI Automation, Progress Bar control type"
ms.assetid: 302e778c-24b0-4789-814a-c8d37cf53a5f
---
# UI Automation Support for the ProgressBar Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the ProgressBar control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values, control patterns, and UI Automation events.

 Progress bar controls are an example of controls that implement the ProgressBar control type. Progress bar controls are used to indicate the progress of a lengthy operation. The control consists of a rectangle that is gradually filled with the system highlight color as an operation progresses.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the ProgressBar control type. The UI Automation requirements apply to all list controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to progress bar controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|ProgressBar|ProgressBar|

 The progress bar controls do not have any children in the control or content view of the UI Automation tree.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to progress bar controls. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The progress bar control typically gets its name from a static text label. If there is not a static text label the application developer must expose a value for the `Name` property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|If there is a static text label then this property must expose a reference to that control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|ProgressBar|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"progress bar"|Localized string corresponding to the ProgressBar control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The progress bar control is always included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The progress bar control is always included in the control view of the UI Automation tree.|

<a name="Required_UI_Automation_Control_Patterns_and_Properties"></a>

## Required UI Automation Control Patterns and Properties

 The following table lists the UI Automation control patterns required to be supported by progress bar controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern/Pattern Property|Support/Value|Notes|
|---------------------------------------|--------------------|-----------|
|<xref:System.Windows.Automation.Provider.IValueProvider>|Depends|Progress bar controls that give a textual indication of progress must implement <xref:System.Windows.Automation.Provider.IValueProvider>.|
|<xref:System.Windows.Automation.Provider.IValueProvider.IsReadOnly%2A>|True|The value for this property is always True.|
|<xref:System.Windows.Automation.Provider.IValueProvider.Value%2A>|See notes.|This property exposes textual progress of a progress bar control.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider>|Depends|Progress bar controls that take a numeric range must implement <xref:System.Windows.Automation.Provider.IRangeValueProvider>|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider.Minimum%2A>|0.0|The value of this property is the smallest value that the control can be set to.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider.Maximum%2A>|100.0|The value of this property is the largest value that the control can be set to.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider.SmallChange%2A>|NaN|This property is not required because progress bar controls are read-only.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider.LargeChange%2A>|NaN|This property is not required because progress bar controls are read-only.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all progress bar controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ValuePatternIdentifiers.ValueProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.ProgressBar>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
