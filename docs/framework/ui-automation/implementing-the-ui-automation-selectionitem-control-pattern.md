---
title: "Implementing the UI Automation SelectionItem Control Pattern"
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
  - "Selection Item control pattern"
  - "UI Automation, Selection Item control pattern"
  - "control patterns, Selection Item"
ms.assetid: 76b0949a-5b23-4cfc-84cc-154f713e2e12
caps.latest.revision: 22
author: "Xansky"
ms.author: "mhopkins"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Implementing the UI Automation SelectionItem Control Pattern
> [!NOTE]
>  This documentation is intended for .NET Framework developers who want to use the managed [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)] classes defined in the <xref:System.Windows.Automation> namespace. For the latest information about [!INCLUDE[TLA2#tla_uiautomation](../../../includes/tla2sharptla-uiautomation-md.md)], see [Windows Automation API: UI Automation](http://go.microsoft.com/fwlink/?LinkID=156746).  
  
 This topic introduces guidelines and conventions for implementing <xref:System.Windows.Automation.Provider.ISelectionItemProvider>, including information about properties, methods, and events. Links to additional references are listed at the end of the overview.  
  
 The <xref:System.Windows.Automation.SelectionItemPattern> control pattern is used to support controls that act as individual, selectable child items of container controls that implement <xref:System.Windows.Automation.Provider.ISelectionProvider>. For examples of controls that implement the SelectionItem control pattern, see [Control Pattern Mapping for UI Automation Clients](../../../docs/framework/ui-automation/control-pattern-mapping-for-ui-automation-clients.md)  
  
<a name="Implementation_Guidelines_and_Conventions"></a>   
## Implementation Guidelines and Conventions  
 When implementing the Selection Item control pattern, note the following guidelines and conventions:  
  
-   Single-selection controls that manage child controls that implement <xref:System.Windows.Automation.Provider.IRawElementProviderFragmentRoot>, such as the **Screen Resolution** slider in the **Display Properties** dialog box, should implement <xref:System.Windows.Automation.Provider.ISelectionProvider> and their children should implement both <xref:System.Windows.Automation.Provider.IRawElementProviderFragment> and <xref:System.Windows.Automation.Provider.ISelectionItemProvider>.  
  
<a name="Required_Members_for_the_IValueProvider_Interface"></a>   
## Required Members for ISelectionItemProvider  
 The following properties, methods, and events are required for implementing <xref:System.Windows.Automation.Provider.ISelectionItemProvider>.  
  
|Required members|Member type|Notes|  
|----------------------|-----------------|-----------|  
|<xref:System.Windows.Automation.Provider.ISelectionProvider.CanSelectMultiple%2A>|Property|None|  
|<xref:System.Windows.Automation.Provider.ISelectionProvider.IsSelectionRequired%2A>|Property|None|  
|<xref:System.Windows.Automation.Provider.ISelectionProvider.GetSelection%2A>|Method|None|  
|<xref:System.Windows.Automation.SelectionPatternIdentifiers.InvalidatedEvent>|Event|Raised when a selection in a container has changed significantly and requires sending more <xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementSelectedEvent> and <xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent> events than the <xref:System.Windows.Automation.Provider.AutomationInteropProvider.InvalidateLimit> constant permits.|  
  
-   If the result of a <xref:System.Windows.Automation.SelectionItemPattern.Select%2A>, an <xref:System.Windows.Automation.SelectionItemPattern.AddToSelection%2A>, or a <xref:System.Windows.Automation.SelectionItemPattern.RemoveFromSelection%2A> is a single selected item, an <xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementSelectedEvent> should be raised; otherwise send <xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementAddedToSelectionEvent>/ <xref:System.Windows.Automation.SelectionItemPatternIdentifiers.ElementRemovedFromSelectionEvent> as appropriate.  
  
<a name="Exceptions"></a>   
## Exceptions  
 Providers must throw the following exceptions.  
  
|Exception type|Condition|  
|--------------------|---------------|  
|<xref:System.InvalidOperationException>|When any of the following are attempted:<br /><br /> -   <xref:System.Windows.Automation.Provider.ISelectionItemProvider.RemoveFromSelection%2A> is called on a single-selection container where <xref:System.Windows.Automation.SelectionPattern.IsSelectionRequiredProperty> = `true` and an element is already selected.<br />-   <xref:System.Windows.Automation.Provider.ISelectionItemProvider.RemoveFromSelection%2A> is called on a multiple-selection container where <xref:System.Windows.Automation.SelectionPattern.IsSelectionRequiredProperty> = `true` and only one element is selected.<br />-   <xref:System.Windows.Automation.Provider.ISelectionItemProvider.AddToSelection%2A> is called on a single-selection container where <xref:System.Windows.Automation.SelectionPattern.CanSelectMultipleProperty> = `false` and another element is already selected.|  
  
## See Also  
 [UI Automation Control Patterns Overview](../../../docs/framework/ui-automation/ui-automation-control-patterns-overview.md)  
 [Support Control Patterns in a UI Automation Provider](../../../docs/framework/ui-automation/support-control-patterns-in-a-ui-automation-provider.md)  
 [UI Automation Control Patterns for Clients](../../../docs/framework/ui-automation/ui-automation-control-patterns-for-clients.md)  
 [Implementing the UI Automation Selection Control Pattern](../../../docs/framework/ui-automation/implementing-the-ui-automation-selection-control-pattern.md)  
 [UI Automation Tree Overview](../../../docs/framework/ui-automation/ui-automation-tree-overview.md)  
 [Use Caching in UI Automation](../../../docs/framework/ui-automation/use-caching-in-ui-automation.md)  
 [Fragment Provider Sample](http://msdn.microsoft.com/library/778ef1bc-8610-4bc9-886e-aeff94a8a13e)
