---
title: "UI Automation Support for the Document Control Type"
description: Get information about UI Automation support for the Document control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control types, Document"
  - "Document control type"
  - "UI Automation, Document control type"
ms.assetid: a79d594b-1ca0-4543-8dac-afd2c645201d
---
# UI Automation Support for the Document Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Document control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values, and control patterns.

 Document controls let a user view and manipulate multiple pages of text. Unlike edit controls which only support a simple line of unformatted text, document controls can host text that is richly styled and formatted.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Document control type. The UI Automation requirements apply to all document controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to document controls and describes what can be contained in each view. For more information about the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Document<br /><br /> -   Varies|Document<br /><br /> -   Varies|

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to document controls. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|The document has a clickable point that will cause the document of one of its elements in the document container to have focus.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Document|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|True|The document control is always included in the content view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The document control is always included in the control view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|The value of this property should be the label of the document control. Typically, the title of the document is used.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"document"|Localized string corresponding to the Document control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The document control typically gets its names from the file name it is loaded from. This is often displayed in a containing window or frame title.|

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by document controls. For more information about control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IScrollProvider>|Depends|The document control can span larger than that span of the viewport. The control should support the Scroll control pattern if the content is scrollable.|
|<xref:System.Windows.Automation.Provider.ITextProvider>|Required|The document control can span larger than that span of the viewport. The control should support the Scroll control pattern if the content is scrollable.|
|<xref:System.Windows.Automation.Provider.IValueProvider>|Never|The document control does not support this control pattern because the contents of the control often span more than one page. UI Automation clients should use <xref:System.Windows.Automation.TextPattern> to obtain text information about a document.|

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all document controls. For more information about events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontallyScrollableProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalScrollPercentProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.HorizontalViewSizeProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalScrollPercentProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticallyScrollableProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.ScrollPatternIdentifiers.VerticalViewSizeProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent>|Depends|If the control supports the Selection control pattern, it must support this event.|
|<xref:System.Windows.Automation.TextPatternIdentifiers.TextSelectionChangedEvent>|Required|None|
|<xref:System.Windows.Automation.TextPatternIdentifiers.TextChangedEvent>|Required|None|
|<xref:System.Windows.Automation.ValuePatternIdentifiers.ValueProperty> property-changed event.|Never|None|

## See also

- <xref:System.Windows.Automation.ControlType.Document>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
