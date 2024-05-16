---
title: "Implementing the UI Automation RangeValue Control Pattern"
description: Review guidelines and conventions for implementing the RangeValue control pattern in UI Automation. See required members for the IRangeValueProvider interface.
ms.date: "03/30/2017"
helpviewer_keywords:
  - "control patterns, Range Value"
  - "Range Value control pattern"
  - "UI Automation, Range Value control pattern"
ms.assetid: 225feaa4-918e-418b-938e-7389338d0a69
---
# Implementing the UI Automation RangeValue Control Pattern

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This topic introduces guidelines and conventions for implementing <xref:System.Windows.Automation.Provider.IRangeValueProvider>, including information about events and properties. Links to additional references are listed at the end of the topic.

 The <xref:System.Windows.Automation.RangeValuePattern> control pattern is used to support controls that can be set to a value within a range. For examples of controls that implement this control pattern, see [Control Pattern Mapping for UI Automation Clients](control-pattern-mapping-for-ui-automation-clients.md).

<a name="Implementation_Guidelines_and_Conventions"></a>

## Implementation Guidelines and Conventions

 When implementing the Range Value control pattern, note the following guidelines and conventions:

- Controls allow recalibration of their supported properties based upon locale or user preference. An example of this is a thermometer control that can be set to display the temperature in Fahrenheit or Celsius.

- Controls that have ambiguous range values, such as progress bars or sliders, should have those values normalized.

 ![Progress bar.](./media/uia-rangevaluepattern-progress-bar.PNG "UIA_RangeValuePattern_Progress_Bar")
Example of a Progress Bar Where Value Is of Type Integer and Minimum and Maximum Property Values Are Normalized to 0 and 100, Respectively

<a name="Required_Members_for_the_IRangeValueProvider"></a>

## Required Members for IRangeValueProvider

|Required member|Member type|Notes|
|---------------------|-----------------|-----------|
|<xref:System.Windows.Automation.RangeValuePattern.IsReadOnlyProperty>|Property|None|
|<xref:System.Windows.Automation.RangeValuePattern.ValueProperty>|Property|None|
|<xref:System.Windows.Automation.RangeValuePattern.LargeChangeProperty>|Property|None|
|<xref:System.Windows.Automation.RangeValuePattern.SmallChangeProperty>|Property|None|
|<xref:System.Windows.Automation.RangeValuePattern.MaximumProperty>|Property|None|
|<xref:System.Windows.Automation.RangeValuePattern.MinimumProperty>|Property|None|
|<xref:System.Windows.Automation.RangeValuePattern.SetValue%2A>|Methods|None|

 This control pattern has no associated events.

<a name="Exceptions"></a>

## Exceptions

 Providers must throw the following exceptions.

|Exception type|Condition|
|--------------------|---------------|
|<xref:System.ArgumentOutOfRangeException>|<xref:System.Windows.Automation.RangeValuePattern.SetValue%2A> is called with a value that is either greater than <xref:System.Windows.Automation.RangeValuePattern.MaximumProperty> or less than <xref:System.Windows.Automation.RangeValuePattern.MinimumProperty>.|

## See also

- [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md)
- [Support Control Patterns in a UI Automation Provider](support-control-patterns-in-a-ui-automation-provider.md)
- [UI Automation Control Patterns for Clients](ui-automation-control-patterns-for-clients.md)
- [UI Automation Tree Overview](ui-automation-tree-overview.md)
- [Use Caching in UI Automation](use-caching-in-ui-automation.md)
