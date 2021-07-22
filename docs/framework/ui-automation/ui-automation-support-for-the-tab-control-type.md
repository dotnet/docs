---
title: "UI Automation Support for the Tab Control Type"
description: Get information about UI Automation support for the Tab control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "TabControl type"
  - "UI Automation, Tab control type"
  - "control types, Tab"
ms.assetid: f8be2732-836d-4e4d-85e2-73aa39479bf4
---
# UI Automation Support for the Tab Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Tab control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and UI Automation. control patterns.

 A tab control is analogous to the dividers in a notebook or the labels in a file cabinet. By using a tab control, an application can define multiple pages for the same area of a window or dialog box.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Tab control type. The UI Automation requirements apply to all tab controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to tab controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Tab<br /><br /> <ul><li>TabItem (1 or more)</li><li>ScrollBar (0 or 1)<br /><br /> <ul><li>Button (0 or 2)</li></ul></li></ul>|Tab<br /><br /> -   TabItem (1 or more)|

 Tab controls have child UI Automation elements based on the Tab Item control type. When tab items are grouped (for example, as in Microsoft Office 2007 applications) the Tab control type can also host Groups control types for the grouped tab items, as the following tree structure shows.

|Control View|Content View|
|------------------|------------------|
|Tab<br /><br /> <ul><li>TabItem (1 or more)</li><li>Group (0 or more)<br /><br /> <ul><li>TabItem (0 or more)</li></ul></li><li>ScrollBar (0 or more)<br /><br /> <ul><li>Button (0 or 2)</li></ul></li></ul>|Tab<br /><br /> <ul><li>TabItem (1 or more)</li><li>Group (0 or more)<br /><br /> <ul><li>TabItem (0 or more)</li></ul></li></ul>|

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to the Tab control type. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The tab control rarely requires a Name property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|No|The tab control does not have a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|Tab controls typically have a static text label that is exposed through this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Tab|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"tab"|Localized string corresponding to the Tab control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|True|The Tab control type must be able to receive keyboard focus. Typically, a UI Automation client calls SetFocus on a tab control and one of its items will forward the keyboard focus to the tab control. It is possible for some tab containers to take focus without setting focus to one of its items.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The tab control is always included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The tab control is always included in the control view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.OrientationProperty>|See notes.|The tab control must always indicate whether it is positioned horizontally or vertically.|

<a name="Required_UI_Automation_Control_Patterns_and_Properties"></a>

## Required UI Automation Control Patterns and Properties

 The following table lists the UI Automation control patterns required to be supported by all tab controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern/Pattern Property|Support/Value|Notes|
|---------------------------------------|--------------------|-----------|
|<xref:System.Windows.Automation.Provider.ISelectionProvider>|Yes|All tab controls must support the Selection pattern.|
|<xref:System.Windows.Automation.Provider.ISelectionProvider.IsSelectionRequired%2A>|True|Tab controls always require that a selection be made.|
|<xref:System.Windows.Automation.Provider.ISelectionProvider.CanSelectMultiple%2A>|False|Tab controls are always single-selection containers.|
|<xref:System.Windows.Automation.Provider.IScrollProvider>|Depends|The Scroll pattern must be supported in the tab control has widgets that allow for a set of tab items to be scrolled through.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all tab controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontallyScrollableProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalScrollPercentProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontallyScrollableProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalViewSizeProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalScrollPercentProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalViewSizeProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Tab>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
