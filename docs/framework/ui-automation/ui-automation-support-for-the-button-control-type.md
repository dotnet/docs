---
title: "UI Automation Support for the Button Control Type"
description: Get information about UI Automation support for the Button control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Button"
  - "UI Automation, Button control type"
  - "Button control type"
ms.assetid: 057c983a-da83-4c50-86c7-26fe381076a6
---
# UI Automation Support for the Button Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Button control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values, control patterns, and UI Automation events.

 A button is an object that a user interacts with to perform an action such as the **OK** and **Cancel** buttons on a dialog box. The button control is a simple control to expose because it maps to a single command that the user wishes to complete.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Button control type. The UI Automation requirements apply to all button controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to button controls and describes what can be contained in each view. For more information about the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Button<br /><br /> -   Image (0 or more)<br />-   Text (0 or more)|Button|

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to the controls that implement the Button control type (such as button controls). For more information about UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AcceleratorKeyProperty>|See notes.|The Button control typically must support an accelerator key to enable an end user to perform the action it represents quickly from the keyboard.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Button|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.HelpTextProperty>|See notes.|The Help Text can indicate what the end result of activating the button will be. This is typically the same type of information presented through a ToolTip.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The Button control must always be content.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The Button control must always be a control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|`Null`|Button controls are self-labeled by their contents.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"button"|Localized string corresponding to the Button control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The name of the button control is the text that is used to label it. Whenever an image is used to label a button, alternate text must be supplied for the button's Name property.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by all button controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IInvokeProvider>|See notes.|All buttons should support the Invoke control pattern or the Toggle control pattern. Invoke is supported when the button performs a command at the request of the user. This command maps to a single operation such as Cut, Copy, Paste, or Delete.|
|<xref:System.Windows.Automation.Provider.IToggleProvider>|See notes.|All buttons should support the Invoke control pattern or the Toggle control pattern. Toggle is supported if the button can be cycled through a series of up to three states. Typically this is seen as an on/off switch for specific features.|
|<xref:System.Windows.Automation.Provider.IExpandCollapseProvider>|See notes.|When a button is hosted as a child of a split button, the child button can support the ExpandCollapse pattern instead of the Invoke or Toggle pattern. The ExpandCollapse pattern can be used for opening or closing a menu or other sub-structure associated with the button element.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all button controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|
|<xref:System.Windows.Automation.InvokePatternIdentifiers.InvokedEvent>|Depends|If the control supports the Invoke control pattern, it must support this event.|
|<xref:System.Windows.Automation.TogglePatternIdentifiers.ToggleStateProperty> property-changed event.|Depends|If the control supports the Toggle control pattern, it must support this event.|

## See also

- <xref:System.Windows.Automation.ControlType.Button>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
