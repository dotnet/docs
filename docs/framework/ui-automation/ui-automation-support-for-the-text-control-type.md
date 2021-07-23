---
title: "UI Automation Support for the Text Control Type"
description: Get information about UI Automation support for the Text control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Text control type"
  - "UI Automation, Text control type"
  - "control types, Text"
ms.assetid: ab0d0ada-8a71-4547-9c03-aadf675938f2
---
# UI Automation Support for the Text Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Text control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns.

 Text controls are the basic user interface item that represents a piece of text on the screen.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Text control type. The UI Automation requirements apply to all text controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to text controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Text|Text (if content)|

 A text control can be used alone as a label or as static text on a form. It can also be contained within the structure of a:

- ListItem

- TreeItem

- DataItem

 Text controls may not be in the Content View of the UI Automation tree because text is often displayed through the `NameProperty` of another control. For example the text that is used to label a Combo Box control is exposed through the control's `NameProperty` value. Because the Combo Box control is in the content view of the UI Automation Tree, it is not necessary for the text control to be there. Text controls always have 0 children in the content view

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to text controls. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The text bar control's name is always the txt that it displays.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|`Null`|Text controls do not have a static text label.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Text|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"text"|Localized string corresponding to the text control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|Depends|The text control will be content if it contains information not exposed in another control's NameProperty.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The text control must always be a control.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by text controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IValueProvider>|Never|Text never supports ValuePattern. If the text is editable, this it is the Edit control type.|
|<xref:System.Windows.Automation.Provider.ITextProvider>|Depends|Text should support the Text control pattern for better accessibility; however, it is not required. The Text control pattern is useful when the text has rich style and attributes (for example, color, bold, and italics).Depends on framework.|
|<xref:System.Windows.Automation.Provider.ITableItemProvider>|Depends|If the text element is contained within a Table control, this must be supported.|
|<xref:System.Windows.Automation.Provider.IRangeValueProvider>|Depends|If the text element is contained within a table control, this must be supported.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all text controls. For more information about events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.TextPatternIdentifiers.TextSelectionChangedEvent>|Required|None|
|<xref:System.Windows.Automation.TextPatternIdentifiers.TextChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ValuePatternIdentifiers.ValueProperty> property-changed event.|Never|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Text>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
