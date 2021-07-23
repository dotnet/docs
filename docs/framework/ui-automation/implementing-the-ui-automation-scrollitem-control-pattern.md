---
title: "Implementing the UI Automation ScrollItem Control Pattern"
description: Review guidelines and conventions for implementing the ScrollItem control pattern in UI Automation. See required members for the IScrollItemProvider interface.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control patterns, Scroll Item"
  - "UI Automation, Scroll Item control pattern"
  - "Scroll Item control pattern"
ms.assetid: 903bab5c-80c1-44d7-bdc2-0a418893b987
---
# Implementing the UI Automation ScrollItem Control Pattern

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic introduces guidelines and conventions for implementing the <xref:System.Windows.Automation.Provider.IScrollItemProvider>, including information about properties, methods, and events. Links to additional references are listed at the end of the topic.

 The <xref:System.Windows.Automation.ScrollItemPattern> control pattern is used to support individual child controls of containers that implement <xref:System.Windows.Automation.Provider.IScrollProvider>. This control pattern acts as a communication channel between a child control and its container to ensure that the container can change the currently visible content (or region) within its viewport to display the child control. For examples of controls that implement this control pattern, see [Control Pattern Mapping for UI Automation Clients](control-pattern-mapping-for-ui-automation-clients.md).

<a name="Implementation_Guidelines_and_Conventions"></a>

## Implementation Guidelines and Conventions

 When implementing the Scroll Item control pattern, note the following guidelines and conventions:

- Items contained within a Window or Canvas control are not required to implement the IScrollItemProvider interface. As an alternative, however, they must expose a valid location for the <xref:System.Windows.Automation.AutomationElementIdentifiers.BoundingRectangleProperty>. This will allow a UI Automation client application to use the <xref:System.Windows.Automation.ScrollPattern> control pattern methods on the container to display the child item.

<a name="Required_Members_for_IScrollItemProvider"></a>

## Required Members for IScrollItemProvider

 The following method is required for implementing the IScrollProvider interface.

|Required members|Member type|Notes|
|----------------------|-----------------|-----------|
|<xref:System.Windows.Automation.Provider.IScrollItemProvider.ScrollIntoView%2A>|-   Method|None|

 This control pattern has no associated properties or events.

<a name="Exceptions"></a>

## Exceptions

 Providers must throw the following exceptions.

|Exception Type|Condition|
|--------------------|---------------|
|<xref:System.InvalidOperationException>|If an item cannot be scrolled into view:<br /><br /> -   <xref:System.Windows.Automation.ScrollItemPattern.ScrollIntoView%2A>|

## See also

- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [Support Control Patterns in a UI Automation Provider](support-control-patterns-in-a-ui-automation-provider.md)
- [UI Automation Control Patterns for Clients](ui-automation-control-patterns-for-clients.md)
- [UI Automation Tree Overview](ui-automation-tree-overview.md)
- [Use Caching in UI Automation](use-caching-in-ui-automation.md)
