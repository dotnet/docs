---
title: "UI Automation Support for the ListItem Control Type"
description: Get information about UI Automation support for the ListItem control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, List"
  - "List Item control type"
  - "UI Automation, List Item control type"
ms.assetid: 34f533bf-fc14-4e78-8fee-fb7107345fab
---
# UI Automation Support for the ListItem Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the <xref:System.Windows.Automation.ControlType.ListItem> control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns.

 List item controls are an example of controls that implement the ListItem control type.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the ListItem control type. The UI Automation requirements apply to all list controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to list item controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|ListItem<br /><br /> -   Image (0 or more)<br />-   Text (0 or more)<br />-   Edit (0 or more)|ListItem|

 The children of a list item control within the content view of the UI Automation tree must always be "0". If the structure of the control is such that other items are contained underneath the list item then it should follow the requirements for the [UI Automation Support for the TreeItem Control Type](ui-automation-support-for-the-treeitem-control-type.md) control type.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to list item controls. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|This value of this property should include the area of the image and text contents of the list item.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|Depends|If the list control has a clickable point (a point that can be clicked to cause the list to take focus) then that point must be exposed through this property. If the list control is completely covered by descendant list items it will raise a <xref:System.Windows.Automation.NoClickablePointException> to indicate that the client must ask an item inside the list control for a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The value of a list item control's name property comes from the text contents of the item.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|If there is a static text label then this property must expose a reference to that control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|ListItem|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"list item"|Localized string corresponding to the ListItem control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The list control is always included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The list control is always included in the control view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|True|If the container can accept keyboard input then this property value should be true.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.HelpTextProperty>|""|The Help text for list controls should explain why the user is being asked to make a choice from a list of options, which is typically the same type of information presented through a tooltip. For example, "Select an item to set the display resolution for your monitor."|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ItemTypeProperty>|Depends|This property should be exposed for list item controls that are representing an underlying object. These list item controls typically have an icon associated with the control that users associate with the underlying object.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty>|Depends|This property must return a value for whether the list item is currently scrolled into view within the parent container that implements Scroll control pattern.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by list item controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.ISelectionItemProvider>|Yes|List item control must implement this control pattern. This allows list items controls to convey when they are selected.|
|<xref:System.Windows.Automation.Provider.IScrollItemProvider>|Depends|If the list item is contained within a container that is scrollable then this control pattern must be implemented.|
|<xref:System.Windows.Automation.Provider.IToggleProvider>|Depends|If the list item is checkable and the action does not perform a selection state change then this control pattern must be implemented.|
|<xref:System.Windows.Automation.Provider.IExpandCollapseProvider>|Depends|If the item can be manipulated to show or hide information then this control pattern must be implemented.|
|<xref:System.Windows.Automation.Provider.IValueProvider>|Depends|If the item can be edited then this control pattern must be implemented. Changes to the list item control will cause changes to the values of <xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>, and <xref:System.Windows.Automation.Provider.IValueProvider.Value%2A>.|
|<xref:System.Windows.Automation.Provider.IGridItemProvider>|Depends|If item to item spatial navigation is supported within the list container and the container is arranged in rows and columns then the Grid Item control pattern must be implemented.|
|<xref:System.Windows.Automation.Provider.IInvokeProvider>|Depends|If the item has a command that can be performed on it, separate from selection, then this pattern must be implemented. This is typically an action associated with double-clicking the list item control. Examples would be launching a document from Microsoft Windows Explorer, or playing a music file in Microsoft Windows Media Player.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all list item controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.InvokePatternIdentifiers.InvokedEvent>|Depends|None|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent>|Required|None|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent>|Required|None|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementSelectedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ItemStatusProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ValuePatternIdentifiers.ValueProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.TogglePatternIdentifiers.ToggleStateProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.ListItem>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
