---
title: "UI Automation Support for the Image Control Type"
description: Get information about UI Automation support for the Image control type. Learn the required tree structure, properties, control patterns, and events.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, Image control type"
  - "control types, Image"
  - "Image control type"
ms.assetid: 4e0eeefb-e09b-46d2-b83b-0a7e35543ab8
---
# UI Automation Support for the Image Control Type

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic provides information about UI Automation support for the Image control type. In UI Automation, a control type is a set of conditions that a control must meet in order to use the <xref:System.Windows.Automation.AutomationElement.ControlTypeProperty> property. The conditions include specific guidelines for UI Automation tree structure, UI Automation property values and control patterns.

 Image controls used as icons, informational graphics, and charts will support the Image control type. Controls used as background or watermark images will not support the Image control type.

 The following sections define the required UI Automation tree structure, properties, control patterns, and events for the Image control type. The UI Automation requirements apply to all image controls, whether Windows Presentation Foundation (WPF), Win32, or Windows Forms.

<a name="Required_UI_Automation_Tree_Structure"></a>

## Required UI Automation Tree Structure

 The following table depicts the control view and the content view of the UI Automation tree that pertains to image controls and describes what can be contained in each view. For more information about the UI Automation tree, see [UI Automation Tree Overview](ui-automation-tree-overview.md).

|Control View|Content View|
|------------------|------------------|
|Image|Image (Depends whether the image contains information (based on the value of `IsContentElement` property))|

<a name="Required_UI_Automation_Properties"></a>

## Required UI Automation Properties

 The following table lists the UI Automation properties whose value or definition is especially relevant to the Image control type. For more information about UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

|UI Automation Property|Value|Notes|
|------------------------------------------------------------------------------------|-----------|-----------|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationIdProperty>|See notes.|The value of this property needs to be unique across all controls in an application.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>|See notes.|The outermost rectangle that contains the whole control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ClickablePointProperty>|See notes.|The image control’s clickable point must be a point within the bounding rectangle of the image control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsKeyboardFocusableProperty>|See notes.|If the control can receive keyboard focus, it must support this property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty>|See notes.|The Name property must be exposed for all image controls that contain information. Programmatic access to this information requires that a textual equivalent to the graphic be provided. If the image control is purely decorative, it must only show up in the control view of the UI Automation tree and is not required to have a name. UI frameworks must support an ALT or alternate text property on images that can be set from within their framework. This property will then map to the UI Automation Name property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LabeledByProperty>|See notes.|If there is a static text label then this property must expose a reference to that control.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ControlTypeProperty>|Image|This value is the same for all UI frameworks.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.LocalizedControlTypeProperty>|"image"|Localized string corresponding to the Image control type.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsContentElementProperty>|See notes.|The image control must be included in the content view of the UI Automation tree when it contains meaningful information not already exposed to the end user.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsControlElementProperty>|True|The image control is always included in the control view of the UI Automation tree.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.HelpTextProperty>|See notes.|The HelpText property exposes a localized string which describes the actual visual appearance of the control (for example, a red square with a white ‘X’) or other tooltip information associated with the image.<br /><br /> This property must be supported when a long description is needed to convey more information about the image control. For example, a complicated chart or diagram. This property maps to the HTML LongDesc tag and the Scalable Vector Graphics (SVG) Desc tag. Developers working with image controls must support a property to allow the visual description to be set on the control. This property must be mapped to the UI Automation VisualDescription property.|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.ItemStatusProperty>|See notes.|If the image control represents state information about a particular item on the screen, the control should be contained within the item. When the image is contained within an item the item must support the status property and raise appropriate notifications when the status changes.<br /><br /> If an image is a standalone control and is conveying status this property must be supported.|

<a name="Required_UI_Automation_Control_Patterns"></a>

## Required UI Automation Control Patterns

 The following table lists the UI Automation control patterns required to be supported by all image controls. For more information about control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

|Control Pattern|Support|Notes|
|---------------------|-------------|-----------|
|<xref:System.Windows.Automation.Provider.IGridItemProvider>|Depends|The image control supports the Grid Item pattern if the control is within a grid container.|
|<xref:System.Windows.Automation.Provider.ITableItemProvider>|Depends|The image control supports the Table Item pattern if the control is within a container that has header controls.|
|<xref:System.Windows.Automation.Provider.IInvokeProvider>|Never|If the image control contains a clickable image, the control should support a control type that supports the Invoke pattern, such as the Button control type.|
|<xref:System.Windows.Automation.Provider.ISelectionItemProvider>|Never|Image controls should not support the Selection Item pattern.|

<a name="Required_UI_Automation_Events"></a>

## Required UI Automation Events

 The following table lists the UI Automation events required to be supported by all image controls. For more information on events, see [UI Automation Events Overview](ui-automation-events-overview.md).

|UI Automation Event|Support|Notes|
|---------------------------------------------------------------------------------|-------------|-----------|
|<xref:System.Windows.Automation.InvokePatternIdentifiers.InvokedEvent>|Never|None|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent>|Never|None|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent>|Never|None|
|<xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementSelectedEvent>|Never|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsOffscreenProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.IsEnabledProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.NameProperty> property-changed event.|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.AutomationFocusChangedEvent>|Required|None|
|<xref:System.Windows.Automation.AutomationElementIdentifiers.StructureChangedEvent>|Required|None|

## See also

- <xref:System.Windows.Automation.ControlType.Image>
- [UI Automation Control Types Overview](ui-automation-control-types-overview.md)
- [UI Automation Overview](ui-automation-overview.md)
