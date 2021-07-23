---
title: "UI Automation Support for the DataGrid Control Type"
description: Get information about UI Automation support for the DataGrid control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Data Grid control type"
  - "control types, Data Grid"
  - "UI Automation, Data Grid control type"
ms.assetid: a3db4a3f-feb5-4e5f-9b42-aae7fa816e8a
---
# UI Automation Support for the DataGrid Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about Microsoft UI Automation support for the DataGrid control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the `ControlType` property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns.

 The DataGrid control type lets a user easily work with items that contain metadata represented in columns. Data grid controls have rows of items and columns of information about those items. A List View control in Microsoft Vista Explorer is an example that supports the DataGrid control type.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the DataGrid control type. The UI Automation requirements apply to all data grid controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to data grid controls and describes what can be contained in each view. For more information about the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|UI Automation Tree - Control View|UI Automation Tree - Content View|
|------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------|
|DataGrid<br /><br /> <ul><li>Header (0, 1, or 2)<br /><br /> <ul><li>HeaderItem (number of columns or rows)</li></ul></li><li>DataItem (0 or more; can be structured in hierarchy)</li></ul>|DataGrid<br /><br /> -   DataItem (0 or more; can be structured in hierarchy)|

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the properties whose value or definition is especially relevant to data grid controls. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|Property|Value|Notes|
|--------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|DataGrid|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The value of this property must always be True. This means that the data grid control must always be in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The value of this property must always be True. This means that the data grid control must always be in the control view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|If there is a static text label then this property must expose a reference to that control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"data grid"|Localized string corresponding to the DataGrid control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The data grid control typically gets the value for its `Name` property from a static text label. If there is not a static text label an application developer must assign a value to for the `Name` property. The value of the `Name` property must never be the textual contents of the edit control.|

## Required UI Automation Control Patterns

 The following table lists the control patterns required to be supported by all data grid controls. For more information about control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IGridProvider>|Yes|The data grid control itself always supports the Grid control pattern because the items that it contains metadata that is laid out in a grid.|
|<xref:System.Windows.Automation.Provider.IScrollProvider>|Depends|The ability to scroll the data grid depends on content and whether scroll bars are present.|
|<xref:System.Windows.Automation.Provider.ISelectionProvider>|Depends|The ability to select the data grid depends on content.|
|<xref:System.Windows.Automation.Provider.ITableProvider>|Yes|The data grid control always has a header within its subtree so the Table control pattern must be supported.|

 Data items within the data grid containers will support at a minimum:

- Selection Item control pattern (if the data grid is selectable)

- Scroll Item control pattern (if the data grid is scrollable)

- Grid Item control pattern

- Table Item control pattern

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all data grid controls. For more information about events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LayoutInvalidatedEvent>|Depends|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|
|<xref:System.Windows.Automation.MultipleViewPatternIdentifiers.CurrentViewProperty> property-changed event.|Depends|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontallyScrollableProperty> property-changed event.|Depends|If the control supports the Scroll pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalScrollPercentProperty> property-changed event.|Depends|If the control supports the Scroll pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalViewSizeProperty> property-changed event.|Depends|If the control supports the Scroll pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalScrollPercentProperty> property-changed event.|Depends|If the control supports the Scroll pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticallyScrollableProperty> property-changed event.|Depends|If the control supports the Scroll pattern, it must support this event.|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalViewSizeProperty> property-changed event.|Depends|If the control supports the Scroll pattern, it must support this event.|
|<xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent>|Required|None|

## Date Grid Control Type Example

 The following image illustrates a List View control that implements the DataGrid control type.

 ![Graphic of a List View control with two data items](./media/uiauto-data-grid-detailed.GIF "uiauto_data_grid_detailed")

 The control view and the content view of the UI Automation tree that pertains to the List View control is displayed below. The control patterns for each automation element are shown in parentheses.

|UI Automation Tree - Control View|UI Automation Tree - Content View|
|------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------|
|<ul><li>DataGrid (Table, Grid, Selection)</li><li>Header<br /><br /> <ul><li>HeaderItem "Name" (Invoke)</li><li>HeaderItem "Date Modified" (Invoke)</li><li>HeaderItem "Size" (Invoke)</li></ul></li><li>Group "Contoso" (TableItem, GridItem, SelectionItem, Table*, Grid\*)<br /><br /> <ul><li>DataItem "Accounts Receivable.doc" (SelectionItem, Invoke, TableItem\*, GridItem\*)</li><li>DataItem "Accounts Payable.doc" (SelectionItem, Invoke, TableItem\*, GridItem\*)</li></ul></li></ul>|<ul><li>DataGrid (Table, Grid, Selection)</li><li>Group "Contoso" (TableItem, GridItem, SelectionItem, Table*, Grid\*)<br /><br /> <ul><li>DataItem "Accounts Receivable.doc" (SelectionItem, Invoke, TableItem\*, GridItem\*)</li><li>DataItem "Accounts Payable.doc" (SelectionItem, Invoke, TableItem\*, GridItem\*)</li></ul></li></ul>|

 \* The previous example shows a DataGrid that contains multiple levels of controls. The Group ("Contoso") control contains two DataItem controls ("Accounts Receivable.doc" and "Accounts Payable.doc"). A DataGrid/GridItem pair is independent of a pair at another level. The DataItem controls under a Group can also be exposed as a ListItem control type, enabling them to be presented more clearly as selectable objects, rather than as simple data elements. This example does not include the sub-elements of the grouped data items.

## See also

- <xref:System.Windows.Automation.ControlType.DataGrid>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
