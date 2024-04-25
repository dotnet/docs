---
title: "UI Automation Control Patterns for Clients"
description: Read an overview about control patterns for UI Automation clients. Use control patterns to access information about the user interface (UI).
ms.date: "03/30/2017"
helpviewer_keywords:
  - "UI Automation, control patterns for clients"
  - "control patterns, UI Automation clients"
---
# UI Automation Control Patterns for Clients

> [!NOTE]
> This documentation is intended for .NET Framework developers who want to use the managed UI Automation classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about UI Automation, see [Windows Automation API: UI Automation](/windows/win32/winauto/entry-uiauto-win32).

 This overview introduces control patterns for UI Automation clients. It includes information on how a UI Automation client can use control patterns to access information about the user interface (UI).

 Control patterns provide a way to categorize and expose a control's functionality independent of the control type or the appearance of the control. UI Automation clients can examine an <xref:System.Windows.Automation.AutomationElement> to determine which control patterns are supported and be assured of the behavior of the control.

 For a complete list of control patterns, see [UI Automation Control Patterns Overview](ui-automation-control-patterns-overview.md).

<a name="uiautomation_getting_control_patterns"></a>

## Getting Control Patterns

 Clients retrieve a control pattern from an <xref:System.Windows.Automation.AutomationElement> by calling either <xref:System.Windows.Automation.AutomationElement.GetCachedPattern%2A?displayProperty=nameWithType> or <xref:System.Windows.Automation.AutomationElement.GetCurrentPattern%2A?displayProperty=nameWithType>.

 Clients can use the <xref:System.Windows.Automation.AutomationElement.GetSupportedPatterns%2A> method or an individual `IsPatternAvailable` property (for example, <xref:System.Windows.Automation.AutomationElement.IsTextPatternAvailableProperty>) to determine if a pattern or group of patterns is supported on the <xref:System.Windows.Automation.AutomationElement>. However, it is more efficient to attempt to get the control pattern and test for a `null` reference than to check the supported properties and retrieve the control pattern since it results in fewer cross-process calls.

 The following example demonstrates how to get a <xref:System.Windows.Automation.TextPattern> control pattern from an <xref:System.Windows.Automation.AutomationElement>.

 [!code-csharp[UIATextPattern_snip#1037](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIATextPattern_snip/CSharp/SearchWindow.cs#1037)]

<a name="uiautomation_properties_on_control_patterns"></a>

## Retrieving Properties on Control Patterns

 Clients can retrieve the property values on control patterns by calling either <xref:System.Windows.Automation.AutomationElement.GetCachedPropertyValue%2A?displayProperty=nameWithType> or <xref:System.Windows.Automation.AutomationElement.GetCurrentPropertyValue%2A?displayProperty=nameWithType> and casting the object returned to an appropriate type. For more information on UI Automation properties, see [UI Automation Properties for Clients](ui-automation-properties-for-clients.md).

 In addition to the `GetPropertyValue` methods, property values can be retrieved through the common language runtime (CLR) accessors to access the UI Automation properties on a pattern.

<a name="uiautomation_with_variable_patterns"></a>

## Controls with Variable Patterns

 Some control types support different patterns depending on their state or the manner in which the control is being used. Examples of controls that can have variable patterns are list views (thumbnails, tiles, icons, list, details), Microsoft Excel Charts (Pie, Line, Bar, Cell Value with a formula), Microsoft Word's document area (Normal, Web Layout, Outline, Print Layout, Print Preview), and Microsoft Windows Media Player skins.

 Controls implementing custom control types can have any set of control patterns that are needed to represent their functionality.

## See also

- [UI Automation Control Patterns](ui-automation-control-patterns.md)
- [UI Automation Text Pattern](ui-automation-text-pattern.md)
- [Invoke a Control Using UI Automation](invoke-a-control-using-ui-automation.md)
- [Get the Toggle State of a Check Box Using UI Automation](get-the-toggle-state-of-a-check-box-using-ui-automation.md)
- [Control Pattern Mapping for UI Automation Clients](control-pattern-mapping-for-ui-automation-clients.md)
- [TextPattern Insert Text Sample](https://github.com/Microsoft/WPF-Samples/tree/main/Accessibility/InsertText)
- [TextPattern Search and Selection Sample](https://github.com/Microsoft/WPF-Samples/tree/main/Accessibility/FindText)
- [InvokePattern, ExpandCollapsePattern, and TogglePattern Sample](https://github.com/Microsoft/WPF-Samples/tree/main/Accessibility/InvokePattern)
