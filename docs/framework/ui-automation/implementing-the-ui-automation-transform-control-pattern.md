---
title: "Implementing the UI Automation Transform Control Pattern"
description: Review guidelines and conventions to implement the Transform control pattern in UI Automation. Know required members for the ITransformProvider interface.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control patterns, Transform"
  - "Transform control pattern"
  - "UI Automation, Transform control pattern"
ms.assetid: 5f49d843-5845-4800-9d9c-56ce0d146844
---
# Implementing the UI Automation Transform Control Pattern

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic introduces guidelines and conventions for implementing <xref:System.Windows.Automation.Provider.ITransformProvider>, including information about properties, methods, and events. Links to additional references are listed at the end of the topic.

 The <xref:System.Windows.Automation.TransformPattern> control pattern is used to support controls that can be moved, resized, or rotated within a two-dimensional space. For examples of controls that implement this control pattern, see [Control Pattern Mapping for UI Automation Clients](control-pattern-mapping-for-ui-automation-clients.md).

<a name="Implementation_Guidelines_and_Conventions"></a>

## Implementation Guidelines and Conventions

 When implementing the Transform control pattern, note the following guidelines and conventions:

- Support for this control pattern is not limited to objects on the desktop. This control pattern must also be supported by the children of a container object if the children can be moved, resized, or rotated freely within the boundaries of the container.

- An object cannot be moved, resized, or rotated such that its resulting screen location would be completely outside the coordinates of its container and therefore inaccessible to the keyboard or mouse (for example, when a top-level window is moved off-screen or a child object is moved outside the boundaries of the container's viewport). In these cases, the object is placed as close to the requested screen coordinates as possible with the top or left coordinates overridden to be within the container boundaries.

- For multi-monitor systems, if an object is moved, resized, or rotated completely outside the combined desktop screen coordinates, the object is placed on the primary monitor as close to the requested coordinates as possible.

- All parameters and property values are absolute and independent of locale.

<a name="Required_Members_for_the_IValueProvider_Interface"></a>

## Required Members for ITransformProvider

 The following properties and methods are required for implementing <xref:System.Windows.Automation.Provider.ITransformProvider>.

|Required members|Member type|Notes|
|----------------------|-----------------|-----------|
|<xref:System.Windows.Automation.Provider.ITransformProvider.CanMove%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.ITransformProvider.CanResize%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.ITransformProvider.CanRotate%2A>|Property|None|
|<xref:System.Windows.Automation.Provider.ITransformProvider.Move%2A>|Method|None|
|<xref:System.Windows.Automation.Provider.ITransformProvider.Resize%2A>|Method|None|
|<xref:System.Windows.Automation.Provider.ITransformProvider.Rotate%2A>|Method|None|

 This control pattern has no associated events.

<a name="Exceptions"></a>

## Exceptions

 Providers must throw the following exceptions.

|Exception Type|Condition|
|--------------------|---------------|
|<xref:System.InvalidOperationException>|<xref:System.Windows.Automation.Provider.ITransformProvider.Move%2A><br /><br /> -   If the <xref:System.Windows.Automation.TransformPatternIdentifiers.CanMoveProperty> is false.|
|<xref:System.InvalidOperationException>|<xref:System.Windows.Automation.Provider.ITransformProvider.Resize%2A><br /><br /> -   If the <xref:System.Windows.Automation.TransformPatternIdentifiers.CanResizeProperty> is false.|
|<xref:System.InvalidOperationException>|<xref:System.Windows.Automation.Provider.ITransformProvider.Rotate%2A><br /><br /> -   If the <xref:System.Windows.Automation.TransformPatternIdentifiers.CanRotateProperty> is false.|

## See also

- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [Support Control Patterns in a UI Automation Provider](support-control-patterns-in-a-ui-automation-provider.md)
- [UI Automation Control Patterns for Clients](ui-automation-control-patterns-for-clients.md)
- [UI Automation Tree Overview](ui-automation-tree-overview.md)
- [Use Caching in UI Automation](use-caching-in-ui-automation.md)
