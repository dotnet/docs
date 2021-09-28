---
title: "UI Automation Support for the ComboBox Control Type"
description: Get information about UI Automation support for the ComboBox control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Combo Box"
  - "UI Automation, Combo Box control type"
  - "ComboBox controls"
ms.assetid: bb321126-4770-41da-983a-67b7b89d45dd
---
# UI Automation Support for the ComboBox Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the ComboBox control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values, control patterns, and UI Automation events.

 A combo box is a list box combined with a static control or an edit control that displays the currently selected item in the list box portion of the combo box. The list box portion of the control is displayed at all times or only appears when the user selects the drop-down arrow (which is a push button) next to the control. If the selection field is an edit control, the user can enter information that is not in the list; otherwise, the user can only select items in the list.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the ComboBox control type. The UI Automation requirements apply to all combo box controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to combo box controls and describes what can be contained in each view. For more information about the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|ComboBox<br /><br /> -   Edit (0 or 1)<br />-   List (1)<br />-   List Item (child of List; 0 to many)<br />-   Button (1)|ComboBox<br /><br /> -   List Item (0 to many)|

 The edit control in the control view of the combo box is necessary only if the combo box can be edited to take any input, as is the case of the combo box in the Run dialog box.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to combo box controls. For more information about UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|ComboBox|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.HelpTextProperty>|See notes.|The help text for combo box controls should explain why the user is being asked to choose an option from the combo box. The text is similar to information presented through a tooltip. For example, "Select an item to set the display resolution of your monitor."|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|Combo box controls are always included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|Combo box controls are always included in the control view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|True|Combo box controls expose a set of items from a selection container. The combo box control can receive keyboard focus, although when a UI Automation client sets focus on a combo box, any items in the combo box subtree might receive the focus.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|Combo box controls typically have a static text label that this property references.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"combo box"|Localized string corresponding to the ComboBox control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The combo box control typically gets its name from a static text control.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by all combo box controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IExpandCollapseProvider>|Yes|The combo box control must always contain the drop-down button in order to be a combo box.|
|<xref:System.Windows.Automation.Provider.ISelectionProvider>|Yes|Displays the current selection in the combo box. This support is delegated to the list box beneath the combo box.|
|<xref:System.Windows.Automation.Provider.IValueProvider>|Depends|If the combo box has the ability to take arbitrary text values, the Value pattern must be supported. This pattern provides the ability to programmatically set the string contents of the combo box. If the Value pattern is not supported, this indicates that the user must make a selection from the list items within the subtree of the combo box.|
|<xref:System.Windows.Automation.Provider.IScrollProvider>|Never|The Scroll pattern is never supported on a combo box directly. It is supported if a list box contained within a combo box can scroll. It may only be supported when the list box is visible on the screen.|

<a name="Required_Events"></a>

## Required Events

 The following table lists the UI Automation events required to be supported by all combo box controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|
|<xref:System.Windows.Automation.ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ValuePatternIdentifiers.ValueProperty> property-changed event.|Depends|If the control supports the Value pattern, it must support this event.|

## See also

- <xref:System.Windows.Automation.ControlType.ComboBox>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
