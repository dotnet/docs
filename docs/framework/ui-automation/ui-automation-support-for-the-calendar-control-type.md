---
title: "UI Automation Support for the Calendar Control Type"
description: Get information about UI Automation support for the Calendar control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, Calendar control type"
  - "Calendar control type"
  - "control types, Calendar"
ms.assetid: e91a7393-a7f9-4838-a1a6-857438b24bc9
---
# UI Automation Support for the Calendar Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Calendar control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values, control patterns, and UI Automation events.

 Calendar controls allow a user to easily determine the date and select other dates.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Calendar control type. The UI Automation requirements apply to all calendar controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to calendar controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Calendar<br /><br /> <ul><li>DataGrid<br /><br /> <ul><li>Header (0 or 1)</li><li>HeaderItem (0 or 7; quantity depends on how many days are displayed in columns)</li><li>ListItem (quantity depends on how many days are displayed)</li><li>Button (0 or 2; for paging calendar view)</li></ul></li></ul>|Calendar<br /><br /> -   ListItem (quantity depends on how many days are displayed)|

 Calendar controls can be represented in many different forms within the user interface. The only guaranteed controls to be in the control view of the UI Automation tree are the data grid, header, header item, and list item controls.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to the calendar controls. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Calendar|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The calendar control is always included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The calendar control is always included in the control view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|The label of the document control. Typically, the title of the document is used.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"calendar"|Localized string corresponding to the Calendar control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The calendar control typically gets its name from the current day’s date.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by all calendar controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern/Pattern Property|Support|Notes|
|---------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IGridProvider>|Yes|The calendar control always supports the Grid pattern because the days within a month are items that can be navigated spatially.|
|<xref:System.Windows.Automation.Provider.IScrollProvider>|Depends|Most calendar controls support flipping the view by page. The Scroll pattern is recommended in order to support paging navigation.|
|<xref:System.Windows.Automation.Provider.ISelectionProvider>|Depends|Most calendar controls retain a specific day, month, or year as a selection of the sub-element. Some calendars are multi-selectable and others only single-selectable.|
|<xref:System.Windows.Automation.Provider.ITableProvider>|Yes|The calendar control always has a header within its subtree for the days of the week, so the Table pattern must be supported.|
|<xref:System.Windows.Automation.Provider.IValueProvider>|No|The Value control pattern is not necessary for calendar controls because you cannot set the value directly on the control. If a specific date is associated with the control, the information should be provided by the Selection control pattern.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all calendar controls. For more information about events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LayoutInvalidatedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|
|<xref:System.Windows.Automation.MultipleViewPatternIdentifiers.CurrentViewProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontallyScrollableProperty> property-changed event.|Depends|If the control supports the Scroll control pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalScrollPercentProperty> property-changed event.|Depends|If the control supports the Scroll control pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalViewSizeProperty> property-changed event.|Depends|If the control supports the Scroll control pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalScrollPercentProperty> property-changed event.|Depends|If the control supports the Scroll control pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticallyScrollableProperty> property-changed event.|Depends|If the control supports the Scroll control pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalViewSizeProperty> property-changed event.|Depends|If the control supports the Scroll control pattern, it must support this event.|
|<xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Calendar>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
