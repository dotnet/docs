---
title: "UI Automation Support for the Table Control Type"
description: Get information about UI Automation support for the Table control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "TableControl type"
  - "control types, Table"
  - "UI Automation, Table control type"
ms.assetid: 9050dde5-6469-4c83-abb7-f861c24ff985
---
# UI Automation Support for the Table Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Table control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns.

 Table controls contain rows and columns of text, and optionally, row headers and column headers.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Table control type. The UI Automation requirements apply to all table controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to table controls and describes what can be contained in each view. For more information on the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Table<br /><br /> -   Header (0 or 1)<br />-   Text (0 or 1)<br />-   Various controls (0 or more)|Table<br /><br /> -   Text (0 or more)<br />-   Various controls (0 or more)|

 If a table control has row or column headers, they must be exposed in the Control View of the UI Automation tree. The Content View does not need to expose this information because it can be accessed using the TablePattern.

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to Table controls. For more information about UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|Supported if there is a bounding rectangle. If not every point within the bounding rectangle is clickable, and you perform specialized hit testing, then override and provide a clickable point.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The table control typically gets its name from a static text label. If there is no static text label, you must assign a Name property that must always be available to explain the purpose of the table.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|If there is a static text label, this property should expose a reference to the automation element of the control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Table|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"table"|Localized string corresponding to the Table control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.HelpTextProperty>|See notes.|More details about the purpose of the table should be exposed through this property if it is not sufficiently explained by accessing the NameProperty.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The table control must always be content.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The table control must always be a control.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by Table controls. For more information on control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IGridProvider>|Yes|The table control always supports this control pattern because the items that it contains have data that is presented in a grid.|
|<xref:System.Windows.Automation.Provider.IGridItemProvider>|Yes (required with child objects)|The inner objects of a table should support both the GridItem and TableItem control patterns. The table itself need not support the GridItem or TableItem control patterns unless the table is part of another table.|
|<xref:System.Windows.Automation.Provider.ITableProvider>|Yes|The table control always has the capability of having headers associated with the content.|
|<xref:System.Windows.Automation.Provider.ITableItemProvider>|Yes (required with child objects)|The inner objects of a table should support both the GridItem and TableItem control patterns. The table itself need not support the GridItem or TableItem control patterns unless the table is part of another table.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all table controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Table>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
