---
title: "Implementing the UI Automation Toggle Control Pattern"
description: Review guidelines and conventions to implement the Toggle control pattern in UI Automation. Know required members for the IToggleProvider interface.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "Toggle control pattern"
  - "control patterns, Toggle"
  - "UI Automation, Toggle control pattern"
ms.assetid: 3cfe875f-b0c0-413d-9703-5f14e6a1a30e
---
# Implementing the UI Automation Toggle Control Pattern

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic introduces guidelines and conventions for implementing <xref:System.Windows.Automation.Provider.IToggleProvider>, including information about methods and properties. Links to additional references are listed at the end of the topic.

 The <xref:System.Windows.Automation.TogglePattern> control pattern is used to support controls that can cycle through a set of states and maintain a state once set. For examples of controls that implement this control pattern, see [Control Pattern Mapping for UI Automation Clients](control-pattern-mapping-for-ui-automation-clients.md).

<a name="Implementation_Guidelines_and_Conventions"></a>

## Implementation Guidelines and Conventions

 When implementing the Toggle control pattern, note the following guidelines and conventions:

- Controls that do not maintain state when activated, such as buttons, toolbar buttons, and hyperlinks, must implement <xref:System.Windows.Automation.Provider.IInvokeProvider> instead.

- A control must cycle through its <xref:System.Windows.Automation.ToggleState> in the following order: <xref:System.Windows.Automation.ToggleState.On>, <xref:System.Windows.Automation.ToggleState.Off> and, if supported, <xref:System.Windows.Automation.ToggleState.Indeterminate>.

- <xref:System.Windows.Automation.TogglePattern> does not provide a SetState(newState) method due to issues surrounding the direct setting of a tri-state CheckBox without cycling through its appropriate <xref:System.Windows.Automation.ToggleState> sequence.

- The RadioButton control does not implement <xref:System.Windows.Automation.Provider.IToggleProvider>, as it is not capable of cycling through its valid states.

<a name="Required_Members_for_IToggleProvider"></a>

## Required Members for IToggleProvider

 The following properties and methods are required for implementing <xref:System.Windows.Automation.Provider.IToggleProvider>.

|Required member|Member type|Notes|
|---------------------|-----------------|-----------|
|<xref:System.Windows.Automation.TogglePattern.Toggle%2A>|Method|None|
|<xref:System.Windows.Automation.TogglePatternIdentifiers.ToggleStateProperty>|Property|None|

 This control pattern has no associated events.

<a name="Exceptions"></a>

## Exceptions

 This control pattern has no associated exceptions.

## See also

- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [Support Control Patterns in a UI Automation Provider](support-control-patterns-in-a-ui-automation-provider.md)
- [UI Automation Control Patterns for Clients](ui-automation-control-patterns-for-clients.md)
- [Get the Toggle State of a Check Box Using UI Automation](get-the-toggle-state-of-a-check-box-using-ui-automation.md)
- [UI Automation Tree Overview](ui-automation-tree-overview.md)
- [Use Caching in UI Automation](use-caching-in-ui-automation.md)
