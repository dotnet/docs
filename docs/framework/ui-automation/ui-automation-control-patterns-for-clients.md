---
title: "UI Automation Control Patterns for Clients"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-bcl"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "UI Automation, control patterns for clients"
  - "control patterns, UI Automation clients"
ms.assetid: 571561d8-5f49-43a9-a054-87735194e013
caps.latest.revision: 24
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# UI Automation Control Patterns for Clients
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This overview introduces control patterns for UI Automation clients. It includes information on how a UI Automation client can use control patterns to access information about the [!INCLUDE[TLA#tla_ui](../../../includes/tlasharptla-ui-md.md)].  
  
 Control patterns provide a way to categorize and expose a control's functionality independent of the control type or the appearance of the control. UI Automation clients can examine an <xref:System.Windows.Automation.AutomationElement> to determine which control patterns are supported and be assured of the behavior of the control.  
  
 For a complete list of control patterns, see [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md).  
  
<a name="uiautomation_getting_control_patterns"></a>   
## Getting Control Patterns  
 Clients retrieve a control pattern from an <xref:System.Windows.Automation.AutomationElement> by calling either <xref:System.Windows.Automation.AutomationElement.GetCachedPattern%2A?displayProperty=nameWithType> or <xref:System.Windows.Automation.AutomationElement.GetCurrentPattern%2A?displayProperty=nameWithType>.  
  
 Clients can use the <xref:System.Windows.Automation.AutomationElement.GetSupportedPatterns%2A> method or an individual `IsPatternAvailable` property (for example, <xref:System.Windows.Automation.AutomationElement.IsTextPatternAvailableProperty>) to determine if a pattern or group of patterns is supported on the <xref:System.Windows.Automation.AutomationElement>. However, it is more efficient to attempt to get the control pattern and test for a `null` reference than to check the supported properties and retrieve the control pattern since it results in fewer cross-process calls.  
  
 The following example demonstrates how to get a <xref:System.Windows.Automation.TextPattern> control pattern from an <xref:System.Windows.Automation.AutomationElement>.  
  
 [!code-csharp[UIATextPattern_snip#1037](../../../samples/snippets/csharp/VS_Snippets_Wpf/UIATextPattern_snip/CSharp/SearchWindow.cs#1037)]  
  
<a name="uiautomation_properties_on_control_patterns"></a>   
## Retrieving Properties on Control Patterns  
 Clients can retrieve the property values on control patterns by calling either <xref:System.Windows.Automation.AutomationElement.GetCachedPropertyValue%2A?displayProperty=nameWithType> or <xref:System.Windows.Automation.AutomationElement.GetCurrentPropertyValue%2A?displayProperty=nameWithType> and casting the object returned to an appropriate type. For more information on [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties, see [UI Automation Properties for Clients](../../../docs/framework/ui-automation/ui-automation-properties-for-clients.md).  
  
 In addition to the `GetPropertyValue` methods, property values can be retrieved through the [!INCLUDE[TLA#tla_clr](../../../includes/tlasharptla-clr-md.md)] accessors to access the [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] properties on a pattern.  
  
<a name="uiautomation_with_variable_patterns"></a>   
## Controls with Variable Patterns  
 Some control types support different patterns depending on their state or the manner in which the control is being used. Examples of controls that can have variable patterns are list views (thumbnails, tiles, icons, list, details), [!INCLUDE[TLA#tla_xl](../../../includes/tlasharptla-xl-md.md)] Charts (Pie, Line, Bar, Cell Value with a formula), [!INCLUDE[TLA#tla_word](../../../includes/tlasharptla-word-md.md)]'s document area (Normal, Web Layout, Outline, Print Layout, Print Preview), and [!INCLUDE[TLA#tla_wmp](../../../includes/tlasharptla-wmp-md.md)] skins.  
  
 Controls implementing custom control types can have any set of control patterns that are needed to represent their functionality.  
  
## See Also  
 [UI Automation Control Patterns](../../../docs/framework/ui-automation/ui-automation-control-patterns.md)  
 [UI Automation Text Pattern](../../../docs/framework/ui-automation/ui-automation-text-pattern.md)  
 [Invoke a Control Using UI Automation](../../../docs/framework/ui-automation/invoke-a-control-using-ui-automation.md)  
 [Get the Toggle State of a Check Box Using UI Automation](../../../docs/framework/ui-automation/get-the-toggle-state-of-a-check-box-using-ui-automation.md)  
 [Control Pattern Mapping for UI Automation Clients](../../../docs/framework/ui-automation/control-pattern-mapping-for-ui-automation-clients.md)  
 [TextPattern Insert Text Sample](http://msdn.microsoft.com/library/67353f93-7ee2-42f2-ab76-5c078cf6ca16)  
 [TextPattern Search and Selection Sample](http://msdn.microsoft.com/library/0a3bca57-8b72-489d-a57c-da85b7a22c7f)  
 [InvokePattern and ExpandCollapsePattern Menu Item Sample](http://msdn.microsoft.com/library/b7fa141c-e2d1-4da2-a27f-81a7d1172210)
